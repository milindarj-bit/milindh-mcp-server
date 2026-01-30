using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using myapp.Data;
using myapp.Models;
using System.Linq;

namespace myapp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var biryanis = _context.Biryanis.ToList();
            return View(biryanis);
        }

        [HttpPost]
        public IActionResult Create(Biryani biryani)
        {
            if (ModelState.IsValid)
            {
                _context.Biryanis.Add(biryani);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(biryani);
        }
    }
}
