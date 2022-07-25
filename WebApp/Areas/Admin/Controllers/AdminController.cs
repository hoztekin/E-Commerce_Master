using Microsoft.AspNetCore.Mvc;
using System;

namespace WebApp.Areas.Admin.Controllers
{

	[Area ("Admin")]
	public class AdminController : BaseController
	{
		
		public IActionResult Index()
		{
			return View();
		}
	}
}
