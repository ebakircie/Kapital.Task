using Kapital.Domain.Entities;
using Kapital.Domain.Entities.Base;
using Kapital.Domain.Repositories;
using Kapital.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kapital.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, IBase
    {
        private readonly KapitalContext _kapitalContext;
  
        public BaseRepository(KapitalContext kapitalContext)
        {
            _kapitalContext = kapitalContext;
        }
        public DbSet<T> Table => _kapitalContext.Set<T>();

        public async Task Create(T entity)
        {
            Table.Add(entity);
            await _kapitalContext.SaveChangesAsync();
        }
        public async Task Update(T entity)
        {
            _kapitalContext.Entry<T>(entity).State = EntityState.Modified;
            await _kapitalContext.SaveChangesAsync();
        }
        public void  Delete(T entity)
        {
            using var c =  _kapitalContext;
            c.Remove(entity);
            c.SaveChanges();
        }
 
        public IQueryable<T> GetAll()
        {
            var query = Table.AsQueryable();
            return query;
        }

        public async Task<TResult> GetFilteredFirstOrDefault<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> query = Table;
            if (where != null)
            {
                query = query.Where(where);
            }
                return  await query.Select(select).FirstOrDefaultAsync();
        }
        public async Task<List<TResult>> GetFilteredList<TResult>(Expression<Func<T, TResult>> select, Expression<Func<T, bool>> where = null)
        {
            IQueryable<T> query = Table;
            if (where!= null)
            {
                query = query.Where(where);
            }
            return await query.Select(select).ToListAsync();
        }

        
    }
    
}
