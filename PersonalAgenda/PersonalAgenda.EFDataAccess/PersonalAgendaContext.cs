using Microsoft.EntityFrameworkCore;
using PersonalAgenda.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalAgenda.EFDataAccess
{
    public class PersonalAgendaContext : DbContext
    {
        public DbSet<Meeting> Meetings { get; set; }

        public DbSet<Meetup> Meetups { get; set; }

        public DbSet<Shopping> Shoppings { get; set; }

        public PersonalAgendaContext(DbContextOptions<PersonalAgendaContext> options) :
            base(options)
        {
                
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meeting>().HasKey(e => e.Id);
            modelBuilder.Entity<Meeting>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Meeting>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Meeting>().Property(e => e.Description).IsRequired();
            modelBuilder.Entity<Meeting>().Property(e => e.DateAndTime).IsRequired();
            modelBuilder.Entity<Meeting>().Property(e => e.CompanyName).IsRequired();

            modelBuilder.Entity<Meetup>().HasKey(e => e.Id);
            modelBuilder.Entity<Meetup>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Meetup>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Meetup>().Property(e => e.Description).IsRequired();
            modelBuilder.Entity<Meetup>().Property(e => e.DateAndTime).IsRequired();

            modelBuilder.Entity<Shopping>().HasKey(e => e.Id);
            modelBuilder.Entity<Shopping>().Property(e => e.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Shopping>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Shopping>().Property(e => e.Description).IsRequired();
            modelBuilder.Entity<Shopping>().Property(e => e.Budget).HasColumnType("decimal(18,2)").IsRequired();  
        }
    }
}
