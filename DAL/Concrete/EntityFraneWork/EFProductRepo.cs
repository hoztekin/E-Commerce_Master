using DAL.Abstract;
using DAL.Concrete.EF;
using DAL.Concrete.EF.Database;
using Entity.DTO;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFraneWork
{
	public class EFProductRepo : EFRepository<Product, CommerceDbContext>, IProductDAL
	{
		private readonly CommerceDbContext db;

		public EFProductRepo(CommerceDbContext db) : base(db)
		{
			this.db = db;
		}

		public IEnumerable<ProductDTO> GetProductListByCategoryId(int categoryId)
		{
			var result =
			   from product in db.Products
			   join Brand in db.Products on product.Id equals Brand.Id
			   join proCategory in db.ProductCategories on product.Id equals proCategory.ProductId
			   join category in db.Categories on proCategory.CategoryId equals category.Id
			   
			   where product.Active == true && product.Deleted == false
			   && proCategory.CategoryId == categoryId
			   select new ProductDTO
			   {
				   Description = product.Description,
				   ProductId = product.Id,
				   CatagoryName = category.CategoryName,
				   CategoryId = category.Id,
				   StockLevel = product.StockLevel,
				   ListPrice = product.ListPrice,
				   ProductName = product.ProductName,
				   BrandId = Brand.Id,
				   BrandName = Brand.BrandName,
				   
				   Imageurl = db.ProductImages.FirstOrDefault(x => x.ProductId == product.Id).ImageUrl
			   };
			return result;
		}
		
		public async Task<bool> ProductCreate(ProductCreateDTO model)
		{
			bool ok = false;
			var strategy = db.Database.CreateExecutionStrategy();

			strategy.Execute(() =>
			{
				using (var transaction = db.Database.BeginTransaction())
				{
					try
					{
						Product product = new Product()
						{
							Description = model.Description,
							ProductName = model.ProductName,
							ListPrice = model.ListPrice,
							StockLevel = model.StokLevel
						};
						db.Products.Add(product);
						var productResult = db.SaveChanges();
						if (productResult == 0) transaction.Rollback();
						else
						{
							ProductCategory productcategory = new ProductCategory
							{
								CategoryId = model.CategoryId,
								ProductId = product.Id
							};
							db.ProductCategories.Add(productcategory);

							foreach (var item in model.ImageUrl)
							{
								ProductImage productImage = new ProductImage
								{
									ImageUrl = item,
									ProductId = product.Id
								};
								db.ProductImages.Add(productImage);
							}

							var result = db.SaveChanges();

							if (result == 0)
							{
								transaction.Rollback();
							}
							else
							{
								ok = true;
								transaction.Commit();
							}
						}
					}
					catch (Exception)
					{
						transaction.Rollback();
					}
				}
			});
			return await Task.FromResult(ok);
		}
	}
}
