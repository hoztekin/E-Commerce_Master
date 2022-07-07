using DAL.Abstract;
using DAL.Concrete.EF;
using DAL.Concrete.EF.Database;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFraneWork
{
	public class EFCategoryRepo : EFRepository<Category, OrganicDbContext>, ICategoryDAL
	{
		public readonly OrganicDbContext db;

		public EFCategoryRepo(OrganicDbContext db) : base(db)
		{
			this.db = db;
		}
	}
}
