namespace AF.Application.Models
{
    public class Lessor : User { // verhuurder

        public User? User { get; set; }
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
