using Services.LibraryServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private ILibraryService _libraryService;

        public HomeController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Library");
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