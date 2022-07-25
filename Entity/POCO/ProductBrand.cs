using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
	public class ProductBrand : BaseEntity
	{
		public int ProductId { get; set; }
		public int BrandId { get; set; }


		public virtual Product Product { get; set; }
		public virtual Brand Brand { get; set; }
	}
}
