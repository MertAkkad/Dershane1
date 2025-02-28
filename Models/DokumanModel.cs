namespace Dershane.Models
{
    public class DokumanModel
    {
        public int Id { get; set; }
        public required string Dokuman_Baslik { get; set; }
        public required string Dokuman_Icerik { get; set; }
        public byte[]? Gorsel_Data { get; set; }
    }
} 