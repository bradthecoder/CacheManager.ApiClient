#region Using Statements
using CacheManager.ApiClient.Interfaces;
using CacheManager.ApiClient.Models;
using Microsoft.Extensions.Configuration;
using Shared.HttpUtilities;
using System.Threading.Tasks;
#endregion

namespace CacheManager.ApiClient.Services
{
    public class Service : ServiceBase, IService
    {
        public Service(IConfiguration configuration, IRestClient restClient) : base(configuration, restClient)
        {
            this.BaseUrl = this.Configuration.GetValue<string>(BaseUrlConfigPath);
            this.ApiUri = "/api/";
        }

        public async Task<CacheObject> GetObject(GetObjectRequest request)
        {
            CacheObject toReturn = null;
            toReturn = await base.Post<GetObjectRequest, CacheObject>(request, "getObject");
            return toReturn;
        }

        public async Task<object> GetObjectProperty(GetObjectPropertyRequest request)
        {
            object toReturn = null;
            toReturn = await base.Post<GetObjectPropertyRequest, object>(request, "getObjectProperty");
            return toReturn;
        }

        public async Task SetObject(CacheObject request)
        {
            string toReturn = null;
            toReturn = await base.Post<CacheObject, string>(request, "setObject");
            return;
        }

        public async Task SetObjectProperty(SetObjectPropertyRequest request)
        {
            string toReturn = null;
            toReturn = await base.Post<SetObjectPropertyRequest, string>(request, "setObjectProperty");
            return;
        }

        public async Task RefreshObject(RefreshObjectRequest request)
        {
            string toReturn = null;
            toReturn = await base.Post<RefreshObjectRequest, string>(request, "refreshObject");
            return;
        }

        public async Task RemoveObject(RemoveObjectRequest request)
        {
            string toReturn = null;
            toReturn = await base.Post<RemoveObjectRequest, string>(request, "removeObject");
            return;
        }
        
        public async Task RemoveObjectProperty(RemoveObjectPropertyRequest request)
        {
            string toReturn = null;
            toReturn = await base.Post<RemoveObjectPropertyRequest, string>(request, "removeObjectProperty");
            return;
        }

    }
}
