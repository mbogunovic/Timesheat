using System;
using System.Security.Principal;
using System.Web.Security;
using TimeshEAT.Business.API;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Web.Membership
{
	public class MemberPrincipal : IPrincipal
	{
		public MemberPrincipal(IIdentity identity)
		{
			_identity = identity;
			_api = new ApiClient();
		}

		private readonly IIdentity _identity;
		private UserModel _user;
		private ApiClient _api;

		public enum LoginStatus
		{
			Successfull,
			Unsuccessfull,
			LockedOut
		}

		public IIdentity Identity => _identity;

		public LoginStatus Login(string email, string password)
		{
			//TODO: ADD OTHER LOGIN STATUSES ONCE YOU GET API
			var loginStatus = LoginApi(email, password);
			switch (loginStatus)
			{
				case LoginStatus.Successfull:
					FormsAuthentication.SetAuthCookie(_user.Email, true);
					break;
				case LoginStatus.Unsuccessfull:
					break;
				case LoginStatus.LockedOut:
					break;
			}

			return loginStatus;
		}

		public void Logout() =>
			FormsAuthentication.SignOut();

		private LoginStatus LoginApi(string email, string password)
		{
			var model = _api.Authorize(new AuthorizationModel() { Email = email, PasswordHash = password });
			if(model != null)
			{ 
				_user = model.User;
				return LoginStatus.Successfull;
			}

			return LoginStatus.Unsuccessfull;
		}

		public bool IsInRole(string role)
		{
			//TODO: ADD ROLES CHECK
			return true;
		}

		public void ResetPassword(string email)
		{
			throw new NotImplementedException();
		}
	}
}