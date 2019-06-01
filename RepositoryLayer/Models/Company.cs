namespace TimeshEAT.RepositoryLayer.Models
{
	public class Company : Entity
	{
		public Company() { }
		public Company(int id, string name, string email, int dailyDiscount) : base(id)
		{
			Name = name;
			Email = email;
			DailyDiscount = dailyDiscount;
		}

		public string Name { get; set; }
		public string Email { get; set;  }
		public int DailyDiscount { get; set; }
	}
}
