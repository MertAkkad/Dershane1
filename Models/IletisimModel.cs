namespace Dershane.Models
{
    public class IletisimModel
    {
        public int Id { get; set; } 
        public required string Isim { get; set; }
        public required string Email { get; set; }
        public required string Mesaj { get; set; }
        public byte[]? Gorsel_Data { get; set; }
        
    }

}