using App.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Interface
{
    public interface IProductsRepository
    {
        Task<List<Products>> GetAllWithCategories();
        Task<Products> GetByIDAsync(int Id);
        Task UpdateAsync(Products item);
    }
        
}
