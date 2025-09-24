using System;
using TravelBookingSystem.Areas.Identity.Data;

namespace TravelBookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string? UserId { get; set; }
        public DateTime BookingDate { get; set; }
        public decimal Amount { get; set; }
        public string? PaymentId { get; set; }
        public string? SelectedSeat { get; set; }

        // --- ADD THESE TWO LINES ---
        public string? PassengerName { get; set; }
        public string? Status { get; set; }


        // Navigation properties
        public virtual Flight? Flight { get; set; }
        public virtual TravelBookingSystemUser? User { get; set; }
    }
} 