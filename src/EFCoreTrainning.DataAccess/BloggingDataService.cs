using EFCoreTrainning.DataAccess.Repositories;
using System;

namespace EFCoreTrainning.DataAccess
{
	public class BloggingDataService : IDisposable
	{
		private BloggingContext _dbContext;

		public string AccessToken { get; private set; }

		public PostRepository Posts { get; private set; }
		public BlogRepository Blogs { get; private set; }


		internal BloggingDataService()
		{
			_dbContext = new BloggingContext();

			Posts = new PostRepository(_dbContext.Posts);
			Blogs = new BlogRepository(_dbContext.Blogs);
		}

		public BloggingDataService(string accessToken)
			: this()
		{
			AccessToken = accessToken;
		}


		public int Save() => _dbContext.SaveChanges();

		public void Dispose()
		{
			_dbContext.Dispose();
		}
	}
}
