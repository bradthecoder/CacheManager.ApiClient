#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CacheManager.ApiClient.Models;
#endregion

namespace CacheManager.ApiClient.Tests.MockData
{
    public class CacheObjects
    {
        public CacheObject ExampleCacheObject()
        {
            CacheObject toReturn = new();
            toReturn.Id = 99;
            toReturn.Type = CacheObjectType.User;
            toReturn.Properties = new Dictionary<string, object>();
            toReturn.Properties.Add("Name", "Some User");
            toReturn.Properties.Add("Today", DateTime.Now);
            toReturn.Properties.Add("ComplexProperty", new { Message= "hello world", Value = 0.01M });
            return toReturn;
        }
    }
}
