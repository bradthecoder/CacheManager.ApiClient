#region Using Statements
using Shared.HttpUtilities;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CacheManager.ApiClient.Models;
#endregion

namespace CacheManager.ApiClient.Tests.RestClientMocks
{
    public class MockRestClient : IRestClient
    {
        private MockData.CacheObjects _mockData = new MockData.CacheObjects();

        public string ErrorMessage { get; set; }

        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

         public Dictionary<string, string> Headers { get; set; }

        public async Task<HttpResponseMessage> SendAsync(HttpMethod httpMethod, string url, HttpContent content = null)
        {
            HttpResponseMessage toReturn = new HttpResponseMessage();
            toReturn.StatusCode = System.Net.HttpStatusCode.OK;

            if (httpMethod == HttpMethod.Post && url.Contains("/api/getObject"))
            {
                ResponseBase<CacheObject> response = new ResponseBase<CacheObject>()
                {
                    Message = _mockData.ExampleCacheObject()
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            } 
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/getObjectProperty"))
            {
                ResponseBase<object> response = new ResponseBase<object>()
                {
                    Message = _mockData.ExampleCacheObject().Properties["ComplexProperty"]
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/setObject"))
            {
                ResponseBase<string> response = new ResponseBase<string>()
                {
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/setObjectProperty"))
            {
                ResponseBase<string> response = new ResponseBase<string>()
                {
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/refreshObject"))
            {
                ResponseBase<string> response = new ResponseBase<string>()
                {
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/removeObject"))
            {
                ResponseBase<string> response = new ResponseBase<string>()
                {
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/removeObjectProperty"))
            {
                ResponseBase<string> response = new ResponseBase<string>()
                {
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }

            return toReturn;
        }
    }
}
