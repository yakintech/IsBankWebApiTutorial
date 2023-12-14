﻿using Microsoft.EntityFrameworkCore;

namespace IsBankWebApiTutorial.Models.ORM
{
    public class IsBankDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EET2RGT; Database=Isbankdb; trusted_connection=true");
        }

        public DbSet<Customer> Customers { get; set; }
    }
}
