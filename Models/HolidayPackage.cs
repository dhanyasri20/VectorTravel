using System.Collections.Generic;

namespace TravelBookingSystem.Models
{
    public class HolidayPackage
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public int DurationDays { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public List<string> Inclusions { get; set; }
        public List<ItineraryDay> Itinerary { get; set; }

        // ## ADDED THESE TWO LINES ##
        public string BadgeText { get; set; }
        public string BadgeColor { get; set; }
    }

    public class ItineraryDay
    {
        public int Day { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
} 