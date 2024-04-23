namespace AF.Application.Models
{
    public class Tenant : User { // huurder
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
