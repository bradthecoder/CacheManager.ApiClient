#region Using Statements
using Shared.HttpUtilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
#endregion

namespace CacheManager.ApiClient.Tests.RestClientMocks
{
    public class ExceptionRestClient : IRestClient
    {
        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

         public Dictionary<string, string> Headers { get; set; }

        public Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string url, HttpContent content = null)
        {
            throw new NotImplementedException();
        }
    }
}
