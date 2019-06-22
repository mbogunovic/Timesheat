using RestSharp;
using System.Collections.Generic;
using TimeshEAT.Domain.Models;

namespace TimeshEAT.Business.Interfaces
{
    public interface IApiClient
    {
        T Execute<T>(RestRequest request) where T : Entity, new();
        T ExecuteList<T>(RestRequest request) where T : IEnumerable<Entity>, new();
    }
}
