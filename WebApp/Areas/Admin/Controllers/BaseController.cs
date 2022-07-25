using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles="Admin,AdminHelper")]
	public class BaseController : Controller
	{
		
		
	}
}
