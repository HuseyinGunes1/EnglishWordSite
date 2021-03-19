using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bitirme_Projem_BussinesLayer;

namespace Bitirme_Projem_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Test t = new Test();
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