namespace TimeshEAT.Domain.Interfaces
{
	public interface IEntity
	{
		int Id { get; set; }
		byte[] Version { get; set; }
	}
}