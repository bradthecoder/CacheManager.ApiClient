#region Using Statements
#endregion

namespace CacheManager.ApiClient.Models
{
    public class RemoveObjectRequest
    {
        public int Id { get; set; }

        public CacheObjectType Type { get; set; }

    }
}
