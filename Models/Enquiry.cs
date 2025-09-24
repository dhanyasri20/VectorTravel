using System;
using System.ComponentModel.DataAnnotations;

namespace TravelBookingSystem.Models
{
    public class Enquiry
    {
        public int Id { get; set; }

        [Required]
        public string? PackageName { get; set; }

        [Required]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? PhoneNumber { get; set; }

        public DateTime EnquiryDate { get; set; }
    }
} 