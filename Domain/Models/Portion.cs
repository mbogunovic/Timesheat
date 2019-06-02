namespace TimeshEAT.Domain.Models
{
	public class Portion : Entity
	{
		public Portion(int id, string name, byte[] version) : base(id, version)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}
