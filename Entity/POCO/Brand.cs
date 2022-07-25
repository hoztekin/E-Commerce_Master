using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
	public class Brand : BaseEntity
	{
		public string BrandName { get; set; }
		public virtual ICollection<ProductBrand> ProductBrand { get; set; }
	}
}
