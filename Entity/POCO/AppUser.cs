using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
	public class AppUser : IdentityUser<int>
	{
		public virtual ICollection<Basket> Baskets { get; set; }
		public virtual Customer Customer { get; set; }
	}
}
