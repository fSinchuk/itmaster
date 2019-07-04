using App.DAL.Interface;
using App.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.DAL.Repository
{
    public class ProductCategoriesRepository : Repository<ProductCategories>, IProductCategoriesRepository
    {
        public ProductCategoriesRepository(DataBaseContext context) : base(context)
        {
        }

        public override async Task<List<ProductCategories>> GetAllAsync()
        {
            return await context.ProductCategories.ToListAsync();
        }

    }
}
