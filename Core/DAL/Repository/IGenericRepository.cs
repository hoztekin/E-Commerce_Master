using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DAL.Repository
{
	public interface IGenericRepository<T>
		where T : class, IBaseEntity, new()
	{
		Task<T> Insert(T Entity);
		Task<bool> Delete(T Entity);
		Task<bool> Delete(object Id);
		Task<T> Update(T Entity);
		Task<T> Get(object Id);
		Task<IEnumerable<T>> GetList();
		Task<IEnumerable<T>> GetList(Expression<Func<T, bool>> func = null, params string[] include);
		Task<IEnumerable<T>> GetList(int skip, int take, Expression<Func<T, bool>> func = null, params string[] include);
	}
}
