using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using TravelBookingSystem.Areas.Identity.Data;
using TravelBookingSystem.Data;
using TravelBookingSystem.Models;

namespace TravelBookingSystem.Controllers
{
    public class HolidayPackagesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<TravelBookingSystemUser> _userManager;

        public HolidayPackagesController(ApplicationDbContext context, UserManager<TravelBookingSystemUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string category)
        {
            // This method remains the same
            var packagesQuery = _context.Packages.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                packagesQuery = packagesQuery.Where(p => p.Category == category);
            }
            var packages = await packagesQuery.ToListAsync();
            ViewBag.Categories = await _context.Packages.Select(p => p.Category).Distinct().ToListAsync();
            ViewBag.SelectedCategory = category;
            return View(packages);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) { return NotFound(); }

            // UPDATED: Now includes Reviews
            var package = await _context.Packages
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (package == null) { return NotFound(); }
            return View(package);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SubmitEnquiry(string packageName, string fullName, string email, string phoneNumber)
        {
            // This method remains the same
            if (ModelState.IsValid)
            {
                var enquiry = new Enquiry { PackageName = packageName, FullName = fullName, Email = email, PhoneNumber = phoneNumber, EnquiryDate = DateTime.Now };
                _context.Enquiries.Add(enquiry);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thank you for your enquiry! We will get back to you shortly.";
                var package = await _context.Packages.FirstOrDefaultAsync(p => p.Title == packageName);
                return RedirectToAction("Details", new { id = package?.Id });
            }
            TempData["ErrorMessage"] = "There was an error submitting your enquiry. Please try again.";
            return RedirectToAction("Index");
        }

        // ADDED: New method to handle review submissions
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddReview(int packageId, int rating, string comment)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge(); // Should not happen if [Authorize] is working
            }

            var review = new Review
            {
                PackageId = packageId,
                Rating = rating,
                Comment = comment,
                UserName = $"{user.FirstName} {user.LastName}",
                ReviewDate = DateTime.Now
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = packageId });
        }
    }
} 
