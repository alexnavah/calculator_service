namespace CalculatorService.Domain.Services
{
    /// <summary>
    ///     Handles memory cache operations
    /// </summary>
    public interface IMemoryCacheService
    {
        /// <summary>
        /// Retrieves cache entries based on the <paramref name="key"/> identifier
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">Cache identifier</param>
        /// <returns>Object found as <typeparamref name="T"/></returns>
        T Get<T>(string key);
        /// <summary>
        /// Set in cache <paramref name="data"/> for the <paramref name="key"/> given
        /// </summary>
        /// <param name="key">The cache identifier</param>
        /// <param name="data">The data to add in memory cache</param>
        void Set(string key, object data);
    }
}