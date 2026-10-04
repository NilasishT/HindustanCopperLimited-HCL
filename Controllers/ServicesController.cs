using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hindustancopperlimited.Controllers
{
    public class ServicesController : Controller
    {
        [HttpGet]
        public ActionResult TownOptions()
        {
            return View();
        }
        public ActionResult TownAdministration()
        {
            return View();
        }
    }
}
