using System.Linq;

namespace EFCoreTrainning.DataAccess.Repositories
{
	public interface IRepository<TEntity>
	{
		int Count();
		IQueryable<TEntity> Get();
		void Add(TEntity entity);
		void Remove(TEntity entity);
	}
}
