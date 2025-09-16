using TravelBookingSystem.Areas.Identity.Data;

namespace TravelBookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string? UserId { get; set; }
        public DateTime BookingDate { get; set; }

        // Navigation properties
        public Flight? Flight { get; set; }
        public TravelBookingSystemUser? User { get; set; }
    }
} 