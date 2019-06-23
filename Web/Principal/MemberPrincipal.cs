using System;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
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
			var loginCount = (int?)HttpContext.Current.Session["login_counter"] ?? 0;
			
			if(loginCount > Constants.MAX_LOGIN_ATTEMPTS)
			{
				WebCache.Set(HttpContext.Current.Request.UserHostAddress, true, 15);
				Lockout(email);
				return new Tuple<bool, string>(false, "Vaš nalog je blokiran zbog previše netačnih unosa kredencijala.");
			}
			else
			{
				var response = _api.Authorize(new AuthorizationModel() { Email = email, PasswordHash = password });

				HttpContext.Current.Session["login_counter"] = loginCount + 1;

				switch (response.Status)
				{
					case System.Net.HttpStatusCode.Unauthorized:
						return new Tuple<bool, string>(false, "Uneli ste nepostojaće kredencijale.");
					case System.Net.HttpStatusCode.Forbidden:
						return new Tuple<bool, string>(false, "Vaš nalog je blokiran.");
					case System.Net.HttpStatusCode.OK:
						HttpContext.Current.Session["login_counter"] = 0;
						_user = response.Data.User;
						FormsAuthentication.SetAuthCookie(_user.Email, true);
						return new Tuple<bool, string>(true, "");
					default:
						return new Tuple<bool, string>(false, response.Status.ToString());
				}
			}			
		}

		public void Lockout(string email = null)
		{
			email = !string.IsNullOrWhiteSpace(email) ? email : _user.Email;
			_api.Lockout(email);
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