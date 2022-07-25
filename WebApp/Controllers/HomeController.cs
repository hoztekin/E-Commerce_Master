using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Controllers
{
	public class HomeController : Controller
	{
		
		private readonly ICategoryService categoryService;
		private readonly IBrandService brandService;
		private readonly IProductService productService;

		public HomeController(ICategoryService categoryService, IBrandService brandService, IProductService productService)
		{
			this.categoryService = categoryService;
			this.brandService = brandService;
			this.productService = productService;
		}

		

		public IActionResult Index()
		{
			HomePageViewModel model = new HomePageViewModel();

			var result = categoryService.GetList();
			switch (result.resultType)
			{
				case Core.Business.ResultTypes.ResultType.Success:
					model.Categories = result.data.ToList();
					break;
				case Core.Business.ResultTypes.ResultType.Notfound:
					break;
				case Core.Business.ResultTypes.ResultType.Warning:
					break;
				case Core.Business.ResultTypes.ResultType.Error:
					break;
				case Core.Business.ResultTypes.ResultType.NotValidaiton:
					break;
				default:
					break;
			}

			var result1 = brandService.GetList();
			switch (result1.resultType)
			{
				case Core.Business.ResultTypes.ResultType.Success:
					model.Brands = result1.data.ToList();
					break;
				case Core.Business.ResultTypes.ResultType.NotFound:
					break;
				case Core.Business.ResultTypes.ResultType.Warning:
					break;
				case Core.Business.ResultTypes.ResultType.Error:
					break;
				case Core.Business.ResultTypes.ResultType.NotValidation:
					break;
				case Core.Business.ResultTypes.ResultType.Notfound:
					break;
				case Core.Business.ResultTypes.ResultType.NotValidaiton:
					break;
				default:
					break;
			}

			var result2 = productService.GetList();
			switch (result2.resultType)
			{
				case Core.Business.ResultTypes.ResultType.Success:
					model.Products = result2.data.ToList();
					break;
				case Core.Business.ResultTypes.ResultType.NotFound:
					break;
				case Core.Business.ResultTypes.ResultType.Warning:
					break;
				case Core.Business.ResultTypes.ResultType.Error:
					break;
				case Core.Business.ResultTypes.ResultType.NotValidation:
					break;
				case Core.Business.ResultTypes.ResultType.Notfound:
					break;
				case Core.Business.ResultTypes.ResultType.NotValidaiton:
					break;
				default:
					break;
			}

			return View(model);

		}

		//public IActionResult Privacy()
		//{
		//	return View();
		//}

		//[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		//public IActionResult Error()
		//{
		//	return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		//private readonly ILogger<HomeController> _logger;

		//public HomeController(ILogger<HomeController> logger)
		//{
		//	_logger = logger;
		//}
	}
	
}
