using System;
using Newtonsoft.Json;
using RestSharp.Deserializers;
using TimeshEAT.Business.API.Converters;

namespace TimeshEAT.Business.API.Deserializers
{
    public class RestSharpJsonNetDeserializer : IDeserializer
    {
        public T Deserialize<T>(RestSharp.IRestResponse response)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.All,
                PreserveReferencesHandling = PreserveReferencesHandling.All
            };

            serializerSettings.Converters.Add(new DateTimeJsonConverter());

            try
            {
                return JsonConvert.DeserializeObject<T>(response.Content, serializerSettings);
            }
            catch (Exception ex)
            {
                //
                throw ex;
            }
        }


        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string RootElement { get; set; }

        /// <summary>
        /// Unused for JSON Serialization
        /// </summary>
        public string Namespace { get; set; }
    }
}
