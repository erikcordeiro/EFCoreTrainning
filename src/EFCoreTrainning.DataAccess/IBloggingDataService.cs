using EFCoreTrainning.DataAccess.Repositories;
using EFCoreTrainning.Domain;

namespace EFCoreTrainning.DataAccess
{
	public interface IBloggingDataService
	{
		string AccessToken { get; }
		IRepository<Blog> Blogs { get; }
		IRepository<Post> Posts { get; }

		void Dispose();
		int Save();
	}
}