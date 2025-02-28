using Microsoft.EntityFrameworkCore;
using Dershane.Models;
namespace Dershane.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

   


        public DbSet<Banner> Banner { get; set; }
        public DbSet<Duyurular> Duyurular { get; set; }
        public DbSet<Haberler> Haberler { get; set; }
        public DbSet<Anasayfa_icerik> Anasayfa_icerik { get; set; }
        public DbSet<EgitimModel> Egitimler { get; set; }
        public DbSet<DokumanModel> Dokumanlar { get; set; }
        public DbSet<Kadromuz> Kadromuz { get; set; }
        public DbSet<Hakkimizda_icerik> Hakkimizda_icerik { get; set; }
        public DbSet<SubelerModel> Subeler { get; set; }
        public DbSet<IletisimModel> Iletisim { get; set; }
        public DbSet<KurumsalModel> KurumsalBilgiler { get; set; }
        public DbSet<Etkinlikler> Etkinlikler { get; set; }

}
