using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using xUnitTestAspNetCore.Entities.Models;

namespace xUnitTestAspNetCore.DAL.Contexts
{
    public class UserDataContext :  DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-DPCC3SS\\MUSTAFA;Database=xUnitDb;Trusted_Connection=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>().Property(e => e.userId).ValueGeneratedNever();
        }

        // dotnet ef migrations add initialcreate --context UserDataContext
        // dotnet ef database update --context UserDataContext

    }
}
