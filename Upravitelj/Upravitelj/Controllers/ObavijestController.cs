using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using Upravitelj.Models;

namespace Upravitelj.Controllers
{
    public class ObavijestController : Controller
    {
        // GET: Obavijest
        public ActionResult Index()
        {
            return View();
        }

        // CRUD oprecije
        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("CreateObavijest");
            }
            else

                return View("CreateObavijest");
        }

        [HttpPost]
        public async Task<ActionResult> Create(Obavijest obavijest)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("CreateObavijest", obavijest);
                
            }
            Obavijest obav = new Obavijest();
            obav.id_obavijest = obavijest.id_obavijest;
            obav.datum = obavijest.datum;
            obav.naslov = obavijest.naslov;
            obav.opis = obavijest.opis;
            obav.dokument = obavijest.dokument;
            obav.slika = obavijest.slika;
            obav.kategorija = obavijest.kategorija;
            obav.vidljiv = obavijest.vidljiv;
            
            string IsSuccess = ObavijestDBHandle.addObavijest(obav);

            if (!IsSuccess.Equals("OK"))
            {
                ModelState.Clear();
                return PartialView("CreateObavijest", obavijest);
            }
            return new HttpStatusCodeResult(200);
        }


        public ActionResult Edit(int id)
        {
            Obavijest obav = new Obavijest();
            obav = ObavijestDBHandle.getObavijestID(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("EditObavijest", obav);
            }
            else

                return View("EditObavijest", obav);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Obavijest obav)
        {

            if (!ModelState.IsValid)
            {
                return PartialView("EditObavijest", obav);

            }
            string IsSuccess = ObavijestDBHandle.updateObavijest(obav);

            if (!IsSuccess.Equals("OK"))
            {
                ModelState.Clear();
                return PartialView("EditObavijest", obav);
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("ObavijestView");
        }
        
        public ActionResult Delete(int id)
        {
            Obavijest obavijest = baza.PopisObavijest.Find(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("DeleteObaviejst", obavijest);
            }
            else

                return View("DeleteObavijest", obavijest);
        }
        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            Obavijest obav = baza.PopisObavijest.Where(
              x => x.id == id).SingleOrDefault();

            if (obav != null)
            {
                baza.PopisObavijest.Remove(obav);
                baza.SaveChanges();
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("ObavijestView");
        }
    }

}