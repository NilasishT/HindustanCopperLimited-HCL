using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Hindustancopperlimited.GlobalClass;
using System.Web.Security;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Security.Principal;
using System.Web.Routing;
using System.Data.Entity.Validation;
using Microsoft.Office.Interop.Excel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.OleDb;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;



using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using NPOI.HSSF.UserModel;
using System.Data.Entity;

namespace Hindustancopperlimited.Controllers
{
    public class VendorController : BaseController
    {
        //
        // GET: /Vendor/
        VendorRegistrationContext objContext = new VendorRegistrationContext();
        VendorsNewContext objContextNew = new VendorsNewContext();
        UnitContext objContext3 = new UnitContext();
        CasteContext objContext2 = new CasteContext();
        CompanyContext objContext6 = new CompanyContext();
        ConstitutionFirmCotext objContext4 = new ConstitutionFirmCotext();
        ItemDescriptionContext objContext5 = new ItemDescriptionContext();
        CONTRACT_WORK_ORDERContext objContext7= new CONTRACT_WORK_ORDERContext();
        CONTRACT_WORKMAN_DETAILSContext objContext8 = new CONTRACT_WORKMAN_DETAILSContext();
        CONTRACT_WORKMAN_WAGESContext objContext9 = new CONTRACT_WORKMAN_WAGESContext();
        CONTRACT_WORKMAN_WORKContext objContext10 = new CONTRACT_WORKMAN_WORKContext();
        tbl_mstDepartmentContext objContextDepartment = new tbl_mstDepartmentContext();
        tbl_mst_Serviceprovidercontext objprovider = new tbl_mst_Serviceprovidercontext();
        tbl_mst_countrycontext objcountry = new tbl_mst_countrycontext();
        tbl_mst_statecontext objstate = new tbl_mst_statecontext();
        BillTrackingContext objBillTracking = new BillTrackingContext();

        public ActionResult Dataview()
        {
            var vendorId = Session["VendorCode"];
            var vendrreg = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorId).ToList();
            //var vendrreg = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorId).ToList();
            return View(vendrreg);

        }


