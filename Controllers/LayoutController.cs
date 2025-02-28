using Dershane.Models;
using Microsoft.AspNetCore.Mvc;
using Dershane.Data;
namespace Dershane.Controllers
{
    public class LayoutController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LayoutController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var model = new KurumsalModel   
            {
                Logo_Data = _context.KurumsalBilgiler.FirstOrDefault()?.Logo_Data,
                Logo_Url = _context.KurumsalBilgiler.FirstOrDefault()?.Logo_Url
            };
            return View(model);
        }
    }
}
