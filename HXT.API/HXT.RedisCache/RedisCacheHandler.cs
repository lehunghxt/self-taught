using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HXT.RedisCache
{
    public class RedisCacheHandler : ICacheHandler
    {
        private readonly IRedisDbProvider _redisDbProvider;

        public RedisCacheHandler(IRedisDbProvider redisDbProvider)
        {
            _redisDbProvider = redisDbProvider ?? throw new ArgumentNullException(nameof(redisDbProvider));

            if (_redisDbProvider.Database == null)
            {
                throw new ArgumentNullException("The provided redisDbProvider or its database is null");
            }
        }

        private bool disposedValue;

        public Task StringDeleteAsync(string key)
        {
            var _ = _redisDbProvider.Database.StringGetDeleteAsync(key).ConfigureAwait(false);
            return Task.CompletedTask;
        }

        public async Task<bool> StringExistsAsync(string key)
        {
            return await _redisDbProvider.Database.KeyExistsAsync(key).ConfigureAwait(false);
        }

        public async Task<string?> StringGetAsync(string key)
        {
            return await _redisDbProvider.Database.StringGetAsync(key).ConfigureAwait(false);
        }

        public async Task<bool> StringSetAsync(string key, string value, TimeSpan? expiry = null)
        {
            return await _redisDbProvider.Database.StringSetAsync(key, value, expiry).ConfigureAwait(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _redisDbProvider.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        ~RedisCacheHandler()
        {
            Dispose(disposing: false);
        }
    }
}
