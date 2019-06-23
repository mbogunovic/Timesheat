using System.Net;

namespace TimeshEAT.Business.API.Models
{
    public class ApiResponseModel<T> where T : new()
    {
        public T Data { get; set; }
        public HttpStatusCode Status { get; set; }
    }
}
