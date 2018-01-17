using System.Collections.Generic;

namespace EFCoreTrainning.Domain
{
	public class Blog : EntityBase
	{
		public string Url { get; set; }
		public int Rating { get; set; }

		public virtual List<Post> Posts { get; set; }

		public Blog()
		{
			Posts = new List<Post>();
		}
	}
}
