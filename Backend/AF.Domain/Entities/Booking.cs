using System.ComponentModel.DataAnnotations;

namespace AF.Domain.Entities
{
    public class Booking
    {
        public int CarId { get; set; }
        public int TenantId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
        //public bool Confirmed { get; set; } = false;

    }
}
