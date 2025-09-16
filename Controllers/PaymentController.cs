using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TravelBookingSystem.Areas.Identity.Data;
using TravelBookingSystem.Data;
using TravelBookingSystem.Models;

namespace TravelBookingSystem.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<TravelBookingSystemUser> _userManager;

        public PaymentController(ApplicationDbContext context, UserManager<TravelBookingSystemUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /Payment?flightId=5
        public async Task<IActionResult> Index(int flightId)
        {
            var flight = await _context.Flights.FindAsync(flightId);
            if (flight == null)
            {
                return NotFound();
            }
            return View(flight);
        }

        // POST: /Payment/Process
        [HttpPost]
        public async Task<IActionResult> Process(int flightId)
        {
            var flight = await _context.Flights.FindAsync(flightId);
            var currentUser = await _userManager.GetUserAsync(User);

            if (flight == null || currentUser == null)
            {
                return NotFound();
            }

            var booking = new Booking
            {
                FlightId = flight.Id,
                UserId = currentUser.Id,
                BookingDate = DateTime.Now
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "Bookings");
        }
    }
} 