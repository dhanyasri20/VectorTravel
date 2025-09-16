using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TravelBookingSystem.Areas.Identity.Data;
using TravelBookingSystem.Data;
using TravelBookingSystem.Models;

namespace TravelBookingSystem.Controllers
{
    [Authorize] // This ensures only logged-in users can access this controller
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<TravelBookingSystemUser> _userManager;

        public BookingsController(ApplicationDbContext context, UserManager<TravelBookingSystemUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: /Bookings or /Bookings/Index
        public async Task<IActionResult> Index()
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge();
            }

            var userBookings = await _context.Bookings
                .Where(b => b.UserId == currentUser.Id)
                .Include(b => b.Flight) // Loads the flight details for each booking
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();

            return View(userBookings);
        }

        // POST: /Bookings/Cancel/5
        [HttpPost]
        public async Task<IActionResult> Cancel(int bookingId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var booking = await _context.Bookings.FindAsync(bookingId);

            // Security check: Make sure the booking exists and belongs to the current user
            if (booking != null && booking.UserId == currentUser.Id)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index"); // Redirect back to the bookings list
        }
    }
} 