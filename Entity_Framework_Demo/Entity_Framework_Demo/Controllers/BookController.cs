using Entity_Framework_Demo.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Entity_Framework_Demo.Controllers
{
    [Route("api/books")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public BookController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        [HttpPost("")]
        public async Task<IActionResult> InsertBook([FromBody] BookCreateModel model)
        {
            // Ensure Language exists
            var language = await appDbContext.Languages.FindAsync(model.LanguageId);
            if (language == null)
            {
                return BadRequest("Invalid LanguageId.");
            }

            var book = new Books
            {
                Title = model.Title,
                Description = model.Description,
                NoOfPages = model.NoOfPages,
                IsActive = model.IsActive,
                CreatedOn = model.CreatedOn,
                LanguageId = model.LanguageId
            };

            appDbContext.Books.Add(book);
            await appDbContext.SaveChangesAsync();
            return Ok(book);
        }
    }
    public class BookCreateModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int NoOfPages { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedOn { get; set; }
        public int LanguageId { get; set; }
    }
}
