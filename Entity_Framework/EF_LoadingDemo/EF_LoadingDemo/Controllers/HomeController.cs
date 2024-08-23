using EF_LoadingDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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

            // List<Villa> villas = _appDbContext.Villas.ToList();

            //var TotalVillas = villas.Count();

            // Child Class not load By Default in lazy loading. We need to call explicitly
            // call Query n+1 times
            //for (int i = 0; i < TotalVillas; i++)
            //{
            //    villas[i].eminity = _appDbContext.VillaEminity.Where(u=>u.VillaId == villas[i].Id).ToList();
            //}

            // Work same as above for loop
            //foreach (Villa villa in villas)
            //{
            //    villa.eminity = _appDbContext.VillaEminity.Where(u => u.VillaId == villa.Id).ToList();
            //}

            //2. Eager Loading
            // Load all data in one Query Call only
            // List<Villa> eager_villas = _appDbContext.Villas.Include(u=>u.eminity).ToList();

            //3. Explicit Loading

            Villa? villaTemp = _appDbContext.Villas.FirstOrDefault(a => a.Id == 1);
            _appDbContext.Entry(villaTemp).Collection(u => u.eminity).Load();

            VillaEminity? villaEminityTemp = _appDbContext.VillaEminity.FirstOrDefault(a => a.Id == 1);
            _appDbContext.Entry(villaEminityTemp).Reference(u => u.Villa).Load();

            List<Villa> villas = _appDbContext.Villas.ToList();

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
