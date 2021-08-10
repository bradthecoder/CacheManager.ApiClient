#region Using Statements
using System.Runtime.Serialization;
#endregion

namespace CacheManager.ApiClient.Models
{
    public enum CacheObjectType : int
    {
        [EnumMember(Value = "User")]
        User = 0,

    }
}
