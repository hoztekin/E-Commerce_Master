﻿using DAL.Abstract;
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
	public class EFProductRepo : EFRepository<Product, OrganicDbContext>, IProductDAL
	{
		private readonly OrganicDbContext db;

		public EFProductRepo(OrganicDbContext db) : base(db)
		{
			this.db = db;
		}

		public IEnumerable<ProductDTO> GetProductListByCategoryId(int categoryId)
		{
			var result =
			   from product in db.Products
			   join proCategory in db.ProductCategories on product.Id equals proCategory.ProductId
			   join category in db.Categories on proCategory.CategoryId equals category.Id
			   where product.Active == true && product.Deleted == false
			   && proCategory.CategoryId == categoryId
			   select new ProductDTO
			   {
				   ProductId = product.Id,
				   CatagoryName = category.CategoryName,
				   CategoryId = category.Id,
				   StockLevel = product.StockLevel,
				   ListPrice = product.ListPrice,
				   ProductName = product.ProductName,
				   Imageurl = db.ProductImages.FirstOrDefault(x => x.ProductId == product.Id).ImageUrl
			   };
			return result;
		}
		/// <summary>
		/// Model
		/// </summary>
		/// <param name="model"></param>
		/// <returns></returns>
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