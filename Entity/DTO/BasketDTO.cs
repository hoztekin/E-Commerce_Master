using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Entity.DTO
{
	public class BasketDTO
	{

		public int ProductId { get; set; }
		public int Count { get; set; }
		public string ProductName { get; set; }
		public string ImageUrl { get; set; }
		public decimal Price { get; set; }
		public int Stok { get; set; }
		public List<Product> Products { get; set; }
		public AppUser AppUser { get; set; }
		public int AppUserId { get; set; }

	}
}
