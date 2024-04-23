using AF.Domain.Entities;
using AF.Domain.Interfaces;
using AF.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Infrastructure.Repos
{
    public class BookingRepository : GenericRepository<Booking>, IBookingRepository
    {
        public BookingRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
