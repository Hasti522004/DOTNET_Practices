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
        private readonly ILogger<DemoOfDIController> _myloggerFactory;
        public DemoOfDIController(IMyLogger mylogger, ILogger<DemoOfDIController> myloggerFactory)
        {
            _mylogger = mylogger;
            _myloggerFactory = myloggerFactory;
        }
        [HttpGet]
        public ActionResult Index()
        {
            _myloggerFactory.LogInformation("From Log Information");
            _myloggerFactory.LogDebug("From Log Debug");
            _myloggerFactory.LogError("From Log Error");

            _mylogger.Log("Index method Started");
            return Ok();
        }
    }
}
