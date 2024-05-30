namespace AF.Application.DTO_s.Input
{
    public class CarRESTinputDTO
    {
        public CarRESTinputDTO(string? model, string? brand, string? color, string? imageUrl, List<string>? imageUrls)
        {
            Model = model;
            Brand = brand;
            Color = color;
            ImageUrl = imageUrl;
            ImageUrls = imageUrls;
        }

        public int Id { get; set; }
        public string? Model { get; set; }
        public string? Brand { get; set; }
        public string? Color { get; set; }
        public string? ImageUrl { get; set; }
        public List<string>? ImageUrls { get; set; }
    }
}
