using System;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using TimeshEAT.Business.API;
using TimeshEAT.Business.Helpers;
using TimeshEAT.Business.Logging.Interfaces;
using TimeshEAT.Business.Models;
using TimeshEAT.Common;

namespace TimeshEAT.Web.Membership
{
	public class MemberPrincipal : IPrincipal
	{
		public MemberPrincipal(IIdentity identity, IApiClient api)
		{
			Identity = identity;
			_api = api ?? throw new ArgumentNullException(nameof(api));
			_api.SetToken(WebCache.Get(string.Format(Constants.MEMBER_CACHE_TOKEN, Identity.Name)));
		}

		private UserModel _user => WebCache.Get(string.Format(Constants.MEMBER_CACHE_FORMAT, Identity.Name));
		private IApiClient _api;

		public IIdentity Identity { get; private set; }
		public int Id => _user.Id;
		public CompanyModel Company => _user.Company;
        public string FullName => _user.FullName;

        public Tuple<bool, string> Login(string email, string password)
		{
			int loginCount = (int?)HttpContext.Current.Session["login_counter"] ?? 0;

			if (loginCount > Constants.MAX_LOGIN_ATTEMPTS)
			{
				WebCache.Set(HttpContext.Current.Request.UserHostAddress, true, 15);
				Lockout(email);
				return new Tuple<bool, string>(false, "Vaš nalog je blokiran zbog previše netačnih unosa kredencijala.");
			}
			else
			{
				Business.API.Models.ApiResponseModel<AuthorizationResponseModel> response = _api.Authorize(new AuthorizationModel() { Email = email, PasswordHash = password });

				HttpContext.Current.Session["login_counter"] = loginCount + 1;

				switch (response.Status)
				{
					case HttpStatusCode.Unauthorized:
						return new Tuple<bool, string>(false, "Uneli ste nepostojaće kredencijale.");
					case HttpStatusCode.Forbidden:
						return new Tuple<bool, string>(false, "Vaš nalog je blokiran.");
					case HttpStatusCode.OK:
						HttpContext.Current.Session["login_counter"] = 0;
						FormsAuthentication.SetAuthCookie(email, true);
						Identity = new GenericIdentity(email);
						WebCache.Set(string.Format(Constants.MEMBER_CACHE_FORMAT, email), response.Data.User, Constants.MEMBER_CACHE_TIME);
						WebCache.Set(string.Format(Constants.MEMBER_CACHE_TOKEN, email), response.Data.Token, Constants.MEMBER_CACHE_TIME);
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

		public bool IsInRole(string role) =>
			_user != null 
				? _user.Roles.Any(x => x.Name.Equals(role))
				: throw new UnauthorizedAccessException("Sesija vam je istekla, molim vas prijavite se opet.");
			


		public bool ResetPassword(string newPassword, string token)
		{
			int? userId = WebCache.Get(token);
			if (!userId.HasValue)
			{
				return false;
			}

			_api.UpdatePassword(userId.Value, newPassword);
			WebCache.Remove(token);

			return true;
		}

		public void ForgotPassword(string email = null)
		{
			Business.API.Models.ApiResponseModel<UserModel> userResponse = _api.GetUserByEmail<UserModel>(email ?? _user.Email);
			if (userResponse.Status.Equals(HttpStatusCode.OK) && userResponse.Data != null)
			{
				EmailSender emailSender = new EmailSender(DependencyResolver.Current.GetService<ILogger>());
				string token = TokenGenerator.GenerateToken();

				WebCache.Set(token, userResponse.Data.Id);
				string resetPasswordLink = $"{HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority)}/Authorization/ResetPassword?token={token}";
				emailSender.Send(!string.IsNullOrWhiteSpace(email) ? email : _user.Email, AppSettings.DefaultEmail, "TimeshEAT - Link za resetovanje lozinke", resetPasswordLink);
			}

		}
	}
}