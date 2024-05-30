
using AF.Domain.Entities;
using AF.Domain.Interfaces;
using AF.Domain.Pagination;
using AF.Infrastructure.Data;
using AF.Infrastructure.QueryParameters;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;

namespace AF.Infrastructure.Repos 
{
    public class GenericRepository<T> : IRepository<T> where T : class {

        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext) {
            this._appDbContext = appDbContext;
        }

        public IQueryable<T> FindAll()
        {
            return _appDbContext.Set<T>();
        }

        public virtual async Task<PagedList<T>> GetAllAsync(QueryStringParameters parameters) {

            try
            {
                var results = FindAll();
                return PagedList<T>.ToPagedList(results,
                    parameters.PageNumber,
                    parameters.PageSize);
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        public virtual async Task<T> GetByIdAsync(int id) {
            return await _appDbContext.Set<T>().FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {

            try
            {
                await _appDbContext.Set<T>().AddAsync(entity);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task UpdateAsync(T entity) {
            try
            {
                _appDbContext.Entry(entity).State = EntityState.Modified;
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public async Task DeleteAsync(T entity) {
            try
            {
                _appDbContext.Set<T>().Remove(entity);
                await _appDbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
