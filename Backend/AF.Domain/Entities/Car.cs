using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AF.Domain.Entities {
    public class Car {
        [Key]
        public int CarId { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public byte[]? CarPicture { get; set; }
        public List<byte[]>? CarPictures { get; set; }
    }
}
