using Microsoft.Extensions.Caching.Memory;
using System.Net.Http.Json;

namespace TradingPartyClient
{
    public class TradingPartyHttpClient
    {
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache _memoryCache;


        public TradingPartyHttpClient(HttpClient httpClient, IMemoryCache memoryCache)
        {
            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri("https://localhost:7046/");
            _memoryCache = memoryCache;
        }

        public async Task<IEnumerable<int>?> GetParties() {
            if (!_memoryCache.TryGetValue("tradingparty", out IEnumerable<int> cacheValue))
            {
                cacheValue = await _httpClient.GetFromJsonAsync<IEnumerable<int>>(
                        "tradingparty");

                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromHours(3));

                _memoryCache.Set("tradingparty", cacheValue, cacheEntryOptions);
            }
            return cacheValue;
            
        }
    }
}