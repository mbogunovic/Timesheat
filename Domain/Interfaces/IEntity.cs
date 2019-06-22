namespace TimeshEAT.Domain.Interfaces
{
	public interface IEntity
	{
		int Id { get; set; }
		long Version { get; set; }
	}
}