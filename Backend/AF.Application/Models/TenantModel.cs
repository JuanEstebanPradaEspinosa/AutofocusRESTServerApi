using AF.Domain.Entities;

namespace AF.Application.Models
{
    public class TenantModel : UserModel 
    {
        public string? StudioName { get; set; }
        public List<BookingModel> Bookings { get; set; } = new List<BookingModel>();
    }
}
