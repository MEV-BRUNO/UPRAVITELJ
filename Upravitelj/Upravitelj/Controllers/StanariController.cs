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
    public class StanarController : Controller
    {
        private StanarBazaPodataka stanarBazaPodataka = new StanarBazaPodataka();
        int Page_No_Master = 1;
       
        public ActionResult StanarView(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {

            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Id_stanar" : "";

            ViewBag.Message = "Id_stanar";

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


            // List<Grad> Popis = stanarBazaPodataka.GetStanar().ToList();
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            if (Search_Data == null || Search_Data.Length == 0)
            {

                if (Request.IsAjaxRequest())
                {
                    int noP = (int)Page_No_Master;
                    var Popis2 = stanarBazaPodataka.GetStanar().ToPagedList(noP, Size_Of_Page);
                    return PartialView("_StanarView", Popis2);
                }
                Page_No_Master = No_Of_Page;
                var Popis = stanarBazaPodataka.GetStanar().ToPagedList(No_Of_Page, Size_Of_Page);
                return View(Popis);
                //return View(Popis);
            }
            else
            {
                Page_No_Master = No_Of_Page;
                var Popis = stanarBazaPodataka.GetStanar_2(Search_Data).ToPagedList(No_Of_Page, Size_Of_Page);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_StanarView", Popis);
                }

                return View(Popis);
            }
        }
        //Crudovi
        public ActionResult Create()
        {
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("StanarDodaj");
            }
            else

                return View("StanarDodaj");
        }

        [HttpPost]
        public async Task<ActionResult> Create(Stanar st)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("StanarDodaj", st);


                // if (Request.IsAjaxRequest())
                //     return PartialView("_CreateKontakt", kont);
                // else
                //     return View("_CreateKontakt", kont);
            }
            Stanar stObj = new Stanar();
            stObj.id_stanar = st.id_stanar;
            stObj.Ime_prezime = st.Ime_prezime;
            stObj.id_zgrada = st.id_zgrada;
            stObj.vrsta_korisnika = st.vrsta_korisnika;
            stObj.mob = st.mob;
            stObj.email = st.email;
            stObj.lozinka = st.lozinka;
            stObj.aktivacijski_link = st.aktivacijski_link;
            stObj.aktivan = st.aktivan;
            string IsSuccess = stanarBazaPodataka.addStanar(stObj);

            if (!IsSuccess.Equals("OK"))
            {
                ModelState.Clear();
                return PartialView("StanarDodaj", st);
            }
            return new HttpStatusCodeResult(200);
        }

        public ActionResult Edit(int id)
        {
            Stanar st = new Stanar();
            st = stanarBazaPodataka.getStanarID(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("StanarUredi", st);
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


                // if (Request.IsAjaxRequest())
                //     return PartialView("_CreateKontakt", kont);
                // else
                //     return View("_CreateKontakt", kont);
            }
            string IsSuccess = stanarBazaPodataka.updateStanar(st);

            if (!IsSuccess.Equals("OK"))
            {
                ModelState.Clear();
                return PartialView("StanarUredi", st);
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("StanarView");
        }

        public ActionResult Delete(int id)
        {
            Stanar st = new Stanar();
            st = stanarBazaPodataka.getStanarID(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("StanarObrisi", st);
            }
            else

                return View("StanarObrisi", st);
        }

        [HttpPost]
        public ActionResult Delete(Stanar st)
        {
            string IsSuccess = stanarBazaPodataka.deleteStanar(st.id_zgrada);
            if (!IsSuccess.Equals("OK"))
            {
                ModelState.Clear();
                return PartialView("StanarObrisi");
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("StanarView");
        }
    }
}     
