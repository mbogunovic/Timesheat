namespace TimeshEAT.DataAccessLayer.Models
{
	public class Company
	{
		public Company() { }
		public Company(int id, string name, string email, int dailyDiscount)
		{
			Id = id;
			Name = name;
			Email = email;
			DailyDiscount = dailyDiscount;
		}

		public int Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set;  }
		public int DailyDiscount { get; set; }
	}
}
