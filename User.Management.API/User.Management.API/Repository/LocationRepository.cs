using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using User.Management.API.Models;

namespace InMemoryCachingDemo.Repository
{
    public class LocationRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache;

        public LocationRepository(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }
        //Using Manual Eviction for countries
        public async Task<List<Country>> GetCountriesAsync()
         {
            var cacheKey = "Countries";
            if (!_cache.TryGetValue(cacheKey, out List<Country>? countries))
            {
                
                countries = await _context.Countries.ToListAsync();
                _cache.Set(cacheKey, countries);  // No Expiration Set
            }
            Console.WriteLine("Hiiiiiiii");
            return countries ?? new List<Country>();
        }
        // This Methid can be called after updating or deleting country data.
        public void RemoveCountriesFromCache()
        {
            var cacheKey = "Countries";
            _cache.Remove(cacheKey);
        }
        public async Task UpdateCountry(Country updatedCountry)
        {
            _context.Countries.Update(updatedCountry);
            await _context.SaveChangesAsync();
            RemoveCountriesFromCache();
        }
        // Using Sliding Expiration for states
        public async Task<List<State>> GetStatesAsync(int countryId)
        {
            string cacheKey = $"States_{countryId}";
            if (!_cache.TryGetValue(cacheKey, out List<State>? states))
            {
                states = await _context.States.Where(s => s.CountryId == countryId).ToListAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30)); // Sliding Expiration
                _cache.Set(cacheKey, states, cacheEntryOptions);
            }
            return states ?? new List<State>();
        }
        // Using Absolute Expiration for Cities
        public async Task<List<City>> GetCitiesAsync(int stateId)
        {
            string cacheKey = $"Cities_{stateId}";
            if (!_cache.TryGetValue(cacheKey, out List<City>? cities))
            {
                cities = await _context.Cities.Where(c => c.StateId == stateId).ToListAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetAbsoluteExpiration(TimeSpan.FromMinutes(30)); // Absolute Expiration
                _cache.Set(cacheKey, cities, cacheEntryOptions);
            }
            return cities ?? new List<City>();
        }
    }
}