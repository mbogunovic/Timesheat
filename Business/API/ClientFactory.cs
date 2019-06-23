using System;
using System.Reflection;
using RestSharp;
using TimeshEAT.Business.API.Deserializers;
using TimeshEAT.Common;

namespace TimeshEAT.Business.API
{
    public class ClientFactory
    {
        public static RestClient CreateClient()
        {
            var baseUrl = AppSettings.ApiBaseUrl;
            var client = new RestClient(baseUrl);

            client.AddHandler("application/json", () => new RestSharpJsonNetDeserializer());

            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = new AssemblyName(assembly.FullName);
            var version = assemblyName.Version;

            client.Timeout = 1000 * 45;
            client.UserAgent = "timesheat-csharp/" + version + " (.NET " + Environment.Version + ")";

            return client;
        }
    }
}
