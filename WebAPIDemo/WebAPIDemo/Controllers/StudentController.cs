using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Model;

namespace WebAPIDemo.Controllers
{
    [Controller]
    [Route("api/")]
    public class StudentController : Controller
    {
        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            // Ok - 200 - Success
            return Ok(CollegeRepository.students);
        }

        [HttpGet("{id:int}",Name ="GetStudentById")]
        public ActionResult<Student> GetStudentById(int id)
        {
            // BadRequest - 400 - Client Error
            if (id <= 0)
                return BadRequest();

            var student = CollegeRepository.students.Where(s => s.Id == id).FirstOrDefault();

            // NotFound - 404 - Client error
            if (student == null)
                return NotFound($"The Student with Id {id} Not Found.");

            // Ok - 200 - Success
            return Ok(student);
        }

        [HttpGet]
        // string is not use as a routing constrain, in place of that we can use alpha
        [Route("{name:alpha}",Name = "GetStudentByName")]
        public Student GetStudentById(string name)
        {
            return CollegeRepository.students.Where(s => s.Name == name).FirstOrDefault();
        }
    }
}
