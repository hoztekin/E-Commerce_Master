using BLL.Abstract;
using System;
using System.Linq;
using WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public readonly ICategoryService categoryService;

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
            return View();

        }
    }
}
