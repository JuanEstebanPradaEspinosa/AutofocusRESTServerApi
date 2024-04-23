
namespace AF.Domain.Entities
{
    public class Lessor : User
    {
        public User? User { get; set; }
        public string? BtwNr { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
