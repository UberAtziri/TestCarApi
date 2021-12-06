using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestCar.Data.Models;

namespace TestCar.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        
        Task<T> Get(int id);
        
        Task<T> Update(T entity);
        
        Task<T> Delete(T entity);
        
        Task<List<T>> DeleteRange(List<T> entities);
        
        Task<T> Create(T entity);
        
        Task<List<T>> CreateRange(List<T> entities);
    }
}