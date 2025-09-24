using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Razorpay.Api;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelBookingSystem.Areas.Identity.Data;
using TravelBookingSystem.Data;
using TravelBookingSystem.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace TravelBookingSystem.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<TravelBookingSystemUser> _userManager;
        private readonly IConfiguration _configuration;

        public PaymentController(ApplicationDbContext context, UserManager<TravelBookingSystemUser> userManager, IConfiguration configuration)
        {
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        public IActionResult Index(int flightId)
        {
            return RedirectToAction("SelectSeat", new { flightId = flightId });
        }

        public async Task<IActionResult> SelectSeat(int flightId)
        {
            var flight = await _context.Flights
                .Include(f => f.Seats)
                .FirstOrDefaultAsync(f => f.Id == flightId);

            if (flight == null)
            {
                return NotFound();
            }

            if (!flight.Seats.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    string[] columns = { "A", "B", "C", "D", "E", "F" };
                    foreach (var col in columns)
                    {
                        _context.Seats.Add(new Seat { FlightId = flight.Id, SeatNumber = $"{i}{col}" });
                    }
                }
                await _context.SaveChangesAsync();
                flight = await _context.Flights.Include(f => f.Seats).FirstOrDefaultAsync(f => f.Id == flightId);
            }

            return View(flight);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(int flightId, string selectedSeat)
        {
            var flight = await _context.Flights.FindAsync(flightId);
            var currentUser = await _userManager.GetUserAsync(User);
            if (flight == null || currentUser == null)
            {
                return NotFound();
            }

            string keyId = _configuration["RazorpaySettings:KeyId"];
            string keySecret = _configuration["RazorpaySettings:KeySecret"];
            RazorpayClient client = new RazorpayClient(keyId, keySecret);

            var options = new Dictionary<string, object>
            {
                { "amount", flight.Price * 100 },
                { "currency", "INR" },
                { "receipt", $"receipt_{DateTime.Now.Ticks}" }
            };

            Order order = client.Order.Create(options);
            string orderId = order["id"].ToString();

            ViewBag.OrderId = orderId;
            ViewBag.KeyId = keyId;
            ViewBag.Amount = flight.Price * 100;
            ViewBag.Currency = "INR";
            ViewBag.Name = "VectorTravel Booking";
            ViewBag.Description = $"Flight from {flight.DepartureCity} to {flight.ArrivalCity}";
            ViewBag.FlightId = flightId;
            ViewBag.SelectedSeat = selectedSeat;
            ViewBag.CurrentUser = currentUser;

            return View("PaymentPage");
        }

        [HttpPost]
        public async Task<IActionResult> VerifyPayment(int flightId, string selectedSeat, string passengerName, string razorpay_payment_id, string razorpay_order_id, string razorpay_signature)
        {
            try
            {
                var flight = await _context.Flights.FindAsync(flightId);
                var currentUser = await _userManager.GetUserAsync(User);
                if (flight == null || currentUser == null)
                {
                    return StatusCode(500, new { status = "failure", message = "Flight or User not found." });
                }

                string keySecret = _configuration["RazorpaySettings:KeySecret"];
                bool isSignatureValid = VerifyRazorpaySignature(razorpay_order_id, razorpay_payment_id, razorpay_signature, keySecret);

                if (isSignatureValid == false)
                {
                    return StatusCode(500, new { status = "failure", message = "Invalid Payment Signature." });
                }

                var seat = await _context.Seats.FirstOrDefaultAsync(s => s.FlightId == flightId && s.SeatNumber == selectedSeat);
                if (seat != null && seat.IsAvailable)
                {
                    seat.IsAvailable = false;
                }
                else
                {
                    return StatusCode(500, new { status = "failure", message = "Selected seat is no longer available." });
                }

                var booking = new Booking
                {
                    FlightId = flight.Id,
                    UserId = currentUser.Id,
                    BookingDate = DateTime.Now,
                    Amount = flight.Price,
                    PaymentId = razorpay_payment_id,
                    SelectedSeat = selectedSeat,
                    PassengerName = passengerName // <-- THIS LINE IS NOW ADDED
                };

                _context.Bookings.Add(booking);
                await _context.SaveChangesAsync();

                return Ok(new { status = "success" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { status = "failure", message = ex.Message });
            }
        }

        private static bool VerifyRazorpaySignature(string orderId, string paymentId, string signature, string secret)
        {
            string text = orderId + "|" + paymentId;
            byte[] keyBytes = Encoding.UTF8.GetBytes(secret);
            byte[] textBytes = Encoding.UTF8.GetBytes(text);

            using (var hmacsha256 = new HMACSHA256(keyBytes))
            {
                byte[] hash = hmacsha256.ComputeHash(textBytes);
                string generatedSignature = BitConverter.ToString(hash).Replace("-", "").ToLower();
                return generatedSignature.Equals(signature);
            }
        }
    }
}