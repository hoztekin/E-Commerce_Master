using DAL.Abstract;
using DAL.Concrete.EF;
using DAL.Concrete.EF.Database;
using Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFraneWork
{
	public class EfBrandRepo : EFRepository<Brand, CommerceDbContext>, IBrandDAL
	{
		public readonly CommerceDbContext db;

		public EfBrandRepo(CommerceDbContext db) : base(db)
		{
			this.db = db;
		}
	}
	
}
