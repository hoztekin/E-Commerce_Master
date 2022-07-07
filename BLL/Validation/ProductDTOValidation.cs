using DAL.Abstract;
using Entity.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Validation
{
	public class ProductDTOValidation : AbstractValidator<ProductCreateDTO>
	{
		private readonly IProductDAL productDAL;

		public ProductDTOValidation(IProductDAL productDAL)
		{
			RuleFor(x => x.ProductName).NotEmpty();
			RuleFor(x => x.Description).MinimumLength(10).MaximumLength(200);
			RuleFor(x => x.ProductName).NotNull().WithMessage("Boş Geçilemez");
			RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Boş Geçilemez");
			RuleFor(x => x.ListPrice).GreaterThan(0).WithMessage("Geçerli Fiyat Giriniz");
			RuleFor(x => x.StokLevel).GreaterThan(0).WithMessage("Geçerli Stok Giriniz");
			RuleFor(x => x.ProductName).Must(NameUniq);

			this.productDAL = productDAL;
		}

		private bool NameUniq(string name)
		{
			var result = productDAL.GetList(x => x.ProductName == name).Result.Count();
			if (result == 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
}
