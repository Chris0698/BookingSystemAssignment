///Chris Aston, Carlton Evans, Sam Noble

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImplementationOfObjectOrientedDesigns.Domain;
using System.Data.Entity;

namespace ImplementationOfObjectOrientedDesigns.DataAccess
{
    public partial class DatabaseEntities : DbContext
    {
        public DatabaseEntities() : base("connectionString")
        {

        }

        public DbSet<Client> Client { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Venue> Venue { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<VenueExtrasLink> VenueExtrasLink { get; set; }
        public DbSet<VenueDecorator> VenueDecorator { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}