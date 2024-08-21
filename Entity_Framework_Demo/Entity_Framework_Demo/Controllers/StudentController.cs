using Entity_Framework_Demo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Demo.Controllers
{
    [Route("API/Student")]
    [ApiController]
    public class StudentController : Controller
    {
        private readonly AppDbContext appDbContext;

        public StudentController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }
        [HttpPost("")]
        public async Task<IActionResult> AddData([FromBody] Student student)
        {
            appDbContext.Students.Add(student);
            appDbContext.SaveChanges();
            return Ok(student);
        }

        [HttpGet("")]
        public async Task<IActionResult> GetData()
        {
            var result = await appDbContext.Students.ToListAsync();
            return Ok(result);
        }

        [HttpPost("bulk")]
        public async Task<IActionResult> AddBulkData([FromBody] List<Student> student)
        {
            await appDbContext.Students.AddRangeAsync(student);
            appDbContext.SaveChanges();
            return Ok(student);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent([FromRoute] int id,[FromBody] Student student)
        {
            var stu = appDbContext.Students.FirstOrDefault(s => s.Id == id);
            if(stu == null)
            {
                return NotFound();
            }
            stu.Name = student.Name;
            stu.Age = student.Age;

            appDbContext.SaveChanges();
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecord([FromRoute] int id)
        {
            var data = await appDbContext.Students.FirstOrDefaultAsync(a => a.Id == id);
            if(data == null)
            {
                return NotFound();
            }

            appDbContext.Students.Remove(data);
            appDbContext.SaveChanges();
            return Ok(data);
        }
    }
}
