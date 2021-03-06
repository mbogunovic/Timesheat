﻿using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.Interfaces
{
	public interface IUserService : IService<UserModel>
    {
        LoginResultModel Login(string email, string passwordHash);
		void Lockout(string email);
		void UpdatePassword(int userId, string password);
		UserModel GetBy(string email);
	}
}
