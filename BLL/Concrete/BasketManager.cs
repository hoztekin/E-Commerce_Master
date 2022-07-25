using BLL.Abstract;
using Core.Business;
using Core.Business.ResultTypes;
using DAL.Abstract;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
	public class BasketManager : IBasketService
	{
		private readonly IBasketDAL basketDAL;

		public BasketManager(IBasketDAL basketDAL)
		{
			this.basketDAL = basketDAL;
		}
		public ResultMessage<bool> BasketAddOrUpdate(Basket basket)
		{
			try
			{
				var result = basketDAL.BasketAddOrUpdate(basket).Result;

				if (result)
				{
					return new ResultMessage<bool>(true, ResponseMessage.Add);
				}
				return new ResultMessage<bool>(false, ResponseMessage.AddWarning);


			}
			catch (Exception ex)
			{

				return new ResultMessage<bool>(false, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage<bool> Delete(Basket Entity)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<bool> Delete(object Id)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<Basket> Get(object Id)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<IEnumerable<BasketDTO>> GetBasketDto(object userId)
		{
			try
			{
				if (userId==null)
				{
					return new ResultMessage<IEnumerable<BasketDTO>>(null, ResponseMessage.NotValidation, ResultType.NotValidation);
				}
				var result = basketDAL.GetBasketDto(userId).Result;

				if (result.Count()>0)
				{
					return new ResultMessage<IEnumerable<BasketDTO>>(result, ResponseMessage.Add, ResultType.Success);
				}
				return new ResultMessage<IEnumerable<BasketDTO>>(null, ResponseMessage.SearchWarning, ResultType.Notfound);
			}
			catch (Exception ex)
			{

				return new ResultMessage<IEnumerable<BasketDTO>>(null, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage<IEnumerable<Basket>> GetList()
		{
			throw new NotImplementedException();
		}

		public ResultMessage<IEnumerable<Basket>> GetList(Expression<Func<Basket, bool>> func = null, params string[] include)
		{
			try
			{
				var result = basketDAL.GetList(func, include).Result;
				return new ResultMessage<IEnumerable<Basket>>(result, ResponseMessage.Add);
			}
			catch (Exception ex)
			{
				return new ResultMessage<IEnumerable<Basket>>(null, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage<IEnumerable<Basket>> GetList(int skip, int take, Expression<Func<Basket, bool>> func = null, params string[] include)
		{
			throw new NotImplementedException();
		}

		public ResultMessage Insert(Basket Entity)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<Basket> Update(Basket Entity)
		{
			throw new NotImplementedException();
		}
	}
}
