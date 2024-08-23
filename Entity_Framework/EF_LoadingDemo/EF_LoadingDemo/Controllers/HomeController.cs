using EF_LoadingDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EF_LoadingDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _appDbContext;

        public HomeController(ILogger<HomeController> logger,AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }

        public IActionResult Index()
        {
            //1. Lazy Loading - Default Behaviour

            // IEnumerable<Villa> villa = _appDbContext.Villas;

            // call Query and fetch data when villa.Count method is Called.
            // var TotalVillas = villa.Count();

            List<Villa> villas = _appDbContext.Villas.ToList();

            var TotalVillas = villas.Count();

            for (int i = 0; i < TotalVillas; i++)
            {
                villas[i].eminity = _appDbContext.VillaEminity.Where(u=>u.VillaId == villas[i].Id).ToList();
            }



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
