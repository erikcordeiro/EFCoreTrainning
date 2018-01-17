using EFCoreTrainning.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EFCoreTrainning.DataAccess.Tests
{
	[TestClass]
	public class BloggingDataServiceTest
	{
		[TestMethod]
		public void GenericTest()
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

			using (BloggingDataService dataService = new BloggingDataService("989E81ED-0259-4763-80C9-ED3B91001FF1"))
			{
				using (var transaction = dataService)
				dataService.Blogs.Add(newBlog);
				dataService.Posts.Add(newPost);

				int affectedRows = dataService.Save();

				Assert.AreEqual(2, affectedRows);


			}
		}
	}
}