        public ActionResult Dataviewnew()
        {
            var vendorId = Session["VendorCode"];
          //var vendrreg = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorId).ToList();
            var vendrreg = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorId).ToList();
            return View(vendrreg);

        }


        public ActionResult DataViewDetails(int id)
        {
            
            var vendorId = Session["VendorCode"];
            VendorRegistration VendorRegistration = objContext.VendorRegistrations.Single(x => x.strVendorRegistrationID == vendorId);
            ViewBag.dtApplicationDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            VendorRegistration.dtApplicationDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            ViewBag.hidFk_intDepartment = VendorRegistration.Fk_intDepartment;
            var AppliedFk_intUnitId = VendorRegistration.Fk_intUnitId;
            ViewBag.hidFk_intUnitId = VendorRegistration.Fk_intUnitId;
            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
            ViewBag.intfk_CasteID = new SelectList(objContext2.Castes.ToList(), "pk_intCasteId", "strCasteName", VendorRegistration.intfk_CasteID);
            ViewBag.int_fk_CompanyStatusID = new SelectList(objContext6.Companys.ToList(), "pk_CompanyStatusID", "strCompanyStatusName", VendorRegistration.int_fk_CompanyStatusID);
            ViewBag.fk_intConstitutionFirmID = new SelectList(objContext4.ConstitutionFirms.ToList(), "pk_intConstitutionFirmID", "strConstitutionFirm", VendorRegistration.fk_intConstitutionFirmID);
            ViewBag.strRegistrationApplied = new SelectList(objContext5.ItemDescriptions.ToList(), "Pk_intItemDescription", "strItemDescriptionName");
            ViewBag.hidstrRegistrationApplied = VendorRegistration.strRegistrationApplied;
            TempData["PanNo"] = VendorRegistration.strVerify;
            ViewBag.Fk_intDepartment = new SelectList(objContextDepartment.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");

            VendorRegistration.strFinancialYear1 = "2016-2017";
            VendorRegistration.strFinancialYear2 = "2015-2016";
            VendorRegistration.strFinancialYear3 = "2014-2015";
            return View(VendorRegistration);
        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DataViewDetails(VendorRegistration Registration, FormCollection frm)
        {

           
            ViewBag.Fk_intDepartment = new SelectList(objContextDepartment.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");            
            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
            ViewBag.intfk_CasteID = new SelectList(objContext2.Castes.ToList(), "pk_intCasteId", "strCasteName", Registration.intfk_CasteID);
            ViewBag.int_fk_CompanyStatusID = new SelectList(objContext6.Companys.ToList(), "pk_CompanyStatusID", "strCompanyStatusName", Registration.int_fk_CompanyStatusID);
            ViewBag.fk_intConstitutionFirmID = new SelectList(objContext4.ConstitutionFirms.ToList(), "pk_intConstitutionFirmID", "strConstitutionFirm", Registration.fk_intConstitutionFirmID);
            ViewBag.strRegistrationApplied = new SelectList(objContext5.ItemDescriptions.ToList(), "Pk_intItemDescription", "strItemDescriptionName");
            

            if (ModelState.IsValid)
            {

                if (Session["VendorCode"] != null)
                {

                    HttpPostedFileBase strConstitutionofthefirmfile1 = Request.Files["strConstitutionofthefirmfile1"];
                    HttpPostedFileBase strConstitutionofthefirmfile2 = Request.Files["strConstitutionofthefirmfile2"];
                    HttpPostedFileBase strMSMEDocument = Request.Files["strMSMEDocument"];
                    HttpPostedFileBase strCSTRegistrationdocument = Request.Files["strCSTRegistrationdocument"];
                    HttpPostedFileBase strST_VATRegistrationdocument = Request.Files["strST_VATRegistrationdocument"];
                    HttpPostedFileBase strExciseControldocument = Request.Files["strExciseControldocument"];
                    HttpPostedFileBase strTradeLicencedocument = Request.Files["strTradeLicencedocument"];
                    HttpPostedFileBase strServiceTaxRegistrationdocument = Request.Files["strServiceTaxRegistrationdocument"];
                    HttpPostedFileBase strPANNodocument = Request.Files["strPANNodocument"];
                    HttpPostedFileBase strMachineryDocument = Request.Files["strMachineryDocument"];
                    HttpPostedFileBase strISOaccrediteddocument = Request.Files["strISOaccrediteddocument"];
                    HttpPostedFileBase strBalancesheetandProfitAndLoss = Request.Files["strBalancesheetandProfitAndLoss"];
                    HttpPostedFileBase strMajorPurchaseOrders = Request.Files["strMajorPurchaseOrders"];
                    HttpPostedFileBase strFinancialYearDoc1 = Request.Files["strFinancialYearDoc1"];
                    HttpPostedFileBase strFinancialYearDoc2 = Request.Files["strFinancialYearDoc2"];
                    HttpPostedFileBase strFinancialYearDoc3 = Request.Files["strFinancialYearDoc3"];



                    HttpPostedFileBase strReferenceUpload1 = Request.Files["strReferenceUpload1"];
                    HttpPostedFileBase strReferenceUpload2 = Request.Files["strReferenceUpload2"];
                    HttpPostedFileBase strReferenceUpload3 = Request.Files["strReferenceUpload3"];
                    HttpPostedFileBase strReferenceUpload4 = Request.Files["strReferenceUpload4"];
                    HttpPostedFileBase strReferenceUpload5 = Request.Files["strReferenceUpload5"];

                    if (strConstitutionofthefirmfile1.ContentLength>0)
                    {

                        var fileExtension = Path.GetExtension(strConstitutionofthefirmfile1.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "CONSTITUTIONOFTHEFIRMFILE1";
                        var path = Path.Combine(Server.MapPath("~/Constitutionofthefirm"), AutoGenFileName + fileExtension);
                        strConstitutionofthefirmfile1.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Constitutionofthefirm/" + newpath;
                        Registration.strConstitutionofthefirmfile1 = imagepath;
                    }

                    if (strConstitutionofthefirmfile2.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strConstitutionofthefirmfile2.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "CONSTITUTIONOFTHEFIRMFILE2";
                        var path = Path.Combine(Server.MapPath("~/Constitutionofthefirm"), AutoGenFileName + fileExtension);
                        strConstitutionofthefirmfile2.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Constitutionofthefirm/" + newpath;
                        Registration.strConstitutionofthefirmfile2 = imagepath;
                    }

                    if (strMSMEDocument.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strMSMEDocument.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "MSMEDOCUMENT";
                        var path = Path.Combine(Server.MapPath("~/Constitutionofthefirm"), AutoGenFileName + fileExtension);
                        strMSMEDocument.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Constitutionofthefirm/" + newpath;
                        Registration.strMSMEDocument = imagepath;
                    }

                    if (strCSTRegistrationdocument.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strCSTRegistrationdocument.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "CSTREGISTRATIONDOCUMENT";
                        var path = Path.Combine(Server.MapPath("~/StaturyRegistrationDetails"), AutoGenFileName + fileExtension);
                        strCSTRegistrationdocument.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/StaturyRegistrationDetails/" + newpath;
                        Registration.strCSTRegistrationdocument = imagepath;
                    }

                    if (strST_VATRegistrationdocument.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strST_VATRegistrationdocument.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "VATREGISTRATIONDOCUMENT";
                        var path = Path.Combine(Server.MapPath("~/StaturyRegistrationDetails"), AutoGenFileName + fileExtension);
                        strST_VATRegistrationdocument.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/StaturyRegistrationDetails/" + newpath;
                        Registration.strST_VATRegistrationdocument = imagepath;
                    }

                    if (strExciseControldocument.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strExciseControldocument.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "EXCISECONTROLDOCUMENT";
                        var path = Path.Combine(Server.MapPath("~/StaturyRegistrationDetails"), AutoGenFileName + fileExtension);
                        strExciseControldocument.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/StaturyRegistrationDetails/" + newpath;
                        Registration.strExciseControldocument = imagepath;
                    }

                    if (strTradeLicencedocument.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strTradeLicencedocument.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TRADELICENCEDOCUMENT";
                        var path = Path.Combine(Server.MapPath("~/StaturyRegistrationDetails"), AutoGenFileName + fileExtension);
                        strTradeLicencedocument.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/StaturyRegistrationDetails/" + newpath;
                        Registration.strTradeLicencedocument = imagepath;
                    }

                    if (strServiceTaxRegistrationdocument.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strServiceTaxRegistrationdocument.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "SERVICETAXREGISTRATIONDOCUMENT";
                        var path = Path.Combine(Server.MapPath("~/StaturyRegistrationDetails"), AutoGenFileName + fileExtension);
                        strServiceTaxRegistrationdocument.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/StaturyRegistrationDetails/" + newpath;
                        Registration.strServiceTaxRegistrationdocument = imagepath;
                    }

                    if (strPANNodocument.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strPANNodocument.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "PANNODOCUMENT";
                        var path = Path.Combine(Server.MapPath("~/StaturyRegistrationDetails"), AutoGenFileName + fileExtension);
                        strPANNodocument.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/StaturyRegistrationDetails/" + newpath;
                        Registration.strPANNodocument = imagepath;
                    }
                    if (strMachineryDocument.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strMachineryDocument.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "MACHINERYDOCUMENT";
                        var path = Path.Combine(Server.MapPath("~/Technical"), AutoGenFileName + fileExtension);
                        strMachineryDocument.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Technical/" + newpath;
                        Registration.strMachineryDocument = imagepath;
                    }
                    if (strISOaccrediteddocument.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strISOaccrediteddocument.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "ISOACCREDITEDDOCUMENT";
                        var path = Path.Combine(Server.MapPath("~/Technical"), AutoGenFileName + fileExtension);
                        strISOaccrediteddocument.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Technical/" + newpath;
                        Registration.strISOaccrediteddocument = imagepath;
                    }

                 

                    if (strFinancialYearDoc1.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strFinancialYearDoc1.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "FINANCIALYEARDOC1";
                        var path = Path.Combine(Server.MapPath("~/Financial"), AutoGenFileName + fileExtension);
                        strFinancialYearDoc1.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Financial/" + newpath;
                        Registration.strFinancialYearDoc1 = imagepath;
                    }

                    if (strFinancialYearDoc2.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strFinancialYearDoc2.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "FINANCIALYEARDOC2";
                        var path = Path.Combine(Server.MapPath("~/Financial"), AutoGenFileName + fileExtension);
                        strFinancialYearDoc2.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Financial/" + newpath;
                        Registration.strFinancialYearDoc2 = imagepath;
                    }

                    if (strFinancialYearDoc3.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strFinancialYearDoc3.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "FINANCIALYEARDOC3";
                        var path = Path.Combine(Server.MapPath("~/Financial"), AutoGenFileName + fileExtension);
                        strFinancialYearDoc3.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Financial/" + newpath;
                        Registration.strFinancialYearDoc3 = imagepath;
                    }









                    if (strReferenceUpload1.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strReferenceUpload1.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "REFERENCEUPLOAD1";
                        var path = Path.Combine(Server.MapPath("~/Financial"), AutoGenFileName + fileExtension);
                        strReferenceUpload1.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Financial/" + newpath;
                        Registration.strReferenceUpload1 = imagepath;
                    }






                    if (strReferenceUpload2.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strReferenceUpload2.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "REFERENCEUPLOAD2";
                        var path = Path.Combine(Server.MapPath("~/Financial"), AutoGenFileName + fileExtension);
                        strReferenceUpload2.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Financial/" + newpath;
                        Registration.strReferenceUpload2 = imagepath;
                    }






                    if (strReferenceUpload3.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strReferenceUpload3.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "REFERENCEUPLOAD3";
                        var path = Path.Combine(Server.MapPath("~/Financial"), AutoGenFileName + fileExtension);
                        strReferenceUpload3.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Financial/" + newpath;
                        Registration.strReferenceUpload3 = imagepath;
                    }





                    if (strReferenceUpload4.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strReferenceUpload4.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "REFERENCEUPLOAD4";
                        var path = Path.Combine(Server.MapPath("~/Financial"), AutoGenFileName + fileExtension);
                        strReferenceUpload4.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Financial/" + newpath;
                        Registration.strReferenceUpload4 = imagepath;
                    }





                    if (strReferenceUpload5.ContentLength > 0)
                    {
                        var fileExtension = Path.GetExtension(strReferenceUpload5.FileName);
                        var AutoGenFileName = Registration.Pk_intNewVendorRegistrationID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "REFERENCEUPLOAD5";
                        var path = Path.Combine(Server.MapPath("~/Financial"), AutoGenFileName + fileExtension);
                        strReferenceUpload5.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Financial/" + newpath;
                        Registration.strReferenceUpload5 = imagepath;
                    }




                    Registration.strRegistrationApplied = frm["hidstrRegistrationApplied"];                    
                    Registration.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    Registration.dtApplicationDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    Registration.Fk_intUnitId = frm["hidFk_intUnitId"];
                    Registration.Fk_intDepartment = frm["hidFk_intDepartment"];
                    Registration.strActive = "NO";
                    Registration.strPending = "NO";
                    Registration.strVerify = "NO";

                    objContext.Entry(Registration).State = EntityState.Modified;
                    objContext.SaveChanges();

                    VendorLoginContext objVendorLoginContext = new VendorLoginContext();
                    var checkobjVendorLogin = objVendorLoginContext.VendorLogin.Where(x => x.strUserName == Registration.strVendorRegistrationID).FirstOrDefault();
                    if (checkobjVendorLogin != null)
                    {
                        if (frm["hidFk_intDepartment"] != "" && frm["hidFk_intDepartment"] != null)
                        {
                            checkobjVendorLogin.strusertype = "CONTRACTOR";
                        }
                        else
                        {
                            checkobjVendorLogin.strusertype = "VENDOR";
                        }
                        //if (frm["ifManpowerSupply"] == "Yes")
                        //{
                        //    checkobjVendorLogin.strusertype = "CONTRACTOR";
                        //}
                        //else
                        //{
                        //    checkobjVendorLogin.strusertype = "VENDOR";
                        //}
                        checkobjVendorLogin.dtUpdatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        objVendorLoginContext.Entry(checkobjVendorLogin).State = EntityState.Modified;
                        objVendorLoginContext.SaveChanges();
                    }



                    Utility.SendEmailForVendor(Registration.strEmail, "Your data has been sent successfully", "Your data has been sent successfully. After completion of your verification you will get your details information by mail.");
                    if (frm["hidFk_intUnitId"].Split(',').Count() > 1)
                    {
                        Utility.SendEmailForVendor("reddy_pks@hindustancopper.com", "Vendor approval", "The vendor is : " + Registration.strVendorRegistrationID + " waiting for your approval.");
                    }
                    ViewBag.Message = "Your status is now under approval.";
                    ViewBag.hidFk_intDepartment = Registration.Fk_intDepartment;
                    return View(Registration);



                }

                else
                {
                    return RedirectToAction("Login", "VendorRegistration");
                }
            }

            string messages = string.Join("; ", ModelState.Values
                                       .SelectMany(x => x.Errors)
                                       .Select(x => x.ErrorMessage));
            ViewBag.Message = messages;

            if (Registration.Pk_intNewVendorRegistrationID == 437)
            {
                Utility.SendEmailForVendor("bhashkar.ghosh@dfssolutions.com", "Error List", messages);
            }

            return View(Registration);

        }

        public ActionResult WorkmanDetails()
        {
            //int Id = Convert.ToInt32(Session["UserID"]);
            string vendorCode = Session["VendorCode"].ToString();
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            var workManDetails = objContext8.CONTRACT_WORKMAN_DETAILS.Where(x=>x.CONTRACTORID==Id).ToList();
            return View(workManDetails);
        }

        public ActionResult AddEmployee()
        {
            return View(new CONTRACT_WORKMAN_DETAILS());
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddEmployee(CONTRACT_WORKMAN_DETAILS CONTRACT_WORKMAN_DETAILS)
        {
            if (ModelState.IsValid)
            {

                string vendorCode = Session["VendorCode"].ToString();
                //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;


                int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
                CONTRACT_WORKMAN_DETAILS.CREATIONTIME = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                CONTRACT_WORKMAN_DETAILS.CONTRACTORID = Id;
                objContext8.CONTRACT_WORKMAN_DETAILS.Add(CONTRACT_WORKMAN_DETAILS);
                objContext8.SaveChanges();
                ViewBag.Message = "Data Save Successfully.";
                ModelState.Clear();
            }

            return View();
        }

        [HttpPost]
        public ActionResult checkPAN(string PANNO)
        {
            var already = "No";
            int checkData = objContext8.CONTRACT_WORKMAN_DETAILS.Where(x => x.PANNO == PANNO).ToList().Count();
            if (checkData > 0)
            {
                already = "Yes";
            }
            return Json(new { already = already });
        }



        public ActionResult EditEmployee(int id)
        {

            var CONTRACT_WORK_ORDER = objContext8.CONTRACT_WORKMAN_DETAILS.Single(x => x.ID == id);            
            return View(CONTRACT_WORK_ORDER);
        }

        [HttpPost]
        public ActionResult EditEmployee(CONTRACT_WORKMAN_DETAILS CONTRACT_WORKMAN_DETAILS)
        {   //SHOUMYA
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;

           //END
            CONTRACT_WORKMAN_DETAILS.MODIFCATIONTIME = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            //CONTRACT_WORKMAN_DETAILS.CONTRACTORID = Convert.ToInt32(Session["UserID"]);
            //SHOUMYA
            CONTRACT_WORKMAN_DETAILS.CONTRACTORID = Id;
            //END
            objContext8.Entry(CONTRACT_WORKMAN_DETAILS).State = EntityState.Modified;
            objContext8.SaveChanges();
            ViewBag.Message = "Data updated Successfully.";
            return View(CONTRACT_WORKMAN_DETAILS);
        }

        // 12th May 

        public ActionResult AddWorkOrder()
        {
            TempData["notapproved"] = "";
            string vendorCode = Session["VendorCode"].ToString();
            //var vendordetail = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault();
            var vendordetail = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault();
            int Id = vendordetail.Pk_intNewVendorRegistrationID;
            string verify = vendordetail.strVerify;
            ViewBag.WO_UNIT = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
            if (verify != "YES")
            {
                TempData["notapproved"] = "Yes";
                ViewBag.Message = "You are not approved by admin.";
            }
            return View(new CONTRACT_WORK_ORDER());
            
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddWorkOrder(CONTRACT_WORK_ORDER CONTRACT_WORK_ORDER, HttpPostedFileBase WO_FILE)
        {
            string vendorCode = Session["VendorCode"].ToString();
            //var vendordetail=objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault();
            var vendordetail = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault();
            int Id = vendordetail.Pk_intNewVendorRegistrationID;
            

            ViewBag.WO_UNIT = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
            //Shoumya
            
            if (CONTRACT_WORK_ORDER.DATEOFCOMMENCEMENT < CONTRACT_WORK_ORDER.DATEOFCOMPLETIONWORK)
            {
                if (WO_FILE != null)
                {   //Shoumya
                    //var fileName = Path.GetExtension(WO_FILE.FileName);
                    //var guid = Guid.NewGuid().ToString();
                    //var path = Path.Combine(Server.MapPath("~/WorkOrder"), guid + fileName);
                    var fileExtension = Path.GetExtension(WO_FILE.FileName);
                    var AutoGenFileName = CONTRACT_WORK_ORDER.CONTRACTORID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "WorkOrder";
                    var path = Path.Combine(Server.MapPath("~/WorkOrder/"), AutoGenFileName + fileExtension);

                    WO_FILE.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/WorkOrder/" + newpath;
                    CONTRACT_WORK_ORDER.WO_FILE = imagepath;
                }

                CONTRACT_WORK_ORDER.CREATIONDATE = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                CONTRACT_WORK_ORDER.CREATEDBY = Convert.ToString(Session["VendorCode"]);
                CONTRACT_WORK_ORDER.CONTRACTORID = Id;
                objContext7.CONTRACT_WORK_ORDER.Add(CONTRACT_WORK_ORDER);
                objContext7.SaveChanges();
                ViewBag.Message = "Data Saved Successfully.";
                ModelState.Clear();
            }
                else
            {
                ViewBag.Message = "Date of Commencement cannot be less than Date of Completion Work.";
                
            }
                //ModelState.Clear();
                return View();
            }
        
        
    



        // End part

        public ActionResult AddWorkList()
        {
            //int Id = Convert.ToInt32(Session["UserID"]);
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            var CONTRACT_WORK_ORDER = objContext7.CONTRACT_WORK_ORDER.Where(x=>x.CONTRACTORID==Id).ToList();
            return View(CONTRACT_WORK_ORDER);
        }


        public ActionResult EditWorkOrder(int id)
        {

            var CONTRACT_WORK_ORDER = objContext7.CONTRACT_WORK_ORDER.Single(x => x.ID == id);
            ViewBag.WO_UNIT = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName", CONTRACT_WORK_ORDER.WO_UNIT);
            //Shoumya
            ViewBag.strFile = CONTRACT_WORK_ORDER.WO_FILE;
            ViewBag.hdWO_FILE = CONTRACT_WORK_ORDER.WO_FILE;
            return View(CONTRACT_WORK_ORDER);
        }

        

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditWorkOrder(CONTRACT_WORK_ORDER CONTRACT_WORK_ORDER, HttpPostedFileBase WO_FILE)
        {
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            ViewBag.WO_UNIT = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName", CONTRACT_WORK_ORDER.WO_UNIT);
            //Shoumya
            if (CONTRACT_WORK_ORDER.DATEOFCOMMENCEMENT < CONTRACT_WORK_ORDER.DATEOFCOMPLETIONWORK)
            {
             
            if (WO_FILE != null)
            {
                //Shoumya
                //var fileName = Path.GetExtension(WO_FILE.FileName);
                //var guid = Guid.NewGuid().ToString();
                //var path = Path.Combine(Server.MapPath("~/WorkOrder"), guid + fileName);
                var fileExtension = Path.GetExtension(WO_FILE.FileName);
                var AutoGenFileName = CONTRACT_WORK_ORDER.CONTRACTORID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "WorkOrderPhoto";
                var path = Path.Combine(Server.MapPath("~/WorkOrder/"), AutoGenFileName + fileExtension);
                   
                WO_FILE.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                string imagepath = "~/WorkOrder/" + newpath;
                CONTRACT_WORK_ORDER.WO_FILE = imagepath;
            }
            CONTRACT_WORK_ORDER.MODIFICATIONDATE = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            CONTRACT_WORK_ORDER.MODIFIEDBY = Convert.ToString(Session["VendorCode"]);
            CONTRACT_WORK_ORDER.CONTRACTORID = Id;

            objContext7.Entry(CONTRACT_WORK_ORDER).State = EntityState.Modified;
            objContext7.SaveChanges();

            ViewBag.Message = "Data updated Successfully.";
            }
                  else
            {
                ViewBag.Message = "Date of Commencement cannot be less than Date of Completion Work.";
                
            }
                

            return View(CONTRACT_WORK_ORDER);
        }

        public ActionResult WorkmanDetailsforUploadingPhoto()
        {

            //int Id = Convert.ToInt32(Session["UserID"]);
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            var workManDetails = objContext8.CONTRACT_WORKMAN_DETAILS.Where(x=>x.CONTRACTORID==Id).ToList();
            return View(workManDetails);
        }

        public ActionResult PhotoUpload(int id)
        {
            var workManDetails = objContext8.CONTRACT_WORKMAN_DETAILS.Single(x => x.ID == id);
            return View(workManDetails);
        }
        
        [HttpPost]
        public ActionResult PhotoUpload(int id, CONTRACT_WORKMAN_DETAILS CONTRACT_WORKMAN_DETAILS,HttpPostedFileBase PHOTO)
        {
           
                if (PHOTO != null)
                {




                    var WorkmanDetails = objContext8.CONTRACT_WORKMAN_DETAILS.Where(x => x.ID == id).FirstOrDefault();
                    //Shoumya
                    //var fileName = Path.GetExtension(PHOTO.FileName);
                    //var guid = Guid.NewGuid().ToString();
                    //var path = Path.Combine(Server.MapPath("~/WorkmanPhoto/"), guid + fileName);


                    var fileExtension = Path.GetExtension(PHOTO.FileName);

                    var AutoGenFileName = CONTRACT_WORKMAN_DETAILS.CONTRACTORID + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "WorkmanPhoto";
                    var path = Path.Combine(Server.MapPath("~/WorkmanPhoto/"), AutoGenFileName + fileExtension);
                   
                    
                    PHOTO.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/WorkmanPhoto/" + newpath;
                    WorkmanDetails.PHOTO = imagepath;
                    objContext8.Entry(WorkmanDetails).State = EntityState.Modified;
                   
                        objContext8.SaveChanges();
                   
                    }
                        ViewBag.Message = "Photo Uploaded Successfully.";
                        ModelState.Clear();
            
                        return View();
        }


        public ActionResult WorkmanListforTermination()
        {
            //int Id = Convert.ToInt32(Session["UserID"]);
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            var workManDetails = objContext8.CONTRACT_WORKMAN_DETAILS.Where(x=>x.CONTRACTORID==Id).ToList();
            return View(workManDetails);
        }

        public ActionResult WorkmanTermination(int id)
        {
            var workManDetails = objContext8.CONTRACT_WORKMAN_DETAILS.Single(x => x.ID == id);
            return View(workManDetails);
        }

        [HttpPost]
        public ActionResult WorkmanTermination(int id, CONTRACT_WORKMAN_DETAILS CONTRACT_WORKMAN_DETAILS, string btnAction)
        {
            var workManDetails = objContext8.CONTRACT_WORKMAN_DETAILS.Single(x => x.ID == id);
            workManDetails.DATEOFTERMINATION = CONTRACT_WORKMAN_DETAILS.DATEOFTERMINATION;
            workManDetails.REASONS = CONTRACT_WORKMAN_DETAILS.REASONS;
            if (btnAction == "Termination")
            {
            workManDetails.ISTERMINATION ="Y";
            }
            else{
            workManDetails.ISTERMINATION = "N";
            }
            objContext8.Entry(workManDetails).State = EntityState.Modified;
            
            objContext8.SaveChanges();
            ViewBag.Message = "Data updated Successfully.";
            ModelState.Clear();
            return View();
           
        }

        public ActionResult WorkmanWages()
        {
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;

            var workManDetails = objContext9.vw_CONTRACT_WORKMAN_WAGES.Where(x=>x.CONTRACTORID==Id).ToList();
            return View(workManDetails);
        }

        public ActionResult AddWorkmanWages()
        {
            //int Id = Convert.ToInt32(Session["UserID"]);
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            ViewBag.WORKMANID = new SelectList(objContext8.CONTRACT_WORKMAN_DETAILS.Where(x=>x.CONTRACTORID==Id && (x.ISTERMINATION!="Y" || x.ISTERMINATION==null)).ToList(), "ID", "NAME");
            ViewBag.WORKORDERID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == Id && x.APPROVED == "Y").ToList(), "ID", "NAMEOFTHEWORK");
            ViewBag.LOCATIONID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == Id && x.APPROVED == "Y").ToList(), "ID", "LOCATIONOFWORK");
            return View();
        }


        [HttpPost]
        public ActionResult AddWorkmanWages(CONTRACT_WORKMAN_WAGES CONTRACT_WORKMAN_WAGES)
        {

            //int Id = Convert.ToInt32(Session["UserID"]);
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            ViewBag.WORKMANID = new SelectList(objContext8.CONTRACT_WORKMAN_DETAILS.Where(x => x.CONTRACTORID == Id && (x.ISTERMINATION != "Y" || x.ISTERMINATION == null)).ToList(), "ID", "NAME");
            ViewBag.WORKORDERID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == Id && x.APPROVED == "Y").ToList(), "ID", "NAMEOFTHEWORK");
            ViewBag.LOCATIONID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == Id && x.APPROVED == "Y").ToList(), "ID", "LOCATIONOFWORK");

            CONTRACT_WORKMAN_WAGES.CREATIONDATE = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            CONTRACT_WORKMAN_WAGES.CONTRACTORID = Id;
            objContext9.CONTRACT_WORKMAN_WAGES.Add(CONTRACT_WORKMAN_WAGES);
            objContext9.SaveChanges();
            ViewBag.Message = "Data Saved Successfully.";
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult GetWorkman(int WORKORDERID)
        {

            var workman = objContext10.vw_CONTRACT_WORKMAN_WORK.Where(x => x.WorkorderId == WORKORDERID).ToList();
            return Json(new { Workman = workman });
        }



        public ActionResult EditWorkmanWages(int id)
        {
            var workManDetails = objContext9.CONTRACT_WORKMAN_WAGES.Single(x => x.ID == id);
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            ViewBag.WORKMANID = new SelectList(objContext8.CONTRACT_WORKMAN_DETAILS.Where(x => x.CONTRACTORID == Id && (x.ISTERMINATION != "Y" || x.ISTERMINATION == null)).ToList(), "ID", "NAME", workManDetails.WORKMANID);
            ViewBag.WORKORDERID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == Id && x.APPROVED == "Y").ToList(), "ID", "NAMEOFTHEWORK", workManDetails.WORKORDERID);
            ViewBag.LOCATIONID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == Id && x.APPROVED == "Y").ToList(), "ID", "LOCATIONOFWORK", workManDetails.LOCATIONID);           
            return View(workManDetails);
        }


        [HttpPost]
        public ActionResult EditWorkmanWages(int id, CONTRACT_WORKMAN_WAGES CONTRACT_WORKMAN_WAGES)
        {
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            ViewBag.WORKMANID = new SelectList(objContext8.CONTRACT_WORKMAN_DETAILS.Where(x => x.CONTRACTORID == Id && (x.ISTERMINATION != "Y" || x.ISTERMINATION == null)).ToList(), "ID", "NAME", CONTRACT_WORKMAN_WAGES.WORKMANID);
            ViewBag.WORKORDERID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == Id && x.APPROVED == "Y").ToList(), "ID", "NAMEOFTHEWORK", CONTRACT_WORKMAN_WAGES.WORKORDERID);
            ViewBag.LOCATIONID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == Id && x.APPROVED == "Y").ToList(), "ID", "LOCATIONOFWORK", CONTRACT_WORKMAN_WAGES.LOCATIONID);           


            CONTRACT_WORKMAN_WAGES.CONTRACTORID = Id;
            CONTRACT_WORKMAN_WAGES.MODIFICATIONDATE = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            objContext9.Entry(CONTRACT_WORKMAN_WAGES).State = EntityState.Modified;
            objContext9.SaveChanges();
            ViewBag.Message = "Data updated Successfully.";
            return View();
        }


        public ActionResult TaggingNameofworkeragainstworkorderList()
        {
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            var CONTRACT_WORKMAN_WORK = objContext10.vw_CONTRACT_WORKMAN_WORK.Where(x => x.CONTRACTORID == Id).ToList();
            return View(CONTRACT_WORKMAN_WORK);

           
        }


        public ActionResult TaggingNameofworkeragainstworkorder()
        {
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            ViewBag.WorkorderNo = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == Id && x.APPROVED=="Y").ToList(), "ID", "WORKORDERNO");
            ViewBag.WorkmanName = new SelectList(objContext8.CONTRACT_WORKMAN_DETAILS.Where(x => x.CONTRACTORID == Id && (x.ISTERMINATION == "N" || x.ISTERMINATION == null)).ToList(), "ID", "NAME");
            return View();
        }

        [HttpPost]
        public ActionResult TaggingNameofworkeragainstworkorder( FormCollection frm)
        {
            DateTime currentDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            DateTime startDate = Convert.ToDateTime(frm["STARTDATE"]);
            DateTime endDate = Convert.ToDateTime(frm["ENDDATE"]);

            string vendorCode = Session["VendorCode"].ToString();
            int workOrderId = Convert.ToInt32(frm["WorkorderNo"]);
            string selectedworkmanId = frm["hidWorkmanName"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;

            int? maxcempintendor = objContext7.CONTRACT_WORK_ORDER.Where(x => x.ID == workOrderId).FirstOrDefault().MAXNOOFEMPLOYEES;

            ViewBag.WorkorderNo = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == Id && x.APPROVED=="Y").ToList(), "ID", "WORKORDERNO");
            ViewBag.WorkmanName = new SelectList(objContext8.CONTRACT_WORKMAN_DETAILS.Where(x => x.CONTRACTORID == Id && (x.ISTERMINATION == "N" || x.ISTERMINATION==null) ).ToList(), "ID", "NAME");
            var chekEntry = objContext10.CONTRACT_WORKMAN_WORK.Where(x => x.CONTRACTORID == Id).ToList();

            string[] parts = frm["hidWorkmanName"].Split(',');

            if (parts.Count() > maxcempintendor)
            {
                ViewBag.Message = "You can Tagging Maximum " + maxcempintendor;
            }
            else
            {
                var workmanmane = "";
                foreach (string part in parts)
                {
                    int workManId = Convert.ToInt32(part);
                    var chekEntryforworkman = chekEntry.Where(x => x.WORKMANID == workManId).ToList();

                    if (chekEntryforworkman.Count != 0)
                    {
                       // chekEntryforworkman = chekEntryforworkman.Where(x => x.ENDDATE < startDate && x.STARTDATE> endDate).ToList();
                        chekEntryforworkman = chekEntryforworkman.Where(x => (x.STARTDATE <= startDate && x.ENDDATE >= endDate) || (x.STARTDATE >= startDate && x.STARTDATE <= endDate) || (x.ENDDATE >= startDate && x.ENDDATE <= endDate)).ToList();
                    }
                    //&& (x.STARTDATE <= startDate && x.ENDDATE <= startDate) || (x.STARTDATE <= endDate && x.ENDDATE <= endDate)


                    if (chekEntryforworkman.Count == 0)
                    {
                        CONTRACT_WORKMAN_WORK CONTRACT_WORKMAN_WORK = new CONTRACT_WORKMAN_WORK();
                        CONTRACT_WORKMAN_WORK.CONTRACTORID = Id;
                        CONTRACT_WORKMAN_WORK.WORKORDERID = workOrderId;
                        CONTRACT_WORKMAN_WORK.WORKMANID = workManId;
                        CONTRACT_WORKMAN_WORK.STARTDATE = startDate;
                        CONTRACT_WORKMAN_WORK.ENDDATE = endDate;
                        CONTRACT_WORKMAN_WORK.CREATIONDATE = currentDate;
                        objContext10.CONTRACT_WORKMAN_WORK.Add(CONTRACT_WORKMAN_WORK);
                        objContext10.SaveChanges();
                    }
                    else
                    {
                        var details = objContext8.CONTRACT_WORKMAN_DETAILS.Where(x => x.ID == workManId).FirstOrDefault();
                        workmanmane = "," + details.NAME;
                        workmanmane = workmanmane.Remove(0, 1);

                    }
                }
                if (workmanmane != "")
                {
                    ViewBag.Message = "They are already another work " + workmanmane;
                }
                else
                {
                    ViewBag.Message = "Data saved Successfully.";
                }
            }

            //if (chekEntry == null)
            //{
            //    CONTRACT_WORKMAN_WORK CONTRACT_WORKMAN_WORK = new CONTRACT_WORKMAN_WORK();
            //    CONTRACT_WORKMAN_WORK.CONTRACTORID = Id;
            //    CONTRACT_WORKMAN_WORK.WORKORDERID = workOrderId;
            //    CONTRACT_WORKMAN_WORK.WORKMANID = frm["hidWorkmanName"];
            //    CONTRACT_WORKMAN_WORK.CREATIONDATE = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            //    objContext10.CONTRACT_WORKMAN_WORK.Add(CONTRACT_WORKMAN_WORK);
            //    objContext10.SaveChanges();
            //    ViewBag.Message = "Data saved Successfully.";
            //}
            //else
            //{
            //    chekEntry.CONTRACTORID = Id;
            //    chekEntry.WORKORDERID = workOrderId;
            //    chekEntry.WORKMANID = frm["hidWorkmanName"];
            //    chekEntry.CREATIONDATE = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            //    objContext10.Entry(chekEntry).State = EntityState.Modified;
            //    objContext10.SaveChanges();
            //    ViewBag.Message = "Data updated Successfully.";
            //}


            return View();
        }



        public ActionResult TaggingNameofworkeragainstworkorderEdit( int id)
        {

            var editworkeragainstworkorder = objContext10.CONTRACT_WORKMAN_WORK.Where(x => x.ID == id ).FirstOrDefault();

            ViewBag.WORKORDERID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == editworkeragainstworkorder.CONTRACTORID && x.APPROVED == "Y" && x.ID == editworkeragainstworkorder.WORKORDERID).ToList(), "ID", "WORKORDERNO", editworkeragainstworkorder.WORKORDERID);
            ViewBag.WorkmanName = new SelectList(objContext8.CONTRACT_WORKMAN_DETAILS.Where(x => x.CONTRACTORID == editworkeragainstworkorder.CONTRACTORID && x.ID == editworkeragainstworkorder.WORKMANID && (x.ISTERMINATION == "N" || x.ISTERMINATION==null)).ToList(), "ID", "NAME", editworkeragainstworkorder.WORKMANID);
            return View(editworkeragainstworkorder);
        }


        [HttpPost]
        public ActionResult TaggingNameofworkeragainstworkorderEdit(int id, FormCollection frm, CONTRACT_WORKMAN_WORK editworkeragainstworkorder)
        {

          
            DateTime currentDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            DateTime startDate = Convert.ToDateTime(frm["STARTDATE"]);
            DateTime endDate = Convert.ToDateTime(frm["ENDDATE"]);

            string vendorCode = Session["VendorCode"].ToString();
            int workOrderId = Convert.ToInt32(frm["WorkorderNo"]);
            string selectedworkmanId = frm["hidWorkmanName"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            ViewBag.WORKORDERID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == editworkeragainstworkorder.CONTRACTORID && x.APPROVED == "Y" && x.ID == editworkeragainstworkorder.WORKORDERID).ToList(), "ID", "WORKORDERNO", editworkeragainstworkorder.WORKORDERID);
            ViewBag.WorkmanName = new SelectList(objContext8.CONTRACT_WORKMAN_DETAILS.Where(x => x.CONTRACTORID == editworkeragainstworkorder.CONTRACTORID && x.ID == editworkeragainstworkorder.WORKMANID && (x.ISTERMINATION == "N" || x.ISTERMINATION==null)).ToList(), "ID", "NAME", editworkeragainstworkorder.WORKMANID);


            editworkeragainstworkorder.UPDATEDATE = currentDate;
            objContext10.Entry(editworkeragainstworkorder).State = EntityState.Modified;
            objContext10.SaveChanges();
            ViewBag.Message = "Data update Successfully.";
            return View();


           // var chekEntry = objContext10.CONTRACT_WORKMAN_WORK.Where(x => x.WORKORDERID == workOrderId && x.CONTRACTORID == Id).ToList();

            //int workorderId = Convert.ToInt32(frm["WORKORDERID"]);
            //string[] parts = frm["hidWorkmanName"].Split(',');
            //var workmanmane = "";
            //foreach (string part in parts)
            //{
            //    int workManId = Convert.ToInt32(part);
            //    var chekEntryforworkman = chekEntry.Where(x => x.WORKMANID == workManId && x.WORKORDERID != workorderId && (x.STARTDATE <= startDate && x.ENDDATE <= startDate) || (x.STARTDATE <= endDate && x.ENDDATE <= endDate)).ToList();


            //    //Not Completed 

            //    if (chekEntryforworkman.Count == 0)
            //    {
            //        editworkeragainstworkorder.UPDATEDATE = currentDate;
            //        objContext10.Entry(editworkeragainstworkorder).State = EntityState.Modified;
            //        objContext10.SaveChanges();
            //    }
            //    else
            //    {
            //        var details = objContext8.CONTRACT_WORKMAN_DETAILS.Where(x => x.ID == workManId).FirstOrDefault();
            //        workmanmane = "," + details.NAME;
            //        workmanmane = workmanmane.Remove(0, 1);

            //    }
            //}
            //if (workmanmane != "")
            //{
            //    ViewBag.Message = "They are already another work" + workmanmane;
            //}
            //else
            //{
            //    ViewBag.Message = "Data update Successfully.";
            //}

           // return View();
           
        }


        //[HttpPost]
        //public ActionResult getworkerName(int WorkorderNo)
        //{
        //    var workmanId = "";
        //    //int Id = Convert.ToInt32(Session["UserID"]);
        //    string vendorCode = Session["VendorCode"].ToString();
        //    int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;

        //    var Code = objContext10.CONTRACT_WORKMAN_WORK.Where(x => x.CONTRACTORID == Id && x.WORKORDERID == WorkorderNo);
        //    if (Code.Count()> 0)
        //    {
        //        workmanId = Code.FirstOrDefault().WORKMANID.ToString();
        //    }
        //    else
        //    {
        //        workmanId = "0";    
        //    }

        //    return Json(new { workmanId = workmanId });

        //}


        public ActionResult TaggingNameofworkeragainstworkorderDelete(int id)
        {
            var CONTRACT_WORKMAN_WORKDelete = objContext10.CONTRACT_WORKMAN_WORK.Where(x => x.ID == id).FirstOrDefault();
            objContext10.Entry(CONTRACT_WORKMAN_WORKDelete).State = EntityState.Deleted;
            objContext10.SaveChanges();
            return RedirectToAction("TaggingNameofworkeragainstworkorderList");
        }

        public ActionResult TenderList()
        {
            DateTime current= DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            TenderContext _tenderContext = new TenderContext();
            string vendorCode = Session["VendorCode"].ToString();
            //string Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID.ToString();
            string Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID.ToString();
            var TenderDetails = _tenderContext.Tenders.Where(x => (x.dtActiveDate <= current && x.strVendorsId.Contains(Id)) && (x.strTenderType == "STE" || x.strTenderType=="LTE") ).ToList();
            return View(TenderDetails);
        }

        public ActionResult PurchaseOrders()
        {
            
            string vendorcode = Session["VendorCode"].ToString();
            string gstNo = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorcode).FirstOrDefault().strGSTNo.ToString();
            return View(objBillTracking.ContractDetails.Where(x => x.VendorGSTNo == gstNo).ToList());
        }

        public ActionResult BillSubmitted()
        {

            string vendorcode = Session["VendorCode"].ToString();
            string gstNo = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorcode).FirstOrDefault().strGSTNo.ToString();
            return View(objBillTracking.BillDetails.Where(x => x.VendorGSTNo == gstNo).ToList());
        }

        public ActionResult BillStatus()
        {

            string vendorcode = Session["VendorCode"].ToString();
            string gstNo = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorcode).FirstOrDefault().strGSTNo.ToString();
            return View(objBillTracking.BillStatus.Where(x => x.VendorGSTNo == gstNo).ToList());
        }


        public ActionResult ExcelUploadForWorkmanData()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ExcelUploadForWorkmanData(CONTRACT_WORKMAN_DETAILS CONTRACT_WORKMAN_DETAILS, HttpPostedFileBase WorkmanDetails)
        {

            if (WorkmanDetails != null)
            {
                try
                {
                    var fileName = Path.GetExtension(WorkmanDetails.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/WorkOrder"), guid + fileName);
                    WorkmanDetails.SaveAs(path);
                    //if (IsCorrectFile(path))
                    //{
                        ViewBag.Message = importdatafromexcel(path);
                    //}
                    //else
                    //{
                    //    ViewBag.Message = "Wrong file selected...";
                    //}
                }
                catch (Exception ex)
                {
                    ViewBag.Message = ex.Message;
                    //System.Windows.Forms.MessageBox.Show(ex.Message);
                }
                //CONTRACT_WORKMAN_DETAILS.ADDLINCRALLOWED = "";
                //objContext8.CONTRACT_WORKMAN_DETAILS.Add(CONTRACT_WORKMAN_DETAILS);
                //objContext8.SaveChanges();
            }
            return View();
        }

        public string importdatafromexcel(string excelfilepath)
        {
            //if (IsCorrectFile(excelfilepath))
            //{

                //declare variables - edit these based on your particular situation
                string ssqltable = "CONTRACT_WORKMAN_DETAILS";
                // make sure your sheet name is correct, here sheet name is sheet1, so you can change your sheet name if have different          

                string vendorCode = Session["VendorCode"].ToString();
                //string FixedCollValue = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID.ToString();

                string FixedCollValue = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID.ToString();
                string myexceldataquery = "select ID,NAME,MIDDLENAME,SURNAME,DATEOFBIRTH,SEX,FATHERNAME,EMPLOYMENTTYPE,DESIGNATION,WAGERATE,WAGEPERIOD,PERMANENTADDRESS,PERMANENTPINCODE,PRESENTADRESS,PRESENTPINCODE,PANNO,AADHARNO,MOBILENO,EMAIL,PFTYPE,PFNO,BANKACNO,CASTE,EDUQUAL,TECHQUAL,DATEOFCOMMENCEMENT,DATEOFTERMINATION,REASONS,CREATIONTIME,MODIFCATIONTIME," + FixedCollValue + ",BANKNAME,PFOTHER,NOMINEE1,RELATION1,NOMINEE2,RELATION2,NOMINEEOTH1,NOMINEEOTH2,WUIN,INITMEDEXAMDATE,PRDMEDEXAMDATE,VTCTRNGDATE,CATCODE,UGALLOWED,UGALLOWEDPER,PFALLOWED,PFPER,PENSIONALLOWED,PENSIONALLOWEDPER,ADDLINCRALLOWED,ADDLINCRPER,BONUSALLOWED,BONUSALLOWEDPER,ATTDBONUSALLOWED,ATTDBONUSALLOWEDPER,RFD,LOI,ESINO from [Sheet1$] where NAME <> ''";
                // & NAME <>'(Must Be Filled)'
                try
                {
                    //create our connection strings
                    string sexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelfilepath + ";Extended Properties=Excel 12.0;Persist Security Info=False";

                    //string ssqlconnectionstring = "server=dfsserver;user id=sa;password=dfs@123;database=Hindustancopperlimited;connection reset=false";
                    string ssqlconnectionstring = ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;

                    //to check the content of dr or ds/da
                    //OleDbDataAdapter da = new OleDbDataAdapter(myexceldataquery, sexcelconnectionstring);
                    //DataSet ds = new DataSet();
                    //da.Fill(ds);

                //    Application application = new Application();
                //    _Workbook workbook = application.Workbooks.Open(excelfilepath, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                //_Worksheet worksheet = string.IsNullOrEmpty("Sheet1") ? ((_Worksheet)workbook.ActiveSheet) : ((_Worksheet)workbook.Worksheets["Sheet1"]);
                ////worksheet.Unprotect(Password: "HCL#2017#ManPower");
                //string test = Convert.ToString(worksheet.Cells[2, 28].Value());
                //workbook.Close();
                ////test = worksheet.Cells.Cells[2, 1].Value.ToString();
                //if (test == "HCL#Roni#2017#ManPower")
                //{

                    //series of commands to bulk copy data from the excel file into our sql table
                    OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                    OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                    oledbconn.Open();
                    OleDbDataReader dr = oledbcmd.ExecuteReader();




                    SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
                    bulkcopy.DestinationTableName = ssqltable;

                    //bulkcopy.WriteToServer(ds.Tables[0]);


                    while (dr.Read())
                    {
                        bulkcopy.WriteToServer(dr);
                    }
                    bulkcopy.Close();
                    oledbconn.Close();
                    return "Data Saved Successfully...";
                //}
                //else
                //{
                //    return "Wrong File...";
                //}

                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
        

            //}
            //else
            //{
            //    return "Wrong file selected...";
            //}
        }

        public bool IsCorrectFile(string file)
        {
            bool result = false;

            Application application = new Application();
            if (System.IO.File.Exists(file))
            {
                _Workbook workbook = application.Workbooks.Open(file, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                _Worksheet worksheet = string.IsNullOrEmpty("Sheet1") ? ((_Worksheet)workbook.ActiveSheet) : ((_Worksheet)workbook.Worksheets["Sheet1"]);
                //worksheet.Unprotect(Password: "HCL#2017#ManPower");
                string test = Convert.ToString(worksheet.Cells[2, 28].Value());
                //test = worksheet.Cells.Cells[2, 1].Value.ToString();
                if (test == "HCL#Roni#2017#ManPower")
                {
                    result = true;
                }
                else
                {
                    result = false;
                }

            }
            //
            int pid = Process.GetCurrentProcess().Id;
            Process.GetProcessesByName("EXCEL").Where((Process ex) => ex.Id == pid).ToList<Process>().ForEach(delegate(Process ex)
            {
                ex.Kill();
                ex.Dispose();
            }
            );
            
            return result;
        }

        public ActionResult ExportToExcel()
        {
            //Get the data from database into datatable
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;            
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            string strQuery = "select *" +
                "from CONTRACT_WORKMAN_DETAILS where CONTRACTORID="+Id;
            SqlCommand cmd = new SqlCommand(strQuery);
            System.Data.DataTable dt = GetData(cmd);

            //Create a dummy GridView
            System.Web.UI.WebControls.GridView GridView1 = new System.Web.UI.WebControls.GridView();
            GridView1.AllowPaging = false;
            GridView1.DataSource = dt;
            GridView1.DataBind();

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";

            Response.AddHeader("content-disposition", "attachment; filename=DataTable.xls");
            //Response.ContentType = "application/vnd.ms-excel";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

            StringWriter sw = new StringWriter();
            System.Web.UI.HtmlTextWriter hw = new System.Web.UI.HtmlTextWriter(sw);

            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                //Apply text style to each Row
                GridView1.Rows[i].Attributes.Add("class", "textmode");
            }
            GridView1.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            if (GridView1.Rows.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("There is No data in the Database Table...");
            }
            else
            {
                Response.Write(style);
                Response.Output.Write(sw.ToString());
            }

            Response.Flush();
            Response.End();

            return View();
        }

        //<add name="conString" connectionString="Data Source=.\SQLEXPRESS;
        //            database=Northwind;Integrated Security=true"/>

        private System.Data.DataTable GetData(SqlCommand cmd)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            String strConnString = System.Configuration.ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
            SqlConnection con = new SqlConnection(strConnString);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            try
            {
                con.Open();
                sda.SelectCommand = cmd;
                sda.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                sda.Dispose();
                con.Dispose();
            }
        }

        public ActionResult ExcelUploadForWorkmanWages()
        {
            string vendorCode = Session["VendorCode"].ToString();
            //int Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            ViewBag.WORKORDERID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == Id && x.APPROVED=="Y").ToList(), "ID", "NAMEOFTHEWORK");
            return View();
        }


        

        //// Bhashkar 060717

        [HttpPost]
        public ActionResult ExcelUploadForWorkmanWages(CONTRACT_WORKMAN_WAGES CONTRACT_WORKMAN_WAGES, HttpPostedFileBase WorkmanWages, FormCollection frm, string submit)
        {
            int WorkorderNo = Convert.ToInt32(frm["WORKORDERID"]);
            string vendorCode = Session["VendorCode"].ToString();
            //int ContractorId = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            int ContractorId = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID;
            var detailsofWorkMan = objContext10.vw_CONTRACT_WORKMAN_WORK.Where(x => x.WorkorderId == WorkorderNo && x.CONTRACTORID == ContractorId).ToList();
            ViewBag.WORKORDERID = new SelectList(objContext7.CONTRACT_WORK_ORDER.Where(x => x.CONTRACTORID == ContractorId && x.APPROVED == "Y").ToList(), "ID", "NAMEOFTHEWORK");


            if (submit == "Download the Excel File")
            {

                if (detailsofWorkMan.Count > 0)
                {


                    try
                    {

                        string strFileName = "WorkmanWages_" + vendorCode + ".xls";
                        FileStream fs = new FileStream(Server.MapPath("/ExcelFormat") + "/CONTRACT_WORKMAN_WAGES.xls", FileMode.Open, FileAccess.Read);
                        HSSFWorkbook wb = new HSSFWorkbook(fs, true);
                        HSSFSheet ws = (HSSFSheet)wb.GetSheet("Sheet1");

                        int i = 3;
                        foreach (var detailsofMan in detailsofWorkMan)
                        {

                            ws.GetRow(i).GetCell(0).SetCellValue(detailsofMan.CONTRACTORID);
                            ws.GetRow(i).GetCell(2).SetCellValue(detailsofMan.WORKMANID);
                            ws.GetRow(i).GetCell(3).SetCellValue(detailsofMan.NAME);
                            ws.GetRow(i).GetCell(4).SetCellValue(detailsofMan.MIDDLENAME);
                            ws.GetRow(i).GetCell(5).SetCellValue(detailsofMan.SURNAME);
                            ws.GetRow(i).GetCell(15).SetCellValue(detailsofMan.WorkorderId);
                            ws.GetRow(i).GetCell(16).SetCellValue(detailsofMan.WorkorderId);
                            i = i + 1;
                        }
                        ws.ProtectSheet("");
                        MemoryStream ms = new MemoryStream();
                        wb.Write(ms);

                        
                        
                        //HttpResponse response = HttpContext.Current.Response;
                        Response.ContentType = "application/vnd.ms-excel";
                        Response.AddHeader("Content-Disposition", String.Format("attachment;filename={0}", strFileName));
                        Response.Clear();
                        Response.BinaryWrite(ms.GetBuffer());
                        Response.Flush();
                    }
                    catch (Exception)
                    {
                        ViewBag.Message = "Error in Excel file generating";
                    }

                    
                }
                else
                {
                    ViewBag.Message = "There is No data in the Database Table...";
                }
                return View();
            }

            else
            {
                if (WorkmanWages != null)
                {
                    var fileName = Path.GetExtension(WorkmanWages.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/WorkOrder"), guid + fileName);
                    WorkmanWages.SaveAs(path);
                    string FunctionResult = importwagesfromexcel(path);
                    ViewBag.Message = FunctionResult;

                }
                return View();
            }
        }

        public void updateexcel(string file, string data, out int pID)
        {
            int pid = 0;
            try
            {

                //Application application = new Application();
                pid = Process.GetCurrentProcess().Id;

                //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelfilepath + ";Extended Properties=Excel 12.0;Persist Security Info=False

                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.OleDb.OleDbCommand myCommand = new System.Data.OleDb.OleDbCommand();
                string sql = null;
                MyConnection = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties=Excel 12.0;Persist Security Info=False;");
                //MyConnection = new System.Data.OleDb.OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;Data Source=file;Extended Properties=Excel 8.0;");
                MyConnection.Open();
                myCommand.Connection = MyConnection;
                //data = "'1', '123', 'Ssss', '', 'biswas', '1'";

                sql = "Insert into [Sheet1$] (CONTRACTORID, WORKMANID, FIRSTNAME, MIDDLENAME, SURNAME, WORKORDERID) values(" + data + ")";

                myCommand.CommandText = sql;
                myCommand.ExecuteNonQuery();
                MyConnection.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
            }
            finally
            {
                pID = pid;
            }
        }
        public void UpdateExcel(string file, string sheetName, int row, int col, string data, out int pID)
        {
            int pid = 0;
            try
            {
                Application application = new Application();
                //Upload.GetWindowThreadProcessId(application.Hwnd, out pid);
                pid = Process.GetCurrentProcess().Id;

                pID = pid;
                if (System.IO.File.Exists(file))
                {
                    _Workbook workbook = application.Workbooks.Open(file, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value, Missing.Value);
                    _Worksheet worksheet = string.IsNullOrEmpty(sheetName) ? ((_Worksheet)workbook.ActiveSheet) : ((_Worksheet)workbook.Worksheets[sheetName]);
                    worksheet.Cells[row, col] = data.ToUpper();
                    workbook.Save();
                    workbook.Close();
                    //Process.GetProcessesByName("EXCEL").Where((Process ex) => ex.Id == pid).ToList<Process>().ForEach(delegate(Process ex)
                    //{
                    //    ex.Kill();
                    //    ex.Dispose();                        
                    //}
                    //);

                }


            }
            catch (Exception ex)
            {
                throw (ex);
            }
            finally
            {

            }
        }


        public string importwagesfromexcel(string excelfilepath)
        {
            string ssqltable = "CONTRACT_WORKMAN_WAGES";
            string myexceldataquery = "select ID,CONTRACTORID,WORKMANID,MNTH,YEAR,ATTENDANCE,WAGERATE,OTHERS,TOTALDEDUCTION,NETAMOUNT,BANKDEPOSITDATE,REMARKS,WORKORDERID,LOCATIONID,ABSENTDAYS,PFDEPOSITDATE,BASICPAY,VDA,SDA,UGALLOW,BONUS,PFGROSS,ATTENDANCEBONUS,PENSION,ADDLINCR,GROSS,NETPAY,CATCODE,OTHERALLOWANCE,NORMALWAGESEARNED,OTWAGES,PF,OTHERDEDUCTION,CREATIONDATE,MODIFICATIONDATE from [Sheet1$] where CONTRACTORID>0";

            try
            {

                string sexcelconnectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + excelfilepath + ";Extended Properties=Excel 12.0;Persist Security Info=False";
                string ssqlconnectionstring = ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
                OleDbConnection oledbconn = new OleDbConnection(sexcelconnectionstring);
                OleDbCommand oledbcmd = new OleDbCommand(myexceldataquery, oledbconn);
                oledbconn.Open();
                OleDbDataReader dr = oledbcmd.ExecuteReader();
                SqlBulkCopy bulkcopy = new SqlBulkCopy(ssqlconnectionstring);
                bulkcopy.DestinationTableName = ssqltable;
                if (dr.FieldCount > 0)
                {

                    while (dr.Read())
                    {

                        bulkcopy.WriteToServer(dr);

                    }
                    bulkcopy.Close();
                    oledbconn.Close();
                    return "Data Saved Successfully...";
                }
                else
                {
                    return "No Data...";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }


        [HttpPost]
        public ActionResult getWorkmanWages(int WorkorderNo)
        {
            return View();
        }

        public ActionResult DataViewDetailsNew(int id)
        {

            var vendorId = Session["VendorCode"];

            if (vendorId == null && Session["UserID"]!=null)
            {
                vendorId = objContextNew.VendorsNews.Single(x => x.Pk_intNewVendorRegistrationID == id).strVendorRegistrationID;
            }
            VendorsNew VendorsNew = objContextNew.VendorsNews.Single(x => x.strVendorRegistrationID == vendorId);
            ViewBag.dtApplicationDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");            
            
            //ViewBag.Fk_intDepartment = new SelectList(objContextDepartment.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");
            //ViewBag.hidFk_intDepartment = VendorsNew.Fk_intDepartment;
            ViewBag.hidstrIsManpowerSupplier = VendorsNew.strIsManpowerSupplier;
            //var AppliedFk_intUnitId = VendorsNew.Fk_intUnitId;
            //ViewBag.hidFk_intUnitId = VendorsNew.Fk_intUnitId;
            //ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
            ViewBag.str_country = new SelectList(objcountry.tbl_mst_country.ToList(), "Str_country", "Str_country", VendorsNew.str_country);
            ViewBag.str_state = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", VendorsNew.str_state);
            ViewBag.intfk_CategoryID = new SelectList(objContext2.Castes.ToList(), "pk_intCasteId", "strCasteName", VendorsNew.intfk_CategoryID);
            ViewBag.int_fk_CompanyStatusID = new SelectList(objContext6.Companys.ToList(), "pk_CompanyStatusID", "strCompanyStatusName", VendorsNew.int_fk_CompanyStatusID);
            ViewBag.fk_intConstitutionFirmID = new SelectList(objContext4.ConstitutionFirms.ToList(), "pk_intConstitutionFirmID", "strConstitutionFirm", VendorsNew.fk_intConstitutionFirmID);
            ViewBag.str_serviceprovidertype = new SelectList(objprovider.tbl_mst_Serviceprovider.ToList(), "str_desc", "str_desc", VendorsNew.str_serviceprovidertype);
            ViewBag.strRegistrationApplied = new SelectList(objContext5.ItemDescriptions.ToList(), "Pk_intItemDescription", "strItemDescriptionName");
            ViewBag.hidstrRegistrationApplied = VendorsNew.strRegistrationApplied;
            TempData["PanNo"] = VendorsNew.strPANNo;
            
            return View(VendorsNew);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult DataViewDetailsNew(VendorsNew vendorsNew, FormCollection frm)
        {
            ViewBag.str_country = new SelectList(objcountry.tbl_mst_country.ToList(), "Str_country", "Str_country", vendorsNew.str_country);
            ViewBag.str_state = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", vendorsNew.str_state);
            //ViewBag.Fk_intDepartment = new SelectList(objContextDepartment.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");
            //ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
            ViewBag.intfk_CategoryID = new SelectList(objContext2.Castes.ToList(), "pk_intCasteId", "strCasteName", vendorsNew.intfk_CategoryID);
            ViewBag.int_fk_CompanyStatusID = new SelectList(objContext6.Companys.ToList(), "pk_CompanyStatusID", "strCompanyStatusName", vendorsNew.int_fk_CompanyStatusID);
            ViewBag.fk_intConstitutionFirmID = new SelectList(objContext4.ConstitutionFirms.ToList(), "pk_intConstitutionFirmID", "strConstitutionFirm", vendorsNew.fk_intConstitutionFirmID);
            ViewBag.strRegistrationApplied = new SelectList(objContext5.ItemDescriptions.ToList(), "Pk_intItemDescription", "strItemDescriptionName");
            ViewBag.str_serviceprovidertype = new SelectList(objprovider.tbl_mst_Serviceprovider.ToList(), "str_desc", "str_desc", vendorsNew.str_serviceprovidertype);
            if (ModelState.IsValid)
            {
                if (Session["VendorCode"] != null && Session["UserID"] != null)
                {
                    //HttpPostedFileBase strMSMEDocument = Request.Files["strMSMEDocument"];                    

                    vendorsNew.strRegistrationApplied = frm["hidstrRegistrationApplied"];
                    vendorsNew.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    vendorsNew.Fk_intDepartment = frm["hidFk_intDepartment"];
                    vendorsNew.strActive = "YES";
                    vendorsNew.strPending = "NO";
                    vendorsNew.strVerify = "YES";
                    objContextNew.Entry(vendorsNew).State = EntityState.Modified;
                    objContextNew.SaveChanges();

                    VendorLoginContext objVendorLoginContext = new VendorLoginContext();
                    var checkobjVendorLogin = objVendorLoginContext.VendorLogin.Where(x => x.strUserName == vendorsNew.strVendorRegistrationID).FirstOrDefault();
                    if (checkobjVendorLogin != null)
                    {
                        if (frm["strIsManpowerSupplier"] == "Yes")
                        {
                            checkobjVendorLogin.strusertype = "CONTRACTOR";
                        }
                        else
                        {
                            checkobjVendorLogin.strusertype = "VENDOR";
                        }

                        checkobjVendorLogin.dtUpdatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        objVendorLoginContext.Entry(checkobjVendorLogin).State = EntityState.Modified;
                        objVendorLoginContext.SaveChanges();
                    }

                   // Utility.SendEmail(vendorsNew.strEmail, "Your data has been sent successfully", "Your data has been sent successfully. After completion of your verification you will get your details information by mail.");
                    //if (frm["hidFk_intUnitId"].Split(',').Count() > 1)
                    //{
                    //    Utility.SendEmail("reddy_pks@hindustancopper.com", "Vendor approval", "The vendor is : " + vendorsNew.strVendorRegistrationID + " waiting for your approval.");
                    //}
                    ViewBag.Message = "Your Data Updated Successfully!";
                    //ViewBag.hidFk_intDepartment = vendorsNew.Fk_intDepartment;
                    return View(vendorsNew);
                }
                else
                {
                    return RedirectToAction("Login", "VendorRegistration");
                }
            }

            string messages = string.Join("; ", ModelState.Values
                                       .SelectMany(x => x.Errors)
                                       .Select(x => x.ErrorMessage));
            ViewBag.Message = messages;

            if (vendorsNew.Pk_intNewVendorRegistrationID == 437)
            {
                Utility.SendEmail("bhashkar.ghosh@dfssolutions.com", "Error List", messages);
            }

            return View(vendorsNew);
        }
        
        [HttpPost]
        public ActionResult checkGST(string GSTNo)
        {
            
            var already = "No";
            int checkData = objContextNew.VendorsNews.Where(x => x.strGSTNo == GSTNo).ToList().Count();
            if (checkData > 0)
            {
                already = "Yes";
            }
            return Json(new { already = already });
        }
    }
}

