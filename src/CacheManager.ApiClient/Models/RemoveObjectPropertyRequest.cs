#region Using Statements
using System.Collections.Generic;
#endregion

namespace CacheManager.ApiClient.Models
{
    public class RemoveObjectPropertyRequest
    {
        public int Id { get; set; }

        public CacheObjectType Type { get; set; }

        public List<string> Properties { get; set; }

    }
}
