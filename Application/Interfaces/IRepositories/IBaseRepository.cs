using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IRepositories
{
    public interface IBaseRepository<T> where T : class
    {
        public IQueryable<T> GetAllAsync();
        public Task<T?> GetSingle(Expression<Func<T, bool>> expression);
        public Task AddAsync(T entity);
        public void UpdateAsync(T entity);
        public void RemoveAsync(T entity);
        public IQueryable<T> Find(Expression<Func<T, bool>> expression);
        public Task<bool> HasAnyAsync(Expression<Func<T, bool>> expression);
    }
}
