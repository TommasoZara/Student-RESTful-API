using API;
using API.Data;
using API.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace API.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }

    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly ApiDbContext _dbContext;

        public UserService(IOptions<AppSettings> appSettings, ApiDbContext context)
        {
            _appSettings = appSettings.Value;
            _dbContext = context;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = GetAll()?.SingleOrDefault(x => x.Username == model.Username && x.Password == model?.Password?.CreateMD5());

            if (user == null) //--- se non trovo niente esco 
                return null;

            var token = generateJwtToken(user);
            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll() =>_dbContext.Users.ToList();

        public User GetById(int id) => GetAll()?.FirstOrDefault(x => x.Id == id);

        
        private string generateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),                                                                                   //--- token valido per 7 giorni
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}