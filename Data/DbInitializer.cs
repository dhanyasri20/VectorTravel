using Microsoft.EntityFrameworkCore;
using TravelBookingSystem.Models;

namespace TravelBookingSystem.Data
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();

                if (context != null)
                {
                    // Check if the database exists, if not, create it.
                    context.Database.EnsureCreated();

                    // Look for any flights. If there are any, the database has already been seeded.
                    if (context.Flights.Any())
                    {
                        return;
                    }

                    var flights = new Flight[]
 {
    // --- Delhi to Mumbai ---
    // Oct 15
    new Flight{ Airline="IndiGo", DepartureCity="Delhi", ArrivalCity="Mumbai", DepartureTime=DateTime.Parse("2025-10-15 18:00"), ArrivalTime=DateTime.Parse("2025-10-15 20:00"), Price=5200, FlightNumber="6E-5032", AircraftType="A321"},
    new Flight{ Airline="Vistara", DepartureCity="Delhi", ArrivalCity="Mumbai", DepartureTime=DateTime.Parse("2025-10-15 09:30"), ArrivalTime=DateTime.Parse("2025-10-15 11:45"), Price=6100, FlightNumber="UK-971", AircraftType="B787"},
    // Oct 16
    new Flight{ Airline="Air India", DepartureCity="Delhi", ArrivalCity="Mumbai", DepartureTime=DateTime.Parse("2025-10-16 23:20"), ArrivalTime=DateTime.Parse("2025-10-17 01:20"), Price=4500, FlightNumber="AI-202", AircraftType="A320neo"},

    // --- Bangalore to Delhi ---
    // Oct 17
    new Flight{ Airline="SpiceJet", DepartureCity="Bangalore", ArrivalCity="Delhi", DepartureTime=DateTime.Parse("2025-10-17 06:15"), ArrivalTime=DateTime.Parse("2025-10-17 08:45"), Price=7500, FlightNumber="SG-805", AircraftType="B737"},
    new Flight{ Airline="Vistara", DepartureCity="Bangalore", ArrivalCity="Delhi", DepartureTime=DateTime.Parse("2025-10-17 11:00"), ArrivalTime=DateTime.Parse("2025-10-17 13:30"), Price=8100, FlightNumber="UK-819", AircraftType="A320"},

    // --- Mumbai to Bangalore ---
    // Oct 18
    new Flight{ Airline="IndiGo", DepartureCity="Mumbai", ArrivalCity="Bangalore", DepartureTime=DateTime.Parse("2025-10-18 14:00"), ArrivalTime=DateTime.Parse("2025-10-18 15:45"), Price=3800, FlightNumber="6E-2044", AircraftType="A320"},
    new Flight{ Airline="Air India", DepartureCity="Mumbai", ArrivalCity="Bangalore", DepartureTime=DateTime.Parse("2025-10-18 19:00"), ArrivalTime=DateTime.Parse("2025-10-18 20:50"), Price=4200, FlightNumber="AI-607", AircraftType="A321"},

    // --- Chennai to Delhi ---
    // Oct 18
    new Flight{ Airline="SpiceJet", DepartureCity="Chennai", ArrivalCity="Delhi", DepartureTime=DateTime.Parse("2025-10-18 20:00"), ArrivalTime=DateTime.Parse("2025-10-18 22:45"), Price=6800, FlightNumber="SG-3324", AircraftType="B737"},

    // --- Kolkata to Mumbai ---
    // Oct 19
    new Flight{ Airline="Vistara", DepartureCity="Kolkata", ArrivalCity="Mumbai", DepartureTime=DateTime.Parse("2025-10-19 17:30"), ArrivalTime=DateTime.Parse("2025-10-19 20:10"), Price=7200, FlightNumber="UK-774", AircraftType="A320"},

    // --- NEW: Vizag to Delhi ---
    // Oct 20
    new Flight{ Airline="Air India", DepartureCity="Vizag", ArrivalCity="Delhi", DepartureTime=DateTime.Parse("2025-10-20 07:00"), ArrivalTime=DateTime.Parse("2025-10-20 09:15"), Price=5800, FlightNumber="AI-452", AircraftType="A320neo"},
    new Flight{ Airline="IndiGo", DepartureCity="Vizag", ArrivalCity="Delhi", DepartureTime=DateTime.Parse("2025-10-20 15:30"), ArrivalTime=DateTime.Parse("2025-10-20 17:45"), Price=6300, FlightNumber="6E-2022", AircraftType="A320"}
         };
                    context.Flights.AddRange(flights);
                    context.SaveChanges();
                }
            }
        }
    }
} 