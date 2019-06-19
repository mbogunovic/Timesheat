namespace TimeshEAT.Domain.Models
{
	public class Meal : Entity
	{
		public Meal() : base()
		{

		}

		public Meal(int id, string name, int price, int categoryId, byte[] version) : base(id, version)
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
