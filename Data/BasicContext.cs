using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketPlatform.Data.Entity;

namespace TicketPlatform.Data
{
    public class BasicContext : DbContext
    {
        //tabloların projeye tanıtılması ve ıslem ıcın aktıf hale getırme.
        public BasicContext(DbContextOptions<BasicContext> options) : base(options)
        { }

        public DbSet<User> Customers { get; set; }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<BusLocations> BusLocations { get; set; }

        public DbSet<BusJourney> BusJourneys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Customer");
            modelBuilder.Entity<Session>().ToTable("Session");
            modelBuilder.Entity<BusLocations>().ToTable("BusLocations");
            modelBuilder.Entity<BusJourney>().ToTable("BusJourney");
        }
    }
}
