using BLL.Abstract;
using Core.Business;
using Core.Business.ResultTypes;
using DAL.Abstract;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
	public class BrandManager : IBrandService
	{
		private readonly IBrandDAL brandDAL;

		public BrandManager(IBrandDAL brandDAL)
		{
			this.brandDAL = brandDAL;
		}

		public ResultMessage<bool> Delete(Brand Entity)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<bool> Delete(object Id)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<Brand> Get(object Id)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<IEnumerable<Brand>> GetList()
		{
			try
			{
				var result = brandDAL.GetList().Result;
				if (result != null && result.Count() > 0)
				{
					return new ResultMessage<IEnumerable<Brand>>(result, ResponseMessage.SearchSucces, ResultType.Success);
				}
				return new ResultMessage<IEnumerable<Brand>>(null, ResponseMessage.SearchWarning, ResultType.Notfound);
			}
			catch (Exception ex)
			{
				return new ResultMessage<IEnumerable<Brand>>(null, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage<IEnumerable<Brand>> GetList(Expression<Func<Brand, bool>> func = null, params string[] include)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<IEnumerable<Brand>> GetList(int skip, int take, Expression<Func<Brand, bool>> func = null, params string[] include)
		{
			throw new NotImplementedException();
		}

		public ResultMessage Insert(Brand Entity)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<Brand> Update(Brand Entity)
		{
			throw new NotImplementedException();
		}
	}
}
