using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestCar.Data.Models;
using TestCar.Data.Repositories.Interfaces;

namespace TestCar.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly DbSet<T> dbSet;
        private readonly CarContext carContext;

        public Repository(CarContext carContext)
        {
            this.carContext = carContext;
            this.dbSet = carContext.Set<T>();
        }

        public IQueryable<T> GetAll()
        {
            return this.dbSet.AsQueryable();
        }

        public async Task<T> Get(int id)
        {
            return await this.dbSet.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<T> Update(T entity)
        {
            this.dbSet.Update(entity);
            await this.carContext.SaveChangesAsync();

            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            this.dbSet.Remove(entity);
            await this.carContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> DeleteRange(List<T> entities)
        {
            this.dbSet.RemoveRange(entities);
            await this.carContext.SaveChangesAsync();

            return entities;
        }

        public async Task<T> Create(T entity)
        {
            this.dbSet.Add(entity);
            await this.carContext.SaveChangesAsync();

            return entity;
        }

        public async Task<List<T>> CreateRange(List<T> entities)
        {
            this.dbSet.AddRange(entities);
            await this.carContext.SaveChangesAsync();

            return entities;
        }
    }
}