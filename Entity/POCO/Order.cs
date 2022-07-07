using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
	public class Order : BaseEntity
	{
		public int BasketId { get; set; }
		public int CustomerId { get; set; }
		public DateTime OrderDate { get; set; }
		public int ProductId { get; set; }
		public decimal UnitPrice { get; set; }
		public int Quantity { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual ICollection<Product> Product { get; set; }
		public virtual ICollection<Basket> Basket { get; set; }
	}
}
