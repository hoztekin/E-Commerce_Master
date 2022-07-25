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
	public class CategoryManager : ICategoryService
	{
		private readonly ICategoryDAL categoryDAL;

		public CategoryManager(ICategoryDAL categoryDAL)
		{
			this.categoryDAL = categoryDAL;
		}
		public ResultMessage<bool> Delete(Category Entity)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<bool> Delete(object Id)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<Category> Get(object Id)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<IEnumerable<Category>> GetList()
		{
			try
			{
				var result = categoryDAL.GetList().Result;
				if (result != null && result.Count() > 0)
				{
					return new ResultMessage<IEnumerable<Category>>(result, ResponseMessage.SearchSucces, ResultType.Success);
				}
				return new ResultMessage<IEnumerable<Category>>(null, ResponseMessage.SearchWarning, ResultType.Notfound);
			}
			catch (Exception ex)
			{
				return new ResultMessage<IEnumerable<Category>>(null, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage<IEnumerable<Category>> GetList(Expression<Func<Category, bool>> func = null, params string[] include)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<IEnumerable<Category>> GetList(int skip, int take, Expression<Func<Category, bool>> func = null, params string[] include)
		{
			throw new NotImplementedException();
		}

		public ResultMessage Insert(Category Entity)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<Category> Update(Category Entity)
		{
			throw new NotImplementedException();
		}
	}
}
