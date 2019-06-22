namespace TimeshEAT.Domain.Models
{
	public class Category : Entity
	{
        public Category()
        {
            
        }

		public Category(int id, string name, long version) : base(id, version)
		{
			Name = name;
		}

		public string Name { get; set; }
	}
}
