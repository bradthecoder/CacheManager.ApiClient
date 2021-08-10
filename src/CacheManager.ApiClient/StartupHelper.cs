#region Using Statements
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;
#endregion

namespace CacheManager.ApiClient
{
    [ExcludeFromCodeCoverage]
    public static class StartupHelper
    {
        public static void AddCacheManagerApiClient(this IServiceCollection services)
        {
			 services.AddTransient<Shared.HttpUtilities.IRestClient, Shared.HttpUtilities.RestClient>();
			 services.AddTransient<Interfaces.IService, Services.Service>();

        }

    }
}
