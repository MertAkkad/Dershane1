using Microsoft.AspNetCore.Mvc;
using Dershane.Models;
using Dershane.Data;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Dershane.Controllers
{
    public class SubelerController : Controller
    {
        private readonly ILogger<SubelerController> _logger;
        private readonly ApplicationDbContext _context;

        public SubelerController(ILogger<SubelerController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var subeler = _context.Subeler.ToList();
            return View(subeler);
        }
    }
}
