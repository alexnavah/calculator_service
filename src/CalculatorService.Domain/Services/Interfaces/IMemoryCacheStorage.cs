namespace CalculatorService.Domain.Services.Interfaces
{
    public interface IMemoryCacheStorage
    {
        bool Exists(string key);
        T Get<T>(string key);
        void Set(string key, object data);
    }
}