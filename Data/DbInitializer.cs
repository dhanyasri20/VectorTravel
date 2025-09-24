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
                    context.Database.EnsureCreated();

                    // This check stops the seeder from running if there is already flight data.
                    if (context.Flights.Any())
                    {
                        return;
                    }

                    var flights = new Flight[]
                    {
                        // --- October Flights ---
                        new Flight{ Airline="IndiGo", DepartureCity="Delhi", ArrivalCity="Mumbai", DepartureTime=DateTime.Parse("2025-10-15 18:00"), ArrivalTime=DateTime.Parse("2025-10-15 20:00"), Price=5200, FlightNumber="6E-5032", AircraftType="A321"},
                        new Flight{ Airline="Vistara", DepartureCity="Delhi", ArrivalCity="Mumbai", DepartureTime=DateTime.Parse("2025-10-15 09:30"), ArrivalTime=DateTime.Parse("2025-10-15 11:45"), Price=6100, FlightNumber="UK-971", AircraftType="B787"},
                        new Flight{ Airline="Air India", DepartureCity="Delhi", ArrivalCity="Mumbai", DepartureTime=DateTime.Parse("2025-10-16 23:20"), ArrivalTime=DateTime.Parse("2025-10-17 01:20"), Price=4500, FlightNumber="AI-202", AircraftType="A320neo"},
                        new Flight{ Airline="SpiceJet", DepartureCity="Bangalore", ArrivalCity="Delhi", DepartureTime=DateTime.Parse("2025-10-17 06:15"), ArrivalTime=DateTime.Parse("2025-10-17 08:45"), Price=7500, FlightNumber="SG-805", AircraftType="B737"},
                        new Flight{ Airline="Vistara", DepartureCity="Bangalore", ArrivalCity="Delhi", DepartureTime=DateTime.Parse("2025-10-17 11:00"), ArrivalTime=DateTime.Parse("2025-10-17 13:30"), Price=8100, FlightNumber="UK-819", AircraftType="A320"},
                        new Flight{ Airline="IndiGo", DepartureCity="Mumbai", ArrivalCity="Bangalore", DepartureTime=DateTime.Parse("2025-10-18 14:00"), ArrivalTime=DateTime.Parse("2025-10-18 15:45"), Price=3800, FlightNumber="6E-2044", AircraftType="A320"},

                        // --- September Flights ---
                        new Flight{ Airline="Vistara", DepartureCity="Hyderabad", ArrivalCity="Delhi", DepartureTime=DateTime.Parse("2025-09-23 08:00"), ArrivalTime=DateTime.Parse("2025-09-23 10:10"), Price=5900, FlightNumber="UK-840", AircraftType="A320"},
                        new Flight{ Airline="IndiGo", DepartureCity="Mumbai", ArrivalCity="Kolkata", DepartureTime=DateTime.Parse("2025-09-24 11:30"), ArrivalTime=DateTime.Parse("2025-09-24 14:00"), Price=7100, FlightNumber="6E-5321", AircraftType="A321"},
                        new Flight{ Airline="Air India", DepartureCity="Delhi", ArrivalCity="Chennai", DepartureTime=DateTime.Parse("2025-09-25 05:45"), ArrivalTime=DateTime.Parse("2025-09-25 08:30"), Price=6500, FlightNumber="AI-550", AircraftType="B787"},
                        new Flight{ Airline="Vistara", DepartureCity="Bangalore", ArrivalCity="Mumbai", DepartureTime=DateTime.Parse("2025-09-26 21:00"), ArrivalTime=DateTime.Parse("2025-09-26 22:45"), Price=4800, FlightNumber="UK-809", AircraftType="A320"},

                        // --- November Flights ---
                        new Flight{ Airline="IndiGo", DepartureCity="Delhi", ArrivalCity="Hyderabad", DepartureTime=DateTime.Parse("2025-11-05 10:00"), ArrivalTime=DateTime.Parse("2025-11-05 12:15"), Price=5600, FlightNumber="6E-602", AircraftType="A320neo"},
                        new Flight{ Airline="Vistara", DepartureCity="Kolkata", ArrivalCity="Bangalore", DepartureTime=DateTime.Parse("2025-11-05 19:45"), ArrivalTime=DateTime.Parse("2025-11-05 22:15"), Price=8200, FlightNumber="UK-748", AircraftType="A321"},
                        new Flight{ Airline="Air India", DepartureCity="Mumbai", ArrivalCity="Delhi", DepartureTime=DateTime.Parse("2025-11-06 13:00"), ArrivalTime=DateTime.Parse("2025-11-06 15:00"), Price=6100, FlightNumber="AI-660", AircraftType="B787"}
                    };
                    context.Flights.AddRange(flights);
                    context.SaveChanges();
                }
            }
        }
    }
} 