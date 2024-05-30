
namespace AF.Application.DTO_s.Output
{
    public class CarRESToutputDTO
    {
        public CarRESToutputDTO(int id, string? model, string? brand, string? color, string? imageUrl, List<string>? imageUrls, List<BookingRESTnormalDTO> bookings)
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
        public List<BookingRESTnormalDTO> Bookings { get; set; }

    }
}
