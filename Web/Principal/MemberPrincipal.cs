using System;
using System.Security.Principal;
using System.Web.Security;
using TimeshEAT.Business.API;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Web.Membership
{
	public class MemberPrincipal : IPrincipal
	{
		public MemberPrincipal(IIdentity identity, IApiClient api)
		{
			Identity = identity;
			_api = api ?? throw new ArgumentNullException(nameof(api));
		}

		private UserModel _user;
		private IApiClient _api;

		public IIdentity Identity { get; }

		public Tuple<bool, string> Login(string email, string password)
		{
			var response = _api.Authorize(new AuthorizationModel() { Email = email, PasswordHash = password });

			switch (response.Status)
			{
				case System.Net.HttpStatusCode.Unauthorized:
					return new Tuple<bool, string>(false, "Uneli ste nepostojaće kredencijale.");
				case System.Net.HttpStatusCode.Forbidden:
					return new Tuple<bool, string>(false, "Vaš nalog je blokiran.");
				case System.Net.HttpStatusCode.OK:
					_user = response.Data.User;
					FormsAuthentication.SetAuthCookie(_user.Email, true);
					return new Tuple<bool, string>(true, "");
				default:
					return new Tuple<bool, string>(false, response.Status.ToString());
			}
		}

		public void Logout() =>
			FormsAuthentication.SignOut();

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