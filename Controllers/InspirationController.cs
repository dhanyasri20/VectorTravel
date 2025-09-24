using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TravelBookingSystem.Data;

namespace TravelBookingSystem.Controllers
{
    public class InspirationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InspirationController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var inspirations = await _context.Inspirations.ToListAsync();
            return View(inspirations);
        }
    }
} 