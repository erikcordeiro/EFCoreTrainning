using EFCoreTrainning.DataAccess.Repositories;
using EFCoreTrainning.Domain;
using System;

namespace EFCoreTrainning.DataAccess
{
	public class BloggingDataService : IDisposable, IBloggingDataService
	{
		private readonly IBloggingContext _dbContext;

		public string AccessToken { get; private set; }

		public IRepository<Post> Posts { get; private set; }
		public IRepository<Blog> Blogs { get; private set; }


		internal BloggingDataService()
			: this(new BloggingContext())
		{ }

		internal BloggingDataService(IBloggingContext context)
		{
			_dbContext = context;

			Posts = new PostRepository(_dbContext.Posts);
			Blogs = new BlogRepository(_dbContext.Blogs);
		}

		public BloggingDataService(string accessToken)
			: this()
		{
			AccessToken = accessToken;
		}


		public int Save() => ((BloggingContext)_dbContext).SaveChanges();

		public void Dispose()
		{
			((IDisposable)_dbContext).Dispose();
		}
	}
}
