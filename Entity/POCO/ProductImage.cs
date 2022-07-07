using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
	public class ProductImage : BaseEntity
	{
		public int ProductId { get; set; }
		public string ImageUrl { get; set; }
		public virtual Product Product { get; set; }
	}
}
