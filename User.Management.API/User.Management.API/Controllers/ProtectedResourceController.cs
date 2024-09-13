using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace User.Management.API.Controllers
{
    public class ProtectedResourceController : Controller
    {
        [Route("protectedInfo")]
        [HttpGet]
        //[Authorize("AtLeast18")]
        public IActionResult Index()
        {
            throw new Exception("Global Exception Handler");
            // return Ok("You can See this message means you are a valid user.");
        }
    }
}
