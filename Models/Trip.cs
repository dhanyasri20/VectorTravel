namespace TravelBookingSystem.Models
{
    public class Trip
    {
        public string Title { get; set; }
        public string Tagline { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public decimal Price { get; set; }
        public List<string> GalleryImageUrls { get; set; } 
    }
} 