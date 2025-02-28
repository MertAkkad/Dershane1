using Microsoft.AspNetCore.Mvc;
using Dershane.Models;
using Dershane.Data;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace Dershane.Controllers
{
    public class IletisimController : Controller
    {
        private readonly ILogger<IletisimController> _logger;
        private readonly ApplicationDbContext _context;

        public IletisimController(ILogger<IletisimController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var iletisimModel = new IletisimModel
            {
                Isim = string.Empty,
                Email = string.Empty,
                Mesaj = string.Empty
            };

            ViewBag.KurumsalBilgiler = _context.KurumsalBilgiler.FirstOrDefault() ?? new KurumsalModel();
            return View(iletisimModel);
        }

        [HttpPost]
        public IActionResult Submit(IletisimModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Iletisim.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            
           
            return View("Index", model);
        }
    }
}
