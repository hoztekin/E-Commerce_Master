using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
	public class ProductDTO
	{
        public int ProductId { get; set; }
		public string ProductName { get; set; }
        public int BrandId { get; set; }
		public string BrandName { get; set; }
		public decimal ListPrice { get; set; }
        public int StockLevel { get; set; }
        public string Description { get; set; }
        public string Imageurl { get; set; }
        public string CatagoryName { get; set; }
        public int CategoryId { get; set; }

    }
}
