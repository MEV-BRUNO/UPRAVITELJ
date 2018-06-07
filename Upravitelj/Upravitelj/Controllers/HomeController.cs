using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Upravitelj.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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
        public ActionResult _Upiti(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
		public ActionResult CreateUpit(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
		public ActionResult DeleteUpit(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
		public ActionResult EditUpit(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
		public ActionResult Upiti(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
    }
}