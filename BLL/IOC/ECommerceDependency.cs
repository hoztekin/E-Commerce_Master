using BLL.Abstract;
using BLL.Concrete;
using DAL.Abstract;
using DAL.Concrete.EF.Database;
using DAL.Concrete.EntityFraneWork;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.IOC
{
    public static class ECommerceDependency
    {
        public static IServiceCollection Dependency(this IServiceCollection services)
        {
            
            services.AddScoped<IProductService, ProductManager>();
            services.AddScoped<IProductDAL, EFProductRepo>();
            services.AddScoped<OrganicDbContext>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EFCategoryRepo>();

            
            return services;
        }
    }
}
