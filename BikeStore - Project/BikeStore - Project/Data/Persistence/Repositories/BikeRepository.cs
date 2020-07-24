using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BikeStore___Project.Domain.Models;
using BikeStore___Project.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;

namespace BikeStore___Project.Data.Persistence.Repositories
{
    public class BikeRepository : BaseRepository, IBikeRepository
    {
        private readonly IMemoryCache _memCache;
        private readonly ILogger<BikeRepository> _logger;

        public BikeRepository(AppDbContext context, IMemoryCache memCache, ILogger<BikeRepository> logger) :
            base(context)
        {
            _memCache = memCache;
            _logger = logger;
        }

        public void CacheCallback(object key, object value, EvictionReason reason, object state)
        {
            _logger.LogInformation($"Cache reset caused by: {reason} on: {key}");
        }

        public async Task<IEnumerable<Bike>> ListAsync(CancellationToken tkn)
        {
            //Caching example
            var cacheKey = "getAllBikes";
            var fromCache = true;
            var bikes = await _memCache.GetOrCreateAsync(cacheKey, e =>
            {
                var cacheTokenSource = _memCache.GetOrCreate(cacheKey, cacheEntry => new CancellationTokenSource());
                e.AddExpirationToken(new CancellationChangeToken(cacheTokenSource.Token));
                e.RegisterPostEvictionCallback(CacheCallback, this);
                fromCache = false;
                return _context.Bikes.Include(p => p.Category)
                    .ToListAsync(tkn);
            });

            _logger.LogInformation(!fromCache ? "Bikes returned from db!" : "Bikes returned from cache!");

            return bikes;
        }

        public async Task AddAsync(Bike bike)
        {
            await _context.Bikes.AddAsync(bike);
        }

        public async Task<Bike> FindByIdAsync(int id)
        {
            return await _context.Bikes.FindAsync(id);
        }

        public void Update(Bike bike)
        {
            _context.Bikes.Update(bike);
        }

        public void Remove(Bike bike)
        {
            //Invalidation example
            _memCache.Remove("getAllBikes");
            _logger.LogInformation("Bikes cache invalidated!");
            _context.Bikes.Remove(bike);
        }
    }
}