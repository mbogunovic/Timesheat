namespace TimeshEAT.DataAccessLayer.Models
{
	public class Meal
	{
		public Meal() { }
		public Meal(int id, string name, int price, int categoryId)
		{
			Id = id;
			Name = name;
			Price = price;
			CategoryId = categoryId;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public int Price { get; set;  }
		public int CategoryId { get; set; }
	}
}
