using Core.DAL.Repository;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
	public interface IBasketDAL :  IGenericRepository<Basket>
	{
		Task<bool> BasketAddOrUpdate(Basket basket);
		Task<int> CountByUser(object userid);
		Task<IEnumerable<BasketDTO>> GetBasketDto(object userId);
	}
}
