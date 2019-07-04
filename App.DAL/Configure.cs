using App.DAL.Interface;
using App.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace App.DAL
{
    public class Configure
    {
        public static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(connectionString));
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped<IProductCategoriesRepository, ProductCategoriesRepository>();
        }
    }
}
