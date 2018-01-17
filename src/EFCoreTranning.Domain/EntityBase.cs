namespace EFCoreTrainning.Domain
{
	public class EntityBase
	{
		public int Id { get; set; }
		public byte[] RowVersion { get; set; }
	}
}
