namespace AF.Application.Models
{
    public class Lessor : User 
    {
        public Lessor(string? name, string? lastName, string? password, string? email, string? phoneNumber, byte[]? profilePicture, string? userType, string btwNr) : base(name, lastName, password, email, phoneNumber, profilePicture, userType)
        {
            BtwNr = btwNr;
        }

        public Lessor(int id, string? name, string? lastName, string? password, string? email, string? phoneNumber, byte[]? profilePicture, string? userType, string btwNr) : base(id, name, lastName, password, email, phoneNumber, profilePicture, userType)
        {
            BtwNr = btwNr;
        }

        public string? BtwNr { get; set; }

        public List<CarModel> Cars { get; set; } = new List<CarModel>();
    }
}
