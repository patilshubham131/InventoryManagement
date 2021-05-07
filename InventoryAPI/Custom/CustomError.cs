using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace InventoryAPI.Custom
{
    public class CustomError : IHttpActionResult
    {
        private readonly string _erorrMessage;
        private readonly HttpRequestMessage _requestMessage;
        private readonly HttpStatusCode _statusCode;

        public CustomError(string erorrMessage, HttpRequestMessage requestMessage, HttpStatusCode statusCode)
        {
            _erorrMessage = erorrMessage;
            _requestMessage = requestMessage;
            _statusCode = statusCode;
        }
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(_requestMessage.CreateErrorResponse(_statusCode,_erorrMessage));
        }
    }
}