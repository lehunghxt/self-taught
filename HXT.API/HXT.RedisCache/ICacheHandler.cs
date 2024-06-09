using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXT.RedisCache
{
    public interface ICacheHandler : IDisposable
    {
        Task<bool> StringSetAsync(string key, string value, TimeSpan? expiry = null);
        Task<string?> StringGetAsync(string key);
        Task StringDeleteAsync(string key);
        Task<bool> StringExistsAsync(string key);
    }
}
