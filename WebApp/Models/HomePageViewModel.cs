using Entity.POCO;
using System;
using System.Collections.Generic;

namespace WebApp.Models
{
	public class HomePageViewModel
	{
		public List<Category> Categories { get; set; }
		public List<Brand> Brands { get; set; }
		public List<Product> Products { get; set; }
		public List<ProductImage> ProductImages { get; set; }

	}
}
