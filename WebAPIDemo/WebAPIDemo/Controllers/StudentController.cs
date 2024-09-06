using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Model;

namespace WebAPIDemo.Controllers
{
    [ApiController]
    [Route("api/")]
    public class StudentController : Controller
    {
        [HttpGet]
        [Route("All")]
        public ActionResult<IEnumerable<Student>> GetStudents()
        {
            // using ADO
            var students = new List<StudentDTO>();
            foreach(var item in CollegeRepository.students)
            {
                StudentDTO obj = new StudentDTO()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Email = item.Email,
                    Address = item.Address
                };
                students.Add(obj);
            }

            // using Linq
            var std = CollegeRepository.students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                Name = s.Name,
                Email = s.Email,
                Address = s.Address
            });

            // Ok - 200 - Success
            return Ok(students);
        }

        [HttpGet("{id:int}",Name ="GetStudentById")]
        [ProducesResponseType(typeof(int), 200)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
        public Student GetStudentByName(string name)
        {
            return CollegeRepository.students.Where(s => s.Name == name).FirstOrDefault();
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> CreateStudent([FromBody]StudentDTO model)
        {
            if (model == null)
                return BadRequest();

            int newId = CollegeRepository.students.LastOrDefault().Id + 1;
            Student st = new Student
            {
                Id = newId,
                Name = model.Name,
                Email = model.Email,
                Address = model.Address
            };
            model.Id = newId;
            CollegeRepository.students.Add(st);
            // Create URL/Location for perticular id
            return CreatedAtRoute("GetStudentById", new { id = model.Id }, model);
        }
    }
}
