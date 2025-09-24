using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TravelBookingSystem.Models;

namespace TravelBookingSystem.Controllers
{
    public class PackagesController : Controller
    {
        private readonly List<HolidayPackages> _packages;

        public PackagesController()
        {
            // ## FINAL VERSION ## With complete itineraries and your original Pexels image links.
            _packages = new List<HolidayPackages>
            {
                new HolidayPackages
                {
                    Id = 1, 
                    Title = "Romantic Gateway to the Maldives",
                    Location = "Maldives",
                    DurationDays = 5,
                    Price = 75000,
                    ImageUrl = "https://images.pexels.com/photos/12516848/pexels-photo-12516848.jpeg",
                    Inclusions = new List<string> { "Flights", "4-Star Water Villa", "Airport Transfers", "Breakfast & Dinner" },
                    Itinerary = new List<ItineraryDay>
                    {
                        new ItineraryDay { Day = 1, Title = "Arrival in Malé", Description = "Welcome to paradise! You'll be greeted at the airport and transferred to your beautiful water villa via a scenic speedboat ride." },
                        new ItineraryDay { Day = 2, Title = "Water Sports Adventure", Description = "Enjoy a thrilling day of snorkeling and jet-skiing in the crystal-clear lagoon. Discover vibrant coral reefs and marine life." },
                        new ItineraryDay { Day = 3, Title = "Relax and Rejuvenate", Description = "A day of leisure. Indulge in a couple's spa treatment, relax on the pristine white-sand beaches, or enjoy the amenities of your resort." },
                        new ItineraryDay { Day = 4, Title = "Sunset Dolphin Cruise", Description = "Embark on a magical evening cruise. Witness dozens of playful dolphins in their natural habitat as the sun sets over the Indian Ocean." },
                        new ItineraryDay { Day = 5, Title = "Departure", Description = "Enjoy a final breakfast with ocean views before your speedboat transfer back to Malé for your flight home." }
                    }
                },
                new HolidayPackages
                {
                    Id = 2,
                    Title = "Enchanting Week in Switzerland",
                    Location = "Switzerland",
                    DurationDays = 7,
                    Price = 120000,
                    ImageUrl = "https://images.pexels.com/photos/33848206/pexels-photo-33848206.jpeg",
                    Inclusions = new List<string> { "Return Flights", "3-Star Hotels", "Swiss Travel Pass", "Daily Breakfast" },
                    Itinerary = new List<ItineraryDay>
                    {
                        new ItineraryDay { Day = 1, Title = "Arrival in Zurich", Description = "Arrive in Zurich and check into your hotel. Spend the day exploring the charming old town and the beautiful Lake Zurich." },
                        new ItineraryDay { Day = 2, Title = "Journey to Lucerne", Description = "Take a scenic train to Lucerne. Visit the iconic Chapel Bridge, see the Lion Monument, and enjoy a boat trip on Lake Lucerne." },
                        new ItineraryDay { Day = 3, Title = "Top of Europe - Jungfrau", Description = "An unforgettable journey to Jungfraujoch, the highest railway station in Europe. Enjoy breathtaking views of the Aletsch Glacier." },
                        new ItineraryDay { Day = 4, Title = "Interlaken Adventure", Description = "Travel to Interlaken, the adventure capital. Choose an optional activity like paragliding or simply enjoy the stunning views of the twin lakes." },
                        new ItineraryDay { Day = 5, Title = "Visit Zermatt & Matterhorn", Description = "Take a train to the car-free village of Zermatt. Get a stunning view of the magnificent Matterhorn peak." },
                        new ItineraryDay { Day = 6, Title = "Explore Geneva", Description = "Travel to Geneva, a global city and diplomatic hub. Visit the Jet d'Eau, the Flower Clock, and the United Nations headquarters." },
                        new ItineraryDay { Day = 7, Title = "Departure", Description = "After breakfast, proceed to Geneva Airport for your flight back home, filled with incredible memories." }
                    }
                },
                new HolidayPackages 
                {
                    Id = 3,
                    Title = "Vibrant Exploration of Dubai",
                    Location = "Dubai, UAE",
                    DurationDays = 4,
                    Price = 45000,
                    ImageUrl = "https://images.pexels.com/photos/91628/pexels-photo-91628.jpeg",
                    Inclusions = new List<string> { "Flights", "4-Star Hotel", "Desert Safari with Dinner", "City Tour" },
                    Itinerary = new List<ItineraryDay>
                    {
                        new ItineraryDay { Day = 1, Title = "Arrival and Dhow Cruise", Description = "Arrive in Dubai and check in to your hotel. In the evening, enjoy a relaxing dinner on a traditional Dhow Cruise along the Dubai Creek." },
                        new ItineraryDay { Day = 2, Title = "City Tour & Burj Khalifa", Description = "Embark on a half-day city tour covering the Dubai Museum, Jumeirah Mosque, and Palm Jumeirah. End the day with a visit to the top of the Burj Khalifa." },
                        new ItineraryDay { Day = 3, Title = "Desert Safari Adventure", Description = "Experience the thrill of a desert safari in the afternoon. Enjoy dune bashing in a 4x4, camel rides, and a traditional BBQ dinner with entertainment." },
                        new ItineraryDay { Day = 4, Title = "Shopping and Departure", Description = "Spend the morning shopping at one of Dubai's famous malls. Later, transfer to Dubai International Airport for your departure." }
                    }
                }
            };
        }

        public IActionResult Details(int id)
        {
            var package = _packages.FirstOrDefault(p => p.Id == id);
            if (package == null)
            {
                return NotFound();
            }
            return View(package);
        }
    }
} 