using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Threading.Tasks;
using Upravitelj.Models;
using PagedList;
namespace Upravitelj.Controllers
{
    public class UpitController : Controller
    {
        private UpitBazaPodataka upitBazaPodataka = new UpitBazaPodataka();
        int Page_No_Master = 1;

        public ActionResult StanarView(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {

            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Id_Upit" : "";

            ViewBag.Message = "Id_Upit";

            ViewBag.FilterValue = Search_Data;
            if (Search_Data != null)
            {
                Page_No = 1;
            }
            else
            {
                Search_Data = Filter_Value;
            }
            ViewBag.CurrentPage = 1;
            if (Page_No != null)
                ViewBag.CurrentPage = Page_No;


            // List<Upit> Popis = UpitBazaPodataka.GetUpit().ToList();
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            if (Search_Data == null || Search_Data.Length == 0)
            {

                if (Request.IsAjaxRequest())
                {
                    int noP = (int)Page_No_Master;
                    var Popis2 = UpitBazaPodataka.GetUpit().ToPagedList(noP, Size_Of_Page);
                    return PartialView("_UpitView", Popis2);
                }
                Page_No_Master = No_Of_Page;
                var Popis = upitBazaPodataka.GetUpit().ToPagedList(No_Of_Page, Size_Of_Page);
                return View(Popis);
                //return View(Popis);
            }
            else
            {
                Page_No_Master = No_Of_Page;
                var Popis = upitBazaPodataka.GetUpit_2(Search_Data).ToPagedList(No_Of_Page, Size_Of_Page);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_UpitView", Popis);
                }

                return View(Popis);
            }
        }
        //Crudovi-uredi
        public ActionResult Edit(int id)
        {
            Upit up = new Upit();
            up = upitBazaPodataka.getUpitID(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("UpitUredi", st);
            }
            else

                return View("StanarUredi", st);
        }
        [HttpPost]
        public ActionResult Edit(Stanar st)
        {

            if (!ModelState.IsValid)
            {
                return PartialView("StanarUredi", st);

            }
            string IsSuccess = upitBazaPodataka.updateUpit(up);

            if (!IsSuccess.Equals("OK"))
            {
                ModelState.Clear();
                return PartialView("UpitUredi", up);
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("UpitView");
        }
        //delete
        public ActionResult Delete(int id)
        {
            Upit up = new Upit();
            up = upitBazaPodataka.getUpitID(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("UpitObrisi", st);
            }
            else

                return View("UpitObrisi", st);
        }

        [HttpPost]
        public ActionResult Delete(Upit up)
        {
            string IsSuccess = upitBazaPodataka.deleteUpit(up.id_upit);
            if (!IsSuccess.Equals("OK"))
            {
                ModelState.Clear();
                return PartialView("UpitObrisi");
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("UpitView");
        }
        //info
        [HttpPost]
        public ActionResult UpitInfo(int id)
        {
            Upit up = baza.Upit.Find(id);


            return View(up);

        }
    }
}