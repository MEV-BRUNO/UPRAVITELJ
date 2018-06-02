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

        //CRUD operacije
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