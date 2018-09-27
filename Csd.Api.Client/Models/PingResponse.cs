using System.Net;

namespace Csd.Api.Client.Models
{
    public class PingResponse
    {
        public string Text { get; set; }
        public HttpStatusCode status { get; set; }
        public string message { get; set; }
    }
}
