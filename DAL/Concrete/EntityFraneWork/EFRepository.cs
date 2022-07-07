using Core.DAL.Repository;
using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EF
{
	public class EFRepository<TEntity, TDbContext> : IGenericRepository<TEntity>
		where TEntity : class, IBaseEntity, new()
		where TDbContext : DbContext
	{
		private readonly DbContext db;

		public EFRepository(DbContext db)
		{
			this.db = db;
		}

		public async Task<bool> Delete(TEntity Entity)
		{
			db.Remove(Entity);
			var result = await db.SaveChangesAsync();
			return result > 0 ? true : false;
		}

		public async Task<bool> Delete(object Id)
		{
			var Entity = db.Set<TEntity>().FindAsync(Id);
			Entity.GetType().GetProperty("Active").SetValue(Entity, false);
			Entity.GetType().GetProperty("Deleted").SetValue(Entity, true);
			db.Update(Entity);
			var Result = await db.SaveChangesAsync();
			return Result > 0 ? true : false;
		}

		public async Task<TEntity> Get(object Id)
		{
			throw new NotImplementedException();
		}

		public async Task<IEnumerable<TEntity>> GetList()
		{
			var result = db.Set<TEntity>().AsNoTracking();
			return await Task.FromResult(result);
		}

		public async Task<IEnumerable<TEntity>> GetList(Expression<Func<TEntity, bool>> func = null, params string[] include)
		{
			IQueryable<TEntity> result =
				func == null ? db.Set<TEntity>() : db.Set<TEntity>().Where(func);//Sorgu Hazırlanıyor
			if (include.Length == 0)
			{
				//var aa = result.ToQueryString();
				return await Task.FromResult(result.AsNoTracking());
			}
			else
			{
				foreach (var item in include)
					result = result.Include(item);
				var aa = result.ToQueryString();
				return await Task.FromResult(result.AsNoTracking());
			}
		}

		public async Task<IEnumerable<TEntity>> GetList(int skip, int take, Expression<Func<TEntity, bool>> func = null, params string[] include)
		{
			IQueryable<TEntity> result =
				func == null ? db.Set<TEntity>() : db.Set<TEntity>().Where(func);//Sorgu Hazırlanıyor
			if (include.Length == 0)
			{
				return await Task.FromResult(result.Skip(skip).Take(take).AsNoTracking());
			}
			else
			{
				foreach (var item in include)
					result = result.Include(item);
				return await Task.FromResult(result.Skip(skip).Take(take).AsNoTracking());
			}
		}

		public async Task<TEntity> Insert(TEntity Entity)
		{
			db.Entry(Entity).State = EntityState.Added;
			//db.Add(entity);
			await db.SaveChangesAsync();
			return Entity;
		}

		public async Task<TEntity> Update(TEntity Entity)
		{
			db.Entry(Entity).State = EntityState.Modified;
			//db.Update(entity);
			await db.SaveChangesAsync();
			return Entity;
		}
	}
}
