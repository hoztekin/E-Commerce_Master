using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Areas.Admin.Data
{
	public class ProductAdminCreateDTO
	{
		[Required(ErrorMessage = "Zorunlu Alan")]
		public string ProductName { get; set; }

		[Required(ErrorMessage = "Zorunlu Alan")]
		public decimal ListPrice { get; set; }

		[Required(ErrorMessage = "Zorunlu Alan")]
		public int Stock { get; set; }
		public string Description { get; set; }

		[Required(ErrorMessage = "Zorunlu Alan")]
		public IFormFile[] ProductImages { get; set; }

		[Required(ErrorMessage = "Zorunlu Alan")]
		public int[] CategoryId { get; set; }

	}
}
