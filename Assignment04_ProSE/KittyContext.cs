using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Assignment04_ProSE
{
    public class KittyContext : DbContext
    {
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source=./Users/kimnayun/Projects/Assignment04_TUM22");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // function to define relations among different sets in a database
        {
            /* relations are not required for this example but you can add them if you want, using syntax as follow:
              modelBuilder.Entity<Pokemon> ().HasOne(t => t.type); */
        }
    }
}
