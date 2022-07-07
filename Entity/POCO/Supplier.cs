using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
	public class Supplier : BaseEntity
	{
		public string CompanyName { get; set; }
		public string Location { get; set; }
		public string ProductNumber { get; set; }
		public string Adress { get; set; }
		public virtual ICollection<ProductSupplier> ProductSupplier { get; set; }
	}
}
