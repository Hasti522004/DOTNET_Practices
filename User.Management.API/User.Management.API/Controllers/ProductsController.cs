using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using System.Text;
using System.Text.Json;
using User.Management.API.Models;

namespace User.Management.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IDistributedCache _cache;
        public ProductsController(ApplicationDbContext context, IDistributedCache cache)
        {
            _context = context;
            _cache = cache;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cacheKey = "GET_ALL_PRODUCTS";
            List<Product> products;
            // Get data from cache
            var cachedData = await _cache.GetAsync(cacheKey);
            if (cachedData != null)
            {
                // If data found in cache, encode and deserialize cached data
                var cachedDataString = Encoding.UTF8.GetString(cachedData);
                products = JsonSerializer.Deserialize<List<Product>>(cachedDataString) ?? new List<Product>();
            }
            else
            {
                // If not found, then fetch data from database
                products = await _context.Products.ToListAsync();
                // serialize data
                var cachedDataString = JsonSerializer.Serialize(products);
                var newDataToCache = Encoding.UTF8.GetBytes(cachedDataString);
                // set cache options 
                var options = new DistributedCacheEntryOptions()
                    .SetAbsoluteExpiration(DateTime.Now.AddMinutes(2))
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));
                // Add data in cache
                await _cache.SetAsync(cacheKey, newDataToCache, options);
            }
            return Ok(products);
        }
    }
}
