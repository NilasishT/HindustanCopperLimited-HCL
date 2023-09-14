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

namespace Hindustancopperlimited.Controllers
{
    public class HindiVigilanceController : Controller
    {

        tbl_mstPageDetailContext dbContext001 = new tbl_mstPageDetailContext();
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
            ViewBag.Notice_Article = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "नोटिस /आलेख").FirstOrDefault().strHindiPageDetails;
            return View();
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

        public ActionResult Sustainability()
        {
            return View();
        }

    }
}
