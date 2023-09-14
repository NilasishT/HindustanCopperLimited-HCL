using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Controllers
{
    public class UnitController : BaseController
    {
        //
        // GET: /Unit/
        tbl_MenuMasterContext MC = new tbl_MenuMasterContext();
        UnitContext objContext;

        public UnitController()
        {
            objContext = new UnitContext();
        }



        public ActionResult Create()
        {
                      
            //var menu = MC.tbl_MenuMaster.ToList();
            //return View(menu);
           
            return View(new Unit());

        }


        [HttpPost]
        public ActionResult Create(Unit login)
        {
            objContext.Units.Add(login);
            objContext.SaveChanges();
            return RedirectToAction("Create");
        }

        public ActionResult UnitList()
        {
                         
            //var menu = MC.tbl_MenuMaster.ToList();
            //return View(menu);


            //ViewBag.Fk_intUnitId = new SelectList(objContext.Units.ToList(), "pk_intUnitId", "strUnitName");
            var vendrreg = objContext.Units.ToList();
            return View(vendrreg);

        }



       




        public ActionResult UnitDetails(int id)
        {


            var vendrreg = objContext.Units.ToList();

            //ViewBag.Fk_intUnitId = new SelectList(objContext.Units.Where(x => x.pk_intUnitId == VendorRegistration.Fk_intUnitId).ToList(), "pk_intUnitId", "strUnitName");

            return View(vendrreg);
        }

    }
}
