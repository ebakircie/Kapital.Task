using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        DbSet<T> Table { get; }

        Task Create(T entity);
        Task Update(T entity);
        void Delete(T entity);
        
        IQueryable<T> GetAll();
        
        Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> select,
                                                         Expression<Func<T, bool>> where= null);
        Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select,
                                                         Expression<Func<T, bool>> where = null);


    }
}
