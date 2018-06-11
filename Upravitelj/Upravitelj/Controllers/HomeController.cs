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
            if (!ModelState.IsValid)
            {
                return View(Login);
            }
            return View();
        }


        // GET: Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Registracija()
        {

            return View(Registracija);
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Registracija(RegistracijaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(Login);
            }
            return View(Registracija);
        }

        // GET: Account/Login
        [HttpGet]
        [AllowAnonymous]
        public ActionResult ZaboravljenaLozinka()
        {

            return View(ZaboravljenaLozinka);
        }

        // POST: Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ZaboravljenaLozinka(ZaboravljenaLozinkaViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(Login);
            }
            return View(ZaboravljenaLozinka);
        }
    }
 }

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

        //CRUD operacije za Arhivu

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("CreateArhiva");
            }
            else

                return View("CreateArhiva");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Arhiva arhiva)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("CreateArhiva", arhiva);
            }
            baza.PopisArhiva.Add(arhiva);
            baza.SaveChanges();
            return new HttpStatusCodeResult(200);
        }

        public ActionResult Edit(int? id)
        {
            Arhiva arhiva;
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            arhiva = baza.PopisArhiva.Find(id);
            if (arhiva == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("EditArhiva", arhiva);
            }
            else

                return View("EditArhiva", arhiva);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_arhiva, naziv, datoteka")] Arhiva arhiva)
        {

            if (!ModelState.IsValid)
            {
                return PartialView("EditArhiva", arhiva);
            }
            Arhiva A = baza.PopisArhiva.Where(
              x => x.id == arhiva.id).SingleOrDefault();

            if (arhiva.id != 0 && Z != null)// update
            {
                baza.Entry(Z).CurrentValues.SetValues(arhiva);
            }
            else
            {
                baza.PopisArhiva.Add(arhiva);
            }
            baza.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("ArhivaView");
        }

        public ActionResult Delete(int id)
        {
            Arhiva arhiva = baza.PopisArhiva.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DeleteArhiva", arhiva);
            }
            else

                return View("DeleteArhiva", arhiva);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            Arhiva A = baza.PopisArhiva.Where(
              x => x.id == id).SingleOrDefault();

            if (A != null)
            {
                baza.PopisArhiva.Remove(A);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("ArhivaView");
        }

        //CRUD operacije za Zgrade

        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("CreateZgrada");
            }
            else

                return View("CreateZgrada");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Zgrada zgrada)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("CreateZgrada", zgrada);
            }
            baza.PopisGradova.Add(zgrada);
            baza.SaveChanges();
            return new HttpStatusCodeResult(200);
        }

        public ActionResult Edit(int? id)
        {
            Zgrada zgrada;
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            zgrada = baza.PopisZgrada.Find(id);
            if (zgrada == null)
            {
                return HttpNotFound();
            }
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("EditZgrada", zgrada);
            }
            else

                return View("EditZgrada", zgrada);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_zgrada, naziv, ulica, grad, broj_stanara")] Zgrada zgrada)
        {

            if (!ModelState.IsValid)
            {
                return PartialView("EditZgrada", zgrada);
            }
            Zgrada Z = baza.PopisZgrada.Where(
              x => x.id == gr.id).SingleOrDefault();

            if (zgrada.id != 0 && Z != null)// update
            {
                baza.Entry(Z).CurrentValues.SetValues(zgrada);
            }
            else
            {
                baza.PopisZgrada.Add(zgrada);
            }
            baza.SaveChanges();
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("ZgradaView");
        }

        public ActionResult Delete(int id)
        {
            Zgrada zgrada = baza.PopisZgrada.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DeleteZgrada", zgrada);
            }
            else

                return View("DeleteZgrada", zgrada);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            Zgrada Z = baza.PopisZgrada.Where(
              x => x.id == id).SingleOrDefault();

            if (G != null)
            {
                baza.PopisZgrada.Remove(Z);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("ZgradaView");
        }
    }
}
