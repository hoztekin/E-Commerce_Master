using DAL.Abstract;
using DAL.Concrete.EF;
using DAL.Concrete.EF.Database;
using Entity.DTO;
using Entity.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EntityFraneWork
{
	public class EFBasketRepo : EFRepository<Basket, CommerceDbContext> , IBasketDAL
	{
		private readonly CommerceDbContext db;

		public EFBasketRepo(CommerceDbContext db) : base(db)
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

		public async Task<int> CountByUser(object userid)
		{
            var count = db.Baskets.Where(x => x.AppUserId == (int)userid).Count();
            return await Task.FromResult(count);
        }

        public async Task<IEnumerable<BasketDTO>> GetBasketDto(object userId)
        {

            var result = from basket in db.Baskets
                         join product in db.Products on basket.ProductId equals product.Id
                         where product.Active == true
                         && product.Deleted == false && product.StockLevel > 0
                         && basket.Active == true && basket.Deleted == false
                         && basket.AppUserId ==  Convert.ToInt32 (userId)
                         select new BasketDTO
                         {
                             Count = basket.Count,
                             Price = product.ListPrice,
                             ProductId = product.Id,
                             Stok = product.StockLevel,
                             ProductName = product.ProductName,
                             ImageUrl = db.ProductImages.FirstOrDefault(x => x.ProductId == product.Id).ImageUrl
                         };
            return await Task.FromResult(result);
        }
    }
}
