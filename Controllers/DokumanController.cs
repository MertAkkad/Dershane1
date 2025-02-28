// Dokuman Sayfası
using Microsoft.AspNetCore.Mvc;
using Dershane.Models;
using Dershane.Data;
using Microsoft.Extensions.Logging;

namespace Dershane.Controllers
{
    public class DokumanController : Controller
    {
        private readonly ILogger<DokumanController> _logger;
        private readonly ApplicationDbContext _context;

        public DokumanController(ILogger<DokumanController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var dokumanlar = _context.Dokumanlar.ToList();
            return View(dokumanlar);
        }
    }
} 