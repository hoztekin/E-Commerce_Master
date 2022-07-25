using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
	public class Product : BaseEntity
	{
		public string ProductName { get; set; }
		public string CategoryName { get; set; }
		public string BrandName { get; set; }
		public DateTime SalesStartDate { get; set; }
		public DateTime SalesEndDate { get; set; }
		public int StockLevel { get; set; }
		public decimal StandartCost { get; set; }
		public decimal ListPrice { get; set; }
		public string ProductNumber { get; set; }
		public string Description { get; set; }
		public virtual Basket Basket { get; set; }
		public virtual Order Order { get; set; }
		public virtual ICollection<ProductSupplier> ProductSupplier { get; set; }
		public virtual ICollection<ProductImage> ProductImage { get; set; }
		public virtual ICollection<ProductCategory> ProductCategory { get; set; }
		public virtual ICollection<ProductBrand> ProductBrand { get; set; }
	}
}
