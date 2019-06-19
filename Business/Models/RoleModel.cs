using System;
using System.Diagnostics;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Business.Models
{
	public class RoleModel : Entity
	{
		private string _name;

		public RoleModel(string name, int id = 0, long version = 0) : base(id, version)
		{
			Id = id;
			Name = name;
			Version = version;
		}

		public string Name
		{
			get
			{
				Debug.Assert(_name != null);
				return _name;
			}
			set
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentNullException(nameof(Name), "Valid name is mandatory!");
				}

				_name = value;
			}
		}

		#region [Implicit Operators]

		public static implicit operator Role(RoleModel roleModel)
		{
			if (roleModel == null)
			{
				throw new NullReferenceException("Role cannot be null!");
			}

			return new Role(roleModel.Id, roleModel.Name, roleModel.Version);
		}

		public static implicit operator RoleModel(Role dbRole)
		{
			if (dbRole == null)
			{
				throw new NullReferenceException("Role cannot be null!");
			}

			return new RoleModel(dbRole.Name, dbRole.Id, dbRole.Version);
		}

		#endregion
	}
}
