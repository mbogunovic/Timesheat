namespace TimeshEAT.Domain.Models
{
	public class Role : Entity
	{
		public Role(int id, string name, byte[] version) : base(id, version)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}
