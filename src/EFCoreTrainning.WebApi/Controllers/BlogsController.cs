using System.Collections.Generic;
using System.Linq;
using EFCoreTrainning.DataAccess;
using EFCoreTrainning.Domain;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreTrainning.WebApi.Controllers
{
	[Produces("application/json")]
	[Route("api/Blogs")]
	public class BlogsController : Controller
	{
		// GET: api/Blogs
		[HttpGet]
		public IEnumerable<Blog> Get()
		{
			using (BloggingDataService dataService = new BloggingDataService("access_token"))
			{
				return dataService.Blogs.Get().ToArray();
			}
		}

		// GET: api/Blogs/5
		[HttpGet("{id}")]
		public Blog Get(int id)
		{
			using (BloggingDataService dataService = new BloggingDataService("access_token"))
			{
				return dataService.Blogs.Get().FirstOrDefault(x => x.Id == id);
			}
		}

		// POST: api/Blogs
		[HttpPost]
		public void Post([FromBody]Blog value)
		{
			using (BloggingDataService dataService = new BloggingDataService("access_token"))
			{
				dataService.Blogs.Add(value);
				dataService.Save();
			}
		}

		// PUT: api/Blogs/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody]Blog value)
		{
			using (BloggingDataService dataService = new BloggingDataService("access_token"))
			{
				Blog blog = dataService.Blogs.Get().FirstOrDefault(x => x.Id == id);
				if (blog != null)
				{
					blog.Rating = value.Rating;
					blog.Url = value.Url;

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
				Blog blog = dataService.Blogs.Get().FirstOrDefault(x => x.Id == id);
				if (blog != null)
				{
					dataService.Blogs.Remove(blog);
					dataService.Save();
				}
			}
		}
	}
}