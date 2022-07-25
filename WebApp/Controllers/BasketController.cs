using BLL.Abstract;
using Entity.POCO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebApp.Models;

namespace WebApp.Controllers
{
	[Authorize]
	public class BasketController : Controller
	{
		private readonly IBasketService basketService;
		private readonly IAccountService accountService;
		private readonly IProductService productService;

		public BasketController(IBasketService basketService, IAccountService accountService, IProductService productService)
		{
			this.basketService = basketService;
			this.accountService = accountService;
			this.productService = productService;
		}


		public IActionResult Index(int ProductId, int Count = 1)
		{
			
			if (!User.Identity.IsAuthenticated)
			{
				return View(new { Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized });
			}

			Basket basket = new Basket();
			basket.Count = Count;
			basket.ProductId = ProductId;
			var userid = Request.Cookies["userid"];
			basket.AppUserId = Convert.ToInt32(userid);

			var result = basketService.BasketAddOrUpdate(basket).data;
		

			if (result)
			{
				var resultBasket = basketService.GetBasketDto(userid);
				switch (resultBasket.resultType)
				{
					case Core.Business.ResultTypes.ResultType.Success:
						return View(resultBasket.data.ToList());
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
				return View(Microsoft.AspNetCore.Http.StatusCodes.Status200OK);
			}

			else
			{
				return View(Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
			}

			return View();
		}

		public IActionResult AddBasket(int ProductId, int Count = 1)
		{
			

			if (!User.Identity.IsAuthenticated)
			{
				return View (new {Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized});
			}

			Basket basket = new Basket();
			basket.Count = Count;
			basket.ProductId = ProductId;
			var userid = Request.Cookies["userid"];
			basket.AppUserId = Convert.ToInt32(userid);
			
			var result = basketService.BasketAddOrUpdate(basket).data;


			if (result)
			{
				var resultBasket = basketService.GetBasketDto(userid);
				switch (resultBasket.resultType)
				{
					case Core.Business.ResultTypes.ResultType.Success:
						return View (resultBasket.data.ToList());
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
				return View (Microsoft.AspNetCore.Http.StatusCodes.Status200OK);
			}

			else
			{
				return View (Microsoft.AspNetCore.Http.StatusCodes.Status500InternalServerError);
			}
			
		}

		[HttpGet]
		public IActionResult GetBasket()
		{
			if (User.Identity.IsAuthenticated)
			{
				var userid = Request.Cookies["userid"];
				if (!string.IsNullOrEmpty(userid))
				{
					var result = basketService.GetList(x => x.AppUserId == Convert.ToInt32(userid), "Product").data.ToList();
				}
			}
			return null;

		}

		[HttpGet]
		public IActionResult GetListBasket()
		{
			if (!User.Identity.IsAuthenticated)
			{
				return View(new {Microsoft.AspNetCore.Http.StatusCodes.Status401Unauthorized}); 
			}

			var userid = Request.Cookies["userid"];
			var resultBasket = basketService.GetBasketDto(userid);
			switch (resultBasket.resultType)
			{
				case Core.Business.ResultTypes.ResultType.Success:
					return View (resultBasket.data.ToList()); 
				case Core.Business.ResultTypes.ResultType.Notfound:
					return RedirectToAction("Index", "Home");
				case Core.Business.ResultTypes.ResultType.Warning:
					return RedirectToAction("Index", "Home");
				case Core.Business.ResultTypes.ResultType.Error:
					return RedirectToAction("Index", "Home");
				case Core.Business.ResultTypes.ResultType.NotValidaiton:
					return RedirectToAction("Index", "Home");
				default:
					break;
			}
			return null;
		}




	}
}
