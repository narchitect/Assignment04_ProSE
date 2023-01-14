using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Assignment04_ProSE
{
    public class KittyContext : DbContext
    {

        public DbSet<Kitty> Kitties { get; set;}
        public DbSet<Participant> Participants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/Users/kimnayun/Projects/Assignment04_TUM22/Assignment04_ProSE/KittyDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // function to define relations among different sets in a database
        {
            modelBuilder.Entity<Participant>()
                .HasOne(p => p.Kitty)
                .WithMany(k => k.Pariticipants)
                .HasForeignKey(p => p.KittyId);

            modelBuilder.Entity<Kitty>()
                .Property(k => k.HomeCurrency)
                .HasConversion(v => v.ToString(), v => (Currency)Enum.Parse(typeof(Currency), v));

            modelBuilder.Entity<Participant>()
                .Property(p => p.Seen)
                .HasDefaultValue(false);
            //// . chaining Method to return same dataType
            //modelBuilder.Entity<PaymentParticipants>() //inside PaymentParticipants entity
            //    .HasOne<Participant>(pp => pp.Sender) //one Participant entity has 1->m 1 is pt.sender 
            //    .WithMany(p => p.PaymentParticipants) 
            //    .HasForeignKey(pp => pp.SenderId); 

            //modelBuilder.Entity<PaymentParticipants>() //inside PaymentParticipants entity
            //    .HasOne<Participant>(pp => pp.Receiver) //one Participant entity has 1->m 1 is pt.sender 
            //    .WithMany(p => p.PaymentParticipants) // one participant has many pp.
            //    .HasForeignKey(pp => pp.SenderId);

            //modelBuilder.Entity<PaymentParticipants>()
            //    .HasOne<Payment>(pp => pp.Payment)
            //    .WithMany(pay => pay.)
        }
    }
}
