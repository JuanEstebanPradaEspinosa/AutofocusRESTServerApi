using System.ComponentModel.DataAnnotations;

namespace AF.Application.Models
{
    public class Car
    {
        [Key]
        public int CarId { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public byte[]? CarPicture { get; set; }
        public List<byte[]>? CarPictures { get; set; }
    }
}
