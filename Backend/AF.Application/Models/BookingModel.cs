using System.ComponentModel.DataAnnotations;

namespace AF.Application.Models
{
    public class BookingModel
    {
        public BookingModel(int carId, int tenantId, DateTime startDatum, DateTime eindDatum)
        {
            CarId = carId;
            TenantId = tenantId;
            StartDatum = startDatum;
            EindDatum = eindDatum;
        }

        public int CarId { get; set; }
        public int TenantId { get; set; }
        public DateTime StartDatum { get; set; }
        public DateTime EindDatum { get; set; }
    }
}
