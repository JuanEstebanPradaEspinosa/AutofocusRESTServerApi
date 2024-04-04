using AF.BL.Interfaces;
using AF.DL.Data;
using AF.DL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AF.DL.Repositories
{
    public class CarRepository : IRepository<Car>
    {
        private readonly AutoFocusContext _dbContext;

        public CarRepository(AutoFocusContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Car> Create(Car entity)
        {
            _dbContext.Cars.Add(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int entityId)
        {
            var CarToDelete = await _dbContext.Cars.FindAsync(entityId);
            if (CarToDelete == null)
            {
                throw new KeyNotFoundException("Auto not found.");
            }

            _dbContext.Cars.Remove(CarToDelete);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Car> Get(int entityId)
        {
            var Car = await _dbContext.Cars.FindAsync(entityId);
            if (Car == null)
            {
                throw new KeyNotFoundException("Auto not found.");
            }
            return Car;
        }

        public async Task<IEnumerable<Car>> GetAll()
        {
            return await _dbContext.Cars.ToListAsync();
        }

        public async Task Update(Car entity)
        {
            _dbContext.Cars.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
