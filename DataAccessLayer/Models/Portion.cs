namespace TimeshEAT.DataAccessLayer.Models
{
	public class Portion
	{
		public Portion() { }
		public Portion(int id, string name)
		{
			Id = id;
			Name = name;
		}

		public int Id { get; set; }
		public string Name { get; set; }
	}
}
