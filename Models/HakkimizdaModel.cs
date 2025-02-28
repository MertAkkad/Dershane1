namespace Dershane.Models
{
    public class Kadromuz
    {
        public int Id { get; set; } 
        public  string? Isim { get; set; }
        public  string? Alan { get; set; }
        public  string? Email { get; set; }
        public byte[]? Gorsel_Data { get; set; }
    }
    public class Hakkimizda_icerik
    {
        public int Id { get; set; }
        public string? Hakkimizda_Baslik { get; set; }
        public string? Hakkimizda_Icerik { get; set; }
        public byte[]? Gorsel_Data { get; set; }
    }
    public class Hakkimizda_Model
    {
        public List<Kadromuz>? Kadromuz { get; set; }
        public List<Hakkimizda_icerik>? Hakkimizda_icerik { get; set; }
    }
}