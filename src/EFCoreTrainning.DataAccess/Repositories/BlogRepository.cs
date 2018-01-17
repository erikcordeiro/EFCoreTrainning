using EFCoreTrainning.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTrainning.DataAccess.Repositories
{
	public class BlogRepository : RepositoryBase<Blog>
	{
		public BlogRepository(DbSet<Blog> dbSet)
			: base(dbSet)
		{ }
	}
}
