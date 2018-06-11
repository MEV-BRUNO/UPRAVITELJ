using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Upravitelj.Models;
using System.Threading.Tasks;


namespace Upravitelj.Controllers
{

    public class PrijavaController : Controller
    {

        // GET: Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(PrijavaViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }


        // GET: Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registracija()
        {

            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registracija(RegistracijaViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }

        // GET: Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ZaboravljenaLozinka()
        {

            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ZaboravljenaLozinka(ZaboravljenaLozinkaViewModel model)
        {
            if (ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }
    }
}