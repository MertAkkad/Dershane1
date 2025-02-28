namespace Dershane.Models
{
    public class EgitimModel
    {
        public int Id { get; set; }
        public required string EgitimAdi { get; set; }
        public required string EgitimAciklama { get; set; }
        public byte[]? Gorsel_Data { get; set; }
    }

} 