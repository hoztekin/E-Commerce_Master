using BLL.Abstract;
using Core.Business;
using Core.Business.ResultTypes;
using DAL.Abstract;
using Entity.DTO;
using Entity.POCO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
	public class AccountManager : IAccountService
	{
		private readonly IAccountDAL accountDAL;

		public AccountManager(IAccountDAL accountDAL)
		{
			this.accountDAL = accountDAL;
		}

		public ResultMessage<object> GetUserId(string username)
		{
			try
			{
				var id = accountDAL.UserIdByUserName(username).Result;
				if ((int)id != 0)
				{
					return new ResultMessage<object>(id, ResponseMessage.SearchSucces);
				}
				return new ResultMessage<object>(null, ResponseMessage.SearchWarning, ResultType.Notfound);
			}
			catch (Exception ex)
			{
				return new ResultMessage<object>(null, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage<SignInResult> Login(AppUserLoginDTO model)
		{
			try
			{
				var result = accountDAL.Login(model).Result;
				if (result.Succeeded)
				{
					return new ResultMessage<SignInResult>(result, ResponseMessage.Add, ResultType.Success);
				}
				return new ResultMessage<SignInResult>(null, ResponseMessage.AddWarning, ResultType.Warning);
			}
			catch (Exception ex)
			{
				return new ResultMessage<SignInResult>(null, ex.ToInnest().Message, ResultType.Error);
			}
		}

		

		public ResultMessage LogOut()
		{
			try
			{
				accountDAL.LogOut();
				return new ResultMessage("Succues");
			}
			catch (Exception ex)
			{

				throw;
			}
		}

		public ResultMessage<IdentityResult> Register(AppUser appuser, string password)
		{
			try
			{
				var result = accountDAL.Register(appuser, password).Result;

				if (result.Succeeded)
				{
					return new ResultMessage<IdentityResult>(result, ResponseMessage.Add, ResultType.Success);
				}
				return new ResultMessage<IdentityResult>(null, ResponseMessage.AddWarning, ResultType.Warning);
			}
			catch (Exception ex)
			{
				return new ResultMessage<IdentityResult>(null, ex.ToInnest().Message, ResultType.Error);
			}
		}
	}
}
