using Microsoft.Extensions.Caching.Memory;

namespace CalculatorService.Domain.Services
{
    public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;

        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T Get<T>(string key)
        {
            return (T)_memoryCache.Get(key);
        }

        public void Set(string key, object data)
        {
            _memoryCache.Set(key, data);
        }

        public void Remove(string key)
        {
            _memoryCache.Remove(key);
        }
    }
}
