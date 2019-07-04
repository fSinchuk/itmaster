using App.DAL.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using App.DAL.Interface;
using System.Threading.Tasks;
using AutoMapper;
using App.WEB.ViewModels;
using App.Models;

namespace App.WEB.Controllers
{
    public class ProductController : Controller
    {
        private readonly IMapper mapper;
        private IProductsRepository productRepo;
        private IProductCategoriesRepository categoryRepo;
        public ProductController(IProductsRepository productRepo, IProductCategoriesRepository categoryRepo, IMapper mapper)
        {
            this.productRepo = productRepo;
            this.mapper = mapper;
            this.categoryRepo = categoryRepo;
        }

        public async Task<IActionResult> IndexAsync()
        {
            var model = await productRepo.GetAllWithCategories();
            return View(model);
        }

        public async Task<IActionResult> EditAsync(int id)
        {
            var product = await productRepo.GetByIDAsync(id);
            var categories = await categoryRepo.GetAllAsync();

            var model = mapper.Map<ProductDTO>(product);
            model.Categories = mapper.Map<IEnumerable<ProductCategoryDTO>>(categories);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ProductDTO model) {

            if (ModelState.IsValid)
            {
                var product = mapper.Map<Products>(model);
                await productRepo.UpdateAsync(product);
                TempData["message"] = "Data saved !!!";
            }
            else {
                TempData["Error"] = "Error saving data";
            }


            var categories = await categoryRepo.GetAllAsync();
            model.Categories = mapper.Map<IEnumerable<ProductCategoryDTO>>(categories);

            return View("EditAsync",model);
        }

        public IActionResult Error() => View();
    }
}
