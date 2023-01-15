using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Assignment04_ProSE
{
    public class KittySplitContext : DbContext
    {

        public DbSet<Kitty> Kitties { get; set;}
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=/Users/kimnayun/Projects/Assignment04_TUM22/Assignment04_ProSE/Data/KittySplitDB.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // function to define relations among different sets in a database
        {
            // one - many
            modelBuilder.Entity<Participant>()
                .HasOne(p => p.Kitty)
                .WithMany(k => k.Participants)
                .HasForeignKey(p => p.KittyId);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Participant)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ParticipantId);

            modelBuilder.Entity<Payment>()
                 .HasOne(pay => pay.Participant)
                 .WithMany(p => p.Payments)
                 .HasForeignKey(pay => pay.ParticipantId);

            // conversion configuration
            modelBuilder.Entity<Kitty>()
                .Property(k => k.HomeCurrency)
                .HasConversion(v => v.ToString(), v => (Currency)Enum.Parse(typeof(Currency), v));

            modelBuilder.Entity<Participant>()
                .Property(p => p.Seen)
                .HasDefaultValue(false);

            modelBuilder.Entity<Participant>()
                .Property(p => p.Mark)
                .HasDefaultValue(false);
        }
    }
}
