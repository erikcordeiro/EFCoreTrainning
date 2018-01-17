using EFCoreTrainning.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTrainning.DataAccess.Repositories
{
	public class PostRepository : RepositoryBase<Post>
	{
		public PostRepository(DbSet<Post> dbSet)
			: base(dbSet)
		{ }
	}
}
