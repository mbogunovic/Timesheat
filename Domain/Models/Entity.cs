using TimeshEAT.Domain.Interfaces;

namespace TimeshEAT.Domain.Models
{
	public class Entity : IEntity
	{
		public Entity()
		{
			
		}
		public Entity(int id, byte[] version)
		{
			Id = id;
			Version = version;
		}

		public int Id { get; set; }
		public byte[] Version { get; set; }
	}
}
