using App.DAL.Interface;
using App.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected DataBaseContext context;
        public Repository(DataBaseContext context)
        {
            this.context = context;
        }

        public virtual async Task AddAllAsync(IEnumerable<T> Items) => await context.AddAsync(Items);

        public virtual async Task DeleteAsync(int PrimaryKey)
        {
            context.Remove(await GetByIDAsync(PrimaryKey));
            await context.SaveChangesAsync();
        }

        public virtual async Task<List<T>> GetAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includingProperties = "", int? skip = null, int? take = null)
        {
            IQueryable<T> query = context.Set<T>().AsQueryable();

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            foreach (string item in includingProperties.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(item);
            }

            if (skip.HasValue)
            {
                query = query.Skip(skip.Value);
            }

            if (take.HasValue)
            {
                query = query.Take(take.Value);
            }

            return await query.ToListAsync();
        }
        public virtual async Task<List<T>> GetAllAsync() => await context.Set<T>().ToListAsync();
        public virtual async Task<T> GetByIDAsync(int Id) => await context.Set<T>().FindAsync(Id);

        public virtual async Task SaveAsync(T Item)
        {
            context.Update(Item);
             await context.SaveChangesAsync();
        }
        public virtual async Task SaveAllAsync(IEnumerable<T> Items)
        {
            context.UpdateRange(Items);
            await context.SaveChangesAsync();
        }
    }
}
