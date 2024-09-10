using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIUserManagement.Models;

namespace WebAPIUserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly MyDbContext _myDbContext;
        public UsersController(MyDbContext dbContext)
        {
            _myDbContext = dbContext;
        }
        [HttpPost]
        [Route("Registration")]
        public IActionResult Registration(UserDTO userDTO)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var objUser = _myDbContext.Users.FirstOrDefault(x => x.Email == userDTO.Email);
            if(objUser == null)
            {
                _myDbContext.Users.Add(new Models.User
                {
                    FirstName = userDTO.FirstName,
                    LastName = userDTO.LastName,
                    Email = userDTO.Email,
                    Password = userDTO.Password
                });
                _myDbContext.SaveChanges();
                return Ok("User Registor Successfully");
            }
            else
            {
                return BadRequest("User Already Exists with the same email address");
            }
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginDTO login)
        {
            var user = _myDbContext.Users.FirstOrDefault(x => x.Email == login.Email && x.Password == login.Password);
            if(user != null)
            {
                return Ok(user);
            }
            return NoContent();
        }

        [HttpGet]
        [Route("GetUsers")]
        public IActionResult GetUsers()
        {
            return Ok(_myDbContext.Users.ToList());
        }

        [HttpGet]
        [Route("GetUser")]
        public IActionResult GetUser(int id)
        {
            var user = _myDbContext.Users.FirstOrDefault(x=> x.UserId == id);
            if(user != null)
            {
                return Ok(user);
            }
            else
            {
                return NoContent();
            }
        }
    }
}
