namespace AF.Application.DTO_s
{
    public class BookingRESTnormalDTO
    {
        public BookingRESTnormalDTO(int carId, int tenantId, DateTime startDatum, DateTime eindDatum)
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
