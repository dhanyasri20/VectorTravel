using System;
using System.Collections.Generic;

namespace TravelBookingSystem.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string? FlightNumber { get; set; }
        public string? Airline { get; set; }
        public string? DepartureCity { get; set; }
        public string? ArrivalCity { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string? AircraftType { get; set; }
        public decimal Price { get; set; }

        // --- SEAT SELECTION PROPERTY ---
        public virtual ICollection<Seat> Seats { get; set; } = new List<Seat>();
    }
} 