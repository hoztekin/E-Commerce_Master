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
	public class EFBasketRepo : EFRepository<Basket, OrganicDbContext> , IBasketDAL
	{
		private readonly OrganicDbContext db;

		public EFBasketRepo(OrganicDbContext db) : base(db)
		{
			this.db = db;
		}

		public async Task<bool> BasketAddOrUpdate(Basket basket)
		{
            bool ok = false;
            var strategy = db.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        var basketDb = db.Baskets.FirstOrDefault(x => x.Active == true && x.Deleted == false
                        && x.AppUserId == basket.AppUserId && x.ProductId == basket.ProductId);
                        if (basketDb == null)
                        {
                            //Add
                            db.Baskets.Add(basket);
                        }
                        else
                        {
                            basketDb.Count += basketDb.Count;
                            db.Baskets.Update(basketDb);
                            //Or
                        }
                        var result = db.SaveChanges();
                        if (result == 0)
                            transaction.Rollback();
                        else
                        {
                            ok = true;
                            transaction.Commit();
                        }
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                    }
                }
            });

            return await Task.FromResult(ok);
        }
	}
}
