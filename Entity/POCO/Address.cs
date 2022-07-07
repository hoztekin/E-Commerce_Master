using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.POCO
{
	public class Address : BaseEntity
	{
        public string Province { get; set; }
        public string District { get; set; }
        public string Detail { get; set; }
        public string PostaCode { get; set; }
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
