using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.MyLogging;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("DI/")]
    public class DemoOfDIController : ControllerBase
    {
        //1. Strongly coupled/tightly coupled

        private readonly IMyLogger _mylogger;
        public DemoOfDIController(IMyLogger mylogger)
        {
            _mylogger = mylogger;
        }
        [HttpGet]
        public ActionResult Index()
        {
            _mylogger.Log("Index method Started");
            return Ok();
        }
    }
}
