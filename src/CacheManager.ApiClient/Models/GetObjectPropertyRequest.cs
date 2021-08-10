#region Using Statements

#endregion
namespace CacheManager.ApiClient.Models
{
    public class GetObjectPropertyRequest
    {
        public int Id { get; set; }

        public CacheObjectType Type { get; set; }

        public string PropertyName { get; set; }
    }
}
