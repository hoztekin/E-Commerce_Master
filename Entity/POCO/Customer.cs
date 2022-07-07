using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
	public class Customer : BaseEntity
	{
		public string Name { get; set; }
		public string Lastname { get; set; }
		public string IdentityNumber { get; set; }
		public string PhoneNumber { get; set; }
		public string EMail { get; set; }
		public DateTime BirthDate { get; set; }
		public virtual ICollection<Address> Address { get; set; }
		public virtual int? AppUserId { get; set; }
		public virtual AppUser AppUser { get; set; }
		public virtual ICollection<Order> Order { get; set; }
		public virtual ICollection<Basket> Basket { get; set; }
	}
}
