using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment04_ProSE
{
    public class KittyContext : DbContext
    {
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Kitty> Kitties { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlite("Data Source=D:\\001_ITBE-Master\\ProSE\\Assignment4\\Solution-Assignment4-TW\\ExpenseDatabase.db");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // function to define relations among different sets in a database
        {
            /* relations are not required for this example but you can add them if you want, using syntax as follow:
              modelBuilder.Entity<Pokemon> ().HasOne(t => t.type); */
        }
    }
}
