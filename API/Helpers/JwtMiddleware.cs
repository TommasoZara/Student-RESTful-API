using API;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        private readonly ILogger<JwtMiddleware> _logger;


        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings, ILogger<JwtMiddleware> logger)
        {
            _next = next;
            _appSettings = appSettings.Value;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ")?.Last();

            if (token != null)
                attachUserToContext(context, userService, token);

            await _next(context);
        }

        private void attachUserToContext(HttpContext context, IUserService userService, string token)
        {
            try
            {
                var key = Encoding.ASCII.GetBytes(_appSettings?.Secret);

                new JwtSecurityTokenHandler()
                    .ValidateToken(token, new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(key),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            ClockSkew = TimeSpan.Zero                                           //--- differenza oraria massima consentita tra le impostazioni dell'orologio client e server
                        }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var userId = int.Parse(jwtToken?.Claims?.First(x => x.Type == "id")?.Value);

                context.Items["User"] = userService.GetById(userId);                            //--- Rispondo con l'utente completo che si è loggato
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, nameof(JwtMiddleware));
            }

        }
    }
}