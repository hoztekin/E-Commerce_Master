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
	public interface IProductService : IGenericService<Product>
	{
		ResultMessage<bool> ProductCreate(ProductCreateDTO model);
		ResultMessage<IEnumerable<ProductDTO>> GetProductListByCategoryId(int categoryId);
	}
}
