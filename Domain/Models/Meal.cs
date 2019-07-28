namespace TimeshEAT.Domain.Models
{
	public class Meal : Entity
	{
		public Meal()
		{

		}

		public Meal(int id, string name, int categoryId, long version) : base(id, version)
		{
			Name = name;
			CategoryId = categoryId;
		}

		public string Name { get; set; }
		public int CategoryId { get; set; }
	}
}
