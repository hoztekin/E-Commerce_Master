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
	public interface IProductDAL : IGenericRepository<Product>
	{
		Task<bool> ProductCreate(ProductCreateDTO model);
		IEnumerable<ProductDTO> GetProductListByCategoryId(int categoryId);
	}
}
