using ASP_Web_Application_MVC.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP_Web_Application_MVC.Controllers
{
    [CustomFilter]
    // [HandleError]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 100)]
        public ActionResult Index()
        {
            // throw new Exception("This is Unhandle Exception....");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}