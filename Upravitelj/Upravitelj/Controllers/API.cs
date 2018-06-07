using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Mvc;
using Upravitelj.Models;

namespace Upravitelj.Controllers
{
    public class API : Controller
    {
        private UpitiDBHandle upitiDBHandle = new UpitiDBHandle();
        public JsonResult GetAllUpiti()
        {
            return Json(upitiDBHandle.GetUpite().ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
