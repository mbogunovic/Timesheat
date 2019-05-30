namespace TimeshEAT.DataAccessLayer.Models
{
	public class User
	{
		public User() { }
		public User(int id, string fullName, string email, string password, bool isActive, int companyId)
		{
			Id = id;
			FullName = fullName;
			Email = email;
			Password = password;
			IsActive = isActive;
			CompanyId = companyId;
		}

		public int Id { get; set; }
		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool IsActive { get; set; }
		public int CompanyId { get; set; }
	}
}
