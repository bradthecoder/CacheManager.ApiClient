#region Using Statements
using CacheManager.ApiClient.Models;
using Microsoft.Extensions.Configuration;
using Shared.HttpUtilities;
using System;
using System.Net.Http;
using System.Threading.Tasks;
#endregion

namespace CacheManager.ApiClient.Services
{
    public abstract class ServiceBase
    {
        protected const string BaseUrlConfigPath = "EndPointURL:CacheManagerApi:BaseUrl";

        protected IConfiguration Configuration;

        protected IRestClient _client;

        public string ErrorMessage { get; set; }
        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

        private string _baseUrl;

        /// <summary>
        /// Example: https://api.company.com
        /// </summary>
        public string BaseUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_baseUrl))
                {
                    throw new Exception("Error: BaseUrl not set!");
                }
                return _baseUrl;
            }
            set { _baseUrl = value; }
        }

        private string _apiUri;

        /// <summary>
        ///  example: /api/resources/
        /// </summary>
        public string ApiUri
        {
            get
            {
                if (string.IsNullOrEmpty(_apiUri))
                {
                    throw new Exception("Error: Api Uri not set!");
                }
                return _apiUri;
            }
            set { _apiUri = value; }
        }

        public ServiceBase(IConfiguration configuration, IRestClient client)
        {
            this.Configuration = configuration;
            _client = client;
        }

        //protected internal virtual async Task<T> Read<T>(int id)
        //{
        //    T toReturn = default(T);
        //    try
        //    {
        //        string url = this.BaseUrl + this.ApiUri;
        //        HttpContent content = JsonHelper.SerializeContent(new ReadRequestBase() { Id = id });
        //        HttpResponseMessage response = await _client.SendAsync(HttpMethod.Post, url, content);
        //        toReturn = await this.EvaulateResponse<T>(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.ToString();
        //    }
        //    return toReturn;
        //}

        //        protected internal virtual async Task<T> ReadAll<T>()
        //        {
        //            T toReturn = default(T);
        //            try
        //            {
        //                string url = this.BaseUrl + this.ApiUri;
        //                HttpResponseMessage response = await _client.SendAsync(HttpMethod.Get, url);
        //                toReturn = await this.EvaulateResponse<T>(response);
        //            }
        //            catch (Exception ex)
        //            {
        //                this.ErrorMessage = ex.ToString();
        //            }
        //            return toReturn;
        //        }
        //protected internal virtual async Task<T> Search<T>(object searchCriteria)
        //{
        //    T toReturn = default(T);
        //    try
        //    {
        //        string url = this.BaseUrl + this.ApiUri + "search";
        //        HttpContent content = JsonHelper.SerializeContent(searchCriteria);
        //        HttpResponseMessage response = await _client.SendAsync(HttpMethod.Post, url, content);
        //        toReturn = await this.EvaulateResponse<T>(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.ToString();
        //    }
        //    return toReturn;
        //}

        //protected internal virtual async Task<T> Create<T>(T entity)
        //{
        //    try
        //    {
        //        string url = this.BaseUrl + this.ApiUri + "create";
        //        HttpContent content = JsonHelper.SerializeContent(entity);
        //        HttpResponseMessage response = await _client.SendAsync(HttpMethod.Post, url, content);
        //        entity = await this.EvaulateResponse<T>(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.ToString();
        //    }
        //    return entity;
        //}

        //protected internal virtual async Task<T> Update<T>(int id, T entity)
        //{
        //    T toReturn = default(T);
        //    try
        //    {
        //        string url = this.BaseUrl + this.ApiUri + "update";
        //        HttpContent content = JsonHelper.SerializeContent(entity);
        //        HttpResponseMessage response = await _client.SendAsync(HttpMethod.Post, url, content);
        //        toReturn = await this.EvaulateResponse<T>(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.ToString();
        //    }
        //    return toReturn;
        //}

        //protected internal virtual async Task<T> Delete<T>(int id)
        //{
        //    T toReturn = default(T);
        //    try
        //    {
        //        string url = this.BaseUrl + this.ApiUri + "delete";
        //        HttpContent content = JsonHelper.SerializeContent(new DeleteRequestBase() { Id = id });
        //        HttpResponseMessage response = await _client.SendAsync(HttpMethod.Post, url, content);
        //        await this.EvaulateResponse<string>(response);
        //    }
        //    catch (Exception ex)
        //    {
        //        this.ErrorMessage = ex.ToString();
        //    }
        //    return toReturn;
        //}

        protected internal virtual async Task<K> Post<T,K>(T input, string uri)
        {
            K toReturn = default(K);
            try
            {
                string url = this.BaseUrl + this.ApiUri + uri;
                HttpContent content = JsonHelper.SerializeContent(input);
                HttpResponseMessage response = await _client.SendAsync(HttpMethod.Post, url, content);
                toReturn = await this.EvaulateResponse<K>(response);
            }
            catch (Exception ex)
            {
                this.ErrorMessage = ex.ToString();
            }
            return toReturn;
        }

        public async Task<T> EvaulateResponse<T>(HttpResponseMessage response)
        {
            T toReturn = default(T);
            if (!response.IsSuccessStatusCode)
            {
                this.ErrorMessage = response.StatusCode.ToString();
                return toReturn;
            }

            ResponseBase<object> responseBase = await JsonHelper.DeserializeResponse<ResponseBase<object>>(response);
            if (responseBase.HasError)
            {
                this.ErrorMessage = responseBase.Error.Message;
                return toReturn;
            }

            if (responseBase.Message != null)
            {
                toReturn = await JsonHelper.Deserialize<T>(responseBase.Message.ToString());
            }
            return toReturn;
        }

    }
}
