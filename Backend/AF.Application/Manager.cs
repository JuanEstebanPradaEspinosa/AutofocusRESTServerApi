
using AF.Application.Models;
using AF.Domain.Entities;
using AF.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AF.Application.Mapper;
namespace AF.Application
{
    public class Manager
    {
        private readonly ICarRepository _carRepository;
        private readonly IBookingRepository _bookingRepository;
        private  IMapper _mapper;
        public Manager(ICarRepository carRepository, IBookingRepository bookingRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        //Hier zal je de mapper implementeren en gebruiken om de entities naar models en DTO's

        public async Task<List<CarModel>> GetAllCarsAsync()
        {
            try
            {
                List<CarModel> Cars = new List<CarModel>();
                var results = await _carRepository.GetAllAsync();

                results.ForEach(car =>
                {
                    Cars.Add(_mapper.Map<CarModel>(car));
                });

                return Cars;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task AddCarAsync(CarModel Car)
        {
            try
            {
                await _carRepository.AddAsync(_mapper.Map<Car>(Car));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
