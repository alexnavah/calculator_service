using Microsoft.Extensions.Caching.Memory;

namespace CalculatorService.Domain.Services
{
    ///<inheritdoc cref="IMemoryCacheService"/>
    public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        ///<inheritdoc cref="IMemoryCacheService.Get{T}(string)"/>
        public T Get<T>(string key)
        {
            return (T)_memoryCache.Get(key);
        }

        /// <inheritdoc cref="IMemoryCacheService.Set(string, object)"/>
        public void Set(string key, object data)
        {
            _memoryCache.Set(key, data);
        }
    }
}
