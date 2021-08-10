#region Using Statements
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
#endregion

namespace CacheManager.ApiClient.Services.Tests
{
    [TestClass]
    public abstract class ServiceTestsBase
    {
        protected IConfiguration _configuration;

        [TestInitialize]
        public void Initalize()
        {
            IServiceCollection services = new ServiceCollection();            

            // Configuration
            _configuration = new ConfigurationBuilder()
               .AddJsonFile("appsettings.json", true, true)
               .Build();
            services.AddSingleton(_configuration);

            ServiceProvider serviceProvider = services.BuildServiceProvider();


        }

    }
    
}
