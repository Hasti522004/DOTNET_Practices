using Entity_Framework_Demo.Data;
using Microsoft.AspNetCore.Mvc;

namespace Entity_Framework_Demo.Controllers
{
    [Route("api/language")]
    [ApiController]
    public class LanguageController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public LanguageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        public ActionResult GetLanguages()
        {
            var result = _appDbContext.Languages.ToList();
            return Ok(result);
        }
    }
}
