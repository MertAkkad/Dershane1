// Admin Sayfası
using Microsoft.AspNetCore.Mvc;
using Dershane.Data;
using Dershane.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.Extensions.Logging;

namespace Dershane.Controllers
{
    [Authorize] //Admin sayfasina giris icin yetki kontrolu
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private const string AdminUsername = "admin"; //Admin kullanıcı adı
        private const string AdminPassword = "123456"; //Admin şifresi
        private readonly ILogger<AdminController> _logger;

        public AdminController(ApplicationDbContext context, ILogger<AdminController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (model.Username == AdminUsername && model.Password == AdminPassword)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, model.Username),
                    new Claim(ClaimTypes.Role, "Admin")
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);

                return RedirectToAction("Index");
            }

            ViewBag.Error = "Geçersiz kullanıcı adı veya şifre";
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        // (Admin Sayfası)
        public IActionResult Index()
        {
        var model = new AdminModel();

        // Admin sayfasinda tablo listesi
        var dbSets = _context.GetType().GetProperties()
            .Where(p => p.PropertyType.IsGenericType &&
                        p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

        foreach (var dbSet in dbSets)
        {
            var entityType = dbSet.PropertyType.GetGenericArguments()[0];
            var tableName = dbSet.Name; // yazdirilacak tablo adi
            
            
            var dbSetValue = dbSet.GetValue(_context);
            var data = dbSetValue != null ? ((IQueryable<object>)dbSetValue).ToList() : new List<object>();
            model.Tables.Add(tableName, data);
        }

        return View(model);
        }

        //  Edit formu
        public IActionResult Edit(int id, string tableName)
        {
            var entity = GetEntityByName(tableName, id);
            if (entity == null) return NotFound();

            return PartialView($"_{tableName}", entity);
        }

        //  Ekleme formu
public IActionResult Create(string tableName)
{
    switch (tableName)
    {
        case "Kadromuz":
            return PartialView("_Kadromuz", new Kadromuz());

        case "Egitimler":
            return PartialView("_Egitimler", new EgitimModel { EgitimAdi = "", EgitimAciklama = "" });

        case "Hakkimizda_icerik":
            return PartialView("_Hakkimizda_icerik", new Hakkimizda_icerik());

        case "Banner":
            return PartialView("_Banner", new Banner());

        case "Duyurular":
            return PartialView("_Duyurular", new Duyurular { Duyuru_Tarih = DateTime.Now });

        case "Haberler":
            return PartialView("_Haberler", new Haberler { Haber_Tarih = DateTime.Now });

        case "Etkinlikler":
            return PartialView("_Etkinlikler", new Etkinlikler { Etkinlik_Tarih = DateTime.Now });

        case "Anasayfa_icerik":
            return PartialView("_Anasayfa_icerik", new Anasayfa_icerik());

        case "Subeler":
            return PartialView("_Subeler", new SubelerModel(){SubeAdi = "", SubeKonum = ""});

        case "Iletisim":
            return PartialView("_Iletisim", new IletisimModel(){Isim = "", Email = "", Mesaj = ""});
        case "Dokumanlar":
            return PartialView("_Dokuman", new DokumanModel(){Dokuman_Baslik = "", Dokuman_Icerik = ""});

        case "KurumsalBilgiler":
            var kurumsal = _context.KurumsalBilgiler.FirstOrDefault() ?? new KurumsalModel();
            return PartialView("_KurumsalBilgiler", kurumsal);

        default:
            return BadRequest("Invalid table name.");
    }
}

        // Silme butonu tiklaninca
        [HttpPost]
        public IActionResult Delete(int id, string tableName)
        {
            var entity = GetEntityByName(tableName, id);
            if (entity != null)
            {
                _context.Remove(entity);
                _context.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // Tablo adina gore entity bulma
        private object? GetEntityByName(string tableName, int id)
        {
            return tableName switch
            {
                "Kadromuz" => _context.Kadromuz.Find(id),
                "Hakkimizda_icerik" => _context.Hakkimizda_icerik.Find(id),
                "Egitimler" => _context.Egitimler.Find(id),
                "Duyurular" => _context.Duyurular.Find(id),
                "Haberler" => _context.Haberler.Find(id),
                "Anasayfa_icerik" => _context.Anasayfa_icerik.Find(id),
                "Subeler" => _context.Subeler.Find(id),
                "Iletisim" => _context.Iletisim.Find(id),
                "Dokumanlar" => _context.Dokumanlar.Find(id),
                "KurumsalBilgiler" => _context.KurumsalBilgiler.Find(id),
                "Banner" => _context.Banner.Find(id),
                "Etkinlikler" => _context.Etkinlikler.Find(id),
                _ => null
            };
        }

[HttpPost]
public async Task<IActionResult> Save(string tableName, IFormCollection formData)
{
    if (ModelState.IsValid)
    {
        switch (tableName)
        {
            case "Banner":
                var banner = new Banner
                {
                    Id = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.Parse(formData["Id"]),
                    Banner_Baslik = formData["Banner_Baslik"],
                    Banner_Icerik = formData["Banner_Icerik"],
                    Banner_Gorsel_Tipi = formData["Banner_Gorsel_Tipi"],
                    Gorsel_Url = formData["Gorsel_Url"]
                };

                // Debug logging
                _logger.LogInformation($"Files count: {formData.Files.Count}");
                foreach (var file in formData.Files)
                {
                    _logger.LogInformation($"File name: {file.Name}, Length: {file.Length}");
                }

                if (formData.Files.Count > 0)
                {
                    using var memoryStream = new MemoryStream();
                    await formData.Files[0].CopyToAsync(memoryStream);
                    banner.Gorsel_Data = memoryStream.ToArray();
                    banner.Banner_Gorsel_Tipi = formData.Files[0].ContentType;
                    
                    // Debug logging
                    _logger.LogInformation($"Image byte length: {banner.Gorsel_Data?.Length ?? 0}");
                }

                if (banner.Id == 0)
                    _context.Banner.Add(banner);
                else
                    _context.Banner.Update(banner);

                await _context.SaveChangesAsync(); // Change to async version
                break;

            case "Duyurular":
                var duyuru = new Duyurular
                {
                    Id = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.TryParse(formData["Id"], out var duyuru_id) ? duyuru_id : 0,
                    Duyuru_Baslik = formData["Duyuru_Baslik"],
                    Duyuru_Icerik = formData["Duyuru_Icerik"],
                    Duyuru_Tarih = DateTime.TryParse(formData["Duyuru_Tarih"], out var duyuru_tarih) ? duyuru_tarih : DateTime.MinValue
                };

                if (formData.Files.Count > 0)
                {
                    using var memoryStream = new MemoryStream();
                    await formData.Files[0].CopyToAsync(memoryStream);
                    duyuru.Gorsel_Data = memoryStream.ToArray();
                }

                if (duyuru.Id == 0)
                    _context.Duyurular.Add(duyuru);
                else
                    _context.Duyurular.Update(duyuru);
                break;
            case "Etkinlikler":
                var etkinlik = new Etkinlikler
                {
                    Id = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.TryParse(formData["Id"], out var etkinlik_id) ? etkinlik_id : 0,
                    Etkinlik_Baslik = formData["Etkinlik_Baslik"],
                    Etkinlik_Icerik = formData["Etkinlik_Icerik"],
                    Etkinlik_Tarih = DateTime.TryParse(formData["Etkinlik_Tarih"], out var etkinlik_tarih) ? etkinlik_tarih : DateTime.MinValue
                };

                if (formData.Files.Count > 0)
                {
                    using var memoryStream = new MemoryStream();
                    await formData.Files[0].CopyToAsync(memoryStream);
                    etkinlik.Gorsel_Data = memoryStream.ToArray();
                }

                if (etkinlik.Id == 0)
                    _context.Etkinlikler.Add(etkinlik);
                else
                    _context.Etkinlikler.Update(etkinlik);
                break;

            case "Subeler":
                var sube = new SubelerModel
                {
                    Id = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.TryParse(formData["Id"], out var sube_id) ? sube_id : 0,
                    SubeAdi = formData["SubeAdi"],
                    SubeKonum = formData["SubeKonum"]
                };

                if (sube.Id == 0)
                    _context.Subeler.Add(sube);
                else
                    _context.Subeler.Update(sube);
                break;

            case "Iletisim":
                var iletisim = new IletisimModel
                {
                    Id = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.TryParse(formData["Id"], out var iletisim_id) ? iletisim_id : 0,
                    Isim = formData["Isim"],
                    Email = formData["Email"],
                    Mesaj = formData["Mesaj"]
                };

                if (iletisim.Id == 0)
                    _context.Iletisim.Add(iletisim);
                else
                    _context.Iletisim.Update(iletisim);
                break;

            case "Anasayfa_icerik":
                var anasayfaIcerik = new Anasayfa_icerik
                {
                    Id = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.TryParse(formData["Id"], out var anasayfa_id) ? anasayfa_id : 0,
                    Anasayfa_Baslik = formData["Anasayfa_Baslik"],
                    Anasayfa_Icerik = formData["Anasayfa_Icerik"]
                };

                if (anasayfaIcerik.Id == 0)
                    _context.Anasayfa_icerik.Add(anasayfaIcerik);
                else
                    _context.Anasayfa_icerik.Update(anasayfaIcerik);
                break;

            case "Dokumanlar":
                var dokumanId = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.Parse(formData["Id"]);
                var dokuman = new DokumanModel
                {
                    Id = dokumanId,
                    Dokuman_Baslik = formData["Dokuman_Baslik"],
                    Dokuman_Icerik = formData["Dokuman_Icerik"]
                };

                if (formData.Files.Count > 0)
                {
                    using var memoryStream = new MemoryStream();
                    await formData.Files[0].CopyToAsync(memoryStream);
                    dokuman.Gorsel_Data = memoryStream.ToArray();
                }

                if (dokuman.Id == 0)
                    _context.Dokumanlar.Add(dokuman);
                else
                    _context.Dokumanlar.Update(dokuman);

                await _context.SaveChangesAsync();
                break;

            case "Egitimler":
                var egitim = new EgitimModel
                {
                    Id = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.TryParse(formData["Id"], out var egitim_id) ? egitim_id : 0,
                    EgitimAdi = formData["EgitimAdi"],
                    EgitimAciklama = formData["EgitimAciklama"],
         
                };

                if (formData.Files.Count > 0)
                {
                    using var memoryStream = new MemoryStream();
                    await formData.Files[0].CopyToAsync(memoryStream);
                    egitim.Gorsel_Data = memoryStream.ToArray();
                }

                if (egitim.Id == 0)
                    _context.Egitimler.Add(egitim);
                else
                    _context.Egitimler.Update(egitim);
                break;

            case "Hakkimizda_icerik":
                var hakkimizdaIcerik = new Hakkimizda_icerik
                {
                    Id = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.TryParse(formData["Id"], out var hakkimizda_id) ? hakkimizda_id : 0,
                    Hakkimizda_Baslik = formData["Hakkimizda_Baslik"],
                    Hakkimizda_Icerik = formData["Hakkimizda_Icerik"]
                };

                if (hakkimizdaIcerik.Id == 0)
                    _context.Hakkimizda_icerik.Add(hakkimizdaIcerik);
                else
                    _context.Hakkimizda_icerik.Update(hakkimizdaIcerik);
                break;

            case "Haberler":
                var haber = new Haberler
                {
                    Id = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.TryParse(formData["Id"], out var haber_id) ? haber_id : 0,
                    Haber_Baslik = formData["Haber_Baslik"],
                    Haber_Icerik = formData["Haber_Icerik"],
                    Haber_Tarih = DateTime.TryParse(formData["Haber_Tarih"], out var haber_tarih) ? haber_tarih : DateTime.Now
                };

                if (formData.Files.Count > 0)
                {
                    using var memoryStream = new MemoryStream();
                    await formData.Files[0].CopyToAsync(memoryStream);
                    haber.Gorsel_Data = memoryStream.ToArray();
                }

                if (haber.Id == 0)
                    _context.Haberler.Add(haber);
                else
                    _context.Haberler.Update(haber);
                break;

            case "Kadromuz":
                var kadro = new Kadromuz
                {
                    Id = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.TryParse(formData["Id"], out var kadro_id) ? kadro_id : 0,
                    Isim = formData["Isim"],
                    Alan = formData["Alan"],
                    Email = formData["Email"]
                };

                if (kadro.Id == 0)
                        _context.Kadromuz.Add(kadro);
                else
                    _context.Kadromuz.Update(kadro);
                break;

            case "KurumsalBilgiler":
                var kurumsalBilgiler = new KurumsalModel
                {
                    Id = string.IsNullOrEmpty(formData["Id"]) ? 0 : int.TryParse(formData["Id"], out var kurumsal_id) ? kurumsal_id : 0,
                    Tel_No = formData["Tel_No"],
                    Kurumsal_Email = formData["Kurumsal_Email"],
                    Adres = formData["Adres"],
                    Logo_Data = formData.Files.FirstOrDefault()?.OpenReadStream() != null ? 
                        StreamToByteArray(formData.Files.FirstOrDefault().OpenReadStream()) : null,
                    Logo_Url = formData.Files.FirstOrDefault()?.FileName
                };

                if (kurumsalBilgiler.Id == 0)
                    _context.KurumsalBilgiler.Add(kurumsalBilgiler);
                else
                    _context.KurumsalBilgiler.Update(kurumsalBilgiler);
                break;

            default:
                return Json(new { success = false, message = "Geçersiz tablo adı." });
        }

        _context.SaveChanges();
        return Json(new { success = true, message = "Kayıt başarıyla kaydedildi." });
    }

    return Json(new { success = false, message = "Model durumu geçersiz." });
}

    private byte[] StreamToByteArray(Stream stream)
{
    using (var memoryStream = new MemoryStream())
    {
        stream.CopyTo(memoryStream);
        return memoryStream.ToArray();
    }
}





    }
}
    


