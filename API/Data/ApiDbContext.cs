using API.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class ApiDbContext : DbContext
    {
        public virtual DbSet<User> Users { get; set; }
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[] {
                new User{Id=1, FirstName="Tommaso", LastName="Zarantonello", Password="Zarantonello".CreateMD5(), Username="Tommaso"},
            });
        }
    }
}
