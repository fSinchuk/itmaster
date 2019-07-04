using App.DAL.Interface;
using App.Models;
using App.WEB.Controllers;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace App.WEB.Integration.Tests
{
    [TestClass]
    public class ProductControllerTest
    {
        [TestMethod]
        public async Task TestIndexAsyncAction()
        {

            var productRepo = new Mock<IProductsRepository>();
            var productCategoryRepo = new Mock<IProductCategoriesRepository>();
            var autoMapper = new Mock<IMapper>();

            productRepo.Setup(x => x.GetAllWithCategories()).Returns(Task.FromResult(new List<Products>() {
                new Products(){ Id=1, Name="Some test name", CategoryId=1, IsActive=true, Price=10, ProductCateogry= new ProductCategories(){ Id=1, Name="Category name" } },
                new Products(){ Id=2, Name="Some test name 2", CategoryId=2, IsActive=false, Price=5, ProductCateogry= new ProductCategories(){ Id=2, Name="Category name 2" } },
                new Products(){ Id=3, Name="Some test name 3", CategoryId=3, IsActive=true, Price=15, ProductCateogry= new ProductCategories(){ Id=3, Name="Category name 3" } }
            }));


            var productController = new ProductController(productRepo.Object, productCategoryRepo.Object, autoMapper.Object);

           IActionResult  result= await productController.IndexAsync();

            Assert.IsInstanceOfType(result,typeof(ActionResult));
        }
    }
}
