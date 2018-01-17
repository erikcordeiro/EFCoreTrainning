using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreTrainning.Domain
{
	public class EntityBase
	{
		public int Id { get; set; }
		public byte[] RowVersion { get; set; }
	}
}
