using EFCoreTrainning.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTrainning.DataAccess
{
	internal interface IBloggingContext
	{
		DbSet<Blog> Blogs { get; set; }
		DbSet<Post> Posts { get; set; }
	}
}