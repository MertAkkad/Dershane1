// Hakkimizda Sayfası
using Dershane.Models;
using Microsoft.AspNetCore.Mvc;
using Dershane.Data;
namespace Dershane.Controllers
{
    public class HakkimizdaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HakkimizdaController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new Hakkimizda_Model
            {
                Kadromuz = _context.Kadromuz.ToList(),
                Hakkimizda_icerik = _context.Hakkimizda_icerik.ToList() // veritabanından kadromuz ve hakkimizda_icerik verilerini al
            };
            return View(model);
        }
    }
}
