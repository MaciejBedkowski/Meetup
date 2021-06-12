using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meetup.Entities
{
    public class MeetupDBContext : DbContext
    {
        private string _connectionString = (@"Server=FDBSTY1\SQLEXPRESS;Database=MeetupDb;Trusted_Connection=True;");
        public DbSet<Meet> Meets { get; set; }
        public DbSet<Participant> Participants { get; set; }

        //Method override for required parameters Participants
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Participant>()
                .Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(20);

            modelBuilder.Entity<Participant>()
                .Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(25);

            modelBuilder.Entity<Participant>()
                .Property(x => x.EMail)
                .IsRequired();
        }

        //Specification of connections to the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
