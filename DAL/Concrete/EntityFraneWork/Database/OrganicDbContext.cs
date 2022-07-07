using DAL.Concrete.Database.Mapping;
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
	public class OrganicDbContext : IdentityDbContext<AppUser, AppRole, int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=DESKTOP-EKG7OCR;Database=OrganicDb;Integrated Security=true");
			base.OnConfiguring(optionsBuilder);
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfiguration<Product>(new ProductMap());
			builder.ApplyConfiguration<Customer>(new CustomerMap());
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
	
	}
}
