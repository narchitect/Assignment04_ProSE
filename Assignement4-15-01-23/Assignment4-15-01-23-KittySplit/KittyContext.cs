using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Assignment4_15_01_23_KittySplit
{
    public class KittyContext : DbContext
    {
        public DbSet<Kitty> Kitties { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=D:\\001_ITBE-Master\\ProSE\\Assignement4-15-01-23\\Assignment4-15-01-23-KittySplit\\KittyDatabase.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) // function to define relations among different sets in a database
        {
            // one - many
            modelBuilder.Entity<Participant>()
                .HasOne(p => p.Kitty)
                .WithMany(k => k.Pariticipants)
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
