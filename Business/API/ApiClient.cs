using System.Collections;
using System.Net;
using System.Text;
using RestSharp;
using RestSharp.Extensions;
using TimeshEAT.Business.API.Models;
using TimeshEAT.Business.Models;

namespace TimeshEAT.Business.API
{
    public partial class ApiClient : IApiClient
    {
        private readonly RestClient _client;
        private string _token;
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

            var response = _client.Execute<AuthorizationResponseModel>(request);

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

        public ApiResponseModel<T> Execute<T>(RestRequest request) where T : new()
        {
            request.OnBeforeDeserialization = resp =>
            {
                int responseStatus = (int) resp.ResponseStatus;
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
                    var restException = "{{ \"RestException\" : {0} }}";
                    var content = resp.RawBytes.AsString(); //get the response content
                    var newJson = string.Format(restException, content);

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

            var response = _client.Execute<T>(request);

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

        public ApiResponseModel<T> ExecuteList<T>(RestRequest request) where T : IEnumerable, new()
        {
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
                    var restException = "{{ \"RestException\" : {0} }}";
                    var content = resp.RawBytes.AsString(); //get the response content
                    var newJson = string.Format(restException, content);

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

            var response = _client.Execute<T>(request);

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
    }
}
