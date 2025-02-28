using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Dershane.Models;
using Dershane.Data;
using Microsoft.EntityFrameworkCore;

namespace Dershane.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context; 

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        // Anasayfa içeriğini veritabanından çek
        var announcements = _context.Duyurular.ToList();
        var banner = _context.Banner.OrderByDescending(b => b.Id).FirstOrDefault(); 
        var anasayfaContent = _context.Anasayfa_icerik.ToList(); 
        var news = _context.Haberler.OrderByDescending(h => h.Id).ToList(); 
        var kurumsalBilgiler = _context.KurumsalBilgiler.FirstOrDefault() ?? new KurumsalModel();
        var etkinlikler = _context.Etkinlikler.OrderByDescending(e => e.Etkinlik_Tarih).ToList();

        var viewModel = new HomeModel
        {
            Duyurular = announcements,
            Banner = banner,
            Anasayfa_icerik = anasayfaContent,
            Haberler = news,
            Etkinlikler = etkinlikler
        };

        ViewBag.KurumsalBilgiler = kurumsalBilgiler;
        return View(viewModel); // ViewModel'i view'e gönder
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    // Topbardan tiklanan sayfalara yönlendirme
    public IActionResult Iletisim()
    {
        return View("~/Views/Iletisim/iletisim.cshtml");
    }

    public IActionResult Egitim()
    {
        return View("~/Views/Egitim/Index.cshtml");
    }

    public IActionResult Dokuman()
    {
        return View("~/Views/Dokuman/dokuman.cshtml");
    }

    public IActionResult Subeler()
    {
        return View("~/Views/Subeler/subeler.cshtml");
    }
}
