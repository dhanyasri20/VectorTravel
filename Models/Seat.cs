namespace TravelBookingSystem.Models
{
    public class Seat
    {
        public int Id { get; set; }
        public string? SeatNumber { get; set; } // e.g., "1A", "12C"
        public bool IsAvailable { get; set; } = true;

        // Foreign Key for Flight
        public int FlightId { get; set; }
        public virtual Flight? Flight { get; set; }
    }
} 