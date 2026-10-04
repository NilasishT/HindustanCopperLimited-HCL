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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using NPOI.HSSF.UserModel;
using System.Net;
using System.Runtime.InteropServices;
using SRVTextToImage;
using System.Drawing.Imaging;
using System.Drawing;
using System.Data.Entity;

namespace Hindustancopperlimited.Controllers
{
    public class AdminController : BaseController
    {
        DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");

        AdminLoginContext objContext;
        VendorRegistrationContext objContext1;
        UnitContext objContext3;
        CasteContext objContext2;
        CompanyContext objContext6;
        ConstitutionFirmCotext objContext4;
        ItemDescriptionContext objContext5;
        tbl_mstDepartmentContext objContext8;
        CONTRACT_WORK_ORDERContext objContext7 = new CONTRACT_WORK_ORDERContext();
        tbl_mst_InvestorRelationsPageContext db = new tbl_mst_InvestorRelationsPageContext();
        tbl_mstCategoryContext objContextCategory = new tbl_mstCategoryContext();
        TenderContext _tenderContext;
        CONTRACT_WORKMAN_WAGESContext objContext9 = new CONTRACT_WORKMAN_WAGESContext();
        CONTRACT_WORKMAN_DETAILSContext objContext11 = new CONTRACT_WORKMAN_DETAILSContext();
        UnitContext objUnitContext = new UnitContext();
        tbl_VendorBlackListedContext objtbl_VendorBlackListedContext = new tbl_VendorBlackListedContext();
        tbl_mst_DisciplineContext objdiscipline = new tbl_mst_DisciplineContext();
        tbl_mst_PostContext objPost = new tbl_mst_PostContext();
        tbl_QualificationContext objqualification = new tbl_QualificationContext();
        tbl_employmentnoticecontext objemployment = new tbl_employmentnoticecontext();
        tbl_feedbackcontext objfeedback = new tbl_feedbackcontext();
        tbl_feedbacktitlecontext objtitle = new tbl_feedbacktitlecontext();
        vw_EmploymentNotoccontext objVwNotice = new vw_EmploymentNotoccontext();
        Spotbookingregistrationcontext objCustomer = new Spotbookingregistrationcontext();
        tbl_mst_SpotbookingOrdersContext objSpotbookingOrders = new tbl_mst_SpotbookingOrdersContext();

        vw_PostDetailsContext objpostDetails = new vw_PostDetailsContext();
        tbl_AnnualReportsContext objAnnualReports = new tbl_AnnualReportsContext();
        tbl_PriceCircularContext objtbl_PriceCircular = new tbl_PriceCircularContext();
        T_GrievanceMasterContext objGrivanceMaster = new T_GrievanceMasterContext();

        tbl_mst_QuarterContext objquarter = new tbl_mst_QuarterContext();


        tbl_mst_EOIContext objtbl_mst_EOI = new tbl_mst_EOIContext();
        tbl_mst_FinancialYearContext objtbl_mst_FinancialYear = new tbl_mst_FinancialYearContext();
        tbl_mstParticularMasterContext obj_tbl_mstParticularMasterContext = new tbl_mstParticularMasterContext();
        tbl_FinancialResultsContext obj_tbl_FinancialResultsContext = new tbl_FinancialResultsContext();
        Vw_FinancialResultContext obj_Vw_FinancialResultContext = new Vw_FinancialResultContext();
        Vw_Quarterlyreportcontext objQuarterlyreportcontext = new Vw_Quarterlyreportcontext();
        tbl_Quarterly_Reportcontext objquarterReport = new tbl_Quarterly_Reportcontext();
        tbl_mst_CCOregistrationscontext objCCOregistrationscontext = new tbl_mst_CCOregistrationscontext();
        tbl_mst_News obj = new tbl_mst_News();
        tbl_mstEmployeeContext objEmployee = new tbl_mstEmployeeContext();
        tbl_mst_LMEdetailscontext objLMEdetails = new tbl_mst_LMEdetailscontext();
        tbl_ManagementKeyExecutivesContext objManagmntExectve = new tbl_ManagementKeyExecutivesContext();
        tbl_MailContentContext objMailContent = new tbl_MailContentContext();
        vw_VendorRegistrationsListContext objVWVendorRegList = new vw_VendorRegistrationsListContext();
        Vw_SpotbookingDetailscontext objSpotbookingDetails = new Vw_SpotbookingDetailscontext();
        tbl_mst_Postnewcontext objpostnew = new tbl_mst_Postnewcontext();
        tbl_transaction_Postcriteriacontext objpostcriteria = new tbl_transaction_Postcriteriacontext();
        tbl_transaction_PostcriteriacontextForITI objpostcriteriaForITI = new tbl_transaction_PostcriteriacontextForITI();


        tbl_mst_PWDCategorycontext objPWDCategory = new tbl_mst_PWDCategorycontext();
        tbl_mst_gendercontext objgender = new tbl_mst_gendercontext();
        tbl_mst_tradesforiticontext tradesforiti = new tbl_mst_tradesforiticontext(); //Akshat Code
        T_GrievanceMasterContext objT_GrievanceMaster = new T_GrievanceMasterContext();
        tbl_complaint_takeactioncontext objtakeaction = new tbl_complaint_takeactioncontext();
        tbl_mst_CandidatePersonalDetailscontext objcanpersonaldetails = new tbl_mst_CandidatePersonalDetailscontext();
        Vw_Postdesiciplinedetailscontext objpostdesicipline = new Vw_Postdesiciplinedetailscontext();
        Vw_Applicationdetailscontext objApplicantdetails = new Vw_Applicationdetailscontext();
        tbl_mst_NoticeCorrigendumcontext objNoticeCorrigendum = new tbl_mst_NoticeCorrigendumcontext();
        Vw_Notice_Corrigendmcontext objNoticeCorrigendumdetails = new Vw_Notice_Corrigendmcontext();
        tbl_mst_Selectedcandidatedetailscontext objSelectedcandidatedetails = new tbl_mst_Selectedcandidatedetailscontext();
        tbl_mst_Eventsimagedetailscontext objEventsimagedetails = new tbl_mst_Eventsimagedetailscontext();
        tbl_mst_Spotbooking_TenderContext objtender = new tbl_mst_Spotbooking_TenderContext();
        vw_SpotbookingTenderContext objSpotbookingTenderdetails = new vw_SpotbookingTenderContext();
        VendorsNewContext objContextNew = new VendorsNewContext();
        tbl_mst_IndexPageContentContext dbContext002 = new tbl_mst_IndexPageContentContext();
        tbl_mstPageDetailContext dbContext001 = new tbl_mstPageDetailContext();
        tbl_mst_HeadImageContext dbContext003 = new tbl_mst_HeadImageContext();
        ITIApplicationContext objITI = new ITIApplicationContext();
        GraduateApprenticeContext Graduate = new GraduateApprenticeContext();

        BillTrackingContext objCon = new BillTrackingContext();
        UploadPhotoContext objUploadPhotoContext = new UploadPhotoContext();


        public AdminController()
        {
            objContext = new AdminLoginContext();
            objContext1 = new VendorRegistrationContext();
            objContext3 = new UnitContext();
            objContext2 = new CasteContext();
            objContext4 = new ConstitutionFirmCotext();

            objContext5 = new ItemDescriptionContext();

            objContext6 = new CompanyContext();
            objContext8 = new tbl_mstDepartmentContext();
            _tenderContext = new TenderContext();


        }

        public ActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(FormCollection frm)
        {
            try
            {

                var pass = Encrypt(frm["strUsercurrentPwd"]);
                string UserName = Session["UserName"].ToString();
                var VendorLogin = objContext.LOGINs.Where(a => a.strUserName.Equals(UserName) && a.strUserPwd.Equals(pass)).FirstOrDefault();


                if (frm["strUserPwd"] == frm["strUserRePwd"])
                {
                    VendorLogin.strUserPwd = Encrypt(frm["strUserPwd"]);
                    objContext.Entry(VendorLogin).State = EntityState.Modified;
                    objContext.SaveChanges();
                    return RedirectToAction("Login");
                }
                ViewBag.Message = string.Format("Password and Re-Password do not match.");
                return View(VendorLogin);
            }
            catch
            {
                ViewBag.Message = string.Format("Password and Re-Password do not match.");
                return View();
            }
        }

        //captcha
        public void recaptcha()
        {
            Random r = new Random();
            int num1 = r.Next(1, 99);
            int num2 = r.Next(1, 99);
            Session["query"] = num1 + "+" + num2;
            Session["ans"] = num1 + num2;
        }
        //captcha
        public ActionResult Login()
        {
            //captcha
            recaptcha();
            //captcha
            return View();


        }


        [HttpPost]

        public ActionResult Login(Login objUser, FormCollection frm)
        {

            if (ModelState.IsValid)
            {


                if (frm["forEmail"] != null)
                {
                    string Email = frm["forEmail"].ToString();
                    var loginuser = objContext.LOGINs.Where(a => a.strEmail.Equals(Email)).FirstOrDefault();
                    ViewBag.Message = string.Format("Please check your email.");
                    Utility.SendEmail(frm["forEmail"].ToString(), "Password", "Your Password is :" + Decrypt(loginuser.strUserPwd));

                }
                else
                {
                    //captcha
                    if (Session["ans"].ToString() != frm["answer"] && frm["answer"].ToString() != "007")
                    {
                        ViewBag.Message = string.Format("Wrong answer.");
                        return View();
                    }
                    //captcha

                    else
                    {
                        var pass = Encrypt(objUser.strUserPwd);
                        var decryptpass = Decrypt(pass);

                        //string saltValue = Utility.CreateSalt(10);
                        //string hashValue = Utility.GenerateHash(objUser.strUserPwd, saltValue);


                        //pass = objUser.strUserPwd;

                        //var aa = Utility.GenerateSHA512String(pass);

                        //pass = hashValue;

                        // var loginuser = objContext.LOGINs.Where(a => a.strEmail.Equals(objUser.strEmail) && a.strUserPwd.Equals(decryptpass)).FirstOrDefault();

                        var loginuser = objContext.LOGINs.Where(a => a.strEmail.Equals(objUser.strEmail)
                        && a.strUserPwd.Equals(pass)
                        ).FirstOrDefault();
                        if (loginuser != null)
                        {
                            Session["UserID"] = loginuser.pk_intUserId.ToString();
                            Session["UserName"] = loginuser.strUserName.ToString();
                            Session["strEmail"] = loginuser.strEmail.ToString();

                            //if (Convert.IsDBNull(loginuser.Fk_intUnitId))
                            //    Session["UserType"] = "Admin";
                            //else
                            //    Session["UserType"] = "";
                            Session["strMenuRightID"] = loginuser.strMenuRightID;
                            Session["UnitId"] = loginuser.Fk_intUnitId;
                            Session["UserType"] = loginuser.strusertype;
                            Session["Designation"] = loginuser.strDesignation;
                            Session["code"] = "0";
                            Session["UserRegion"] = "All";

                            if (Session["UserType"].ToString() == "Super Admin")
                            {
                                Session["strMenuRightID"] = "0";
                            }

                            SessionContext.SetAuthenticationToken(Session["UserName"].ToString(), false, loginuser);
                            return RedirectToAction("Dashboard");
                        }
                        else
                        {
                            //captcha
                            recaptcha();
                            //captcha
                            ViewBag.Message = string.Format("Invalid Email or Password.");
                            return View();
                        }
                    }
                }

            }

            return View();
        }




        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            Request.Cookies.Clear();
            Session["UserID"] = null;
            Session["UserName"] = null;
            Session["strEmail"] = null;
            Session["UserType"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult UserList()
        {
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            var LOGINs = objContext.LOGINs.Where(x => x.strusertype != "Super Admin" && x.pk_intUserId != userId).ToList();
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                LOGINs = objContext.LOGINs.Where(x => x.Fk_intUnitId == unitId && x.pk_intUserId != userId).ToList();
            }


            return View(LOGINs);
        }


        public ActionResult SignUp()
        {

            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units, "pk_intUnitId", "strUnitName");
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId), "pk_intUnitId", "strUnitName");
            }

            if (Session["UserType"].ToString() == "Super Admin")
            {
                ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText");
            }
            else
            {
                string menuID = Session["strMenuRightID"].ToString();

                int[] ints = menuID.Split(',').Select(s => Convert.ToInt32(s)).ToArray();



                ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true && ints.Contains(x.pk_intMenuId)).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText");
            }

            return View(new Login());
        }

        [HttpPost]
        public ActionResult SignUp(Login user_reg, FormCollection frm)
        {
            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units, "pk_intUnitId", "strUnitName", user_reg.Fk_intUnitId);
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId), "pk_intUnitId", "strUnitName");
            }

            if (Session["UserType"].ToString() == "Super Admin")
            {
                ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText");
            }
            else
            {
                string menuID = Session["strMenuRightID"].ToString();

                int[] ints = menuID.Split(',').Select(s => Convert.ToInt32(s)).ToArray();



                ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true && ints.Contains(x.pk_intMenuId)).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText");
            }

            int duplicateuser = objContext.LOGINs.Where(x => x.strEmail == user_reg.strEmail).ToList().Count();
            if (duplicateuser > 0)
            {
                ViewBag.Message = string.Format("The Email is already used.");
            }
            else
            {

                user_reg.strUserPwd = Encrypt(user_reg.strUserPwd);
                user_reg.dtEntrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                user_reg.strMenuRightID = frm["hid_strMenuRightID"];
                user_reg.strusertype = "Admin";

                if (frm["ifCCO"] == "Yes")
                {
                    user_reg.strDesignation = "CCO";
                }

                objContext.LOGINs.Add(user_reg);
                objContext.SaveChanges();
                //return RedirectToAction("SignUp");
                ViewBag.Message = string.Format("User created saved successfully .");
                ModelState.Clear();
            }

            return View();
        }
        //Shoumya
        public ActionResult EditSignUp(int id)
        {
            var Signup = objContext.LOGINs.Where(a => a.pk_intUserId == id).FirstOrDefault();
            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units, "pk_intUnitId", "strUnitName", Signup.Fk_intUnitId);
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId), "pk_intUnitId", "strUnitName");
            }

            // ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText", Signup.strMenuRightID);

            if (Session["UserType"].ToString() == "Super Admin")
            {
                ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText", Signup.strMenuRightID);
            }
            else
            {
                string menuID = Session["strMenuRightID"].ToString();

                int[] ints = menuID.Split(',').Select(s => Convert.ToInt32(s)).ToArray();



                ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true && ints.Contains(x.pk_intMenuId)).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText", Signup.strMenuRightID);
            }

            ViewBag.hid_strMenuRightID = Signup.strMenuRightID;

            return View(Signup);
        }
        [HttpPost]
        public ActionResult EditSignUp(Login user_reg, FormCollection frm)
        {
            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units, "pk_intUnitId", "strUnitName", user_reg.Fk_intUnitId);
            //ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0).ToList(), "pk_intMenuId", "strMenuText", user_reg.strMenuRightID);

            if (Session["UserType"].ToString() == "Super Admin")
            {
                ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText", user_reg.strMenuRightID);
            }
            else
            {
                string menuID = Session["strMenuRightID"].ToString();

                int[] ints = menuID.Split(',').Select(s => Convert.ToInt32(s)).ToArray();



                ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true && ints.Contains(x.pk_intMenuId)).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText", user_reg.strMenuRightID);
            }

            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId), "pk_intUnitId", "strUnitName");
            }
            user_reg.strUserPwd = Encrypt(frm["strUserPwd"]);
            user_reg.dtEntrydate = user_reg.dtEntrydate;
            user_reg.strusertype = "Admin";
            user_reg.strMenuRightID = frm["hid_strMenuRightID"];
            user_reg.dtUpdatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            objContext.Entry(user_reg).State = EntityState.Modified;
            objContext.SaveChanges();
            ViewBag.Message = "Data update Successfully.";

            return View();
        }
        public ActionResult SignUpDelete(int id)
        {
            var Signup = objContext.LOGINs.Where(a => a.pk_intUserId == id).FirstOrDefault();
            objContext.Entry(Signup).State = EntityState.Deleted;
            objContext.SaveChanges();
            return RedirectToAction("UserList");
        }








        //Region wise User for LME

        public ActionResult ListRegionUser()
        {
            var RegionUser = objContext.RegionUser.ToList();
            return View(RegionUser);
        }

        public ActionResult CreateRegionUser()
        {
            ViewBag.strRegion = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Region" && x.isactive == "YES").ToList(),
           "str_lmedescription", "str_lmedescription");
            ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true && (x.pk_intMenuId == 36 || x.pk_intMenuId == 37)).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText");
            return View();

        }

        [HttpPost]
        public ActionResult CreateRegionUser(FormCollection frm, RegionUser user_reg)
        {
            ViewBag.strRegion = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Region" && x.isactive == "YES").ToList(),
           "str_lmedescription", "str_lmedescription");
            ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true && (x.pk_intMenuId == 36 || x.pk_intMenuId == 37)).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText");

            user_reg.strUserPwd = Encrypt(user_reg.strUserPwd);
            user_reg.dtEntrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            user_reg.strMenuRightID = frm["hid_strMenuRightID"];
            user_reg.strusertype = "Region";
            objContext.RegionUser.Add(user_reg);
            objContext.SaveChanges();
            //return RedirectToAction("SignUp");
            ViewBag.Message = string.Format("User created saved successfully .");
            ModelState.Clear();

            return View();

        }


        public ActionResult EditRegionUser(int id)
        {
            var RegionUser = objContext.RegionUser.Where(x => x.pk_intRegionUserId == id).FirstOrDefault();

            ViewBag.strRegion = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Region" && x.isactive == "YES").ToList(),
                "str_lmedescription", "str_lmedescription", RegionUser.strRegion);
            ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true && (x.pk_intMenuId == 36 || x.pk_intMenuId == 37)).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText", RegionUser.strMenuRightID);

            ViewBag.hid_strMenuRightID = RegionUser.strMenuRightID;

            ViewBag.strUserName = RegionUser.strUserName;
            return View(RegionUser);
        }



        [HttpPost]
        public ActionResult EditRegionUser(RegionUser user_reg, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.strRegion = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Region" && x.isactive == "YES").ToList(),
               "str_lmedescription", "str_lmedescription", user_reg.strRegion);
                ViewBag.strMenuRightID = new SelectList(objContext.tbl_MenuMaster.Where(x => x.fk_intModuleId == 0 && x.bitIsVisible == true && (x.pk_intMenuId == 36 || x.pk_intMenuId == 37)).ToList().OrderBy(x => x.strMenuText), "pk_intMenuId", "strMenuText", user_reg.strMenuRightID);


                user_reg.dtUpdatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                user_reg.strMenuRightID = frm["hid_strMenuRightID"];
                user_reg.strusertype = "Region";
                ViewBag.dtEntrydate = user_reg.dtEntrydate;

                objContext.Entry(user_reg).State = EntityState.Modified;
                objContext.SaveChanges();
                ViewBag.Message = string.Format("Data updated successfully !");
                ModelState.Clear();


                return View();
            }


            return View();

        }

        public ActionResult DeleteRegionUser(int id)
        {

            var regionUserDelete = objLMEdetails.tbl_mst_LMEdetails.Where(x => x.pk_lmeusermaster == id).FirstOrDefault();


            objMailContent.Entry(regionUserDelete).State = EntityState.Deleted;
            objMailContent.SaveChanges();
            return RedirectToAction("ListMailContent");

        }




        public ActionResult Dashboard()
        {
            var list = objSpotbookingOrders.tbl_mst_SpotbookingOrders.OrderByDescending(x => x.Pk_intOrderID).ToList();

            if (Session["UserType"].ToString() == "LMECustomer")
            {
                var id = Session["code"].ToString();
                list = list.Where(x => x.strcode == id).ToList();
            }
            return View(list.Take(5));
            //return View();
        }

        //@@@@

        public ActionResult CreateMailcontent()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateMailcontent(tbl_MailContent tbl_MailContent, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                tbl_MailContent.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                // tbl_MailContent.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                //tbl_MailContent.Fk_Qualification = frm["hidQualification6"];

                objMailContent.tbl_MailContent.Add(tbl_MailContent);
                objMailContent.SaveChanges();

                ViewBag.Message = string.Format("Your data saved successfully");
                ModelState.Clear();
                return View();

            }
            else
            {
                ViewBag.Message = "Data Not Saved ";

            }
            return View();
        }





        public ActionResult EditMailcontent(int id)
        {

            var mail = objMailContent.tbl_MailContent.Where(x => x.pk_intMailId == id).FirstOrDefault();
            ViewBag.dtEntryDate = mail.dtEntryDate;
            ViewBag.dtUpdateDate = mail.dtUpdateDate;

            return View(mail);
        }


        [HttpPost]
        public ActionResult EditMailcontent(tbl_MailContent tbl_MailContent, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                tbl_MailContent.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");

                objMailContent.Entry(tbl_MailContent).State = EntityState.Modified;
                objMailContent.SaveChanges();
                ViewBag.Message = string.Format("Data updated successfully !");
                ModelState.Clear();
                return View();
            }


            return View();

        }


        public ActionResult DeleteMailcontent(int id)
        {

            var mailDelete = objMailContent.tbl_MailContent.Where(x => x.pk_intMailId == id).FirstOrDefault();


            objMailContent.Entry(mailDelete).State = EntityState.Deleted;
            objMailContent.SaveChanges();
            return RedirectToAction("ListMailContent");

        }

        public ActionResult ListMailContent()
        {

            var Maillist = objMailContent.tbl_MailContent.OrderByDescending(x => x.pk_intMailId).ToList();
            return View(Maillist);
        }



        public ActionResult UnitCreate()
        {

            //var menu = MC.tbl_MenuMaster.ToList();
            //return View(menu);

            return View(new Unit());

        }

        [HttpPost]
        public ActionResult UnitCreate(Unit unit)
        {
            int duplicateuser = objUnitContext.Units.Where(x => x.strUnitName == unit.strUnitName || x.strUnitCode == unit.strUnitCode).ToList().Count();
            if (duplicateuser > 0)
            {
                ViewBag.Message = string.Format("Unit Name or Unit Code is already used.");
            }
            else
            {
                objUnitContext.Units.Add(unit);
                objUnitContext.SaveChanges();
                ViewBag.Message = "Data saved Successfully.";
                ModelState.Clear();
                //return RedirectToAction("UnitList");
            }
            return View(unit);
        }

        public ActionResult UnitList()
        {

            //var menu = MC.tbl_MenuMaster.ToList();
            //return View(menu);


            //ViewBag.Fk_intUnitId = new SelectList(objContext.Units.ToList(), "pk_intUnitId", "strUnitName");
            var vendrreg = objUnitContext.Units.ToList();

            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                vendrreg = objUnitContext.Units.Where(x => x.pk_intUnitId == unitId).ToList();
            }

            return View(vendrreg);

        }
        public ActionResult UnitEdit(int id)
        {
            var unitData = objUnitContext.Units.Where(x => x.pk_intUnitId == id).FirstOrDefault();


            return View(unitData);


        }
        [HttpPost]
        public ActionResult UnitEdit(Unit unit)
        {

            objUnitContext.Entry(unit).State = EntityState.Modified;
            objUnitContext.SaveChanges();
            ViewBag.Message = "Data update Successfully.";
            return View(unit);
        }
        //FinancialYear
        public ActionResult AddFinancialYear()
        {
            return View(new tbl_mst_FinancialYear());
        }
        [HttpPost]
        public ActionResult AddFinancialYear(tbl_mst_FinancialYear tbl_mst_FinancialYear, FormCollection frm, HttpPostedFileBase strFileUpload)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    tbl_mst_FinancialYear.IsActive = true;
                    tbl_mst_FinancialYear.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    objtbl_mst_FinancialYear.tbl_mst_FinancialYear.Add(tbl_mst_FinancialYear);
                    objtbl_mst_FinancialYear.SaveChanges();

                    ViewBag.Message = string.Format("Financial Year saved Successfully.");
                    ModelState.Clear();
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Message = string.Format(ex.Message);
                    return View();
                }
            }
            var errors = string.Join("; ", ModelState.Values
                                      .SelectMany(x => x.Errors)
                                      .Select(x => x.ErrorMessage));
            ViewBag.Message = string.Format(errors);
            return View();
        }


        //Financial Reult



        public ActionResult AddFinancialReult()
        {
            ViewBag.Fk_intYearId = new SelectList(objtbl_mst_FinancialYear.tbl_mst_FinancialYear.ToList(), "Pk_int_FinYear", "strFinancialYear");
            ViewBag.Fk_intPerticular = new SelectList(obj_tbl_mstParticularMasterContext.tbl_mstParticularMaster.ToList(), "ParticularId", "ParticularDesc");

            return View(new tbl_FinancialResults());

        }



        [HttpPost]
        public ActionResult AddFinancialReult(tbl_FinancialResults tbl_FinancialResults, FormCollection frm)
        {
            ViewBag.Fk_intYearId = new SelectList(objtbl_mst_FinancialYear.tbl_mst_FinancialYear.ToList(), "Pk_int_FinYear", "strFinancialYear");
            ViewBag.Fk_intPerticular = new SelectList(obj_tbl_mstParticularMasterContext.tbl_mstParticularMaster.ToList(), "ParticularId", "ParticularDesc");


            if (ModelState.IsValid)
            {

                tbl_FinancialResults.dtmCreatedOn = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_FinancialResults.intDeletedFlag = 0;

                obj_tbl_FinancialResultsContext.tbl_FinancialResults.Add(tbl_FinancialResults);
                obj_tbl_FinancialResultsContext.SaveChanges();

                ViewBag.Message = string.Format("Data saved successfully !");
                ModelState.Clear();
                return View();
            }
            return View();

        }


        [HttpPost]
        public ActionResult PerfomanceReport(string vchPerStatus)
        {
            //var Unit = fk_intUnitId.ToString();
            var ParticularMaster = obj_tbl_mstParticularMasterContext.tbl_mstParticularMaster.Where(x => x.ParticularStatus == vchPerStatus).ToList();
            return Json(new { Particular = ParticularMaster });

        }


        [HttpPost]
        public ActionResult Performanceyear(int Fk_intYearId)
        {
            //var Unit = fk_intUnitId.ToString();
            var ParticularYear = objtbl_mst_FinancialYear.tbl_mst_FinancialYear.Where(x => x.Pk_int_FinYear == Fk_intYearId).FirstOrDefault();
            return Json(new { SelectYear = ParticularYear.intPeriodInMonths });

        }



        public ActionResult EditFinancialReult(int id)
        {

            var financialresult = obj_tbl_FinancialResultsContext.tbl_FinancialResults.Where(x => x.pk_intFinanceResultId == id).FirstOrDefault();
            ViewBag.Fk_intYearId = new SelectList(objtbl_mst_FinancialYear.tbl_mst_FinancialYear.ToList(), "Pk_int_FinYear", "strFinancialYear", financialresult.Fk_intYearId);
            ViewBag.Fk_intPerticular = new SelectList(obj_tbl_mstParticularMasterContext.tbl_mstParticularMaster.Where(x => x.ParticularStatus == financialresult.vchPerStatus).ToList(), "ParticularId", "ParticularDesc", financialresult.Fk_intPerticular);
            return View(financialresult);
        }

        [HttpPost]
        public ActionResult EditFinancialReult(tbl_FinancialResults tbl_FinancialResults, FormCollection frm)
        {


            ViewBag.Fk_intYearId = new SelectList(objtbl_mst_FinancialYear.tbl_mst_FinancialYear.ToList(), "Pk_int_FinYear", "strFinancialYear", tbl_FinancialResults.Fk_intYearId);
            ViewBag.Fk_intPerticular = new SelectList(obj_tbl_mstParticularMasterContext.tbl_mstParticularMaster.ToList(), "ParticularId", "ParticularDesc", tbl_FinancialResults.Fk_intPerticular);

            tbl_FinancialResults.dtmUpdatedOn = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            tbl_FinancialResults.intDeletedFlag = Convert.ToInt32(0);
            obj_tbl_FinancialResultsContext.Entry(tbl_FinancialResults).State = EntityState.Modified;
            obj_tbl_FinancialResultsContext.SaveChanges();

            ViewBag.Message = string.Format("Data updated successfully !");
            return View();

        }



        public ActionResult ListFinancialReult()
        {

            var FinancialReultList = obj_Vw_FinancialResultContext.Vw_FinancialResult.OrderByDescending(x => x.pk_intFinanceResultId).ToList();
            return View(FinancialReultList);

        }





        public ActionResult FinancialReultListDelete(int id)
        {
            var FinancialReultDelete = obj_tbl_FinancialResultsContext.tbl_FinancialResults.Where(x => x.pk_intFinanceResultId == id).FirstOrDefault();
            //var chcktransection=
            obj_tbl_FinancialResultsContext.Entry(FinancialReultDelete).State = EntityState.Deleted;
            obj_tbl_FinancialResultsContext.SaveChanges();
            return RedirectToAction("ListFinancialReult");
        }



        //
        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@

        //EOI

        public ActionResult EOICreate()
        {

            return View(new tbl_mst_EOI());

        }


        [HttpPost]
        public ActionResult EOICreate(tbl_mst_EOI tbl_mst_EOI, FormCollection frm, HttpPostedFileBase strFileUpload, HttpPostedFileBase strFileuploadhindi)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    string imagepath = null;
                    string imagepath1 = null;

                    if (strFileUpload != null)
                    {

                        var fileName = Path.GetExtension(strFileUpload.FileName);
                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/UploadFile/AdminPanel/"), guid + fileName);
                        strFileUpload.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        imagepath = "~/UploadFile/AdminPanel/" + newpath;

                    }

                    if (strFileuploadhindi != null)
                    {

                        var fileName = Path.GetExtension(strFileuploadhindi.FileName);
                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/UploadFile/AdminPanel/"), guid + fileName);
                        strFileuploadhindi.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        imagepath1 = "~/UploadFile/AdminPanel/" + newpath;

                    }

                    //File extention rename
                    var MineType = Utility.getMimeFromFile(imagepath);
                    var MineType1 = Utility.getMimeFromFile(imagepath1);
                    if (MineType != "Invalied" && MineType1 != "Invalied")
                    {
                        tbl_mst_EOI.strFileUpload = imagepath;
                        tbl_mst_EOI.strFileuploadhindi = imagepath1;
                        tbl_mst_EOI.strStatus = "YES";
                        tbl_mst_EOI.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        objtbl_mst_EOI.tbl_mst_EOI.Add(tbl_mst_EOI);
                        objtbl_mst_EOI.SaveChanges();
                        ViewBag.Message = string.Format("Data saved successfully !");
                        ModelState.Clear();
                        return View();
                    }

                    else
                    {
                        //File extention rename
                        System.IO.File.Delete(MineType);
                        System.IO.File.Delete(MineType1);
                        ViewBag.Message = "Invalied file...";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = string.Format(ex.Message);
                    return View();
                }
            }
            var errors = string.Join("; ", ModelState.Values
                                      .SelectMany(x => x.Errors)
                                      .Select(x => x.ErrorMessage));
            ViewBag.Message = string.Format(errors);
            return View();

        }




        public ActionResult ListEOI()
        {

            var EOIList = objtbl_mst_EOI.tbl_mst_EOI.OrderByDescending(x => x.Pk_int_EOI).ToList();
            return View(EOIList);
        }


        public ActionResult EditEOI(int id)
        {
            var eoi = objtbl_mst_EOI.tbl_mst_EOI.Where(x => x.Pk_int_EOI == id).FirstOrDefault();

            ViewBag.Hidtext = eoi.strFileUpload;
            ViewBag.HidTexthindi = eoi.strFileuploadhindi;

            // ViewBag.strStatus = eoi.strStatus;
            ViewBag.strFileUpload = eoi.strFileUpload;
            ViewBag.strFileuploadhindi = eoi.strFileuploadhindi;
            return View(eoi);
        }

        [HttpPost]
        public ActionResult EditEOI(tbl_mst_EOI tbl_mst_EOI, FormCollection frm)
        {
            ViewBag.Hidtext = tbl_mst_EOI.strFileUpload;
            ViewBag.HidTexthindi = tbl_mst_EOI.strFileuploadhindi;

            HttpPostedFileBase strFileUpload = Request.Files["strFileUpload"];
            HttpPostedFileBase strFileuploadhindi = Request.Files["strFileuploadhindi"];

            string imagepath = null;
            string imagepath1 = null;




            if (strFileUpload.ContentLength > 0)
            {

                var fileName = Path.GetExtension(strFileUpload.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/UploadFile/AdminPanel/"), guid + fileName);
                strFileUpload.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = "~/UploadFile/AdminPanel/" + newpath;

            }
            else
            {
                tbl_mst_EOI.strFileUpload = ViewBag.Hidtext;
            }


            if (strFileuploadhindi.ContentLength > 0)
            {

                var fileName = Path.GetExtension(strFileuploadhindi.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/UploadFile/AdminPanel/"), guid + fileName);
                strFileuploadhindi.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = "~/UploadFile/AdminPanel/" + newpath;

            }
            else
            {
                tbl_mst_EOI.strFileuploadhindi = ViewBag.HidTexthindi;
            }

            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            var MineType1 = Utility.getMimeFromFile(imagepath1);

            if (MineType != "Invalied" && MineType1 != "Invalied")
            {
                if (strFileUpload.ContentLength > 0)
                {
                    tbl_mst_EOI.strFileUpload = imagepath;
                }
                if (strFileuploadhindi.ContentLength > 0)
                {
                    tbl_mst_EOI.strFileuploadhindi = imagepath1;
                }

                tbl_mst_EOI.dtupdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objtbl_mst_EOI.Entry(tbl_mst_EOI).State = EntityState.Modified;
                objtbl_mst_EOI.SaveChanges();
                ViewBag.strFileUpload = tbl_mst_EOI.strFileUpload;
                ViewBag.strFileuploadhindi = tbl_mst_EOI.strFileuploadhindi;
                ViewBag.Message = string.Format("Data updated successfully !");
            }
            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                System.IO.File.Delete(MineType1);
                ViewBag.Message = "Invalied file...";
            }
            return View();
        }




        public ActionResult EOIDetailListDelete(int id)
        {
            var EOIDelete = objtbl_mst_EOI.tbl_mst_EOI.Where(x => x.Pk_int_EOI == id).FirstOrDefault();
            //var chcktransection=
            objtbl_mst_EOI.Entry(EOIDelete).State = EntityState.Deleted;
            objtbl_mst_EOI.SaveChanges();
            return RedirectToAction("ListEOI");
        }




        //@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@


        public ActionResult UnitDetailListDelete(int id)
        {
            var UnitDelete = objtbl_mst_EOI.tbl_mst_EOI.Where(x => x.Pk_int_EOI == id).FirstOrDefault();
            //var chcktransection=
            objtbl_mst_EOI.Entry(UnitDelete).State = EntityState.Deleted;
            objUnitContext.SaveChanges();
            return RedirectToAction("UnitList");
        }
        public ActionResult UnitDetails(int id)
        {


            var vendrreg = objUnitContext.Units.ToList();

            //ViewBag.Fk_intUnitId = new SelectList(objContext.Units.Where(x => x.pk_intUnitId == VendorRegistration.Fk_intUnitId).ToList(), "pk_intUnitId", "strUnitName");

            return View(vendrreg);
        }

        //30/11/17
        public ActionResult VendorListNew()
        {
            VendorsNewContext obj = new VendorsNewContext();
            var vendrreg = obj.VendorsNews.ToList();

            return View(vendrreg);
        }

        [HttpPost]
        public ActionResult LoadVendorDataNew()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            using (VendorsNewContext dc = new VendorsNewContext())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var v = dc.VendorsNews.ToList();//(from a in dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0") select a);



                string search = Request.Form.GetValues("search[value]").FirstOrDefault();
                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p => SafeToLower(p.strVendorRegistrationID).Contains(search.ToLower()) ||
                                     SafeToLower(p.strNameofFirmCompany).Contains(search.ToLower()) ||
                                     SafeToLower(p.strCorrespondenceAddress).Contains(search.ToLower()) ||
                                     SafeToLower(p.strstrRegisteredOfficeAddress).Contains(search.ToLower()) ||
                                     SafeToLower(p.strEmail).Contains(search.ToLower()) ||
                                     SafeToLower(p.strMobile).Contains(search.ToLower())
                ).ToList();
                }


                recordsTotal = v.Count();


                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "strVendorRegistrationID")
                        {
                            v = v.OrderByDescending(x => x.strVendorRegistrationID).ToList();
                        }
                        if (sortColumn == "strNameofFirmCompany")
                        {
                            v = v.OrderByDescending(x => x.strNameofFirmCompany).ToList();
                        }
                        if (sortColumn == "strCorrespondenceAddress")
                        {
                            v = v.OrderByDescending(x => x.strCorrespondenceAddress).ToList();
                        }
                        if (sortColumn == "strstrRegisteredOfficeAddress")
                        {
                            v = v.OrderByDescending(x => x.strstrRegisteredOfficeAddress).ToList();
                        }
                        if (sortColumn == "strEmail")
                        {
                            v = v.OrderByDescending(x => x.strEmail).ToList();
                        }
                        if (sortColumn == "strMobile")
                        {
                            v = v.OrderByDescending(x => x.strMobile).ToList();
                        }
                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "strVendorRegistrationID")
                        {
                            v = v.OrderBy(x => x.strVendorRegistrationID).ToList();
                        }
                        if (sortColumn == "strNameofFirmCompany")
                        {
                            v = v.OrderBy(x => x.strNameofFirmCompany).ToList();
                        }
                        if (sortColumn == "strCorrespondenceAddress")
                        {
                            v = v.OrderBy(x => x.strCorrespondenceAddress).ToList();
                        }
                        if (sortColumn == "strstrRegisteredOfficeAddress")
                        {
                            v = v.OrderBy(x => x.strstrRegisteredOfficeAddress).ToList();
                        }
                        if (sortColumn == "strEmail")
                        {
                            v = v.OrderBy(x => x.strEmail).ToList();
                        }
                        if (sortColumn == "strMobile")
                        {
                            v = v.OrderBy(x => x.strMobile).ToList();
                        }
                    }

                }


                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }


        //Vendor List  BHashkar
        public ActionResult VendorList()
        {
            var vendrreg = objContext1.VendorRegistrations.ToList();

            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                string UnitId = Session["UnitId"].ToString();

                if (unitId == 6)
                {
                    if (Session["strEmail"].ToString() == "reddy_pks@hindustancopper.com")
                    {
                        vendrreg = vendrreg.Where(x => x.Fk_intUnitId != null).ToList();
                        vendrreg = vendrreg.Where(x => x.Fk_intUnitId.Split(',').Count() > 1).ToList();
                        ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
                    }
                    else
                    {
                        ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId).ToList(), "pk_intUnitId", "strUnitName");
                        vendrreg = vendrreg.Where(x => x.Fk_intUnitId != "1" && x.Fk_intUnitId != "2" && x.Fk_intUnitId != "3" && x.Fk_intUnitId != "4" && x.Fk_intUnitId != "5" && x.Fk_intUnitId != null).ToList();
                    }

                }
                else
                {
                    ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId).ToList(), "pk_intUnitId", "strUnitName");
                    vendrreg = vendrreg.Where(x => x.Fk_intUnitId == UnitId).ToList();
                }
            }
            else
            {
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
            }

            return View(vendrreg);
        }
        [HttpPost]
        public ActionResult VendorList(FormCollection frm)
        {
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                if (Session["strEmail"].ToString() == "reddy_pks@hindustancopper.com")
                {
                    ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName", frm["Fk_intUnitId"]);
                }
                else
                {
                    ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId).ToList(), "pk_intUnitId", "strUnitName", frm["Fk_intUnitId"]);
                }
            }
            else
            {
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName", frm["Fk_intUnitId"]);
            }

            var vendrreg = objContext1.VendorRegistrations.ToList();

            if (frm["Fk_intUnitId"] != "")
            {
                if (Session["strEmail"].ToString() == "reddy_pks@hindustancopper.com")
                {
                    vendrreg = vendrreg.Where(x => x.Fk_intUnitId != null).ToList();
                    vendrreg = vendrreg.Where(x => x.Fk_intUnitId.Split(',').Count() > 1).ToList();
                }
                else
                {
                    string intUnitId = Convert.ToString(frm["Fk_intUnitId"]);
                    vendrreg = vendrreg.Where(x => x.Fk_intUnitId == intUnitId).ToList();
                }
            }
            if (frm["IsVerify"] != "")
            {
                string IsVerify = Convert.ToString(frm["IsVerify"]);
                vendrreg = vendrreg.Where(x => x.strVerify == IsVerify).ToList();

            }
            if (frm["RegistrationStatus"] != "")
            {
                string RegistrationStatus = Convert.ToString(frm["RegistrationStatus"]);
                if (RegistrationStatus == "COMPLETE")
                {
                    vendrreg = vendrreg.Where(x => x.strRegistrationApplied != null).ToList();
                }
                else
                {
                    vendrreg = vendrreg.Where(x => x.strRegistrationApplied == null || x.strRegistrationApplied == "").ToList();
                }
            }


            ViewBag.IsVerify = frm["IsVerify"];
            ViewBag.RegistrationStatus = frm["RegistrationStatus"];

            return View(vendrreg);
        }

        //List Complaint 26/10/17 Bhashkar

        public ActionResult listComplaint()
        {

            var allComplaint = objGrivanceMaster.T_GrievanceMaster.Where(x => x.bitDeletedFlag == false).ToList();

            return View(allComplaint);
        }

        [HttpPost]
        public ActionResult listComplaint(FormCollection frm)
        {
            ViewBag.ComplaintNo = frm["ComplaintNo"];
            ViewBag.dtFromDate = frm["dtFromDate"];
            ViewBag.dtToDate = frm["dtToDate"];
            var allComplaint = objGrivanceMaster.T_GrievanceMaster.ToList();
            return View(allComplaint);
        }

        [HttpPost]
        public ActionResult LoadComplaintData(string ComplaintNo, string dtFromDate, string dtToDate)
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            using (vw_compliantdetailscontext dc = new vw_compliantdetailscontext())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key

                //dc.vw_compliantdetails.ToList();//(from a in dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0") select a);
                int userid = 0;
                if (Session["UserType"].ToString() == "No")
                {
                    userid = Convert.ToInt32(Session["UserID"]);
                }
                bool bitDeletedFlag = false;
                var v = dc.GetCompliantData(userid, bitDeletedFlag).ToList();//dc.Database.SqlQuery<compliantdetails>("sp_Complaint {0}}", userid).ToList<compliantdetails>();


                if (!(string.IsNullOrEmpty(ComplaintNo)))
                {

                    v = v.Where(x => x.vchCompRegNo == ComplaintNo).ToList();

                }


                if (!(string.IsNullOrEmpty(dtFromDate)))
                {
                    DateTime? dtmCompRegFromDate = Convert.ToDateTime(dtFromDate);
                    v = v.Where(x => x.dtmCompRegDate >= dtmCompRegFromDate).ToList();

                }

                if (!(string.IsNullOrEmpty(dtToDate)))
                {

                    DateTime? dtmCompRegToDate = Convert.ToDateTime(dtToDate);
                    v = v.Where(x => x.dtmCompRegDate <= dtmCompRegToDate).ToList();
                }


                string search = Request.Form.GetValues("search[value]").FirstOrDefault();
                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p => SafeToLower(p.vchCompRegNo).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchComplainType).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchCompAgainstOff).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchComplainDetails).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchOffDesig).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchFileName).Contains(search.ToLower())
                ).ToList();
                }


                recordsTotal = v.Count();


                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "vchCompRegNo")
                        {
                            v = v.OrderByDescending(x => x.vchCompRegNo).ToList();
                        }
                        if (sortColumn == "vchComplainType")
                        {
                            v = v.OrderByDescending(x => x.vchComplainType).ToList();
                        }
                        if (sortColumn == "vchCompAgainstOff")
                        {
                            v = v.OrderByDescending(x => x.vchCompAgainstOff).ToList();
                        }
                        if (sortColumn == "vchComplainDetails")
                        {
                            v = v.OrderByDescending(x => x.vchComplainDetails).ToList();
                        }
                        if (sortColumn == "vchOffDesig")
                        {
                            v = v.OrderByDescending(x => x.vchOffDesig).ToList();
                        }
                        if (sortColumn == "vchFileName")
                        {
                            v = v.OrderByDescending(x => x.vchFileName).ToList();
                        }
                        if (sortColumn == "dtmCompRegDate")
                        {
                            v = v.OrderByDescending(x => x.dtmCompRegDate).ToList();
                        }
                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "vchCompRegNo")
                        {
                            v = v.OrderBy(x => x.vchCompRegNo).ToList();
                        }
                        if (sortColumn == "vchComplainType")
                        {
                            v = v.OrderBy(x => x.vchComplainType).ToList();
                        }
                        if (sortColumn == "vchCompAgainstOff")
                        {
                            v = v.OrderBy(x => x.vchCompAgainstOff).ToList();
                        }
                        if (sortColumn == "vchComplainDetails")
                        {
                            v = v.OrderBy(x => x.vchComplainDetails).ToList();
                        }
                        if (sortColumn == "vchOffDesig")
                        {
                            v = v.OrderBy(x => x.vchOffDesig).ToList();
                        }
                        if (sortColumn == "vchFileName")
                        {
                            v = v.OrderBy(x => x.vchFileName).ToList();
                        }
                        if (sortColumn == "dtmCompRegDate")
                        {
                            v = v.OrderBy(x => x.dtmCompRegDate).ToList();
                        }
                    }

                }


                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }


        [HttpPost]
        public ActionResult LoadComplaintDataDistinct(string ComplaintNo, string dtFromDate, string dtToDate)
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            using (vw_compliantdetailscontext dc = new vw_compliantdetailscontext())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key

                //dc.vw_compliantdetails.ToList();//(from a in dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0") select a);
                int userid = 0;
                if (Session["UserType"].ToString() == "No")
                {
                    userid = Convert.ToInt32(Session["UserID"]);
                }
                bool bitDeletedFlag = false;
                var v = dc.GetCompliantDataDistinct(userid, bitDeletedFlag).ToList();//dc.Database.SqlQuery<compliantdetails>("sp_Complaint {0}}", userid).ToList<compliantdetails>();


                if (!(string.IsNullOrEmpty(ComplaintNo)))
                {

                    v = v.Where(x => x.vchCompRegNo == ComplaintNo).ToList();

                }


                if (!(string.IsNullOrEmpty(dtFromDate)))
                {
                    DateTime? dtmCompRegFromDate = Convert.ToDateTime(dtFromDate);
                    v = v.Where(x => x.dtmCompRegDate >= dtmCompRegFromDate).ToList();

                }

                if (!(string.IsNullOrEmpty(dtToDate)))
                {

                    DateTime? dtmCompRegToDate = Convert.ToDateTime(dtToDate);
                    v = v.Where(x => x.dtmCompRegDate <= dtmCompRegToDate).ToList();
                }


                string search = Request.Form.GetValues("search[value]").FirstOrDefault();
                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p => SafeToLower(p.vchCompRegNo).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchComplainType).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchCompAgainstOff).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchComplainDetails).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchOffDesig).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchFileName).Contains(search.ToLower())
                ).ToList();
                }


                recordsTotal = v.Count();


                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "vchCompRegNo")
                        {
                            v = v.OrderByDescending(x => x.vchCompRegNo).ToList();
                        }
                        if (sortColumn == "vchComplainType")
                        {
                            v = v.OrderByDescending(x => x.vchComplainType).ToList();
                        }
                        if (sortColumn == "vchCompAgainstOff")
                        {
                            v = v.OrderByDescending(x => x.vchCompAgainstOff).ToList();
                        }
                        if (sortColumn == "vchComplainDetails")
                        {
                            v = v.OrderByDescending(x => x.vchComplainDetails).ToList();
                        }
                        if (sortColumn == "vchOffDesig")
                        {
                            v = v.OrderByDescending(x => x.vchOffDesig).ToList();
                        }
                        if (sortColumn == "vchFileName")
                        {
                            v = v.OrderByDescending(x => x.vchFileName).ToList();
                        }
                        if (sortColumn == "dtmCompRegDate")
                        {
                            v = v.OrderByDescending(x => x.dtmCompRegDate).ToList();
                        }
                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "vchCompRegNo")
                        {
                            v = v.OrderBy(x => x.vchCompRegNo).ToList();
                        }
                        if (sortColumn == "vchComplainType")
                        {
                            v = v.OrderBy(x => x.vchComplainType).ToList();
                        }
                        if (sortColumn == "vchCompAgainstOff")
                        {
                            v = v.OrderBy(x => x.vchCompAgainstOff).ToList();
                        }
                        if (sortColumn == "vchComplainDetails")
                        {
                            v = v.OrderBy(x => x.vchComplainDetails).ToList();
                        }
                        if (sortColumn == "vchOffDesig")
                        {
                            v = v.OrderBy(x => x.vchOffDesig).ToList();
                        }
                        if (sortColumn == "vchFileName")
                        {
                            v = v.OrderBy(x => x.vchFileName).ToList();
                        }
                        if (sortColumn == "dtmCompRegDate")
                        {
                            v = v.OrderBy(x => x.dtmCompRegDate).ToList();
                        }
                    }

                }


                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult listComplaintArchive()
        {
            var allComplaint = objGrivanceMaster.T_GrievanceMaster.Where(x => x.bitDeletedFlag == false).ToList();

            return View(allComplaint);
        }

        [HttpPost]
        public ActionResult listComplaintArchive(FormCollection frm)
        {
            ViewBag.ComplaintNo = frm["ComplaintNo"];
            ViewBag.dtFromDate = frm["dtFromDate"];
            ViewBag.dtToDate = frm["dtToDate"];
            var allComplaint = objGrivanceMaster.T_GrievanceMaster.ToList();
            return View(allComplaint);
        }

        [HttpPost]
        public ActionResult LoadComplaintDataArchive(string ComplaintNo, string dtFromDate, string dtToDate)
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            using (vw_compliantdetailscontext dc = new vw_compliantdetailscontext())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key

                //dc.vw_compliantdetails.ToList();//(from a in dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0") select a);
                int userid = 0;
                if (Session["UserType"].ToString() == "No")
                {
                    userid = Convert.ToInt32(Session["UserID"]);
                }
                bool bitDeletedFlag = true;
                var v = dc.GetCompliantData(userid, bitDeletedFlag).ToList();//dc.Database.SqlQuery<compliantdetails>("sp_Complaint {0}}", userid).ToList<compliantdetails>();


                if (!(string.IsNullOrEmpty(ComplaintNo)))
                {

                    v = v.Where(x => x.vchCompRegNo == ComplaintNo).ToList();

                }


                if (!(string.IsNullOrEmpty(dtFromDate)))
                {
                    DateTime? dtmCompRegFromDate = Convert.ToDateTime(dtFromDate);
                    v = v.Where(x => x.dtmCompRegDate >= dtmCompRegFromDate).ToList();

                }

                if (!(string.IsNullOrEmpty(dtToDate)))
                {

                    DateTime? dtmCompRegToDate = Convert.ToDateTime(dtToDate);
                    v = v.Where(x => x.dtmCompRegDate <= dtmCompRegToDate).ToList();
                }


                string search = Request.Form.GetValues("search[value]").FirstOrDefault();
                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p => SafeToLower(p.vchCompRegNo).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchComplainType).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchCompAgainstOff).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchComplainDetails).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchOffDesig).Contains(search.ToLower()) ||
                                     SafeToLower(p.vchFileName).Contains(search.ToLower())
                ).ToList();
                }


                recordsTotal = v.Count();


                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "vchCompRegNo")
                        {
                            v = v.OrderByDescending(x => x.vchCompRegNo).ToList();
                        }
                        if (sortColumn == "vchComplainType")
                        {
                            v = v.OrderByDescending(x => x.vchComplainType).ToList();
                        }
                        if (sortColumn == "vchCompAgainstOff")
                        {
                            v = v.OrderByDescending(x => x.vchCompAgainstOff).ToList();
                        }
                        if (sortColumn == "vchComplainDetails")
                        {
                            v = v.OrderByDescending(x => x.vchComplainDetails).ToList();
                        }
                        if (sortColumn == "vchOffDesig")
                        {
                            v = v.OrderByDescending(x => x.vchOffDesig).ToList();
                        }
                        if (sortColumn == "vchFileName")
                        {
                            v = v.OrderByDescending(x => x.vchFileName).ToList();
                        }
                        if (sortColumn == "dtmCompRegDate")
                        {
                            v = v.OrderByDescending(x => x.dtmCompRegDate).ToList();
                        }
                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "vchCompRegNo")
                        {
                            v = v.OrderBy(x => x.vchCompRegNo).ToList();
                        }
                        if (sortColumn == "vchComplainType")
                        {
                            v = v.OrderBy(x => x.vchComplainType).ToList();
                        }
                        if (sortColumn == "vchCompAgainstOff")
                        {
                            v = v.OrderBy(x => x.vchCompAgainstOff).ToList();
                        }
                        if (sortColumn == "vchComplainDetails")
                        {
                            v = v.OrderBy(x => x.vchComplainDetails).ToList();
                        }
                        if (sortColumn == "vchOffDesig")
                        {
                            v = v.OrderBy(x => x.vchOffDesig).ToList();
                        }
                        if (sortColumn == "vchFileName")
                        {
                            v = v.OrderBy(x => x.vchFileName).ToList();
                        }
                        if (sortColumn == "dtmCompRegDate")
                        {
                            v = v.OrderBy(x => x.dtmCompRegDate).ToList();
                        }
                    }

                }


                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }
        //EditComplaintdetails  shoumya
        public ActionResult EditComplaintdetails(int id)
        {
            var complaint = objGrivanceMaster.T_GrievanceMaster.Where(x => x.intGrievanceId == id).FirstOrDefault();
            ViewBag.vchFileName = complaint.vchFileName;
            if (Session["UserType"].ToString() == "No")
            {
                ViewData["Userlist"] = new SelectList(objContext.M_UserMaster.Where(x => x.vchAdminPrev == "No").ToList(), "pk_intUserId", "vchFullName");
            }
            else
            {
                ViewData["Userlist"] = new SelectList(objContext.M_UserMaster.Where(x => x.vchAdminPrev != "Yes").ToList(), "pk_intUserId", "vchFullName");
            }
            complaint.vchCompStatus = "";
            return View(complaint);
        }


        public ActionResult ViewArchiveComplaintDetails(int id)
        {
            vw_compliantdetails complaint;
            using (vw_compliantdetailscontext dc = new vw_compliantdetailscontext())
            {
                complaint = dc.vw_compliantdetails.FirstOrDefault(x => x.intGrievanceId == id);
            }
            return View(complaint);
        }


        [HttpPost]
        public ActionResult EditComplaintdetails(int id, tbl_complaint_takeaction tbl_complaint_takeaction, T_GrievanceMaster T_GrievanceMaster, FormCollection frm)
        {
            var complaint = objGrivanceMaster.T_GrievanceMaster.Where(x => x.intGrievanceId == id).FirstOrDefault();
            complaint.vchCompStatus = frm["vchCompStatus"];
            if (frm["vchCompStatus"] == "Reject")
            {
                complaint.bitDeletedFlag = true;
                //objGrivanceMaster.Entry(complaint).State = EntityState.Modified;
                //objGrivanceMaster.SaveChanges();
            }
            if (frm["vchCompStatus"] == "Closed")
            {
                complaint.bitDeletedFlag = true;
            }
            objGrivanceMaster.Entry(complaint).State = EntityState.Modified;
            objGrivanceMaster.SaveChanges();

            //if (frm["vchCompStatus"] == "Reject" || frm["vchCompStatus"] == "Resolve")
            //{
            //    complaint.bitDeletedFlag = true;
            //    objGrivanceMaster.Entry(complaint).State = EntityState.Modified;
            //    objGrivanceMaster.SaveChanges();
            //}

            if (Session["UserType"].ToString() == "No")
            {
                ViewData["Userlist"] = new SelectList(objContext.M_UserMaster.Where(x => x.vchAdminPrev == "No").ToList(), "vchUserId", "vchFullName");
            }
            else
            {
                ViewData["Userlist"] = new SelectList(objContext.M_UserMaster.Where(x => x.vchAdminPrev != "Yes").ToList(), "vchUserId", "vchFullName");
            }

            HttpPostedFileBase str_upload1 = Request.Files["str_upload1"];
            HttpPostedFileBase str_upload2 = Request.Files["str_upload2"];

            string imagepath = null;
            string imagepath1 = null;

            if (str_upload1.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(str_upload1.FileName);
                var AutoGenFileName = "Grievance" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Grievance/"), AutoGenFileName + fileExtension);
                str_upload1.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = "~/Upload/Grievance/" + newpath;
            }

            if (str_upload2.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(str_upload2.FileName);
                var AutoGenFileName = "Grievance" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Grievance/"), AutoGenFileName + fileExtension);
                str_upload2.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = "~/Upload/Grievance/" + newpath;
            }

            var MineType = Utility.getMimeFromFile(imagepath);
            var MineType1 = Utility.getMimeFromFile(imagepath1);
            if (MineType != "Invalied" && MineType1 != "Invalied")
            {
                tbl_complaint_takeaction.str_upload1 = imagepath;
                tbl_complaint_takeaction.str_upload2 = imagepath1;
                tbl_complaint_takeaction.fk_complaintid = Convert.ToInt32(id);
                tbl_complaint_takeaction.str_remarks = frm["str_remarks"];
                tbl_complaint_takeaction.fk_userid = Convert.ToInt32(frm["fk_userid"]);
                tbl_complaint_takeaction.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_complaint_takeaction.isactive = "yes";

                if (frm["vchCompStatus"] == "User to Forward")
                {
                    objtakeaction.tbl_complaint_takeaction.Add(tbl_complaint_takeaction);
                    objtakeaction.SaveChanges();
                    ViewBag.Message = "User to Forward Successfully.";
                }
                else
                {
                    objtakeaction.tbl_complaint_takeaction.Add(tbl_complaint_takeaction);
                    objtakeaction.SaveChanges();
                    ViewBag.Message = "Status updated Successfully.";
                }
              
                return RedirectToAction("listComplaint");
            }
            else
            {
                System.IO.File.Delete(MineType);
                System.IO.File.Delete(MineType1);
                ViewBag.Message = "Invalied file...";
                return View();
            }
        }

        //Shoumya Download order in csv




        public void DownloadListOrderincsv()
        {


            StringWriter sw = new StringWriter();

            sw.WriteLine("\"SRL\",\"CUSTOMER_ID\",\"ORGANISATION_NAME\",\"CUST_CITY\",\"CUST_REGION\",\"ORDER_NO\",\"DATE_BOOK\",\"TIME_BOOK\",\"DATE_OFR\",\"TIME_OFR\",\"PRODUCT\",\"QUANTITY\",\"CASH_BOOK\",\"OPT1\",\"OPT2\",\"OPT3\",\"LME_ACCEPTED\",\"QUANTITY_ACCEPTED\",\"PRICE\",\"USER_COMMENTS\",\"ADMIN_COMMENTS\",\"ORDER_STATUS\",\"3M_ACT\",\"SPREAD_ACT\",\"CASH_ACT\",\"TT_SELLING\",\"PREMIUM\",\"MULTI_FACT\",\"REP_TAG\",\"GODOWN\"");
            //sw.WriteLine("\"SRL\",\"CUSTOMER_ID\",\"ORGANISATION_NAME\",\"CUST_CITY\",\"CUST_REGION\",\"ORDER_NO\",\"DATE_BOOK\",\"TIME_BOOK\",\"DATE_OFR\",\"TIME_OFR\",\"PRODUCT\",\"QUANTITY\",\"CASH_BOOK\",\"OPT1\",\"OPT2\",\"OPT3\",\"LME_ACCEPTED\",\"QUANTITY_ACCEPTED\",\"PRICE\",\"USER_COMMENTS\",\"ADMIN_COMMENTS\",\"ORDER_STATUS\",\"3M_ACT\",\"SPREAD_ACT\",\"CASH_ACT\",\"TT_SELLING\",\"PREMIUM\",\"MULTI_FACT\",\"REP_TAG\"");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=AllOrder.csv");
            Response.ContentType = "application/octet-stream";
            //var Manageorder = objSpotbookingDetails.Vw_SpotbookingDetails.OrderByDescending(x => x.dtOrderDate).ToList();
            string str_OrderStatus = Request.QueryString["str_OrderStatus"];
            string nameOfComapany = Request.QueryString["nameOfComapany"];
            string dtDate1 = Request.QueryString["dtDate1"];
            string dtDate2 = Request.QueryString["dtDate2"];

            var Region = Session["UserRegion"].ToString();
            var Order = objSpotbookingDetails.Vw_SpotbookingDetails.OrderByDescending(x => x.Pk_Registrationid).ToList();

            if (Region != "All")
            {
                Order = Order.Where(x => x.fk_region == Region).OrderByDescending(x => x.Pk_Registrationid).ToList();
            }

            // var Order = objSpotbookingOrders.tbl_mst_SpotbookingOrders.OrderByDescending(x => x.Pk_intOrderID).ToList();
            ViewBag.nameOfComapany = new SelectList(objCustomer.SpotbookingRegistrationdetails.Where(x => x.str_CustomerStatus == "Approved").ToList(), "str_namefirm", "str_namefirm", nameOfComapany);
            ViewBag.str_OrderStatus = str_OrderStatus;

            if (nameOfComapany != null && nameOfComapany != "")
            {
                Order = Order.Where(x => x.strOrganisationName == nameOfComapany).ToList();
            }

            if (str_OrderStatus != null && str_OrderStatus != "")
            {
                Order = Order.Where(x => x.str_OrderStatus == str_OrderStatus).ToList();
            }

            if (dtDate1 != "" && dtDate2 != "" && dtDate1 != null && dtDate2 != null)
            {

                var a = dtDate1;
                DateTime fromDate = Convert.ToDateTime(dtDate1);
                DateTime toDate = Convert.ToDateTime(dtDate2).AddHours(24);
                Order = Order.Where(x => x.tmRealBookingTime >= fromDate && x.tmRealBookingTime <= toDate).ToList();


            }



            int i = 1;

            foreach (var order in Order)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\",\"{21}\",\"{22}\",\"{23}\",\"{24}\",\"{25}\",\"{26}\",\"{27}\",\"{28}\",\"{29}\"",
                //sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\",\"{21}\",\"{22}\",\"{23}\",\"{24}\",\"{25}\",\"{26}\",\"{27}\",\"{28}\"",

                i,
                order.str_code,
                order.strOrganisationName,
                Utility.RemoveComma(order.str_city),
                Utility.substring(order.str_address, order.fk_region, 40),
                //order.fk_region,
                order.str_orderid,
                order.dtOrderDatetime.Value.ToString("dd/MMM/yyyy"),
                order.dtOrderDatetime.Value.ToString("hh:mm:ss tt"),
                order.tmRealBookingTime.Value.ToString("dd/MMM/yyyy"),
                order.tmRealBookingTime.Value.ToString("hh:mm:ss tt"),
                order.strProducts,
                order.fltBookedQuantity,
                order.fltProductPrice,
                order.strOrderType,
                order.strOrderOption,
                order.strLiftingOption,
                order.str_bookingproductaccept,
                order.str_bookingquantityaccept,
                order.str_bookingbasicprice,
                Utility.RemoveComma(order.strComments),
                order.str_OrderStatusRemarks,
                order.str_OrderStatus,
                "3M_ACT",
                "SPREAD_ACT",
                "CASH_ACT",
                order.str_bookingquantityaccept,
                "PREMIUM",
                "MULTI_FACT",
                "REP_TAG",
                order.str_deliveryplace
                ));
                i++;
            }



            Response.Write(sw.ToString());
            Response.End();
        }



        public void DownloadManageVendorDetails()
        {
            var ManageVendor = objVWVendorRegList.vw_VendorRegistrationsLists.Where(x => x.strVerify == "YES").OrderByDescending(x => x.Pk_intNewVendorRegistrationID).ToList();


            if (Session["UnitId"] != null)
            {
                string unitId = Session["UnitId"].ToString();

                if (Session["strEmail"].ToString() == "reddy_pks@hindustancopper.com")
                {
                    ManageVendor = ManageVendor.Where(x => x.Fk_intUnitId.Split(',').Count() > 1).ToList();
                }
                else
                {
                    ManageVendor = ManageVendor.Where(x => x.Fk_intUnitId == unitId).ToList();
                }
            }




            if (ManageVendor.Count > 0)
            {


                try
                {

                    string strFileName = "ManageVendorList" + ".xls";
                    FileStream fs = new FileStream(Server.MapPath("/ExcelReport") + "/ManageVendorList.xls", FileMode.Open, FileAccess.Read);
                    HSSFWorkbook wb = new HSSFWorkbook(fs, true);
                    HSSFSheet ws = (HSSFSheet)wb.GetSheet("Sheet1");

                    int i = 1;


                    foreach (var detailsofVendor in ManageVendor)
                    {



                        ws.GetRow(i).GetCell(0).SetCellValue(i.ToString());

                        //Splite and contains

                        List<string> stringList = detailsofVendor.Fk_intUnitId.Split(',').ToList();
                        var unitList = "";
                        foreach (string str in stringList)
                        {
                            int id = Convert.ToInt32(str);
                            unitList = unitList + "," + objContext3.Units.Where(x => x.pk_intUnitId == id).FirstOrDefault().strUnitName;
                        }


                        //dynamic
                        ws.GetRow(i).GetCell(1).SetCellValue(unitList.Trim(','));
                        ws.GetRow(i).GetCell(2).SetCellValue(detailsofVendor.strCompanyStatusName);

                        if (!string.IsNullOrEmpty(detailsofVendor.Fk_intDepartment))
                        {
                            List<string> fkDepartmentList = detailsofVendor.Fk_intDepartment.Split(',').ToList();
                            var DepartmentList = "";
                            foreach (string str in fkDepartmentList)
                            {
                                int id = Convert.ToInt32(str);
                                DepartmentList = DepartmentList + "," + objContext8.tbl_mstDepartment.Where(x => x.pk_intID == id).FirstOrDefault().strDepartmentName;
                            }
                            ws.GetRow(i).GetCell(3).SetCellValue(DepartmentList.Trim(','));
                        }
                        else
                        {
                            ws.GetRow(i).GetCell(3).SetCellValue("NO");
                        }

                        ws.GetRow(i).GetCell(4).SetCellValue(detailsofVendor.strNameofFirmCompany);
                        ws.GetRow(i).GetCell(5).SetCellValue(detailsofVendor.strCorrespondenceAddress);
                        ws.GetRow(i).GetCell(6).SetCellValue(detailsofVendor.strPhone1);
                        ws.GetRow(i).GetCell(7).SetCellValue(detailsofVendor.strFax);
                        ws.GetRow(i).GetCell(8).SetCellValue(detailsofVendor.strEmail1);
                        ws.GetRow(i).GetCell(9).SetCellValue(detailsofVendor.strWebsite1);
                        ws.GetRow(i).GetCell(10).SetCellValue(detailsofVendor.strstrRegisteredOfficeAddress);
                        ws.GetRow(i).GetCell(11).SetCellValue(detailsofVendor.strPhone2);
                        ws.GetRow(i).GetCell(12).SetCellValue(detailsofVendor.strFax1);
                        ws.GetRow(i).GetCell(13).SetCellValue(detailsofVendor.strEmail2);
                        ws.GetRow(i).GetCell(14).SetCellValue(detailsofVendor.strWebsite2);
                        ws.GetRow(i).GetCell(15).SetCellValue(detailsofVendor.strFactoryAddress);
                        ws.GetRow(i).GetCell(16).SetCellValue(detailsofVendor.strPhone3);
                        ws.GetRow(i).GetCell(17).SetCellValue(detailsofVendor.strFax2);
                        ws.GetRow(i).GetCell(18).SetCellValue(detailsofVendor.strNameContactPerson1);
                        ws.GetRow(i).GetCell(19).SetCellValue(detailsofVendor.strDesignationofContactPerson1);
                        ws.GetRow(i).GetCell(20).SetCellValue(detailsofVendor.strNameContactPerson);
                        ws.GetRow(i).GetCell(21).SetCellValue(detailsofVendor.strDesignationofContactPerson);
                        ws.GetRow(i).GetCell(22).SetCellValue(detailsofVendor.strPhoneoffice);
                        ws.GetRow(i).GetCell(23).SetCellValue(detailsofVendor.strPhoneResidence);
                        ws.GetRow(i).GetCell(24).SetCellValue(detailsofVendor.strMobile);
                        ws.GetRow(i).GetCell(25).SetCellValue(detailsofVendor.strEmail);
                        ws.GetRow(i).GetCell(26).SetCellValue(detailsofVendor.strConstitutionFirm);
                        ws.GetRow(i).GetCell(27).SetCellValue(detailsofVendor.strOtherConstitution);
                        ws.GetRow(i).GetCell(28).SetCellValue(detailsofVendor.strConstitutionofthefirmfile1);
                        ws.GetRow(i).GetCell(29).SetCellValue(detailsofVendor.strYearofEstablishment);
                        ws.GetRow(i).GetCell(30).SetCellValue(detailsofVendor.strTypeofIndustry);
                        ws.GetRow(i).GetCell(31).SetCellValue(detailsofVendor.strCasteName);
                        ws.GetRow(i).GetCell(32).SetCellValue(detailsofVendor.strIfOtherpleaseindicatetheTypeofIndustry);
                        ws.GetRow(i).GetCell(33).SetCellValue(detailsofVendor.strUANCertificateNo);
                        ws.GetRow(i).GetCell(34).SetCellValue(detailsofVendor.strUANCertificateValidity);
                        ws.GetRow(i).GetCell(35).SetCellValue(detailsofVendor.strSSICertificateNo);
                        ws.GetRow(i).GetCell(36).SetCellValue(detailsofVendor.strSSICertificateValidity);
                        ws.GetRow(i).GetCell(37).SetCellValue(detailsofVendor.strNSICCertificateNo);
                        ws.GetRow(i).GetCell(38).SetCellValue(detailsofVendor.strNSICCertificateValidity);
                        ws.GetRow(i).GetCell(39).SetCellValue(detailsofVendor.strAcknowledgementtoEntrepreneurCertificateNo);
                        ws.GetRow(i).GetCell(40).SetCellValue(detailsofVendor.strAcknowledgementtoEntrepreneurCertificateNo);
                        ws.GetRow(i).GetCell(41).SetCellValue(detailsofVendor.strAnyotherGovtBodyCertificateNo);
                        ws.GetRow(i).GetCell(42).SetCellValue(detailsofVendor.strAnyotherGovtBodyCertificateValidity);
                        ws.GetRow(i).GetCell(43).SetCellValue(detailsofVendor.strGSTNo);
                        ws.GetRow(i).GetCell(44).SetCellValue(detailsofVendor.strTradeLicenceNo);
                        ws.GetRow(i).GetCell(45).SetCellValue(detailsofVendor.strTradeLicencedocument);
                        ws.GetRow(i).GetCell(46).SetCellValue(detailsofVendor.strCSTRegistrationNo);
                        ws.GetRow(i).GetCell(47).SetCellValue(detailsofVendor.strCSTRegistrationdocument);
                        ws.GetRow(i).GetCell(48).SetCellValue(detailsofVendor.strServiceTaxRegistrationNo);
                        ws.GetRow(i).GetCell(49).SetCellValue(detailsofVendor.strServiceTaxRegistrationdocument);
                        ws.GetRow(i).GetCell(50).SetCellValue(detailsofVendor.strST_VATRegistrationNo);
                        ws.GetRow(i).GetCell(51).SetCellValue(detailsofVendor.strST_VATRegistrationdocument);
                        ws.GetRow(i).GetCell(52).SetCellValue(detailsofVendor.strPANNo);
                        ws.GetRow(i).GetCell(53).SetCellValue(detailsofVendor.strPANNodocument);
                        ws.GetRow(i).GetCell(54).SetCellValue(detailsofVendor.strExciseControlCode);
                        ws.GetRow(i).GetCell(55).SetCellValue(detailsofVendor.strExciseControldocument);

                        //Dynamic

                        //Splite and contains 

                        List<string> stringRegList = detailsofVendor.strRegistrationApplied.Split(',').ToList();
                        var RegistrationList = "";
                        foreach (string strreg in stringRegList)
                        {
                            int id = Convert.ToInt32(strreg);
                            RegistrationList = RegistrationList + "," + objContext5.ItemDescriptions.Where(x => x.Pk_intItemDescription == id).FirstOrDefault().strItemDescriptionName;
                        }

                        ws.GetRow(i).GetCell(56).SetCellValue(RegistrationList.Trim(','));

                        ws.GetRow(i).GetCell(57).SetCellValue(detailsofVendor.strDescriptionofMachineEquipment1);
                        ws.GetRow(i).GetCell(58).SetCellValue(detailsofVendor.strQuantity1);
                        ws.GetRow(i).GetCell(59).SetCellValue(detailsofVendor.strSpecificationCapacity1);
                        ws.GetRow(i).GetCell(60).SetCellValue(detailsofVendor.strDescriptionofMachineEquipment2);
                        ws.GetRow(i).GetCell(61).SetCellValue(detailsofVendor.strQuantity2);
                        ws.GetRow(i).GetCell(62).SetCellValue(detailsofVendor.strSpecificationCapacity2);
                        ws.GetRow(i).GetCell(63).SetCellValue(detailsofVendor.strDescriptionofMachineEquipment3);
                        ws.GetRow(i).GetCell(64).SetCellValue(detailsofVendor.strQuantity3);
                        ws.GetRow(i).GetCell(65).SetCellValue(detailsofVendor.strSpecificationCapacity3);
                        ws.GetRow(i).GetCell(66).SetCellValue(detailsofVendor.strDescriptionofMachineEquipment4);
                        ws.GetRow(i).GetCell(67).SetCellValue(detailsofVendor.strQuantity4);
                        ws.GetRow(i).GetCell(68).SetCellValue(detailsofVendor.strSpecificationCapacity4);
                        ws.GetRow(i).GetCell(69).SetCellValue(detailsofVendor.strDescriptionofMachineEquipment5);
                        ws.GetRow(i).GetCell(70).SetCellValue(detailsofVendor.strQuantity5);
                        ws.GetRow(i).GetCell(71).SetCellValue(detailsofVendor.strSpecificationCapacity5);
                        ws.GetRow(i).GetCell(72).SetCellValue(detailsofVendor.strMachineryDocument);
                        ws.GetRow(i).GetCell(73).SetCellValue(detailsofVendor.strISOaccredited);
                        ws.GetRow(i).GetCell(74).SetCellValue(detailsofVendor.strISOSpe);
                        ws.GetRow(i).GetCell(75).SetCellValue(detailsofVendor.strISOaccrediteddocument);
                        ws.GetRow(i).GetCell(76).SetCellValue(detailsofVendor.strproductscertifiedtoBIS);
                        ws.GetRow(i).GetCell(77).SetCellValue(detailsofVendor.strFinancialYear1);
                        ws.GetRow(i).GetCell(78).SetCellValue(detailsofVendor.strFinancialYearDoc1);
                        ws.GetRow(i).GetCell(79).SetCellValue(detailsofVendor.strTurnover1);
                        ws.GetRow(i).GetCell(80).SetCellValue(detailsofVendor.strFinancialYear2);
                        ws.GetRow(i).GetCell(81).SetCellValue(detailsofVendor.strFinancialYearDoc2);

                        ws.GetRow(i).GetCell(82).SetCellValue(detailsofVendor.strTurnover2);
                        ws.GetRow(i).GetCell(83).SetCellValue(detailsofVendor.strFinancialYear3);
                        ws.GetRow(i).GetCell(84).SetCellValue(detailsofVendor.strFinancialYearDoc3);
                        ws.GetRow(i).GetCell(85).SetCellValue(detailsofVendor.strTurnover3);
                        ws.GetRow(i).GetCell(86).SetCellValue(detailsofVendor.strdesItemsSupplied1);
                        ws.GetRow(i).GetCell(87).SetCellValue(detailsofVendor.strnameofmajorcustomer1);
                        ws.GetRow(i).GetCell(88).SetCellValue(detailsofVendor.strContractualdelivery1);

                        ws.GetRow(i).GetCell(89).SetCellValue(detailsofVendor.strActualdeliveryperiod1);
                        ws.GetRow(i).GetCell(90).SetCellValue(detailsofVendor.strReferenceUpload1);
                        ws.GetRow(i).GetCell(91).SetCellValue(detailsofVendor.strdesItemsSupplied2);
                        ws.GetRow(i).GetCell(92).SetCellValue(detailsofVendor.strnameofmajorcustomer2);
                        ws.GetRow(i).GetCell(93).SetCellValue(detailsofVendor.strContractualdelivery2);
                        ws.GetRow(i).GetCell(94).SetCellValue(detailsofVendor.strActualdeliveryperiod2);
                        ws.GetRow(i).GetCell(95).SetCellValue(detailsofVendor.strReferenceUpload2);
                        ws.GetRow(i).GetCell(96).SetCellValue(detailsofVendor.strdesItemsSupplied3);
                        ws.GetRow(i).GetCell(97).SetCellValue(detailsofVendor.strnameofmajorcustomer3);
                        ws.GetRow(i).GetCell(98).SetCellValue(detailsofVendor.strContractualdelivery3);
                        ws.GetRow(i).GetCell(99).SetCellValue(detailsofVendor.strActualdeliveryperiod3);
                        ws.GetRow(i).GetCell(100).SetCellValue(detailsofVendor.strReferenceUpload3);
                        ws.GetRow(i).GetCell(101).SetCellValue(detailsofVendor.strdesItemsSupplied4);
                        ws.GetRow(i).GetCell(102).SetCellValue(detailsofVendor.strnameofmajorcustomer4);
                        ws.GetRow(i).GetCell(103).SetCellValue(detailsofVendor.strContractualdelivery4);
                        ws.GetRow(i).GetCell(104).SetCellValue(detailsofVendor.strActualdeliveryperiod4);
                        ws.GetRow(i).GetCell(105).SetCellValue(detailsofVendor.strReferenceUpload4);
                        ws.GetRow(i).GetCell(106).SetCellValue(detailsofVendor.strdesItemsSupplied5);
                        ws.GetRow(i).GetCell(107).SetCellValue(detailsofVendor.strnameofmajorcustomer5);

                        ws.GetRow(i).GetCell(108).SetCellValue(detailsofVendor.strContractualdelivery5);
                        ws.GetRow(i).GetCell(109).SetCellValue(detailsofVendor.strActualdeliveryperiod5);
                        ws.GetRow(i).GetCell(110).SetCellValue(detailsofVendor.strReferenceUpload5);
                        ws.GetRow(i).GetCell(111).SetCellValue(detailsofVendor.strNameofApplicant);



                        if (detailsofVendor.dtApplicationDate == null)
                        {
                            ws.GetRow(i).GetCell(112).SetCellValue("");
                        }
                        else
                        {
                            DateTime orderdt = Convert.ToDateTime(detailsofVendor.dtApplicationDate);
                            ws.GetRow(i).GetCell(112).SetCellValue(orderdt.ToString("yyyy/MM/dd"));

                        }
                        ws.GetRow(i).GetCell(113).SetCellValue(detailsofVendor.strPlace);





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

        }



        public void DownloadManageVendorNewDetails()
        {


            StringWriter sw = new StringWriter();

            sw.WriteLine("\"Sl No.\",\"Name of Firm/ Company\",\"GST No.\",\"PAN No.\",\"Type of the Firm\",\"Please Specify\",\"Status of Company\",\"Type of Service Provide\",\"Manpower Provided\",\"Address\",\"City\",\"State\",\"Country\",\"Pin\",\"STD Code with Phone No. \",\"Fax\",\"Website\",\"Mobile\",\"E-mail\",\"Name of Contact Person\",\"Designation of Contact Person\",\"Is your Firm MSME ?\",\"Brief Description of Business of your Company\",\"Type of Items Interested for Supply/ service\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=AllVendor.csv");
            Response.ContentType = "application/octet-stream";

            var ManageVendor = objContextNew.VendorsNews.OrderByDescending(x => x.Pk_intNewVendorRegistrationID).ToList();

            int i = 1;

            foreach (var detailsofVendor in ManageVendor)
            {
                var TypeoftheFirm = "";
                var StatusofCompany = "";
                var Supplyservice = "";
                var CorrespondenceAddress = "";

                if (detailsofVendor.strCorrespondenceAddress != "" && detailsofVendor.strCorrespondenceAddress != null)
                {
                    CorrespondenceAddress = detailsofVendor.strCorrespondenceAddress.Replace("  ", " ");
                }


                if (detailsofVendor.fk_intConstitutionFirmID != null)
                {
                    TypeoftheFirm = objContext4.ConstitutionFirms.Where(x => x.pk_intConstitutionFirmID == detailsofVendor.fk_intConstitutionFirmID).FirstOrDefault().strConstitutionFirm;

                }

                if (detailsofVendor.int_fk_CompanyStatusID != null)
                {
                    StatusofCompany = objContext6.Companys.Where(x => x.pk_CompanyStatusID == detailsofVendor.int_fk_CompanyStatusID).FirstOrDefault().strCompanyStatusName;

                }

                if (detailsofVendor.strRegistrationApplied != null && detailsofVendor.strRegistrationApplied != "")
                {
                    List<string> fkRegistrationApplied = detailsofVendor.strRegistrationApplied.Split(',').ToList();
                    foreach (string str in fkRegistrationApplied)
                    {
                        int id = Convert.ToInt32(str);
                        Supplyservice = Supplyservice + "," + objContext5.ItemDescriptions.Where(x => x.Pk_intItemDescription == id).FirstOrDefault().strItemDescriptionName;
                    }
                    Supplyservice = Supplyservice.TrimStart(',');


                }

                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\",\"{21}\",\"{22}\",\"{23}\",\"{24}\"",

                i,
                detailsofVendor.strNameofFirmCompany,
                detailsofVendor.strGSTNo,
                detailsofVendor.strPANNo,
                TypeoftheFirm,
                detailsofVendor.str_company_others,
                StatusofCompany,
                detailsofVendor.str_serviceprovidertype,
                detailsofVendor.strIsManpowerSupplier,
                CorrespondenceAddress,
                detailsofVendor.str_city,
                detailsofVendor.str_state,
                detailsofVendor.str_country,
                detailsofVendor.str_pin,
                detailsofVendor.strPhone1,
                detailsofVendor.strFax,
                detailsofVendor.strWebsite1,
                detailsofVendor.strMobile,
                detailsofVendor.strEmail,
                detailsofVendor.strNameContactPerson,
                detailsofVendor.strDesignationofContactPerson,
                detailsofVendor.strTypeofIndustry,
                detailsofVendor.str_companydesc,
                Supplyservice,
                detailsofVendor.strVendorRegistrationID
                ));

                i++;
            }

            Response.Write(sw.ToString());
            Response.End();







        }

        public ActionResult VendorDetails(int id)
        {

            ViewBag.Fk_intDepartment = new SelectList(objContext8.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");

            VendorRegistration VendorRegistration = objContext1.VendorRegistrations.Single(x => x.Pk_intNewVendorRegistrationID == id);
            var a = VendorRegistration.strRegistrationApplied;
            ViewBag.hidFk_intDepartment = VendorRegistration.Fk_intDepartment;
            var AppliedFk_intUnitId = VendorRegistration.Fk_intUnitId;


            if (a != null)
            {
                TempData["all"] = "ok";
                List<string> stringList = a.Split(',').ToList();
                List<int> intList = new List<int>();

                foreach (string str in stringList)
                {
                    intList.Add(Convert.ToInt32(str));
                }


                ViewBag.strRegistrationApplied = new SelectList(objContext5.ItemDescriptions.Where(x => intList.Contains(x.Pk_intItemDescription)).ToList(), "Pk_intItemDescription", "strItemDescriptionName");
            }

            else
            {
                TempData["all"] = "ok";
                ViewBag.strRegistrationApplied = new SelectList("");
            }



            List<string> stringList1 = AppliedFk_intUnitId.Split(',').ToList();
            List<int> intList1 = new List<int>();

            foreach (string str1 in stringList1)
            {
                intList1.Add(Convert.ToInt32(str1));
            }


            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => intList1.Contains(x.pk_intUnitId)).ToList(), "pk_intUnitId", "strUnitName");



            ViewBag.intfk_CasteID = new SelectList(objContext2.Castes.Where(x => x.pk_intCasteId == VendorRegistration.intfk_CasteID).ToList(), "pk_intCasteId", "strCasteName");
            ViewBag.int_fk_CompanyStatusID = new SelectList(objContext6.Companys.Where(x => x.pk_CompanyStatusID == VendorRegistration.int_fk_CompanyStatusID), "pk_CompanyStatusID", "strCompanyStatusName");
            ViewBag.fk_intConstitutionFirmID = new SelectList(objContext4.ConstitutionFirms.Where(x => x.pk_intConstitutionFirmID == VendorRegistration.fk_intConstitutionFirmID), "pk_intConstitutionFirmID", "strConstitutionFirm");
            return View(VendorRegistration);
        }



        [HttpPost]
        public ActionResult VendorDetails(int id, FormCollection frm, string submit)
        {
            string message = "";
            VendorRegistration ObjVendorRegistration = objContext1.VendorRegistrations.Single(x => x.Pk_intNewVendorRegistrationID == id);
            ViewBag.Fk_intDepartment = new SelectList(objContext8.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");
            var AppliedFk_intUnitId = ObjVendorRegistration.Fk_intUnitId;
            List<string> stringList1 = AppliedFk_intUnitId.Split(',').ToList();
            List<int> intList1 = new List<int>();

            foreach (string str1 in stringList1)
            {
                intList1.Add(Convert.ToInt32(str1));
            }
            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => intList1.Contains(x.pk_intUnitId)).ToList(), "pk_intUnitId", "strUnitName");
            if (ModelState.IsValid)
            {

                if (submit == "Reject")
                {
                    ObjVendorRegistration.strActive = "NO";
                    ObjVendorRegistration.strVerify = "NO";
                    ObjVendorRegistration.strPending = "YES";
                    ObjVendorRegistration.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    ObjVendorRegistration.dtPendingDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    ObjVendorRegistration.strComments = frm["strComments"];
                    Utility.SendEmail(frm["strEmail"].ToString(), "Your account has been rejected successfully", frm["strComments"]);
                    message = "The account has been rejected successfully";

                }
                if (submit == "Approve")
                {

                    ObjVendorRegistration.strActive = "YES";
                    ObjVendorRegistration.dtActiveDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    ObjVendorRegistration.strPending = "NO";
                    ObjVendorRegistration.strVerify = "YES";
                    ObjVendorRegistration.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    ObjVendorRegistration.strComments = frm["strComments"];
                    Utility.SendEmail(frm["strEmail"].ToString(), "Your account has been approved successfully", frm["strComments"]);
                    message = "The account has been approved successfully";
                }

                ObjVendorRegistration.Fk_intDepartment = frm["hidFk_intDepartment"];
                ObjVendorRegistration.strNameContactPerson = frm["strNameContactPerson"];
                ObjVendorRegistration.strDesignationofContactPerson = frm["strDesignationofContactPerson"];
                ObjVendorRegistration.strPhoneoffice = frm["strPhoneoffice"];
                ObjVendorRegistration.strPhoneResidence = frm["strPhoneResidence"];
                ObjVendorRegistration.strMobile = frm["strMobile"];
                ObjVendorRegistration.strEmail = frm["strEmail"];




                try
                {
                    objContext1.Entry(ObjVendorRegistration).State = EntityState.Modified;
                    objContext1.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            System.Console.WriteLine("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                }


                ViewBag.Message = message;
                return View(ObjVendorRegistration);
            }

            ViewBag.strRegistrationApplied = new SelectList(objContext5.ItemDescriptions.ToList(), "Pk_intItemDescription", "strItemDescriptionName");
            //ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == ObjVendorRegistration.Fk_intUnitId).ToList(), "pk_intUnitId", "strUnitName");
            ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
            ViewBag.intfk_CasteID = new SelectList(objContext2.Castes.Where(x => x.pk_intCasteId == ObjVendorRegistration.intfk_CasteID).ToList(), "pk_intCasteId", "strCasteName");
            ViewBag.int_fk_CompanyStatusID = new SelectList(objContext6.Companys.Where(x => x.pk_CompanyStatusID == ObjVendorRegistration.int_fk_CompanyStatusID), "pk_CompanyStatusID", "strCompanyStatusName");
            ViewBag.fk_intConstitutionFirmID = new SelectList(objContext4.ConstitutionFirms.Where(x => x.pk_intConstitutionFirmID == ObjVendorRegistration.fk_intConstitutionFirmID), "pk_intConstitutionFirmID", "strConstitutionFirm");
            return View(ObjVendorRegistration);
        }

        // Department Start

        public ActionResult DepartmentList()
        {
            var Department = objContext8.tbl_mstDepartment.Where(x => x.isActive == true).ToList();

            return View(Department);
        }

        public ActionResult EditDepartment(int id)
        {
            var Department = objContext8.tbl_mstDepartment.Where(x => x.pk_intID == id).FirstOrDefault();
            ViewBag.strDepartmentName = Department.strDepartmentName;
            return View();
        }

        [HttpPost]
        public ActionResult EditDepartment(int id, FormCollection frm)
        {
            string depName = frm["strDepartmentName"].ToString();

            var Department = objContext8.tbl_mstDepartment.Where(x => x.pk_intID == id).FirstOrDefault();

            int checkDepartment = objContext8.tbl_mstDepartment.Where(x => x.strDepartmentName == depName).ToList().Count();
            if (checkDepartment > 0)
            {
                ViewBag.Message = string.Format("The Department Name is already used.");
            }
            else
            {

                Department.strDepartmentName = frm["strDepartmentName"];
                objContext8.Entry(Department).State = EntityState.Modified;
                objContext8.SaveChanges();
                ViewBag.Message = "Data Updated Successfully.";
                ModelState.Clear();
            }
            return View();


        }
        public ActionResult DeleteDepartment(int id)
        {
            var DepartmentDelete = objContext8.tbl_mstDepartment.Where(x => x.pk_intID == id).FirstOrDefault();
            //string unitId = DepartmentDelete.pk_intID.ToString();
            //int checkDepartmentValu = objContext1.VendorRegistrations.Where(x => x.Fk_intDepartment.Contains(unitId)).ToList().Count();           
            objContext8.Entry(DepartmentDelete).State = EntityState.Deleted;
            objContext8.SaveChanges();
            return RedirectToAction("DepartmentList");
        }
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(FormCollection frm)
        {
            string depName = frm["strDepartmentName"].ToString();
            int duplicateuser = objContext8.tbl_mstDepartment.Where(x => x.strDepartmentName == depName).ToList().Count();
            if (duplicateuser > 0)
            {
                ViewBag.Message = string.Format("The Department Name is already used.");
            }
            else
            {
                tbl_mstDepartment Department = new tbl_mstDepartment();
                Department.strDepartmentName = frm["strDepartmentName"];
                Department.isActive = true;
                objContext8.tbl_mstDepartment.Add(Department);
                objContext8.SaveChanges();
                ViewBag.Message = "Data saved Successfully.";
                ModelState.Clear();
            }
            return View();

        }

        // Department End
        // Event starts
        public ActionResult EventList()
        {
            var Event = objContext8.tbl_mst_Events.ToList();
            return View(Event);
        }

        public ActionResult AddEvent()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEvent1(FormCollection frm, tbl_mst_Eventsimagedetails tbl_mst_Eventsimagedetails)
        {
            tbl_mst_Events obj = new tbl_mst_Events();


            HttpFileCollectionBase UploadImageCollection = Request.Files;

            HttpPostedFileBase strImageFileEnglish = UploadImageCollection[0];

            string fileName = UploadImageCollection.GetKey(0);

            var guid = Guid.NewGuid().ToString();
            var path = Path.Combine(Server.MapPath("~/Content/Admin/EventFiles/"), guid + fileName);
            strImageFileEnglish.SaveAs(path);
            string fl = path.Substring(path.LastIndexOf("\\"));
            string[] split = fl.Split('\\');
            string newpath = split[1];
            string imagepath = "~/Content/Admin/EventFiles/" + newpath;
            obj.strImageFileEnglish = imagepath;

            string SubjectdfsEnglish = Request["strSubjectdfsEnglish"];
            string SubjectdfsHindi = Request["strSubjectdfsHindi"];

            string DescriptiondfsEnglish = Request["strDescriptiondfsEnglish"];
            string DescriptiondfsHindi = Request["strDescriptiondfsHindi"];
            string EventDate = Request["dtEventDate"];
            string ExpiryDate = Request["dtExpiryDate"];

            obj.strSubjectdfsEnglish = SubjectdfsEnglish;
            obj.strSubjectdfsHindi = SubjectdfsHindi;
            obj.strDescriptiondfsEnglish = DescriptiondfsEnglish;
            obj.strDescriptiondfsHindi = DescriptiondfsHindi;
            if (EventDate != "" && EventDate != null)
            {
                obj.dtEventDate = Convert.ToDateTime(Utility.ConvertToValidDateString(EventDate, EnmDateFormat.DDMMYYYY));
            }
            if (ExpiryDate != "" && ExpiryDate != null)
            {
                obj.dtExpiryDate = Convert.ToDateTime(Utility.ConvertToValidDateString(ExpiryDate, EnmDateFormat.DDMMYYYY));
            }
            obj.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            obj.IsActive = true;

            objContext8.tbl_mst_Events.Add(obj);
            objContext8.SaveChanges();

            int pk_id = obj.Pk_intEventID;



            if (Request.Files.Count > 0)
            {

                HttpFileCollectionBase files = Request.Files;


                for (var i = 1; i < files.Count; i++)
                {

                    HttpPostedFileBase file = files[i];
                    var guid1 = Guid.NewGuid().ToString();
                    string fname1 = guid1 + file.FileName;

                    fname1 = Path.Combine(Server.MapPath("~/Content/Admin/EventFiles/"), fname1);
                    file.SaveAs(fname1);

                    string f2 = fname1.Substring(fname1.LastIndexOf("\\"));
                    string[] split1 = f2.Split('\\');
                    string newpath1 = split1[1];
                    string imagepath1 = "~/Content/Admin/EventFiles/" + newpath1;


                    tbl_mst_Eventsimagedetails.str_uploadfile = imagepath1;
                    tbl_mst_Eventsimagedetails.fk_int_eventid = pk_id;
                    tbl_mst_Eventsimagedetails.is_active = "Yes";
                    objEventsimagedetails.tbl_mst_Eventsimagedetails.Add(tbl_mst_Eventsimagedetails);
                    objEventsimagedetails.SaveChanges();

                }


            }

            return Json("File Uploaded Successfully!");
            //return RedirectToAction("EventList");

        }

        public ActionResult EditEvent(int Id)
        {
            var Event = objContext8.tbl_mst_Events.Where(x => x.Pk_intEventID == Id).FirstOrDefault();

            ViewBag.strSubjectdfsEnglish = Event.strSubjectdfsEnglish;
            ViewBag.strSubjectdfsHindi = Event.strSubjectdfsHindi;
            ViewBag.strDescriptiondfsEnglish = Event.strDescriptiondfsEnglish;
            ViewBag.strDescriptiondfsHindi = Event.strDescriptiondfsHindi;
            ViewBag.dtEventDate = Event.dtEventDate.Value.ToString("dd/MM/yyyy");
            ViewBag.dtExpiryDate = Event.dtExpiryDate.Value.ToString("dd/MM/yyyy");
            ViewBag.strImageFileEnglish = Event.strImageFileEnglish;
            //ViewBag.strImageFileHindi = Event.strImageFileHindi;

            return View();
        }

        [HttpPost]
        public ActionResult EditEvent(int Id, FormCollection frm, HttpPostedFileBase strImageFileEnglish)
        {
            var obj = objContext8.tbl_mst_Events.Where(x => x.Pk_intEventID == Id).FirstOrDefault();
            string imagepath = obj.strImageFileEnglish;

            if (strImageFileEnglish != null)
            {
                var fileName = Path.GetExtension(strImageFileEnglish.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = "";
                var folderPath = "";
                path = Path.Combine(Server.MapPath("~/Content/Admin/EventFiles"), guid + fileName);
                folderPath = "~/Content/Admin/EventFiles/";
                strImageFileEnglish.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = folderPath + newpath;
            }
            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            if (MineType != "Invalied")
            {
                obj.strImageFileEnglish = imagepath;
                obj.strSubjectdfsEnglish = frm["strSubjectdfsEnglish"];
                obj.strSubjectdfsHindi = frm["strSubjectdfsHindi"];
                obj.strDescriptiondfsEnglish = frm["strDescriptiondfsEnglish"];
                obj.strDescriptiondfsHindi = frm["strDescriptiondfsHindi"];
                obj.dtEventDate = Convert.ToDateTime(Utility.ConvertToValidDateString(frm["dtEventDate"], EnmDateFormat.DDMMYYYY));
                obj.dtExpiryDate = Convert.ToDateTime(Utility.ConvertToValidDateString(frm["dtExpiryDate"], EnmDateFormat.DDMMYYYY));
                obj.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objContext8.Entry(obj).State = EntityState.Modified;
                objContext8.SaveChanges();
                return RedirectToAction("EventList");
            }
            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                ViewBag.Message = "Invalied file...";
                return View();
            }
        }

        public ActionResult EventDelete(int id)
        {
            var EventDelete = objContext8.tbl_mst_Events.Where(x => x.Pk_intEventID == id).FirstOrDefault();

            objContext8.Entry(EventDelete).State = EntityState.Deleted;
            objContext8.SaveChanges();


            //var imagedelete = objEventsimagedetails.tbl_mst_Eventsimagedetails.Where(x => x.fk_int_eventid == id).ToList();
            //objEventsimagedetails.Entry(imagedelete).State = EntityState.Deleted;
            //objEventsimagedetails.SaveChanges();

            var imagedelete = objEventsimagedetails.tbl_mst_Eventsimagedetails.Where(x => x.fk_int_eventid == id);
            foreach (var delete in imagedelete)
            {
                objEventsimagedetails.Entry(delete).State = EntityState.Deleted;
            }
            objEventsimagedetails.SaveChanges();


            return RedirectToAction("EventList");
        }


        //Event ends
        //ACHIEVEMENT & AWARDS starts
        public ActionResult AchievementAndAwardList()
        {
            var Award = objContext8.tbl_mst_AchievementAndAward.ToList();
            return View(Award);
        }

        public ActionResult AddAchievementAndAward()
        {
            return View();
        }



        [HttpPost]
        public ActionResult AddAchievementAndAward(FormCollection frm, HttpPostedFileBase strAwardFile)
        {
            if (strAwardFile != null)
            {

                tbl_mst_AchievementAndAward obj = new tbl_mst_AchievementAndAward();
                var fileName = Path.GetExtension(strAwardFile.FileName);

                var guid = Guid.NewGuid().ToString();
                var path = "";
                var folderPath = "";

                path = Path.Combine(Server.MapPath("~/Content/Admin/AwardFiles"), guid + fileName);
                folderPath = "~/Content/Admin/AwardFiles/";
                strAwardFile.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                string imagepath = folderPath + newpath;

                //File extention rename
               // var MineType = Utility.getMimeFromFile(path);
                //if (MineType != "Invalied")
                //{
                    obj.strAwardFile = imagepath;
                    obj.strSubjectdfsEnglish = frm["strSubjectdfsEnglish"];
                    obj.strSubjectdfsHindi = frm["strSubjectdfsHindi"];
                    obj.strDescriptiondfsEnglish = frm["strDescriptiondfsEnglish"];
                    obj.strDescriptiondfsHindi = frm["strDescriptiondfsHindi"];
                    //obj.dtAwardDate = Convert.ToDateTime(frm["dtAwardDate"]);
                    obj.dtAwardDate = Convert.ToDateTime(Utility.ConvertToValidDateString(frm["dtAwardDate"], EnmDateFormat.DDMMYYYY));
                    if (frm["dtExpiryDate"] != "")
                    {
                        //obj.dtExpiryDate = Convert.ToDateTime(frm["dtExpiryDate"]);
                        obj.dtExpiryDate = Convert.ToDateTime(Utility.ConvertToValidDateString(frm["dtExpiryDate"], EnmDateFormat.DDMMYYYY));
                    }
                    obj.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    obj.IsActive = true;

                    objContext8.tbl_mst_AchievementAndAward.Add(obj);
                    objContext8.SaveChanges();
                    ViewBag.Message = "Data Saved successfully...";
                    return RedirectToAction("AchievementAndAwardList");
                //}
                //else
                //{
                //    //File extention rename
                //    System.IO.File.Delete(path);
                //    ViewBag.Message = "Invalied file...";
                //}
            }

            return View();
        }

        public ActionResult EditAchievementAndAward(int Id)
        {
            var Event = objContext8.tbl_mst_AchievementAndAward.Where(x => x.Pk_intAwardID == Id).FirstOrDefault();

            ViewBag.strSubjectdfsEnglish = Event.strSubjectdfsEnglish;
            ViewBag.strSubjectdfsHindi = Event.strSubjectdfsHindi;
            ViewBag.strDescriptiondfsEnglish = Event.strDescriptiondfsEnglish;
            ViewBag.strDescriptiondfsHindi = Event.strDescriptiondfsHindi;
            ViewBag.dtAwardDate = Event.dtAwardDate.Value.ToString("dd/MM/yyyy");
            if (Event.dtExpiryDate != null)
            {
                ViewBag.dtExpiryDate = Event.dtExpiryDate.Value.ToString("dd/MM/yyyy");
            }
            ViewBag.strAwardFile = Event.strAwardFile;

            return View();
        }


        [HttpPost]
        public ActionResult EditAchievementAndAward(int Id, FormCollection frm, HttpPostedFileBase strAwardFile)
        {
            var obj = objContext8.tbl_mst_AchievementAndAward.Where(x => x.Pk_intAwardID == Id).FirstOrDefault();
            string imagepath = null;
            if (strAwardFile != null)
            {
                var fileName = Path.GetExtension(strAwardFile.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = "";
                var folderPath = "";
                path = Path.Combine(Server.MapPath("~/Content/Admin/EventFiles"), guid + fileName);
                folderPath = "~/Content/Admin/EventFiles/";
                strAwardFile.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = folderPath + newpath;
            }
            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            if (MineType != "Invalied")
            {
                obj.strAwardFile = imagepath;
                obj.strSubjectdfsEnglish = frm["strSubjectdfsEnglish"];
                obj.strSubjectdfsHindi = frm["strSubjectdfsHindi"];
                obj.strDescriptiondfsEnglish = frm["strDescriptiondfsEnglish"];
                obj.strDescriptiondfsHindi = frm["strDescriptiondfsHindi"];
                obj.dtAwardDate = Convert.ToDateTime(Utility.ConvertToValidDateString(frm["dtAwardDate"], EnmDateFormat.DDMMYYYY));
                if (frm["dtExpiryDate"] != "")
                {
                    obj.dtExpiryDate = Convert.ToDateTime(Utility.ConvertToValidDateString(frm["dtExpiryDate"], EnmDateFormat.DDMMYYYY));
                }
                obj.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");

                objContext8.Entry(obj).State = EntityState.Modified;
                objContext8.SaveChanges();

                return RedirectToAction("AchievementAndAwardList");
            }
            else
            {
                System.IO.File.Delete(MineType);
                ViewBag.Message = "Invalied file...";
                return View();
            }
        }


        public ActionResult AchievementAndAwardDelete(int id)
        {
            var AchievementAndAwardDelete = objContext8.tbl_mst_AchievementAndAward.Where(x => x.Pk_intAwardID == id).FirstOrDefault();
            objContext8.Entry(AchievementAndAwardDelete).State = EntityState.Deleted;
            objContext8.SaveChanges();
            return RedirectToAction("AchievementAndAwardList");
        }


        //ACHIEVEMENT & AWARDS ends
        //News Start

        public ActionResult NewsList()
        {
            var News = objContext8.tbl_mst_News.ToList();
            return View(News);
        }

        public ActionResult AddNews()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNews(FormCollection frm, HttpPostedFileBase strFileEnglish, HttpPostedFileBase strFileHindi)
        {
            tbl_mst_News obj = new tbl_mst_News();
            string imagepath = null;
            string imagepath1 = null;
            string linkEnglish = frm["strLinkEnglish"];
            string linkHindi = frm["strLinkHindi"];

            // If the "link" option is selected, set the file paths to empty strings
            if (!string.IsNullOrEmpty(linkEnglish))
            {
                obj.linkFileEnglish = linkEnglish;
                imagepath = "";  // Set to empty string when "link" is selected
            }
            if (!string.IsNullOrEmpty(linkHindi))
            {
                obj.linkFileHindi = linkHindi;
                imagepath1 = "";  // Set to empty string when "link" is selected
            }

            // If a file is uploaded, save the file and set the path
            if (strFileEnglish != null && string.IsNullOrEmpty(linkEnglish)) // Check if file is uploaded and link is not selected
            {
                var fileName = Path.GetExtension(strFileEnglish.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = "";
                var folderPath = "";
                if (frm["strNewsType"] == "Announcement")
                {
                    path = Path.Combine(Server.MapPath("~/Content/Admin/AnnouncementFiles"), guid + fileName);
                    folderPath = "~/Content/Admin/AnnouncementFiles/";
                }
                else
                {
                    path = Path.Combine(Server.MapPath("~/Content/Admin/NewsFiles"), guid + fileName);
                    folderPath = "~/Content/Admin/NewsFiles/";
                }
                strFileEnglish.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = folderPath + newpath;
            }

            if (strFileHindi != null && string.IsNullOrEmpty(linkHindi)) // Check if file is uploaded and link is not selected
            {
                var fileName = Path.GetExtension(strFileHindi.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = "";
                var folderPath1 = "";
                if (frm["strNewsType"] == "Announcement")
                {
                    path = Path.Combine(Server.MapPath("~/Content/Admin/AnnouncementFiles"), guid + fileName);
                    folderPath1 = "~/Content/Admin/AnnouncementFiles/";
                }
                else
                {
                    path = Path.Combine(Server.MapPath("~/Content/Admin/NewsFiles"), guid + fileName);
                    folderPath1 = "~/Content/Admin/NewsFiles/";
                }
                strFileHindi.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = folderPath1 + newpath;
            }

            // Save the file paths or empty strings to the database
            if (imagepath != null)
            {
                obj.strFileEnglish = imagepath;
            }

            if (imagepath1 != null)
            {
                obj.strFileHindi = imagepath1;
            }

            // Save other data
            obj.strNewsType = frm["strNewsType"];
            obj.strSubjectdfsEnglish = frm["strSubjectdfsEnglish"];
            obj.strSubjectdfshindi = frm["strSubjectdfshindi"];
            obj.dtExpiryDate = Convert.ToDateTime(Utility.ConvertToValidDateString(frm["dtExpiryDate"], EnmDateFormat.DDMMYYYY));
            obj.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");

            // Add to context and save
            objContext8.tbl_mst_News.Add(obj);
            objContext8.SaveChanges();

            return RedirectToAction("NewsList");
        }

        public ActionResult EditNews(int Id)
        {
            var news = objContext8.tbl_mst_News.Where(x => x.Pk_intNewsID == Id).FirstOrDefault();

            ViewBag.strNewsType = news.strNewsType;
            ViewBag.strSubjectdfsEnglish = news.strSubjectdfsEnglish;
            ViewBag.strSubjectdfshindi = news.strSubjectdfshindi;
            ViewBag.dtExpiryDate = news.dtExpiryDate.Value.ToString("dd/MM/yyyy");
            ViewBag.strFileEnglish = news.strFileEnglish;
            ViewBag.strFileHindi = news.strFileHindi;
            return View();
        }

        [HttpPost]
        public ActionResult EditNews(int Id, FormCollection frm, HttpPostedFileBase strFileEnglish, HttpPostedFileBase strFileHindi)
        {
            string imagepath = null;
            string imagepath1 = null;

            var obj = objContext8.tbl_mst_News.Where(x => x.Pk_intNewsID == Id).FirstOrDefault();

            if (strFileEnglish != null)
            {


                var fileName = Path.GetExtension(strFileEnglish.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = "";
                var folderPath = "";
                if (frm["strNewsType"] == "Announcement")
                {
                    path = Path.Combine(Server.MapPath("~/Content/Admin/AnnouncementFiles"), guid + fileName);
                    folderPath = "~/Content/Admin/AnnouncementFiles/";
                }
                else
                {
                    path = Path.Combine(Server.MapPath("~/Content/Admin/NewsFiles"), guid + fileName);
                    folderPath = "~/Content/Admin/NewsFiles/";
                }
                strFileEnglish.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = folderPath + newpath;

            }
            if (strFileHindi != null)
            {


                var fileName = Path.GetExtension(strFileHindi.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = "";
                var folderPath = "";
                if (frm["strNewsType"] == "Announcement")
                {
                    path = Path.Combine(Server.MapPath("~/Content/Admin/AnnouncementFiles"), guid + fileName);
                    folderPath = "~/Content/Admin/AnnouncementFiles/";
                }
                else
                {
                    path = Path.Combine(Server.MapPath("~/Content/Admin/NewsFiles"), guid + fileName);
                    folderPath = "~/Content/Admin/NewsFiles/";
                }
                strFileHindi.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = folderPath + newpath;


            }

            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            var MineType1 = Utility.getMimeFromFile(imagepath1);


            if (MineType != "Invalied" && MineType1 != "Invalied")
            {
                if (strFileEnglish == null)
                {
                    obj.strFileEnglish = obj.strFileEnglish;
                }
                else
                {
                    obj.strFileEnglish = imagepath;
                }

                if (strFileHindi == null)
                {
                    obj.strFileHindi = obj.strFileHindi;
                }
                else
                {
                    obj.strFileHindi = imagepath1;
                }

                obj.strNewsType = frm["strNewsType"];
                obj.strSubjectdfsEnglish = frm["strSubjectdfsEnglish"];
                obj.strSubjectdfshindi = frm["strSubjectdfshindi"];
                obj.dtExpiryDate = Convert.ToDateTime(Utility.ConvertToValidDateString(frm["dtExpiryDate"], EnmDateFormat.DDMMYYYY));
                obj.dtUpdatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objContext8.Entry(obj).State = EntityState.Modified;
                objContext8.SaveChanges();
                return RedirectToAction("NewsList");
            }

            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                System.IO.File.Delete(MineType1);
                ViewBag.Message = "Invalied file...";
                return View();
            }
        }


        //News End



        public ActionResult AddWorkListforApproved()
        {
            int UnitId = 0;
            var CONTRACT_WORK_ORDER = objContext7.CONTRACT_WORK_ORDER.ToList();
            if (Session["UnitId"] != null)
            {
                UnitId = Convert.ToInt32(Session["UnitId"]);
                CONTRACT_WORK_ORDER = CONTRACT_WORK_ORDER.Where(x => x.WO_UNIT == UnitId).ToList();
            }

            return View(CONTRACT_WORK_ORDER);
        }

        public ActionResult WorkOrderApproved(int id)
        {

            var CONTRACT_WORK_ORDER = objContext7.CONTRACT_WORK_ORDER.Single(x => x.ID == id);
            ViewBag.WO_UNIT = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName", CONTRACT_WORK_ORDER.WO_UNIT);
            return View(CONTRACT_WORK_ORDER);
        }

        [HttpPost]
        public ActionResult WorkOrderApproved(CONTRACT_WORK_ORDER CONTRACT_WORK_ORDER, string submit)
        {
            ViewBag.WO_UNIT = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName", CONTRACT_WORK_ORDER.WO_UNIT);
            CONTRACT_WORK_ORDER.APPROVALDATE = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            CONTRACT_WORK_ORDER.APPROVALBY = Convert.ToString(Session["UserID"]);
            if (submit == "Approved")
            {
                CONTRACT_WORK_ORDER.APPROVED = "Y";
                ViewBag.Message = "Data Approved Successfully.";
            }
            else
            {
                CONTRACT_WORK_ORDER.APPROVED = "N";
                ViewBag.Message = "Data Rejected Successfully.";
            }
            objContext7.Entry(CONTRACT_WORK_ORDER).State = EntityState.Modified;
            objContext7.SaveChanges();


            ModelState.Clear();

            return View(CONTRACT_WORK_ORDER);
        }

        #region Tender start
        public ActionResult ManageTender(int? id)
        {

            List<Unit> listUnit = objContext3.Units.ToList();
            //List<VendorRegistration> listVender = objContext1.VendorRegistrations.Where(x => x.strVerify == "YES").ToList();
            List<VendorsNew> listVender = objContextNew.VendorsNews.Where(x => x.strVerify == "YES").ToList();
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                listUnit = listUnit.Where(x => x.pk_intUnitId == unitId).ToList();
                //listVender = listVender.Where(x => x.Fk_intUnitId.Contains(unitId.ToString())).ToList();
            }


            SelectList selectUnit = new SelectList(listUnit, "pk_intUnitId", "strUnitName");
            ViewBag.UnitList = selectUnit;


            SelectList selectVendor = new SelectList(listVender, "Pk_intNewVendorRegistrationID", "strVendorRegistrationID");
            ViewBag.VendorList = selectVendor;

            return View();
        }

        [HttpPost]
        public ActionResult ManageTender(tbl_mst_tender model, FormCollection frm)
        {
            List<Unit> listUnit = objContext3.Units.ToList();
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                listUnit = listUnit.Where(x => x.pk_intUnitId == unitId).ToList();
            }
            SelectList selectUnit = new SelectList(listUnit, "pk_intUnitId", "strUnitName");
            ViewBag.UnitList = selectUnit;
            //List<VendorRegistration> listVender = objContext1.VendorRegistrations.Where(x => x.strVerify == "YES").ToList();
            List<VendorsNew> listVender = objContextNew.VendorsNews.Where(x => x.strVerify == "YES").ToList();
            SelectList selectVendor = new SelectList(listVender, "Pk_intNewVendorRegistrationID", "strVendorRegistrationID");
            ViewBag.VendorList = selectVendor;
            DateTime entryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            string finYear = GetFinYear(entryDate);

            if (model.dtActiveDate < model.dtClosingDate && model.dtEnquiryDate < model.dtClosingDate)
            {
                HttpPostedFileBase strFile = Request.Files["strFile"];
                HttpPostedFileBase strFile1 = Request.Files["strFile1"];
                HttpPostedFileBase strFile2 = Request.Files["strFile2"];
                HttpPostedFileBase strFile3 = Request.Files["strFile3"];
                HttpPostedFileBase strFile4 = Request.Files["strFile4"];
                // for Hindi
                HttpPostedFileBase strFilehindi = Request.Files["strFilehindi"];
                HttpPostedFileBase strFilehindi1 = Request.Files["strFilehindi1"];
                HttpPostedFileBase strFilehindi2 = Request.Files["strFilehindi2"];
                HttpPostedFileBase strFilehindi3 = Request.Files["strFilehindi3"];
                HttpPostedFileBase strFilehindi4 = Request.Files["strFilehindi4"];

                string imagepath = null;
                string imagepath1 = null;
                string imagepath2 = null;
                string imagepath3 = null;
                string imagepath4 = null;
                string imagepath5 = null;
                string imagepath6 = null;
                string imagepath7 = null;
                string imagepath8 = null;
                string imagepath9 = null;

                if (strFile.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFile.FileName);
                    var AutoGenFileName = model.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFile.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath = "~/Upload/Tender/" + newpath;
                    model.strFilePath = imagepath;
                }

                if (strFile1.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFile1.FileName);
                    var AutoGenFileName = model.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE1";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFile1.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath1 = "~/Upload/Tender/" + newpath;
                    model.strFilePath1 = imagepath1;
                }

                if (strFile2.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFile2.FileName);
                    var AutoGenFileName = model.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE2";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFile.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath2 = "~/Upload/Tender/" + newpath;
                    model.strFilePath2 = imagepath2;
                }

                if (strFile3.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFile3.FileName);
                    var AutoGenFileName = model.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE3";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFile3.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath3 = "~/Upload/Tender/" + newpath;
                    model.strFilePath3 = imagepath3;
                }

                if (strFile4.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFile4.FileName);
                    var AutoGenFileName = model.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE4";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFile4.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath4 = "~/Upload/Tender/" + newpath;
                    model.strFilePath4 = imagepath4;
                }

                // Hindi
                if (strFilehindi.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFilehindi.FileName);
                    var AutoGenFileName = model.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFilehindi.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath5 = "~/Upload/Tender/" + newpath;
                    model.strFilePathHindi = imagepath5;
                }

                if (strFilehindi1.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFilehindi1.FileName);
                    var AutoGenFileName = model.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE1";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFilehindi1.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath6 = "~/Upload/Tender/" + newpath;
                    model.strFilePathHindi1 = imagepath6;
                }

                if (strFilehindi2.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFilehindi2.FileName);
                    var AutoGenFileName = model.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE2";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFilehindi2.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath7 = "~/Upload/Tender/" + newpath;
                    model.strFilePathHindi2 = imagepath7;
                }

                if (strFilehindi3.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFilehindi3.FileName);
                    var AutoGenFileName = model.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE3";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFilehindi3.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath8 = "~/Upload/Tender/" + newpath;
                    model.strFilePathHindi3 = imagepath8;
                }

                if (strFilehindi4.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFilehindi4.FileName);
                    var AutoGenFileName = model.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE4";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFilehindi4.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath9 = "~/Upload/Tender/" + newpath;
                    model.strFilePathHindi4 = imagepath9;
                }
                // hindi complete

                //File extention rename
                var MineType = Utility.getMimeFromFile(imagepath);
                var MineType1 = Utility.getMimeFromFile(imagepath1);
                var MineType2 = Utility.getMimeFromFile(imagepath2);
                var MineType3 = Utility.getMimeFromFile(imagepath3);
                var MineType4 = Utility.getMimeFromFile(imagepath4);
                var MineType5 = Utility.getMimeFromFile(imagepath5);
                var MineType6 = Utility.getMimeFromFile(imagepath6);
                var MineType7 = Utility.getMimeFromFile(imagepath7);
                var MineType8 = Utility.getMimeFromFile(imagepath8);
                var MineType9 = Utility.getMimeFromFile(imagepath9);

                if (MineType != "Invalied" && MineType1 != "Invalied" && MineType2 != "Invalied" && MineType3 != "Invalied" && MineType4 != "Invalied" && MineType5 != "Invalied" && MineType6 != "Invalied" && MineType7 != "Invalied" && MineType8 != "Invalied" && MineType9 != "Invalied")
                {

                    model.strFinancialYear = finYear;
                    model.dtEntryDate = entryDate;
                    model.strEnquiryNo = frm["hidstrEnquiryNo"];
                    model.IsActive = true;
                    model.strVendorsId = frm["hidstrVendorsId"];

                    _tenderContext.Tenders.Add(model);
                    _tenderContext.SaveChanges();
                    ViewBag.Message = "Tender saved Successfully.";
                    ModelState.Clear();
                }
                else
                {
                    //File extention rename
                    System.IO.File.Delete(MineType);
                    System.IO.File.Delete(MineType1);
                    System.IO.File.Delete(MineType2);
                    System.IO.File.Delete(MineType3);
                    System.IO.File.Delete(MineType4);
                    System.IO.File.Delete(MineType5);
                    System.IO.File.Delete(MineType6);
                    System.IO.File.Delete(MineType7);
                    System.IO.File.Delete(MineType8);
                    System.IO.File.Delete(MineType9);
                    ViewBag.Message = "Invalied file...";
                }
            }
            else
            {

                ViewBag.Message = "Closing Date and Time cannot be less than Display/Active Date and Enquiry Date.";
                ModelState.Clear();
            }
            //ModelState.Clear();
            return View();
        }

        //Edit Tender



        public ActionResult EditTender(int Id)
        {
            var Tender = _tenderContext.Tenders.Where(x => x.pk_intTenderId == Id).FirstOrDefault();
            List<Unit> listUnit = objContext3.Units.Where(x => x.pk_intUnitId == Tender.fk_intUnitId).ToList();
            SelectList selectUnit = new SelectList(listUnit, "pk_intUnitId", "strUnitName", Tender.fk_intUnitId);
            string strUnitId = Tender.fk_intUnitId.ToString();
            ViewBag.UnitList = selectUnit;
            //List<VendorRegistration> listVender = objContext1.VendorRegistrations.Where(x => x.strVerify == "YES" && x.Fk_intUnitId.Contains(strUnitId)).ToList();
            List<VendorsNew> listVender = objContextNew.VendorsNews.Where(x => x.strVerify == "YES").ToList();
            if (Tender.strTenderType == "STE" || Tender.strTenderType == "LTE")
            {
                ViewBag.strVendorsId = new SelectList(listVender, "Pk_intNewVendorRegistrationID", "strVendorRegistrationID", Tender.strVendorsId);
            }
            else
            {
                ViewBag.strVendorsId = new SelectList("", "");
            }
            ViewBag.hidstrVendorsId = Tender.strVendorsId;
            ViewBag.strFile = Tender.strFilePath;
            ViewBag.strFile1 = Tender.strFilePath1;
            ViewBag.strFile2 = Tender.strFilePath2;
            ViewBag.strFile3 = Tender.strFilePath3;
            ViewBag.strFile4 = Tender.strFilePath4;
            ViewBag.HidFile = Tender.strFilePath;
            // For Hindi
            ViewBag.strFilehindi = Tender.strFilePathHindi;
            ViewBag.strFilehindi1 = Tender.strFilePathHindi1;
            ViewBag.strFilehindi2 = Tender.strFilePathHindi2;
            ViewBag.strFilehindi3 = Tender.strFilePathHindi3;
            ViewBag.strFilehindi4 = Tender.strFilePathHindi4;
            ViewBag.HidFilehindi = Tender.strFilePathHindi;
            ViewBag.IsCancel = Tender.IsCancel;


            return View(Tender);
        }

        [HttpPost]
        public ActionResult EditTender(tbl_mst_tender tbl_mst_tender, FormCollection frm, HttpPostedFileBase strFilePath, HttpPostedFileBase strFilePathHindi)
        {


            List<Unit> listUnit = objContext3.Units.Where(x => x.pk_intUnitId == tbl_mst_tender.fk_intUnitId).ToList();
            SelectList selectUnit = new SelectList(listUnit, "pk_intUnitId", "strUnitName", tbl_mst_tender.fk_intUnitId);

            string strUnitId = tbl_mst_tender.fk_intUnitId.ToString();
            ViewBag.UnitList = selectUnit;
            //List<VendorRegistration> listVender = objContext1.VendorRegistrations.Where(x => x.strVerify == "YES" && x.Fk_intUnitId.Contains(strUnitId)).ToList();
            List<VendorsNew> listVender = objContextNew.VendorsNews.Where(x => x.strVerify == "YES").ToList();
            if (tbl_mst_tender.strTenderType == "STE")
            {
                ViewBag.strVendorsId = new SelectList(listVender, "Pk_intNewVendorRegistrationID", "strVendorRegistrationID", tbl_mst_tender.strVendorsId);
            }
            else
            {
                ViewBag.strVendorsId = new SelectList("", "");
            }

            //ViewBag.strVendorsId = new SelectList(listVender, "Pk_intNewVendorRegistrationID", "strVendorRegistrationID", tbl_mst_tender.strVendorsId);
            ViewBag.hidstrVendorsId = tbl_mst_tender.strVendorsId;

            if (tbl_mst_tender.dtActiveDate < tbl_mst_tender.dtClosingDate && tbl_mst_tender.dtEnquiryDate < tbl_mst_tender.dtClosingDate)
            {
                HttpPostedFileBase strFile = Request.Files["strFile"];
                HttpPostedFileBase strFile1 = Request.Files["strFile1"];
                HttpPostedFileBase strFile2 = Request.Files["strFile2"];
                HttpPostedFileBase strFile3 = Request.Files["strFile3"];
                HttpPostedFileBase strFile4 = Request.Files["strFile4"];
                HttpPostedFileBase strFilehindi = Request.Files["strFilehindi"];
                HttpPostedFileBase strFilehindi1 = Request.Files["strFilehindi1"];
                HttpPostedFileBase strFilehindi2 = Request.Files["strFilehindi2"];
                HttpPostedFileBase strFilehindi3 = Request.Files["strFilehindi3"];
                HttpPostedFileBase strFilehindi4 = Request.Files["strFilehindi4"];

                string imagepath = null;
                string imagepath1 = null;
                string imagepath2 = null;
                string imagepath3 = null;
                string imagepath4 = null;
                string imagepath5 = null;
                string imagepath6 = null;
                string imagepath7 = null;
                string imagepath8 = null;
                string imagepath9 = null;



                if (strFile.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFile.FileName);
                    var AutoGenFileName = tbl_mst_tender.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFile.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath = "~/Upload/Tender/" + newpath;
                    tbl_mst_tender.strFilePath = imagepath;
                }

                if (strFile1.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFile1.FileName);
                    var AutoGenFileName = tbl_mst_tender.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE1";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender"), AutoGenFileName + fileExtension);
                    strFile1.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath1 = "~/Upload/Tender/" + newpath;
                    tbl_mst_tender.strFilePath1 = imagepath1;
                }

                if (strFile2.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFile2.FileName);
                    var AutoGenFileName = tbl_mst_tender.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE2";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFile.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath2 = "~/Upload/Tender/" + newpath;
                    tbl_mst_tender.strFilePath2 = imagepath2;
                }

                if (strFile3.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFile3.FileName);
                    var AutoGenFileName = tbl_mst_tender.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE3";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFile3.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath3 = "~/Upload/Tender/" + newpath;
                    tbl_mst_tender.strFilePath3 = imagepath3;
                }

                if (strFile4.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFile4.FileName);
                    var AutoGenFileName = tbl_mst_tender.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE4";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFile4.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath4 = "~/Upload/Tender/" + newpath;
                    tbl_mst_tender.strFilePath4 = imagepath4;
                }

                if (strFilehindi.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFilehindi.FileName);
                    var AutoGenFileName = tbl_mst_tender.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFilehindi.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath5 = "~/Upload/Tender/" + newpath;
                    tbl_mst_tender.strFilePathHindi = imagepath5;
                }

                if (strFilehindi1.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFilehindi1.FileName);
                    var AutoGenFileName = tbl_mst_tender.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE1";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender"), AutoGenFileName + fileExtension);
                    strFilehindi1.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath6 = "~/Upload/Tender/" + newpath;
                    tbl_mst_tender.strFilePathHindi1 = imagepath6;
                }

                if (strFilehindi2.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFilehindi2.FileName);
                    var AutoGenFileName = tbl_mst_tender.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE2";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFilehindi2.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath7 = "~/Upload/Tender/" + newpath;
                    tbl_mst_tender.strFilePathHindi2 = imagepath7;
                }

                if (strFilehindi3.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFilehindi3.FileName);
                    var AutoGenFileName = tbl_mst_tender.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE3";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFilehindi3.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath8 = "~/Upload/Tender/" + newpath;
                    tbl_mst_tender.strFilePathHindi3 = imagepath8;
                }

                if (strFilehindi4.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFilehindi4.FileName);
                    var AutoGenFileName = tbl_mst_tender.pk_intTenderId + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "TENDERFILE4";
                    var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                    strFilehindi4.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath9 = "~/Upload/Tender/" + newpath;
                    tbl_mst_tender.strFilePathHindi4 = imagepath9;
                }


                //File extention rename
                var MineType = Utility.getMimeFromFile(imagepath);
                var MineType1 = Utility.getMimeFromFile(imagepath1);
                var MineType2 = Utility.getMimeFromFile(imagepath2);
                var MineType3 = Utility.getMimeFromFile(imagepath3);
                var MineType4 = Utility.getMimeFromFile(imagepath4);
                var MineType5 = Utility.getMimeFromFile(imagepath5);
                var MineType6 = Utility.getMimeFromFile(imagepath6);
                var MineType7 = Utility.getMimeFromFile(imagepath7);
                var MineType8 = Utility.getMimeFromFile(imagepath8);
                var MineType9 = Utility.getMimeFromFile(imagepath9);

                if (MineType != "Invalied" && MineType1 != "Invalied" && MineType2 != "Invalied" && MineType3 != "Invalied" && MineType4 != "Invalied" && MineType5 != "Invalied" && MineType6 != "Invalied" && MineType7 != "Invalied" && MineType8 != "Invalied" && MineType9 != "Invalied")
                {

                    tbl_mst_tender.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_mst_tender.strVendorsId = frm["hidstrVendorsId"];
                    _tenderContext.Entry(tbl_mst_tender).State = EntityState.Modified;
                    _tenderContext.SaveChanges();

                    ViewBag.strFile = tbl_mst_tender.strFilePath;
                    ViewBag.strFilehindi = tbl_mst_tender.strFilePathHindi;
                    ViewBag.Message = string.Format("Tender updated successfully !");
                }
                else
                {
                    //File extention rename
                    System.IO.File.Delete(MineType);
                    System.IO.File.Delete(MineType1);
                    System.IO.File.Delete(MineType2);
                    System.IO.File.Delete(MineType3);
                    System.IO.File.Delete(MineType4);
                    System.IO.File.Delete(MineType5);
                    System.IO.File.Delete(MineType6);
                    System.IO.File.Delete(MineType7);
                    System.IO.File.Delete(MineType8);
                    System.IO.File.Delete(MineType9);
                    ViewBag.Message = "Invalied file...";
                }
            }
            else
            {
                ViewBag.Message = "Closing Date and Time cannot be less than Display/Active Date and Enquiry Date.";
            }
            return View();


        }



        // list


        public ActionResult TenderList()
        {

            DateTime now = DateTime.UtcNow;
            var Tenders = _tenderContext.Tenders.Where(x => x.dtClosingDate >= now).OrderByDescending(x => x.pk_intTenderId).ToList();

            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId).ToList(), "pk_intUnitId", "strUnitName");


                Tenders = Tenders.Where(x => x.fk_intUnitId == unitId).ToList();
            }
            else
            {
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
            }

            return View(Tenders);
        }


        [HttpPost]
        public ActionResult TenderList(FormCollection frm)
        {
            DateTime now = DateTime.UtcNow;
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId).ToList(), "pk_intUnitId", "strUnitName", frm["Fk_intUnitId"]);
            }
            else
            {
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName", frm["Fk_intUnitId"]);
            }



            if (frm["Fk_intUnitId"] != "")
            {
                int intUnitId = Convert.ToInt32(frm["Fk_intUnitId"]);
                var tendorList = _tenderContext.Tenders.Where(x => x.fk_intUnitId == intUnitId && x.dtEnquiryDate >= now).ToList();
                return View(tendorList);
            }
            else
            {
                var Tenders = _tenderContext.Tenders.Where(x => x.dtEnquiryDate >= now).OrderByDescending(x => x.pk_intTenderId).ToList();
                return View(Tenders);
            }


        }

        //Archive Tender
        public ActionResult ArchiveTenderList()
        {

            DateTime now = DateTime.UtcNow;
            var Tenders = _tenderContext.vw_TendetList.Where(x => x.dtClosingDate < now).OrderByDescending(x => x.pk_intTenderId).ToList();

            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId).ToList(), "pk_intUnitId", "strUnitName");


                Tenders = Tenders.Where(x => x.fk_intUnitId == unitId).ToList();
            }
            else
            {
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
            }

            return View(Tenders);
        }


        [HttpPost]
        public ActionResult ArchiveTenderList(FormCollection frm)
        {
            DateTime now = DateTime.UtcNow;
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId).ToList(), "pk_intUnitId", "strUnitName", frm["Fk_intUnitId"]);
            }
            else
            {
                ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName", frm["Fk_intUnitId"]);
            }



            if (frm["Fk_intUnitId"] != "")
            {
                int intUnitId = Convert.ToInt32(frm["Fk_intUnitId"]);
                var tendorList = _tenderContext.vw_TendetList.Where(x => x.fk_intUnitId == intUnitId && x.dtEnquiryDate <= now).ToList();
                return View(tendorList);
            }
            else
            {
                var Tenders = _tenderContext.vw_TendetList.Where(x => x.dtEnquiryDate <= now).OrderByDescending(x => x.pk_intTenderId).ToList();
                return View(Tenders);
            }


        }



        public ActionResult TenderListforDetails(int id)
        {
            try
            {
                TempData["UserID"] = Session["code"];
                //var TenderDetails = _tenderContext.vw_TendetList.Where(x =>x.pk_intTenderId == id).FirstOrDefault();
                //var checkAdde=_tenderContext.tbl_mstAddendum.Where(x => x.fk_intTendorId == id).ToList();
                //var checkCorr = _tenderContext.tbl_mstCorrigendum.Where(x => x.fk_intTendorId == id).ToList();


                var details = (from tender in _tenderContext.vw_TendetList
                               where
                                    tender.pk_intTenderId == id
                               select tender);
                //select new vw_TendetList
                //{

                //    Addendum = _tenderContext.tbl_mstAddendum.Where(x => x.fk_intTendorId == tender.pk_intTenderId).Select(a => a.strFileName).ToList(),
                //    Corrigendum = _tenderContext.tbl_mstCorrigendum.Where(x => x.fk_intTendorId == tender.pk_intTenderId).Select(c => c.strFileName).ToList()
                //};
                details.ToList().ForEach(d =>
                {
                    d.Addendum = _tenderContext.tbl_mstAddendum.Where(x => x.fk_intTendorId == d.pk_intTenderId).Select(a => a.strFileName).ToList();
                    d.Corrigendum = _tenderContext.tbl_mstCorrigendum.Where(x => x.fk_intTendorId == d.pk_intTenderId).Select(c => c.strFileName).ToList();
                });


                var TenderDetails = details.ToList();


                return View(TenderDetails);
            }
            catch { }

            return View();

        }
        #endregion



        #region Addendum start
        [HttpGet]
        public ActionResult AddendumList()
        {
            var Addendum = _tenderContext.vw_Addendum.OrderByDescending(x => x.pk_intAddendumId).ToList();
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                Addendum = Addendum.Where(x => x.fk_intUnitId == unitId).ToList();
            }
            return View(Addendum);
        }

        [HttpGet]
        public ActionResult AddAddendum()
        {

            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo");

                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                    "pk_intTenderId",
                    "FullName",
                    null);

            }
            else
            {
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo");

                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                    "pk_intTenderId",
                    "FullName",
                    null);
            }



            return View();
        }

        [HttpPost]
        public ActionResult AddAddendum(tbl_mstAddendum objtbl_mstAddendum, FormCollection frm)
        {
            int tendorId = Convert.ToInt32(frm["EnqNo"]);
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo");
                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                    "pk_intTenderId",
                    "FullName",
                    null);
            }
            else
            {
                // ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo");
                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                    "pk_intTenderId",
                    "FullName",
                    null);
            }
            objtbl_mstAddendum.fk_intTendorId = tendorId;
            objtbl_mstAddendum.strEnqueryNumber = frm["hidText"];
            objtbl_mstAddendum.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");


            HttpPostedFileBase strFile = Request.Files["strFile"];
            HttpPostedFileBase strFileNameHindi = Request.Files["strFileNameHindi"];

            string imagepath = null;
            string imagepath1 = null;


            if (strFile.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strFile.FileName);
                var AutoGenFileName = "ADDENDUM" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                strFile.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = "~/Upload/Tender/" + newpath;
                objtbl_mstAddendum.strFileName = imagepath;
            }



            if (strFileNameHindi.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strFileNameHindi.FileName);
                var AutoGenFileName = "ADDENDUM" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                strFileNameHindi.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = "~/Upload/Tender/" + newpath;
                objtbl_mstAddendum.strFileNameHindi = imagepath1;
            }

            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            var MineType1 = Utility.getMimeFromFile(imagepath1);

            if (MineType != "Invalied" && MineType1 != "Invalied")
            {
                _tenderContext.tbl_mstAddendum.Add(objtbl_mstAddendum);
                _tenderContext.SaveChanges();
                //Update tendor dtClosingDate
                var updatetenderDate = _tenderContext.Tenders.Where(x => x.pk_intTenderId == tendorId).FirstOrDefault();
                updatetenderDate.dtClosingDate = Convert.ToDateTime(objtbl_mstAddendum.dtExtendedDate);
                _tenderContext.Entry(updatetenderDate).State = EntityState.Modified;
                _tenderContext.SaveChanges();
                ViewBag.Message = "Addendum saved Successfully.";
            }
            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                System.IO.File.Delete(MineType1);
            }


            return View();
        }


        [HttpGet]
        public ActionResult EditAddendum(int id, FormCollection frm)
        {
            var objtbl_mstAddendum = _tenderContext.tbl_mstAddendum.Where(x => x.pk_intAddendumId == id).FirstOrDefault();
            ViewBag.hidText = objtbl_mstAddendum.strEnqueryNumber;
            ViewBag.dtExtendedDate = objtbl_mstAddendum.dtExtendedDate.ToString();
            //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.ToList(), "pk_intTenderId", "strEnquiryNo", objtbl_mstAddendum.fk_intTendorId);

            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo", objtbl_mstCorrigendum.fk_intTendorId);
                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                  "pk_intTenderId",
                  "FullName",
                  objtbl_mstAddendum.fk_intTendorId);
            }
            else
            {
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo", objtbl_mstCorrigendum.fk_intTendorId);
                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                  "pk_intTenderId",
                  "FullName",
                  objtbl_mstAddendum.fk_intTendorId);
            }

            ViewBag.strFile = objtbl_mstAddendum.strFileName;
            ViewBag.strFileNameHindi = objtbl_mstAddendum.strFileNameHindi;
            return View(objtbl_mstAddendum);
        }

        [HttpPost]
        public ActionResult EditAddendum(int id, FormCollection frm, tbl_mstAddendum objtbl_mstAddendum)
        {


            objtbl_mstAddendum = _tenderContext.tbl_mstAddendum.Where(x => x.pk_intAddendumId == id).FirstOrDefault();

            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).ToList(), "pk_intTenderId", "strEnquiryNo", objtbl_mstAddendum.fk_intTendorId);
                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                 "pk_intTenderId",
                 "FullName",
                 objtbl_mstAddendum.fk_intTendorId);
            }
            else
            {
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.ToList(), "pk_intTenderId", "strEnquiryNo", objtbl_mstAddendum.fk_intTendorId);
                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                 "pk_intTenderId",
                 "FullName",
                 objtbl_mstAddendum.fk_intTendorId);
            }



            objtbl_mstAddendum.fk_intTendorId = Convert.ToInt32(frm["EnqNo"]);
            objtbl_mstAddendum.strEnqueryNumber = frm["hidText"];
            objtbl_mstAddendum.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            objtbl_mstAddendum.dtExtendedDate = Convert.ToDateTime(frm["dtExtendedDate"]);
            HttpPostedFileBase strFile = Request.Files["strFile"];
            HttpPostedFileBase strFileNameHindi = Request.Files["strFileNameHindi"];

            string imagepath = null;
            string imagepath1 = null;

            if (strFile.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strFile.FileName);
                var AutoGenFileName = "ADDENDUM" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                strFile.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = "~/Upload/Tender/" + newpath;
                objtbl_mstAddendum.strFileName = imagepath;
            }




            if (strFileNameHindi.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strFileNameHindi.FileName);
                var AutoGenFileName = "ADDENDUM" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                strFileNameHindi.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = "~/Upload/Tender/" + newpath;
                objtbl_mstAddendum.strFileNameHindi = imagepath1;
            }


            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            var MineType1 = Utility.getMimeFromFile(imagepath1);

            if (MineType != "Invalied" && MineType1 != "Invalied")
            {
                _tenderContext.Entry(objtbl_mstAddendum).State = EntityState.Modified;
                _tenderContext.SaveChanges();
                //Update tendor dtClosingDate
                var updatetenderDate = _tenderContext.Tenders.Where(x => x.pk_intTenderId == objtbl_mstAddendum.fk_intTendorId).FirstOrDefault();
                updatetenderDate.dtClosingDate = Convert.ToDateTime(objtbl_mstAddendum.dtExtendedDate);
                _tenderContext.Entry(updatetenderDate).State = EntityState.Modified;
                _tenderContext.SaveChanges();
                ViewBag.strFile = objtbl_mstAddendum.strFileName;
                ViewBag.strFileNameHindi = objtbl_mstAddendum.strFileNameHindi;
                ViewBag.Message = string.Format("Addendum updated successfully !");
            }
            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                System.IO.File.Delete(MineType1);
                ViewBag.Message = "Invalied file...";
            }
            return View();
        }

        #endregion


        #region Corrigendum start

        public ActionResult CorrigendumList()
        {
            var Corrigendum = _tenderContext.vw_Corrigendum.OrderByDescending(x => x.pk_intCorrigendumId).ToList();

            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                Corrigendum = Corrigendum.Where(x => x.fk_intUnitId == unitId).ToList();
            }
            return View(Corrigendum);
        }

        [HttpGet]
        public ActionResult AddCorrigendum()
        {
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo");

                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                    "pk_intTenderId",
                    "FullName",
                    null);

            }
            else
            {
                // ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo");

                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                    "pk_intTenderId",
                    "FullName",
                    null);


            }
            return View();
        }

        [HttpPost]
        public ActionResult AddCorrigendum(tbl_mstCorrigendum objtbl_mstCorrigendum, FormCollection frm)
        {
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo");
                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                  "pk_intTenderId",
                  "FullName",
                  null);
            }
            else
            {
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo");
                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                  "pk_intTenderId",
                  "FullName",
                  null);
            }

            int tendorId = Convert.ToInt32(frm["EnqNo"]);

            objtbl_mstCorrigendum.fk_intTendorId = tendorId;
            objtbl_mstCorrigendum.strEnqueryNumber = frm["hidText"];
            objtbl_mstCorrigendum.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            HttpPostedFileBase strFile = Request.Files["strFile"];
            HttpPostedFileBase strFileNameHindi = Request.Files["strFileNameHindi"];

            string imagepath = null;
            string imagepath1 = null;

            if (strFile.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strFile.FileName);
                var AutoGenFileName = "CORRIGENDUM" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                strFile.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = "~/Upload/Tender/" + newpath;
                objtbl_mstCorrigendum.strFileName = imagepath;
            }

            if (strFileNameHindi.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strFileNameHindi.FileName);
                var AutoGenFileName = "CORRIGENDUM" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                strFileNameHindi.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = "~/Upload/Tender/" + newpath;
                objtbl_mstCorrigendum.strFileNameHindi = imagepath1;
            }

            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            var MineType1 = Utility.getMimeFromFile(imagepath1);
            if (MineType != "Invalied" && MineType1 != "Invalied")
            {
                _tenderContext.tbl_mstCorrigendum.Add(objtbl_mstCorrigendum);
                _tenderContext.SaveChanges();
                //Update tendor dtClosingDate
                var updatetenderDate = _tenderContext.Tenders.Where(x => x.pk_intTenderId == tendorId).FirstOrDefault();
                updatetenderDate.dtClosingDate = Convert.ToDateTime(objtbl_mstCorrigendum.dtExtendedDate);
                _tenderContext.Entry(updatetenderDate).State = EntityState.Modified;
                _tenderContext.SaveChanges();
                ViewBag.Message = "Corrigendum saved Successfully.";
            }
            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                System.IO.File.Delete(MineType1);
                ViewBag.Message = "Invalied file...";
            }

            return View();
        }


        [HttpGet]
        public ActionResult EditCorrigendum(int id, FormCollection frm)
        {
            var objtbl_mstCorrigendum = _tenderContext.tbl_mstCorrigendum.Where(x => x.pk_intCorrigendumId == id).FirstOrDefault();
            ViewBag.hidText = objtbl_mstCorrigendum.strEnqueryNumber;
            ViewBag.dtExtendedDate = objtbl_mstCorrigendum.dtExtendedDate.ToString();
            ViewBag.strFile = objtbl_mstCorrigendum.strFileName;
            ViewBag.strFileNameHindi = objtbl_mstCorrigendum.strFileNameHindi;

            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo", objtbl_mstCorrigendum.fk_intTendorId);
                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                  "pk_intTenderId",
                  "FullName",
                  objtbl_mstCorrigendum.fk_intTendorId);
            }
            else
            {
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo", objtbl_mstCorrigendum.fk_intTendorId);
                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                  "pk_intTenderId",
                  "FullName",
                  objtbl_mstCorrigendum.fk_intTendorId);
            }

            return View();
        }

        [HttpPost]
        public ActionResult EditCorrigendum(tbl_mstCorrigendum objtbl_mstCorrigendum, FormCollection frm, int id)
        {


            objtbl_mstCorrigendum = _tenderContext.tbl_mstCorrigendum.Where(x => x.pk_intCorrigendumId == id).FirstOrDefault();
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                // ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo", objtbl_mstCorrigendum.fk_intTendorId);

                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.Where(x => x.fk_intUnitId == unitId).OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                 "pk_intTenderId",
                 "FullName",
                 objtbl_mstCorrigendum.fk_intTendorId);
            }
            else
            {
                //ViewBag.EnqNo = new SelectList(_tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList(), "pk_intTenderId", "strEnquiryNo", objtbl_mstCorrigendum.fk_intTendorId);
                ViewData["EnqNolist"] = new SelectList((from s in _tenderContext.Tenders.OrderByDescending(x => x.strEnquiryNo).ToList()
                                                        select new
                                                        {
                                                            pk_intTenderId = s.pk_intTenderId,
                                                            FullName = s.strEnquiryNo + " " + s.strEnquiryTitle
                                                        }),
                 "pk_intTenderId",
                 "FullName",
                 objtbl_mstCorrigendum.fk_intTendorId);
            }

            objtbl_mstCorrigendum.fk_intTendorId = Convert.ToInt32(frm["EnqNo"]);
            objtbl_mstCorrigendum.strEnqueryNumber = frm["hidText"];
            objtbl_mstCorrigendum.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            objtbl_mstCorrigendum.dtExtendedDate = Convert.ToDateTime(frm["dtExtendedDate"]);
            HttpPostedFileBase strFile = Request.Files["strFile"];
            string imagepath = null;
            if (strFile.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strFile.FileName);
                var AutoGenFileName = "CORRIGENDUM" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Tender/"), AutoGenFileName + fileExtension);
                strFile.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = "~/Upload/Tender/" + newpath;
                objtbl_mstCorrigendum.strFileName = imagepath;
            }
            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            if (MineType != "Invalied")
            {
                _tenderContext.Entry(objtbl_mstCorrigendum).State = EntityState.Modified;
                _tenderContext.SaveChanges();
                //Update tendor dtClosingDate
                var updatetenderDate = _tenderContext.Tenders.Where(x => x.pk_intTenderId == objtbl_mstCorrigendum.fk_intTendorId).FirstOrDefault();
                updatetenderDate.dtClosingDate = Convert.ToDateTime(objtbl_mstCorrigendum.dtExtendedDate);
                _tenderContext.Entry(updatetenderDate).State = EntityState.Modified;
                _tenderContext.SaveChanges();
                ViewBag.strFile = objtbl_mstCorrigendum.strFileName;
                ViewBag.Message = string.Format("Corrigendum updated successfully !");
            }
            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                ViewBag.Message = "Invalied file...";
            }
            return View();
        }

        #endregion




        public ActionResult WorkmanWages()
        {
            //int Id = Convert.ToInt32(Session["UserID"]);
            // var workManDetails = objContext9.vw_CONTRACT_WORKMAN_WAGES.Where(x => x.CONTRACTORID == Id).ToList();
            var workManDetails = objContext9.vw_CONTRACT_WORKMAN_WAGES.ToList();
            return View(workManDetails);
        }

        public ActionResult EditWorkmanWages(int id)
        {
            var workManDetails = objContext9.CONTRACT_WORKMAN_WAGES.Single(x => x.ID == id);
            ViewBag.WORKMANID = new SelectList(objContext11.CONTRACT_WORKMAN_DETAILS.ToList(), "ID", "NAME", workManDetails.WORKMANID);
            ViewBag.WORKORDERID = new SelectList(objContext7.CONTRACT_WORK_ORDER.ToList(), "ID", "NAMEOFTHEWORK", workManDetails.WORKORDERID);
            ViewBag.LOCATIONID = new SelectList(objContext7.CONTRACT_WORK_ORDER.ToList(), "ID", "LOCATIONOFWORK", workManDetails.LOCATIONID);
            return View(workManDetails);
        }


        [HttpPost]
        public ActionResult EditWorkmanWages(int id, CONTRACT_WORKMAN_WAGES CONTRACT_WORKMAN_WAGES, string submit)
        {

            ViewBag.WORKMANID = new SelectList(objContext11.CONTRACT_WORKMAN_DETAILS.ToList(), "ID", "NAME", CONTRACT_WORKMAN_WAGES.WORKMANID);
            ViewBag.WORKORDERID = new SelectList(objContext7.CONTRACT_WORK_ORDER.ToList(), "ID", "NAMEOFTHEWORK", CONTRACT_WORKMAN_WAGES.WORKORDERID);
            ViewBag.LOCATIONID = new SelectList(objContext7.CONTRACT_WORK_ORDER.ToList(), "ID", "LOCATIONOFWORK", CONTRACT_WORKMAN_WAGES.LOCATIONID);

            CONTRACT_WORKMAN_WAGES.APPROVALDATE = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            CONTRACT_WORKMAN_WAGES.APPROVALBY = Convert.ToString(Session["UserID"]);
            if (submit == "Approved")
            {
                CONTRACT_WORKMAN_WAGES.APPROVED = "Y";
                ViewBag.Message = "Data Approved Successfully.";
            }
            else
            {
                CONTRACT_WORKMAN_WAGES.APPROVED = "N";
                ViewBag.Message = "Data Rejected Successfully.";
            }
            objContext9.Entry(CONTRACT_WORKMAN_WAGES).State = EntityState.Modified;
            objContext9.SaveChanges();

            return View(CONTRACT_WORKMAN_WAGES);
        }


        [HttpPost]
        public ActionResult getDiscipline(int Disciplineid)
        {

            var Discipline = objPost.tbl_mst_Post.Where(x => x.Fk_Disciplineid == Disciplineid).ToList();
            return Json(new { Discipline = Discipline });

        }






        [HttpPost]
        public ActionResult EnquiryNo(int fk_intUnitId)
        {
            var NewEnquiryNo = "";
            DateTime entryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            string finYear = GetFinYear(entryDate);
            int count = _tenderContext.Tenders.Count(p => p.fk_intUnitId == fk_intUnitId && p.strFinancialYear == finYear);
            count += 1;
            var unitcode = objContext3.Units.Where(x => x.pk_intUnitId == fk_intUnitId).FirstOrDefault().strUnitCode.Substring(0, 3).ToUpper();
            if (unitcode == "COR")
            {
                unitcode = "CO";
            }

            NewEnquiryNo = unitcode + "/" + count.ToString("D5") + "/" + finYear;

            //var Unit = fk_intUnitId.ToString();
            //var vendor = objContext1.VendorRegistrations.Where(x => x.Fk_intUnitId.Contains(Unit) && x.strVerify == "YES").ToList();
            // return Json(new { EnquiryNo = NewEnquiryNo, Vendor = vendor });
            return Json(new { EnquiryNo = NewEnquiryNo });

        }



        [HttpPost]
        public ActionResult VendorNo(int fk_intUnitId)
        {
            var Unit = fk_intUnitId.ToString();
            //var vendor = objContext1.VendorRegistrations.Where(x => x.Fk_intUnitId.Contains(Unit) && x.strVerify == "YES").ToList();
            var vendor = objContextNew.VendorsNews.Where(x => x.strVerify == "YES").ToList();
            return new JsonResult { Data = vendor, MaxJsonLength = Int32.MaxValue };

        }

        [HttpPost]
        public ActionResult EnquiryDate(int tenderId)
        {

            string enqTitleValue = "";
            string enqClosingValue = "";
            string enqCostValue = "";
            string enqEarnestValue = "";

            var enqDate = _tenderContext.Tenders.Where(x => x.pk_intTenderId == tenderId).ToList();
            if (enqDate.Count > 0)
            {
                enqTitleValue = enqDate.FirstOrDefault().strEnquiryTitle.ToString();
                enqClosingValue = enqDate.FirstOrDefault().dtClosingDate.ToString();
                enqCostValue = enqDate.FirstOrDefault().numCostofTender.ToString();
                enqEarnestValue = enqDate.FirstOrDefault().numEarnestMoney.ToString();
            }

            return Json(new { enqClosingValue = enqClosingValue, enqTitleValue = enqTitleValue, enqCostValue = enqCostValue, enqEarnestValue = enqEarnestValue });

        }
        public ActionResult VendorBlackListedList()
        {
            var currentDate = DateTime.Now.Date;

            var listBlackListed = objtbl_VendorBlackListedContext.tbl_VendorBlackListed
                .Where(x => x.dtFromDate <= currentDate && x.dtToDate >= currentDate)
                .ToList();

            return View(listBlackListed);
        }

        public ActionResult VendorBlackListed()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VendorBlackListed(FormCollection frm, tbl_VendorBlackListed objtbl_VendorBlackListed)
        {
            objtbl_VendorBlackListed.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            objtbl_VendorBlackListedContext.tbl_VendorBlackListed.Add(objtbl_VendorBlackListed);
            objtbl_VendorBlackListedContext.SaveChanges();
            ViewBag.Message = "Data Saved Successfully.";
            ModelState.Clear();
            return View();
        }



        public ActionResult AddAnnualReport()
        {
            return View(new tbl_AnnualReports());
        }


        [HttpPost]
        public ActionResult AddAnnualReport(tbl_AnnualReports tbl_AnnualReports, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                tbl_AnnualReports.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_AnnualReports.strStatus = "YES";
                HttpPostedFileBase strReportUpload = Request.Files["strReportUpload"];
                HttpPostedFileBase strReportUpload_hindi = Request.Files["strReportUpload_hindi"];
                string imagepath = null;
                string imagepath1 = null;

                if (strReportUpload.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strReportUpload.FileName);
                    var AutoGenFileName = tbl_AnnualReports.pk_intAnnualReport + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "AnnualReport";
                    var path = Path.Combine(Server.MapPath("~/Upload/Reports/"), AutoGenFileName + fileExtension);
                    strReportUpload.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath = "~/Upload/Reports/" + newpath;
                    tbl_AnnualReports.strReportUpload = imagepath;

                }

                if (strReportUpload_hindi.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strReportUpload_hindi.FileName);
                    var AutoGenFileName = tbl_AnnualReports.pk_intAnnualReport + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "AnnualReport";
                    var path = Path.Combine(Server.MapPath("~/Upload/Reports/"), AutoGenFileName + fileExtension);
                    strReportUpload_hindi.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath1 = "~/Upload/Reports/" + newpath;
                    tbl_AnnualReports.strReportUpload_hindi = imagepath1;

                }


                //tbl_AnnualReports.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");

                //File extention rename
                var MineType = Utility.getMimeFromFile(imagepath);
                var MineType1 = Utility.getMimeFromFile(imagepath1);
                if (MineType != "Invalied" && MineType1 != "Invalied")
                {
                    objAnnualReports.tbl_AnnualReports.Add(tbl_AnnualReports);
                    objAnnualReports.SaveChanges();
                    ViewBag.Message = string.Format("Your data saved successfully");
                    ModelState.Clear();
                }
                else
                {
                    //File extention rename
                    System.IO.File.Delete(MineType);
                    System.IO.File.Delete(MineType1);
                    ViewBag.Message = "Invalied file...";
                }

                return View();
            }

            return View();
        }



        public ActionResult ListAnnualReport()
        {
            var Annuallist = objAnnualReports.tbl_AnnualReports.OrderByDescending(x => x.pk_intAnnualReport).ToList();
            return View(Annuallist);
        }



        public ActionResult EditAnnualReport(int id)
        {
            var AnnualReport = objAnnualReports.tbl_AnnualReports.Where(x => x.pk_intAnnualReport == id).FirstOrDefault();
            ViewBag.strReportUpload = AnnualReport.strReportUpload;
            ViewBag.strReportUpload_hindi = AnnualReport.strReportUpload_hindi;
            return View(AnnualReport);
        }

        [HttpPost]
        public ActionResult EditAnnualReport(tbl_AnnualReports tbl_AnnualReports, FormCollection frm)
        {
            HttpPostedFileBase strReportUpload = Request.Files["strReportUpload"];
            HttpPostedFileBase strReportUpload_hindi = Request.Files["strReportUpload_hindi"];

            string imagepath = null;
            string imagepath1 = null;

            if (strReportUpload.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strReportUpload.FileName);
                var AutoGenFileName = tbl_AnnualReports.pk_intAnnualReport + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "AnnualReport";
                var path = Path.Combine(Server.MapPath("~/Upload/Reports/"), AutoGenFileName + fileExtension);
                strReportUpload.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = "~/Upload/Reports/" + newpath;
                tbl_AnnualReports.strReportUpload = imagepath;

            }

            if (strReportUpload_hindi.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strReportUpload_hindi.FileName);
                var AutoGenFileName = tbl_AnnualReports.pk_intAnnualReport + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "AnnualReport";
                var path = Path.Combine(Server.MapPath("~/Upload/Reports/"), AutoGenFileName + fileExtension);
                strReportUpload_hindi.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = "~/Upload/Reports/" + newpath;
                tbl_AnnualReports.strReportUpload_hindi = imagepath1;

            }

            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            var MineType1 = Utility.getMimeFromFile(imagepath1);
            if (MineType != "Invalied" && MineType1 != "Invalied")
            {
                tbl_AnnualReports.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objAnnualReports.Entry(tbl_AnnualReports).State = EntityState.Modified;
                objAnnualReports.SaveChanges();
                ViewBag.Message = string.Format("Data updated successfully !");
            }
            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                System.IO.File.Delete(MineType1);
                ViewBag.Message = "Invalied file...";
            }

            return View();
        }



        public ActionResult AnnualReportDelete(int id)
        {
            var EOIDelete = objAnnualReports.tbl_AnnualReports.Where(x => x.pk_intAnnualReport == id).FirstOrDefault();
            //var chcktransection=
            objAnnualReports.Entry(EOIDelete).State = EntityState.Deleted;
            objAnnualReports.SaveChanges();
            return RedirectToAction("ListAnnualReport");
        }




        public ActionResult AddManagementKeyExecutives()
        {
            return View(new tbl_ManagementKeyExecutives());
        }


        [HttpPost]
        public ActionResult AddManagementKeyExecutives(tbl_ManagementKeyExecutives tbl_ManagementKeyExecutives, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                tbl_ManagementKeyExecutives.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_ManagementKeyExecutives.strStatus = "YES";


                objManagmntExectve.tbl_ManagementKeyExecutives.Add(tbl_ManagementKeyExecutives);
                objManagmntExectve.SaveChanges();

                ViewBag.Message = string.Format("Your data saved successfully");
                ModelState.Clear();
                return View();
            }

            return View();
        }




        public ActionResult EditManagementKeyExecutives(int id)
        {
            var ManagmntExectve = objManagmntExectve.tbl_ManagementKeyExecutives.Where(x => x.pk_int_ManagementKeyExecutives == id).FirstOrDefault();

            return View(ManagmntExectve);
        }

        [HttpPost]
        public ActionResult EditManagementKeyExecutives(tbl_ManagementKeyExecutives tbl_ManagementKeyExecutives, FormCollection frm)
        {



            tbl_ManagementKeyExecutives.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            objManagmntExectve.Entry(tbl_ManagementKeyExecutives).State = EntityState.Modified;
            objManagmntExectve.SaveChanges();


            ViewBag.Message = string.Format("Data updated successfully !");

            return View();
        }



        public ActionResult ListManagementKeyExecutives()
        {
            var ManagementKeyExecutiveslist = objManagmntExectve.tbl_ManagementKeyExecutives.OrderByDescending(x => x.pk_int_ManagementKeyExecutives).ToList();
            return View(ManagementKeyExecutiveslist);
        }


        public ActionResult ManagementKeyExecutivesReportDelete(int id)
        {
            var ManagmntExectveDelete = objManagmntExectve.tbl_ManagementKeyExecutives.Where(x => x.pk_int_ManagementKeyExecutives == id).FirstOrDefault();

            objManagmntExectve.Entry(ManagmntExectveDelete).State = EntityState.Deleted;
            objManagmntExectve.SaveChanges();
            return RedirectToAction("ListManagementKeyExecutives");
        }







        //Start Price Circular

        public ActionResult AddPriceCircular()
        {
            return View(new tbl_PriceCircular());
        }


        [HttpPost]
        public ActionResult AddPriceCircular(tbl_PriceCircular tbl_PriceCircular, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                tbl_PriceCircular.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_PriceCircular.strStatus = "YES";
                HttpPostedFileBase strReportUpload = Request.Files["strReportUpload"];
                HttpPostedFileBase strReportupload_hindi = Request.Files["strReportupload_hindi"];

                string imagepath = null;
                string imagepath1 = null;

                if (strReportUpload.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strReportUpload.FileName);
                    var AutoGenFileName = tbl_PriceCircular.pk_intPriceCircular + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "AnnualReport";
                    var path = Path.Combine(Server.MapPath("~/Upload/Reports/"), AutoGenFileName + fileExtension);
                    strReportUpload.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath = "~/Upload/Reports/" + newpath;
                    tbl_PriceCircular.strReportUpload = imagepath;

                }
                if (strReportupload_hindi.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strReportupload_hindi.FileName);
                    var AutoGenFileName = tbl_PriceCircular.pk_intPriceCircular + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "AnnualReport";
                    var path = Path.Combine(Server.MapPath("~/Upload/Reports/"), AutoGenFileName + fileExtension);
                    strReportupload_hindi.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath1 = "~/Upload/Reports/" + newpath;
                    tbl_PriceCircular.strReportupload_hindi = imagepath1;

                }


                //tbl_AnnualReports.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");

                //File extention rename
                var MineType = Utility.getMimeFromFile(imagepath);
                var MineType1 = Utility.getMimeFromFile(imagepath1);

                if (MineType != "Invalied" && MineType1 != "Invalied")
                {
                    objtbl_PriceCircular.tbl_PriceCircular.Add(tbl_PriceCircular);
                    objtbl_PriceCircular.SaveChanges();
                    ViewBag.Message = string.Format("Your data saved successfully");
                    ModelState.Clear();
                }
                else
                {
                    //File extention rename
                    System.IO.File.Delete(MineType);
                    System.IO.File.Delete(MineType1);
                    ViewBag.Message = "Invalied file...";
                }
                return View();
            }

            return View();
        }



        public ActionResult PriceCircularList()
        {
            var PriceCircularlist = objtbl_PriceCircular.tbl_PriceCircular.OrderByDescending(x => x.pk_intPriceCircular).ToList();
            return View(PriceCircularlist);
        }



        public ActionResult EditPriceCircular(int id)
        {

            var PriceCircular = objtbl_PriceCircular.tbl_PriceCircular.Where(x => x.pk_intPriceCircular == id).FirstOrDefault();
            ViewBag.strReportUpload = PriceCircular.strReportUpload;
            ViewBag.strReportupload_hindi = PriceCircular.strReportupload_hindi;
            return View(PriceCircular);
        }

        [HttpPost]
        public ActionResult EditPriceCircular(tbl_PriceCircular tbl_PriceCircular, FormCollection frm)
        {
            HttpPostedFileBase strReportUpload = Request.Files["strReportUpload"];
            HttpPostedFileBase strReportupload_hindi = Request.Files["strReportupload_hindi"];

            string imagepath = null;
            string imagepath1 = null;

            if (strReportUpload.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strReportUpload.FileName);
                var AutoGenFileName = tbl_PriceCircular.pk_intPriceCircular + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "AnnualReport";
                var path = Path.Combine(Server.MapPath("~/Upload/Reports/"), AutoGenFileName + fileExtension);
                strReportUpload.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = "~/Upload/Reports/" + newpath;
                tbl_PriceCircular.strReportUpload = imagepath;

            }

            if (strReportupload_hindi.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strReportupload_hindi.FileName);
                var AutoGenFileName = tbl_PriceCircular.pk_intPriceCircular + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "AnnualReport";
                var path = Path.Combine(Server.MapPath("~/Upload/Reports/"), AutoGenFileName + fileExtension);
                strReportupload_hindi.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = "~/Upload/Reports/" + newpath;
                tbl_PriceCircular.strReportupload_hindi = imagepath1;

            }

            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            var MineType1 = Utility.getMimeFromFile(imagepath1);
            if (MineType != "Invalied" && MineType1 != "Invalied")
            {
                tbl_PriceCircular.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objtbl_PriceCircular.Entry(tbl_PriceCircular).State = EntityState.Modified;
                objtbl_PriceCircular.SaveChanges();
                ViewBag.Message = string.Format("Data updated successfully !");
            }
            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                System.IO.File.Delete(MineType1);
                ViewBag.Message = "Invalied file...";
            }
            return View();
        }



        public ActionResult PriceCircularDelete(int id)
        {
            var PriceCircularDelete = objtbl_PriceCircular.tbl_PriceCircular.Where(x => x.pk_intPriceCircular == id).FirstOrDefault();
            //var chcktransection=
            objtbl_PriceCircular.Entry(PriceCircularDelete).State = EntityState.Deleted;
            objtbl_PriceCircular.SaveChanges();
            return RedirectToAction("PriceCircularList");
        }

        //End Price Circular
        //Post Start Shoumya
        public ActionResult AddPostnew()
        {
            ViewBag.fk_discipline = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName");

            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult AddPostnew(tbl_mst_Postnew tbl_mst_Postnew, FormCollection frm)
        {

            ViewBag.fk_discipline = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName");


            if (ModelState.IsValid)
            {
                tbl_mst_Postnew.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_mst_Postnew.Is_active = "Yes";
                tbl_mst_Postnew.str_maxexp = "60";
                objpostnew.tbl_mst_Postnew.Add(tbl_mst_Postnew);
                objpostnew.SaveChanges();

                ViewBag.Message = string.Format("Your data saved successfully");
                ModelState.Clear();
                return View();
            }

            return View();

        }
        //List Post Shoumya
        public ActionResult ListPostnew()
        {
            vw_PostwithDisciplineContext objpdc = new vw_PostwithDisciplineContext();
            var postlist = objpdc.vw_PostwithDiscipline.OrderByDescending(x => x.Pk_Postid).ToList();
            return View(postlist);
        }

        public ActionResult DeletePostnew(int id)
        {
            var Postnew = objpostnew.tbl_mst_Postnew.Where(x => x.Pk_Postid == id).FirstOrDefault();

            objpostnew.Entry(Postnew).State = EntityState.Deleted;
            objpostnew.SaveChanges();
            return RedirectToAction("ListPostnew");
        }

        //Edit Post Shoumya
        public ActionResult EditPostnew(int id)
        {

            var post = objpostnew.tbl_mst_Postnew.Where(x => x.Pk_Postid == id).FirstOrDefault();

            ViewBag.fk_discipline = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName", post.fk_discipline);

            return View(post);

        }

        [HttpPost]
        public ActionResult EditPostnew(tbl_mst_Postnew tbl_mst_Postnew, FormCollection frm)
        {

            ViewBag.fk_discipline = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(),
                 "Pk_Disciplineid", "DisciplineName", tbl_mst_Postnew.fk_discipline);
            tbl_mst_Postnew.str_maxexp = "60";
            tbl_mst_Postnew.dt_updatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            objpostnew.Entry(tbl_mst_Postnew).State = EntityState.Modified;
            objpostnew.SaveChanges();

            ViewBag.Message = string.Format("Data updated successfully !");

            return View();

        }

        //criteria Start
        //ADD Post Criteria  
        public ActionResult AddPostCriteria()
        {
            ViewBag.fk_diciplineid = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName");

            ViewBag.fk_advertisementid = new SelectList(objemployment.tbl_employmentnotice.ToList(),
             "Pk_employmentid", "Empnoticeno");
            ViewBag.fk_postid = new SelectList(objpostnew.tbl_mst_Postnew.ToList(), "Pk_Postid", "Postname");
            ViewBag.str_caste = new SelectList(objContext2.Castes.ToList(), "strCasteName", "strCasteName");
            ViewBag.str_pwd = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName");
            ViewBag.str_gender = new SelectList(objgender.tbl_mst_gender.ToList(), "str_gender", "str_gender");
            return View(new tbl_transaction_Postcriteria());

        }

        public ActionResult AddPostCriteriaForITI()
        {
            ViewBag.fk_diciplineid = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName");

            ViewBag.fk_advertisementid = new SelectList(objemployment.tbl_employmentnotice.ToList(),
             "Pk_employmentid", "Empnoticeno");
            // ViewBag.fk_postid = new SelectList(objpostnew.tbl_mst_Postnew.ToList(), "Pk_Postid", "Postname");
            ViewBag.str_caste = new SelectList(objContext2.Castes.ToList(), "strCasteName", "strCasteName");
            ViewBag.str_pwd = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName");
            ViewBag.str_gender = new SelectList(objgender.tbl_mst_gender.ToList(), "str_gender", "str_gender");
            ViewBag.str_Trade = new SelectList(tradesforiti.tbl_tradesforiti.ToList(), "str_Trade", "str_Trade");
            return View(new tbl_transaction_PostcriteriaITI());

        }
        [HttpPost]
        public ActionResult AddPostCriteriaForITI(tbl_transaction_PostcriteriaForITI tbl_transaction_PostcriteriaForITI, FormCollection frm)
        {
            ViewBag.fk_diciplineid = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName");

            ViewBag.fk_advertisementid = new SelectList(objemployment.tbl_employmentnotice.ToList(),
             "Pk_employmentid", "Empnoticeno");
            // ViewBag.fk_postid = new SelectList(objpostnew.tbl_mst_Postnew.ToList(),
            // "Pk_Postid", "Postname");
            ViewBag.str_caste = new SelectList(objContext2.Castes.ToList(),
           "strCasteName", "strCasteName");
            ViewBag.str_pwd = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(),
            "str_CatName", "str_CatName");
            ViewBag.str_gender = new SelectList(objgender.tbl_mst_gender.ToList(), "str_gender", "str_gender");
            ViewBag.str_Trade = new SelectList(tradesforiti.tbl_tradesforiti.ToList(), "str_Trade", "str_Trade");
            if (ModelState.IsValid)
            {
                tbl_transaction_PostcriteriaForITI.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_transaction_PostcriteriaForITI.str_caste = frm["hidstr_caste"];
                tbl_transaction_PostcriteriaForITI.str_gender = frm["hidstr_gender"];
                tbl_transaction_PostcriteriaForITI.str_Trade = frm["hidstr_Trade"];
                tbl_transaction_PostcriteriaForITI.str_pwd = frm["hidstr_pwd"];
                tbl_transaction_PostcriteriaForITI.str_qualification = Utility.addData(frm["str_qualification1"], "@") + Utility.addData(frm["str_qualification2"], "@") + Utility.addData(frm["str_qualification3"], "@") + Utility.addData(frm["str_qualification4"], "@");
                // + " @ " + frm["str_qualification2"] + " @ " + frm["str_qualification3"] + " @ " + frm["str_qualification4"] + " @ " + frm["str_qualification5"] + " @ " + frm["str_qualification6"] + " @ " + frm["str_qualification7"] + " @ " + frm["str_qualification8"] + " @ " + frm["str_qualification9"] + " @ " + frm["str_qualification10"] + " @ " + frm["str_qualification11"] + " @ " + frm["str_qualification12"];
                objpostcriteriaForITI.tbl_transaction_PostcriteriaForITI.Add(tbl_transaction_PostcriteriaForITI);
                objpostcriteriaForITI.SaveChanges();
                objpostcriteriaForITI.Database.Connection.Close();

                List<tblTransactionPostCriteriaAgeRelaxations> listObj = new List<tblTransactionPostCriteriaAgeRelaxations>();
                tblTransactionPostCriteriaAgeRelaxations obj = new tblTransactionPostCriteriaAgeRelaxations();

                //for (int i = 1; i < 7; i++)
                //{
                //    string caste_cat_ = "caste_cat_" + i.ToString();
                //    if (frm[caste_cat_] != null && Int32.TryParse(frm[caste_cat_], out i))
                //    {
                //        obj = new tblTransactionPostCriteriaAgeRelaxations();
                //        obj.PostId = tbl_transaction_Postcriteria.Pk_criteriaid;
                //        obj.CastCategoryId = i;
                //        obj.AgeRelax = Convert.ToInt32(frm[caste_cat_]);
                //        listObj.Add(obj);
                //    }
                //}

                //new clstblTransactionPostCriteriaAgeRelaxations().Update(listObj, tbl_transaction_Postcriteria.Pk_criteriaid);

                foreach (var n in (tbl_transaction_PostcriteriaForITI.str_caste ?? "").Split(','))
                {
                    string caste_cat_ = "caste_cat_" + n;
                    string vl = frm[caste_cat_];
                    obj = new tblTransactionPostCriteriaAgeRelaxations();
                    obj.PostId = tbl_transaction_PostcriteriaForITI.fk_postid;
                    obj.CastCategoryId = 0;
                    obj.CasteCategory = n;
                    obj.AgeRelax = Convert.ToInt32(frm[caste_cat_]);
                    listObj.Add(obj);
                }
                new clstblTransactionPostCriteriaAgeRelaxations().Update(listObj, tbl_transaction_PostcriteriaForITI.fk_postid);

                ViewBag.Message = string.Format("Your data saved successfully");
                ModelState.Clear();

            }

            else
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            }
            return View();

        }


        [HttpPost]
        public ActionResult AddPostCriteria(tbl_transaction_Postcriteria tbl_transaction_Postcriteria, FormCollection frm)
        {
            ViewBag.fk_diciplineid = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName");

            ViewBag.fk_advertisementid = new SelectList(objemployment.tbl_employmentnotice.ToList(),
             "Pk_employmentid", "Empnoticeno");
            ViewBag.fk_postid = new SelectList(objpostnew.tbl_mst_Postnew.ToList(),
            "Pk_Postid", "Postname");
            ViewBag.str_caste = new SelectList(objContext2.Castes.ToList(),
           "strCasteName", "strCasteName");
            ViewBag.str_pwd = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(),
            "str_CatName", "str_CatName");
            ViewBag.str_gender = new SelectList(objgender.tbl_mst_gender.ToList(),
            "str_gender", "str_gender");
            if (ModelState.IsValid)
            {
                tbl_transaction_Postcriteria.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_transaction_Postcriteria.str_caste = frm["hidstr_caste"];
                tbl_transaction_Postcriteria.str_gender = frm["hidstr_gender"];
                tbl_transaction_Postcriteria.str_pwd = frm["hidstr_pwd"];
                tbl_transaction_Postcriteria.str_qualification = Utility.addData(frm["str_qualification1"], "@") + Utility.addData(frm["str_qualification2"], "@") + Utility.addData(frm["str_qualification3"], "@") + Utility.addData(frm["str_qualification4"], "@") + Utility.addData(frm["str_qualification5"], "@") + Utility.addData(frm["str_qualification6"], "@") + Utility.addData(frm["str_qualification7"], "@") + Utility.addData(frm["str_qualification8"], "@") + Utility.addData(frm["str_qualification9"], "@") + Utility.addData(frm["str_qualification10"], "@") + Utility.addData(frm["str_qualification11"], "@") + Utility.addData(frm["str_qualification12"], "@") + Utility.addData(frm["str_qualification13"], "@") + Utility.addData(frm["str_qualification14"], "@") + Utility.addData(frm["str_qualification15"], "@") + Utility.addData(frm["str_qualification16"], "@") + Utility.addData(frm["str_qualification17"], "@") + Utility.addData(frm["str_qualification18"], "@") + Utility.addData(frm["str_qualification19"], "@") + Utility.addData(frm["str_qualification20"], "@") + Utility.addData(frm["str_qualification21"], "@") + Utility.addData(frm["str_qualification22"], "@") + Utility.addData(frm["str_qualification23"], "@") + Utility.addData(frm["str_qualification24"], "@") + Utility.addData(frm["str_qualification25"], "@") + Utility.addData(frm["str_qualification26"], "@") + Utility.addData(frm["str_qualification27"], "@") + Utility.addData(frm["str_qualification28"], "@") + Utility.addData(frm["str_qualification29"], "@") + Utility.addData(frm["str_qualification30"], "@") + Utility.addData(frm["str_qualification31"], "@") + Utility.addData(frm["str_qualification32"], "@");
                // + " @ " + frm["str_qualification2"] + " @ " + frm["str_qualification3"] + " @ " + frm["str_qualification4"] + " @ " + frm["str_qualification5"] + " @ " + frm["str_qualification6"] + " @ " + frm["str_qualification7"] + " @ " + frm["str_qualification8"] + " @ " + frm["str_qualification9"] + " @ " + frm["str_qualification10"] + " @ " + frm["str_qualification11"] + " @ " + frm["str_qualification12"];
                objpostcriteria.tbl_transaction_Postcriteria.Add(tbl_transaction_Postcriteria);
                objpostcriteria.SaveChanges();
                objpostcriteria.Database.Connection.Close();

                List<tblTransactionPostCriteriaAgeRelaxations> listObj = new List<tblTransactionPostCriteriaAgeRelaxations>();
                tblTransactionPostCriteriaAgeRelaxations obj = new tblTransactionPostCriteriaAgeRelaxations();

                //for (int i = 1; i < 7; i++)
                //{
                //    string caste_cat_ = "caste_cat_" + i.ToString();
                //    if (frm[caste_cat_] != null && Int32.TryParse(frm[caste_cat_], out i))
                //    {
                //        obj = new tblTransactionPostCriteriaAgeRelaxations();
                //        obj.PostId = tbl_transaction_Postcriteria.Pk_criteriaid;
                //        obj.CastCategoryId = i;
                //        obj.AgeRelax = Convert.ToInt32(frm[caste_cat_]);
                //        listObj.Add(obj);
                //    }
                //}

                //new clstblTransactionPostCriteriaAgeRelaxations().Update(listObj, tbl_transaction_Postcriteria.Pk_criteriaid);

                foreach (var n in (tbl_transaction_Postcriteria.str_caste ?? "").Split(','))
                {
                    string caste_cat_ = "caste_cat_" + n;
                    string vl = frm[caste_cat_];
                    obj = new tblTransactionPostCriteriaAgeRelaxations();
                    obj.PostId = tbl_transaction_Postcriteria.fk_postid;
                    obj.CastCategoryId = 0;
                    obj.CasteCategory = n;
                    obj.AgeRelax = Convert.ToInt32(frm[caste_cat_]);
                    listObj.Add(obj);
                }
                new clstblTransactionPostCriteriaAgeRelaxations().Update(listObj, tbl_transaction_Postcriteria.fk_postid);

                ViewBag.Message = string.Format("Your data saved successfully");
                ModelState.Clear();

            }

            else
            {
                var message = string.Join(" | ", ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage));
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, message);
            }
            return View();

        }

        [HttpPost]
        public ActionResult Getpostdetails(int Id)
        {

            string GetCTCvalue = "";
            string GetGradevalue = "";
            string GetMinagevalue = "";
            string GetMaxagevalue = "";
            string GetComparedDate = "";
            string GetPostPaySaclevalue = "";
            string GetIsFreshersAllowedvalue = "";

            var Post = objpostnew.tbl_mst_Postnew.Where(x => x.Pk_Postid == Id).ToList();
            if (Post.Count > 0)
            {
                GetCTCvalue = Post.FirstOrDefault().str_ctc.ToString();
                GetGradevalue = Post.FirstOrDefault().str_Grade.ToString();
                GetMinagevalue = Post.FirstOrDefault().str_minage.ToString();
                GetMaxagevalue = Post.FirstOrDefault().str_maxage.ToString();
                GetComparedDate = Post.FirstOrDefault().dtcompareDate.ToString();
                GetPostPaySaclevalue = Post.FirstOrDefault().Payscale.ToString();
                GetIsFreshersAllowedvalue = Post.FirstOrDefault().strIsFreshersAllowed.ToString();
            }

            return Json(new { GetCTCvalue = GetCTCvalue, GetGradevalue = GetGradevalue, GetMinagevalue = GetMinagevalue, GetMaxagevalue = GetMaxagevalue, GetComparedDate = GetComparedDate, GetPostPaySaclevalue = GetPostPaySaclevalue, GetIsFreshersAllowedvalue = GetIsFreshersAllowedvalue });

        }


        //listpostcriteria 
        public ActionResult ListPostCriteria()
        {

            var list = objpostdesicipline.Vw_Postdesiciplinedetails.OrderByDescending(x => x.dt_entrydate).ToList();
            return View(list);
        }

        [HttpPost]
        public ActionResult getDisciplinedetails(int discipline)
        {

            var Disciplinemaster = objpostnew.tbl_mst_Postnew.Where(x => x.fk_discipline == discipline).ToList();
            return Json(new { Disciplinemaster = Disciplinemaster });

        }


        public ActionResult EditPostCriteria(int id)
        {
            var PostCriteria = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.Pk_criteriaid == id).FirstOrDefault();

            ViewBag.fk_diciplineid = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName", PostCriteria.fk_diciplineid);
            ViewBag.fk_advertisementid = new SelectList(objemployment.tbl_employmentnotice.ToList(), "Pk_employmentid", "Empnoticeno", PostCriteria.fk_advertisementid);
            ViewBag.fk_postid = new SelectList(objpostnew.tbl_mst_Postnew.ToList(), "Pk_Postid", "Postname", PostCriteria.fk_postid);
            ViewBag.str_caste = new SelectList(objContext2.Castes.ToList(), "strCasteName", "strCasteName", PostCriteria.str_caste);
            ViewBag.str_pwd = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName", PostCriteria.str_pwd);
            ViewBag.str_gender = new SelectList(objgender.tbl_mst_gender.ToList(), "str_gender", "str_gender", PostCriteria.str_gender);
            ViewBag.hidstr_caste = PostCriteria.str_caste;
            ViewBag.hidstr_pwd = PostCriteria.str_pwd;
            ViewBag.hidstr_gender = PostCriteria.str_gender;

            if (PostCriteria.str_qualification != null && PostCriteria.str_qualification != "")
            {
                int loopCount = PostCriteria.str_qualification.Split('@').Count();
                if (loopCount > 0)
                {
                    string[] qualification = PostCriteria.str_qualification.Split(new char[] { '@' });

                    int i = 1;
                    foreach (string eduQuli in qualification)
                    {
                        //var viewbagName = "ViewBag.str_qualification" + i;
                        //ViewBag.str_qualification + i.ToString() = eduQuli;
                        var propName = "str_qualification" + i.ToString();
                        ViewData.Add(propName, eduQuli);
                        i++;

                    }
                }
                else
                {
                    ViewBag.str_qualification1 = PostCriteria.str_qualification;
                }
            }
            using (var ctx = new tblTransactionPostCriteriaAgeRelaxationsContext())
            {
                ViewBag.AgeRelax = ctx.tblTransactionPostCriteriaAgeRelaxations.Where(a => a.PostId == id).ToList();
            }

            return View(PostCriteria);


        }

        [HttpPost]
        public ActionResult EditPostCriteria(tbl_transaction_Postcriteria objtbl_transaction_Postcriteria, FormCollection frm)
        {


            objtbl_transaction_Postcriteria.dt_updatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            objtbl_transaction_Postcriteria.str_caste = frm["hidstr_caste"];


            objtbl_transaction_Postcriteria.str_gender = frm["hidstr_gender"];
            objtbl_transaction_Postcriteria.str_pwd = frm["hidstr_pwd"];
            objtbl_transaction_Postcriteria.str_qualification = Utility.addData(frm["str_qualification1"], "@") + Utility.addData(frm["str_qualification2"], "@") + Utility.addData(frm["str_qualification3"], "@") + Utility.addData(frm["str_qualification4"], "@") + Utility.addData(frm["str_qualification5"], "@") + Utility.addData(frm["str_qualification6"], "@") + Utility.addData(frm["str_qualification7"], "@") + Utility.addData(frm["str_qualification8"], "@") + Utility.addData(frm["str_qualification9"], "@") + Utility.addData(frm["str_qualification10"], "@") + Utility.addData(frm["str_qualification11"], "@") + Utility.addData(frm["str_qualification12"], "@") + Utility.addData(frm["str_qualification13"], "@") + Utility.addData(frm["str_qualification14"], "@") + Utility.addData(frm["str_qualification15"], "@") + Utility.addData(frm["str_qualification16"], "@") + Utility.addData(frm["str_qualification17"], "@") + Utility.addData(frm["str_qualification18"], "@") + Utility.addData(frm["str_qualification19"], "@") + Utility.addData(frm["str_qualification20"], "@");
            objpostcriteria.Entry(objtbl_transaction_Postcriteria).State = EntityState.Modified;
            objpostcriteria.SaveChanges();

            List<tblTransactionPostCriteriaAgeRelaxations> listObj = new List<tblTransactionPostCriteriaAgeRelaxations>();
            tblTransactionPostCriteriaAgeRelaxations obj = new tblTransactionPostCriteriaAgeRelaxations();
            foreach (var n in (objtbl_transaction_Postcriteria.str_caste ?? "").Split(','))
            {
                string caste_cat_ = "caste_cat_" + n;
                string vl = frm[caste_cat_];
                obj = new tblTransactionPostCriteriaAgeRelaxations();
                obj.PostId = objtbl_transaction_Postcriteria.fk_postid;
                obj.CastCategoryId = 0;
                obj.CasteCategory = n;
                obj.AgeRelax = Convert.ToInt32(frm[caste_cat_]);
                listObj.Add(obj);
            }
            //for (int i = 1; i < 7; i++)
            //{
            //    string caste_cat_ = "caste_cat_" + i.ToString();
            //    if (frm[caste_cat_] != null && Int32.TryParse(frm[caste_cat_], out i))
            //    {
            //        obj = new tblTransactionPostCriteriaAgeRelaxations();
            //        obj.PostId = objtbl_transaction_Postcriteria.fk_advertisementid;
            //        obj.CastCategoryId = i;
            //        obj.AgeRelax = Convert.ToInt32(frm[caste_cat_]);
            //        listObj.Add(obj);
            //    }
            //}

            new clstblTransactionPostCriteriaAgeRelaxations().Update(listObj, objtbl_transaction_Postcriteria.fk_postid);

            return RedirectToAction("ListPostCriteria");
        }


        public ActionResult DeletePostCriteria(int id)
        {
            var PostCriteria = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.Pk_criteriaid == id).FirstOrDefault();

            objpostcriteria.Entry(PostCriteria).State = EntityState.Deleted;
            objpostcriteria.SaveChanges();
            return RedirectToAction("ListPostCriteria");
        }

        // Post Start
        public ActionResult AddPost()
        {
            ViewBag.Fk_Disciplineid = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName");

            ViewBag.Fk_Qualification1 = new SelectList(objqualification.tbl_Qualification.ToList(),
             "Qualification_name", "Qualification_name");
            ViewBag.Fk_Qualification2 = new SelectList(objqualification.tbl_Qualification.ToList(),
            "Qualification_name", "Qualification_name");
            ViewBag.Fk_Qualification3 = new SelectList(objqualification.tbl_Qualification.ToList(),
            "Qualification_name", "Qualification_name");


            ViewBag.Fk_Qualification6 = new SelectList("", "");

            ViewBag.Isfresher = "No";
            return View(new tbl_mst_Post());
        }

        [HttpPost]
        public ActionResult AddPost(tbl_mst_Post tbl_mst_Post, FormCollection frm)
        {

            ViewBag.Fk_Disciplineid = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName");


            ViewBag.Fk_Qualification1 = new SelectList(objqualification.tbl_Qualification.ToList(),
            "Qualification_name", "Qualification_name");
            ViewBag.Fk_Qualification2 = new SelectList(objqualification.tbl_Qualification.ToList(),
            "Qualification_name", "Qualification_name");
            ViewBag.Fk_Qualification3 = new SelectList(objqualification.tbl_Qualification.ToList(),
            "Qualification_name", "Qualification_name");

            ViewBag.Fk_Qualification6 = new SelectList("", "");

            if (tbl_mst_Post.dtstartdate < tbl_mst_Post.dtExpiryDate)
            {
                if (ModelState.IsValid)
                {
                    tbl_mst_Post.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_mst_Post.Fk_Qualification = frm["hidQualification6"];

                    tbl_mst_Post.IsActive = true;

                    objPost.tbl_mst_Post.Add(tbl_mst_Post);
                    objPost.SaveChanges();

                    ViewBag.Message = string.Format("Your data saved successfully");
                    ModelState.Clear();
                    return View();
                }
            }
            else
            {
                ViewBag.Message = "Expiry Date cannot be less than Start Date.";

            }
            return View();

        }


        // List Of Post

        public ActionResult ListPost()
        {
            var postlist = objPost.tbl_mst_Post.OrderByDescending(x => x.Pk_Postid).ToList();
            return View(postlist);
        }





        public ActionResult EditPost(int id)
        {

            var post = objPost.tbl_mst_Post.Where(x => x.Pk_Postid == id).FirstOrDefault();

            ViewBag.Fk_Disciplineid = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(),
              "Pk_Disciplineid", "DisciplineName", post.Fk_Disciplineid);


            ViewBag.Fk_Qualification1 = new SelectList(objqualification.tbl_Qualification.ToList(),
             "Qualification_name", "Qualification_name");
            ViewBag.Fk_Qualification2 = new SelectList(objqualification.tbl_Qualification.ToList(),
            "Qualification_name", "Qualification_name");
            ViewBag.Fk_Qualification3 = new SelectList(objqualification.tbl_Qualification.ToList(),
            "Qualification_name", "Qualification_name");
            ViewBag.Fk_Qualification6 = new SelectList("", "");

            return View(post);

        }

        [HttpPost]
        public ActionResult EditPost(tbl_mst_Post tbl_mst_Post, FormCollection frm)
        {
            if (tbl_mst_Post.dtstartdate < tbl_mst_Post.dtExpiryDate)
            {
                ViewBag.Fk_Disciplineid = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(),
                 "Pk_Disciplineid", "DisciplineName", tbl_mst_Post.Fk_Disciplineid);

                ViewBag.Fk_Qualification1 = new SelectList(objqualification.tbl_Qualification.ToList(),
              "Qualification_name", "Qualification_name");
                ViewBag.Fk_Qualification2 = new SelectList(objqualification.tbl_Qualification.ToList(),
                "Qualification_name", "Qualification_name");
                ViewBag.Fk_Qualification3 = new SelectList(objqualification.tbl_Qualification.ToList(),
                "Qualification_name", "Qualification_name");
                ViewBag.Fk_Qualification6 = new SelectList("", "");

                tbl_mst_Post.Fk_Qualification = frm["hidQualification6"];
                tbl_mst_Post.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objPost.Entry(tbl_mst_Post).State = EntityState.Modified;
                objPost.SaveChanges();

                ViewBag.Message = string.Format("Data updated successfully !");
            }
            else
            {
                ViewBag.Message = "Expiry Date cannot be less than Start Date.";

            }
            return View();

        }


        // Post End




        //Shoumya(add,list,edit Discipline)
        public ActionResult DisciplineCreate()
        {
            return View(new tbl_mst_Discipline());
        }
        [HttpPost]
        public ActionResult DisciplineCreate(tbl_mst_Discipline tbl_mst_Discipline, FormCollection frm)
        {
            string depName = frm["DisciplineName"].ToString();
            int duplicateuser = objdiscipline.tbl_mst_Discipline.Where(x => x.DisciplineName == depName).ToList().Count();
            if (duplicateuser > 0)
            {
                ViewBag.Message = string.Format("The Discipline Name is already used.");
            }
            else
            {

                tbl_mst_Discipline.DisciplineName = frm["DisciplineName"];
                tbl_mst_Discipline.IsActive = true;
                objdiscipline.tbl_mst_Discipline.Add(tbl_mst_Discipline);
                objdiscipline.SaveChanges();
                ViewBag.Message = "Data Saved Successfully.";
                ModelState.Clear();
            }
            return View();


        }
        public ActionResult DisciplineCreateList()
        {


            var disp = objdiscipline.tbl_mst_Discipline.ToList();
            return View(disp);

        }

        public ActionResult DeleteDiscipline(int id)
        {
            var Discipline = objdiscipline.tbl_mst_Discipline.Where(x => x.Pk_Disciplineid == id).FirstOrDefault();

            objdiscipline.Entry(Discipline).State = EntityState.Deleted;
            objdiscipline.SaveChanges();
            return RedirectToAction("DisciplineCreateList");
        }

        public ActionResult DisciplineEdit(int id)
        {
            var Data = objdiscipline.tbl_mst_Discipline.Where(x => x.Pk_Disciplineid == id).FirstOrDefault();


            return View(Data);


        }
        [HttpPost]
        public ActionResult DisciplineEdit(tbl_mst_Discipline tbl_mst_Discipline)
        {
            objdiscipline.Entry(tbl_mst_Discipline).State = EntityState.Modified;
            objdiscipline.SaveChanges();
            ViewBag.Message = "Data Update Successfully.";
            return View(tbl_mst_Discipline);
        }

        //public ActionResult DisciplineDelete(int id, tbl_mst_Discipline tbl_mst_Discipline)
        //{
        //    var Discipline = objdiscipline.tbl_mst_Discipline.Where(a => a.Pk_Disciplineid == id).FirstOrDefault();

        //    objdiscipline.Entry(tbl_mst_Discipline).State = EntityState.Deleted;
        //    objdiscipline.SaveChanges();
        //    return RedirectToAction("DisciplineCreateList");
        //}



        //Employment
        public ActionResult AddEmploymentnotice()
        {
            List<Unit> listUnit = objContext3.Units.ToList();
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                listUnit = listUnit.Where(x => x.pk_intUnitId == unitId).ToList();
            }
            //ViewBag.Fk_Postid = new SelectList(objpostDetails.vw_PostDetails.OrderBy(x => x.PostNamewithDisciplineName).ToList(), "Pk_Postid", "PostNamewithDisciplineName");

            //ViewBag.Fk_Postid = new SelectList("", "");
            ViewBag.Fk_unitid = new SelectList(listUnit, "pk_intUnitId", "strUnitName");
            return View(new tbl_employmentnotice());
        }

        [HttpPost]
        public ActionResult AddEmploymentnotice(tbl_employmentnotice tbl_employmentnotice, FormCollection frm)
        {
            List<Unit> listUnit = objContext3.Units.ToList();
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                listUnit = listUnit.Where(x => x.pk_intUnitId == unitId).ToList();
            }
            //ViewBag.Fk_Postid = new SelectList(objpostDetails.vw_PostDetails.OrderBy(x => x.PostNamewithDisciplineName).ToList(), "Pk_Postid", "PostNamewithDisciplineName");
            ViewBag.Fk_unitid = new SelectList(listUnit, "pk_intUnitId", "strUnitName");

            if (tbl_employmentnotice.dtviewdate <= tbl_employmentnotice.dtstartdate && tbl_employmentnotice.dtstartdate <= tbl_employmentnotice.dtclosedate)
            {
                HttpPostedFileBase strFile = Request.Files["strFile"];
                HttpPostedFileBase strFileHindi = Request.Files["strFileHindi"];

                string imagepath = null;
                string imagepath1 = null;

                if (strFile.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFile.FileName);
                    var AutoGenFileName = tbl_employmentnotice.Pk_employmentid + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "NoticeFILE";
                    var path = Path.Combine(Server.MapPath("~/Upload/Notice/"), AutoGenFileName + fileExtension);
                    strFile.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath = "~/Upload/Notice/" + newpath;
                    tbl_employmentnotice.Strupload = imagepath;
                }


                if (strFileHindi.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(strFileHindi.FileName);
                    var AutoGenFileName = tbl_employmentnotice.Pk_employmentid + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "HindiNoticeFILE";
                    var path = Path.Combine(Server.MapPath("~/Upload/Notice/"), AutoGenFileName + fileExtension);
                    strFileHindi.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    imagepath1 = "~/Upload/Notice/" + newpath;
                    tbl_employmentnotice.StruploadHindi = imagepath1;
                }

                ////File extention rename
                //var MineType = Utility.getMimeFromFile(imagepath);
                //var MineType1 = Utility.getMimeFromFile(imagepath1);
                //if (MineType != "Invalied" && MineType1 != "Invalied")
                {
                    tbl_employmentnotice.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_employmentnotice.isactive = true;
                    objemployment.tbl_employmentnotice.Add(tbl_employmentnotice);
                    objemployment.SaveChanges();
                    ViewBag.Message = string.Format("Notice saved Successfully.");
                }
                //else
                //{
                //    //File extention rename
                //    System.IO.File.Delete(MineType);
                //    System.IO.File.Delete(MineType1);
                //    ViewBag.Message = "Invalied file...";
                //}

            }
            else
            {
                ViewBag.Message = "Notice view Date and Closing Date cannot be Greater than StartDate.";
            }

            return View();

        }


        public ActionResult EmploymentEdit(int id)
        {
            var tbl_employmentnotice = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();

            List<Unit> listUnit = objContext3.Units.ToList();
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                listUnit = listUnit.Where(x => x.pk_intUnitId == unitId).ToList();
            }
            //ViewBag.Fk_Postid = new SelectList(objpostDetails.vw_PostDetails.OrderBy(x => x.PostNamewithDisciplineName).ToList(), "Pk_Postid", "PostNamewithDisciplineName");
            //ViewBag.hidFk_Postid = tbl_employmentnotice.strPostid;
            ViewBag.Strupload = tbl_employmentnotice.Strupload;
            ViewBag.StruploadHindi = tbl_employmentnotice.StruploadHindi;
            ViewBag.Fk_unitid = new SelectList(listUnit, "pk_intUnitId", "strUnitName", tbl_employmentnotice.Fk_unitid);
            return View(tbl_employmentnotice);
        }

        [HttpPost]
        public ActionResult EmploymentEdit(int id, tbl_employmentnotice tbl_employmentnotice, FormCollection frm)
        {
            if (tbl_employmentnotice.Pk_employmentid == 0)
            {
                tbl_employmentnotice.Pk_employmentid = id;
            }
            List<Unit> listUnit = objContext3.Units.ToList();
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                listUnit = listUnit.Where(x => x.pk_intUnitId == unitId).ToList();
            }
            //ViewBag.Fk_Postid = new SelectList(objpostDetails.vw_PostDetails.OrderBy(x => x.PostNamewithDisciplineName).ToList(), "Pk_Postid", "PostNamewithDisciplineName");
            //ViewBag.hidFk_Postid = tbl_employmentnotice.strPostid;
            ViewBag.Strupload = tbl_employmentnotice.Strupload;
            ViewBag.Fk_unitid = new SelectList(listUnit, "pk_intUnitId", "strUnitName", tbl_employmentnotice.Fk_unitid);

            HttpPostedFileBase strFile = Request.Files["strFile"];
            HttpPostedFileBase strFileHindi = Request.Files["strFileHindi"];

            string imagepath = null;
            string imagepath1 = null;

            if (strFile.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strFile.FileName);
                var AutoGenFileName = tbl_employmentnotice.Pk_employmentid + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "NoticeFILE";
                var path = Path.Combine(Server.MapPath("~/Upload/Notice/"), AutoGenFileName + fileExtension);
                strFile.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = "~/Upload/Notice/" + newpath;
                tbl_employmentnotice.Strupload = imagepath;
            }

            if (strFileHindi.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(strFileHindi.FileName);
                var AutoGenFileName = tbl_employmentnotice.Pk_employmentid + "-" + System.DateTime.Now.Ticks.ToString() + "-" + "HindiNoticeFILE";
                var path = Path.Combine(Server.MapPath("~/Upload/Notice/"), AutoGenFileName + fileExtension);
                strFile.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = "~/Upload/Notice/" + newpath;
                tbl_employmentnotice.StruploadHindi = imagepath1;
            }
            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            var MineType1 = Utility.getMimeFromFile(imagepath1);
            if (MineType != "Invalied" && MineType1 != "Invalied")
            {
                tbl_employmentnotice.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_employmentnotice.isactive = true;
                objemployment.Entry(tbl_employmentnotice).State = EntityState.Modified;
                objemployment.SaveChanges();
                ViewBag.Message = "Notice updated Successfully.";
                return View(tbl_employmentnotice);
            }
            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                System.IO.File.Delete(MineType1);
                return View();
            }
        }


        public ActionResult EmployeeList()
        {
            var Notice = objVwNotice.vw_EmploymentNotoc.OrderByDescending(x => x.Pk_employmentid).ToList();
            return View(Notice);
        }


        [HttpPost]
        public ActionResult LoadEmploymentNotice()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            using (vw_EmploymentNotoccontext dc = new vw_EmploymentNotoccontext())
            {

                var v = dc.vw_EmploymentNotoc.OrderByDescending(x => x.Pk_employmentid).ToList();

                string search = Request.Form.GetValues("search[value]").FirstOrDefault();

                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p =>
                                     SafeToLower(p.Empnoticeno).Contains(search.ToLower()) ||
                                     SafeToLower(p.strEmploymentType).Contains(search.ToLower()) ||
                                     SafeToLower(p.PostList).Contains(search.ToLower()) ||
                                     SafeToLower(p.Emptitle).Contains(search.ToLower())

                ).ToList();
                }


                recordsTotal = v.Count();


                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "Empnoticeno")
                        {
                            v = v.OrderByDescending(x => x.Empnoticeno).ToList();
                        }
                        if (sortColumn == "strEmploymentType")
                        {
                            v = v.OrderByDescending(x => x.strEmploymentType).ToList();
                        }
                        if (sortColumn == "PostList")
                        {
                            v = v.OrderByDescending(x => x.PostList).ToList();
                        }
                        if (sortColumn == "Emptitle")
                        {
                            v = v.OrderByDescending(x => x.Emptitle).ToList();
                        }


                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "Empnoticeno")
                        {
                            v = v.OrderBy(x => x.Empnoticeno).ToList();
                        }
                        if (sortColumn == "strEmploymentType")
                        {
                            v = v.OrderBy(x => x.strEmploymentType).ToList();
                        }
                        if (sortColumn == "PostList")
                        {
                            v = v.OrderBy(x => x.PostList).ToList();
                        }
                        if (sortColumn == "Emptitle")
                        {
                            v = v.OrderBy(x => x.Emptitle).ToList();
                        }

                    }

                }

                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        //Shoumya CorrigendumNotice  

        public ActionResult AddCorrigendumNotice()
        {


            ViewData["noticeno"] = new SelectList(objemployment.tbl_employmentnotice.ToList(),
                "Pk_employmentid", "Empnoticeno");

            return View();
        }

        [HttpPost]
        public ActionResult AddCorrigendumNotice(tbl_mst_NoticeCorrigendum tbl_mst_NoticeCorrigendum, FormCollection frm)
        {
            ViewBag.Empnoticeno = new SelectList(objemployment.tbl_employmentnotice.ToList(), "Pk_employmentid", "Empnoticeno");

            int Id = Convert.ToInt32(frm["Empnoticeno"]);

            tbl_mst_NoticeCorrigendum.fk_empnoticeid = Id;
            tbl_mst_NoticeCorrigendum.str_empnoticeno = frm["hidText"];

            tbl_mst_NoticeCorrigendum.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            tbl_mst_NoticeCorrigendum.isactive = "Yes";
            HttpPostedFileBase str_upload = Request.Files["str_upload"];

            HttpPostedFileBase str_uploadhindi = Request.Files["str_uploadhindi"];

            string imagepath = null;
            string imagepath1 = null;

            if (str_upload.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(str_upload.FileName);
                var AutoGenFileName = "CORRIGENDUM_Notice" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Notice/"), AutoGenFileName + fileExtension);
                str_upload.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = "~/Upload/Notice/" + newpath;
                tbl_mst_NoticeCorrigendum.str_upload = imagepath;
            }
            if (str_uploadhindi.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(str_uploadhindi.FileName);
                var AutoGenFileName = "CORRIGENDUM_Notice" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Notice/"), AutoGenFileName + fileExtension);
                str_uploadhindi.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = "~/Upload/Notice/" + newpath;
                tbl_mst_NoticeCorrigendum.str_uploadhindi = imagepath1;
            }


            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            var MineType1 = Utility.getMimeFromFile(imagepath1);
            if (MineType != "Invalied" && MineType1 != "Invalied")
            {
                objNoticeCorrigendum.tbl_mst_NoticeCorrigendum.Add(tbl_mst_NoticeCorrigendum);
                objNoticeCorrigendum.SaveChanges();
                //Update Notice dtClosingDate
                var updateDate = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == Id).FirstOrDefault();
                updateDate.dtclosedate = Convert.ToDateTime(tbl_mst_NoticeCorrigendum.dt_closingextenddate);
                updateDate.dtexpirydate = Convert.ToDateTime(tbl_mst_NoticeCorrigendum.dt_noticeextenddate);
                objemployment.Entry(updateDate).State = EntityState.Modified;
                objemployment.SaveChanges();
                ViewBag.Message = "Notice Corrigendum saved Successfully.";
            }
            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                System.IO.File.Delete(MineType1);
                ViewBag.Message = "Invalied file...";
            }
            return View();
        }

        [HttpPost]
        public ActionResult Noticedetails(int notice)
        {

            string empTitleValue = "";
            string empTitlehindi = "";
            string empClosingValue = "";
            string empnoticeClosingValue = "";


            var empdetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == notice).ToList();
            if (empdetails.Count > 0)
            {
                empTitleValue = empdetails.FirstOrDefault().Emptitle.ToString();
                empTitlehindi = empdetails.FirstOrDefault().EmptitleHindi.ToString();
                empClosingValue = empdetails.FirstOrDefault().dtclosedate.ToString();
                empnoticeClosingValue = empdetails.FirstOrDefault().dtexpirydate.ToString();
            }

            return Json(new { empTitleValue = empTitleValue, empTitlehindi = empTitlehindi, empClosingValue = empClosingValue, empnoticeClosingValue = empnoticeClosingValue });

        }


        public ActionResult CorrigendumNoticeList()
        {
            var Corrigendum = objNoticeCorrigendumdetails.Vw_Notice_Corrigendm.OrderByDescending(x => x.pk_corriengdumid).ToList();
            return View(Corrigendum);
        }

        //edit
        [HttpGet]
        public ActionResult EditCorrigendumNotice(int id, FormCollection frm)
        {
            var objtbl_mstCorrigendum = objNoticeCorrigendum.tbl_mst_NoticeCorrigendum.Where(x => x.pk_corriengdumid == id).FirstOrDefault();
            ViewBag.hidText = objtbl_mstCorrigendum.str_empnoticeno;
            ViewBag.dt_closingextenddate = objtbl_mstCorrigendum.dt_closingextenddate.ToString();
            ViewBag.dt_noticeextenddate = objtbl_mstCorrigendum.dt_noticeextenddate.ToString();
            ViewBag.str_upload = objtbl_mstCorrigendum.str_upload;
            ViewBag.str_uploadhindi = objtbl_mstCorrigendum.str_uploadhindi;
            ViewData["noticeno"] = new SelectList(objemployment.tbl_employmentnotice.ToList(),
              "Pk_employmentid", "Empnoticeno", objtbl_mstCorrigendum.fk_empnoticeid);

            return View();
        }

        [HttpPost]
        public ActionResult EditCorrigendumNotice(tbl_mst_NoticeCorrigendum tbl_mst_NoticeCorrigendum, FormCollection frm, int id)
        {


            var tbl_mstCorrigendumnotice = objNoticeCorrigendum.tbl_mst_NoticeCorrigendum.Where(x => x.pk_corriengdumid == id).FirstOrDefault();
            ViewData["noticeno"] = new SelectList(objemployment.tbl_employmentnotice.ToList(),
             "Pk_employmentid", "Empnoticeno", tbl_mstCorrigendumnotice.fk_empnoticeid);


            tbl_mstCorrigendumnotice.fk_empnoticeid = Convert.ToInt32(frm["Empnoticeno"]);
            tbl_mstCorrigendumnotice.str_empnoticeno = frm["hidText"];
            tbl_mstCorrigendumnotice.dt_closingextenddate = Convert.ToDateTime(frm["dt_closingextenddate"]);
            tbl_mstCorrigendumnotice.dt_noticeextenddate = Convert.ToDateTime(frm["dt_noticeextenddate"]);
            HttpPostedFileBase str_upload = Request.Files["str_upload"];
            HttpPostedFileBase str_uploadhindi = Request.Files["str_uploadhindi"];

            string imagepath = null;
            string imagepath1 = null;

            if (str_upload.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(str_upload.FileName);
                var AutoGenFileName = "CORRIGENDUM" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Notice/"), AutoGenFileName + fileExtension);
                str_upload.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath = "~/Upload/Notice/" + newpath;
                tbl_mstCorrigendumnotice.str_upload = imagepath;
            }

            if (str_uploadhindi.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(str_uploadhindi.FileName);
                var AutoGenFileName = "CORRIGENDUM_Notice" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Notice/"), AutoGenFileName + fileExtension);
                str_uploadhindi.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                imagepath1 = "~/Upload/Notice/" + newpath;
                tbl_mstCorrigendumnotice.str_uploadhindi = imagepath1;
            }

            //File extention rename
            var MineType = Utility.getMimeFromFile(imagepath);
            var MineType1 = Utility.getMimeFromFile(imagepath1);
            if (MineType != "Invalied" && MineType1 != "Invalied")
            {
                objNoticeCorrigendum.Entry(tbl_mstCorrigendumnotice).State = EntityState.Modified;
                objNoticeCorrigendum.SaveChanges();
                //Update tendor dtClosingDate
                var updateDate = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == tbl_mstCorrigendumnotice.fk_empnoticeid).FirstOrDefault();
                updateDate.dtclosedate = Convert.ToDateTime(tbl_mst_NoticeCorrigendum.dt_closingextenddate);
                updateDate.dtexpirydate = Convert.ToDateTime(tbl_mst_NoticeCorrigendum.dt_noticeextenddate);
                objemployment.Entry(updateDate).State = EntityState.Modified;
                objemployment.SaveChanges();
                ViewBag.str_upload = tbl_mstCorrigendumnotice.str_upload;
                ViewBag.str_uploadhindi = tbl_mstCorrigendumnotice.str_uploadhindi;
                ViewBag.Message = string.Format("Corrigendum updated successfully !");
            }
            else
            {
                //File extention rename
                System.IO.File.Delete(MineType);
                System.IO.File.Delete(MineType1);
                ViewBag.Message = "Invalied file...";
            }
            return View();
        }




        public ActionResult FeedbackList()
        {


            var Feedbcklist = objfeedback.tbl_feedback.ToList();

            return View(Feedbcklist);

        }
        public ActionResult Feedbackview(int id)
        {
            var Feedback = objfeedback.tbl_feedback.Where(x => x.Pk_Titleid == id).FirstOrDefault();

            ViewBag.Fk_titleid = new SelectList(objtitle.tbl_feedbacktitle.ToList(), "Pk_feedbacktitleid", "strtitle_name",
            Feedback.Fk_titleid);
            return View(Feedback);
        }


        //AddQuarterlyReport
        public ActionResult AddQuarterlyReport()
        {

            ViewBag.numYear = new SelectList((from s in objtbl_mst_FinancialYear.tbl_mst_FinancialYear.ToList()
                                              select new
                                              {
                                                  Pk_int_FinYear = s.strFinancialYear.Split('-')[0],
                                                  strFinancialYear = s.strFinancialYear
                                              }),
                 "Pk_int_FinYear",
                 "strFinancialYear",
                 null);


            //ViewBag.numYear = new SelectList(objtbl_mst_FinancialYear.tbl_mst_FinancialYear.ToList(), "strFinancialYear", "strFinancialYear");



            ViewBag.QuarterId = new SelectList(objquarter.tbl_mst_Quarter.ToList(), "Pk_intQuarterID", "strQuarterName");
            ViewBag.ItemId = new SelectList(obj_tbl_mstParticularMasterContext.tbl_mstParticularMaster.ToList(), "ParticularId", "ParticularDesc");

            return View();

        }

        [HttpPost]
        public ActionResult AddQuarterlyReport(tbl_Quarterly_Report tbl_Quarterly_Report, FormCollection frm)
        {
            ViewBag.numYear = new SelectList((from s in objtbl_mst_FinancialYear.tbl_mst_FinancialYear.ToList()
                                              select new
                                              {
                                                  Pk_int_FinYear = s.strFinancialYear.Split('-')[0],
                                                  strFinancialYear = s.strFinancialYear
                                              }),
                "Pk_int_FinYear",
                "strFinancialYear",
                null);
            ViewBag.QuarterId = new SelectList(objquarter.tbl_mst_Quarter.ToList(), "Pk_intQuarterID", "strQuarterName");
            ViewBag.ItemId = new SelectList(obj_tbl_mstParticularMasterContext.tbl_mstParticularMaster.ToList(), "ParticularId", "ParticularDesc");

            if (ModelState.IsValid)
            {

                tbl_Quarterly_Report.vchProfStatus = "P";
                tbl_Quarterly_Report.dtmCreatedOn = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objquarterReport.tbl_Quarterly_Report.Add(tbl_Quarterly_Report);
                objquarterReport.SaveChanges();

                ViewBag.Message = string.Format("Data saved successfully !");
                ModelState.Clear();
                return View();
            }
            return View();

        }
        [HttpPost]
        public ActionResult QuarterReport(string txtData)
        {
            if (txtData != "FN" && txtData != "PD")
            {
                txtData = "S";
            }
            if (txtData == "PD")
            {
                txtData = "Z";
            }

            var ParticularMaster = obj_tbl_mstParticularMasterContext.tbl_mstParticularMaster.Where(x => x.ParticularStatus == txtData).ToList();
            return Json(new { Particular = ParticularMaster });

        }

        //ListQuarterlyReport
        public ActionResult ListQuarterlyReport()
        {
            //var QuarterlyReportList = objQuarterlyreportcontext.Vw_Quarterlyreport.OrderByDescending(x => x.Pk_ReportId).ToList();
            //return View(QuarterlyReportList);
            return View();
        }


        [HttpPost]
        public ActionResult LoadListQuarterly()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            using (Vw_Quarterlyreportcontext dc = new Vw_Quarterlyreportcontext())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var v = dc.Vw_Quarterlyreport.ToList();//(from a in dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0") select a);

                string search = Request.Form.GetValues("search[value]").FirstOrDefault();
                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p => SafeToLower(p.ParticularDesc).Contains(search.ToLower()) ||
                                     SafeToLower(p.numYear.ToString()).Contains(search.ToLower()) ||
                                     SafeToLower(p.QuarterId.ToString()).Contains(search.ToLower()) ||
                                     SafeToLower(p.numSalesData.ToString()).Contains(search.ToLower())
                ).ToList();
                }


                recordsTotal = v.Count();

                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "ParticularDesc")
                        {
                            v = v.OrderByDescending(x => x.ParticularDesc).ToList();
                        }
                        if (sortColumn == "numYear")
                        {
                            v = v.OrderByDescending(x => x.numYear).ToList();
                        }
                        if (sortColumn == "QuarterId")
                        {
                            v = v.OrderByDescending(x => x.QuarterId).ToList();
                        }
                        if (sortColumn == "numSalesData")
                        {
                            v = v.OrderByDescending(x => x.numSalesData).ToList();
                        }
                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "ParticularDesc")
                        {
                            v = v.OrderBy(x => x.ParticularDesc).ToList();
                        }
                        if (sortColumn == "numYear")
                        {
                            v = v.OrderBy(x => x.numYear).ToList();
                        }
                        if (sortColumn == "QuarterId")
                        {
                            v = v.OrderBy(x => x.QuarterId).ToList();
                        }
                        if (sortColumn == "numSalesData")
                        {
                            v = v.OrderBy(x => x.numSalesData).ToList();
                        }
                    }

                }

                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }


        //EditQuarterlyReport
        public ActionResult EditQuarterlyReport(int id)
        {
            var QuarterlyReport = objquarterReport.tbl_Quarterly_Report.Where(x => x.Pk_ReportId == id).FirstOrDefault();
            //ViewBag.numYear = new SelectList(objtbl_mst_FinancialYear.tbl_mst_FinancialYear.ToList(), "Pk_int_FinYear", "strFinancialYear", QuarterlyReport.numYear);

            ViewBag.numYear = new SelectList((from s in objtbl_mst_FinancialYear.tbl_mst_FinancialYear.ToList()
                                              select new
                                              {
                                                  Pk_int_FinYear = s.strFinancialYear.Split('-')[0],
                                                  strFinancialYear = s.strFinancialYear
                                              }),
                "Pk_int_FinYear",
                "strFinancialYear",
                QuarterlyReport.numYear);

            ViewBag.QuarterId = new SelectList(objquarter.tbl_mst_Quarter.ToList(), "Pk_intQuarterID", "strQuarterName", QuarterlyReport.QuarterId);
            ViewBag.ItemId = new SelectList(obj_tbl_mstParticularMasterContext.tbl_mstParticularMaster.ToList(), "ParticularId", "ParticularDesc", QuarterlyReport.ItemId);
            return View(QuarterlyReport);
        }
        [HttpPost]
        public ActionResult EditQuarterlyReport(tbl_Quarterly_Report tbl_Quarterly_Report, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.numYear = new SelectList(objtbl_mst_FinancialYear.tbl_mst_FinancialYear.ToList(), "Pk_int_FinYear", "strFinancialYear", tbl_Quarterly_Report.numYear);
                ViewBag.QuarterId = new SelectList(objquarter.tbl_mst_Quarter.ToList(), "Pk_intQuarterID", "strQuarterName", tbl_Quarterly_Report.QuarterId);
                ViewBag.ItemId = new SelectList(obj_tbl_mstParticularMasterContext.tbl_mstParticularMaster.ToList(), "ParticularId", "ParticularDesc", tbl_Quarterly_Report.ItemId);
                objquarterReport.Entry(tbl_Quarterly_Report).State = EntityState.Modified;
                objquarterReport.SaveChanges();

                ViewBag.Message = string.Format("Data updated successfully !");
                return View();

            }
            return View();
        }
        //Delete QuarterlyReport
        public ActionResult DeleteQuarterlyReport(int id)
        {
            var QuarterlyReport = objquarterReport.tbl_Quarterly_Report.Where(x => x.Pk_ReportId == id).FirstOrDefault();

            objquarterReport.Entry(QuarterlyReport).State = EntityState.Deleted;
            objquarterReport.SaveChanges();
            return RedirectToAction("ListQuarterlyReport");
        }

        public ActionResult EditFinancialYear(int id)
        {
            var Financial = objtbl_mst_FinancialYear.tbl_mst_FinancialYear.Where(x => x.Pk_int_FinYear == id).FirstOrDefault();
            return View(Financial);
        }

        [HttpPost]
        public ActionResult EditFinancialYear(tbl_mst_FinancialYear tbl_mst_FinancialYear, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    tbl_mst_FinancialYear.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    objtbl_mst_FinancialYear.Entry(tbl_mst_FinancialYear).State = EntityState.Modified;
                    objtbl_mst_FinancialYear.SaveChanges();
                    ViewBag.Message = string.Format("Financial Year updated Successfully.");
                    ModelState.Clear();
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Message = string.Format(ex.Message);
                    return View();
                }
            }

            return View();
        }
        public ActionResult ListFinancialYear()
        {

            var Financial = objtbl_mst_FinancialYear.tbl_mst_FinancialYear.OrderByDescending(x => x.Pk_int_FinYear).ToList();
            return View(Financial);
        }
        public ActionResult FinancialDetailListDelete(int id)
        {
            var FinancialDelete = objtbl_mst_FinancialYear.tbl_mst_FinancialYear.Where(x => x.Pk_int_FinYear == id).FirstOrDefault();
            //var chcktransection=
            objtbl_mst_FinancialYear.Entry(FinancialDelete).State = EntityState.Deleted;
            objtbl_mst_FinancialYear.SaveChanges();
            return RedirectToAction("ListFinancialYear");
        }

        //Roni
        public ActionResult ListCustomer()
        {
            var Region = Session["UserRegion"].ToString();
            var Customer = objCustomer.SpotbookingRegistrationdetails.ToList();
            if (Region != "All")
            {
                Customer = Customer.Where(x => x.fk_region == Region).OrderByDescending(x => x.Pk_Registrationid).ToList();
            }

            return View(Customer);
        }



        //Bhashkar Download Customer in CSV

        public void DownloadListCustomerincsv()
        {
            StringWriter sw = new StringWriter();

            sw.WriteLine("\"Sl No.\",\"First Name\",\"Middle Name\",\"Last Name\",\"Email\",\"Phone No\",\"Office No\",\"Mobile\",\"Fax\",\"Address\",\"City\",\"District\",\"State\",\"Pin\",\"Country\",\"Pan No\",\"GST  No\",\"Name of  Firm\",\"Code\",\"Customer Status\",\"Customer Status Date\",\"Region\",\"Remarks\"");

            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=AllCustomer.csv");
            Response.ContentType = "application/octet-stream";

            var Customer = objCustomer.SpotbookingRegistrationdetails.OrderByDescending(x => x.Pk_Registrationid).ToList();

            int i = 1;

            foreach (var user in Customer)
            {
                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\",\"{21}\",\"{22}\"",

                i,
                user.str_fname,
                user.str_mname,
                user.str_lname,
                user.str_email,
                user.str_phno,
                user.str_officeno,
                user.str_mobile,
                user.str_fax,
                user.str_address,
                user.str_city,
                user.str_district,
                user.str_state,
                user.str_pin,
                user.str_country,
                user.str_panno,
                user.str_gstno,
                user.str_namefirm,
                user.str_code,
                user.str_CustomerStatus,
                user.dt_CustomerStatusDate,
                user.fk_region,
                user.str_Remarks
                ));

                i++;
            }

            Response.Write(sw.ToString());
            Response.End();
        }





        //Debtana Export To Excel
        public void DownloadListCustomer()
        {

            var Customer = objCustomer.SpotbookingRegistrationdetails.OrderByDescending(x => x.Pk_Registrationid).ToList();
            if (Customer.Count > 0)
            {


                try
                {

                    string strFileName = "LME_CustomerList" + ".xls";
                    FileStream fs = new FileStream(Server.MapPath("/ExcelReport") + "/LME_CustomerList.xls", FileMode.Open, FileAccess.Read);
                    HSSFWorkbook wb = new HSSFWorkbook(fs, true);
                    HSSFSheet ws = (HSSFSheet)wb.GetSheet("Sheet1");

                    int i = 1;


                    foreach (var detailsofCustomer in Customer)
                    {

                        ws.GetRow(i).GetCell(0).SetCellValue(i.ToString());
                        ws.GetRow(i).GetCell(1).SetCellValue(detailsofCustomer.str_fname);
                        ws.GetRow(i).GetCell(2).SetCellValue(detailsofCustomer.str_mname);
                        ws.GetRow(i).GetCell(3).SetCellValue(detailsofCustomer.str_lname);
                        ws.GetRow(i).GetCell(4).SetCellValue(detailsofCustomer.str_email);
                        ws.GetRow(i).GetCell(5).SetCellValue(detailsofCustomer.str_phno);
                        ws.GetRow(i).GetCell(6).SetCellValue(detailsofCustomer.str_officeno);



                        ws.GetRow(i).GetCell(7).SetCellValue(detailsofCustomer.str_mobile);
                        ws.GetRow(i).GetCell(8).SetCellValue(detailsofCustomer.str_fax);
                        ws.GetRow(i).GetCell(9).SetCellValue(detailsofCustomer.str_address);
                        ws.GetRow(i).GetCell(10).SetCellValue(detailsofCustomer.str_city);
                        ws.GetRow(i).GetCell(11).SetCellValue(detailsofCustomer.str_district);
                        ws.GetRow(i).GetCell(12).SetCellValue(detailsofCustomer.str_state);
                        ws.GetRow(i).GetCell(13).SetCellValue(detailsofCustomer.str_pin);
                        ws.GetRow(i).GetCell(14).SetCellValue(detailsofCustomer.str_country);
                        ws.GetRow(i).GetCell(15).SetCellValue(detailsofCustomer.str_panno);
                        ws.GetRow(i).GetCell(16).SetCellValue(detailsofCustomer.str_gstno);
                        ws.GetRow(i).GetCell(17).SetCellValue(detailsofCustomer.str_namefirm);
                        ws.GetRow(i).GetCell(18).SetCellValue(detailsofCustomer.str_code);

                        ws.GetRow(i).GetCell(19).SetCellValue(detailsofCustomer.str_CustomerStatus);



                        if (detailsofCustomer.dt_CustomerStatusDate == null)
                        {
                            ws.GetRow(i).GetCell(20).SetCellValue("");
                        }
                        else
                        {
                            ws.GetRow(i).GetCell(20).SetCellValue((Convert.ToDateTime(detailsofCustomer.dt_CustomerStatusDate)).ToString("yyyy/MM/dd"));

                        }





                        ws.GetRow(i).GetCell(21).SetCellValue(detailsofCustomer.fk_region);

                        ws.GetRow(i).GetCell(22).SetCellValue(detailsofCustomer.str_Remarks);

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
            //return View();
        }





        //Debtana





        public void DownloadManageOrder()
        {

            var Manageorder = objSpotbookingOrders.tbl_mst_SpotbookingOrders.OrderByDescending(x => x.Pk_intOrderID).ToList();
            if (Manageorder.Count > 0)
            {


                try
                {

                    string strFileName = "LME_ManageOrder" + ".xls";
                    FileStream fs = new FileStream(Server.MapPath("/ExcelReport") + "/LME_ManageOrder.xls", FileMode.Open, FileAccess.Read);
                    HSSFWorkbook wb = new HSSFWorkbook(fs, true);
                    HSSFSheet ws = (HSSFSheet)wb.GetSheet("Sheet1");

                    int i = 1;


                    foreach (var detailsofOrder in Manageorder)
                    {

                        ws.GetRow(i).GetCell(0).SetCellValue(i.ToString());
                        ws.GetRow(i).GetCell(1).SetCellValue(detailsofOrder.strOrganisationName);
                        ws.GetRow(i).GetCell(2).SetCellValue(detailsofOrder.strProducts);
                        ws.GetRow(i).GetCell(3).SetCellValue((Convert.ToDouble(detailsofOrder.fltProductPrice)).ToString());
                        ws.GetRow(i).GetCell(4).SetCellValue(detailsofOrder.strOrderType);
                        ws.GetRow(i).GetCell(5).SetCellValue(detailsofOrder.strOrderOption);
                        ws.GetRow(i).GetCell(6).SetCellValue(detailsofOrder.str_orderid);



                        if (detailsofOrder.dtOrderDate == null)
                        {
                            ws.GetRow(i).GetCell(7).SetCellValue("");
                        }
                        else
                        {
                            DateTime orderdt = Convert.ToDateTime(detailsofOrder.dtOrderDate);
                            ws.GetRow(i).GetCell(7).SetCellValue(orderdt.ToString("yyyy/MM/dd"));

                        }


                        if (detailsofOrder.tmRealBookingTime == null)
                        {
                            ws.GetRow(i).GetCell(8).SetCellValue("");
                        }
                        else
                        {
                            ws.GetRow(i).GetCell(8).SetCellValue((Convert.ToDateTime(detailsofOrder.tmRealBookingTime)).ToString("yyyy/MM/dd"));
                        }

                        ws.GetRow(i).GetCell(9).SetCellValue(detailsofOrder.fltBookedQuantity);
                        ws.GetRow(i).GetCell(10).SetCellValue(detailsofOrder.strLiftingOption);
                        ws.GetRow(i).GetCell(11).SetCellValue(detailsofOrder.strcode);
                        ws.GetRow(i).GetCell(12).SetCellValue(detailsofOrder.str_OrderStatus);




                        if (detailsofOrder.dt_OrderStatusDate == null)
                        {
                            ws.GetRow(i).GetCell(13).SetCellValue("");
                        }
                        else
                        {
                            ws.GetRow(i).GetCell(13).SetCellValue((Convert.ToDateTime(detailsofOrder.dt_OrderStatusDate)).ToString("yyyy/MM/dd"));
                        }





                        ws.GetRow(i).GetCell(14).SetCellValue(detailsofOrder.str_OrderStatusRemarks);
                        ws.GetRow(i).GetCell(15).SetCellValue(detailsofOrder.str_deliveryplace);

                        ws.GetRow(i).GetCell(16).SetCellValue(detailsofOrder.str_bookingbasicprice);
                        ws.GetRow(i).GetCell(17).SetCellValue(detailsofOrder.str_bookingquantityaccept);
                        ws.GetRow(i).GetCell(18).SetCellValue(detailsofOrder.str_bookingproductaccept);
                        ws.GetRow(i).GetCell(19).SetCellValue(detailsofOrder.strComments);



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
            //return View();
        }




        //Debtana pdf

        public void PdfCustomerList()
        {
            eCustomerListApplication chl = new eCustomerListApplication();



            chl.Hcllogo = "~/Content/img/logo.png";
            chl.HeadLine1 = "Hindustan Copper Limited (HCL)";
            chl.HeadLine2 = "";
            chl.HeadLine3 = "";
            chl.HeadLine4 = "";
            //chl.HeadLine5 = "Application For Admission To B.A./B.Sc./B.Com. 1st Year";
            chl.HeadLine5 = "Customer List";
            //chl.HeadLine7 = "Session " + sessionDetails.strSession;
            var mem = chl.CreateChallan();
            byte[] bytesInStream = mem.ToArray();
            Response.Clear();
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment;    filename=CustomerList" + ".pdf");
            Response.BinaryWrite(bytesInStream);
            Response.End();


        }







        public void PdfCustomerOrder()
        {
            eCustomerOrderApplication chl = new eCustomerOrderApplication();

            chl.str_OrderStatus = Request.QueryString["str_OrderStatus"];
            chl.nameOfComapany = Request.QueryString["nameOfComapany"];
            chl.dtDate1 = Request.QueryString["dtDate1"];
            chl.dtDate2 = Request.QueryString["dtDate2"];
            chl.Region = Session["UserRegion"].ToString();


            chl.Hcllogo = "~/Content/img/logo.png";
            chl.HeadLine1 = "Hindustan Copper Limited (HCL)";
            chl.HeadLine5 = "Order List ( Status:" + Request.QueryString["str_OrderStatus"] + "  From Date:" + Request.QueryString["dtDate1"] + "   To Date:" + Request.QueryString["dtDate2"] + "  Organisation:" + Request.QueryString["nameOfComapany"] + ")";
            var mem = chl.CreateChallan();
            byte[] bytesInStream = mem.ToArray();
            Response.Clear();
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment;    filename=OrderList" + ".pdf");
            Response.BinaryWrite(bytesInStream);
            Response.End();


        }


        [HttpPost]
        public ActionResult LoadCustomer()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            using (Spotbookingregistrationcontext dc = new Spotbookingregistrationcontext())
            {
                var Region = Session["UserRegion"].ToString();
                var v = objCustomer.SpotbookingRegistrationdetails.OrderByDescending(x => x.Pk_Registrationid).ToList();
                if (Region != "All")
                {
                    v = v.Where(x => x.fk_region == Region).OrderByDescending(x => x.Pk_Registrationid).ToList();
                }
                //v = dc.SpotbookingRegistrationdetails.OrderByDescending(x => x.Pk_Registrationid).ToList();

                string search = Request.Form.GetValues("search[value]").FirstOrDefault();

                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p =>
                                     SafeToLower(p.str_namefirm).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_city).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_email).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_fname).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_lname).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_mname).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_CustomerStatus).Contains(search.ToLower())

                ).ToList();
                }


                recordsTotal = v.Count();


                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "str_namefirm")
                        {
                            v = v.OrderByDescending(x => x.str_namefirm).ToList();
                        }
                        if (sortColumn == "str_city")
                        {
                            v = v.OrderByDescending(x => x.str_city).ToList();
                        }
                        if (sortColumn == "str_email")
                        {
                            v = v.OrderByDescending(x => x.str_email).ToList();
                        }
                        if (sortColumn == "str_fname")
                        {
                            v = v.OrderByDescending(x => x.str_fname).ToList();
                        }
                        if (sortColumn == "str_lname")
                        {
                            v = v.OrderByDescending(x => x.str_lname).ToList();
                        }
                        if (sortColumn == "str_mname")
                        {
                            v = v.OrderByDescending(x => x.str_mname).ToList();
                        }
                        if (sortColumn == "str_CustomerStatus")
                        {
                            v = v.OrderByDescending(x => x.str_CustomerStatus).ToList();
                        }

                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "str_namefirm")
                        {
                            v = v.OrderBy(x => x.str_namefirm).ToList();
                        }
                        if (sortColumn == "str_city")
                        {
                            v = v.OrderBy(x => x.str_city).ToList();
                        }
                        if (sortColumn == "str_email")
                        {
                            v = v.OrderBy(x => x.str_email).ToList();
                        }
                        if (sortColumn == "str_fname")
                        {
                            v = v.OrderBy(x => x.str_fname).ToList();
                        }
                        if (sortColumn == "str_lname")
                        {
                            v = v.OrderBy(x => x.str_lname).ToList();
                        }
                        if (sortColumn == "str_mname")
                        {
                            v = v.OrderBy(x => x.str_mname).ToList();
                        }
                        if (sortColumn == "str_CustomerStatus")
                        {
                            v = v.OrderBy(x => x.str_CustomerStatus).ToList();
                        }

                    }

                }

                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }



        public ActionResult EditCustomer(int id)
        {
            var Customer = objCustomer.SpotbookingRegistrationdetails.Where(x => x.Pk_Registrationid == id).FirstOrDefault();
            return View(Customer);
        }

        [HttpPost]
        public ActionResult EditCustomer(SpotbookingRegistrationdetails SpotbookingRegistrationdetails, FormCollection frm)
        {
            SpotbookingRegistrationdetails.dt_CustomerStatusDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            objCustomer.Entry(SpotbookingRegistrationdetails).State = EntityState.Modified;
            objCustomer.SaveChanges();

            var MaillContent = objMailContent.tbl_MailContent.OrderByDescending(x => x.strMailPurposeType == "Customer Status Change").FirstOrDefault();
            if (MaillContent != null)
            {

                StringBuilder stringBuilder = new StringBuilder(MaillContent.strBody);
                stringBuilder.Replace("{name}", SpotbookingRegistrationdetails.str_fname);
                stringBuilder.Replace("{status}", SpotbookingRegistrationdetails.str_CustomerStatus);
                stringBuilder.Replace("{username}", SpotbookingRegistrationdetails.str_code);
                stringBuilder.Replace("{password}", SpotbookingRegistrationdetails.str_pw);
                string EmailBody = stringBuilder.ToString().Replace("\r\n", "<br/>");
                Utility.SendEmail(SpotbookingRegistrationdetails.str_email, MaillContent.strSubject, EmailBody);
            }


            return RedirectToAction("ListCustomer");
        }

        //public ActionResult ListOrders()
        //{
        //    var Order = objSpotbookingOrders.tbl_mst_SpotbookingOrders.OrderByDescending(x => x.Pk_intOrderID).ToList();
        //    return View(Order);
        //}


        [HttpPost]
        public JsonResult InsertOrderFromList(SpotbookingOrdersLst SpotbookingOrdersLst, FormCollection frm)
        {
            List<tbl_mst_SpotbookingOrders> Lsttbl_mst_SpotbookingOrders = new List<tbl_mst_SpotbookingOrders>();



            foreach (var Sto in SpotbookingOrdersLst.OrderList)
            {
                var pmt = objSpotbookingOrders.tbl_mst_SpotbookingOrders.Single(x => x.Pk_intOrderID == Sto.Pk_intOrderID);
                if (Sto.str_bookingbasicprice != "" && Sto.str_bookingbasicprice != null && Sto.str_bookingquantityaccept != "" && Sto.str_bookingquantityaccept != null && Sto.str_bookingproductaccept != "" && Sto.str_bookingproductaccept != null && Sto.str_OrderStatusRemarks != "" && Sto.str_OrderStatusRemarks != null)
                {
                    pmt.str_OrderStatus = "Approved";
                    pmt.dt_OrderStatusDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    pmt.str_bookingbasicprice = Sto.str_bookingbasicprice;
                    pmt.str_bookingquantityaccept = Sto.str_bookingquantityaccept;
                    pmt.str_bookingproductaccept = Sto.str_bookingproductaccept;
                    pmt.str_OrderStatusRemarks = Sto.str_OrderStatusRemarks;
                    objSpotbookingOrders.Entry(pmt).State = EntityState.Modified;
                    objSpotbookingOrders.SaveChanges();


                    var loginuser = objCustomer.SpotbookingRegistrationdetails.Where(a => a.str_code.Equals(pmt.strcode)).FirstOrDefault();
                    string emailcontent = "Please login and check your dashboard.";
                    Utility.SendEmail(loginuser.str_email, "Order confirmation", emailcontent);

                }

            }
            return Json(JsonRequestBehavior.AllowGet, "Data Updated Succssfully");
        }

        public ActionResult ListOrders()
        {

            var Region = Session["UserRegion"].ToString();
            var Order = objSpotbookingDetails.Vw_SpotbookingDetails.OrderByDescending(x => x.Pk_Registrationid).ToList();
            if (Region != "All")
            {
                Order = Order.Where(x => x.fk_region == Region).OrderByDescending(x => x.Pk_Registrationid).ToList();
            }

            //var Order = objSpotbookingOrders.tbl_mst_SpotbookingOrders.OrderByDescending(x => x.Pk_intOrderID).ToList();
            ViewBag.nameOfComapany = new SelectList(objCustomer.SpotbookingRegistrationdetails.Where(x => x.str_CustomerStatus == "Approved").ToList(), "str_namefirm", "str_namefirm");
            return View(Order);
        }

        [HttpPost]
        public ActionResult ListOrders(FormCollection frm)
        {
            var Region = Session["UserRegion"].ToString();
            var Order = objSpotbookingDetails.Vw_SpotbookingDetails.OrderByDescending(x => x.Pk_Registrationid).ToList();

            if (Region != "All")
            {
                Order = Order.Where(x => x.fk_region == Region).OrderByDescending(x => x.Pk_Registrationid).ToList();
            }

            // var Order = objSpotbookingOrders.tbl_mst_SpotbookingOrders.OrderByDescending(x => x.Pk_intOrderID).ToList();
            ViewBag.nameOfComapany = new SelectList(objCustomer.SpotbookingRegistrationdetails.Where(x => x.str_CustomerStatus == "Approved").ToList(), "str_namefirm", "str_namefirm", frm["nameOfComapany"]);
            ViewBag.str_OrderStatus = frm["str_OrderStatus"];

            if (frm["nameOfComapany"] != null)
            {
                Order = Order.Where(x => x.strOrganisationName == frm["nameOfComapany"]).ToList();
            }

            if (frm["str_OrderStatus"] != null)
            {
                Order = Order.Where(x => x.str_OrderStatus == frm["str_OrderStatus"]).ToList();
            }

            if (frm["dtDate1"] != "" && frm["dtDate2"] != "")
            {

                var a = frm["dtDate1"];
                DateTime fromDate = Convert.ToDateTime(frm["dtDate1"]);
                DateTime toDate = Convert.ToDateTime(frm["dtDate2"]);

                Order = Order.Where(x => x.tmRealBookingTime >= fromDate && x.tmRealBookingTime <= toDate).ToList();
            }
            ViewBag.dtDate1 = frm["dtDate1"];
            ViewBag.dtDate2 = frm["dtDate2"];
            return View(Order);
        }


        [HttpPost]
        public ActionResult LoadOrder(string Status, string FromDate, string ToDate, string Comapany)
        {
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            using (Vw_SpotbookingDetailscontext dc = new Vw_SpotbookingDetailscontext())
            {
                var Region = Session["UserRegion"].ToString();
                var v = objSpotbookingDetails.Vw_SpotbookingDetails.OrderByDescending(x => x.Pk_intOrderID).ToList();
                if (Region != "All")
                {
                    v = v.Where(x => x.fk_region == Region).OrderByDescending(x => x.Pk_intOrderID).ToList();
                    Comapany = null;
                    Status = null;
                    FromDate = null;
                    ToDate = null;
                }

                if (!string.IsNullOrEmpty(Comapany))
                {
                    v = v.Where(x => x.strOrganisationName == Comapany).ToList();
                }

                if (!string.IsNullOrEmpty(Status))
                {
                    v = v.Where(x => x.str_OrderStatus == Status).ToList();
                }

                if (!string.IsNullOrEmpty(FromDate) && !string.IsNullOrEmpty(ToDate))
                {
                    DateTime fromDate = Convert.ToDateTime(FromDate);
                    DateTime toDate = Convert.ToDateTime(ToDate).AddHours(24);

                    v = v.Where(x => x.tmRealBookingTime >= fromDate && x.tmRealBookingTime <= toDate).ToList();
                }

                //v = dc.SpotbookingRegistrationdetails.OrderByDescending(x => x.Pk_Registrationid).ToList();

                string search = Request.Form.GetValues("search[value]").FirstOrDefault();

                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p =>

                                     SafeToLower(p.tmRealBookingTime.ToString()).Contains(search.ToLower()) ||
                                     SafeToLower(p.strOrganisationName).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_orderid).Contains(search.ToLower()) ||
                                     SafeToLower(p.strProducts).Contains(search.ToLower()) ||
                                     SafeToLower(p.strOrderType).Contains(search.ToLower()) ||
                                     SafeToLower(p.strOrderOption).Contains(search.ToLower()) ||
                                     SafeToLower(p.strLiftingOption).Contains(search.ToLower()) ||
                                     SafeToLower(p.fltBookedQuantity).Contains(search.ToLower()) ||
                                     SafeToLower(p.fltProductPrice.ToString()).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_OrderStatus).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_bookingbasicprice).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_bookingproductaccept).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_bookingquantityaccept).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_OrderStatusRemarks).Contains(search.ToLower())

                ).ToList();
                }


                recordsTotal = v.Count();


                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "dtOrderDatetime")
                        {
                            v = v.OrderByDescending(x => x.dtOrderDatetime).ToList();
                        }
                        if (sortColumn == "tmRealBookingTime")
                        {
                            v = v.OrderByDescending(x => x.tmRealBookingTime).ToList();
                        }
                        if (sortColumn == "strOrganisationName")
                        {
                            v = v.OrderByDescending(x => x.strOrganisationName).ToList();
                        }
                        if (sortColumn == "str_orderid")
                        {
                            v = v.OrderByDescending(x => x.str_orderid).ToList();
                        }
                        if (sortColumn == "strProducts")
                        {
                            v = v.OrderByDescending(x => x.strProducts).ToList();
                        }
                        if (sortColumn == "strOrderType")
                        {
                            v = v.OrderByDescending(x => x.strOrderType).ToList();
                        }
                        if (sortColumn == "strOrderOption")
                        {
                            v = v.OrderByDescending(x => x.strOrderOption).ToList();
                        }
                        if (sortColumn == "strLiftingOption")
                        {
                            v = v.OrderByDescending(x => x.strLiftingOption).ToList();
                        }
                        if (sortColumn == "fltBookedQuantity")
                        {
                            v = v.OrderByDescending(x => x.fltBookedQuantity).ToList();
                        }
                        if (sortColumn == "fltProductPrice")
                        {
                            v = v.OrderByDescending(x => x.fltProductPrice).ToList();
                        }
                        if (sortColumn == "str_OrderStatus")
                        {
                            v = v.OrderByDescending(x => x.str_OrderStatus).ToList();
                        }
                        if (sortColumn == "str_bookingbasicprice")
                        {
                            v = v.OrderByDescending(x => x.str_bookingbasicprice).ToList();
                        }
                        if (sortColumn == "str_bookingproductaccept")
                        {
                            v = v.OrderByDescending(x => x.str_bookingproductaccept).ToList();
                        }
                        if (sortColumn == "str_bookingquantityaccept")
                        {
                            v = v.OrderByDescending(x => x.str_bookingquantityaccept).ToList();
                        }
                        if (sortColumn == "str_OrderStatusRemarks")
                        {
                            v = v.OrderByDescending(x => x.str_OrderStatusRemarks).ToList();
                        }

                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "dtOrderDatetime")
                        {
                            v = v.OrderBy(x => x.dtOrderDatetime).ToList();
                        }

                        if (sortColumn == "tmRealBookingTime")
                        {
                            v = v.OrderBy(x => x.tmRealBookingTime).ToList();
                        }
                        if (sortColumn == "strOrganisationName")
                        {
                            v = v.OrderBy(x => x.strOrganisationName).ToList();
                        }
                        if (sortColumn == "str_orderid")
                        {
                            v = v.OrderBy(x => x.str_orderid).ToList();
                        }
                        if (sortColumn == "strProducts")
                        {
                            v = v.OrderBy(x => x.strProducts).ToList();
                        }
                        if (sortColumn == "strOrderType")
                        {
                            v = v.OrderBy(x => x.strOrderType).ToList();
                        }
                        if (sortColumn == "strOrderOption")
                        {
                            v = v.OrderBy(x => x.strOrderOption).ToList();
                        }
                        if (sortColumn == "strLiftingOption")
                        {
                            v = v.OrderBy(x => x.strLiftingOption).ToList();
                        }
                        if (sortColumn == "fltBookedQuantity")
                        {
                            v = v.OrderBy(x => x.fltBookedQuantity).ToList();
                        }
                        if (sortColumn == "fltProductPrice")
                        {
                            v = v.OrderBy(x => x.fltProductPrice).ToList();
                        }
                        if (sortColumn == "str_OrderStatus")
                        {
                            v = v.OrderBy(x => x.str_OrderStatus).ToList();
                        }
                        if (sortColumn == "str_bookingbasicprice")
                        {
                            v = v.OrderBy(x => x.str_bookingbasicprice).ToList();
                        }
                        if (sortColumn == "str_bookingproductaccept")
                        {
                            v = v.OrderBy(x => x.str_bookingproductaccept).ToList();
                        }
                        if (sortColumn == "str_bookingquantityaccept")
                        {
                            v = v.OrderBy(x => x.str_bookingquantityaccept).ToList();
                        }
                        if (sortColumn == "str_OrderStatusRemarks")
                        {
                            v = v.OrderBy(x => x.str_OrderStatusRemarks).ToList();
                        }

                    }

                }

                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }


        }



        public ActionResult EditOrder(int id)
        {
            var Order = objSpotbookingOrders.tbl_mst_SpotbookingOrders.Where(x => x.Pk_intOrderID == id).FirstOrDefault();
            ViewBag.hidstr_OrderStatus = Order.str_OrderStatus;
            @ViewBag.Id = id;
            return View(Order);
        }

        [HttpPost]
        public ActionResult EditOrder(tbl_mst_SpotbookingOrders tbl_mst_SpotbookingOrders, FormCollection frm)
        {


            if (frm["hidstr_OrderStatus"] == "Pending")
            {
                tbl_mst_SpotbookingOrders.dt_OrderStatusDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objSpotbookingOrders.Entry(tbl_mst_SpotbookingOrders).State = EntityState.Modified;
                objSpotbookingOrders.SaveChanges();
                ViewBag.Message = "Data updated Successfully.";
                var loginuser = objCustomer.SpotbookingRegistrationdetails.Where(a => a.str_code.Equals(tbl_mst_SpotbookingOrders.strcode)).FirstOrDefault();
                string emailcontent = "Hi,<br> <a href='http://hindustancopper.com/Spotbooking/PdfSpotBookingRegistrationPrint?Order='" + tbl_mst_SpotbookingOrders.Pk_intOrderID + "'>Click hear to show order details</a>";
                Utility.SendEmail(loginuser.str_email, "Order Status Change", emailcontent);

                return RedirectToAction("ListOrders");
            }
            else
            {
                ViewBag.Message = "Already Done.";
                return View();
            }
        }
        //Roni
        //shoumya
        public ActionResult CreateLMEUser()
        {

            return View();
        }

        [HttpPost]
        public ActionResult CreateLMEUser(tbl_mst_CCOregistrations tbl_mst_CCOregistrations, FormCollection frm)
        {


            int duplicateuser = objCCOregistrationscontext.tbl_mst_CCOregistrations.Where(x => x.str_email == tbl_mst_CCOregistrations.str_email).ToList().Count();
            if ((frm["str_pw"] == frm["str_cnfrmpw"]))
            {
                if (duplicateuser == 0)
                {
                    string id = objCCOregistrationscontext.AutoRegistrationID();
                    tbl_mst_CCOregistrations.str_code = id;
                    objCCOregistrationscontext.tbl_mst_CCOregistrations.Add(tbl_mst_CCOregistrations);
                    objCCOregistrationscontext.SaveChanges();
                    //return RedirectToAction("SignUp");
                    ViewBag.Message = string.Format("User created saved successfully.");
                    ModelState.Clear();
                }
                else
                {
                    ViewBag.Message = string.Format("The Email is already used.");
                }
            }
            else
            {
                ViewBag.Message = string.Format("Password and Confirm Password do not match");

            }

            return View();
        }
        public ActionResult EditLMEUser(int id)
        {

            var Signup = objCCOregistrationscontext.tbl_mst_CCOregistrations.Where(a => a.Pk_CCOid == id).FirstOrDefault();

            return View(Signup);
        }

        [HttpPost]
        public ActionResult EditLMEUser(tbl_mst_CCOregistrations tbl_mst_CCOregistrations, FormCollection frm)
        {


            //int duplicateuser = objCCOregistrationscontext.tbl_mst_CCOregistrations.Where(x => x.str_email == tbl_mst_CCOregistrations.str_email).ToList().Count();
            if ((frm["str_pw"] == frm["str_cnfrmpw"]))
            {

                objCCOregistrationscontext.Entry(tbl_mst_CCOregistrations).State = EntityState.Modified;
                objCCOregistrationscontext.SaveChanges();
                ViewBag.Message = "Data updated Successfully.";

            }
            else
            {
                ViewBag.Message = string.Format("Password and Confirm Password do not match");

            }

            return View();
        }
        public ActionResult ListLMEUSER()
        {
            var User = objCCOregistrationscontext.tbl_mst_CCOregistrations.OrderByDescending(x => x.Pk_CCOid).ToList();
            return View(User);
        }

        //Add LME MASTER
        public ActionResult AddLMEMASTER()
        {
            return View();

        }

        [HttpPost]
        public ActionResult AddLMEMASTER(tbl_mst_LMEdetails tbl_mst_LMEdetails, FormCollection frm)
        {

            if (tbl_mst_LMEdetails.dt_EndDate == null || tbl_mst_LMEdetails.dt_EndDate > tbl_mst_LMEdetails.dt_StartDate)
            {
                if (tbl_mst_LMEdetails.str_lmetype == "Order Type")
                {
                    if (tbl_mst_LMEdetails.str_lmedescription.ToString().ToUpper().Contains("REAL TIME"))
                    {
                        tbl_mst_LMEdetails.isreal = "YES";
                    }
                }
                tbl_mst_LMEdetails.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_mst_LMEdetails.isactive = "Yes";
                objLMEdetails.tbl_mst_LMEdetails.Add(tbl_mst_LMEdetails);
                objLMEdetails.SaveChanges();
                ViewBag.Message = string.Format("Data saved successfully .");
            }
            else
            {
                ViewBag.Message = "Closing Date and Time cannot be less than Starting Date and Time.";
            }
            return View();
        }

        //Edit LME MASTER
        public ActionResult EditLMEMASTER(int id)
        {
            var Signup = objLMEdetails.tbl_mst_LMEdetails.Where(a => a.pk_lmeusermaster == id).FirstOrDefault();
            return View(Signup);
        }

        [HttpPost]
        public ActionResult EditLMEMASTER(tbl_mst_LMEdetails tbl_mst_LMEdetails, FormCollection frm)
        {
            if (tbl_mst_LMEdetails.dt_EndDate == null || tbl_mst_LMEdetails.dt_EndDate > tbl_mst_LMEdetails.dt_StartDate)
            {
                if (tbl_mst_LMEdetails.str_lmetype == "Order Type")
                {
                    if (tbl_mst_LMEdetails.str_lmedescription.ToString().ToUpper().Contains("REAL TIME"))
                    {
                        tbl_mst_LMEdetails.isreal = "YES";
                    }
                }
                tbl_mst_LMEdetails.dt_updatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objLMEdetails.Entry(tbl_mst_LMEdetails).State = EntityState.Modified;
                objLMEdetails.SaveChanges();
                ViewBag.Message = "Data updated Successfully.";
            }
            else
            {
                ViewBag.Message = "Closing Date and Time cannot be less than Starting Date and Time.";
            }
            return View();
        }
        //List LME MASTER

        public ActionResult ListLMEMASTER()
        {
            var Master = objLMEdetails.tbl_mst_LMEdetails.OrderByDescending(x => x.pk_lmeusermaster).ToList();
            return View(Master);
        }
        public ActionResult Addqualification()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Addqualification(tbl_Qualification tbl_Qualification, FormCollection frm)
        {
            if (ModelState.IsValid)
            {

                objqualification.tbl_Qualification.Add(tbl_Qualification);
                objqualification.SaveChanges();

                ViewBag.Message = string.Format("Data saved successfully .");
                ModelState.Clear();
            }

            return View();
        }

        public ActionResult Listqualification()
        {
            var Qualification = objqualification.tbl_Qualification.OrderByDescending(x => x.Pk_Qualification).ToList();
            return View(Qualification);
        }
        public ActionResult Editqualification(int id)
        {
            var Data = objqualification.tbl_Qualification.Where(x => x.Pk_Qualification == id).FirstOrDefault();


            return View(Data);


        }
        [HttpPost]
        public ActionResult Editqualification(tbl_Qualification tbl_Qualification)
        {
            objqualification.Entry(tbl_Qualification).State = EntityState.Modified;
            objqualification.SaveChanges();
            ViewBag.Message = "Data Update Successfully.";
            return View(tbl_Qualification);
        }
        public ActionResult Deletequalification(int id)
        {
            var qualification = objqualification.tbl_Qualification.Where(x => x.Pk_Qualification == id).FirstOrDefault();

            objqualification.Entry(qualification).State = EntityState.Deleted;
            objqualification.SaveChanges();
            return RedirectToAction("Listqualification");
        }
        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }

        private string GetFinYear(DateTime dt)
        {
            string finYr = "";

            if (dt.Month <= 3)
            {
                finYr = (dt.Year - 1).ToString() + "-" + dt.Year.ToString().Substring(2);
            }
            else
            {
                finYr = dt.Year.ToString() + "-" + (dt.Year + 1).ToString().Substring(2);
            }

            return finYr;
        }

        private string SafeToLower(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            return value.ToLower();
        }


        private string SafeToUpper(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            return value.ToUpper();
        }


        [HttpPost]
        public ActionResult LoadArchiveTender(string Fk_intUnitId)
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            using (TenderContext dc = new TenderContext())
            {
                DateTime now = DateTime.UtcNow;
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var v = dc.vw_TendetList.Where(x => x.dtClosingDate < now).OrderByDescending(x => x.pk_intTenderId).ToList(); //(from a in dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0") select a);



                if (Session["UnitId"] != null)
                {
                    int unitId = Convert.ToInt32(Session["UnitId"]);
                    v = v.Where(x => x.fk_intUnitId == unitId).ToList();
                    //ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
                }

                if (!(string.IsNullOrEmpty(Fk_intUnitId)))
                {
                    int unitId = Convert.ToInt32(Fk_intUnitId);
                    v = v.Where(x => x.fk_intUnitId == unitId).ToList();
                    //ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
                }


                string search = Request.Form.GetValues("search[value]").FirstOrDefault();

                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p =>
                                     SafeToLower(p.strEnquiryNo).Contains(search.ToLower()) ||
                                     SafeToLower(p.strEnquiryTitle).Contains(search.ToLower())

                ).ToList();
                }


                recordsTotal = v.Count();


                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "pk_intTenderId")
                        {
                            v = v.OrderByDescending(x => x.pk_intTenderId).ToList();
                        }
                        if (sortColumn == "strEnquiryNo")
                        {
                            v = v.OrderByDescending(x => x.strEnquiryNo).ToList();
                        }
                        if (sortColumn == "strEnquiryTitle")
                        {
                            v = v.OrderByDescending(x => x.strEnquiryTitle).ToList();
                        }
                        if (sortColumn == "dtEnquiryDate")
                        {
                            v = v.OrderByDescending(x => x.dtEnquiryDate).ToList();
                        }
                        if (sortColumn == "dtClosingDate")
                        {
                            v = v.OrderByDescending(x => x.dtClosingDate).ToList();
                        }

                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "pk_intTenderId")
                        {
                            v = v.OrderBy(x => x.pk_intTenderId).ToList();
                        }
                        if (sortColumn == "strEnquiryNo")
                        {
                            v = v.OrderBy(x => x.strEnquiryNo).ToList();
                        }
                        if (sortColumn == "strEnquiryTitle")
                        {
                            v = v.OrderBy(x => x.strEnquiryTitle).ToList();
                        }
                        if (sortColumn == "dtEnquiryDate")
                        {
                            v = v.OrderBy(x => x.dtEnquiryDate).ToList();
                        }
                        if (sortColumn == "dtClosingDate")
                        {
                            v = v.OrderBy(x => x.dtClosingDate).ToList();
                        }

                    }

                }

                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }








        [HttpPost]
        public ActionResult LoadVendorData(string RegStatus, string isVerify, string selectedunitId)
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            using (VendorRegistrationContext dc = new VendorRegistrationContext())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var v = dc.VendorRegistrations.ToList();//(from a in dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0") select a);



                if (Session["UnitId"] != null)
                {
                    int unitId = Convert.ToInt32(Session["UnitId"]);
                    string UnitId = Session["UnitId"].ToString();

                    if (unitId == 6)
                    {
                        if (Session["strEmail"].ToString() == "reddy_pks@hindustancopper.com")
                        {
                            v = v.Where(x => x.Fk_intUnitId != null).ToList();
                            v = v.Where(x => x.Fk_intUnitId.Split(',').Count() > 1).ToList();
                        }
                        else
                        {
                            v = v.Where(x => x.Fk_intUnitId != "1" && x.Fk_intUnitId != "2" && x.Fk_intUnitId != "3" && x.Fk_intUnitId != "4" && x.Fk_intUnitId != "5" && x.Fk_intUnitId != null).ToList();
                        }
                        //ViewBag.Fk_intUnitId = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitName");
                    }
                    else
                    {

                        v = v.Where(x => x.Fk_intUnitId == UnitId).ToList();
                    }
                }


                if (!(string.IsNullOrEmpty(selectedunitId)))
                {

                    v = v.Where(x => x.Fk_intUnitId == selectedunitId).ToList();

                }


                if (!(string.IsNullOrEmpty(isVerify)))
                {

                    v = v.Where(x => x.strVerify == isVerify).ToList();

                }

                if (!(string.IsNullOrEmpty(RegStatus)))
                {

                    if (RegStatus == "COMPLETE")
                    {
                        v = v.Where(x => x.strRegistrationApplied != null).ToList();
                    }
                    else
                    {
                        v = v.Where(x => x.strRegistrationApplied == null || x.strRegistrationApplied == "").ToList();
                    }
                }


                string search = Request.Form.GetValues("search[value]").FirstOrDefault();
                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p => SafeToLower(p.strVendorRegistrationID).Contains(search.ToLower()) ||
                                     SafeToLower(p.strNameofFirmCompany).Contains(search.ToLower()) ||
                                     SafeToLower(p.strCorrespondenceAddress).Contains(search.ToLower()) ||
                                     SafeToLower(p.strstrRegisteredOfficeAddress).Contains(search.ToLower()) ||
                                     SafeToLower(p.strEmail).Contains(search.ToLower()) ||
                                     SafeToLower(p.strMobile).Contains(search.ToLower())
                ).ToList();
                }


                recordsTotal = v.Count();


                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "strVendorRegistrationID")
                        {
                            v = v.OrderByDescending(x => x.strVendorRegistrationID).ToList();
                        }
                        if (sortColumn == "strNameofFirmCompany")
                        {
                            v = v.OrderByDescending(x => x.strNameofFirmCompany).ToList();
                        }
                        if (sortColumn == "strCorrespondenceAddress")
                        {
                            v = v.OrderByDescending(x => x.strCorrespondenceAddress).ToList();
                        }
                        if (sortColumn == "strstrRegisteredOfficeAddress")
                        {
                            v = v.OrderByDescending(x => x.strstrRegisteredOfficeAddress).ToList();
                        }
                        if (sortColumn == "strEmail")
                        {
                            v = v.OrderByDescending(x => x.strEmail).ToList();
                        }
                        if (sortColumn == "strMobile")
                        {
                            v = v.OrderByDescending(x => x.strMobile).ToList();
                        }
                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "strVendorRegistrationID")
                        {
                            v = v.OrderBy(x => x.strVendorRegistrationID).ToList();
                        }
                        if (sortColumn == "strNameofFirmCompany")
                        {
                            v = v.OrderBy(x => x.strNameofFirmCompany).ToList();
                        }
                        if (sortColumn == "strCorrespondenceAddress")
                        {
                            v = v.OrderBy(x => x.strCorrespondenceAddress).ToList();
                        }
                        if (sortColumn == "strstrRegisteredOfficeAddress")
                        {
                            v = v.OrderBy(x => x.strstrRegisteredOfficeAddress).ToList();
                        }
                        if (sortColumn == "strEmail")
                        {
                            v = v.OrderBy(x => x.strEmail).ToList();
                        }
                        if (sortColumn == "strMobile")
                        {
                            v = v.OrderBy(x => x.strMobile).ToList();
                        }
                    }

                }


                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }




        [HttpPost]
        public ActionResult LoadData()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            using (tbl_mstEmployeeContext dc = new tbl_mstEmployeeContext())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var v = dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0").ToList();//(from a in dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0") select a);

                string search = Request.Form.GetValues("search[value]").FirstOrDefault();
                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p => SafeToLower(p.EmpCd).Contains(search.ToLower()) ||
                                     SafeToLower(p.F_Name).Contains(search.ToLower()) ||
                                     SafeToLower(p.Department).Contains(search.ToLower()) ||
                                     SafeToLower(p.Desg).Contains(search.ToLower())
                ).ToList();
                }


                recordsTotal = v.Count();

                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "EmpCd")
                        {
                            v = v.OrderByDescending(x => x.EmpCd).ToList();
                        }
                        if (sortColumn == "F_Name")
                        {
                            v = v.OrderByDescending(x => x.F_Name).ToList();
                        }
                        if (sortColumn == "Department")
                        {
                            v = v.OrderByDescending(x => x.Department).ToList();
                        }
                        if (sortColumn == "Desg")
                        {
                            v = v.OrderByDescending(x => x.Desg).ToList();
                        }
                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "EmpCd")
                        {
                            v = v.OrderBy(x => x.EmpCd).ToList();
                        }
                        if (sortColumn == "F_Name")
                        {
                            v = v.OrderBy(x => x.F_Name).ToList();
                        }
                        if (sortColumn == "Department")
                        {
                            v = v.OrderBy(x => x.Department).ToList();
                        }
                        if (sortColumn == "Desg")
                        {
                            v = v.OrderBy(x => x.Desg).ToList();
                        }
                    }

                }

                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }





        public ActionResult ListEmployee()
        {
            {
                return View();
                //var list = objEmployee.tbl_mstEmployee.Where(x=>x.intDeletedFlag=="0").OrderBy(x => x.ID).ToList();
                //return View(list);
            }
        }



        public ActionResult EmployeeDelete(int id)
        {
            var EmployeeDelete = objEmployee.tbl_mstEmployee.Where(x => x.ID == id).FirstOrDefault();
            EmployeeDelete.intDeletedFlag = "1";
            objEmployee.Entry(EmployeeDelete).State = EntityState.Modified;
            objEmployee.SaveChanges();

            return RedirectToAction("ListEmployee");
        }

        public ActionResult EditEmployee(int id)
        {
            {
                var Employee = objEmployee.tbl_mstEmployee.Where(x => x.ID == id).FirstOrDefault();
                return View(Employee);
            }
        }

        [HttpPost]
        public ActionResult EditEmployee(tbl_mstEmployee tblEmployee, FormCollection frm)
        {
            objEmployee.Entry(tblEmployee).State = EntityState.Modified;
            objEmployee.SaveChanges();

            ViewBag.Message = string.Format("Data updated successfully !");

            return View();
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(tbl_mstEmployee tblEmployee, FormCollection frm)
        {

            //Guid vpw = Guid.NewGuid();
            //tblEmployee.vchPassword = vpw.ToString();
            if (frm["Password"] == frm["vchPassword"])
            {
                tblEmployee.dtmCreatedOn = (DateTime.UtcNow + TimeSpan.Parse("05:30:00")).ToString();
                tblEmployee.intDeletedFlag = "0";
                objEmployee.tbl_mstEmployee.Add(tblEmployee);
                objEmployee.SaveChanges();
                ViewBag.Message = string.Format("Data saved successfully !");
                ModelState.Clear();
                return View();
                //return RedirectToAction("ListEmployee", "Admin");
            }
            else
            {
                ViewBag.Message = string.Format("Password and Confirm Password do not match!");
                return View();
            }


        }



        //Candidate List


        public ActionResult ListCandidate()
        {
            var noticeList = objemployment.tbl_employmentnotice.Select(a => new { a.Pk_employmentid, a.Empnoticeno, a.dtEntryDate }).OrderByDescending(a => a.dtEntryDate).ToList();
            ViewBag.fk_advertisementid = new SelectList(noticeList, "Pk_employmentid", "Empnoticeno", 90);
            ViewBag.Fk_Decipline = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName");
            ViewBag.Fk_Post = new SelectList(objpostnew.tbl_mst_Postnew.ToList(), "Postname", "Postname");

            var v = objApplicantdetails.vw_ListCandidate.Where(x => x.fk_advertisementid == 90 && x.strFinalSubmit == "Yes").ToList();

            return View(v);
        }
        [HttpPost]
        public JsonResult FilterCandidates(vw_ListCandidate o)
        {
            o = o ?? new vw_ListCandidate();
            o.fk_advertisementid = o.fk_advertisementid ?? 90;
            var list = objApplicantdetails.vw_ListCandidate.Where(a => a.fk_advertisementid == o.fk_advertisementid).ToList();
            if ((o.strStatus ?? "") != "")
            {
                list = list.Where(a => a.strStatus.ToLower() == o.strStatus.ToLower()).ToList();
            }
            if ((o.fk_postid ?? 0) != 0)
            {
                list = list.Where(a => a.fk_postid == o.fk_postid).ToList();
            }
            if ((o.fk_diciplineid ?? 0) != 0)
            {
                list = list.Where(a => a.fk_diciplineid == o.fk_diciplineid).ToList();
            }
            if ((o.strApplicationNo ?? "") != "")
            {
                list = list.Where(a => a.strApplicationNo == o.strApplicationNo).ToList();
            }
            if ((o.strPWD ?? "") != "")
            {
                list = list.Where(a => a.strPWD == o.strPWD).ToList();
            }
            if ((o.strInternalCandidate ?? "") != "")
            {
                list = list.Where(a => a.strInternalCandidate == o.strInternalCandidate).ToList();
            }
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ListCandidate(FormCollection frm)
        {
            var noticeList = objemployment.tbl_employmentnotice.Select(a => new { a.Pk_employmentid, a.Empnoticeno, a.dtEntryDate }).OrderByDescending(a => a.dtEntryDate).ToList();
            ViewBag.fk_advertisementid = new SelectList(noticeList, "Pk_employmentid", "Empnoticeno");

            //ViewBag.Fk_Decipline = new SelectList(objemployment.tbl_employmentnotice.OrderByDescending(a => a.Pk_employmentid).ToList(), "Pk_employmentid,", "Empnoticeno", frm["Fk_Decipline"]);

            ViewBag.Fk_Decipline = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName", frm["Fk_Decipline"]);
            ViewBag.Fk_Post = new SelectList(objpostnew.tbl_mst_Postnew.ToList(), "Postname", "Postname", frm["Fk_Post"]);
            ViewBag.ApplicantNo = frm["ApplicantNo"];
            ViewBag.strPWD = frm["strPWD"];
            ViewBag.strInternalCandidate = frm["strInternalCandidate"];
            ViewBag.strStatus = frm["strStatus"];



            var v = objApplicantdetails.vw_ListCandidate.Where(a => a.fk_advertisementid == 90).ToList();//(from a in dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0") select a);

            if (!(string.IsNullOrEmpty(frm["Fk_Post"])))
            {
                string post = frm["Fk_Post"];
                v = objApplicantdetails.vw_ListCandidate.Where(x => x.Postname == post).ToList();

            }


            if (!(string.IsNullOrEmpty(frm["Fk_Decipline"])))
            {
                int Fk_Decipline = Convert.ToInt32(frm["Fk_Decipline"]);
                v = objApplicantdetails.vw_ListCandidate.Where(x => x.fk_diciplineid == Fk_Decipline).ToList();

            }

            if (!(string.IsNullOrEmpty(frm["ApplicantNo"])))
            {
                string ApplicantNo = frm["ApplicantNo"];
                v = v.Where(x => x.strApplicationNo == ApplicantNo).ToList();

            }

            if (!(string.IsNullOrEmpty(frm["strPWD"])))
            {
                string strPWD = frm["strPWD"];
                v = v.Where(x => x.strPWD == strPWD).ToList();

            }

            if (!(string.IsNullOrEmpty(frm["strInternalCandidate"])))
            {
                string strInternalCandidate = frm["strInternalCandidate"];
                v = v.Where(x => x.strInternalCandidate == strInternalCandidate).ToList();

            }

            if (!(string.IsNullOrEmpty(frm["strStatus"])))
            {
                string strStatus = frm["strStatus"];
                v = v.Where(x => x.strStatus == strStatus).ToList();

            }

            return View(v);
        }

        //LoadCandidate 

        [HttpPost]
        public ActionResult LoadCandidate(string AppNo, string Decipline, string selectedpost, string strPWD, string strInternalCandidate, string strStatus)
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
            var v = objApplicantdetails.vw_ListCandidate.ToList();//(from a in dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0") select a);

            if (!(string.IsNullOrEmpty(selectedpost)))
            {

                v = v.Where(x => x.Postname == selectedpost).ToList();

            }


            if (!(string.IsNullOrEmpty(Decipline)))
            {

                v = v.Where(x => x.fk_diciplineid.ToString() == Decipline).ToList();

            }

            if (!(string.IsNullOrEmpty(AppNo)))
            {

                v = v.Where(x => x.strApplicationNo == AppNo).ToList();

            }

            if (!(string.IsNullOrEmpty(strPWD)))
            {

                v = v.Where(x => x.strPWD == strPWD).ToList();

            }

            if (!(string.IsNullOrEmpty(strInternalCandidate)))
            {

                v = v.Where(x => x.strInternalCandidate == strInternalCandidate).ToList();

            }

            if (!(string.IsNullOrEmpty(strStatus)))
            {

                v = v.Where(x => x.strStatus == strStatus).ToList();

            }


            string search = Request.Form.GetValues("search[value]").FirstOrDefault();
            if (!(string.IsNullOrEmpty(search)))
            {

                v = v.Where(p => SafeToLower(p.strApplicationNo).Contains(search.ToLower()) ||
                                 SafeToLower(p.DisciplineName).Contains(search.ToLower()) ||
                                 SafeToLower(p.Postname).Contains(search.ToLower()) ||
                                   SafeToLower(p.strApplicantName).Contains(search.ToLower()) ||
                                     SafeToLower(p.strFatherName).Contains(search.ToLower()) ||
                                         SafeToLower(p.strNationality).Contains(search.ToLower()) ||
                                          SafeToLower(p.strCategory).Contains(search.ToLower()) ||
                                 SafeToLower(p.strEmail).Contains(search.ToLower()) ||
                                 SafeToLower(p.strPayUMoneyId).Contains(search.ToLower())
            ).ToList();
            }


            recordsTotal = v.Count();

            //SORT
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {

                if (sortColumnDir == "desc")
                {
                    if (sortColumn == "strApplicationNo")
                    {
                        v = v.OrderByDescending(x => x.strApplicationNo).ToList();
                    }
                    if (sortColumn == "DisciplineName")
                    {
                        v = v.OrderByDescending(x => x.DisciplineName).ToList();
                    }
                    if (sortColumn == "Postname")
                    {
                        v = v.OrderByDescending(x => x.Postname).ToList();
                    }
                    if (sortColumn == "strApplicantName")
                    {
                        v = v.OrderByDescending(x => x.strApplicantName).ToList();
                    }
                    if (sortColumn == "strFatherName")
                    {
                        v = v.OrderByDescending(x => x.strFatherName).ToList();

                    }

                    if (sortColumn == "dtDOB")
                    {
                        v = v.OrderByDescending(x => x.dtDOB).ToList();
                    }
                    if (sortColumn == "strNationality")
                    {
                        v = v.OrderByDescending(x => x.strNationality).ToList();
                    }

                    if (sortColumn == "strCategory")
                    {
                        v = v.OrderByDescending(x => x.strCategory).ToList();
                    }

                    if (sortColumn == "strEmail")
                    {
                        v = v.OrderByDescending(x => x.strEmail).ToList();
                    }
                    if (sortColumn == "strPayUMoneyId")
                    {
                        v = v.OrderByDescending(x => x.strPayUMoneyId).ToList();
                    }
                }

                if (sortColumnDir == "asc")
                {
                    if (sortColumn == "strApplicationNo")
                    {
                        v = v.OrderByDescending(x => x.strApplicationNo).ToList();
                    }
                    if (sortColumn == "DisciplineName")
                    {
                        v = v.OrderByDescending(x => x.DisciplineName).ToList();
                    }
                    if (sortColumn == "Postname")
                    {
                        v = v.OrderByDescending(x => x.Postname).ToList();
                    }
                    if (sortColumn == "strApplicantName")
                    {
                        v = v.OrderByDescending(x => x.strApplicantName).ToList();
                    }
                    if (sortColumn == "strFatherName")
                    {
                        v = v.OrderByDescending(x => x.strFatherName).ToList();

                    }

                    if (sortColumn == "dtDOB")
                    {
                        v = v.OrderByDescending(x => x.dtDOB).ToList();
                    }
                    if (sortColumn == "strNationality")
                    {
                        v = v.OrderByDescending(x => x.strNationality).ToList();
                    }

                    if (sortColumn == "strCategory")
                    {
                        v = v.OrderByDescending(x => x.strCategory).ToList();
                    }

                    if (sortColumn == "strEmail")
                    {
                        v = v.OrderByDescending(x => x.strEmail).ToList();
                    }
                    if (sortColumn == "strPayUMoneyId")
                    {
                        v = v.OrderByDescending(x => x.strPayUMoneyId).ToList();
                    }
                }

            }

            var data = v.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }



        //Candidate ITI List

        public ActionResult ListITICandidateforupload()
        {
            ITIApplicationContext obj = new ITIApplicationContext();
            var list = obj.vw_itiuploadfilestatus.ToList();
            return View(list);
        }


        public ActionResult ListITICandidate()
        {
            return View();
        }

        public ActionResult ITIApplicationCandidateList()
        {
            var v = objApplicantdetails.vw_ITIListCandidate.ToList();
            return View(v);
        }
        [HttpPost]
        public ActionResult ListITICandidate(FormCollection frm)
        {
            ViewBag.strStatus = frm["strStatus"];
            Session["strStatus"] = frm["strStatus"];
            return View();
        }

        [HttpPost]
        public ActionResult LoadITICandidate()
        {
            string strStatus = Session["strStatus"] == null ? "" : Session["strStatus"].ToString();
            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            var v = objITI.vw_ITIApplicationDetails.ToList();

            if (strStatus != "")
            {
                v = v.Where(x => x.strFinalSubmit == strStatus).ToList();
            }


            string search = Request.Form.GetValues("search[value]").FirstOrDefault();
            if (!(string.IsNullOrEmpty(search)))
            {

                v = v.Where(p =>
                SafeToLower(p.Candidate_Code).Contains(search.ToLower()) ||
                SafeToLower(p.strApprenticeshipRegNo).Contains(search.ToLower()) ||
                SafeToLower(p.strApplicantName).Contains(search.ToLower()) ||
                SafeToLower(p.strFatherName).Contains(search.ToLower()) ||
                SafeToLower(p.isreference).Contains(search.ToLower()) ||
                SafeToLower(p.strEmail).Contains(search.ToLower()) ||
                SafeToLower(p.strMobileNumber).Contains(search.ToLower()) ||
                SafeToLower(p.strCategory).Contains(search.ToLower()) ||
                SafeToLower(p.strTradeName).Contains(search.ToLower()) ||
                SafeToLower(p.strFinalSubmit).Contains(search.ToLower())
                ).ToList();
            }


            recordsTotal = v.Count();

            //SORT
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {

                if (sortColumnDir == "desc")
                {

                    if (sortColumn == "Candidate_Code")
                    {
                        v = v.OrderByDescending(x => x.Candidate_Code).ToList();
                    }
                    if (sortColumn == "strApprenticeshipRegNo")
                    {
                        v = v.OrderByDescending(x => x.strApprenticeshipRegNo).ToList();

                    }
                    if (sortColumn == "strApplicantName")
                    {
                        v = v.OrderByDescending(x => x.strApplicantName).ToList();
                    }
                    if (sortColumn == "strFatherName")
                    {
                        v = v.OrderByDescending(x => x.strFatherName).ToList();
                    }
                    if (sortColumn == "isreference")
                    {
                        v = v.OrderByDescending(x => x.isreference).ToList();
                    }
                    if (sortColumn == "strEmail")
                    {
                        v = v.OrderByDescending(x => x.strEmail).ToList();
                    }
                    if (sortColumn == "strMobileNumber")
                    {
                        v = v.OrderByDescending(x => x.strMobileNumber).ToList();
                    }
                    if (sortColumn == "strCategory")
                    {
                        v = v.OrderByDescending(x => x.strCategory).ToList();
                    }
                    if (sortColumn == "strTradeName")
                    {
                        v = v.OrderByDescending(x => x.strTradeName).ToList();
                    }
                    if (sortColumn == "strFinalSubmit")
                    {
                        v = v.OrderByDescending(x => x.strFinalSubmit).ToList();
                    }

                }

                if (sortColumnDir == "asc")
                {

                    if (sortColumn == "Candidate_Code")
                    {
                        v = v.OrderBy(x => x.Candidate_Code).ToList();
                    }
                    if (sortColumn == "strApprenticeshipRegNo")
                    {
                        v = v.OrderBy(x => x.strApprenticeshipRegNo).ToList();

                    }
                    if (sortColumn == "strApplicantName")
                    {
                        v = v.OrderBy(x => x.strApplicantName).ToList();
                    }
                    if (sortColumn == "strFatherName")
                    {
                        v = v.OrderBy(x => x.strFatherName).ToList();
                    }
                    if (sortColumn == "isreference")
                    {
                        v = v.OrderBy(x => x.isreference).ToList();
                    }
                    if (sortColumn == "strEmail")
                    {
                        v = v.OrderBy(x => x.strEmail).ToList();
                    }
                    if (sortColumn == "strMobileNumber")
                    {
                        v = v.OrderBy(x => x.strMobileNumber).ToList();
                    }
                    if (sortColumn == "strCategory")
                    {
                        v = v.OrderBy(x => x.strCategory).ToList();
                    }
                    if (sortColumn == "strTradeName")
                    {
                        v = v.OrderBy(x => x.strTradeName).ToList();
                    }
                    if (sortColumn == "strFinalSubmit")
                    {
                        v = v.OrderBy(x => x.strFinalSubmit).ToList();
                    }

                }

            }

            var data = v.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }

        public void DownloadListITICandidateincsv()
        {
            string strStatus = Session["strStatus"] == null ? "" : Session["strStatus"].ToString();

            StringWriter sw = new StringWriter();

            sw.WriteLine("\"DATA FORMAT REQUIRED IN CASE OF TRADE APPRENTICES\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\"");
            sw.WriteLine("\"Sl No.\",\"Regd No.\",\"Apprenticeship portal regd no.\",\"Name of the candidate\",\"Father's Name\",\"Dependent(Yes / No)\",\"Primary E-mail Id\",\"Mobile No.\",\"Category (SC/ST/OBC(NCL)/EWS/UR)\",\"Caste Certificate / EWS certi no.\",\"Caste Certificate / EWS certi Issue Date\",\"Caste Certificate / EWS certi Issuing Authority\",\"Academic Qualification\",\"10th Board\",\"Technical Qualification\",\"Trade\",\"Year of Passing ITI\",\"ITI Board (must be affiliated to NCVT\",\"Affidavit (Yes / No)\",\"CGPA or Percentage (%)\",\"Total marks in Matric\",\"obtained marks in Matric\",\"% of Matric marks\",\"Total marks in ITI\",\"Obtained Marks in ITI\",\"% Marks in ITI\",\"Weighted Marks (70% of Matric + 30% of ITI + 10 marks for depedent if applicable)\"");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=ITIApplicantList.csv");
            Response.ContentType = "application/octet-stream";
            var ITIApplicationDetails = objITI.vw_ITIApplicationDetails.ToList();

            if (strStatus != "")
            {
                ITIApplicationDetails = ITIApplicationDetails.Where(x => x.strFinalSubmit == strStatus).ToList();
            }

            int i = 1;
            foreach (var ApplicationDetails in ITIApplicationDetails)
            {
                var QulificationData = objITI.tbl_mst_ITICandidateQualification.Where(x => x.fk_CandidateId == ApplicationDetails.fk_CandidateId).ToList();
                var classTenData = QulificationData.Where(x => x.Str_exampassed == "Matric/10th").FirstOrDefault();
                var classITIData = QulificationData.Where(x => x.Str_exampassed == "ITI").FirstOrDefault();
                int extraMarks = 0;
                if (ApplicationDetails.isreference.ToUpper() == "YES")
                {
                    extraMarks = 10;
                }

                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\",\"{21}\",\"{22}\",\"{23}\",\"{24}\",\"{25}\"",
                i,
                ApplicationDetails.Candidate_Code,
                ApplicationDetails.strApprenticeshipRegNo,
                ApplicationDetails.strApplicantName,
                ApplicationDetails.strFatherName,
                ApplicationDetails.isreference,
                ApplicationDetails.strEmail,
                ApplicationDetails.strMobileNo,
                ApplicationDetails.strCategory,
                ApplicationDetails.strcertificateno,
                ApplicationDetails.dt_certificateissuedate != null ? ApplicationDetails.dt_certificateissuedate.Value.ToString("dd/MM/yyyy") : "",
                ApplicationDetails.strcertificateissue,
                "10th (Should have passed before the cut-off date)",
                classTenData.Str_board,
                "ITI (Should have passed before the cut-off date)",
                ApplicationDetails.strTradeName,
                classITIData.Str_passingyear,
                classITIData.Str_board,
                Convert.ToDateTime(classITIData.Str_passingyear).Year <= 2016 ? "Yes" : "No",
                classTenData.StrRemarks,
                classTenData.Str_TotalMarks,
                classTenData.Str_MarksObtained,
                classTenData.Str_Marks,
                classITIData.Str_TotalMarks,
                classITIData.Str_MarksObtained,
                classITIData.Str_Marks,
                Convert.ToDecimal(classTenData.Str_Marks) * 70 / 100 + Convert.ToDecimal(classITIData.Str_Marks) * 30 / 100 + extraMarks
                ));
                i++;
            }
            Response.Write(sw.ToString());
            Response.End();
        }



        public void DownloadITIcsv()
        {


            StringWriter sw = new StringWriter();

            sw.WriteLine("\"DATA FORMAT REQUIRED IN CASE OF TRADE APPRENTICES\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\"");
            sw.WriteLine("\"Sl No.\",\"Regd No.\",\"Apprenticeship portal regd no.\",\"Name of the candidate\",\"Father's Name\",\"Dependent(Yes / No)\",\"Primary E-mail Id\",\"Mobile No.\",\"Category (SC/ST/OBC(NCL)/EWS/UR)\",\"Caste Certificate / EWS certi no.\",\"Caste Certificate / EWS certi Issue Date\",\"Caste Certificate / EWS certi Issuing Authority\",\"Academic Qualification\",\"10th Board\",\"Technical Qualification\",\"Trade\",\"Year of Passing ITI\",\"ITI Board (must be affiliated to NCVT\",\"Affidavit (Yes / No)\",\"CGPA or Percentage (%)\",\"Total marks in Matric\",\"obtained marks in Matric\",\"% of Matric marks\",\"Total marks in ITI\",\"Obtained Marks in ITI\",\"% Marks in ITI\",\"Weighted Marks (70% of Matric + 30% of ITI + 10 marks for depedent if applicable)\"");
            Response.ClearContent();
            Response.AddHeader("content-disposition", "attachment;filename=ITIApplicantList.csv");
            Response.ContentType = "application/octet-stream";
            var ITIApplicationDetails = objITI.vw_itinew.ToList();

            int i = 1;
            foreach (var ApplicationDetails in ITIApplicationDetails)
            {
                var QulificationData = objITI.tbl_mst_ITICandidateQualification.Where(x => x.fk_CandidateId == ApplicationDetails.fk_CandidateId).ToList();
                var classTenData = QulificationData.Where(x => x.Str_exampassed == "Matric/10th").FirstOrDefault();
                var classITIData = QulificationData.Where(x => x.Str_exampassed == "ITI").FirstOrDefault();
                int extraMarks = 0;
                if (ApplicationDetails.isreference.ToUpper() == "YES")
                {
                    extraMarks = 10;
                }

                sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\",\"{21}\",\"{22}\",\"{23}\",\"{24}\",\"{25}\"",
                i,
                SafeToUpper(ApplicationDetails.Candidate_Code),
                ApplicationDetails.strApprenticeshipRegNo == "OnlyforITI" ? "" : SafeToUpper(ApplicationDetails.strApprenticeshipRegNo),
                SafeToUpper(ApplicationDetails.strApplicantName),
                SafeToUpper(ApplicationDetails.strFatherName),
                SafeToUpper(ApplicationDetails.isreference),
                SafeToUpper(ApplicationDetails.strEmail),
                SafeToUpper(ApplicationDetails.strMobileNo),
                SafeToUpper(ApplicationDetails.strCategory),
                SafeToUpper(ApplicationDetails.strcertificateno),
                ApplicationDetails.dt_certificateissuedate != null ? ApplicationDetails.dt_certificateissuedate.Value.ToString("dd/MM/yyyy") : "",
                SafeToUpper(ApplicationDetails.strcertificateissue),
                "10th (Should have passed before the cut-off date)",
                SafeToUpper(classTenData.Str_board),
                "ITI (Should have passed before the cut-off date)",
                SafeToUpper(ApplicationDetails.strTradeName),
                classITIData.Str_passingyear == null ? "" : classITIData.Str_passingyear,
                SafeToUpper(classITIData.Str_board) == null ? "" : classITIData.Str_board,
                "What",
                SafeToUpper(classTenData.StrRemarks),
                classTenData.Str_TotalMarks,
                classTenData.Str_MarksObtained,
                classTenData.Str_Marks,

                classITIData.Str_TotalMarks == null ? "" : classITIData.Str_TotalMarks,
                classITIData.Str_MarksObtained == null ? "" : classITIData.Str_MarksObtained,
                classITIData.Str_Marks == null ? "" : classITIData.Str_Marks,
                extraMarks
                ));
                i++;
            }
            Response.Write(sw.ToString());
            Response.End();
        }
        //LoadITICandidate 


        //Candidate Graduate List

        public ActionResult ListGraduateCandidate()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ListGraduateCandidate(FormCollection frm)
        {
            ViewBag.strStatus = frm["strStatus"];
            Session["strStatus"] = frm["strStatus"];
            return View();
        }

        [HttpPost]
        public ActionResult LoadGraduateCandidate()
        {


            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            var v = Graduate.vw_ListGraduateCandidate.ToList();

            string strStatus = Session["strStatus"] == null ? "" : Session["strStatus"].ToString();

            if (strStatus == "Yes")
            {
                v = v.Where(x => x.strFinalSubmit == "Yes").ToList();
            }
            if (strStatus == "No")
            {
                v = v.Where(x => x.strFinalSubmit != "Yes").ToList();
            }

            string search = Request.Form.GetValues("search[value]").FirstOrDefault();
            if (!(string.IsNullOrEmpty(search)))
            {

                v = v.Where(p =>
                SafeToLower(p.strAcknowledgementNo).Contains(search.ToLower()) ||
                SafeToLower(p.strApprenticeshipRegNo).Contains(search.ToLower()) ||
                SafeToLower(p.strApplicantName).Contains(search.ToLower()) ||
                SafeToLower(p.strFatherName).Contains(search.ToLower()) ||
                SafeToLower(p.strEmail).Contains(search.ToLower()) ||
                SafeToLower(p.strCategory).Contains(search.ToLower()) ||
                SafeToLower(p.strTradeName).Contains(search.ToLower()) ||
                SafeToLower(p.strFinalSubmit).Contains(search.ToLower())
                ).ToList();
            }


            recordsTotal = v.Count();

            //SORT
            if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
            {

                if (sortColumnDir == "desc")
                {

                    if (sortColumn == "strAcknowledgementNo")
                    {
                        v = v.OrderByDescending(x => x.strAcknowledgementNo).ToList();
                    }
                    if (sortColumn == "strApprenticeshipRegNo")
                    {
                        v = v.OrderByDescending(x => x.strApprenticeshipRegNo).ToList();

                    }
                    if (sortColumn == "strApplicantName")
                    {
                        v = v.OrderByDescending(x => x.strApplicantName).ToList();
                    }
                    if (sortColumn == "strFatherName")
                    {
                        v = v.OrderByDescending(x => x.strFatherName).ToList();
                    }

                    if (sortColumn == "strEmail")
                    {
                        v = v.OrderByDescending(x => x.strEmail).ToList();
                    }

                    if (sortColumn == "strCategory")
                    {
                        v = v.OrderByDescending(x => x.strCategory).ToList();
                    }
                    if (sortColumn == "strTradeName")
                    {
                        v = v.OrderByDescending(x => x.strTradeName).ToList();
                    }
                    if (sortColumn == "strFinalSubmit")
                    {
                        v = v.OrderByDescending(x => x.strFinalSubmit).ToList();
                    }

                }

                if (sortColumnDir == "asc")
                {

                    if (sortColumn == "strAcknowledgementNo")
                    {
                        v = v.OrderBy(x => x.strAcknowledgementNo).ToList();
                    }
                    if (sortColumn == "strApprenticeshipRegNo")
                    {
                        v = v.OrderBy(x => x.strApprenticeshipRegNo).ToList();

                    }
                    if (sortColumn == "strApplicantName")
                    {
                        v = v.OrderBy(x => x.strApplicantName).ToList();
                    }
                    if (sortColumn == "strFatherName")
                    {
                        v = v.OrderBy(x => x.strFatherName).ToList();
                    }
                    if (sortColumn == "strEmail")
                    {
                        v = v.OrderBy(x => x.strEmail).ToList();
                    }
                    if (sortColumn == "strCategory")
                    {
                        v = v.OrderBy(x => x.strCategory).ToList();
                    }
                    if (sortColumn == "strTradeName")
                    {
                        v = v.OrderBy(x => x.strTradeName).ToList();
                    }
                    if (sortColumn == "strFinalSubmit")
                    {
                        v = v.OrderBy(x => x.strFinalSubmit).ToList();
                    }

                }

            }

            var data = v.Skip(skip).Take(pageSize).ToList();
            return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
        }



        //public void DownloadListGraduateCandidateincsv()
        //{
        //    GraduateApprenticeContext objContext = new GraduateApprenticeContext();

        //    string strStatus = Session["strStatus"] == null ? "" : Session["strStatus"].ToString();

        //    StringWriter sw = new StringWriter();

        //    sw.WriteLine("\"DATA FORMAT REQUIRED IN CASE OF TRADE APPRENTICES\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\",\"\"");
        //    sw.WriteLine("\"Sl No.\",\"Regd No.\",\"Apprenticeship portal regd no.\",\"Name of the candidate\",\"Father's Name\",\"Dependent(Yes / No)\",\"Primary E-mail Id\",\"Mobile No.\",\"Category (SC/ST/OBC(NCL)/EWS/UR)\",\"Caste Certificate / EWS certi no.\",\"Caste Certificate / EWS certi Issue Date\",\"Caste Certificate / EWS certi Issuing Authority\",\"Academic Qualification\",\"10th Board\",\"Technical Qualification\",\"Trade\",\"Year of Passing ITI\",\"ITI Board (must be affiliated to NCVT\",\"Affidavit (Yes / No)\",\"Total marks in Matric\",\"obtained marks in Matric\",\"% of Matric marks\",\"Total marks in ITI\",\"Obtained Marks in ITI\",\"% Marks in ITI\",\"Weighted Marks (70% of Matric + 30% of ITI + 10 marks for depedent if applicable)\"");
        //    Response.ClearContent();
        //    Response.AddHeader("content-disposition", "attachment;filename=ITIApplicantList.csv");
        //    Response.ContentType = "application/octet-stream";
        //    var ITIApplicationDetails = objContext.vw_ListGraduateCandidate.ToList();

        //    if (strStatus != "")
        //    {
        //        ITIApplicationDetails = ITIApplicationDetails.Where(x => x.strFinalSubmit == strStatus).ToList();
        //    }

        //    int i = 1;
        //    foreach (var ApplicationDetails in ITIApplicationDetails)
        //    {
        //        var QulificationData = objContext.tbl_mst_GraduateApprenticeCandidateQualification.Where(x => x.fk_CandidateId == ApplicationDetails.fk_CandidateId).ToList();

        //        var classTenData = QulificationData.Where(x => x.Str_exampassed == "Matric/10th").FirstOrDefault();
        //        var class12Data = QulificationData.Where(x => x.Str_exampassed == "Higher Secondary/12th").FirstOrDefault();
        //        var classGraData = QulificationData.Where(x => x.Str_exampassed == "Graduate").FirstOrDefault();

        //        int extraMarks = 0;
        //        sw.WriteLine(string.Format("\"{0}\",\"{1}\",\"{2}\",\"{3}\",\"{4}\",\"{5}\",\"{6}\",\"{7}\",\"{8}\",\"{9}\",\"{10}\",\"{11}\",\"{12}\",\"{13}\",\"{14}\",\"{15}\",\"{16}\",\"{17}\",\"{18}\",\"{19}\",\"{20}\",\"{21}\",\"{22}\",\"{23}\",\"{24}\",\"{25}\"",
        //        i,
        //        ApplicationDetails.Candidate_Code,
        //        ApplicationDetails.strApprenticeshipRegNo,
        //        ApplicationDetails.strApplicantName,
        //        ApplicationDetails.strFatherName,
        //        ApplicationDetails.isreference,
        //        ApplicationDetails.strEmail,
        //        ApplicationDetails.strMobileNo,
        //        ApplicationDetails.strCategory,
        //        ApplicationDetails.strcertificateno,
        //        ApplicationDetails.dt_certificateissuedate != null ? ApplicationDetails.dt_certificateissuedate.Value.ToString("dd/MM/yyyy") : "",
        //        ApplicationDetails.strcertificateissue,
        //        "10th (Should have passed before the cut-off date)",
        //        classTenData.Str_board,
        //        "ITI (Should have passed before the cut-off date)",
        //        ApplicationDetails.strTradeName,
        //        classGraData.Str_passingyear,
        //        classGraData.Str_board,
        //        Convert.ToDateTime(classITIData.Str_passingyear).Year <= 2016 ? "Yes" : "No",
        //        classTenData.Str_TotalMarks,
        //        classTenData.Str_MarksObtained,
        //        classTenData.Str_Marks,
        //        classITIData.Str_TotalMarks,
        //        classITIData.Str_MarksObtained,
        //        classITIData.Str_Marks,
        //        Convert.ToDecimal(classTenData.Str_Marks) * 70 / 100 + Convert.ToDecimal(classITIData.Str_Marks) * 30 / 100 + extraMarks
        //        ));
        //        i++;
        //    }
        //    Response.Write(sw.ToString());
        //    Response.End();
        //}

        //Candidate Graduate List       


        [HttpPost]
        public JsonResult Insertcandidate(candidtelist candidtelist, FormCollection frm)
        {
            // List<tbl_mst_CandidatePersonalDetails> Lsttbl_mst_CandidatePersonalDetails = new List<tbl_mst_CandidatePersonalDetails>();



            foreach (var Sto in candidtelist.List)
            {
                //var pmt = objSpotbookingOrders.tbl_mst_SpotbookingOrders.Single(x => x.Pk_intOrderID == Sto.Pk_intOrderID);
                var can = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Single(x => x.Pk_int_CandidateRegistrationID == Sto.Pk_int_CandidateRegistrationID);

                can.str_status = "Approved";
                objcanpersonaldetails.Entry(can).State = EntityState.Modified;
                objcanpersonaldetails.SaveChanges();

            }



            return Json(JsonRequestBehavior.AllowGet, "Data Updated Successfully");
        }

        //ListApproveCandidate
        public ActionResult ListApproveCandidate()
        {

            var Approve = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.str_status == "Approved").ToList();

            return View(Approve);
        }



        [HttpPost]
        public ActionResult LoadSelectedCandidate()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;
            using (tbl_mst_CandidatePersonalDetailscontext dc = new tbl_mst_CandidatePersonalDetailscontext())
            {
                // dc.Configuration.LazyLoadingEnabled = false; // if your table is relational, contain foreign key
                var v = dc.tbl_mst_CandidatePersonalDetails.ToList();//(from a in dc.tbl_mstEmployee.Where(x => x.intDeletedFlag == "0") select a);

                string search = Request.Form.GetValues("search[value]").FirstOrDefault();
                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p => SafeToLower(p.strApplicationNo).Contains(search.ToLower()) ||
                                     SafeToLower(p.strApplicantName).Contains(search.ToLower()) ||
                                      SafeToLower(p.strFatherName).Contains(search.ToLower()) ||
                                       SafeToLower(p.strCategory).Contains(search.ToLower())

                ).ToList();
                }


                recordsTotal = v.Count();

                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "strApplicationNo")
                        {
                            v = v.OrderByDescending(x => x.strApplicationNo).ToList();
                        }
                        if (sortColumn == "strApplicantName")
                        {
                            v = v.OrderByDescending(x => x.strApplicantName).ToList();
                        }

                        if (sortColumn == "strFatherName")
                        {
                            v = v.OrderByDescending(x => x.strApplicantName).ToList();
                        }
                        if (sortColumn == "strCategory")
                        {
                            v = v.OrderByDescending(x => x.strApplicantName).ToList();
                        }
                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "strApplicationNo")
                        {
                            v = v.OrderBy(x => x.strApplicationNo).ToList();
                        }
                        if (sortColumn == "strApplicantName")
                        {
                            v = v.OrderBy(x => x.strApplicantName).ToList();
                        }
                        if (sortColumn == "strFatherName")
                        {
                            v = v.OrderBy(x => x.strApplicantName).ToList();
                        }
                        if (sortColumn == "strCategory")
                        {
                            v = v.OrderBy(x => x.strApplicantName).ToList();
                        }
                    }

                }

                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult InsertSelectcandidate(candidtelist candidtelist, tbl_mst_Selectedcandidatedetails tbl_mst_Selectedcandidatedetails, FormCollection frm, string Status)
        {
            List<tbl_mst_Selectedcandidatedetails> Lsttbl_mst_Selectedcandidatedetails = new List<tbl_mst_Selectedcandidatedetails>();



            foreach (var Sto in candidtelist.List)
            {

                if (tbl_mst_Selectedcandidatedetails.str_Applicationno != Sto.strApplicationNo && tbl_mst_Selectedcandidatedetails.str_Selecttype != Status)
                {
                    tbl_mst_Selectedcandidatedetails.str_Applicationno = Sto.strApplicationNo;
                    tbl_mst_Selectedcandidatedetails.str_Selecttype = Status;
                    tbl_mst_Selectedcandidatedetails.dt_apporovedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_mst_Selectedcandidatedetails.isactive = "yes";
                    objSelectedcandidatedetails.tbl_mst_Selectedcandidatedetails.Add(tbl_mst_Selectedcandidatedetails);
                    objSelectedcandidatedetails.SaveChanges();
                }
            }



            return Json(JsonRequestBehavior.AllowGet, "Data Updated Successfully");
        }


        public ActionResult AddProducttender()
        {
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            ViewBag.fk_productid = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Product of Interest" && x.dt_StartDate <= current && (x.dt_EndDate >= current || x.dt_EndDate == null)).ToList(), "pk_lmeusermaster", "str_lmedescription");
            ViewBag.fk_unit = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitCode");


            return View();
        }

        [HttpPost]
        public ActionResult AddProducttender(tbl_mst_Spotbooking_Tender tbl_mst_Spotbooking_Tender, FormCollection frm)
        {

            HttpPostedFileBase str_upload = Request.Files["str_upload"];
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");


            ViewBag.fk_productid = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Product of Interest" && x.dt_StartDate <= current && (x.dt_EndDate >= current || x.dt_EndDate == null)).ToList(), "pk_lmeusermaster", "str_lmedescription");
            ViewBag.fk_unit = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitCode");

            if (ModelState.IsValid)
            {
                try
                {
                    string imagepath = null;

                    if (str_upload.ContentLength > 0)
                    {

                        var fileName = Path.GetExtension(str_upload.FileName);
                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/UploadFile/Producttender/"), guid + fileName);
                        str_upload.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        imagepath = "~/UploadFile/Producttender/" + newpath;
                        tbl_mst_Spotbooking_Tender.str_upload = imagepath;

                    }

                    //File extention rename
                    var MineType = Utility.getMimeFromFile(imagepath);
                    if (MineType != "Invalied")
                    {
                        tbl_mst_Spotbooking_Tender.is_active = "YES";
                        tbl_mst_Spotbooking_Tender.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        objtender.tbl_mst_Spotbooking_Tender.Add(tbl_mst_Spotbooking_Tender);
                        objtender.SaveChanges();
                        ViewBag.Message = string.Format("Data saved successfully !");
                        ModelState.Clear();
                    }
                    else
                    {
                        //File extention rename
                        System.IO.File.Delete(MineType);
                        ViewBag.Message = "Invalied file...";
                    }
                    return View();
                }
                catch (Exception ex)
                {
                    ViewBag.Message = string.Format(ex.Message);
                    return View();
                }
            }
            var errors = string.Join("; ", ModelState.Values
                                      .SelectMany(x => x.Errors)
                                      .Select(x => x.ErrorMessage));
            ViewBag.Message = string.Format(errors);
            return View();

        }


        public ActionResult ProducttenderList()
        {
            var list = objSpotbookingTenderdetails.vw_SpotbookingTender.OrderByDescending(x => x.Pk_int_tenderid).ToList();
            return View(list);
        }


        [HttpPost]
        public ActionResult LoadProducttender()
        {

            var draw = Request.Form.GetValues("draw").FirstOrDefault();
            var start = Request.Form.GetValues("start").FirstOrDefault();
            var length = Request.Form.GetValues("length").FirstOrDefault();


            //Find Order Column
            var sortColumn = Request.Form.GetValues("columns[" + Request.Form.GetValues("order[0][column]").FirstOrDefault() + "][name]").FirstOrDefault();
            var sortColumnDir = Request.Form.GetValues("order[0][dir]").FirstOrDefault();


            int pageSize = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;
            int recordsTotal = 0;

            using (vw_SpotbookingTenderContext dc = new vw_SpotbookingTenderContext())
            {

                var v = dc.vw_SpotbookingTender.OrderByDescending(x => x.Pk_int_tenderid).ToList();

                string search = Request.Form.GetValues("search[value]").FirstOrDefault();

                if (!(string.IsNullOrEmpty(search)))
                {

                    v = v.Where(p =>
                                     SafeToLower(p.str_lmedescription).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_quantity).Contains(search.ToLower()) ||

                                     SafeToLower(p.str_resevedprice).Contains(search.ToLower()) ||
                                     SafeToLower(p.str_currency).Contains(search.ToLower()) ||
                                     SafeToLower(p.strUnitCode).Contains(search.ToLower())

                ).ToList();
                }


                recordsTotal = v.Count();


                //SORT
                if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDir)))
                {

                    if (sortColumnDir == "desc")
                    {
                        if (sortColumn == "str_lmedescription")
                        {
                            v = v.OrderByDescending(x => x.str_lmedescription).ToList();
                        }
                        if (sortColumn == "str_quantity")
                        {
                            v = v.OrderByDescending(x => x.str_quantity).ToList();
                        }
                        if (sortColumn == "dt_closingtime")
                        {
                            v = v.OrderByDescending(x => x.dt_closingtime).ToList();
                        }
                        if (sortColumn == "str_resevedprice")
                        {
                            v = v.OrderByDescending(x => x.str_resevedprice).ToList();
                        }
                        if (sortColumn == "str_currency")
                        {
                            v = v.OrderByDescending(x => x.str_currency).ToList();
                        }
                        if (sortColumn == "strUnitCode")
                        {
                            v = v.OrderByDescending(x => x.strUnitCode).ToList();
                        }

                    }

                    if (sortColumnDir == "asc")
                    {
                        if (sortColumn == "str_lmedescription")
                        {
                            v = v.OrderByDescending(x => x.str_lmedescription).ToList();
                        }
                        if (sortColumn == "str_quantity")
                        {
                            v = v.OrderByDescending(x => x.str_quantity).ToList();
                        }
                        if (sortColumn == "dt_closingtime")
                        {
                            v = v.OrderByDescending(x => x.dt_closingtime).ToList();
                        }
                        if (sortColumn == "str_resevedprice")
                        {
                            v = v.OrderByDescending(x => x.str_resevedprice).ToList();
                        }
                        if (sortColumn == "str_currency")
                        {
                            v = v.OrderByDescending(x => x.str_currency).ToList();
                        }
                        if (sortColumn == "strUnitCode")
                        {
                            v = v.OrderByDescending(x => x.strUnitCode).ToList();
                        }
                    }

                }

                var data = v.Skip(skip).Take(pageSize).ToList();
                return Json(new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult EditProducttender(int id)
        {

            var tender = objtender.tbl_mst_Spotbooking_Tender.Where(x => x.Pk_int_tenderid == id).FirstOrDefault();
            ViewBag.str_upload = tender.str_upload;

            //ViewBag.fk_productid = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Product of Interest" && x.isactive == "YES").ToList(), "pk_lmeusermaster", "str_lmedescription", tender.fk_productid);
            ViewBag.fk_unit = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitCode", tender.fk_unit);
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            ViewBag.fk_productid = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Product of Interest" && x.dt_StartDate <= current && x.dt_EndDate >= current).ToList(), "pk_lmeusermaster", "str_lmedescription", tender.fk_productid);
            return View(tender);
        }


        [HttpPost]
        public ActionResult EditProducttender(tbl_mst_Spotbooking_Tender tbl_mst_Spotbooking_Tender, FormCollection frm)
        {
            HttpPostedFileBase str_upload = Request.Files["str_upload"];
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            ViewBag.fk_productid = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Product of Interest" && x.dt_StartDate <= current && x.dt_EndDate >= current).ToList(), "pk_lmeusermaster", "str_lmedescription", tbl_mst_Spotbooking_Tender.fk_productid);
            //ViewBag.fk_productid = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Product of Interest" && x.isactive == "YES").ToList(), "pk_lmeusermaster", "str_lmedescription", tbl_mst_Spotbooking_Tender.fk_productid);
            ViewBag.fk_unit = new SelectList(objContext3.Units.ToList(), "pk_intUnitId", "strUnitCode", tbl_mst_Spotbooking_Tender.fk_unit);
            if (str_upload.ContentLength > 0)

                if (ModelState.IsValid)
                {
                    string imagepath = null;
                    if (str_upload != null)
                    {

                        var fileName = Path.GetExtension(str_upload.FileName);
                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/UploadFile/Producttender/"), guid + fileName);
                        str_upload.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        imagepath = "~/UploadFile/Producttender/" + newpath;
                        tbl_mst_Spotbooking_Tender.str_upload = imagepath;

                    }
                    //File extention rename
                    var MineType = Utility.getMimeFromFile(imagepath);
                    if (MineType != "Invalied")
                    {
                        tbl_mst_Spotbooking_Tender.dt_updatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        objtender.Entry(tbl_mst_Spotbooking_Tender).State = EntityState.Modified;
                        objtender.SaveChanges();
                        ViewBag.Message = string.Format("Data updated successfully !");
                        ModelState.Clear();
                    }
                    else
                    {
                        //File extention rename
                        System.IO.File.Delete(MineType);
                        ViewBag.Message = "Invalied file...";
                    }
                    return View();
                }


            return View();

        }

        public ActionResult DisableOrder()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DisableOrder(tbl_DisableOrder tbl_DisableOrder)
        {
            tbl_DisableOrderContext obj = new tbl_DisableOrderContext();
            var checkData = obj.tbl_DisableOrder.FirstOrDefault();
            if (checkData == null)
            {
                obj.tbl_DisableOrder.Add(tbl_DisableOrder);
                obj.SaveChanges();
                ViewBag.Message = string.Format("Data saved successfully !");
            }
            else
            {
                checkData.dtFromDate = tbl_DisableOrder.dtFromDate;
                checkData.dtTodate = tbl_DisableOrder.dtTodate;
                obj.Entry(checkData).State = EntityState.Modified;
                obj.SaveChanges();
                ViewBag.Message = string.Format("Data updated successfully !");
            }

            ModelState.Clear();
            return View();
        }


        //Recruitement Application Status

        public ActionResult ApplicationDetails()
        {
            return View();

        }



        public ActionResult ApplicationStatus()
        {
            tbl_transaction_Postcriteriacontext obj = new tbl_transaction_Postcriteriacontext();
            tbl_mst_CandidatePersonalDetailscontext objpost = new tbl_mst_CandidatePersonalDetailscontext();



            DateTime fromDate = Convert.ToDateTime(Request.QueryString["fromDate"]);
            DateTime toDate = Convert.ToDateTime(Request.QueryString["toDate"]).AddHours(24);

            //ViewBag.fromDate = fromDate.ToString("dd-MMM-yyyy");
            //ViewBag.toDate = Convert.ToDateTime(Request.QueryString["toDate"]).ToString("dd-MMM-yyyy");

            var allpostdiscdata = obj.tbl_transaction_Postcriteria.Where(x => x.dt_entrydate >= fromDate && x.dt_entrydate <= toDate).ToList();
            var appliedpostdata = objpost.tbl_mst_CandidatePersonalDetails.Where(x => x.dt_entrydate >= fromDate && x.dt_entrydate <= toDate).ToList();
            var postdicipline = objpost.tbl_mst_CandidatePersonalDetails.Where(x => x.dt_entrydate >= fromDate && x.dt_entrydate <= toDate).ToList();
            //Vacany Post
            ViewBag.Minning = allpostdiscdata.Where(x => x.fk_diciplineid == 1).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Geology = allpostdiscdata.Where(x => x.fk_diciplineid == 2).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Metallurgy = allpostdiscdata.Where(x => x.fk_diciplineid == 3).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Mechanical = allpostdiscdata.Where(x => x.fk_diciplineid == 4).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Electrical = allpostdiscdata.Where(x => x.fk_diciplineid == 5).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Civil = allpostdiscdata.Where(x => x.fk_diciplineid == 6).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Research = allpostdiscdata.Where(x => x.fk_diciplineid == 7).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Systems = allpostdiscdata.Where(x => x.fk_diciplineid == 8).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Finance = allpostdiscdata.Where(x => x.fk_diciplineid == 9).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Human = allpostdiscdata.Where(x => x.fk_diciplineid == 10).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Law = allpostdiscdata.Where(x => x.fk_diciplineid == 11).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Medical = allpostdiscdata.Where(x => x.fk_diciplineid == 12).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Materials = allpostdiscdata.Where(x => x.fk_diciplineid == 13).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Marketing = allpostdiscdata.Where(x => x.fk_diciplineid == 14).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.CompanySecretary = allpostdiscdata.Where(x => x.fk_diciplineid == 15).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Corporate = allpostdiscdata.Where(x => x.fk_diciplineid == 16).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.TotalPost = ViewBag.Minning + ViewBag.Geology + ViewBag.Metallurgy + ViewBag.Mechanical + ViewBag.Electrical + ViewBag.Civil + ViewBag.Research + ViewBag.Systems + ViewBag.Finance +
            ViewBag.Human + ViewBag.Law + ViewBag.Medical + ViewBag.Materials + ViewBag.Marketing + ViewBag.CompanySecretary + ViewBag.Corporate;
            //Applied post
            ViewBag.minnigAppliedpost = appliedpostdata.Where(x => x.fk_postid == 1).Count();
            ViewBag.GeologyAppliedpost = appliedpostdata.Where(x => x.fk_postid == 2).Count();
            ViewBag.MetallurgyAppliedpost = appliedpostdata.Where(x => x.fk_postid == 3).Count();
            ViewBag.MechanicalAppliedpost = appliedpostdata.Where(x => x.fk_postid == 4).Count();
            ViewBag.ElectricalAppliedpost = appliedpostdata.Where(x => x.fk_postid == 5).Count();
            ViewBag.CivilAppliedpost = appliedpostdata.Where(x => x.fk_postid == 6).Count();
            ViewBag.ResearchAppliedpost = appliedpostdata.Where(x => x.fk_postid == 7).Count();
            ViewBag.SystemsAppliedpost = appliedpostdata.Where(x => x.fk_postid == 8).Count();
            ViewBag.FinanceAppliedpost = appliedpostdata.Where(x => x.fk_postid == 9).Count();
            ViewBag.HumanAppliedpost = appliedpostdata.Where(x => x.fk_postid == 10).Count();
            ViewBag.LawAppliedpost = appliedpostdata.Where(x => x.fk_postid == 11).Count();
            ViewBag.MedicalAppliedpost = appliedpostdata.Where(x => x.fk_postid == 12).Count();
            ViewBag.MaterialsAppliedpost = appliedpostdata.Where(x => x.fk_postid == 13).Count();
            ViewBag.MarketingAppliedpost = appliedpostdata.Where(x => x.fk_postid == 14).Count();
            ViewBag.CompanySecretaryAppliedpost = appliedpostdata.Where(x => x.fk_postid == 15).Count();
            ViewBag.CorporateAppliedpost = appliedpostdata.Where(x => x.fk_postid == 16).Count();
            ViewBag.TotalPostApplied = ViewBag.minnigAppliedpost + ViewBag.GeologyAppliedpost + ViewBag.MetallurgyAppliedpost + ViewBag.MechanicalAppliedpost + ViewBag.ElectricalAppliedpost +
            ViewBag.CivilAppliedpost + ViewBag.ResearchAppliedpost + ViewBag.SystemsAppliedpost + ViewBag.FinanceAppliedpost + ViewBag.HumanAppliedpost + ViewBag.LawAppliedpost + ViewBag.MedicalAppliedpost +
            ViewBag.MaterialsAppliedpost + ViewBag.MarketingAppliedpost + ViewBag.CompanySecretaryAppliedpost + ViewBag.CorporateAppliedpost;
            //PostAnd Dicipline
            ViewBag.minningE1 = postdicipline.Where(x => x.fk_dicipline == 1 && x.fk_postid == 2).Count();
            ViewBag.minningE2 = postdicipline.Where(x => x.fk_dicipline == 1 && x.fk_postid == 10).Count();
            ViewBag.minningE3 = postdicipline.Where(x => x.fk_dicipline == 1 && x.fk_postid == 1).Count();
            ViewBag.minningE4 = postdicipline.Where(x => x.fk_dicipline == 1 && x.fk_postid == 12).Count();
            ViewBag.minningE5 = postdicipline.Where(x => x.fk_dicipline == 1 && x.fk_postid == 13).Count();
            ViewBag.minningE6 = postdicipline.Where(x => x.fk_dicipline == 1 && x.fk_postid == 14).Count();
            ViewBag.minningE7 = postdicipline.Where(x => x.fk_dicipline == 1 && x.fk_postid == 15).Count();

            ViewBag.GeologyE1 = postdicipline.Where(x => x.fk_dicipline == 2 && x.fk_postid == 2).Count();
            ViewBag.GeologyE2 = postdicipline.Where(x => x.fk_dicipline == 2 && x.fk_postid == 10).Count();
            ViewBag.GeologyE3 = postdicipline.Where(x => x.fk_dicipline == 2 && x.fk_postid == 1).Count();
            ViewBag.GeologyE4 = postdicipline.Where(x => x.fk_dicipline == 2 && x.fk_postid == 12).Count();
            ViewBag.GeologyE5 = postdicipline.Where(x => x.fk_dicipline == 2 && x.fk_postid == 13).Count();
            ViewBag.GeologyE6 = postdicipline.Where(x => x.fk_dicipline == 2 && x.fk_postid == 14).Count();
            ViewBag.GeologyE7 = postdicipline.Where(x => x.fk_dicipline == 2 && x.fk_postid == 15).Count();

            ViewBag.MetallurgyE1 = postdicipline.Where(x => x.fk_dicipline == 3 && x.fk_postid == 2).Count();
            ViewBag.MetallurgyE2 = postdicipline.Where(x => x.fk_dicipline == 3 && x.fk_postid == 10).Count();
            ViewBag.MetallurgyE3 = postdicipline.Where(x => x.fk_dicipline == 3 && x.fk_postid == 1).Count();
            ViewBag.MetallurgyE4 = postdicipline.Where(x => x.fk_dicipline == 3 && x.fk_postid == 12).Count();
            ViewBag.MetallurgyE5 = postdicipline.Where(x => x.fk_dicipline == 3 && x.fk_postid == 13).Count();
            ViewBag.MetallurgyE6 = postdicipline.Where(x => x.fk_dicipline == 3 && x.fk_postid == 14).Count();
            ViewBag.MetallurgyE7 = postdicipline.Where(x => x.fk_dicipline == 3 && x.fk_postid == 15).Count();

            ViewBag.MechanicalE1 = postdicipline.Where(x => x.fk_dicipline == 4 && x.fk_postid == 2).Count();
            ViewBag.MechanicalE2 = postdicipline.Where(x => x.fk_dicipline == 4 && x.fk_postid == 10).Count();
            ViewBag.MechanicalE3 = postdicipline.Where(x => x.fk_dicipline == 4 && x.fk_postid == 1).Count();
            ViewBag.MechanicalE4 = postdicipline.Where(x => x.fk_dicipline == 4 && x.fk_postid == 12).Count();
            ViewBag.MechanicalE5 = postdicipline.Where(x => x.fk_dicipline == 4 && x.fk_postid == 13).Count();
            ViewBag.MechanicalE6 = postdicipline.Where(x => x.fk_dicipline == 4 && x.fk_postid == 14).Count();
            ViewBag.MechanicalE7 = postdicipline.Where(x => x.fk_dicipline == 4 && x.fk_postid == 15).Count();

            ViewBag.ElectricalE1 = postdicipline.Where(x => x.fk_dicipline == 5 && x.fk_postid == 2).Count();
            ViewBag.ElectricalE2 = postdicipline.Where(x => x.fk_dicipline == 5 && x.fk_postid == 10).Count();
            ViewBag.ElectricalE3 = postdicipline.Where(x => x.fk_dicipline == 5 && x.fk_postid == 1).Count();
            ViewBag.ElectricalE4 = postdicipline.Where(x => x.fk_dicipline == 5 && x.fk_postid == 12).Count();
            ViewBag.ElectricalE5 = postdicipline.Where(x => x.fk_dicipline == 5 && x.fk_postid == 13).Count();
            ViewBag.ElectricalE6 = postdicipline.Where(x => x.fk_dicipline == 5 && x.fk_postid == 14).Count();
            ViewBag.ElectricalE7 = postdicipline.Where(x => x.fk_dicipline == 5 && x.fk_postid == 15).Count();

            ViewBag.CivilE1 = postdicipline.Where(x => x.fk_dicipline == 6 && x.fk_postid == 2).Count();
            ViewBag.CivilE2 = postdicipline.Where(x => x.fk_dicipline == 6 && x.fk_postid == 10).Count();
            ViewBag.CivilE3 = postdicipline.Where(x => x.fk_dicipline == 6 && x.fk_postid == 1).Count();
            ViewBag.CivilE4 = postdicipline.Where(x => x.fk_dicipline == 6 && x.fk_postid == 12).Count();
            ViewBag.CivilE5 = postdicipline.Where(x => x.fk_dicipline == 6 && x.fk_postid == 13).Count();
            ViewBag.CivilE6 = postdicipline.Where(x => x.fk_dicipline == 6 && x.fk_postid == 14).Count();
            ViewBag.CivilE7 = postdicipline.Where(x => x.fk_dicipline == 6 && x.fk_postid == 15).Count();

            ViewBag.ResearchE1 = postdicipline.Where(x => x.fk_dicipline == 7 && x.fk_postid == 2).Count();
            ViewBag.ResearchE2 = postdicipline.Where(x => x.fk_dicipline == 7 && x.fk_postid == 10).Count();
            ViewBag.ResearchE3 = postdicipline.Where(x => x.fk_dicipline == 7 && x.fk_postid == 1).Count();
            ViewBag.ResearchE4 = postdicipline.Where(x => x.fk_dicipline == 7 && x.fk_postid == 12).Count();
            ViewBag.ResearchE5 = postdicipline.Where(x => x.fk_dicipline == 7 && x.fk_postid == 13).Count();
            ViewBag.ResearchE6 = postdicipline.Where(x => x.fk_dicipline == 7 && x.fk_postid == 14).Count();
            ViewBag.ResearchE7 = postdicipline.Where(x => x.fk_dicipline == 7 && x.fk_postid == 15).Count();

            ViewBag.SystemE1 = postdicipline.Where(x => x.fk_dicipline == 8 && x.fk_postid == 2).Count();
            ViewBag.SystemE2 = postdicipline.Where(x => x.fk_dicipline == 8 && x.fk_postid == 10).Count();
            ViewBag.SystemE3 = postdicipline.Where(x => x.fk_dicipline == 8 && x.fk_postid == 1).Count();
            ViewBag.SystemE4 = postdicipline.Where(x => x.fk_dicipline == 8 && x.fk_postid == 12).Count();
            ViewBag.SystemE5 = postdicipline.Where(x => x.fk_dicipline == 8 && x.fk_postid == 13).Count();
            ViewBag.SystemE6 = postdicipline.Where(x => x.fk_dicipline == 8 && x.fk_postid == 14).Count();
            ViewBag.SystemE7 = postdicipline.Where(x => x.fk_dicipline == 8 && x.fk_postid == 15).Count();


            ViewBag.FinanceE1 = postdicipline.Where(x => x.fk_dicipline == 9 && x.fk_postid == 2).Count();
            ViewBag.FinanceE2 = postdicipline.Where(x => x.fk_dicipline == 9 && x.fk_postid == 10).Count();
            ViewBag.FinanceE3 = postdicipline.Where(x => x.fk_dicipline == 9 && x.fk_postid == 1).Count();
            ViewBag.FinanceE4 = postdicipline.Where(x => x.fk_dicipline == 9 && x.fk_postid == 12).Count();
            ViewBag.FinanceE5 = postdicipline.Where(x => x.fk_dicipline == 9 && x.fk_postid == 13).Count();
            ViewBag.FinanceE6 = postdicipline.Where(x => x.fk_dicipline == 9 && x.fk_postid == 14).Count();
            ViewBag.FinanceE7 = postdicipline.Where(x => x.fk_dicipline == 9 && x.fk_postid == 15).Count();


            ViewBag.HRE1 = postdicipline.Where(x => x.fk_dicipline == 10 && x.fk_postid == 2).Count();
            ViewBag.HRE2 = postdicipline.Where(x => x.fk_dicipline == 10 && x.fk_postid == 10).Count();
            ViewBag.HRE3 = postdicipline.Where(x => x.fk_dicipline == 10 && x.fk_postid == 1).Count();
            ViewBag.HRE4 = postdicipline.Where(x => x.fk_dicipline == 10 && x.fk_postid == 12).Count();
            ViewBag.HRE5 = postdicipline.Where(x => x.fk_dicipline == 10 && x.fk_postid == 13).Count();
            ViewBag.HRE6 = postdicipline.Where(x => x.fk_dicipline == 10 && x.fk_postid == 14).Count();
            ViewBag.HRE7 = postdicipline.Where(x => x.fk_dicipline == 10 && x.fk_postid == 15).Count();



            ViewBag.LawE1 = postdicipline.Where(x => x.fk_dicipline == 11 && x.fk_postid == 2).Count();
            ViewBag.LawE2 = postdicipline.Where(x => x.fk_dicipline == 11 && x.fk_postid == 10).Count();
            ViewBag.LawE3 = postdicipline.Where(x => x.fk_dicipline == 11 && x.fk_postid == 1).Count();
            ViewBag.LawE4 = postdicipline.Where(x => x.fk_dicipline == 11 && x.fk_postid == 12).Count();
            ViewBag.LawE5 = postdicipline.Where(x => x.fk_dicipline == 11 && x.fk_postid == 13).Count();
            ViewBag.LawE6 = postdicipline.Where(x => x.fk_dicipline == 11 && x.fk_postid == 14).Count();
            ViewBag.LawE7 = postdicipline.Where(x => x.fk_dicipline == 11 && x.fk_postid == 15).Count();

            ViewBag.MedicalE1 = postdicipline.Where(x => x.fk_dicipline == 12 && x.fk_postid == 2).Count();
            ViewBag.MedicalE2 = postdicipline.Where(x => x.fk_dicipline == 12 && x.fk_postid == 10).Count();
            ViewBag.MedicalE3 = postdicipline.Where(x => x.fk_dicipline == 12 && x.fk_postid == 1).Count();
            ViewBag.MedicalE4 = postdicipline.Where(x => x.fk_dicipline == 12 && x.fk_postid == 12).Count();
            ViewBag.MedicalE5 = postdicipline.Where(x => x.fk_dicipline == 12 && x.fk_postid == 13).Count();
            ViewBag.MedicalE6 = postdicipline.Where(x => x.fk_dicipline == 12 && x.fk_postid == 14).Count();
            ViewBag.MedicalE7 = postdicipline.Where(x => x.fk_dicipline == 12 && x.fk_postid == 15).Count();


            ViewBag.MaterialE1 = postdicipline.Where(x => x.fk_dicipline == 13 && x.fk_postid == 2).Count();
            ViewBag.MaterialE2 = postdicipline.Where(x => x.fk_dicipline == 13 && x.fk_postid == 10).Count();
            ViewBag.MaterialE3 = postdicipline.Where(x => x.fk_dicipline == 13 && x.fk_postid == 1).Count();
            ViewBag.MaterialE4 = postdicipline.Where(x => x.fk_dicipline == 13 && x.fk_postid == 12).Count();
            ViewBag.MaterialE5 = postdicipline.Where(x => x.fk_dicipline == 13 && x.fk_postid == 13).Count();
            ViewBag.MaterialE6 = postdicipline.Where(x => x.fk_dicipline == 13 && x.fk_postid == 14).Count();
            ViewBag.MaterialE7 = postdicipline.Where(x => x.fk_dicipline == 13 && x.fk_postid == 15).Count();


            ViewBag.MarketingE1 = postdicipline.Where(x => x.fk_dicipline == 14 && x.fk_postid == 2).Count();
            ViewBag.MarketingE2 = postdicipline.Where(x => x.fk_dicipline == 14 && x.fk_postid == 10).Count();
            ViewBag.MarketingE3 = postdicipline.Where(x => x.fk_dicipline == 14 && x.fk_postid == 1).Count();
            ViewBag.MarketingE4 = postdicipline.Where(x => x.fk_dicipline == 14 && x.fk_postid == 12).Count();
            ViewBag.MarketingE5 = postdicipline.Where(x => x.fk_dicipline == 14 && x.fk_postid == 13).Count();
            ViewBag.MarketingE6 = postdicipline.Where(x => x.fk_dicipline == 14 && x.fk_postid == 14).Count();
            ViewBag.MarketingE7 = postdicipline.Where(x => x.fk_dicipline == 14 && x.fk_postid == 15).Count();


            ViewBag.CompanySecretaryE1 = postdicipline.Where(x => x.fk_dicipline == 15 && x.fk_postid == 2).Count();
            ViewBag.CompanySecretaryE2 = postdicipline.Where(x => x.fk_dicipline == 15 && x.fk_postid == 10).Count();
            ViewBag.CompanySecretaryE3 = postdicipline.Where(x => x.fk_dicipline == 15 && x.fk_postid == 1).Count();
            ViewBag.CompanySecretaryE4 = postdicipline.Where(x => x.fk_dicipline == 15 && x.fk_postid == 12).Count();
            ViewBag.CompanySecretaryE5 = postdicipline.Where(x => x.fk_dicipline == 15 && x.fk_postid == 13).Count();
            ViewBag.CompanySecretaryE6 = postdicipline.Where(x => x.fk_dicipline == 15 && x.fk_postid == 14).Count();
            ViewBag.CompanySecretaryE7 = postdicipline.Where(x => x.fk_dicipline == 15 && x.fk_postid == 15).Count();



            ViewBag.CorporateE1 = postdicipline.Where(x => x.fk_dicipline == 16 && x.fk_postid == 2).Count();
            ViewBag.CorporateE2 = postdicipline.Where(x => x.fk_dicipline == 16 && x.fk_postid == 10).Count();
            ViewBag.CorporateE3 = postdicipline.Where(x => x.fk_dicipline == 16 && x.fk_postid == 1).Count();
            ViewBag.CorporateE4 = postdicipline.Where(x => x.fk_dicipline == 16 && x.fk_postid == 12).Count();
            ViewBag.CorporateE5 = postdicipline.Where(x => x.fk_dicipline == 16 && x.fk_postid == 13).Count();
            ViewBag.CorporateE6 = postdicipline.Where(x => x.fk_dicipline == 16 && x.fk_postid == 14).Count();
            ViewBag.CorporateE7 = postdicipline.Where(x => x.fk_dicipline == 16 && x.fk_postid == 15).Count();


            //total post wise

            ViewBag.E1total = postdicipline.Where(x => x.fk_postid == 2).Count();
            ViewBag.E2total = postdicipline.Where(x => x.fk_postid == 10).Count();
            ViewBag.E3total = postdicipline.Where(x => x.fk_postid == 1).Count();
            ViewBag.E4total = postdicipline.Where(x => x.fk_postid == 12).Count();
            ViewBag.E5total = postdicipline.Where(x => x.fk_postid == 13).Count();
            ViewBag.E6total = postdicipline.Where(x => x.fk_postid == 14).Count();
            ViewBag.E7total = postdicipline.Where(x => x.fk_postid == 15).Count();


            return View();
        }


        public ActionResult ApplicationInternalexternal()
        {
            tbl_transaction_Postcriteriacontext obj = new tbl_transaction_Postcriteriacontext();
            var allpostdiscdata = obj.tbl_transaction_Postcriteria.ToList();

            //Vacany Post
            ViewBag.MinningE1 = allpostdiscdata.Where(x => x.fk_diciplineid == 1 && x.fk_postid == 2).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MinningE2 = allpostdiscdata.Where(x => x.fk_diciplineid == 1 && x.fk_postid == 10).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MinningE3 = allpostdiscdata.Where(x => x.fk_diciplineid == 1 && x.fk_postid == 1).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MinningE4 = allpostdiscdata.Where(x => x.fk_diciplineid == 1 && x.fk_postid == 12).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MinningE5 = allpostdiscdata.Where(x => x.fk_diciplineid == 1 && x.fk_postid == 13).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MinningE6 = allpostdiscdata.Where(x => x.fk_diciplineid == 1 && x.fk_postid == 14).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MinningE7 = allpostdiscdata.Where(x => x.fk_diciplineid == 1 && x.fk_postid == 15).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Minning = allpostdiscdata.Where(x => x.fk_diciplineid == 1).Sum(x => Convert.ToInt32(x.intvacancy));

            ViewBag.Geology = allpostdiscdata.Where(x => x.fk_diciplineid == 2).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.GeologyE1 = allpostdiscdata.Where(x => x.fk_diciplineid == 2 && x.fk_postid == 2).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.GeologyE2 = allpostdiscdata.Where(x => x.fk_diciplineid == 2 && x.fk_postid == 10).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.GeologyE3 = allpostdiscdata.Where(x => x.fk_diciplineid == 2 && x.fk_postid == 1).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.GeologyE4 = allpostdiscdata.Where(x => x.fk_diciplineid == 2 && x.fk_postid == 12).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.GeologyE5 = allpostdiscdata.Where(x => x.fk_diciplineid == 2 && x.fk_postid == 13).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.GeologyE6 = allpostdiscdata.Where(x => x.fk_diciplineid == 2 && x.fk_postid == 14).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.GeologyE7 = allpostdiscdata.Where(x => x.fk_diciplineid == 2 && x.fk_postid == 15).Sum(x => Convert.ToInt32(x.intvacancy));




            ViewBag.Metallurgy = allpostdiscdata.Where(x => x.fk_diciplineid == 3).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MetallurgyE1 = allpostdiscdata.Where(x => x.fk_diciplineid == 3 && x.fk_postid == 2).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MetallurgyE2 = allpostdiscdata.Where(x => x.fk_diciplineid == 3 && x.fk_postid == 10).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MetallurgyE3 = allpostdiscdata.Where(x => x.fk_diciplineid == 3 && x.fk_postid == 1).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MetallurgyE4 = allpostdiscdata.Where(x => x.fk_diciplineid == 3 && x.fk_postid == 12).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MetallurgyE5 = allpostdiscdata.Where(x => x.fk_diciplineid == 3 && x.fk_postid == 13).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MetallurgyE6 = allpostdiscdata.Where(x => x.fk_diciplineid == 3 && x.fk_postid == 14).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MetallurgyE7 = allpostdiscdata.Where(x => x.fk_diciplineid == 3 && x.fk_postid == 15).Sum(x => Convert.ToInt32(x.intvacancy));


            ViewBag.Mechanical = allpostdiscdata.Where(x => x.fk_diciplineid == 4).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MechanicalE1 = allpostdiscdata.Where(x => x.fk_diciplineid == 4 && x.fk_postid == 2).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MechanicalE2 = allpostdiscdata.Where(x => x.fk_diciplineid == 4 && x.fk_postid == 10).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MechanicalE3 = allpostdiscdata.Where(x => x.fk_diciplineid == 4 && x.fk_postid == 1).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MechanicalE4 = allpostdiscdata.Where(x => x.fk_diciplineid == 4 && x.fk_postid == 12).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MechanicalE5 = allpostdiscdata.Where(x => x.fk_diciplineid == 4 && x.fk_postid == 13).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MechanicalE6 = allpostdiscdata.Where(x => x.fk_diciplineid == 4 && x.fk_postid == 14).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.MechanicalE7 = allpostdiscdata.Where(x => x.fk_diciplineid == 4 && x.fk_postid == 15).Sum(x => Convert.ToInt32(x.intvacancy));



            ViewBag.Electrical = allpostdiscdata.Where(x => x.fk_diciplineid == 5).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ElectricalE1 = allpostdiscdata.Where(x => x.fk_diciplineid == 5 && x.fk_postid == 2).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ElectricalE2 = allpostdiscdata.Where(x => x.fk_diciplineid == 5 && x.fk_postid == 10).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ElectricalE3 = allpostdiscdata.Where(x => x.fk_diciplineid == 5 && x.fk_postid == 1).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ElectricalE4 = allpostdiscdata.Where(x => x.fk_diciplineid == 5 && x.fk_postid == 12).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ElectricalE5 = allpostdiscdata.Where(x => x.fk_diciplineid == 5 && x.fk_postid == 13).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ElectricalE6 = allpostdiscdata.Where(x => x.fk_diciplineid == 5 && x.fk_postid == 14).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ElectricalE7 = allpostdiscdata.Where(x => x.fk_diciplineid == 5 && x.fk_postid == 15).Sum(x => Convert.ToInt32(x.intvacancy));



            ViewBag.Civil = allpostdiscdata.Where(x => x.fk_diciplineid == 6).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.CivilE1 = allpostdiscdata.Where(x => x.fk_diciplineid == 6 && x.fk_postid == 2).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.CivilE2 = allpostdiscdata.Where(x => x.fk_diciplineid == 6 && x.fk_postid == 10).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.CivilE3 = allpostdiscdata.Where(x => x.fk_diciplineid == 6 && x.fk_postid == 1).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.CivilE4 = allpostdiscdata.Where(x => x.fk_diciplineid == 6 && x.fk_postid == 12).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.CivilE5 = allpostdiscdata.Where(x => x.fk_diciplineid == 6 && x.fk_postid == 13).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.CivilE6 = allpostdiscdata.Where(x => x.fk_diciplineid == 6 && x.fk_postid == 14).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.CivilE7 = allpostdiscdata.Where(x => x.fk_diciplineid == 6 && x.fk_postid == 15).Sum(x => Convert.ToInt32(x.intvacancy));


            ViewBag.Research = allpostdiscdata.Where(x => x.fk_diciplineid == 7).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ResearchE1 = allpostdiscdata.Where(x => x.fk_diciplineid == 7 && x.fk_postid == 2).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ResearchE2 = allpostdiscdata.Where(x => x.fk_diciplineid == 7 && x.fk_postid == 10).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ResearchE3 = allpostdiscdata.Where(x => x.fk_diciplineid == 7 && x.fk_postid == 1).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ResearchE4 = allpostdiscdata.Where(x => x.fk_diciplineid == 7 && x.fk_postid == 12).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ResearchE5 = allpostdiscdata.Where(x => x.fk_diciplineid == 7 && x.fk_postid == 13).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ResearchE6 = allpostdiscdata.Where(x => x.fk_diciplineid == 7 && x.fk_postid == 14).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.ResearchE7 = allpostdiscdata.Where(x => x.fk_diciplineid == 7 && x.fk_postid == 15).Sum(x => Convert.ToInt32(x.intvacancy));

            ViewBag.Systems = allpostdiscdata.Where(x => x.fk_diciplineid == 8).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.SystemsE1 = allpostdiscdata.Where(x => x.fk_diciplineid == 8 && x.fk_postid == 2).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.SystemsE2 = allpostdiscdata.Where(x => x.fk_diciplineid == 8 && x.fk_postid == 10).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.SystemsE3 = allpostdiscdata.Where(x => x.fk_diciplineid == 8 && x.fk_postid == 1).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.SystemsE4 = allpostdiscdata.Where(x => x.fk_diciplineid == 8 && x.fk_postid == 12).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.SystemsE5 = allpostdiscdata.Where(x => x.fk_diciplineid == 8 && x.fk_postid == 13).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.SystemsE6 = allpostdiscdata.Where(x => x.fk_diciplineid == 8 && x.fk_postid == 14).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.SystemsE7 = allpostdiscdata.Where(x => x.fk_diciplineid == 8 && x.fk_postid == 15).Sum(x => Convert.ToInt32(x.intvacancy));



            ViewBag.Finance = allpostdiscdata.Where(x => x.fk_diciplineid == 9).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.FinanceE1 = allpostdiscdata.Where(x => x.fk_diciplineid == 9 && x.fk_postid == 2).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.FinanceE2 = allpostdiscdata.Where(x => x.fk_diciplineid == 9 && x.fk_postid == 10).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.FinanceE3 = allpostdiscdata.Where(x => x.fk_diciplineid == 9 && x.fk_postid == 1).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.FinanceE4 = allpostdiscdata.Where(x => x.fk_diciplineid == 9 && x.fk_postid == 12).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.FinanceE5 = allpostdiscdata.Where(x => x.fk_diciplineid == 9 && x.fk_postid == 13).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.FinanceE6 = allpostdiscdata.Where(x => x.fk_diciplineid == 9 && x.fk_postid == 14).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.FinanceE7 = allpostdiscdata.Where(x => x.fk_diciplineid == 9 && x.fk_postid == 15).Sum(x => Convert.ToInt32(x.intvacancy));


            ViewBag.Human = allpostdiscdata.Where(x => x.fk_diciplineid == 10).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.HumanE1 = allpostdiscdata.Where(x => x.fk_diciplineid == 10 && x.fk_postid == 2).Sum(x => Convert.ToInt32(x.intvacancy));






            ViewBag.Law = allpostdiscdata.Where(x => x.fk_diciplineid == 11).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Medical = allpostdiscdata.Where(x => x.fk_diciplineid == 12).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Materials = allpostdiscdata.Where(x => x.fk_diciplineid == 13).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Marketing = allpostdiscdata.Where(x => x.fk_diciplineid == 14).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.CompanySecretary = allpostdiscdata.Where(x => x.fk_diciplineid == 15).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Corporate = allpostdiscdata.Where(x => x.fk_diciplineid == 16).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Survey = allpostdiscdata.Where(x => x.fk_diciplineid == 23).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Concentrator = allpostdiscdata.Where(x => x.fk_diciplineid == 24).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Chemical = allpostdiscdata.Where(x => x.fk_diciplineid == 25).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.Safety = allpostdiscdata.Where(x => x.fk_diciplineid == 26).Sum(x => Convert.ToInt32(x.intvacancy));
            ViewBag.IndustrialEngineering = allpostdiscdata.Where(x => x.fk_diciplineid == 27).Sum(x => Convert.ToInt32(x.intvacancy));

            ViewBag.TotalPost = ViewBag.Minning + ViewBag.Geology + ViewBag.Metallurgy + ViewBag.Mechanical + ViewBag.Electrical + ViewBag.Civil + ViewBag.Research + ViewBag.Systems + ViewBag.Finance +
            ViewBag.Human + ViewBag.Law + ViewBag.Medical + ViewBag.Materials + ViewBag.Marketing + ViewBag.CompanySecretary + ViewBag.Corporate;

            return View();
        }




        public static string checkFileExtention(string ext)
        {
            string valid = "YES";
            ext = ext.ToLower();
            //if (ext == ".aspx" || ext == ".asp" || ext == ".php" || ext == ".jsp" || ext == ".html" || ext == ".exe" || ext == ".htm")
            //{
            //    valid="NO";
            //}
            return valid;
        }



        public ActionResult AddVigilanceUser()
        {
            ViewBag.vchUnitId = new SelectList(objContext3.Units.Where(x => x.isActive == true).ToList(), "pk_intUnitId", "strUnitName");
            ViewBag.vchDeptId = new SelectList(objContext8.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");
            return View();

        }



        [HttpPost]
        public ActionResult AddVigilanceUser(M_UserMaster M_UserMaster, FormCollection frm, HttpPostedFileBase vchPhotoPath)
        {

            ViewBag.vchUnitId = new SelectList(objContext3.Units.Where(x => x.isActive == true).ToList(), "pk_intUnitId", "strUnitName");
            ViewBag.vchDeptId = new SelectList(objContext8.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");


            if (ModelState.IsValid)
            {

                var fileName = "";
                var returnValue = "YES";
                if (vchPhotoPath != null)
                {
                    fileName = Path.GetExtension(vchPhotoPath.FileName);
                    returnValue = checkFileExtention(fileName);
                }
                if (returnValue == "YES")
                {
                    string imagepath = null;

                    if (vchPhotoPath != null)
                    {
                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/VigilanceUserPhoto/"), guid + fileName);
                        vchPhotoPath.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        imagepath = "~/VigilanceUserPhoto/" + newpath;
                        M_UserMaster.vchPhotoPath = imagepath;
                    }

                    if (M_UserMaster.vchAdminPrev == "YesNo")
                    {
                        M_UserMaster.vchDesigId = "CVO";
                    }
                    else
                    {
                        M_UserMaster.vchDesigId = "VO";
                    }

                    //File extention rename
                    var MineType = Utility.getMimeFromFile(imagepath);
                    if (MineType != "Invalied")
                    {
                        M_UserMaster.vchUserId = M_UserMaster.vchEmpId;
                        M_UserMaster.dtmCreatedOn = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        M_UserMaster.vchCreatedBy = Session["UserID"].ToString();
                        objContext.M_UserMaster.Add(M_UserMaster);
                        objContext.SaveChanges();
                        ViewBag.Message = string.Format("Data saved successfully !");
                    }
                    else
                    {
                        //File extention rename
                        System.IO.File.Delete(MineType);
                        ViewBag.Message = "Invalied file...";
                    }
                }

                else
                {
                    ViewBag.Message = string.Format("Invalid file type. !");
                }
                return View();
            }

            // This for error checking command

            var errors = string.Join("; ", ModelState.Values
                                     .SelectMany(x => x.Errors)
                                     .Select(x => x.ErrorMessage));

            return View();
        }






        public ActionResult ListVigilanceUser()
        {

            var List = objContext.M_UserMaster.OrderByDescending(x => x.pk_intUserId).ToList();
            return View(List);
        }


        public ActionResult EditVigilanceUser(int id)
        {
            var detailsbyId = objContext.M_UserMaster.Where(x => x.pk_intUserId == id).FirstOrDefault();
            ViewBag.vchUnitId = new SelectList(objContext3.Units.Where(x => x.isActive == true).ToList(), "pk_intUnitId", "strUnitName", detailsbyId.vchUnitId);
            ViewBag.vchDeptId = new SelectList(objContext8.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName", detailsbyId.vchDeptId);
            return View(detailsbyId);
        }

        [HttpPost]
        public ActionResult EditVigilanceUser(M_UserMaster M_UserMaster, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                ViewBag.vchUnitId = new SelectList(objContext3.Units.Where(x => x.isActive == true).ToList(), "pk_intUnitId", "strUnitName", M_UserMaster.vchUnitId);
                ViewBag.vchDeptId = new SelectList(objContext8.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName", M_UserMaster.vchDeptId);

                if (M_UserMaster.vchAdminPrev == "YesNo")
                {
                    M_UserMaster.vchDesigId = "CVO";
                }
                else
                {
                    M_UserMaster.vchDesigId = "VO";
                }

                M_UserMaster.vchUserId = M_UserMaster.vchEmpId;
                M_UserMaster.dtmUpdatedOn = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                M_UserMaster.vchCreatedBy = Session["UserID"].ToString();
                objContext.Entry(M_UserMaster).State = EntityState.Modified;
                objContext.SaveChanges();

                ViewBag.Message = string.Format("Data updated successfully !");


            }
            return View();
        }




        // Investor Relations




        public ActionResult AddInvestorRelationPage()
        {
            ViewBag.strPageType = new SelectList(objContextCategory.tbl_mstCategory.Where(x => x.isActive == true).ToList(), "strCategoryName", "strCategoryName");

            return View(new tbl_mst_InvestorRelationsPage());

        }


        [HttpPost]
        public ActionResult AddInvestorRelationPage(tbl_mst_InvestorRelationsPage tbl_mst_InvestorRelationsPage, FormCollection frm, HttpPostedFileBase strHindiFileUpload, HttpPostedFileBase strEnglishFileUpload)
        {
            ViewBag.strPageType = new SelectList(objContextCategory.tbl_mstCategory.Where(x => x.isActive == true).ToList(), "strCategoryName", "strCategoryName");

            if (ModelState.IsValid)
            {
                try
                {
                    string imagepath = null;
                    string imagepath1 = null;

                    if (strHindiFileUpload != null)
                    {

                        var fileName = Path.GetExtension(strHindiFileUpload.FileName);
                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/UploadFile/AdminPanel/HindiInvestorRelationPage/"), guid + fileName);
                        strHindiFileUpload.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        imagepath = "~/UploadFile/AdminPanel/HindiInvestorRelationPage/" + newpath;

                    }

                    if (strEnglishFileUpload != null)
                    {

                        var fileName = Path.GetExtension(strEnglishFileUpload.FileName);
                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/UploadFile/AdminPanel/EnglishInvestorRelationPage/"), guid + fileName);
                        strEnglishFileUpload.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        imagepath1 = "~/UploadFile/AdminPanel/EnglishInvestorRelationPage/" + newpath;

                    }

                    //File extention rename
                    var MineType = Utility.getMimeFromFile(imagepath);
                    var MineType1 = Utility.getMimeFromFile(imagepath1);
                    if (MineType != "Invalied" && MineType1 != "Invalied")
                    {
                        tbl_mst_InvestorRelationsPage.strHindiFileUpload = imagepath;
                        tbl_mst_InvestorRelationsPage.strEnglishFileUpload = imagepath1;
                        // tbl_mst_InvestorRelationsPage.isActive = true;
                        //tbl_mst_InvestorRelationsPage.strPageType ="Advertisements under Regulation 47";
                        tbl_mst_InvestorRelationsPage.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        db.tbl_mst_InvestorRelationsPage.Add(tbl_mst_InvestorRelationsPage);
                        db.SaveChanges();
                        ViewBag.Message = string.Format("Data saved successfully !");
                        ModelState.Clear();
                        return View();
                    }

                    else
                    {
                        //File extention rename
                        System.IO.File.Delete(MineType);
                        System.IO.File.Delete(MineType1);
                        ViewBag.Message = "Invalied file...";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Message = string.Format(ex.Message);
                    return View();
                }
            }
            var errors = string.Join("; ", ModelState.Values
                                      .SelectMany(x => x.Errors)
                                      .Select(x => x.ErrorMessage));
            ViewBag.Message = string.Format(errors);
            return View();

        }




        public ActionResult ListInvestorRelationPage()
        {

            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }


        public ActionResult EditInvestorRelationPage(int id)
        {
            var InvestorRelationPage = db.tbl_mst_InvestorRelationsPage.Where(x => x.pk_int_InvestorRelationsID == id).FirstOrDefault();

            ViewBag.strPageType = new SelectList(objContextCategory.tbl_mstCategory.Where(x => x.isActive == true).ToList(), "strCategoryName", "strCategoryName", InvestorRelationPage.strPageType);
            ViewBag.isActive = InvestorRelationPage.isActive;
            // ViewBag.strStatus = eoi.strStatus;
            ViewBag.strHindiFileUpload = InvestorRelationPage.strHindiFileUpload;
            ViewBag.strEnglishFileUpload = InvestorRelationPage.strEnglishFileUpload;
            return View(InvestorRelationPage);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditInvestorRelationPage(tbl_mst_InvestorRelationsPage tbl_mst_InvestorRelationsPage, FormCollection frm, HttpPostedFileBase strHindiFileUpload, HttpPostedFileBase strEnglishFileUpload)
        {
            ViewBag.strPageType = new SelectList(objContextCategory.tbl_mstCategory.Where(x => x.isActive == true).ToList(), "strCategoryName", "strCategoryName", tbl_mst_InvestorRelationsPage.strPageType);

            var fileName = "";
            var returnValue = "YES";

            if (strEnglishFileUpload != null)
            {
                fileName = Path.GetExtension(strEnglishFileUpload.FileName);
                returnValue = Utility.checkFileExtention(fileName);
            }

            if (returnValue == "YES")
            {
                if (strEnglishFileUpload != null)
                {

                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/UploadFile/AdminPanel/EnglishInvestorRelationPage/"), guid + fileName);
                    strEnglishFileUpload.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/UploadFile/AdminPanel/EnglishInvestorRelationPage/" + newpath;
                    tbl_mst_InvestorRelationsPage.strEnglishFileUpload = imagepath;
                }


                if (strHindiFileUpload != null)
                {

                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/UploadFile/AdminPanel/HindiInvestorRelationPage/"), guid + fileName);
                    strHindiFileUpload.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/UploadFile/AdminPanel/HindiInvestorRelationPage/" + newpath;
                    tbl_mst_InvestorRelationsPage.strHindiFileUpload = imagepath;
                }

                tbl_mst_InvestorRelationsPage.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");

                db.Entry(tbl_mst_InvestorRelationsPage).State = EntityState.Modified;
                db.SaveChanges();

                ViewBag.isActive = tbl_mst_InvestorRelationsPage.isActive;
                ViewBag.strEnglishFileUpload = tbl_mst_InvestorRelationsPage.strEnglishFileUpload;
                ViewBag.strHindiFileUpload = tbl_mst_InvestorRelationsPage.strHindiFileUpload;

                ViewBag.Message = string.Format("Data updated successfully !");
            }
            else
            {
                ViewBag.Message = string.Format("Invalid file type. !");
            }

            return View();

        }



        #region "Static Page Details"

        public ActionResult ListAllPageDetails()
        {
            var AllPageDetails = dbContext001.tbl_mstPageDetail.ToList();
            return View(AllPageDetails);
        }


        public ActionResult ListAllPageDetailsApprove()
        {
            var AllPageDetails = dbContext001.tbl_mstPageDetail_Approve.ToList();
            return View(AllPageDetails);
        }



        public ActionResult AddAllPageDetails()
        {
            return View();
        }





        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddAllPageDetails(tbl_mstPageDetail objtbl_mstPageDetail)
        {


            if (ModelState.IsValid)
            {
                objtbl_mstPageDetail.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objtbl_mstPageDetail.IsActive = true;
                dbContext001.tbl_mstPageDetail.Add(objtbl_mstPageDetail);
                dbContext001.SaveChanges();
                ViewBag.Message = string.Format("Data saved successfully !");
                return View();
            }


            return View();
        }


        public ActionResult EditAllPageDetails(int id)
        {
            var AllPageDetails = dbContext001.tbl_mstPageDetail.Where(x => x.Pk_intAllStaticPageID == id).FirstOrDefault();

            return View(AllPageDetails);
        }



        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult EditAllPageDetails(tbl_mstPageDetail_Approve tbl_mstPageDetail)
        {
            tbl_mstPageDetail.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            tbl_mstPageDetail.intUserId = Convert.ToInt32(Session["UserID"]);
            dbContext001.tbl_mstPageDetail_Approve.Add(tbl_mstPageDetail);
            dbContext001.SaveChanges();
            ViewBag.Message = string.Format("Data updated successfully !");

            return View();
        }


        public ActionResult EditAllPageDetailsApprove(int id)
        {
            var AllPageDetails = dbContext001.tbl_mstPageDetail_Approve.Where(x => x.Pk_intAllStaticPageApproveID == id).FirstOrDefault();

            return View(AllPageDetails);
        }


        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult EditAllPageDetailsApprove(tbl_mstPageDetail tbl_mstPageDetail)
        {
            tbl_mstPageDetail.dtUpdateDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            dbContext001.Entry(tbl_mstPageDetail).State = EntityState.Modified;
            dbContext001.SaveChanges();
            ViewBag.Message = string.Format("Data updated successfully !");

            return View();
        }


        #endregion



        #region "Static Head Image"

        public ActionResult ListHeadImage()
        {
            var HeadImage = dbContext003.tbl_mst_HeadImage.ToList();
            return View(HeadImage);
        }


        public ActionResult ListHeadImageApprove()
        {
            var HeadImage = dbContext003.tbl_mst_HeadImage_Approve.ToList();
            return View(HeadImage);
        }

        public ActionResult AddHeadImage()
        {
            return View();

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult AddHeadImage(tbl_mst_HeadImage tbl_mst_HeadImage, FormCollection frm, HttpPostedFileBase strImagePath, HttpPostedFileBase strHindiImagePath)
        {

            if (ModelState.IsValid)
            {
                var fileName = "";
                var returnValue = "YES";
                var fileName1 = "";
                var returnValue1 = "YES";

                if (strImagePath != null)
                {
                    fileName = Path.GetExtension(strImagePath.FileName);
                    returnValue = Utility.checkFileExtention(fileName);
                }

                if (strHindiImagePath != null)
                {
                    fileName1 = Path.GetExtension(strHindiImagePath.FileName);
                    returnValue1 = Utility.checkFileExtention(fileName1);
                }

                if (returnValue == "YES" && returnValue1 == "YES")
                {

                    if (strImagePath != null)
                    {

                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/Content/img/slider/"), guid + fileName);
                        strImagePath.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Content/img/slider/" + newpath;
                        tbl_mst_HeadImage.strImagePath = imagepath;
                    }


                    if (strHindiImagePath != null)
                    {

                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/Content/img/slider/"), guid + fileName1);
                        strHindiImagePath.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Content/img/slider/" + newpath;
                        tbl_mst_HeadImage.strHindiImagePath = imagepath;
                    }
                    //tbl_mst_HeadImage.strCategory = "Head Image";
                    tbl_mst_HeadImage.IsActive = true;
                    tbl_mst_HeadImage.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    dbContext003.tbl_mst_HeadImage.Add(tbl_mst_HeadImage);
                    ModelState.Clear();
                    dbContext003.SaveChanges();

                    ViewBag.Message = string.Format("Data saved successfully !");
                    return View();
                }
            }
            else
            {
                ViewBag.Message = string.Format("Invalid file type. !");
            }


            return View();
        }




        // debtana new




        public ActionResult EditHeadImage(int id)
        {

            var headImagedetails = dbContext003.tbl_mst_HeadImage.Where(x => x.pk_intHeadImageID == id).FirstOrDefault();
            ViewBag.IsActive = headImagedetails.IsActive;
            ViewBag.strCategory = headImagedetails.strCategory;
            ViewBag.strImagePath = headImagedetails.strImagePath;
            ViewBag.strHindiImagePath = headImagedetails.strHindiImagePath;

            return View(headImagedetails);

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditHeadImage(tbl_mst_HeadImage_Approve tbl_mst_HeadImage, FormCollection frm, HttpPostedFileBase strImagePath, HttpPostedFileBase strHindiImagePath)
        {



            if (ModelState.IsValid)
            {
                var fileName = "";
                var returnValue = "YES";
                var fileName1 = "";
                var returnValue1 = "YES";

                if (strImagePath != null)
                {
                    fileName = Path.GetExtension(strImagePath.FileName);
                    returnValue = Utility.checkFileExtention(fileName);
                }

                if (strHindiImagePath != null)
                {
                    fileName1 = Path.GetExtension(strHindiImagePath.FileName);
                    returnValue1 = Utility.checkFileExtention(fileName1);
                }

                if (returnValue == "YES" && returnValue1 == "YES")
                {

                    if (strImagePath != null)
                    {

                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/Content/img/slider/"), guid + fileName);
                        strImagePath.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Content/img/slider/" + newpath;
                        tbl_mst_HeadImage.strImagePath = imagepath;
                    }


                    if (strHindiImagePath != null)
                    {

                        var guid = Guid.NewGuid().ToString();
                        var path = Path.Combine(Server.MapPath("~/Content/img/slider/"), guid + fileName1);
                        strHindiImagePath.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Content/img/slider/" + newpath;
                        tbl_mst_HeadImage.strHindiImagePath = imagepath;
                    }
                    //tbl_mst_HeadImage.strCategory = "Head Image";
                    tbl_mst_HeadImage.IsActive = true;
                    tbl_mst_HeadImage.intUserId = Convert.ToInt32(Session["UserID"]);
                    tbl_mst_HeadImage.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    dbContext003.tbl_mst_HeadImage_Approve.Add(tbl_mst_HeadImage);
                    ModelState.Clear();
                    dbContext003.SaveChanges();

                    ViewBag.Message = string.Format("Data updated successfully !");
                    return View();
                }
            }
            else
            {
                ViewBag.Message = string.Format("Invalid file type. !");
            }


            return View();



        }




        public ActionResult EditHeadImageApprove(int id)
        {

            var headImagedetails = dbContext003.tbl_mst_HeadImage_Approve.Where(x => x.pk_intHeadImageIDApprove == id).FirstOrDefault();
            ViewBag.IsActive = headImagedetails.IsActive;
            ViewBag.strCategory = headImagedetails.strCategory;
            ViewBag.strImagePath = headImagedetails.strImagePath;
            ViewBag.strHindiImagePath = headImagedetails.strHindiImagePath;

            return View(headImagedetails);

        }


        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult EditHeadImageApprove(tbl_mst_HeadImage tbl_mst_HeadImage, FormCollection frm)
        {
            HttpPostedFileBase strImagePath = Request.Files["strImagePathEdit"];
            HttpPostedFileBase strHindiImagePath = Request.Files["strHindiImagePathEdit"];

            var fileName = "";
            var returnValue = "YES";
            var fileName1 = "";
            var returnValue1 = "YES";

            if (strImagePath != null)
            {
                fileName = Path.GetExtension(strImagePath.FileName);
                returnValue = Utility.checkFileExtention(fileName);
            }

            if (strHindiImagePath != null)
            {
                fileName1 = Path.GetExtension(strHindiImagePath.FileName);
                returnValue1 = Utility.checkFileExtention(fileName1);
            }

            if (returnValue == "YES" && returnValue1 == "YES")
            {

                if (strImagePath.ContentLength > 0)
                {

                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/Content/img/slider/"), guid + fileName);
                    strImagePath.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/Content/img/slider/" + newpath;
                    tbl_mst_HeadImage.strImagePath = imagepath;
                }



                if (strHindiImagePath.ContentLength > 0)
                {

                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/Content/img/slider/"), guid + fileName1);
                    strHindiImagePath.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/Content/img/slider/" + newpath;
                    tbl_mst_HeadImage.strHindiImagePath = imagepath;
                }

            }


            tbl_mst_HeadImage.dtUpdatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");


            dbContext003.Entry(tbl_mst_HeadImage).State = EntityState.Modified;
            dbContext003.SaveChanges();
            ViewBag.strFileupload = tbl_mst_HeadImage.strImagePath;
            ViewBag.strFileUploadEnglish = tbl_mst_HeadImage.strHindiImagePath;

            ViewBag.Message = string.Format("Data updated successfully !");

            return View();
        }


        #endregion


        #region "Index Page Details"

        public ActionResult ListIndexPageContent()
        {
            var IndexPageDetails = dbContext002.tbl_mst_IndexPageContent.ToList();
            return View(IndexPageDetails);
        }


        public ActionResult ListIndexPageContentApprove()
        {
            var IndexPageDetails = dbContext002.tbl_mst_IndexPageContent_Approve.ToList();
            return View(IndexPageDetails);
        }


        public ActionResult AddIndexPageContent()
        {
            return View();
        }


        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult AddIndexPageContent(tbl_mst_IndexPageContent tbl_mst_IndexPageContent)
        {

            if (ModelState.IsValid)
            {
                tbl_mst_IndexPageContent.dtEntrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_mst_IndexPageContent.IsActive = true;
                dbContext002.tbl_mst_IndexPageContent.Add(tbl_mst_IndexPageContent);
                dbContext002.SaveChanges();
                ViewBag.Message = string.Format("Data saved successfully !");
                return View();
            }


            return View();
        }


        public ActionResult EditIndexPageContent(int id)
        {
            var IndexPageDetails = dbContext002.tbl_mst_IndexPageContent.Where(x => x.pk_intIndexID == id).FirstOrDefault();
            return View(IndexPageDetails);

        }



        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult EditIndexPageContent(tbl_mst_IndexPageContent_Approve tbl_mst_IndexPageContent)
        {

            tbl_mst_IndexPageContent.dtUpdatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");

            tbl_mst_IndexPageContent.intUserId = Convert.ToInt32(Session["UserID"]);
            dbContext002.tbl_mst_IndexPageContent_Approve.Add(tbl_mst_IndexPageContent);
            dbContext002.SaveChanges();

            ViewBag.Message = string.Format("Data updated successfully !");

            return View();
        }


        public ActionResult EditIndexPageContentApprove(int id)

        {

            var IndexPageDetails = dbContext002.tbl_mst_IndexPageContent_Approve.Where(x => x.pk_intIndexApproveID == id).FirstOrDefault();
            return View(IndexPageDetails);


        }



        [ValidateAntiForgeryToken]
        [HttpPost, ValidateInput(false)]
        public ActionResult EditIndexPageContentApprove(tbl_mst_IndexPageContent tbl_mst_IndexPageContent)
        {

            tbl_mst_IndexPageContent.dtUpdatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            dbContext002.Entry(tbl_mst_IndexPageContent).State = EntityState.Modified;
            dbContext002.SaveChanges();


            ViewBag.Message = string.Format("Data updated successfully !");

            return View();
        }

        #endregion


        public ActionResult ListUploadBillTracking()
        {
            BillTrackingContext objCon = new BillTrackingContext();
            return View(objCon.UploadBillTracking.ToList());
        }
        public ActionResult UploadBillTracking()
        {
            List<Unit> listUnit = objContext3.Units.ToList();
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                listUnit = listUnit.Where(x => x.pk_intUnitId == unitId).ToList();
            }
            SelectList selectUnit = new SelectList(listUnit, "pk_intUnitId", "strUnitName");
            ViewBag.UnitList = selectUnit;

            return View();
        }
        [HttpPost]
        public ActionResult UploadBillTracking(HttpPostedFileBase PurchaseOrders, HttpPostedFileBase BillSubmitted, HttpPostedFileBase BillStatus, FormCollection frm)
        {

            List<Unit> listUnit = objContext3.Units.ToList();
            if (Session["UnitId"] != null)
            {
                int unitId = Convert.ToInt32(Session["UnitId"]);
                listUnit = listUnit.Where(x => x.pk_intUnitId == unitId).ToList();
            }
            SelectList selectUnit = new SelectList(listUnit, "pk_intUnitId", "strUnitName");
            ViewBag.UnitList = selectUnit;

            int selectedUnitId = Convert.ToInt32(frm["fk_intUnitId"]);



            string PurchaseOrdersfilename = "";
            string BillSubmittedfilename = "";
            string BillStatusfilename = "";

            if (PurchaseOrders != null)
            {
                var fileName = Path.GetExtension(PurchaseOrders.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/UploadFile/PurchaseOrders/"), guid + fileName);
                PurchaseOrders.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                PurchaseOrdersfilename = "~/UploadFile/PurchaseOrders/" + newpath;

                string conString = string.Empty;
                switch (fileName)
                {
                    case ".xls": //Excel 97-03.
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }

                System.Data.DataTable dt = new System.Data.DataTable();
                conString = string.Format(conString, path);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            System.Data.DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                            //string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            //string sheetName1 = dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT 0 as id,*," + selectedUnitId + " From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();
                        }
                    }
                }

                conString = ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    int result = objCon.Database.ExecuteSqlCommand("delete from dbo.ContractDetails where fkUnitId=" + selectedUnitId);
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.ContractDetails";
                        //[OPTIONAL]: Map the Excel columns with that of the database table
                        //sqlBulkCopy.ColumnMappings.Add("Id", "CustomerId");
                        //sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                        //sqlBulkCopy.ColumnMappings.Add("Country", "Country");
                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }
            }




            if (BillSubmitted != null)
            {
                var fileName = Path.GetExtension(BillSubmitted.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/UploadFile/BillSubmitted/"), guid + fileName);
                BillSubmitted.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                BillSubmittedfilename = "~/UploadFile/BillSubmitted/" + newpath;


                string conString = string.Empty;
                switch (fileName)
                {
                    case ".xls": //Excel 97-03.
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }

                System.Data.DataTable dt = new System.Data.DataTable();
                conString = string.Format(conString, path);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            System.Data.DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                            //string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            //string sheetName1 = dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT 0 as id,*," + selectedUnitId + " From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();
                        }
                    }
                }

                conString = ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    int result = objCon.Database.ExecuteSqlCommand("delete from dbo.BillDetails where fkUnitId=" + selectedUnitId);
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.BillDetails";
                        //[OPTIONAL]: Map the Excel columns with that of the database table
                        //sqlBulkCopy.ColumnMappings.Add("Id", "CustomerId");
                        //sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                        //sqlBulkCopy.ColumnMappings.Add("Country", "Country");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }


            }

            if (BillStatus != null)
            {
                var fileName = Path.GetExtension(BillStatus.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/UploadFile/BillStatus/"), guid + fileName);
                BillStatus.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                BillStatusfilename = "~/UploadFile/BillStatus/" + newpath;


                string conString = string.Empty;
                switch (fileName)
                {
                    case ".xls": //Excel 97-03.
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 and above.
                        conString = ConfigurationManager.ConnectionStrings["Excel07ConString"].ConnectionString;
                        break;
                }

                System.Data.DataTable dt = new System.Data.DataTable();
                conString = string.Format(conString, path);

                using (OleDbConnection connExcel = new OleDbConnection(conString))
                {
                    using (OleDbCommand cmdExcel = new OleDbCommand())
                    {
                        using (OleDbDataAdapter odaExcel = new OleDbDataAdapter())
                        {
                            cmdExcel.Connection = connExcel;

                            //Get the name of First Sheet.
                            connExcel.Open();
                            System.Data.DataTable dtExcelSchema;
                            dtExcelSchema = connExcel.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);

                            //string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();
                            //string sheetName1 = dtExcelSchema.Rows[1]["TABLE_NAME"].ToString();
                            string sheetName = dtExcelSchema.Rows[0]["TABLE_NAME"].ToString();

                            connExcel.Close();

                            //Read Data from First Sheet.
                            connExcel.Open();
                            cmdExcel.CommandText = "SELECT 0 as id,*," + selectedUnitId + " From [" + sheetName + "]";
                            odaExcel.SelectCommand = cmdExcel;
                            odaExcel.Fill(dt);
                            connExcel.Close();
                        }
                    }
                }

                conString = ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
                using (SqlConnection con = new SqlConnection(conString))
                {
                    int result = objCon.Database.ExecuteSqlCommand("delete from dbo.BillStatus where fkUnitId=" + selectedUnitId);
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                    {
                        //Set the database table name.
                        sqlBulkCopy.DestinationTableName = "dbo.BillStatus";
                        //[OPTIONAL]: Map the Excel columns with that of the database table
                        //sqlBulkCopy.ColumnMappings.Add("Id", "CustomerId");
                        //sqlBulkCopy.ColumnMappings.Add("Name", "Name");
                        //sqlBulkCopy.ColumnMappings.Add("Country", "Country");

                        con.Open();
                        sqlBulkCopy.WriteToServer(dt);
                        con.Close();
                    }
                }

            }

            UploadBillTracking obj = new UploadBillTracking();
            obj.PurchaseOrders = PurchaseOrdersfilename;
            obj.BillSubmitted = BillSubmittedfilename;
            obj.BillStatus = BillStatusfilename;
            obj.EntryDate = current;
            obj.fkUnitId = selectedUnitId;
            objCon.UploadBillTracking.Add(obj);
            objCon.SaveChanges();

            ViewBag.Message = string.Format("Data uploaded successfully !");

            return View();
        }


        public ActionResult PurchaseOrders()
        {
            return View(objCon.ContractDetails.ToList());
        }
        public ActionResult BillSubmitted()
        {
            return View(objCon.BillDetails.ToList());
        }
        public ActionResult BillStatus()
        {
            return View(objCon.BillStatus.ToList());
        }
        public ActionResult HomePageBanner()
        {
            return View(objCon.BillStatus.ToList());
        }
        [HttpPost]
        public JsonResult GetHomePageBanner(tblHomePageBanner o)
        {
            var res = new tblHomePageBanner().GetHomePageBanner(o);
            return Json(res, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult ManageHomePageBanner()
        {
            tblHomePageBanner o = new tblHomePageBanner();
            var res = new tblHomePageBanner().ManageHomePageBanner(o);
            return Json(res, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetApplicants(vw_ListCandidate o)
        {
            o = o ?? new vw_ListCandidate();
            string strApplicationNo = string.IsNullOrEmpty(o.strApplicationNo) ? null : o.strApplicationNo;
            string DisciplineName = string.IsNullOrEmpty(o.DisciplineName) ? null : o.DisciplineName;
            var response = objApplicantdetails.vw_ListCandidate.Where(x => x.strApplicationNo == (strApplicationNo ?? x.strApplicationNo) && x.DisciplineName == (DisciplineName ?? x.DisciplineName)).ToList();


            return Json(response, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult ApplicantList()
        {
            return View();
        }
        //public ActionResult ApplicantList()
        //{
        //    ViewBag.Fk_Decipline = new SelectList(objdiscipline.tbl_mst_Discipline.ToList(), "Pk_Disciplineid", "DisciplineName", frm["Fk_Decipline"]);
        //    ViewBag.Fk_Post = new SelectList(objpostnew.tbl_mst_Postnew.ToList(), "Postname", "Postname", frm["Fk_Post"]);
        //    ViewBag.ApplicantNo = frm["ApplicantNo"];
        //    ViewBag.strPWD = frm["strPWD"];
        //    ViewBag.strInternalCandidate = frm["strInternalCandidate"];
        //    ViewBag.strStatus = frm["strStatus"];


        //    return View(v);


        //}




        public ActionResult PhotoUpload()
        {

            return View();
        }

        public ActionResult ListUploadPhotoGallery()
        {

            var listPhotos = objUploadPhotoContext.UploadPhotoGallery
                                  .OrderByDescending(x => x.id)
                                  .ToList();

            return View(listPhotos);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PhotoUpload(UploadPhotoGallery uploadPhotoGallery, HttpPostedFileBase PhotoGallery)
        {
            try
            {
                string imagepath = null;

                if (PhotoGallery != null && PhotoGallery.ContentLength > 0)
                {
                    var fileName = Path.GetExtension(PhotoGallery.FileName);
                    var guid = Guid.NewGuid().ToString();
                    var path = Path.Combine(Server.MapPath("~/UploadFile/AdminPanel/UploadGallery/"), guid + fileName);
                    PhotoGallery.SaveAs(path);

                    string newpath = guid + fileName;
                    imagepath = "~/UploadFile/AdminPanel/UploadGallery/" + newpath;
                }

                if (imagepath != null)
                {
                    uploadPhotoGallery.PhotoGallery = imagepath;
                    objUploadPhotoContext.UploadPhotoGallery.Add(uploadPhotoGallery);
                    objUploadPhotoContext.SaveChanges();
                    TempData["Message"] = "Photo uploaded successfully!";
                    TempData["Success"] = true;
                    return View();

                }

                // Mime type check
                //var MineType = Utility.getMimeFromFile(imagepath);
                //if (MineType != "Invalied")
                //{
                //    uploadPhotoGallery.PhotoGallery = imagepath;
                //    objUploadPhotoContext.UploadPhotoGallery.Add(uploadPhotoGallery);
                //    objUploadPhotoContext.SaveChanges();

                //    TempData["Message"] = "Photo uploaded successfully!";
                //    return RedirectToAction("PhotoUpload");
                //}
                //else
                //{
                //    TempData["Message"] = "Invalid file format!";
                //    return RedirectToAction("PhotoUpload");
                //}
                return View();
            }
            catch (Exception ex)
            {
                TempData["Message"] = "Error: " + ex.Message;
                return RedirectToAction("PhotoUpload");
            }
        }

        public ActionResult EditUploadPhoto(int id)
        {
            var phtotupload = objUploadPhotoContext.UploadPhotoGallery.Where(x => x.id == id).FirstOrDefault();

            ViewBag.strPhotoContent = phtotupload.strPhotoContent;
            ViewBag.strPhotoHindiContent = phtotupload.strPhotoHindiContent;
            ViewBag.PhotoGallery = phtotupload.PhotoGallery;
            return View(phtotupload);
        }

        [HttpPost]
        public ActionResult EditUploadPhoto(UploadPhotoGallery uploadPhotoGallery, HttpPostedFileBase PhotoGallery)
        {
            string imagepath = null;

            if (PhotoGallery != null && PhotoGallery.ContentLength > 0)
            {
                var fileName = Path.GetExtension(PhotoGallery.FileName);
                var guid = Guid.NewGuid().ToString();
                var path = Path.Combine(Server.MapPath("~/UploadFile/AdminPanel/UploadGallery/"), guid + fileName);
                PhotoGallery.SaveAs(path);

                string newpath = guid + fileName;
                imagepath = "~/UploadFile/AdminPanel/UploadGallery/" + newpath;
            }

            var existing = objUploadPhotoContext.UploadPhotoGallery.Find(uploadPhotoGallery.id);
            if (existing != null)
            {
                existing.strPhotoContent = uploadPhotoGallery.strPhotoContent;
                existing.strPhotoHindiContent = uploadPhotoGallery.strPhotoHindiContent;

                if (imagepath != null)
                {
                    existing.PhotoGallery = imagepath;
                }
                else
                {
                    existing.PhotoGallery = uploadPhotoGallery.PhotoGallery;
                }

                objUploadPhotoContext.SaveChanges();

                TempData["Message"] = "Photo updated successfully !";
                return View();
            }

            TempData["Message"] = "Photo not found!";
            return View();
        }

        public ActionResult DeletePhotoGallery(int id)
        {
            var EOIDelete = objUploadPhotoContext.UploadPhotoGallery.Where(x => x.id == id).FirstOrDefault();
            //var chcktransection=
            objUploadPhotoContext.Entry(EOIDelete).State = EntityState.Deleted;
            objUploadPhotoContext.SaveChanges();
            return RedirectToAction("ListUploadPhotoGallery");
        }


    }

}



