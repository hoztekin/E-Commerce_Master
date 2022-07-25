using System;
using BLL.Abstract;
using Entity.DTO;
using Entity.POCO;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
	public class AccountController : Controller
		
	{
		private readonly IAccountService accountService;

		public AccountController(IAccountService accountService)
		{
			this.accountService = accountService;
		}

		public IActionResult LogOut()
		{
			var result = accountService.LogOut();
			switch (result.resultType)
			{
				case Core.Business.ResultTypes.ResultType.Success:
					return RedirectToAction("Index", "Home");
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

			return RedirectToAction("Index", "Home");
		}

		[HttpGet]
		public IActionResult Login(string ReturnUrl)
		{

			return View();
		}

		[HttpPost]
		public IActionResult Login(AppUserLoginDTO model)
		{
			
			if (ModelState.IsValid)
			{
				var result = accountService.Login(model);
				switch (result.resultType)
				{
					case Core.Business.ResultTypes.ResultType.Success:
						var UserId = (int)accountService.GetUserId(model.UserName).data;
						Response.Cookies.Append("userid", UserId.ToString());
						return RedirectToAction("Index", "Home");
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
			}
			return View();
		}


		[HttpGet]
		public IActionResult Register()
		{
			return View();
		}


		[HttpPost]
		public IActionResult Register([FromForm] AppUserRegisterDTO model)
		{
			if (ModelState.IsValid) 
			{
				AppUser appUser = new AppUser();
				appUser.Email = model.EMail;
				appUser.UserName = model.UserName;
				appUser.PhoneNumber = model.Phone;
				var result = accountService.Register(appUser, model.Password);
				switch (result.resultType)
				{
					case Core.Business.ResultTypes.ResultType.Success:
						return RedirectToAction(actionName: "Login");
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
			}
			else
			{

			}
			
			return View();
		}

	}
}
