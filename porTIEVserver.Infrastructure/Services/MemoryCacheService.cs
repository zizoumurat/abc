using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using porTIEVserver.Application.Services;

namespace porTIEVserver.Infrastructure.Services
{
    public sealed class MemoryCacheService(
        IMemoryCache cache
        ) : ICacheService
    {
        public T? Get<T>(string key)
        {
            cache.TryGetValue<T>(key, out var value);
            
            return value;
        }

        public bool Remove(string key)
        {
            cache.Remove(key);
            return true;
        }

        public void Set<T>(string key, T value, TimeSpan? expiry = null)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = expiry ?? TimeSpan.FromHours(1),
            };

            cache.Set(key, value, cacheEntryOptions);
        }
    }
}
