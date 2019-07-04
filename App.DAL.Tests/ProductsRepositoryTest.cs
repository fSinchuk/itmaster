using App.DAL.Repository;
using App.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace App.DAL.Tests
{
    [TestClass]
    public class ProductsRepositoryTest
    {

        private DataBaseContext db;

        [TestInitialize]
        public void Init() {
            db = Helper.GetContext("product");
            db.AddRange(new Products[] {
                    new Products{ Id=1, Name="product 1", CategoryId=1, Price=22.3, IsActive=true },
                    new Products{ Id=2, Name="product 2", CategoryId=2, Price=2.3, IsActive=true },
                    new Products{ Id=3, Name="product 3", CategoryId=3, Price=5.55, IsActive=false},
                });

            db.SaveChanges();
        }

        [TestMethod]
        public async Task GetProductById()
        {
           
                var repo = new ProductsRepository(db);

                var result1 = await repo.GetByIDAsync(1);
                var result2 = await repo.GetByIDAsync(2);
                var result3 = await repo.GetByIDAsync(3);


                Assert.IsTrue(result1.Id == 1, "Returned id should be 1");
                Assert.IsTrue(result2.Id == 2, "Returned id should be 2");
                Assert.IsTrue(result3.Id == 3, "Returned id should be 3");
        }

        [TestMethod]
        public async Task UpdateItem()
        {
            var repo = new ProductsRepository(db);

            Products item = await repo.GetByIDAsync(1);
            item.Name = "test";
            item.Price = 125;
            item.IsActive = false;

            db.SaveChanges();
            
            var savedItem = await repo.GetByIDAsync(1);

            Assert.AreEqual("test", savedItem.Name);
            Assert.AreEqual(125, savedItem.Price);
            Assert.AreEqual(false, savedItem.IsActive);

        }




        

    }
}
