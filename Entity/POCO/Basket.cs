using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
	public class Basket : BaseEntity
	{
		public int AppUserId { get; set; }
		public int ProductId { get; set; }
		public int Count { get; set; }
		public ICollection<Product> Product { get; set; }
		public virtual AppUser AppUser { get; set; }
	}
}
