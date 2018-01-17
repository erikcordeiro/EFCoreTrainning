using EFCoreTrainning.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace EFCoreTrainning.DataAccess.Repositories
{
	public abstract class RepositoryBase<TEntity> : IRepository<TEntity>
		where TEntity : EntityBase
	{
		private DbSet<TEntity> _dbSet;


		public RepositoryBase(DbSet<TEntity> dbSet)
		{
			_dbSet = dbSet;
		}

		public int Count() => _dbSet.Count();
		public IQueryable<TEntity> Get() => _dbSet.AsQueryable();
		public void Add(TEntity entity) => _dbSet.Add(entity);
		public void Remove(TEntity entity) => _dbSet.Remove(entity);
	}
}
