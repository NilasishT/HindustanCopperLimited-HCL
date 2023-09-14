using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Models;

namespace Hindustancopperlimited.Controllers
{
    public class AveragePaymentController : Controller
    {
    
        UnitContext objContext3;
        CONTRACT_WORK_ORDERContext objContext7 = new CONTRACT_WORK_ORDERContext();
        public AveragePaymentController()
        {
           
            objContext3 = new UnitContext();


        }
        //
        // GET: /AveragePayment/

        public ActionResult Index()
        {

            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "strUnitCode", "strUnitCode");
            var workOrderDetails = objContext7.vw_AveragePaymentReport.ToList();
            return View(workOrderDetails);
        }


        [HttpPost]
        public ActionResult Index(FormCollection frm)
        {

            var vendrreg = objContext7.vw_AveragePaymentReport.ToList();
            if (frm["Fk_intUnitId"] != "")
            {
                string UnitId = frm["Fk_intUnitId"];
                vendrreg = vendrreg.Where(x => x.strUnitCode == UnitId).ToList();
            }
            if (frm["strMonth"] != "")
            {
                vendrreg = vendrreg.Where(x => x.MNTH == frm["strMonth"]).ToList();
            }
            if (frm["strYear"] != "")
            {
                vendrreg = vendrreg.Where(x => x.YEAR == frm["strYear"]).ToList();
            }
            ViewBag.strMonth = frm["strMonth"];
            ViewBag.strYear = frm["strYear"];
            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "strUnitCode", "strUnitCode", frm["Fk_intUnitId"]);
            return View(vendrreg);
        }
    }
}
