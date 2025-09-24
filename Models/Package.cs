using System.Collections.Generic;

namespace TravelBookingSystem.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Destination { get; set; }
        public string? Duration { get; set; }
        public decimal Price { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? Category { get; set; }
        public string? Tag { get; set; }

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>(); 
    }
} 