namespace TimeshEAT.RepositoryLayer.Models
{
	public class Role : Entity
	{
		public Role() { }
		public Role(int id, string name) : base(id)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}
