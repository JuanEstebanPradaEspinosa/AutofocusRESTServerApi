
using AF.Domain.Interfaces;
using AF.Infrastructure.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AF.Infrastructure.Repos 
{
    public class GenericRepository<T> : IRepository<T> where T : class {

        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        public async Task<List<T>> GetAllAsync() {

            try
            {
                return await _appDbContext.Set<T>().ToListAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public async Task<T> GetByIdAsync(int id) {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity) {

            try
            {
                await _appDbContext.Set<T>().AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
            }
            catch(Exception ex)
            {
                throw ex;
            }

        }

        public async Task UpdateAsync(T entity) {
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity) {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
