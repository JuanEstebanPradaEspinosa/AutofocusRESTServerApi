
namespace AF.Domain.Entities
{
    public class Car
    {
        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public string? ImageUrl { get; set; }
        public List<string>? ImageUrls { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();

    }
}
