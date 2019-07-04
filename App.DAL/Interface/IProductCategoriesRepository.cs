using App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interface
{
    public interface IProductCategoriesRepository
    {
        Task<List<ProductCategories>> GetAllAsync();
    }
}
