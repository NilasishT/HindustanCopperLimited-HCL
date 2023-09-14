using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Models;

namespace Hindustancopperlimited.Controllers
{
    public class ContractLabourController : Controller
    {
        AdminLoginContext objContext;
        VendorRegistrationContext objContext1;
        UnitContext objContext3;
        CasteContext objContext2;
        CompanyContext objContext6;
        ConstitutionFirmCotext objContext4;
        ItemDescriptionContext objContext5;        
        tbl_ContractLabourContext objtbl_ContractLabour;

        CONTRACT_WORK_ORDERContext objContext7 = new CONTRACT_WORK_ORDERContext();

        public ContractLabourController()
        {
            objContext = new AdminLoginContext();
            objContext1 = new VendorRegistrationContext();
            objContext3 = new UnitContext();
            objContext2 = new CasteContext();
            objContext4 = new ConstitutionFirmCotext();

            objContext5 = new ItemDescriptionContext();

            objContext6 = new CompanyContext();
            
            objtbl_ContractLabour = new tbl_ContractLabourContext();

        }

        //
        // GET: /ContractLabour/

        public ActionResult Index()
        {
            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "strUnitCode", "strUnitCode");
            var workOrderDetails = objContext7.vw_lpmp_workorderlist_year_month.ToList();
            return View(workOrderDetails);
            //var vendrreg = objtbl_ContractLabour.tbl_ContractLabours.ToList();
            //ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "strUnitCode", "strUnitCode");
            //return View(vendrreg);
        }

        [HttpPost]
        public ActionResult Index( FormCollection frm)
        {

            var vendrreg = objContext7.vw_lpmp_workorderlist_year_month.ToList();
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
