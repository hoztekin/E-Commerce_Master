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
		
		private ICategoryService categorService;

		public HomeController(ICategoryService categorService) 
		{
			this.categorService = categorService;
		}

		//private readonly ILogger<HomeController> _logger;
		//private readonly ICategoryService categorService;

		//public HomeController(ILogger<HomeController> logger)
		//{
		//	_logger = logger;
		//}

		public IActionResult Index()
		{
			HomePageWiewModel model = new HomePageWiewModel();			
			var result = categorService.GetList();
			switch (result.resultType)
			{
				case Core.Business.ResultTypes.ResultType.Success:
					model.Categories = result.data.ToList();
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
		//}
	}
}
