using Core.Business.ResultTypes;
using Entity.DTO;
using Entity.POCO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
	public interface IAccountService
	{
		ResultMessage<IdentityResult> Register(AppUser appuser, string password);
		ResultMessage<SignInResult> Login(AppUserLoginDTO model);
		ResultMessage LogOut();
		ResultMessage<object> GetUserId(string username);
	}
}
