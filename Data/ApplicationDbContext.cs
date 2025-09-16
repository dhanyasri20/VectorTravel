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

        public DbSet<Flight> Flights { get; set; }
        public DbSet<Booking> Bookings { get; set; } // This line is essential

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Flight>()
                .Property(f => f.Price)
                .HasColumnType("decimal(18, 2)");
        }
    }
} 