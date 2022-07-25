using BLL.Abstract;
using BLL.Validation;
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
	internal class ProductManager : IProductService
	{
		private readonly IProductDAL productDAL;

		public ProductManager(IProductDAL productDAL)
		{
			this.productDAL = productDAL;
		}
		public ResultMessage<bool> Delete(Product Entity)
		{
			try
			{
				if (productDAL.Delete(Entity).Result)
				{
					return new ResultMessage<bool>(true, ResponseMessage.Add, ResultType.Success);
				}
				return new ResultMessage<bool>(false, ResponseMessage.DeleteWarning, ResultType.Warning);
			}
			catch (Exception ex)
			{

				return new ResultMessage<bool>(false, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage<bool> Delete(object Id)
		{
			try
			{
				if (productDAL.Delete(Id).Result)
				{
					return new ResultMessage<bool>(true, ResponseMessage.Delete, ResultType.Success);
				}
				return new ResultMessage<bool>(false, ResponseMessage.DeleteWarning, ResultType.Warning);
			}
			catch (Exception ex)
			{

				return new ResultMessage<bool>(false, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage<Product> Get(object Id)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<IEnumerable<Product>> GetList()
		{
			try
			{
				var result = productDAL.GetList().Result;
				if (result != null && result.Count() > 0)
				{
					return new ResultMessage<IEnumerable<Product>>(result, ResponseMessage.SearchSucces, ResultType.Success);
				}
				return new ResultMessage<IEnumerable<Product>>(null, ResponseMessage.SearchWarning, ResultType.Notfound);
			}
			catch (Exception ex)
			{
				return new ResultMessage<IEnumerable<Product>>(null, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage<IEnumerable<Product>> GetList(Expression<Func<Product, bool>> func = null, params string[] include)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<IEnumerable<Product>> GetList(int skip, int take, Expression<Func<Product, bool>> func = null, params string[] include)
		{
			throw new NotImplementedException();
		}

		public ResultMessage<IEnumerable<ProductDTO>> GetProductListByCategoryId(int categoryId)
		{
			try
			{
				var result = productDAL.GetProductListByCategoryId(categoryId);
				if (result.Count() > 0)
				{
					return new ResultMessage<IEnumerable<ProductDTO>>(result, ResponseMessage.SearchSucces, ResultType.Success);
				}
				return new ResultMessage<IEnumerable<ProductDTO>>(null, ResponseMessage.SearchWarning, ResultType.Notfound);
			}
			catch (Exception ex)
			{
				return new ResultMessage<IEnumerable<ProductDTO>>(null, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage Insert(Product Entity)
		{
			try
			{
				var product = productDAL.Insert(Entity).Result;

				if (product != null)
				{
					return new ResultMessage<Product>(product, ResponseMessage.Add, ResultType.Success);
				}
				return new ResultMessage<Product>(null, ResponseMessage.AddWarning, ResultType.Warning);
			}
			catch (Exception ex)
			{

				return new ResultMessage<Product>(null, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage<bool> ProductCreate(ProductCreateDTO model)
		{
			try
			{
				ProductDTOValidation validations = new ProductDTOValidation(productDAL);
				var val = validations.Validate(model);

				if (!val.IsValid)
				{
					return new ResultMessage<bool>(false, val.Errors, ResultType.NotValidation);
				}

				if (productDAL.ProductCreate(model).Result)
				{
					return new ResultMessage<bool>(true, ResponseMessage.ProductAdd, ResultType.Success);
				}
				return new ResultMessage<bool>(false, ResponseMessage.ProductAddWarning, ResultType.Warning);
			}

			catch (Exception ex)
			{
				return new ResultMessage<bool>(false, ex.ToInnest().Message, ResultType.Error);
			}
		}

		public ResultMessage<Product> Update(Product Entity)
		{
			try
			{
				var product = productDAL.Update(Entity).Result;
				if (product != null)
				{
					return new ResultMessage<Product>(product, ResponseMessage.Update, ResultType.Success);
				}
				return new ResultMessage<Product>(null, ResponseMessage.UpdateWarning, ResultType.Warning);
			}
			catch (Exception ex)
			{
				return new ResultMessage<Product>(null, ex.ToInnest().Message, ResultType.Error);
			}
		}
	}
}
