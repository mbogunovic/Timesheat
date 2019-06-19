using System;

namespace TimeshEAT.Domain.Models
{
	public class User : Entity
	{
		public User(int id, string fullName, string email, string password, bool isActive, int companyId, long version) : base(id, version)
		{
			FullName = fullName;
			Email = email;
			Password = password;
			IsActive = isActive;
			CompanyId = companyId;
		}

		public string FullName { get; set; }
		public string Email { get; set; }
		public string Password { get; set; }
		public bool IsActive { get; set; }
		public int CompanyId { get; set; }
	}
}
