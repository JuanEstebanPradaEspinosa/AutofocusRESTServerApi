using System.ComponentModel.DataAnnotations;

namespace AF.Application.Models
{
    public class CarModel
    {
        public CarModel(string? model, string? brand, string? color, string? imageUrl, List<string>? imageUrls)
        {
            Model = model;
            Brand = brand;
            Color = color;
            ImageUrl = imageUrl;
            ImageUrls = imageUrls;
        }

        public CarModel(int id, string? model, string? brand, string? color, string? imageUrl, List<string>? imageUrls, List<BookingModel> bookings)
        {
            Id = id;
            Model = model;
            Brand = brand;
            Color = color;
            ImageUrl = imageUrl;
            ImageUrls = imageUrls;
            Bookings = bookings;
        }

        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public string? ImageUrl { get; set; }
        public List<string>? ImageUrls { get; set; }
        public List<BookingModel> Bookings { get; set; } = new List<BookingModel>();

    }
}
