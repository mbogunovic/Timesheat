namespace TimeshEAT.Domain.Models
{
	public class Role : Entity
	{
        public Role()
        {
            
        }

		public Role(int id, string name, long version) : base(id, version)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}
