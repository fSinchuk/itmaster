using App.DAL.Interface;
using App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace App.DAL.Repository
{
    public class ProductsRepository : Repository<Products>, IProductsRepository
    {
        public ProductsRepository(DataBaseContext context) : base(context) { }

        public async Task<List<Products>> GetAllWithCategories()
        {
            return await context.Products.Include("ProductCateogry").ToListAsync();
        }
        public  async Task UpdateAsync(Products item) => await base.SaveAsync(item);
        
    }
}
