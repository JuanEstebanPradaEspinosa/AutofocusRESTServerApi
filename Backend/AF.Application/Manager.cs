
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
using AF.Domain.Pagination;
using System.Runtime.ConstrainedExecution;
using System.Reflection;
namespace AF.Application
{
    public class Manager
    {
        private readonly ICarRepository _carRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly IUserRepository _userRepository;
        private  IMapper _mapper;
        public Manager(ICarRepository carRepository, IBookingRepository bookingRepository,IUserRepository userRepository, IMapper mapper)
        {
            _carRepository = carRepository;
            _bookingRepository = bookingRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        //Hier zal je de mapper implementeren en gebruiken om de entities naar models en DTO's

        public async Task<PagedList<CarModel>> GetAllCarsAsync(QueryStringParameters carParameters)
        {
            try
            {
                PagedList<CarModel> Cars = new PagedList<CarModel>();
                var results = await _carRepository.GetAllAsync(carParameters);

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

        public async Task AddCarAsync(int lessorId, CarModel Car)
        {
            try
            {
                //find the user (Lessor) add the car and then Update
                await _carRepository.AddCarToLessorAsync(lessorId,_mapper.Map<Car>(Car));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateCarAsync(int carId, CarModel car)
        {
            try
            {
                var dbEntity = _mapper.Map<Car>(car);
                dbEntity.Id = carId;

                await _carRepository.UpdateAsync(dbEntity);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveCarAsync(int carId)
        {
            try
            {
                var dbEntity = await _carRepository.GetByIdAsync(carId);
                if (dbEntity != null)
                    await _carRepository.DeleteAsync(dbEntity);
                else
                    throw new ArgumentException("Car doesn't exist with this id to remove!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CarModel> GetCarByIdAsync(int carId)
        {
            try
            {
                var dbEntity = await _carRepository.GetByIdAsync(carId);
                return _mapper.Map<CarModel>(dbEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserModel> GetUserByIdAsync(int userId)
        {
            try
            {
                var dbEntity = await _userRepository.GetUserByIdAsync(userId);

                switch (dbEntity.GetType().Name.ToLower())
                {
                    case "tenant":
                        return _mapper.Map<TenantModel>(dbEntity);
                    case "lessor":
                        return _mapper.Map<LessorModel>(dbEntity);
                    default:
                        throw new ArgumentException("This type of user doesn't exist");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookingModel> GetBookingByIdAsync(int carId, int tenantId)
        {
            try
            {
                var dbEntity = await _bookingRepository.GetBookingByIdAsync(carId, tenantId);
                return _mapper.Map<BookingModel>(dbEntity);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task AddBookingAsync(BookingModel book)
        {
            try
            {
                //find the user (Lessor) add the car and then Update
                await _bookingRepository.AddAsync(_mapper.Map<Booking>(book));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateBookingAsync(int carId, int tenantId, BookingModel booking)
        {
            try
            {
                //haal de booking op
                var bookingDb = await _bookingRepository.GetBookingByIdAsync(carId, tenantId);
                //verander de booking
                bookingDb.CarId = booking.CarId;
                bookingDb.TenantId = booking.TenantId;
                bookingDb.StartDatum = booking.StartDatum;
                bookingDb.EindDatum = booking.EindDatum;
                //upsate de boooking
                await _bookingRepository.UpdateAsync(bookingDb);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveBookingAsync(int carId, int tenantId)
        {
            try
            {
                var dbEntity = await _bookingRepository.GetBookingByIdAsync(carId,tenantId);
                if (dbEntity != null)
                    await _bookingRepository.DeleteAsync(dbEntity);
                else
                    throw new ArgumentException("Car doesn't exist with this id to remove!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task RemoveUserAsync(int userId)
        {
            try
            {
                var dbEntity = await _userRepository.GetByIdAsync(userId);
                if (dbEntity != null)
                    await _userRepository.DeleteAsync(dbEntity);
                else
                    throw new ArgumentException("User doesn't exist with this id to remove!");

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
