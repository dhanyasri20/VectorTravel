using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TravelBookingSystem.Models;

namespace TravelBookingSystem.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var holidayPackages = new List<HolidayPackage>
            {
                new HolidayPackage
                {
                    Id = 1,
                    Title = "Romantic Gateway to the Maldives",
                    Description = "Book your 2nd–5th October long weekend trip now. Use Code: MOSTWNTD.",
                    ImageUrl = "https://images.pexels.com/photos/279574/pexels-photo-279574.jpeg",
                    BadgeText = "HOLIDAYS",      // These properties are not on the HolidayPackage model
                    BadgeColor = "bg-primary"    
                },
                new HolidayPackage
                { 
                    Id = 2,
                    Title = "Enchanting Week in Switzerland",
                    Description = "Get Up to ₹10,000 OFF on Intl' flights and Hotels.",
                    ImageUrl = "https://cdn.pixabay.com/photo/2019/12/15/18/24/winter-4697776_1280.jpg",
                    BadgeText = "INT'L FLIGHTS",
                    BadgeColor = "bg-success"
                },
                new HolidayPackage
                {
                    Id = 3,
                    Title = "Vibrant Exploration of Dubai",
                    Description = "Up to 35% OFF* on your international trips.",
                    ImageUrl = "https://images.pexels.com/photos/1467300/pexels-photo-1467300.jpeg",
                    BadgeText = "LIVE NOW",
                    BadgeColor = "bg-danger"
                }
            };
            ViewBag.Offers = holidayPackages;


            // Your existing code for Handpicked Collections (No changes needed)
            var collections = new List<Collection>
            {
                new Collection { Title = "Weekend Getaways", Tagline = "Stays in & Around Mumbai", ImageUrl = "https://images.pexels.com/photos/4877857/pexels-photo-4877857.jpeg", BadgeText = "TOP 8" },
                new Collection { Title = "Beach Destinations", Tagline = "Relax by the Sea", ImageUrl = "https://images.pexels.com/photos/33865577/pexels-photo-33865577.jpeg", BadgeText = "TOP 11" },
                new Collection { Title = "Hill Stations", Tagline = "Escape to the Mountains", ImageUrl = "https://images.pexels.com/photos/3652252/pexels-photo-3652252.jpeg", BadgeText = "TOP 11" },
                new Collection { Title = "Adventure Trips", Tagline = "For the Thrill-Seekers", ImageUrl = "https://images.pexels.com/photos/4353813/pexels-photo-4353813.jpeg", BadgeText = "TOP 5" },
                new Collection { Title = "Romantic Escapes", Tagline = "Perfect for Couples", ImageUrl = "https://images.pexels.com/photos/261102/pexels-photo-261102.jpeg", BadgeText = "TOP 7" },
                new Collection { Title = "Luxury Stays", Tagline = "Indulge in Opulence", ImageUrl = "https://images.pexels.com/photos/751268/pexels-photo-751268.jpeg", BadgeText = "TOP 7" },
                new Collection { Title = "City Breaks", Tagline = "Explore Urban Landscapes", ImageUrl = "https://images.pexels.com/photos/33791949/pexels-photo-33791949.jpeg", BadgeText = "TOP 9" }
            };
            ViewBag.Collections = collections;

            // Your existing code for Trip of the Week (No changes needed)
            var tripOfTheWeek = new Trip
            {
                Title = "Discover the Andaman Islands",
                Tagline = "7 Days, 6 Nights of Tropical Paradise",
                Description = "Explore pristine beaches, vibrant coral reefs, and lush forests. An unforgettable escape awaits.",
                ImageUrl = "https://images.pexels.com/photos/1481096/pexels-photo-1481096.jpeg",
                Price = 49999
            };
            ViewBag.TripOfTheWeek = tripOfTheWeek;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
} 