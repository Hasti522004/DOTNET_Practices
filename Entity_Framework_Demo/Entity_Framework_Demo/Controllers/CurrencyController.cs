using Entity_Framework_Demo.Data;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Demo.Controllers
{
    [Route("api/currency")]
    [ApiController]
    public class CurrencyController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public CurrencyController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        [HttpGet]
        public ActionResult GetAllCurrency()
        {
            var result = _appDbContext.Languages.ToList();
            return Ok(result);
        }
    }
}
