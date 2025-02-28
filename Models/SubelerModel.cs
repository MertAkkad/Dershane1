namespace Dershane.Models
{
    public class SubelerModel
    {
        public int Id { get; set; }
        public required string SubeAdi { get; set; }
        public required string SubeKonum { get; set; }
        public byte[]? Gorsel_Data { get; set; }

    }
} 