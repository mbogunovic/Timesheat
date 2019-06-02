﻿using System.Collections.Generic;
using System.Linq;
using TimeshEAT.DataAccess.SQLAccess.Providers;
using TimeshEAT.Domain.Interfaces;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Repository.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly IUserRepository _provider = new UserProvider();

		public IEnumerable<User> GetAll(ITransaction transaction = null) => 
			_provider.GetAll(transaction).ToList();

		public User GetById(int id, ITransaction transaction = null) =>
			_provider.GetById(id, transaction);

		public User Insert(User template, ITransaction transaction = null) =>
			_provider.Insert(template, transaction);

		public User Update(User template, ITransaction transaction = null) =>
			_provider.Update(template, transaction);

		public void Delete(User template, ITransaction transaction = null) =>
			_provider.Delete(template, transaction);

		public ITransaction CreateNewTransaction() =>
			_provider.CreateNewTransaction();
	}
}
