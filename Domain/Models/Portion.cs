namespace TimeshEAT.Domain.Models
{
	public class Portion : Entity
	{
		public Portion(int id, string name, long version) : base(id, version)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}
