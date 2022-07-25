using BLL.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace WebApp.Controllers
{
	[Authorize]
	public class ProductController : Controller
	{
		private readonly IProductService productService;
		private readonly ICategoryService categoryService;

		public ProductController(IProductService productService, ICategoryService categoryService)
		{
			this.productService = productService;
			this.categoryService = categoryService;
		}
		public IActionResult Index(int Id, int page=0)
		{
			var productCount = productService.GetProductListByCategoryId(Id).data.Count();
			int take = 3;

			var totalpage = Math.Ceiling(Convert.ToDecimal(productCount) / take);
			ViewBag.Totalpage = totalpage;
			ViewBag.Product = Id;
			var skip = page * take;
			


			var result = productService.GetProductListByCategoryId(Id);
			switch (result.resultType)
			{
				case Core.Business.ResultTypes.ResultType.Success:
					return View(result.data.Skip(skip).Take(take).ToList());
				case Core.Business.ResultTypes.ResultType.NotFound:
					return RedirectToAction("Index", "Home");
				case Core.Business.ResultTypes.ResultType.Warning:
					return RedirectToAction("Index", "Home");
				case Core.Business.ResultTypes.ResultType.Error:
					return RedirectToAction("Index", "Home");
				case Core.Business.ResultTypes.ResultType.NotValidation:
					return RedirectToAction("Index", "Home");
				case Core.Business.ResultTypes.ResultType.Notfound:
					return RedirectToAction("Index", "Home");
				case Core.Business.ResultTypes.ResultType.NotValidaiton:
					return RedirectToAction("Index", "Home");
				default:
					break;
			}
			return View();
		}
	}
}
