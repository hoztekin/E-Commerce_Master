using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL.Concrete.EF.Database;
using Entity.POCO;
using Entity.DTO;
using WebApp.Areas.Admin.Data;
using Microsoft.AspNetCore.Http;

namespace WebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductsController : BaseController
	{
		private readonly CommerceDbContext _context;

		public ProductsController(CommerceDbContext context)
		{
			_context = context;
		}

		// GET: Admin/Products
		public async Task<IActionResult> Index()
		{
			var result =
			await _context.Products.Include(x => x.ProductCategory)
				.ThenInclude(x => x.Category)
				.ToListAsync();

			return View(result);
		}

		// GET: Admin/Products/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _context.Products
				.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// GET: Admin/Products/Create
		public IActionResult Create()
		{
			ViewBag.CategoryGroup = new SelectList(_context.Categories, "Id", "CategoryName");
			return View();
		}

		// POST: Admin/Products/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create(ProductAdminCreateDTO product)
		{
			if (ModelState.IsValid)
			{
				try
				{
					if (product.ProductImages.Count() > 0)
					{
						List<string> diziImage = new List<string>();
						foreach (IFormFile item in product.ProductImages)
						{
							var newUrl = System.IO.Path.Combine("/ProductImages/" + Guid.NewGuid().ToString() +
								System.IO.Path.GetExtension(item.FileName)
								);

							var serverUrl = System.IO.Directory.GetCurrentDirectory() + "\\wwwroot" + newUrl;
							System.IO.FileStream stream = new System.IO.FileStream(serverUrl, System.IO.FileMode.Create);
							await item.CopyToAsync(stream);
							stream.Close();
							diziImage.Add(newUrl);
						}

						var stratgy = _context.Database.CreateExecutionStrategy();

						await stratgy.ExecuteAsync(async () =>
						{
							using (var transaction = _context.Database.BeginTransaction())
							{
								try
								{
									Product product1 = new Product
									{
										Description = product.Description,
										ProductName = product.ProductName,
										ListPrice = product.ListPrice,
										StockLevel = product.Stock
									};
									_context.Products.Add(product1);
									await _context.SaveChangesAsync();

									foreach (var item in product.CategoryId)
									{
										_context.ProductCategories.Add(new ProductCategory
										{
											ProductId = product1.Id,
											CategoryId = item
										});
									}

									foreach (var item in diziImage)
									{
										_context.ProductImages.Add(new ProductImage
										{
											ImageUrl = item,
											ProductId = product1.Id
										});
									}
									await _context.SaveChangesAsync();
									await transaction.CommitAsync();
								}
								catch (Exception ex)
								{
									await transaction.RollbackAsync();
								}
							}
						});
						return RedirectToAction(actionName: "Index");
					}
					else
					{
						ModelState.AddModelError("ProductImages", "Ürün Fotoğrafı Zorunlu Alan");
						return View(product);
					}
				}
				catch (Exception ex)
				{

					throw;
				}
			}
			else
			{
				return View(product);
			}
			//return View(product);



			return View();
		}

		// GET: Admin/Products/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _context.Products.FindAsync(id);
			if (product == null)
			{
				return NotFound();
			}
			return View(product);
		}

		// POST: Admin/Products/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("ProductName,StockLevel,StandartCost,ListPrice,ProductNumber,Description,Id,Active,Deleted,Created,Update")] Product product)
		{
			if (id != product.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(product);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!ProductExists(product.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(product);
		}

		// GET: Admin/Products/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var product = await _context.Products
				.FirstOrDefaultAsync(m => m.Id == id);
			if (product == null)
			{
				return NotFound();
			}

			return View(product);
		}

		// POST: Admin/Products/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var product = await _context.Products.FindAsync(id);
			_context.Products.Remove(product);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));

		}
		

		private bool ProductExists(int id)
		{
			return _context.Products.Any(e => e.Id == id);
		}
	}
}
