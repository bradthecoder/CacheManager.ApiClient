#region Using Statements
using CacheManager.ApiClient.Models;
using System.Collections.Generic;
using System.Threading.Tasks; 
#endregion

namespace CacheManager.ApiClient.Interfaces
{
    public interface IService
    {
        string ErrorMessage { get; set; }

        bool HasError { get; }

        string BaseUrl { get; set; }

        Task<CacheObject> GetObject(GetObjectRequest request);
        Task SetObject(CacheObject request);
        Task<object> GetObjectProperty(GetObjectPropertyRequest request);
        Task SetObjectProperty(SetObjectPropertyRequest request);
        Task RefreshObject(RefreshObjectRequest request);
        Task RemoveObject(RemoveObjectRequest request);
        Task RemoveObjectProperty(RemoveObjectPropertyRequest request);
    }

}
