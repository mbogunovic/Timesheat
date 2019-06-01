namespace TimeshEAT.RepositoryLayer.Models
{
	public class Meal : Entity
	{
		public Meal() { }
		public Meal(int id, string name, int price, int categoryId) : base(id)
		{
			Name = name;
			Price = price;
			CategoryId = categoryId;
		}

		public string Name { get; set; }
		public int Price { get; set;  }
		public int CategoryId { get; set; }
	}
}
