using L7_L8.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L7_L8.Controllers
{
    public class HomeController : Controller
    {
        public IDataService DataService { get; set; }
        public HomeController(IDataService dataService)
        {
            DataService = dataService;
        }
        
        public ActionResult Index()
        {
            var parties = DataService.GetAllParties();
            return View("Index", parties);
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