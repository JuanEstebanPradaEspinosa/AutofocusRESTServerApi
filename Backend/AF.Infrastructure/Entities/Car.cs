using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AF.Infrastructure.Entities
{
    public class Car
    {
        [Key]
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public byte[]? CarPicture { get; set; }
        public List<byte[]>? CarPictures { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
