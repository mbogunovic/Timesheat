using System.Collections;
using RestSharp;
using System.Collections.Generic;
using TimeshEAT.Domain.Models;
using TimeshEAT.Business.API.Models;

namespace TimeshEAT.Business.Interfaces
{
    public interface IApiClient
    {
        ApiResponseModel<T> Execute<T>(RestRequest request) where T : new();
        ApiResponseModel<T> ExecuteList<T>(RestRequest request) where T : IEnumerable, new();
    }
}
