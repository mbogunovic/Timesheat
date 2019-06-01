namespace TimeshEAT.DataAccessLayer.Models
{
	public class Category
	{
		public Category() { }
		public Category(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
	}
}
