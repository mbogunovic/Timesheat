namespace TimeshEAT.Domain.Models
{
	public class Company : Entity
	{
		public Company(int id, string name, string email, int dailyDiscount, byte[] version) : base(id, version)
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
