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
        public IEnumerable<Student> GetStudents()
        {
            return CollegeRepository.students;
        }

        [HttpGet("{id:int}",Name ="GetStudentById")]
        public Student GetStudentById(int id)
        {
            return CollegeRepository.students.Where(s => s.Id == id).FirstOrDefault();
        }

        [HttpGet]
        [Route("{name:alpha}",Name = "GetStudentByName")]
        public Student GetStudentById(string name)
        {
            return CollegeRepository.students.Where(s => s.Name == name).FirstOrDefault();
        }
    }
}
