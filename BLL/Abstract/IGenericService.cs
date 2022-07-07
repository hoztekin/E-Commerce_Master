using Core.Business.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
	public interface IGenericService<T>
	{
        ResultMessage Insert(T Entity);
        ResultMessage<bool> Delete(T Entity);
        ResultMessage<bool> Delete(object Id);
        ResultMessage<T> Update(T Entity);
        ResultMessage<T> Get(object Id);
        ResultMessage<IEnumerable<T>> GetList();
        ResultMessage<IEnumerable<T>> GetList(Expression<Func<T, bool>> func = null, params string[] include);
        ResultMessage<IEnumerable<T>> GetList(int skip, int take, Expression<Func<T, bool>> func = null, params string[] include);
    }
}
