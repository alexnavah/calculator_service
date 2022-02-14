using CalculatorService.Domain.Services.Interfaces;
using System;
using System.Runtime.Caching;

namespace CalculatorService.Domain.Services
{
    public class MemoryCacheStorage : IMemoryCacheStorage
    {
        private readonly MemoryCache _cache;

        public MemoryCacheStorage(MemoryCache cache)
        {
            _cache = cache;
        }

        public bool Exists(string key)
        {
            return _cache.Get(key) != null;
        }

        public T Get<T>(string key)
        {
            return (T)_cache.Get(key);
        }

        public void Set(string key, object data)
        {
            _cache.Add(key, data, DateTimeOffset.MaxValue);
        }
    }
}
