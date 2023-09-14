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
using System.Data.Entity;

namespace Hindustancopperlimited.Controllers
{
    public class VigilanceController : Controller
    {
        //
        // GET: /Vigilance/


        T_GrievanceMasterContext objT_GrievanceMaster = new T_GrievanceMasterContext();
        vw_compliantdetailscontext objcomplaintdetails = new vw_compliantdetailscontext();
        AdminLoginContext db = new AdminLoginContext();
        tbl_mstPageDetailContext dbContext001 = new tbl_mstPageDetailContext();
        public VigilanceController()
        {
        }
        

        public ActionResult vigilance()
        {
            ViewBag.vigilance = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Structure & Function").FirstOrDefault().strPageDetails;
            return View();
        }
        public ActionResult ComplaintDetails(int id)
        {
            var complaint = objcomplaintdetails.vw_compliantdetails.Where(x => x.intGrievanceId == id).FirstOrDefault();
            ViewData["regno."] = complaint.vchCompRegNo;
            ViewBag.str_upload1 = complaint.str_upload1;
            ViewBag.str_upload2 = complaint.str_upload2;
            return View(complaint);
        }
        
        public ActionResult Status_Complaint()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Status_Complaint( FormCollection frm)
        {
            
            //return RedirectToAction("Login/"+);
              if (ModelState.IsValid)
            {
               
                    string regno = frm["vchCompRegNo"].ToString();
                 
                   DateTime dob = Convert.ToDateTime(frm["dtmDob"]);
                    var loginuser = objT_GrievanceMaster.T_GrievanceMaster.Where(x => x.vchCompRegNo==regno && x.dtmDob==dob).FirstOrDefault();
                    if (loginuser != null)
                    {

                        var id = loginuser.intGrievanceId;
                        return RedirectToAction("ComplaintDetails/" + id);
                    }
                    else
                    {
                        ViewBag.Message = string.Format("Invalid Registration No. or Date of Birth.");
                        return View();
                    }
                }

            

            return View();

        }
        

        public ActionResult Notice_Article()
        {
            ViewBag.Notice_Article = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "NOTICE /ARTICLES").FirstOrDefault().strPageDetails;
            return View();
        }
        public ActionResult contactUs_Vigilance()
        {
            ViewBag.contactUs_Vigilance = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "VIGILANCE CONTACT US").FirstOrDefault().strPageDetails;
            return View();
        }

       [HttpGet]
        public ActionResult complaint()
        {
                       return View();
        }

        [HttpPost]
       public ActionResult complaint(FormCollection frm, T_GrievanceMaster T_GrievanceMaster)
       {

            
           if (ModelState.IsValid)
           {
               HttpPostedFileBase vchFileName = Request.Files["vchFileName"];

               if (vchFileName.ContentLength > 0)
               {
                   var fileExtension = Path.GetExtension(vchFileName.FileName);

                   var AutoGenFileName = "Grievance" + "-" + System.DateTime.Now.Ticks.ToString();
                   var path = Path.Combine(Server.MapPath("~/Upload/Grievance/"), AutoGenFileName + fileExtension);
                   vchFileName.SaveAs(path);
                   string fl = path.Substring(path.LastIndexOf("\\"));
                   string[] split = fl.Split('\\');
                   string newpath = split[1];
                   string GrvFilepath = "~/Upload/Grievance/" + newpath;
                   T_GrievanceMaster.vchFileName = GrvFilepath;
               }
               string id = objT_GrievanceMaster.AutocomplaintID();
               T_GrievanceMaster.vchCompRegNo = id;
               T_GrievanceMaster.dtmCompRegDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
               objT_GrievanceMaster.T_GrievanceMaster.Add(T_GrievanceMaster);
               Utility.SendEmail(frm["vchEmail"].ToString(), "Complaint No.", "Your Complaint no. is :" + id);
               Utility.SendEmail("sunil_p@hindustancopper.com", "Lodge complaint mail", "Your Complaint no. is :" + id);
               objT_GrievanceMaster.SaveChanges();
               ViewBag.Message = "Your Complaint have been saved Successfull!!Please Check Your Email";
               ModelState.Clear();
           }
           else
           {
               ViewBag.Message = "Error In Data Saving.";

           }

           return View();
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

                var pass =Utility.Encrypt(frm["strUsercurrentPwd"]);
                string UserName = Session["UserName"].ToString();
                var Login = db.M_UserMaster.Where(a => a.vchUserName.Equals(UserName) && a.vchPassword.Equals(pass)).FirstOrDefault();


                if (frm["strUserPwd"] == frm["strUserRePwd"])
                {
                    Login.vchPassword = Utility.Encrypt(frm["strUserPwd"]);
                    db.Entry(Login).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                ViewBag.Message = string.Format("Password and Re-Password do not match.");
                return View(Login);
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

        public ActionResult Login(M_UserMaster objUser, FormCollection frm)
        {
            if (ModelState.IsValid)
            {
                if (frm["forEmail"] != null)
                {
                    string Email = frm["forEmail"].ToString();
                    var loginuser = db.M_UserMaster.Where(a => a.vchEmailId.Equals(Email)).FirstOrDefault();
                    ViewBag.Message = string.Format("Please check your email.");
                    Utility.SendEmail(frm["forEmail"].ToString(), "Password", "Your Password is :" + Utility.Decrypt(loginuser.vchPassword));

                }
                else
                {
                     //captcha
                    if (Session["ans"].ToString() != frm["answer"])
                    {
                        ViewBag.Message = string.Format("Wrong answer.");
                        return View();
                    }
                    //captcha

                    else
                    {

                        var pass = Utility.Encrypt(objUser.vchPassword);
                        var decryptpass = Utility.Decrypt(pass);

                        var loginuser = db.M_UserMaster.Where(a => a.vchUserName.Equals(objUser.vchUserName) && a.vchPassword.Equals(pass)).FirstOrDefault();
                        if (loginuser != null)
                        {
                            Session["UserID"] = loginuser.pk_intUserId;
                            Session["UserName"] = loginuser.vchUserName.ToString();
                            Session["strEmail"] = loginuser.vchEmailId.ToString();

                            if (loginuser.vchAdminPrev == "Yes")
                            {
                                Session["strMenuRightID"] = "51";
                            }
                            else
                            {
                                Session["strMenuRightID"] = "47";
                            }
                            Session["UnitId"] = loginuser.vchUnitId;
                            Session["UserType"] = loginuser.vchAdminPrev;
                            Session["Designation"] = loginuser.vchDesigId;
                            Session["code"] = "0";
                            Session["UserRegion"] = "All";

                            if (Session["UserType"].ToString() == "Super Admin")
                            {
                                Session["strMenuRightID"] = "0";
                            }

                            SessionContext.SetAuthenticationTokenforVigilance(Session["UserName"].ToString(), false, loginuser);
                            return RedirectToAction("Dashboard", "Admin");
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
            return RedirectToAction("login");
        }


    }
}
