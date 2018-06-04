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

    // HTTP GET: /Financije/Delete/

    public ActionResult Delete(int id)
    {

        Financije financije = financijeRepository.GetFinancije(id);

        if (financije == null)
            return View("NotFound");
        else
            return View(Financije);
    }

    // HTTP POST: /Financije/Delete/

    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Delete(int id, string confirmButton)
    {

        Financije financije = financijeRepository.GetFinancije(id);

        if (Financije == null)
            return View("NotFound");

        financijeRepository.Delete(financije);
        financijeRepository.Save();

        return View("Deleted");
    }

    // GET: /Financije/Create

    public ActionResult Create()
    {

        Financije financije = new Financije()
        {
            EventDate = DateTime.Now.AddDays(7)
        };
        return View(Financije);
    }

    // POST: /Financije/Create

    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Create(Financije financije)
    {

        if (ModelState.IsValid)
        {

            try
            {
                financije.HostedBy = "SomeUser";

                financijeRepository.Add(financije);
                financijeRepository.Save();

                return RedirectToAction("Details", new { id = financije.FinancijeID });
            }
            catch
            {
                ModelState.AddRuleViolations(financije.GetRuleViolations());
            }
        }

        return View(financije);
    }

    // GET: /Financije/Update/

    public ActionResult Update(int id)
    {

        Financije financije = financijeRepository.GetFinancije(id);
        return View(financije);
    }

    //
    // POST: /Financije/Update/

    [AcceptVerbs(HttpVerbs.Post)]
    public ActionResult Update(int id, FormCollection formValues)
    {

        Financije financije = financijeRepository.GetFinancije(id);

        try
        {
            UpdateModel(financije);

            FinancijeRepository.Save();

            return RedirectToAction("Details", new { id = financije.FinancijeID });
        }
        catch
        {
            ModelState.AddRuleViolations(financije.GetRuleViolations());

            return View(financije);
        }
    }

    // GET: /Financije/

    public ActionResult Index()
    {

        var financije = financijeRepository.FindUpcomingFinancije().ToList();
        return View(financije);
    }

    //
    // GET: /Financije/Details/

    public ActionResult Details(int id)
    {

        Financije financije = financijeRepository.GetFinancije(id);

        if (financije == null)
            return View("NotFound");
        else
            return View(financije);
    }
}