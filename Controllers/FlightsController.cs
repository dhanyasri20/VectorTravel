using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelBookingSystem.Data;
using System.Threading.Tasks;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using TravelBookingSystem.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;

namespace TravelBookingSystem.Controllers
{
    public class FlightsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<TravelBookingSystemUser> _userManager;

        public FlightsController(ApplicationDbContext context, UserManager<TravelBookingSystemUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // POST: Flights/Search (No changes here)
        [HttpPost]
        public async Task<IActionResult> Search(string departureCity, string arrivalCity, DateTime departureDate)
        {
            var flights = await _context.Flights
                                        .Where(f => f.DepartureCity == departureCity
                                               && f.ArrivalCity == arrivalCity
                                               && f.DepartureTime.Date == departureDate.Date)
                                        .ToListAsync();

            ViewData["SearchTitle"] = $"Flights from {departureCity} to {arrivalCity} on {departureDate.ToShortDateString()}";
            return View("SearchResults", flights);
        }

        // GET: Flights/Details/5 (No changes here)
        public async Task<IActionResult> Details(int id)
        {
            var flight = await _context.Flights.FirstOrDefaultAsync(f => f.Id == id);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: Flights/Book/5 (This is the updated version)
        [HttpPost]
        [Authorize]
        public IActionResult Book(int flightId)
        {
            // This method no longer creates a booking.
            // It now redirects the user to the payment page.
            return RedirectToAction("Index", "Payment", new { flightId = flightId });
        }
    }
} 