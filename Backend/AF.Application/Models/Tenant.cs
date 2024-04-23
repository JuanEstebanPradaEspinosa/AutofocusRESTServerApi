namespace AF.Application.Models
{
    public class Tenant : User 
    {
        public Tenant(string? name, string? lastName, string? password, string? email, string? phoneNumber, byte[]? profilePicture, string? userType) : base(name, lastName, password, email, phoneNumber, profilePicture, userType)
        {
        }

        public Tenant(int id, string? name, string? lastName, string? password, string? email, string? phoneNumber, byte[]? profilePicture, string? userType) : base(id, name, lastName, password, email, phoneNumber, profilePicture, userType)
        {
        }

        public string? StudioName { get; set; }

        public List<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
