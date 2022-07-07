using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace WebApp.Controllers
{
	public class CategoryController : Controller
	{
		private readonly ICategoryService categoryService;
		private readonly IProductService productService;

		public CategoryController(ICategoryService categoryService, IProductService productService)
		{
			this.categoryService = categoryService;
			this.productService = productService;
		}
		public IActionResult Index(int Id)
		{
			var result = productService.GetProductListByCategoryId(Id);
			switch (result.resultType)
			{
				case Core.Business.ResultTypes.ResultType.Success:
					return View(result.data.ToList());
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
			return View();
		}
	}
}
