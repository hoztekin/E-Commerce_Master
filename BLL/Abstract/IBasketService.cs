using Core.Business.ResultTypes;
using Entity.DTO;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
	public interface IBasketService : IGenericService<Basket>
	{
		ResultMessage<bool> BasketAddOrUpdate(Basket basket);

		ResultMessage<IEnumerable<BasketDTO>> GetBasketDto(object userId);
	}
}
