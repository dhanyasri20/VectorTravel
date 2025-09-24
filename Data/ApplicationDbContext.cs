using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TravelBookingSystem.Areas.Identity.Data;
using TravelBookingSystem.Models;

namespace TravelBookingSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext<TravelBookingSystemUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Seat> Seats { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<Enquiry> Enquiries { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Inspiration> Inspirations { get; set; } 

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // This configuration tells the database the exact precision for decimal types,
            // which is a professional best practice and removes the warnings.
            builder.Entity<Flight>().Property(f => f.Price).HasColumnType("decimal(18, 2)");
            builder.Entity<Booking>().Property(b => b.Amount).HasColumnType("decimal(18, 2)");
            builder.Entity<Package>().Property(p => p.Price).HasColumnType("decimal(18, 2)");
        }
    }
} 