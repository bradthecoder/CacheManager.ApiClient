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
    public class ErrorRestClient : IRestClient
    {

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
                   Error = new ResponseBase<CacheObject>.ErrorData() { Message = "error"}
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/getObjectProperty"))
            {
                ResponseBase<object> response = new ResponseBase<object>()
                {
                    Error = new ResponseBase<object>.ErrorData() { Message = "error" }
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/setObject"))
            {
                ResponseBase<string> response = new ResponseBase<string>()
                {
                    Error = new ResponseBase<string>.ErrorData() { Message = "error" }
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/setObjectProperty"))
            {
                ResponseBase<string> response = new ResponseBase<string>()
                {
                    Error = new ResponseBase<string>.ErrorData() { Message = "error" }
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/refreshObject"))
            {
                ResponseBase<string> response = new ResponseBase<string>()
                {
                    Error = new ResponseBase<string>.ErrorData() { Message = "error" }
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/removeObject"))
            {
                ResponseBase<string> response = new ResponseBase<string>()
                {
                    Error = new ResponseBase<string>.ErrorData() { Message = "error" }
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }
            else if (httpMethod == HttpMethod.Post && url.Contains("/api/removeObjectProperty"))
            {
                ResponseBase<string> response = new ResponseBase<string>()
                {
                    Error = new ResponseBase<string>.ErrorData() { Message = "error" }
                };
                toReturn.Content = JsonHelper.SerializeContent(response);
            }

            return toReturn;
        }
    }
}
