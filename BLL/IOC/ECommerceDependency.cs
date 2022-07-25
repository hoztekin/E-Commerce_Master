using BLL.Abstract;
using BLL.Concrete;
using DAL.Abstract;
using DAL.Concrete.EF.Database;
using DAL.Concrete.EntityFraneWork;
using Entity.POCO;
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
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EFCategoryRepo>();
            services.AddScoped<IAccountDAL, EFAccountRepo>();
            services.AddScoped<IAccountService, AccountManager>();
            services.AddScoped<IBrandService, BrandManager>();
            services.AddScoped<IBrandDAL, EfBrandRepo>();
            services.AddScoped<IBasketDAL, EFBasketRepo>();
            services.AddScoped<IBasketService, BasketManager>();
            services.AddDbContext<CommerceDbContext>();
            return services;
        }
    }
}
