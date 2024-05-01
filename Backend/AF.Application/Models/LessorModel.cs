namespace AF.Application.Models
{
    public class LessorModel : UserModel 
    {
        public string? BtwNr { get; set; }
        public List<CarModel> Cars { get; set; } = new List<CarModel>();
    }
}
