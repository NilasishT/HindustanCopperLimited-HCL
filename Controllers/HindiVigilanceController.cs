using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Data;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Hindustancopperlimited.GlobalClass;
using Hindustancopperlimited.Models;
using Microsoft.Office.Interop.Excel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.OleDb;
using System.Text.RegularExpressions;
using System.Data.Objects;

namespace Hindustancopperlimited.Controllers
{
    public class HindiVigilanceController : Controller
    {

        tbl_mstPageDetailContext dbContext001 = new tbl_mstPageDetailContext();
        tbl_mstDepartmentContext objContext8 = new tbl_mstDepartmentContext();
        //
        // GET: /HindiVigilance/
        //public ActionResult Sustainability()
        //{
        //    return View();
        //}
        public ActionResult vigilance()
        {
            ViewBag.vigilance = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "संरचना और कार्य").FirstOrDefault().strHindiPageDetails;
            return View();
        }

        public ActionResult Status_Complaint()
        {
            return View();
        }
        public ActionResult Notice_Article()
        {
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            var tbl_mst_News = objContext8.tbl_mst_News.Where(x => x.strNewsType == "NOTICE / ARTICLES" && EntityFunctions.TruncateTime(x.dtExpiryDate) >= EntityFunctions.TruncateTime(current)).ToList();
            return View(tbl_mst_News);
        }
        public ActionResult contactUs_Vigilance()
        {
            ViewBag.contactUs_Vigilance = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "VIGILANCE CONTACT US").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        public ActionResult complaint()
        {
            return View();
        }

       public ActionResult HindiProfile_of_CVO_HCL()
        {
            return View();
        }

        public ActionResult Sustainability()
        {
            return View();
        }

    }
}
