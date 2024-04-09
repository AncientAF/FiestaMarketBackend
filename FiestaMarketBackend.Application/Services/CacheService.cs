using CSharpFunctionalExtensions;
using CSharpFunctionalExtensions.Json.Serialization;
using FiestaMarketBackend.Application.Abstractions.Caching;
using FiestaMarketBackend.Core;
using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;
using System.Threading.Tasks;

namespace FiestaMarketBackend.Application.Services
{
    public class CacheService : ICacheService
    {
        private static readonly TimeSpan DefaultExpiration = TimeSpan.FromMinutes(5);

        private readonly IDistributedCache _distributedCache;
        public CacheService(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
        }

        public async Task<T> GetOrCreateAsync<T>(string key, Func<CancellationToken, Task<T>> factory, TimeSpan? expiration = null, CancellationToken cancellationToken = default)
        {
            var cachedResult = await _distributedCache.GetStringAsync(key, cancellationToken);

            JsonSerializerOptions options = new JsonSerializerOptions();
            options.AddCSharpFunctionalExtensionsConverters();

            if (!string.IsNullOrEmpty(cachedResult))
            {
                var res = JsonSerializer.Deserialize<T>(cachedResult, options);

                return res!;
            }

            var result = await factory(cancellationToken);

            if (result is IResult && ((IResult)result).IsSuccess)
            {
                DistributedCacheEntryOptions opts = new ();
                opts.AbsoluteExpirationRelativeToNow = expiration ?? DefaultExpiration;
                await _distributedCache.SetStringAsync(key, JsonSerializer.Serialize(result, options), opts, cancellationToken);
            }

            return result;
        }
    }
}
