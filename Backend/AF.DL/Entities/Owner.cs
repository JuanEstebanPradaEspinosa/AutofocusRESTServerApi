namespace AF.DL.Entities
{
    public class Owner
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public List<Car> Cars { get; set; } = null; //may be empty!
    }
}