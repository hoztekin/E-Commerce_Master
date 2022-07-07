using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
	public class ProductSupplier : BaseEntity
	{
		public int ProductId { get; set; }
		public int SupplierId { get; set; }


		public virtual Product Product { get; set; }
		public virtual Supplier Supplier { get; set; }
	}
}
