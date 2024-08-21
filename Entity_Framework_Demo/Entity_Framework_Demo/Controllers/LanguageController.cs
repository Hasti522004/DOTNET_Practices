﻿using Entity_Framework_Demo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Entity_Framework_Demo.Controllers
{
    [Route("api/language")]
    [ApiController]
    public class LanguageController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public LanguageController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        [HttpGet("")]
        //using Asyncronous Programming
        public async Task<ActionResult> GetLanguages()
        {
            var result = await _appDbContext.Languages.ToListAsync();
            // using async
            var result2 = await (from Language in _appDbContext.Languages select Language).ToListAsync();
            return Ok(result);
        }

        [HttpGet("{id:int}")] // Solve ambiguity Error add :int
        public async Task<IActionResult> GetLanguagebyIdAsync([FromRoute] int id)
        {
            var result = _appDbContext.Languages.FindAsync(id);
            return Ok(result);
        }

        //[HttpGet("{name}")]
        //public async Task<IActionResult> GetLanguageByNameAsync([FromRoute] string name)
        //{
        //    var result =await _appDbContext.Languages.Where(x=>x.Title == name).FirstOrDefaultAsync();
        //    return Ok(result);
        //}

        [HttpGet("{name}/{desc}")]
        public async Task<IActionResult> GetLanguageByNameAsync([FromRoute] string name, [FromRoute] string desc)
        {
            var result = await _appDbContext.Languages.FirstOrDefaultAsync(x => x.Title == name && x.Description == desc);
            return Ok(result);
        }
    }
}
