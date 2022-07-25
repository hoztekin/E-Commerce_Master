using DAL.Concrete.EF.Database;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SeedData
{
	public static class Seed
	{
		public static void SeedData()
		{
			CommerceDbContext db = new CommerceDbContext();

			List<Category> categories = new List<Category>
			{
			new Category{CategoryName = "Erkek", ImageUrl = "/images/home/product2" },
			new Category{CategoryName = "Kadın", ImageUrl = "/images/home/product1" },
			new Category{CategoryName = "Çocuk", ImageUrl = "/images/home/product3" },

			};
			db.Categories.AddRange(categories);
			List<Product> products = new List<Product>()
			{
				new Product{ProductName="Gömlek", ListPrice=200, StockLevel=100 },
				new Product{ProductName="Etek", ListPrice=40, StockLevel=100 },
				new Product{ProductName="Pantolon", ListPrice=10, StockLevel=500 },
				new Product{ProductName="Short", ListPrice=40, StockLevel=50 },
				new Product{ProductName="Çorap", ListPrice=60, StockLevel=100 },
				new Product{ProductName="Kazak", ListPrice=30, StockLevel=10 },
				new Product{ProductName="Atkı", ListPrice=60, StockLevel=15 },
				new Product{ProductName="Çanta", ListPrice=50, StockLevel=10 },
				new Product{ProductName="Ayakkabı", ListPrice=250, StockLevel=10 },
				new Product{ProductName="Terlik", ListPrice=60, StockLevel=50 },
				new Product{ProductName="Eldiven", ListPrice=20, StockLevel=5 },
				new Product{ProductName="Şapka", ListPrice=30, StockLevel=5 },
			};
			db.Products.AddRange(products);
			db.SaveChanges();

			List<ProductCategory> productCategories = new List<ProductCategory>
			{
				new ProductCategory{ CategoryId=1,ProductId=1},
				new ProductCategory{ CategoryId=2,ProductId=2},
				new ProductCategory{ CategoryId=3,ProductId=3},
				new ProductCategory{ CategoryId=1,ProductId=4},
				new ProductCategory{ CategoryId=2,ProductId=5},
				new ProductCategory{ CategoryId=3,ProductId=6},
				new ProductCategory{ CategoryId=1,ProductId=7},
				new ProductCategory{ CategoryId=2,ProductId=8},
				new ProductCategory{ CategoryId=3,ProductId=9},
				new ProductCategory{ CategoryId=1,ProductId=10},
				new ProductCategory{ CategoryId=2,ProductId=11},
				new ProductCategory{ CategoryId=3,ProductId=12},
			};
			db.ProductCategories.AddRange(productCategories);
			db.SaveChanges();

			List<Brand> brands = new List<Brand>
			{
				new Brand {BrandName = "Adidas" },
				new Brand {BrandName = "Lacoste" },
				new Brand {BrandName = "MaviJeans" },
				new Brand {BrandName = "Desa" },
				new Brand {BrandName = "Osse" },
				new Brand {BrandName = "Puma" },

			};
			db.AddRange(brands);

			List<ProductBrand> productBrands = new List<ProductBrand> 
			{ 
			new ProductBrand {BrandId = 1, ProductId=1},
			new ProductBrand {BrandId = 2, ProductId=2},
			new ProductBrand {BrandId = 3, ProductId=3},
			new ProductBrand {BrandId = 4, ProductId=4},
			new ProductBrand {BrandId = 5, ProductId=5},
			new ProductBrand {BrandId = 6, ProductId=6},
			};
			db.AddRange(productBrands);

			List<ProductImage> ProductImages = new List<ProductImage>
			{
				new ProductImage{ ProductId=1, ImageUrl="/Images/Home/product1.jpg"},		
				new ProductImage{ ProductId=2, ImageUrl="/Images/Home/product2.jpg"},		
				new ProductImage{ ProductId=3, ImageUrl="/Images/Home/product3.jpg"},
				new ProductImage{ ProductId=4, ImageUrl="/Images/Home/product4.jpg"},
				new ProductImage{ ProductId=5, ImageUrl="/Images/Home/product5.jpg"},
				new ProductImage{ ProductId=5, ImageUrl="/Images/Home/product6.jpg"},
				new ProductImage{ ProductId=6, ImageUrl="/Images/Home/product1.jpg"},
				new ProductImage{ ProductId=7, ImageUrl="/Images/Home/product2.jpg"},
				new ProductImage{ ProductId=8, ImageUrl="/Images/Home/product3.jpg"},
				new ProductImage{ ProductId=9, ImageUrl="/Images/Home/product4.jpg"},
				new ProductImage{ ProductId=10, ImageUrl="/Images/Home/product5.jpg"},
				new ProductImage{ ProductId=11, ImageUrl="/Images/Home/product6.jpg"},
				new ProductImage{ ProductId=12, ImageUrl="/Images/Home/product2.jpg"},
				
			};
			db.ProductImages.AddRange(ProductImages);
			db.SaveChanges();
		}
	}
}