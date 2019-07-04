using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using App.Models;
using App.DAL.Repository;

namespace App.DAL.Tests
{
    [TestClass]
    public class ProductCategoriesRepositoryTest 
    {
        
        [TestMethod]
        public async Task GetCategoryById()
        {
            using (var db = Helper.GetContext("productCategories"))
            {
                await db.AddRangeAsync(new ProductCategories[] {
                    new ProductCategories{ Id=1, Name="Category 1" },
                    new ProductCategories{ Id=2, Name="Category 2" },
                    new ProductCategories{ Id=3, Name="Category 3" },
                });

                await db.SaveChangesAsync();
            }

            using (var db = Helper.GetContext("productCategories")) {

                var repo = new ProductCategoriesRepository(db);

                var result1 = await repo.GetByIDAsync(1);
                var result2 = await repo.GetByIDAsync(2);
                var result3 = await repo.GetByIDAsync(3);


                Assert.IsTrue(result1.Id == 1, "Returned id should be 1");
                Assert.IsTrue(result2.Id == 2, "Returned id should be 2");
                Assert.IsTrue(result3.Id == 3, "Returned id should be 3");
            }
        }

        
    }
}
