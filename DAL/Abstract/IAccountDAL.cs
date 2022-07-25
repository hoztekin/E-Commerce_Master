using Entity.DTO;
using Entity.POCO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
	public interface IAccountDAL
	{
		Task<IdentityResult> Register(AppUser appuser, string password);
		Task<SignInResult> Login(AppUserLoginDTO model);

		Task LogOut();
		Task<object> UserIdByUserName(string username);

	}
}
