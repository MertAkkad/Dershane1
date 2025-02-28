namespace Dershane.Models
{
    public class Banner
    {
        public int Id { get; set; }
        public string? Gorsel_Url { get; set; }
        public byte[]? Gorsel_Data { get; set; } 
        public string? Banner_Baslik { get; set; } 
        public string? Banner_Icerik { get; set; } 
        public string? Banner_Gorsel_Tipi { get; set; } 
    }
    public class Duyurular
    {
        public int Id { get; set; }
        public string? Duyuru_Baslik { get; set; }
        public string? Duyuru_Icerik { get; set; }
        public DateTime Duyuru_Tarih { get; set; }
        public byte[]? Gorsel_Data { get; set; }

    }
    public class Haberler
    {
        public int Id { get; set; }
        public string? Haber_Baslik { get; set; }
        public string? Haber_Icerik { get; set; }
        public DateTime? Haber_Tarih { get; set; }
        public byte[]? Gorsel_Data { get; set; }

    }
        public class Etkinlikler
    {
        public int Id { get; set; }
        public string? Etkinlik_Baslik { get; set; }
        public string? Etkinlik_Icerik { get; set; }
        public DateTime Etkinlik_Tarih { get; set; }
        public byte[]? Gorsel_Data { get; set; }
    }
    public class Anasayfa_icerik
    {
        public int Id { get; set; }
        public string? Anasayfa_Baslik { get; set; }
        public string? Anasayfa_Icerik { get; set; }
        public byte[]? Gorsel_Data { get; set; }
    }

    public class HomeModel
    {
        public List<Duyurular>? Duyurular { get; set; } 
        public Banner? Banner { get; set; } 
        public List<Haberler>? Haberler { get; set; } 
        public List<Anasayfa_icerik>? Anasayfa_icerik { get; set; } 
        public List<Etkinlikler>? Etkinlikler { get; set; }
        public byte[]? Gorsel_Data { get; set; }
    }
}