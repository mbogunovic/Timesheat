using System;
using System.Collections.Generic;
using System.Linq;
using TimeshEAT.Business.Interfaces;
using TimeshEAT.Business.Models;
using TimeshEAT.Domain.Interfaces;
using TimeshEAT.Domain.Interfaces.Repositories;
using TimeshEAT.Domain.Models;
using TimeshEAT.Repository.Repositories;

namespace TimeshEAT.Business.Services
{
	public class UserService : BaseService, IUserService
	{
		public UserService(IRepositoryContext context) : base(context) { }

		public UserModel GetBy(string email) =>
			Get().FirstOrDefault(x => x.Email.Equals(email));

		public IEnumerable<UserModel> Get()
		{
			List<UserModel> result = _context.UserRepository.GetAll()
				.Select(x => (UserModel)x)
				.ToList();
			var companyService = new CompanyService(_context);

			for (int i=0; i < result.Count(); i++)
			{
				result[i].Roles = _context.RoleRepository.GetAllByUserId(result[i].Id)
					.Select(x => (RoleModel)x)
					.ToList();
				result[i].Company = companyService.GetBy(result[i].CompanyId);
			}

			return result.ToList();
		}

		public UserModel GetBy(int id)
		{
			if (id <= 0)
			{
				throw new ArgumentNullException(nameof(id), "Id cannot be null!");
			}

			UserModel result = _context.UserRepository.GetById(id);

			//TODO: add companies models
			result.Roles = _context.RoleRepository.GetAllByUserId(result.Id)
					.Select(x => (RoleModel)x);

			return result;
		}

		public UserModel Add(UserModel user)
		{
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user), "User cannot be null!");
			}

			ITransaction transaction = _context.UserRepository.CreateNewTransaction();
			User result = null;

			try
			{
				transaction.Begin();

				result = _context.UserRepository.Insert(user, transaction);
				var userRole = _context.RoleRepository.GetAll(transaction).ToList().FirstOrDefault(x => x.Name.Equals("User"));
				_context.RoleRepository.InsertUserRole(result.Id, userRole.Id, transaction);

				transaction.Commit();
			}
			catch (Exception ex)
			{
				//TODO: some error handling maybe
				transaction.Rollback();
			}
			
			return result;
		}

		public UserModel Save(UserModel user)
		{
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user), "User cannot be null!");
			}

			Domain.Models.User result = _context.UserRepository.Update(user);

			//TODO: add roles and companies models

			return result;
		}

		public void Remove(UserModel user)
		{
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user), "User cannot be null!");
			}

			_context.UserRepository.Delete(user);
		}

		public LoginResultModel Login(string email, string passwordHash)
		{
			LoginResultModel model = new LoginResultModel();
			UserModel user = Get().FirstOrDefault(u => u.Email.Equals(email));
			if (user == null || !user.Password.Equals(passwordHash, StringComparison.OrdinalIgnoreCase))
			{
				model.IsAuthenticated = false;
				model.IsActive = true;
				return model;
			}

			if (!user.IsActive)
			{
				model.IsAuthenticated = false;
				model.IsActive = false;
				return model;
			}

			model.IsAuthenticated = true;
			model.IsActive = true;
			model.User = user;
			return model;
		}

		public void Lockout(string email)
		{
			Domain.Models.User user = _context.UserRepository.GetAll().FirstOrDefault(u => u.Email.Equals(email));

			if (user != null)
			{
				user.IsActive = false;
				_context.UserRepository.Update(user);
			}
		}

		public void UpdatePassword(int userId, string password)
		{
			Domain.Models.User user = _context.UserRepository.GetById(userId);

			user.Password = password;

			_context.UserRepository.Update(user);
		}
	}
}
