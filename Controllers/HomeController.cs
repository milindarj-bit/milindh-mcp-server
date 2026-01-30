using Microsoft.AspNetCore.Mvc;
using myapp.Data;
using System.Linq;

namespace myapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var biryanis = _context.Biryanis.ToList();
            return View(biryanis);
        }
    }
}
