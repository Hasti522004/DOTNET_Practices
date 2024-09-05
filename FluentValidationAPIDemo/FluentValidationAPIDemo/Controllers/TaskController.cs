using FluentValidationAPIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        public TaskController()
        {
            
        }
        [HttpPost]
        [Route("[Action]")]
        public TaskItem Post(TaskItem model)
        {
            return model;
        }
    }
}
