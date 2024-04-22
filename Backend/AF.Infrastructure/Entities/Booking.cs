using AF.Application.Models;
using System.ComponentModel.DataAnnotations;

namespace AF.Infrastructure.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
