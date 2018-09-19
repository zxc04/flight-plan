using Microsoft.EntityFrameworkCore;

namespace FlightPlan.Sql.Entities
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Plane> Planes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airport>().ToTable("Airport");
            modelBuilder.Entity<Airport>().HasMany(a => a.DepartureFlights).WithOne(f => f.DepartureAirport).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Airport>().HasMany(a => a.ArrivalFlights).WithOne(f => f.ArrivalAirport).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Plane>().ToTable("Plane");
            modelBuilder.Entity<Plane>().HasMany(p => p.Flights).WithOne(f => f.Plane).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Flight>().ToTable("Flight");
        }
    }
}
