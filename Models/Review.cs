using System;
using System.ComponentModel.DataAnnotations;

namespace TravelBookingSystem.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; } // 1 to 5 stars

        public string? Comment { get; set; }

        public string? UserName { get; set; }

        public DateTime ReviewDate { get; set; }

        // Foreign Key to link to a Package
        public int PackageId { get; set; }
        public virtual Package? Package { get; set; }
    }
} 