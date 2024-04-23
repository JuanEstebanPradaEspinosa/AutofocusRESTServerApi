using System.ComponentModel.DataAnnotations;

namespace AF.Application.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
