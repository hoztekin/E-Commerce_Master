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
			OrganicDbContext db = new OrganicDbContext();

			List<Category> categories = new List<Category>
			{
			new Category{CategoryName = "Et", ImageUrl = "/img/categories/banner-1" },
			new Category{CategoryName = "Meyve", ImageUrl = "/img/categories/banner-2" },
			new Category{CategoryName = "Kahvaltılık", ImageUrl = "/img/blog/blog-1" },
			new Category{CategoryName = "Sebze", ImageUrl = "/img/blog/blog-2" },
			new Category{CategoryName = "Temel Gıda", ImageUrl = "/img/blog/blog-3" },
			new Category{CategoryName = "İçecekler", ImageUrl = "/img/blog/blog-4" },
			new Category{CategoryName = "Bakliyat", ImageUrl = "/img/blog/blog-3" },
			new Category{CategoryName = "Şarküteri", ImageUrl = "/img/blog/blog-4" },
			};
			db.Categories.AddRange(categories);
			List<Product> products = new List<Product>()
			{
				new Product{ProductName="Dana Eti", ListPrice=200, StockLevel=100 },
				new Product{ProductName="Muz", ListPrice=40, StockLevel=100 },
				new Product{ProductName="Süt", ListPrice=10, StockLevel=500 },
				new Product{ProductName="Portakal", ListPrice=40, StockLevel=50 },
				new Product{ProductName="Meyve Suyu", ListPrice=60, StockLevel=100 },
				new Product{ProductName="Elma", ListPrice=30, StockLevel=10 },
				new Product{ProductName="Peynir", ListPrice=60, StockLevel=15 },
				new Product{ProductName="Zeytin", ListPrice=50, StockLevel=10 },
				new Product{ProductName="Zeytinyağı", ListPrice=250, StockLevel=10 },
				new Product{ProductName="Salça", ListPrice=60, StockLevel=50 },
				new Product{ProductName="Yumurta", ListPrice=20, StockLevel=5 },
				new Product{ProductName="Kefir", ListPrice=30, StockLevel=5 },
			};
			db.Products.AddRange(products);
			db.SaveChanges();

			List<ProductCategory> productCategories = new List<ProductCategory>
			{
				new ProductCategory{ CategoryId=1,ProductId=1},
				new ProductCategory{ CategoryId=2,ProductId=2},
				new ProductCategory{ CategoryId=3,ProductId=3},
				new ProductCategory{ CategoryId=4,ProductId=4},
				new ProductCategory{ CategoryId=5,ProductId=5},
				new ProductCategory{ CategoryId=6,ProductId=6},
				new ProductCategory{ CategoryId=1,ProductId=7},
				new ProductCategory{ CategoryId=2,ProductId=8},
				new ProductCategory{ CategoryId=3,ProductId=9},
				new ProductCategory{ CategoryId=4,ProductId=10},
				new ProductCategory{ CategoryId=7,ProductId=11},
				new ProductCategory{ CategoryId=8,ProductId=12},
			};
			db.ProductCategories.AddRange(productCategories);
			db.SaveChanges();

			List<ProductImage> ProductImages = new List<ProductImage>
			{
				new ProductImage{ ProductId=1, ImageUrl="/Image/Product/product-1.jpg"},
				new ProductImage{ ProductId=1, ImageUrl="/Image/Product/product-2.jpg"},
				new ProductImage{ ProductId=2, ImageUrl="/Image/Product/product-3.jpg"},
				new ProductImage{ ProductId=2, ImageUrl="/Image/Product/product-4.jpg"},
				new ProductImage{ ProductId=3, ImageUrl="/Image/Product/product-5.jpg"},
				new ProductImage{ ProductId=4, ImageUrl="/Image/Product/product-6.jpg"},
				new ProductImage{ ProductId=3, ImageUrl="/Image/Product/product-7.jpg"},
				new ProductImage{ ProductId=5, ImageUrl="/Image/Product/product-8.jpg"},
				new ProductImage{ ProductId=6, ImageUrl="/Image/Product/product-9.jpg"},
				new ProductImage{ ProductId=6, ImageUrl="/Image/Product/product-10.jpg"},
				new ProductImage{ ProductId=6, ImageUrl="/Image/Product/product-11.jpg"},
				new ProductImage{ ProductId=6, ImageUrl="/Image/Product/product-12.jpg"},
				new ProductImage{ ProductId=6, ImageUrl="/Image/Product/discount/pd-1.jpg"},
				new ProductImage{ ProductId=7, ImageUrl="/Image/Product/discount/pd-2.jpg"},
				new ProductImage{ ProductId=8, ImageUrl="/Image/Product/discount/pd-3.jpg"},
				new ProductImage{ ProductId=9, ImageUrl="//Image/Product/discount/pd-4.jpg"},
				new ProductImage{ ProductId=10,ImageUrl="//Image/Product/discount/pd-5.jpg"},
				new ProductImage{ ProductId=11,ImageUrl="//Image/Product/discount/pd-6"},
				new ProductImage{ ProductId=12,ImageUrl="/Image/Product/discount/pd-3.jpg"},
			};
			db.ProductImages.AddRange(ProductImages);
			db.SaveChanges();
		}
	}
}