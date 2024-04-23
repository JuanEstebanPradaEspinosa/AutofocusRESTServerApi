using System.ComponentModel.DataAnnotations;

namespace AF.Application.Models
{
    public class CarModel
    {
        public CarModel(string? model, string? brand, string? color, byte[]? carPicture, List<byte[]>? carPictures)
        {
            Model = model;
            Brand = brand;
            Color = color;
            CarPicture = carPicture;
            CarPictures = carPictures;
        }

        public CarModel(int id, string? model, string? brand, string? color, byte[]? carPicture, List<byte[]>? carPictures)
        {
            Id = id;
            Model = model;
            Brand = brand;
            Color = color;
            CarPicture = carPicture;
            CarPictures = carPictures;
        }

        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public byte[]? CarPicture { get; set; }
        public List<byte[]>? CarPictures { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
