using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Adventure.Domain.Interface.Repository
{
    public interface IRepository<T> where T : class
    {
        void Add(T obj);
        void Update(T obj);
        Task<bool> AnyAsync(Expression<Func<T, bool>> exp);
        Task<List<T>> GetAllAsync();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> exp);
        Task SaveChangesAsync();
    }
}
