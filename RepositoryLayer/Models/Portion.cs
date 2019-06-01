namespace TimeshEAT.RepositoryLayer.Models
{
	public class Portion : Entity
	{
		public Portion() { }
		public Portion(int id, string name) : base(id)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}
