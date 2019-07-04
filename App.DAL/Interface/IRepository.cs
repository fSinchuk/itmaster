using App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interface
{
    public interface IRepository<T> where T:Entity
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIDAsync(int Id);
        Task<List<T>> GetAsync(Expression<Func<T, bool>> predicate, 
                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, 
                            string includingProperties = "", 
                            int? skip = null, 
                            int? take = null);
        Task SaveAsync(T Item);
        Task SaveAllAsync(IEnumerable<T> Items);
        Task AddAllAsync(IEnumerable<T> Items);
        Task DeleteAsync(int PrimaryKey);




    }
}
