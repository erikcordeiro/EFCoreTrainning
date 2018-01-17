using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using EFCoreTrainning.DataAccess;
using EFCoreTrainning.Domain;

namespace EFCoreTrainning.WebApi.Controllers
{
	[Produces("application/json")]
	[Route("api/Posts")]
	public class PostsController : Controller
	{
		// GET: api/Posts
		[HttpGet]
		public IEnumerable<Post> Get()
		{
			using (BloggingDataService dataService = new BloggingDataService("access_token"))
			{
				return dataService.Posts.Get().ToArray();
			}
		}

		// GET: api/Posts/5
		[HttpGet("{id}")]
		public Post Get(int id)
		{
			using (BloggingDataService dataService = new BloggingDataService("access_token"))
			{
				return dataService.Posts.Get().FirstOrDefault(x => x.Id == id);
			}
		}
		
		// POST: api/Posts
		[HttpPost]
		public void Post([FromBody]Post value)
		{
			using (BloggingDataService dataService = new BloggingDataService("access_token"))
			{
				dataService.Posts.Add(value);
				dataService.Save();
			}
		}
		
		// PUT: api/Posts/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]Post value)
		{
			using (BloggingDataService dataService = new BloggingDataService("access_token"))
			{
				Post post = dataService.Posts.Get().FirstOrDefault(x => x.Id == id);
				if (post != null)
				{
					post.BlogId = value.BlogId;
					post.Content = value.Content;
					post.Title = value.Title;

					dataService.Save();
				}
			}
		}
		
		// DELETE: api/ApiWithActions/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
			using (BloggingDataService dataService = new BloggingDataService("access_token"))
			{
				Post post = dataService.Posts.Get().FirstOrDefault(x => x.Id == id);
				if (post != null)
				{
					dataService.Posts.Remove(post);
					dataService.Save();
				}
			}
		}
	}
}
