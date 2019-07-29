using RestSharp;
using RestSharp.Extensions;
using System.Collections;
using System.Net;
using System.Text;
using TimeshEAT.Business.API.Models;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
	public partial class ApiClient : IApiClient
	{
		private readonly RestClient _client;
		private string _token;
		private const string MasterToken = "bd612f529c053304a72e9f4e93ab028c";
		public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:sszzz";

		public ApiClient()
		{
			_client = ClientFactory.CreateClient();
		}

		public ApiResponseModel<AuthorizationResponseModel> Authorize(AuthorizationModel model)
		{
			RestRequest request = new RestRequest("/api/authorization/");
			request.AddParameter("Email", model.Email);
			request.AddParameter("PasswordHash", model.PasswordHash);
			request.Method = Method.POST;

			IRestResponse<AuthorizationResponseModel> response = _client.Execute<AuthorizationResponseModel>(request);

			if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrWhiteSpace(response.Data?.Token))
			{
				_token = response.Data.Token;
			}

			return new ApiResponseModel<AuthorizationResponseModel>
			{
				Data = response.Data,
				Status = response.StatusCode
			};
		}

		public void UpdatePassword(int userId, string password)
		{
			RestRequest request = new RestRequest("/api/authorization/update_password");
			request.AddParameter("password", password);
			request.AddParameter("userId", userId);
			request.AddHeader("Authorization", $"Bearer {MasterToken}");

			request.Method = Method.GET;

			_client.Execute(request);
		}

		public void Lockout(string email)
		{
			RestRequest request = new RestRequest("/api/authorization/lockout");
			request.AddParameter("email", email);
			request.Method = Method.GET;
			request.AddHeader("Authorization", $"Bearer {MasterToken}");

			_client.Execute(request);
		}


		public ApiResponseModel<T> Execute<T>(RestRequest request, bool isMasterTokenRequest = false) where T : new()
		{
			request.AddHeader("Authorization", $"Bearer { (isMasterTokenRequest ? MasterToken : _token) }");
			request.OnBeforeDeserialization = resp =>
			{
				int responseStatus = (int)resp.ResponseStatus;
				if (responseStatus == 401)
				{
					//unauthorized
				}

				if (responseStatus >= 500)
				{
					//server error
				}

				if (responseStatus >= 400)
				{
					//client error
					string restException = "{{ \"RestException\" : {0} }}";
					string content = resp.RawBytes.AsString(); //get the response content
					string newJson = string.Format(restException, content);

					resp.Content = null;
					resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
				}
			};

			request.RequestFormat = DataFormat.Json;
			request.DateFormat = DateTimeFormat;

			IRestResponse<T> response = _client.Execute<T>(request);

			if (response.ResponseStatus == ResponseStatus.Error)
			{
				//log the error
			}

			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				//log the error 
			}

			return new ApiResponseModel<T>
			{
				Data = response.Data,
				Status = response.StatusCode
			};
		}

		public ApiResponseModel<T> ExecuteList<T>(RestRequest request, bool isMasterTokenRequest = false) where T : IEnumerable, new()
		{
			if (isMasterTokenRequest)
			{
				request.AddHeader("Authorization", $"Bearer {MasterToken}");
			}
			request.OnBeforeDeserialization = resp =>
			{
				int responseStatus = (int)resp.ResponseStatus;
				if (responseStatus == 401)
				{
					//unauthorized
				}

				if (responseStatus >= 500)
				{
					//server error
				}

				if (responseStatus >= 400)
				{
					//client error
					string restException = "{{ \"RestException\" : {0} }}";
					string content = resp.RawBytes.AsString(); //get the response content
					string newJson = string.Format(restException, content);

					resp.Content = null;
					resp.RawBytes = Encoding.UTF8.GetBytes(newJson.ToString());
				}
			};

			request.RequestFormat = DataFormat.Json;
			request.DateFormat = DateTimeFormat;
			if (!string.IsNullOrWhiteSpace(_token))
			{
				request.AddHeader("Authorization", $"Bearer {_token}");
			}

			IRestResponse<T> response = _client.Execute<T>(request);

			if (response.ResponseStatus == ResponseStatus.Error)
			{
				//log the error
			}

			if (response.StatusCode == HttpStatusCode.Unauthorized)
			{
				//log the error 
			}

			return new ApiResponseModel<T>
			{
				Data = response.Data,
				Status = response.StatusCode
			};
		}

		public void SetToken(string token) =>
			_token = token;
	}
}
