using System.Linq;
using BLL.Abstract;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.ViewCompenents
{
	public class HeaderViewComponent : ViewComponent
	{
		private readonly ICategoryService categoryService;

		public HeaderViewComponent(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}
		public IViewComponentResult Invoke() 
		{
			var result = categoryService.GetList();
			switch (result.resultType)
			{
				case Core.Business.ResultTypes.ResultType.Success:
					HeaderViewModel model = new HeaderViewModel();
					model.Categories = result.data.ToList();
					return View(model);
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
