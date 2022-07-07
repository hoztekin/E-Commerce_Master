using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DTO
{
	public class ProductCreateDTO
	{
		public string ProductName { get; set; }
		public decimal ListPrice { get; set; }
		public int StokLevel { get; set; }
		public string Description { get; set; }
		public List<string> ImageUrl { get; set; }
		public int CategoryId { get; set; }
	}
}
