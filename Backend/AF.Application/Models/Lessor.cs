namespace AF.Application.Models
{
    public class Lessor : User { // verhuurder
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
