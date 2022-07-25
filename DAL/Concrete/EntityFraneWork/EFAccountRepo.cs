using Core.DAL;
using DAL.Abstract;
using Entity.DTO;
using Entity.POCO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFraneWork
{
	public class EFAccountRepo : IAccountDAL
	{
		public readonly UserManager<AppUser> userManager;
		public readonly SignInManager<AppUser> signInManager;

		public EFAccountRepo(UserManager <AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager)
		{
			this.userManager = userManager;
			this.signInManager = signInManager;
		}
		public async Task<IdentityResult> Register(AppUser appuser, string password)
		{
			var result = await userManager.CreateAsync(appuser, password);

			if (result.Succeeded)
			{
				var user = await userManager.FindByNameAsync(appuser.UserName);
				var RoleResult = userManager.AddToRoleAsync(user, RoleEnums.User.ToString());
				if (RoleResult.IsCompletedSuccessfully)
				{
					return result;
				}
			}
			return null;

		}
		public async Task<SignInResult> Login(AppUserLoginDTO model) 
		{
			return await signInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);
			
		}



		public async Task<object> UserIdByUserName(string username)
		{
			var user = await userManager.FindByNameAsync(username);
			return user.Id;
		}

		public async Task LogOut()
		{
			await signInManager.SignOutAsync();
		}
	}
}
