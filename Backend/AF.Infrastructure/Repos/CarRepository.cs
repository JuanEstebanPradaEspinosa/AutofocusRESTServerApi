using AF.Application.Contracts;
using AF.Domain.Entities;
using AF.Domain.Interfaces;
using AF.Domain.Pagination;
using AF.Infrastructure.Data;
using AF.Infrastructure.QueryParameters;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.Infrastructure.Repos
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly AppDbContext _appDbContext;
        private ISortHelper<Car> _sortHelper;
        public CarRepository(AppDbContext appDbContext, ISortHelper<Car> sortHelper) : base(appDbContext)
        {
            this._appDbContext = appDbContext;
            this._sortHelper = sortHelper;
        }

        public override async Task<PagedList<Car>> GetAllAsync(QueryStringParameters parameters)
        {
            try
            {
                CarParameters carParameters = (CarParameters) parameters;
                var results = FindAll();

               SearchByBrand(ref results, carParameters.Brand);

                var sortedCars = _sortHelper.ApplySort(ref results, carParameters.OrderBy);

                return PagedList<Car>.ToPagedList(sortedCars,
                    parameters.PageNumber,
                    parameters.PageSize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SearchByBrand(ref IQueryable<Car> cars, string brand)
        {
            if (!cars.Any() || string.IsNullOrWhiteSpace(brand))
                return;
            
            cars = cars.Where(o => o.Brand.ToLower().Contains(brand.Trim().ToLower()));
        }

        public async Task AddCarToLessorAsync(int lessorId, Car entity)
        {

            try
            {
                //haal de lessor op!
                Lessor lessor = await _appDbContext.Lessors.FindAsync(lessorId);
                if (lessor == null)
                    throw new ArgumentException($"The user with id: {lessorId} doesn't exist");
                //Voeg auto + save
                lessor.Cars.Add(entity);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public override async Task<Car> GetByIdAsync(int id)
        {
            return await _appDbContext.Set<Car>().Include(b => b.Bookings).FirstOrDefaultAsync(c => c.Id == id);
        }
    }
}
