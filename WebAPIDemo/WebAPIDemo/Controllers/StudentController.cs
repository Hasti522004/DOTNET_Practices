using Microsoft.AspNetCore.Mvc;
using WebAPIDemo.Model;

namespace WebAPIDemo.Controllers
{
    [Controller]
    [Route("api/")]
    public class StudentController : Controller
    {
        [HttpGet]
        public IEnumerable<Student> GetStudents()
        {
            return CollegeRepository.students;
        }
        [HttpGet("{id}")]
        public Student GetStudentById(int id)
        {
            return CollegeRepository.students.Where(s => s.Id == id).FirstOrDefault();
        }
    }
}
