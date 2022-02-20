namespace CalculatorService.Domain.Services
{
    public interface IMemoryCacheService
    {
        T Get<T>(string key);
        void Set(string key, object data);
        void Remove(string key);
    }
}