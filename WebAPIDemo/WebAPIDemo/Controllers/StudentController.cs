using Microsoft.AspNetCore.JsonPatch;
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
            foreach (var item in CollegeRepository.students)
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

        [HttpGet("{id:int}", Name = "GetStudentById")]
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
        [Route("{name:alpha}", Name = "GetStudentByName")]
        public Student GetStudentByName(string name)
        {
            return CollegeRepository.students.Where(s => s.Name == name).FirstOrDefault();
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> CreateStudent([FromBody] StudentDTO model)
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

        [HttpPut]
        [Route("UpdateStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult UpdateStudent([FromBody] StudentDTO model)
        {
            if (model == null || model.Id <= 0)
            {
                return BadRequest();
            }

            var existingStudent = CollegeRepository.students.Where(s => s.Id == model.Id).FirstOrDefault();

            if (existingStudent == null)
            {
                return NotFound();
            }
            existingStudent.Name = model.Name;
            existingStudent.Email = model.Email;
            existingStudent.Address = model.Address;

            return NoContent();
        }
        [HttpPatch]
        [Route("{id:int}/UpdatePartial")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult UpdateStudentPartial(int id,[FromBody] JsonPatchDocument<StudentDTO> patchDocument)
        {
            if (patchDocument == null || id <= 0)
                return BadRequest();

            var existingStudent = CollegeRepository.students.Where(s => s.Id == id).FirstOrDefault();

            if (existingStudent == null)
                return NotFound();

            var StudentDTO = new StudentDTO()
            {
                Id = existingStudent.Id,
                Name = existingStudent.Name,
                Email = existingStudent.Email,
                Address = existingStudent.Address
            };

            patchDocument.ApplyTo(StudentDTO,ModelState);

            if (!ModelState.IsValid)
                return BadRequest();

            existingStudent.Name = StudentDTO.Name;
            existingStudent.Email = StudentDTO.Email;
            existingStudent.Address= StudentDTO.Address;

            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteStudent")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<bool> DeleteStudent(int id)
        {
            if(id<=0) return BadRequest();
            var student = CollegeRepository.students.Where(s => s.Id==id).FirstOrDefault();
            if (student == null)
                return NotFound($"The Student with Id {id} Not Found.");

            CollegeRepository.students.Remove(student);

            return true;
        }
    }
}
