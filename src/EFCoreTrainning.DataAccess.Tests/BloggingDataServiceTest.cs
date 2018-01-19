using EFCoreTrainning.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace EFCoreTrainning.DataAccess.Tests
{
	[TestClass]
	public class BloggingDataServiceTest
	{
		private readonly IBloggingDataService _dataService;


		public BloggingDataServiceTest()
		{
			var blogCollection = new List<Blog>
			{
				new Blog() { Url = "http://blog1.com", Rating = 5 },
				new Blog() { Url = "http://blog2.com", Rating = 10 }
			};

			var postCollection = new List<Post>
			{
				new Post { Title = "Post #1", Content = "Content of post #1", BlogId = 1, Blog = blogCollection.ElementAt(0) },
				new Post { Title = "Post #2", Content = "Content of post #2", BlogId = 1, Blog = blogCollection.ElementAt(0) },
				new Post { Title = "Post #3", Content = "Content of post #3", BlogId = 1, Blog = blogCollection.ElementAt(0) },
				new Post { Title = "Post #4", Content = "Content of post #4", BlogId = 2, Blog = blogCollection.ElementAt(1) },
				new Post { Title = "Post #5", Content = "Content of post #5", BlogId = 2, Blog = blogCollection.ElementAt(1) }
			};


			var builder = new DbContextOptionsBuilder<BloggingContext>()
				.UseInMemoryDatabase("BlogginDB");

			var context = new BloggingContext(builder.Options);

			context.Blogs.AddRange(blogCollection);
			context.Posts.AddRange(postCollection);
			context.SaveChanges();
			
			_dataService = new BloggingDataService(context);
		}

		[TestMethod]
		public void AddingTest()
		{
			Post newPost = new Post()
			{
				Content = "Content of the post",
				Title = "The Post's Title"
			};

			Blog newBlog = new Blog()
			{
				Rating = 0,
				Url = "http://blogurl.com"
			};

			newBlog.Posts.Add(newPost);

			_dataService.Blogs.Add(newBlog);
			_dataService.Posts.Add(newPost);

			int affectedRows = _dataService.Save();

			Assert.AreEqual(2, affectedRows);
		}

		[TestMethod]
		public void GenericTest()
		{
			var blogCount = _dataService.Blogs.Count();
			Assert.AreEqual(2, blogCount);

			var postCount = _dataService.Posts.Count();
			Assert.AreEqual(5, postCount);

			var blog = _dataService.Blogs.Get().FirstOrDefault(x => x.Id == 1);
			Assert.IsNotNull(blog);
			Assert.AreEqual("http://blog1.com", blog.Url);


			var post = _dataService.Posts.Get().FirstOrDefault(x => x.Id == 1);
			Assert.IsNotNull(post);
			Assert.AreEqual("Post #1", post.Title);

			Post newPost = new Post()
			{
				Content = "Content of the post",
				Title = "The Post's Title"
			};

			Blog newBlog = new Blog()
			{
				Rating = 0,
				Url = "http://blogurl.com"
			};

			newBlog.Posts.Add(newPost);

			_dataService.Blogs.Add(newBlog);
			_dataService.Posts.Add(newPost);
			
			int affectedRows = _dataService.Save();

			Assert.AreEqual(2, affectedRows);
		}

		[TestCleanup]
		public void Cleanup()
		{
			_dataService?.Dispose();
		}
	}
}
