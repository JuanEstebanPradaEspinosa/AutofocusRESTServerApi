namespace AF.Application.Models
{
    public class Tenant : User { // huurder
        public User? User { get; set; }
        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
