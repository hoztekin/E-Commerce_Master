using DAL.Concrete.Database.Mapping;
using DAL.Concrete.EntityFraneWork.Mapping;
using DAL.Concrete.Mapping;
using Entity.POCO;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EF.Database
{
	public class CommerceDbContext : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-EKG7OCR;Database=CommerceDb;Integrated Security=true; MultipleActiveResultSets=true");
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<AppRole>().HasData
				(new AppRole { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
				 new AppRole { Id = 2, Name = "User",  NormalizedName = "USER" });
			builder.ApplyConfiguration<Product>(new ProductMap());
			builder.ApplyConfiguration<Customer>(new CustomerMap());
			builder.ApplyConfiguration<Category>(new CategoryMap());
			base.OnModelCreating(builder);
		}
		public DbSet<Basket> Baskets { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Customer> Customers { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<Product> Products { get; set; }
		public DbSet<ProductCategory> ProductCategories { get; set; }
		public DbSet<ProductImage> ProductImages { get; set; }
		public DbSet<ProductSupplier> ProductSuppliers { get; set; }
		public DbSet<Supplier> Suppliers { get; set; }
		public DbSet<Address> Address { get; set; }
		public DbSet<Brand> Brands { get; set; }
		public DbSet<ProductBrand> ProductBrands { get; set; }
	}
}
