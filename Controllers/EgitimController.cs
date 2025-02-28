// Egitim Sayfası
using Microsoft.AspNetCore.Mvc;
using Dershane.Models;
using Dershane.Data;
using Microsoft.Extensions.Logging;

namespace Dershane.Controllers
{
    public class EgitimController : Controller
    {
        private readonly ILogger<EgitimController> _logger;
        private readonly ApplicationDbContext _context;

        public EgitimController(ILogger<EgitimController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var egitimler = _context.Egitimler.ToList();
            return View(egitimler);
        }
    }
}
