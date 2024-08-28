using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace DapperDemoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : Controller
    {
        private readonly IConfiguration _config;

        public SuperHeroController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllSuperHeroes()
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            IEnumerable<SuperHero> heros = await SelectAllHeroes(connection);
            return Ok(heros);
        }

        

        [HttpGet("{heroId}")]
        public async Task<ActionResult<List<SuperHero>>> GetSuperHeroes(int heroId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            var hero = await connection.QueryFirstAsync<SuperHero>("select * from SuperHeros where id=@Id", new {Id = heroId});
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> CreateHero(SuperHero hero)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into SuperHeros(name,firstname,lastname,place) values(@Name,@FirstName,@LastName,@Place)",hero);
            return Ok(await SelectAllHeroes(connection));
        }
        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero hero)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("update SuperHeros set name = @Name,firstname = @FirstName,lastname=@LastName,place = @Place where id = @Id", hero);
            return Ok(await SelectAllHeroes(connection));
        }

        [HttpDelete("{heroId}")]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(int heroId)
        {
            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("delete from SuperHeros where id = @Id",new {Id = heroId});
            return Ok(await SelectAllHeroes(connection));
        }
        private static async Task<IEnumerable<SuperHero>> SelectAllHeroes(SqlConnection connection)
        {
            return await connection.QueryAsync<SuperHero>("select * from SuperHeros");
        }

    }
}
