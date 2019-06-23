using System;
using System.Diagnostics;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Business.Models
{
	public class UserModel : Entity
	{
		private string _fullName;
		private string _email;
		private string _password;
		private int _companyId;

        public UserModel()
        {
            
        }

		public UserModel(string fullName, string email, string password, bool isActive, int companyId, int id = 0, long version = 0) : base(id, version)
		{
			Id = id;
			FullName = fullName;
			Email = email;
			Password = password;
			IsActive = isActive;
			CompanyId = companyId;
			Version = version;
		}

		public string FullName
		{
			get
			{
				Debug.Assert(_fullName != null);
				return _fullName;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException(nameof(FullName), "Valid full name is mandatory!");
				}

				_fullName = value;
			}
		}
		public string Email
		{
			get
			{
				Debug.Assert(_email != null);
				return _email;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException(nameof(Email), "Valid email is mandatory!");
				}

				_email = value;
			}
		}
		public string Password
		{
			get
			{
				Debug.Assert(_password != null);
				return _password;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException(nameof(Password), "Valid password is mandatory!");
				}

				_password = value;
			}
		}
		public bool IsActive { get; set; }
		public int CompanyId
		{
			get
			{
				Debug.Assert(_companyId > 0);

				return _companyId;
			}
			set
			{
				if (0 > value)
				{
					throw new ArgumentNullException(nameof(CompanyId), "Valid company id is mandatory!");
				}

				_companyId = value;
			}
		}

		#region [Implicit Operators]

		public static implicit operator User(UserModel userModel)
		{
			if (userModel == null)
			{
				throw new NullReferenceException("User cannot be null!");
			}

			return new User(userModel.Id, userModel.FullName, userModel.Email,
				userModel.Password, userModel.IsActive, userModel.CompanyId, userModel.Version);
		}

		public static implicit operator UserModel(User dbUser)
		{
			if (dbUser == null)
			{
				throw new NullReferenceException("User cannot be null!");
			}

			return new UserModel(dbUser.FullName, dbUser.Email, dbUser.Password, dbUser.IsActive, dbUser.CompanyId, dbUser.Id, dbUser.Version);
		}

		#endregion
	}
}
