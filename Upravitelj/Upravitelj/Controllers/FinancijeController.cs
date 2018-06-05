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
    public class FinancijeController : Controller
    {
        private FinancijeBazaPodataka FinancijeBazaPodataka = new FinancijeBazaPodataka();
        int Page_No_Master = 1;

        public ActionResult FinancijeView(string Sorting_Order, string Search_Data, string Filter_Value, int? Page_No)
        {

            ViewBag.CurrentSortOrder = Sorting_Order;
            ViewBag.SortingName = String.IsNullOrEmpty(Sorting_Order) ? "Id_financije" : "";

            ViewBag.Message = "Id_financije";

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


            // List<Grad> Popis = financijeBazaPodataka.GetFinancije().ToList();
            int Size_Of_Page = 4;
            int No_Of_Page = (Page_No ?? 1);
            if (Search_Data == null || Search_Data.Length == 0)
            {

                if (Request.IsAjaxRequest())
                {
                    int noP = (int)Page_No_Master;
                    var Popis2 = financijeBazaPodataka.GetFinancije().ToPagedList(noP, Size_Of_Page);
                    return PartialView("_FinancijeView", Popis2);
                }
                Page_No_Master = No_Of_Page;
                var Popis = financijeBazaPodataka.GetFinancije().ToPagedList(No_Of_Page, Size_Of_Page);
                return View(Popis);
                //return View(Popis);
            }
            else
            {
                Page_No_Master = No_Of_Page;
                var Popis = financijeBazaPodataka.GetFinancije_2(Search_Data).ToPagedList(No_Of_Page, Size_Of_Page);
                if (Request.IsAjaxRequest())
                {
                    return PartialView("_FinancijeView", Popis);
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
                return View("FinancijeDodaj");
            }
            else

                return View("FinancijeDodaj");
        }

        [HttpPost]
        public async Task<ActionResult> Create(Financije st)
        {
            if (!ModelState.IsValid)
            {
                return PartialView("FinancijeDodaj", st);


                // if (Request.IsAjaxRequest())
                //     return PartialView("_CreateKontakt", kont);
                // else
                //     return View("_CreateKontakt", kont);
            }
            Financije stObj = new Financije();
            stObj.id_financije = st.id_financije;
            stObj.id_zgrada = st.id_zgrada;
            stObj.stanje = st.stanje;
            stObj.datum = st.datum;
            string IsSuccess = financijeBazaPodataka.addFinancije(stObj);

            if (!IsSuccess.Equals("OK"))
            {
                ModelState.Clear();
                return PartialView("FinancijeDodaj", st);
            }
            return new HttpStatusCodeResult(200);
        }

        public ActionResult Edit(int id)
        {
            Financije st = new Financije();
            st = financijeBazaPodataka.getFinancijeID(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("FinancijeUredi", st);
            }
            else

                return View("FinancijeUredi", st);
        }
        [HttpPost]
        public ActionResult Edit(Financije st)
        {

            if (!ModelState.IsValid)
            {
                return PartialView("FinancijeUredi", st);


                // if (Request.IsAjaxRequest())
                //     return PartialView("_CreateKontakt", kont);
                // else
                //     return View("_CreateKontakt", kont);
            }
            string IsSuccess = financijeBazaPodataka.updateFinancije(st);

            if (!IsSuccess.Equals("OK"))
            {
                ModelState.Clear();
                return PartialView("FinancijeUredi", st);
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("FinancijeView");
        }

        public ActionResult Delete(int id)
        {
            Financije st = new Financije();
            st = financijeBazaPodataka.getFinancijeID(id);
            if (Request.IsAjaxRequest())
            {
                ViewBag.IsUpdate = false;
                return View("FinancijeObrisi", st);
            }
            else

                return View("FinancijeObrisi", st);
        }

        [HttpPost]
        public ActionResult Delete(Financije st)
        {
            string IsSuccess = financijeBazaPodataka.deleteFinancije(st.id_zgrada);
            if (!IsSuccess.Equals("OK"))
            {
                ModelState.Clear();
                return PartialView("FinancijeObrisi");
            }
            if (Request.IsAjaxRequest())
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }

            return RedirectToAction("FinancijeView");
        }
    }
}