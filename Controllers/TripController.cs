using Microsoft.AspNetCore.Mvc;
using TravelBookingSystem.Models;

namespace TravelBookingSystem.Controllers
{
    public class TripController : Controller
    {
        public IActionResult Details()
        {
            // In a real app, you would get this data from a database using an ID.
            var tripDetails = new Trip
            {
                Title = "Discover the Andaman Islands",
                Tagline = "7 Days, 6 Nights of Tropical Paradise",
                Description = "Explore pristine beaches, vibrant coral reefs, and lush forests. An unforgettable escape awaits.",
                ImageUrl = "https://images.pexels.com/photos/1483053/pexels-photo-1483053.jpeg", // A more stunning header image
                Price = 49999,
                GalleryImageUrls = new List<string>
                {
                    // The images you provided, plus a few more to make the gallery look full
                    "https://images.pexels.com/photos/237272/pexels-photo-237272.jpeg",
                    "https://images.pexels.com/photos/1190298/pexels-photo-1190298.jpeg",
                    "https://images.pexels.com/photos/240561/pexels-photo-240561.jpeg",
                    "https://images.pexels.com/photos/2087391/pexels-photo-2087391.jpeg",
                    "https://images.pexels.com/photos/1658967/pexels-photo-1658967.jpeg",
                    "https://images.pexels.com/photos/261101/pexels-photo-261101.jpeg"
                }
            };

            return View(tripDetails);
        }
    }
} 