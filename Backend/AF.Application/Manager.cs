
using AF.Domain.Entities;
using AF.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Application
{
    public class Manager
    {
        private readonly IRepository<Car> _carRepository;
        private readonly IRepository<Booking> _bookingRepository;

        public Manager(IRepository<Car> carRepository, IRepository<Booking> bookingRepository)
        {
            _carRepository = carRepository;
            _bookingRepository = bookingRepository;
        }
    }
}
