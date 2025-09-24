using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Security.Claims; // <-- ADDED THIS LINE
using System.Threading.Tasks;
using TravelBookingSystem.Areas.Identity.Data;
using TravelBookingSystem.Data;

namespace TravelBookingSystem.Controllers
{
    [Authorize]
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

        // --- NEW METHOD ADDED ---
        // This action shows the confirmation page after a successful payment
        public async Task<IActionResult> Confirmation()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // Find the most recent booking for the current user
            var latestBooking = await _context.Bookings
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.BookingDate)
                .Include(b => b.Flight) // Include flight details
                .FirstOrDefaultAsync();

            if (latestBooking == null)
            {
                // If no booking is found, redirect to the main bookings page
                return RedirectToAction("Index");
            }

            return View(latestBooking);
        }
        // --- END OF NEW METHOD ---


        public async Task<IActionResult> Ticket(int bookingId)
        {
            var booking = await _context.Bookings
                .Include(b => b.Flight) // Load related flight data
                .Include(b => b.User)   // Load related user data
                .FirstOrDefaultAsync(b => b.Id == bookingId);

            if (booking == null)
            {
                return NotFound();
            }

            var currentUserId = _userManager.GetUserId(User);
            if (booking.UserId != currentUserId)
            {
                return Forbid();
            }

            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> Cancel(int bookingId)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var booking = await _context.Bookings.FindAsync(bookingId);

            if (booking != null && booking.UserId == currentUser.Id)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }
    }
} 