using EFCoreTrainning.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTrainning.DataAccess
{
	internal class BloggingContext : DbContext 
	{
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<Post> Posts { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=EFCoreTest;Trusted_Connection=True;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Post
			modelBuilder.Entity<Post>()
				.HasKey(x => x.Id);

			modelBuilder.Entity<Post>()
				.Property(x => x.Id)
				.HasColumnName("PostId")
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<Post>()
				.Property(x => x.Title)
				.IsRequired();

			modelBuilder.Entity<Post>()
				.Property(x => x.Content)
				.IsRequired();

			modelBuilder.Entity<Post>()
				.Property(x => x.BlogId)
				.IsRequired();

			modelBuilder.Entity<Post>()
				.Property(x => x.RowVersion)
				.IsRowVersion();

			modelBuilder.Entity<Post>()
				.HasOne(x => x.Blog)
				.WithMany(x => x.Posts)
				.HasForeignKey(x => x.BlogId);

			// Blog
			modelBuilder.Entity<Blog>()
				.HasKey(x => x.Id);

			modelBuilder.Entity<Blog>()
				.Property(x => x.Id)
				.HasColumnName("BlogId")
				.ValueGeneratedOnAdd();

			modelBuilder.Entity<Blog>()
				.Property(x => x.Rating)
				.IsRequired();

			modelBuilder.Entity<Blog>()
				.Property(x => x.Url)
				.IsRequired();

			modelBuilder.Entity<Blog>()
				.Property(x => x.RowVersion)
				.IsRowVersion();
		}
	}
}
