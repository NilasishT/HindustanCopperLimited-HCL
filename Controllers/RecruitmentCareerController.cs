using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Models;

using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using Hindustancopperlimited.GlobalClass;
using System.Text;
using System.Security.Cryptography;
using System.Data.Entity.Validation;
using System.Web.Security;
using System.Web.UI;
using Microsoft.Office.Interop.Excel;

using System.Data.Entity.Infrastructure;
using System.Data.Entity;

namespace Hindustancopperlimited.Controllers
{
    public class RecruitmentCareerController : Controller
    {
        tbl_mst_CandidateRegistrationForRecruitmentContext objContext;
        DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        Vw_CandidateRegistrationcontext objCandidateRegistration = new Vw_CandidateRegistrationcontext();
        tbl_mst_statecontext objstate = new tbl_mst_statecontext();
        tbl_mst_coursecontext objcourse = new tbl_mst_coursecontext();
        tbl_mst_PostContext objPost = new tbl_mst_PostContext();
        tbl_employmentnoticecontext objtbl_employmentnotice = new tbl_employmentnoticecontext();
        tbl_transaction_Postcriteriacontext objpostcriteria = new tbl_transaction_Postcriteriacontext();
        Vw_Postdesiciplinedetailscontext objpostdesicipline = new Vw_Postdesiciplinedetailscontext();
        tbl_mst_PWDCategorycontext objPWDCategory = new tbl_mst_PWDCategorycontext();
        tbl_mst_Postnewcontext objGrade_Designation = new tbl_mst_Postnewcontext();
        tbl_mst_CandidateQualificationContext tblQulifi = new tbl_mst_CandidateQualificationContext();
        tbl_mst_CandidateExperienceContext tblExperience = new tbl_mst_CandidateExperienceContext();
        tbl_mst_CandidatePublicationPaperPresentationContext objPublicationcon = new tbl_mst_CandidatePublicationPaperPresentationContext();
        tbl_mst_CandidateAwardScholarshipContext objAwardcon = new tbl_mst_CandidateAwardScholarshipContext();
        tbl_mst_candidatephotouploadcontext objcandidatephotoupload = new tbl_mst_candidatephotouploadcontext();
        tbl_mst_CandidatePersonalDetailscontext objcanpersonaldetails = new tbl_mst_CandidatePersonalDetailscontext();
        Vw_Applicationdetailscontext objAcknowledgement = new Vw_Applicationdetailscontext();
        CasteContext objCast = new CasteContext();
        tbl_mst_gendercontext objGender = new tbl_mst_gendercontext();
        tbl_mst_CandidateOtherDetailsContext objOtherDetailsContext = new tbl_mst_CandidateOtherDetailsContext();
        tbl_mst_CandidateDDDetailsContext objtbl_mst_CandidateDDDetailsContext = new tbl_mst_CandidateDDDetailsContext();
        tbl_temp_CandidateApplicationDetailsContext objtbl_temp_CandidateApplicationDetails = new tbl_temp_CandidateApplicationDetailsContext();
        tbl_mst_Postnewcontext objpostnew = new tbl_mst_Postnewcontext();
        tbl_mstOrganisationTypeContext objOType = new tbl_mstOrganisationTypeContext();
        tbl_mstAgeRelaxationContext objAgeRelaxation = new tbl_mstAgeRelaxationContext();
        tbl_mst_DisciplineContext dc = new tbl_mst_DisciplineContext();
        tbl_transaction_Postcriteriacontext objqualification = new tbl_transaction_Postcriteriacontext();

        public RecruitmentCareerController()
        {
            objContext = new tbl_mst_CandidateRegistrationForRecruitmentContext();

        }

        public ActionResult RegistrationForRecruitment()
        {
            if (current <= Convert.ToDateTime("14/10/2018"))
            {
                return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            }
            Random r = new Random();
            int num1 = r.Next(100000, 999999);
            tbl_mst_CandidateRegistrationForRecruitment obj = new tbl_mst_CandidateRegistrationForRecruitment();
            obj.strpassword = num1.ToString();
            Session["autuPassword"] = num1.ToString();
            return View(obj);
        }



        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult RegistrationForRecruitment(tbl_mst_CandidateRegistrationForRecruitment CandidateRegistrationForRecruitment, FormCollection frm)
        {
            if (current >= Convert.ToDateTime("14/10/2018"))
            {
                return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            }

            if (ModelState.IsValid)
            {
                int checkEmail = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(x => x.strEmail == CandidateRegistrationForRecruitment.strEmail).ToList().Count();

                if (checkEmail == 0)
                {
                    if (Session["autuPassword"] != null)
                    {
                        CandidateRegistrationForRecruitment.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        CandidateRegistrationForRecruitment.IsActive = "YES";
                        CandidateRegistrationForRecruitment.Is1stTime = "YES";
                        CandidateRegistrationForRecruitment.dtRegistrationDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        CandidateRegistrationForRecruitment.dtValidateUpto = DateTime.UtcNow.AddDays(365);
                        //CandidateRegistrationForRecruitment.strpassword = DateTime.Now.Ticks.ToString();
                        CandidateRegistrationForRecruitment.strUserName = CandidateRegistrationForRecruitment.strEmail;
                        objContext.tbl_mst_CandidateRegistrationForRecruitment.Add(CandidateRegistrationForRecruitment);
                        objContext.SaveChanges();
                        var message = "Thanks for registering with Hindustan Copper Limited  <br> Following are your login credentials: <br> Username: " + CandidateRegistrationForRecruitment.strEmail + "<br>Your password is :" + Session["autuPassword"] + "<br>Login Link : " + ConfigurationManager.AppSettings["loginLink"];

                        Utility.SendEmail(CandidateRegistrationForRecruitment.strEmail, "Your registration with HCL for online recruitment is successful.", message);
                        ViewBag.Message = string.Format("Registration is successful. Please check your email for login password!");
                        ModelState.Clear();
                    }
                    else
                    {
                        ViewBag.Message = string.Format("Please try again!");
                    }
                }
                else
                {
                    ViewBag.Message = string.Format("The email id already registered!");
                }
                return View();
            }


            return View();

        }

        // For Candidate Login

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
         
        public ActionResult CandidateLogin(string id)
        {
            //captcha
            recaptcha();
            //captcha
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CandidateLogin(tbl_mst_CandidateRegistrationForRecruitment tbl_mst_CandidateRegistrationForRecruitment, FormCollection frm, string id)
        {

            if (frm["forEmail"] != null)
            {
                string Email = frm["forEmail"].ToString();
                var loginuser = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(a => a.strEmail.Equals(Email)).FirstOrDefault();
                ViewBag.Message = string.Format("Please check your email.");


                string password = frm["forEmail"].ToString();
                var loginuser1 = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(a => a.strpassword.Equals(password)).FirstOrDefault();
                ViewBag.Message = string.Format("Please check your Password.");

                //Utility.SendEmail(frm["forEmail"].ToString(), "Password", "Your Password is :" + Decrypt(loginuser.strpassword));

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

                    //var pass = Encrypt(tbl_mst_CandidateRegistrationForRecruitment.strpassword);
                    //var decryptpass = Decrypt(pass);

                    var loginuser = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(a => a.strEmail.Equals(tbl_mst_CandidateRegistrationForRecruitment.strEmail) && a.strpassword.Equals(tbl_mst_CandidateRegistrationForRecruitment.strpassword)).FirstOrDefault();
                    if (loginuser != null)
                    {
                        Session["UserID"] = loginuser.Candidate_Pk_intID.ToString();
                        Session["password"] = loginuser.strpassword.ToString();
                        Session["strEmail"] = loginuser.strEmail.ToString();
                        Session["loginType"] = "Candidate";
                        Session["UserType"] = "Candidate";


                        //  SessionContext.SetAuthenticationToken(Session["UserName"].ToString(), false, loginuser);
                        if (id != null)
                        {
                            return RedirectToAction("CandidatePersonalDetails/" + id, "RecruitmentCareer");
                        }
                        else if (loginuser.Is1stTime == "YES")
                        {
                            return RedirectToAction("ChangePassword", "RecruitmentCareer");
                        }
                        else
                        {
                            //return RedirectToAction("Logout", "RecruitmentCareer");
                            int candidateId = Convert.ToInt32(Session["UserID"]);
                            var candidatedetails = objAcknowledgement.Vw_Applicationdetails.Where(a => a.fk_CandidateId == candidateId).OrderByDescending(x => x.strApplicationNo).ToList();
                            if (candidatedetails.ToList().Count() == 0)
                            {
                                return RedirectToAction("NoApplicantDashboard", "RecruitmentCareer");
                            }
                            else
                            {
                                return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
                            }

                            //if (loginuser.Candidate_Pk_intID == 135 || loginuser.Candidate_Pk_intID == 163 || loginuser.Candidate_Pk_intID == 224 || loginuser.Candidate_Pk_intID == 518 || loginuser.Candidate_Pk_intID == 1556 || loginuser.Candidate_Pk_intID == 2002 || loginuser.Candidate_Pk_intID == 2273 || loginuser.Candidate_Pk_intID == 4201 || loginuser.Candidate_Pk_intID == 17230 || loginuser.Candidate_Pk_intID == 20117 || loginuser.Candidate_Pk_intID == 30192 || loginuser.Candidate_Pk_intID == 30960 || loginuser.Candidate_Pk_intID == 32693 || loginuser.Candidate_Pk_intID == 50991 || loginuser.Candidate_Pk_intID == 7514 || loginuser.Candidate_Pk_intID == 8136 || loginuser.Candidate_Pk_intID == 20334 || loginuser.Candidate_Pk_intID == 28718)
                            //{
                            //    return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
                            //}
                            //else
                            //{
                            //    return RedirectToAction("Logout", "RecruitmentCareer");
                            //}
                        }
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



            return View();

        }


        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            Request.Cookies.Clear();
            Session["UserID"] = null;
            Session["password"] = null;
            Session["strEmail"] = null;
            Session["loginType"] = null;
            Session["UserType"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassword()
        {
            //if (current >= Convert.ToDateTime("14/10/2018"))
            //{
            //    return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            //}

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword(FormCollection frm)
        {
            //if (current >= Convert.ToDateTime("14/10/2018"))
            //{
            //    return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            //}

            try
            {

                string UserName = Session["strEmail"].ToString();
                string password = frm["strUsercurrentPwd"].ToString();


                var CandidateRegistration = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(a => a.strEmail.Equals(UserName) && a.strpassword.Equals(password)).FirstOrDefault();


                if (frm["strUserPwd"] == frm["strUserRePwd"])
                {
                    CandidateRegistration.Is1stTime = "NO";
                    CandidateRegistration.strpassword = frm["strUserPwd"];
                    objContext.Entry(CandidateRegistration).State = EntityState.Modified;
                    objContext.SaveChanges();
                    return RedirectToAction("CandidateLogin");
                }
                ViewBag.Message = string.Format("Password and Re-Password do not match.");
                return View(CandidateRegistration);
            }
            catch
            {
                ViewBag.Message = string.Format("Password and Re-Password do not match.");
                return View();
            }
        }

        // forgot password

        public ActionResult ForgotPassword()
        {
            //if (current >= Convert.ToDateTime("14/10/2018"))
            //{
            //    return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            //}

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]

        public ActionResult ForgotPassword(tbl_mst_CandidateRegistrationForRecruitment tbl_mst_CandidateRegistrationForRecruitment, FormCollection frm)
        {
            //if (current >= Convert.ToDateTime("14/10/2018"))
            //{
            //    return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            //}
            string email = frm["strEmail"].ToString();
            DateTime DOB = Convert.ToDateTime(frm["dtDOB"]);
            var CandidateRegistratio = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(x => x.strEmail == email && x.dtDOB == DOB).FirstOrDefault();

            if (CandidateRegistratio == null)
            {
                ViewBag.Message = "Please put the currect value.";
            }
            else
            {
                tbl_forgetPassword obj = new tbl_forgetPassword();
                obj.strAutoId = CandidateRegistratio.Candidate_Code;
                obj.intCandidateId = CandidateRegistratio.Candidate_Pk_intID;
                obj.dtDatetime = current;
                objContext.tbl_forgetPassword.Add(obj);
                objContext.SaveChanges();

                Utility.SendEmail(CandidateRegistratio.strEmail, "Set New Password.", "Please click the link bellow :" + ConfigurationManager.AppSettings["forgetPassword"] + "?id=" + Utility.Encrypt(obj.strAutoId));
                ViewBag.Message = "Please check your email.";
            }
            return View();

        }

        public ActionResult SetPassword(string id)
        {
            //if (current >= Convert.ToDateTime("14/10/2018"))
            //{
            //    return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            //}
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SetPassword(FormCollection frm, string id)
        {
            //if (current >= Convert.ToDateTime("14/10/2018"))
            //{
            //    return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            //}
            try
            {
                id = Utility.Decrypt(id.Replace(" ", "+"));
                int candidateId = 0;
                //current = current.AddMinutes(-3);
                //&& x.dtDatetime > current
                var details = objContext.tbl_forgetPassword.Where(x => x.strAutoId == id).FirstOrDefault();
                if (details == null)
                {
                    ViewBag.Message = string.Format("Your url has expired.");
                    return View();
                }
                else
                {
                    candidateId = details.intCandidateId;

                    var CandidateRegistration = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(a => a.Candidate_Pk_intID == candidateId).FirstOrDefault();
                    if (frm["strUserPwd"] == frm["strUserRePwd"])
                    {
                        CandidateRegistration.Is1stTime = "NO";
                        CandidateRegistration.strpassword = frm["strUserPwd"];
                        objContext.Entry(CandidateRegistration).State = EntityState.Modified;
                        objContext.SaveChanges();
                        return RedirectToAction("CandidateLogin");
                    }
                    ViewBag.Message = string.Format("Password and Re-Password do not match.");
                    return View(CandidateRegistration);
                }
            }
            catch
            {
                ViewBag.Message = string.Format("error.");
                return View();
            }
        }

        //Photo Upload objcandidatephotoupload

        //public ActionResult CandidatePersonalDetailsphotoupload(string id)
        //{

        //    TempData["id"] = id;
        //    return View();
        //}
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult CandidatePersonalDetailsphotoupload(tbl_mst_candidatephotoupload tbl_mst_candidatephotoupload, FormCollection frm)
        //{
        //    string id = TempData["id"].ToString();
        //    var appno = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.strApplicationNo == id).FirstOrDefault();

        //    var Photoupload = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.str_applicationno == id);
        //    foreach (var candidatephotoupload in Photoupload)
        //    {
        //        objcandidatephotoupload.Entry(candidatephotoupload).State = EntityState.Deleted;
        //    }
        //    objcandidatephotoupload.SaveChanges();


        //    HttpPostedFileBase str_uploadphoto = Request.Files["str_uploadphoto"];
        //    HttpPostedFileBase str_uploadsignature = Request.Files["str_uploadsignature"];

        //    if (str_uploadphoto.ContentLength > 0)
        //    {
        //        var fileExtension = Path.GetExtension(str_uploadphoto.FileName);
        //        var AutoGenFileName = "Photo" + "-" + System.DateTime.Now.Ticks.ToString();
        //        var path = Path.Combine(Server.MapPath("~/Upload/Photo/"), AutoGenFileName + fileExtension);
        //        str_uploadphoto.SaveAs(path);
        //        string fl = path.Substring(path.LastIndexOf("\\"));
        //        string[] split = fl.Split('\\');
        //        string newpath = split[1];
        //        string imagepath = "~/Upload/Photo/" + newpath;
        //        tbl_mst_candidatephotoupload.str_uploadphoto = imagepath;

        //    }

        //    if (str_uploadsignature.ContentLength > 0)
        //    {
        //        var fileExtension = Path.GetExtension(str_uploadsignature.FileName);
        //        var AutoGenFileName = "Signature" + "-" + System.DateTime.Now.Ticks.ToString();
        //        var path = Path.Combine(Server.MapPath("~/Upload/Signature/"), AutoGenFileName + fileExtension);
        //        str_uploadsignature.SaveAs(path);
        //        string fl = path.Substring(path.LastIndexOf("\\"));
        //        string[] split = fl.Split('\\');
        //        string newpath = split[1];
        //        string imagepath = "~/Upload/Signature/" + newpath;
        //        tbl_mst_candidatephotoupload.str_uploadsignature = imagepath;

        //    }


        //    //string AcknowledgeId = objcandidatephotoupload.ACknowledgmentID();
        //    //tbl_mst_candidatephotoupload.str_acknowledgementno = AcknowledgeId;
        //    tbl_mst_candidatephotoupload.str_applicationno = id;
        //    tbl_mst_candidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        //    tbl_mst_candidatephotoupload.fk_intcandidateid = appno.fk_CandidateId;
        //    tbl_mst_candidatephotoupload.is_active = "YES";
        //    objcandidatephotoupload.tbl_mst_candidatephotoupload.Add(tbl_mst_candidatephotoupload);
        //    objcandidatephotoupload.SaveChanges();
        //    ViewBag.Message = string.Format("Data updated successfully!");

        //    //return View();
        //    return RedirectToAction("ApplicationPrint", "RecruitmentCareer", new { AppNo = id });
        //}



        public ActionResult CandidatePersonalDetails(string id)
        {

            if (current >= Convert.ToDateTime("14/10/2018"))
            {
                return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
            }

            string fstValue = "";
            string secValue = "";
            int idInt = 0;

            if (id.IndexOf('-') > 0)
            {
                fstValue = id.Split('-')[0];
                secValue = id.Split('-')[1];


                idInt = Convert.ToInt32(fstValue);

                int CandiadateId = Convert.ToInt32(Session["UserID"]);
                if (CandiadateId == 0)
                {
                    return RedirectToAction("CandidateLogin/" + id, "RecruitmentCareer");
                }
                else
                {
                    var tbl_mst_CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails_temp.Where(x => x.fk_CandidateId == CandiadateId).FirstOrDefault();
                    tbl_mst_CandidatePersonalDetails obj1 = new tbl_mst_CandidatePersonalDetails();

                    // Personal Information Bhashkar 21/09/2018 


                    obj1.Pk_int_CandidateRegistrationID = tbl_mst_CandidatePersonalDetails.Pk_int_CandidateRegistrationID;
                    obj1.fk_CandidateId = tbl_mst_CandidatePersonalDetails.fk_CandidateId;
                    obj1.strApplicantName = tbl_mst_CandidatePersonalDetails.strApplicantName;
                    obj1.dtDOB = tbl_mst_CandidatePersonalDetails.dtDOB;
                    obj1.strFatherName = tbl_mst_CandidatePersonalDetails.strFatherName;
                    obj1.strEmail = tbl_mst_CandidatePersonalDetails.strEmail;
                    obj1.strNationality = tbl_mst_CandidatePersonalDetails.strNationality;
                    obj1.strGender = tbl_mst_CandidatePersonalDetails.strGender;
                    obj1.strCategory = tbl_mst_CandidatePersonalDetails.strCategory;
                    obj1.strMaritalStatus = tbl_mst_CandidatePersonalDetails.strMaritalStatus;
                    obj1.strPWD = tbl_mst_CandidatePersonalDetails.strPWD;
                    obj1.strExserviceMan = tbl_mst_CandidatePersonalDetails.strExserviceMan;
                    obj1.strInternalCandidate = tbl_mst_CandidatePersonalDetails.strInternalCandidate;
                    obj1.strEmployedIn = tbl_mst_CandidatePersonalDetails.strEmployedIn;
                    obj1.strCorrespondenceAddress = tbl_mst_CandidatePersonalDetails.strCorrespondenceAddress;
                    obj1.strState = tbl_mst_CandidatePersonalDetails.strState;
                    obj1.strDistrict = tbl_mst_CandidatePersonalDetails.strDistrict;
                    obj1.strNearestPostOffice = tbl_mst_CandidatePersonalDetails.strNearestPostOffice;
                    obj1.strNearestPoliceStation = tbl_mst_CandidatePersonalDetails.strNearestPoliceStation;
                    obj1.strNearestRailwaystation = tbl_mst_CandidatePersonalDetails.strNearestRailwaystation;
                    obj1.strPin = tbl_mst_CandidatePersonalDetails.strPin;
                    obj1.strTelephone = tbl_mst_CandidatePersonalDetails.strTelephone;
                    obj1.strMobileNo = tbl_mst_CandidatePersonalDetails.strMobileNo;
                    obj1.strPermanentAddress = tbl_mst_CandidatePersonalDetails.strPermanentAddress;
                    obj1.strPermanentState = tbl_mst_CandidatePersonalDetails.strPermanentState;
                    obj1.strPermanentDistrict = tbl_mst_CandidatePersonalDetails.strPermanentDistrict;
                    obj1.strPermanentNearestPostOffice = tbl_mst_CandidatePersonalDetails.strPermanentNearestPostOffice;
                    obj1.strPermanentNearestPoliceStation = tbl_mst_CandidatePersonalDetails.strPermanentNearestPoliceStation;
                    obj1.strPermanentNearestRailwayStation = tbl_mst_CandidatePersonalDetails.strPermanentNearestRailwayStation;
                    obj1.strPermanentPinCode = tbl_mst_CandidatePersonalDetails.strPermanentPinCode;
                    obj1.strPermanentTelephoneNo = tbl_mst_CandidatePersonalDetails.strPermanentTelephoneNo;
                    obj1.strPermanentMobile1 = tbl_mst_CandidatePersonalDetails.strPermanentMobile1;
                    obj1.dt_updatedate = tbl_mst_CandidatePersonalDetails.dt_updatedate;
                    obj1.dt_entrydate = tbl_mst_CandidatePersonalDetails.dt_entrydate;
                    obj1.isactive = tbl_mst_CandidatePersonalDetails.isactive;
                    obj1.strsubcaste = tbl_mst_CandidatePersonalDetails.strsubcaste;
                    obj1.strcertificateno = tbl_mst_CandidatePersonalDetails.strcertificateno;
                    obj1.dt_certificateissuedate = tbl_mst_CandidatePersonalDetails.dt_certificateissuedate;
                    obj1.strcertificateissue = tbl_mst_CandidatePersonalDetails.strcertificateissue;
                    obj1.strexservicemanno = tbl_mst_CandidatePersonalDetails.strexservicemanno;
                    obj1.strDomicilestate = tbl_mst_CandidatePersonalDetails.strDomicilestate;
                    obj1.strtypeofdisable = tbl_mst_CandidatePersonalDetails.strtypeofdisable;
                    obj1.strcertificateno1 = tbl_mst_CandidatePersonalDetails.strcertificateno1;
                    obj1.dt_certificateissuedate1 = tbl_mst_CandidatePersonalDetails.dt_certificateissuedate1;
                    obj1.strcertificateissue1 = tbl_mst_CandidatePersonalDetails.strcertificateissue1;
                    obj1.stremployeecode = tbl_mst_CandidatePersonalDetails.stremployeecode;
                    obj1.strgrade = tbl_mst_CandidatePersonalDetails.strgrade;
                    obj1.strplaceposting = tbl_mst_CandidatePersonalDetails.strplaceposting;
                    obj1.strpresentdesignation = tbl_mst_CandidatePersonalDetails.strpresentdesignation;
                    obj1.dt_presententrydate = tbl_mst_CandidatePersonalDetails.dt_presententrydate;
                    obj1.strapplyproper = tbl_mst_CandidatePersonalDetails.strapplyproper;
                    obj1.fk_postid = tbl_mst_CandidatePersonalDetails.fk_postid;
                    obj1.strApplicationNo = tbl_mst_CandidatePersonalDetails.strApplicationNo;
                    obj1.fk_advertiseid = tbl_mst_CandidatePersonalDetails.fk_advertiseid;
                    obj1.str_status = tbl_mst_CandidatePersonalDetails.str_status;
                    obj1.is_freshers = tbl_mst_CandidatePersonalDetails.is_freshers;
                    obj1.fk_dicipline = tbl_mst_CandidatePersonalDetails.fk_dicipline;
                    obj1.strMotherName = tbl_mst_CandidatePersonalDetails.strMotherName;
                    obj1.strSpouseName = tbl_mst_CandidatePersonalDetails.strSpouseName;
                    obj1.strAlternate_EmaiID = tbl_mst_CandidatePersonalDetails.strAlternate_EmaiID;
                    obj1.strPANNo = tbl_mst_CandidatePersonalDetails.strPANNo;
                    obj1.strAadharNo = tbl_mst_CandidatePersonalDetails.strAadharNo;
                    obj1.strAadharNo = tbl_mst_CandidatePersonalDetails.strAadharNo;






                    ViewBag.addId = id;
                    ViewBag.Str_exampassed4 = new SelectList(objcourse.tbl_mst_course.ToList(), "Str_Coursename", "Str_Coursename");
                    ViewBag.Str_exampassed5 = new SelectList(objcourse.tbl_mst_course.ToList(), "Str_Coursename", "Str_Coursename");
                    var diciplineId = objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.Pk_Disciplineid == obj1.fk_dicipline).Select(x => x.fk_diciplineid).ToList();

                    ViewBag.fk_dicipline = new SelectList(dc.tbl_mst_Discipline.Where(t => diciplineId.Contains(t.Pk_Disciplineid)), "Pk_Disciplineid", "DisciplineName", obj1.fk_dicipline);
                    ViewBag.fk_postid = new SelectList((from s in objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.Pk_Postid == obj1.fk_postid).ToList()
                                                        select new
                                                        {
                                                            fk_postid = s.fk_postid,
                                                            FullName = s.Postname + " ( " + s.DisciplineName + " )"
                                                        }),
                          "fk_postid",
                          "FullName",
                           obj1.fk_postid);
                    ViewBag.fk_advertiseid = id;

                    // End Personal Information Bhashkar 21/09/2018 

                    // Educational Qualification Details Bhashkar 21/09/2018 

                    var postCaitareaDetails = objqualification.tbl_transaction_Postcriteria.Where(x => x.fk_postid == obj1.fk_postid && x.fk_advertisementid == obj1.fk_advertiseid).FirstOrDefault();
                    ViewData["hidMaxExpdate"] = postCaitareaDetails.dt_compareDate.Value.ToShortDateString().Replace("/", "-");

                    var castAll = postCaitareaDetails.str_caste;


                    if (postCaitareaDetails.strPostIsFreshersAllowed != "Yes")
                    {
                        ViewData["is_freshers"] = "No";
                    }
                    else
                    {
                        ViewData["is_freshers"] = "Yes";
                    }

                    string sampleSentence = postCaitareaDetails.str_qualification;
                    string[] words = System.Text.RegularExpressions.Regex.Split(sampleSentence, "@");
                    List<Qulification> fstSubject = new List<Qulification>();

                    foreach (var quliName in words)
                    {
                        Qulification qu = new Qulification() { str_qualification = quliName.Trim(' ') };
                        fstSubject.Add(qu);
                    }

                    int numberLoop = 0;
                    var educationAll = tblQulifi.tbl_mst_CandidateQualification_temp.Where(x => x.Fk_int_CandidateRegistrationID == obj1.fk_CandidateId && x.Application_No == obj1.strApplicationNo).ToList();


                    if (educationAll.Count() > 0)
                    {
                        ViewBag.EduQulifi = new SelectList(fstSubject, "str_qualification", "str_qualification", educationAll.FirstOrDefault().EduQulifi);
                        numberLoop = 2 + educationAll.FirstOrDefault().EduQulifi.Split(new[] { "WITH" }, StringSplitOptions.None).Length;
                        if (educationAll.Count() < numberLoop)
                        {
                            numberLoop = educationAll.Count();
                        }

                    }
                    else
                    {
                        ViewBag.EduQulifi = new SelectList(fstSubject, "str_qualification", "str_qualification");
                    }




                    string j = "";
                    int i = 0;
                    for (i = 0; i < numberLoop; i++)
                    {
                        if (i == 0)
                        {
                            j = "";
                        }
                        else
                        {
                            j = i.ToString();
                        }

                        ViewData["Str_exampassed" + j] = educationAll[i].Str_exampassed;
                        ViewData["Str_course" + j] = educationAll[i].Str_course;
                        ViewData["Str_board" + j] = educationAll[i].Str_board;
                        ViewData["Str_passingdetails" + j] = educationAll[i].Str_passingdetails;
                        if (educationAll[i].Str_passingyear != null && educationAll[i].Str_passingyear != "")
                        {
                            ViewData["Str_passingyear" + j] = Convert.ToDateTime(educationAll[i].Str_passingyear).ToShortDateString().Replace("/", "-");
                        }
                        ViewData["Str_duration" + j] = educationAll[i].Str_duration;
                        ViewData["Str_Marks" + j] = educationAll[i].Str_Marks;
                        ViewData["Str_division" + j] = educationAll[i].Str_division;
                        ViewData["StrRemarks" + j] = educationAll[i].StrRemarks;


                    }


                    j = "";

                    int k = 1;

                    for (; i < educationAll.Count; i++)
                    {

                        ViewData["others_exampassed" + k] = educationAll[i].Str_exampassed;
                        ViewData["others_course" + k] = educationAll[i].Str_course;
                        ViewData["others_board" + k] = educationAll[i].Str_board;
                        ViewData["others_passingdetails" + k] = educationAll[i].Str_passingdetails;
                        //ViewData["others_passingyear" + k] = educationAll[i].Str_passingyear;

                        if (educationAll[i].Str_passingyear != null && educationAll[i].Str_passingyear != "")
                        {
                            ViewData["others_passingyear" + k] = Convert.ToDateTime(educationAll[i].Str_passingyear).ToShortDateString().Replace("/", "-");
                        }

                        ViewData["others_duration" + k] = educationAll[i].Str_duration;
                        ViewData["others_Marks" + k] = educationAll[i].Str_Marks;
                        ViewData["others_division" + k] = educationAll[i].Str_division;
                        ViewData["others_Remarks" + k] = educationAll[i].StrRemarks;
                        k++;

                    }

                    //End  Educational Qualification Details Bhashkar 21/09/2018 




                    // Experience Details (Chronological Order - Starting with First Job) Bhashkar 21/09/2018 


                    ViewBag.str_organisationType = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType1 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType2 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType3 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType4 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    //NewAdd
                    ViewBag.str_organisationType5 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType6 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType7 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType8 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType9 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType10 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType11 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    //NewAdd


                    var expAll = tblExperience.tbl_mst_CandidateExperience_temp.Where(x => x.Fk_CandidateRegistrationID == obj1.fk_CandidateId && x.ApplicationNo == obj1.strApplicationNo).ToList();
                    numberLoop = expAll.Count();
                    j = "";
                    i = 0;
                    for (i = 0; i < numberLoop; i++)
                    {
                        if (i == 0)
                        {
                            j = "";
                        }
                        else
                        {
                            j = i.ToString();
                        }

                        ViewData["str_organisationType" + j] = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType", expAll[i].str_organisationType);
                        ViewData["StrEmploymentPresentStatus" + j] = expAll[i].StrEmploymentPresentStatus;
                        ViewData["str_organisation" + j] = expAll[i].str_organisation;
                        ViewData["Str_designation" + j] = expAll[i].Str_designation;
                        ViewData["str_CTC" + j] = expAll[i].str_CTC;
                        ViewData["str_PayScale" + j] = expAll[i].str_PayScale;
                        ViewData["dt_fromdate" + j] = expAll[i].dt_fromdate.ToShortDateString().Replace("/", "-");
                        ViewData["dt_todate" + j] = expAll[i].dt_todate.ToShortDateString().Replace("/", "-");
                        ViewData["str_noyears" + j] = expAll[i].str_noyears;
                    }

                    // End Experience Details (Chronological Order - Starting with First Job) Bhashkar 21/09/2018


                    //Experience in immediate next below Grade ( for PSU/Government/Semi-Government Employees ) Bhashkar 21/09/2018

                    var ImdNextBellowGrade = tblExperience.tbl_NextBelowGrade_temp.Where(x => x.Fk_CandidateRegistrationID == obj1.fk_CandidateId && x.strApplicationNo == obj1.strApplicationNo).ToList();

                    if (ImdNextBellowGrade.Count() > 0)
                    {
                        ViewData["strimmediateGrade"] = ImdNextBellowGrade.FirstOrDefault().strGrade;
                        ViewData["dt_immediatefromdate"] = ImdNextBellowGrade.FirstOrDefault().dtFromDate;
                        ViewData["dt_immediatetodate"] = ImdNextBellowGrade.FirstOrDefault().dtTodate;
                        ViewData["str_immediatenoyears"] = ImdNextBellowGrade.FirstOrDefault().strYear;
                    }

                    //End Experience in immediate next below Grade ( for PSU/Government/Semi-Government Employees ) Bhashkar 21/09/2018



                    //Award & Scholarship

                    var awardll = objAwardcon.tbl_mst_CandidateAwardScholarship_temp.Where(x => x.Fk_candidateregistration == obj1.fk_CandidateId && x.Application_No == obj1.strApplicationNo).ToList();
                    numberLoop = awardll.Count();
                    j = "";
                    i = 0;
                    for (i = 0; i < numberLoop; i++)
                    {
                        if (i == 0)
                        {
                            j = "";
                        }
                        else
                        {
                            j = i.ToString();
                        }
                        ViewData["straward" + j] = awardll[i].straward;
                    }


                    //End Award & Scholarship


                    //Publication & Paper Presentation
                    var Publication = objPublicationcon.tbl_mst_CandidatePublicationPaperPresentation_temp.Where(x => x.Fk_candidateregistration == obj1.fk_CandidateId && x.Application_No == obj1.strApplicationNo).ToList();
                    numberLoop = Publication.Count();
                    j = "";
                    i = 0;
                    for (i = 0; i < numberLoop; i++)
                    {
                        if (i == 0)
                        {
                            j = "";
                        }
                        else
                        {
                            j = i.ToString();
                        }
                        ViewData["str_Publication_PaperPresentation" + j] = Publication[i].str_Publication_PaperPresentation;
                    }
                    //End Publication & Paper Presentation


                    //Other Details Bhashkar 21/09/2018

                    var otherDetails = objOtherDetailsContext.tbl_mst_CandidateOtherDetails_temp.Where(x => x.Fk_CandidateRegistrationID == obj1.fk_CandidateId && x.strApplicationNo == obj1.strApplicationNo).ToList();

                    if (otherDetails.Count() > 0)
                    {
                        ViewData["strProfessionalBodies"] = otherDetails.FirstOrDefault().strProfessionalBodies;
                        ViewData["strJoiningTimeReq"] = otherDetails.FirstOrDefault().strJoiningTimeReq;
                        ViewData["strJoinEarly"] = otherDetails.FirstOrDefault().strJoinEarly;
                    }

                    //End Other Details Bhashkar 21/09/2018


                    //Upload Details Bhashkar 21/09/2018

                    var uploadDetails = objcandidatephotoupload.tbl_mst_candidatephotoupload_temp.Where(x => x.fk_intcandidateid == obj1.fk_CandidateId && x.str_applicationno == obj1.strApplicationNo).ToList();

                    if (uploadDetails.Count() > 0)
                    {
                        if (!string.IsNullOrEmpty(uploadDetails.FirstOrDefault().str_uploadphoto))
                        {
                            ViewData["hidstr_uploadphoto"] = Utility.ImageToBase64(Server.MapPath(uploadDetails.FirstOrDefault().str_uploadphoto));
                            ViewData["hiduploadphotopath"] = uploadDetails.FirstOrDefault().str_uploadphoto;
                        }
                        else
                        {
                            ViewData["hidstr_uploadphoto"] = "";
                            ViewData["hiduploadphotopath"] = "";
                        }
                        if (!string.IsNullOrEmpty(uploadDetails.FirstOrDefault().str_uploadsignature))
                        {
                            ViewData["hidstr_uploadsignature"] = Utility.ImageToBase64(Server.MapPath(uploadDetails.FirstOrDefault().str_uploadsignature));
                            ViewData["hiduploadsignaturepath"] = uploadDetails.FirstOrDefault().str_uploadsignature;
                        }
                        else
                        {
                            ViewData["hidstr_uploadsignature"] = "";
                            ViewData["hiduploadsignaturepath"] = "";
                        }

                    }

                    //End Other Details Bhashkar 21/09/2018


                    ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender", obj1.strGender);
                    //ViewBag.strCategory = new SelectList(objCast.Castes.OrderBy(x => x.strCasteName).ToList(), "strCasteName", "strCasteName", obj1.strCategory);

                    ViewBag.strCategory = new SelectList(objCast.Castes.Where(a => castAll.Contains(a.strCasteName)), "strCasteName", "strCasteName", obj1.strCategory);

                    ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName", obj1.strtypeofdisable);
                    ViewBag.strgrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName", obj1.strgrade);
                    //ViewBag.strimmediateGrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName");
                    //ViewBag.strpresentdesignation = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strDesignationName", "strDesignationName");

                    var loginDetails = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(x => x.Candidate_Pk_intID == CandiadateId).FirstOrDefault();

                    ViewBag.strApplicantName = loginDetails.strCandidateFName + " " + loginDetails.strCandidateMName + " " + loginDetails.strCandidateLName;
                    //ViewBag.dtDOB = loginDetails.dtDOB;


                    //ViewBag.strFatherName = loginDetails.strFatherName;
                    //ViewBag.strMotherName = loginDetails.strMotherName;
                    //ViewBag.strSpouseName = loginDetails.strSpouseName;
                    //ViewBag.strAlternate_EmaiID = loginDetails.strAlternate_EmaiID;
                    //ViewBag.strAadharNo = loginDetails.strAadharNo;
                    //ViewBag.strPANNo = loginDetails.strPANNo;
                    //ViewBag.strMobileNo = loginDetails.strMobileNumber;


                    //ViewBag.strEmail = loginDetails.strEmail;

                    ViewBag.strDomicilestate = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", obj1.strDomicilestate);

                    ViewBag.strState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", obj1.strState);
                    ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", obj1.strPermanentState);


                    return View(obj1);


                }
            }
            else
            {
                fstValue = id;
                idInt = Convert.ToInt32(fstValue);

                int CandiadateId = Convert.ToInt32(Session["UserID"]);
                if (CandiadateId == 0)
                {
                    return RedirectToAction("CandidateLogin/" + id, "RecruitmentCareer");
                }
                else
                {
                    var tbl_mst_CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == CandiadateId).FirstOrDefault();
                    ViewBag.addId = id;
                    ViewBag.Str_exampassed4 = new SelectList(objcourse.tbl_mst_course.ToList(), "Str_Coursename", "Str_Coursename");
                    ViewBag.Str_exampassed5 = new SelectList(objcourse.tbl_mst_course.ToList(), "Str_Coursename", "Str_Coursename");
                    var diciplineId = objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.fk_advertisementid == idInt).Select(x => x.fk_diciplineid).ToList();
                    ViewBag.fk_dicipline = new SelectList(dc.tbl_mst_Discipline.Where(t => diciplineId.Contains(t.Pk_Disciplineid)), "Pk_Disciplineid", "DisciplineName");
                    ViewBag.fk_postid = new SelectList((from s in objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.fk_advertisementid == idInt).ToList()
                                                        select new
                                                        {
                                                            fk_postid = s.fk_postid,
                                                            FullName = s.Postname + " ( " + s.DisciplineName + " )"
                                                        }),
                          "fk_postid",
                          "FullName",
                          null);

                    ViewBag.fk_advertiseid = id;
                    ViewBag.EduQulifi = new SelectList("", "");



                    ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender");
                    ViewBag.strCategory = new SelectList(objCast.Castes.OrderBy(x => x.strCasteName).ToList(), "strCasteName", "strCasteName");
                    ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName");
                    ViewBag.strgrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName");
                    //ViewBag.strimmediateGrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName");
                    //ViewBag.strpresentdesignation = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strDesignationName", "strDesignationName");

                    var loginDetails = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(x => x.Candidate_Pk_intID == CandiadateId).FirstOrDefault();

                    ViewBag.strApplicantName = loginDetails.strCandidateFName + " " + loginDetails.strCandidateMName + " " + loginDetails.strCandidateLName;
                    ViewBag.dtDOB = loginDetails.dtDOB;


                    ViewBag.strFatherName = loginDetails.strFatherName;
                    ViewBag.strMotherName = loginDetails.strMotherName;
                    ViewBag.strSpouseName = loginDetails.strSpouseName;
                    ViewBag.strAlternate_EmaiID = loginDetails.strAlternate_EmaiID;
                    ViewBag.strAadharNo = loginDetails.strAadharNo;
                    ViewBag.strPANNo = loginDetails.strPANNo;
                    ViewBag.strMobileNo = loginDetails.strMobileNumber;


                    ViewBag.strEmail = loginDetails.strEmail;

                    ViewBag.strDomicilestate = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");

                    ViewBag.strState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
                    ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");

                    ViewBag.str_organisationType = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType1 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType2 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType3 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType4 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    //NewAdd
                    ViewBag.str_organisationType5 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType6 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType7 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType8 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType9 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType10 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    ViewBag.str_organisationType11 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                    //NewAdd


                    return View(tbl_mst_CandidatePersonalDetails);

                }


            }



        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CandidatePersonalDetails(tbl_mst_CandidatePersonalDetails tbl_mst_CandidatePersonalDetails, FormCollection frm, string id, string btnSubmit)
        {
            if (current >= Convert.ToDateTime("14/10/2018"))
            {
                return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
            }





            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            if (CandiadateId == 0)
            {
                return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            }

            string fstValue = "";
            string secValue = "";
            int idInt = 0;

            if (id.IndexOf('-') > 0)
            {
                fstValue = id.Split('-')[0];
                secValue = id.Split('-')[1];
                int pkId = Convert.ToInt32(fstValue);
                int? idIntNull = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails_temp.Where(x => x.Pk_int_CandidateRegistrationID == pkId).FirstOrDefault().fk_advertiseid;
                idInt = Convert.ToInt32(idIntNull);
            }
            else
            {
                idInt = Convert.ToInt32(id);
            }

            //ViewBag.strimmediateGrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName");
            ViewBag.strState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.str_organisationType = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType1 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType2 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType3 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType4 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            //NewAdd 
            ViewBag.str_organisationType5 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType6 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType7 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType8 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType9 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType10 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType11 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            //NewAdd
            ViewBag.strDomicilestate = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName");
            ViewBag.strgrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName");
            //ViewBag.strpresentdesignation = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strDesignationName", "strDesignationName");
            ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender");
            ViewBag.strCategory = new SelectList(objCast.Castes.ToList(), "strCasteName", "strCasteName");
            ViewBag.fk_dicipline = new SelectList(objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.fk_advertisementid == idInt).ToList(), "fk_diciplineid", "DisciplineName");
            ViewBag.fk_postid = new SelectList((from s in objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.fk_advertisementid == idInt).ToList()
                                                select new
                                                {
                                                    fk_postid = s.fk_postid,
                                                    FullName = s.Postname + " ( " + s.DisciplineName + " )"
                                                }),
                 "fk_postid",
                 "FullName"
                 );
            ViewBag.EduQulifi = new SelectList("", "");

            string ApplicationNo = "";
            int Pk_int_CandidateRegistrationID = 0;
            int candidateId = Convert.ToInt32(Session["UserID"]);

            var Postcriteria = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == tbl_mst_CandidatePersonalDetails.fk_postid && x.fk_advertisementid == idInt).FirstOrDefault();
            var minExpAll = objpostnew.tbl_mst_Postnew.Where(x => x.Pk_Postid == tbl_mst_CandidatePersonalDetails.fk_postid).FirstOrDefault();



            string expmaxage = Postcriteria.str_postMaxage.ToString();
            string fremaxage = Postcriteria.str_postMaxage.ToString();
            string expCompdate = Postcriteria.dt_compareDate.ToString();
            string freCompdate = Postcriteria.dt_compareDate.ToString();
            var candidateDOB = Convert.ToDateTime(frm["dtDOB"]);

            string category1 = "";
            string category2 = frm["strGender"];
            string category3 = frm["strCategory"];
            if (frm["strPWD"] == "Yes")
            {
                category1 = "PWD";
            }
            var category = new string[] { category1, category2, category3 };
            var AgeRelaxationValue = objAgeRelaxation.tbl_mstAgeRelaxation.Where(x => category.Contains(x.strCategory)).Sum(x => x.AgeRelaxationYear);

            if (AgeRelaxationValue == null)
            {
                AgeRelaxationValue = 0;
            }




            //if (frm["is_freshers"] == "No" && frm["strExserviceMan"] == "No" && frm["strInternalCandidate"] == "No")
            //{
            //    double daysFrsh = (Convert.ToDateTime(expCompdate) - Convert.ToDateTime(candidateDOB)).TotalDays;
            //    double Years = (daysFrsh / 365) - Convert.ToDouble(AgeRelaxationValue);
            //    if (Years > Convert.ToDouble(fremaxage))
            //    {
            //        ViewBag.Message = "Age Over";
            //        return View();
            //    }
            //}



            int UploadDetail = 0;

            var RegistrationDetail = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == candidateId && x.fk_advertiseid == idInt).FirstOrDefault();

            if (RegistrationDetail != null)
            {
                UploadDetail = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == candidateId && x.str_applicationno == RegistrationDetail.strApplicationNo).ToList().Count();
            }

            if (RegistrationDetail != null && UploadDetail == 0)
            {
                tbl_mst_candidatephotoupload tbl_mst_candidatephotoupload = new Models.tbl_mst_candidatephotoupload();
                HttpPostedFileBase str_uploadphoto = Request.Files["str_uploadphoto"];
                HttpPostedFileBase str_uploadsignature = Request.Files["str_uploadsignature"];
                if (str_uploadphoto.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(str_uploadphoto.FileName);
                    var AutoGenFileName = "Photo" + "-" + System.DateTime.Now.Ticks.ToString();
                    var path = Path.Combine(Server.MapPath("~/Upload/Photo/"), AutoGenFileName + fileExtension);
                    str_uploadphoto.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/Upload/Photo/" + newpath;
                    tbl_mst_candidatephotoupload.str_uploadphoto = imagepath;
                }
                if (str_uploadsignature.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(str_uploadsignature.FileName);
                    var AutoGenFileName = "Signature" + "-" + System.DateTime.Now.Ticks.ToString();
                    var path = Path.Combine(Server.MapPath("~/Upload/Signature/"), AutoGenFileName + fileExtension);
                    str_uploadsignature.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/Upload/Signature/" + newpath;
                    tbl_mst_candidatephotoupload.str_uploadsignature = imagepath;

                }
                tbl_mst_candidatephotoupload.str_applicationno = RegistrationDetail.strApplicationNo;
                tbl_mst_candidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_mst_candidatephotoupload.fk_intcandidateid = RegistrationDetail.fk_CandidateId;
                tbl_mst_candidatephotoupload.is_active = "YES";
                objcandidatephotoupload.tbl_mst_candidatephotoupload.Add(tbl_mst_candidatephotoupload);
                objcandidatephotoupload.SaveChanges();
                return RedirectToAction("PayOnline", "Payment", new { AppNo = RegistrationDetail.strApplicationNo });
            }

            if (RegistrationDetail != null && UploadDetail > 0)
            {
                //ApplicationNo = RegistrationDetail.strApplicationNo.ToString();
                //Pk_int_CandidateRegistrationID = RegistrationDetail.Pk_int_CandidateRegistrationID;
                ViewBag.Message = string.Format("You have already applied to this post!");
                return View();
            }
            //////////
            else if (btnSubmit == "Draft")
            {

                if (frm["strExserviceMan"] == "No" && frm["strInternalCandidate"] == "No")
                {
                    //double daysFrsh = (Convert.ToDateTime(freCompdate) - Convert.ToDateTime(candidateDOB)).TotalDays;
                    //double Years = (daysFrsh / 365) - Convert.ToDouble(AgeRelaxationValue);

                    //if (Years > Convert.ToDouble(fremaxage))
                    //{
                    DateTime date2 = Convert.ToDateTime(freCompdate);
                    DateTime date1 = Convert.ToDateTime(candidateDOB);

                    TimeSpan diff = date2 - date1;
                    int Years = (diff.Days / 366);
                    DateTime workingDate = date1.AddYears(Years);
                    while (workingDate.AddYears(1) <= date2)
                    {
                        workingDate = workingDate.AddYears(1);
                        Years++;
                    }
                    //---------------------------------------------
                    //months
                    diff = date2 - workingDate;
                    int Months = diff.Days / 31;
                    workingDate = workingDate.AddMonths(Months);
                    while (workingDate.AddMonths(1) <= date2)
                    {
                        workingDate = workingDate.AddMonths(1);
                        Months++;
                    }
                    //---------------------------------------------
                    //weeks and days
                    diff = date2 - workingDate;
                    int Days = diff.Days;

                    int monthDay = Months * 30 + Days;
                    Years = Years - Convert.ToInt32(AgeRelaxationValue);

                    if ((Years > Convert.ToInt32(fremaxage)) || (Years == Convert.ToInt32(fremaxage) && monthDay != 0))
                    {
                        ViewBag.Message = "Age Criteria not met";
                        return View();

                    }

                }




                int post = Convert.ToInt32(frm["fk_postid"]);
                var Draft = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails_temp.Where(x => x.fk_CandidateId == candidateId && x.fk_advertiseid == idInt && x.fk_postid == post);

                foreach (var CandidateRegistrationDraft in Draft)
                {
                    objcanpersonaldetails.Entry(CandidateRegistrationDraft).State = EntityState.Deleted;
                }
                objcanpersonaldetails.SaveChanges();


                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString))
                {
                    SqlParameter outScore = new SqlParameter("@newstrApplicationNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                    var cmd = new SqlCommand("sp_AddModifyCandidatePersonalDetails_temp", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Pk_int_CandidateRegistrationID", SqlDbType.VarChar)).Value = Convert.ToInt32(Pk_int_CandidateRegistrationID);//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@ApplicationNo", SqlDbType.VarChar)).Value = ApplicationNo;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@fk_CandidateId", SqlDbType.VarChar)).Value = candidateId;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@fk_postid", SqlDbType.Int)).Value = tbl_mst_CandidatePersonalDetails.fk_postid;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@fk_dicipline", SqlDbType.Int)).Value = tbl_mst_CandidatePersonalDetails.fk_dicipline;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strApplicantName", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strApplicantName;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@dtDOB", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dtDOB;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strFatherName", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strFatherName; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strEmail", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strEmail; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strNationality", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strNationality; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strGender", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strGender; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strCategory", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strCategory; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strMaritalStatus", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strMaritalStatus; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPWD", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPWD; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strExserviceMan", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strExserviceMan; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strInternalCandidate", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strInternalCandidate; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strEmployedIn", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strEmployedIn; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strCorrespondenceAddress", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strCorrespondenceAddress; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strState", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strState; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strDistrict", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strDistrict; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strNearestPostOffice", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strNearestPostOffice; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strNearestPoliceStation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strNearestPoliceStation; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strNearestRailwaystation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strNearestRailwaystation; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPin", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPin; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strTelephone", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strTelephone; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strMobileNo", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strMobileNo; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentAddress", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentAddress; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentState", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentState; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentDistrict", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentDistrict; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentNearestPostOffice", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentNearestPostOffice; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentNearestPoliceStation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentNearestPoliceStation; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentNearestRailwayStation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentNearestRailwayStation; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentPinCode", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentPinCode; //Pass the parameter                  
                    cmd.Parameters.Add(new SqlParameter("@strPermanentTelephoneNo", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentTelephoneNo; //Pass the parameter                   
                    cmd.Parameters.Add(new SqlParameter("@strPermanentMobile1", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentMobile1; //Pass the parameter                   
                    cmd.Parameters.Add(new SqlParameter("@strsubcaste", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strsubcaste; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strcertificateno", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateno; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@dt_certificateissuedate", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dt_certificateissuedate; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strcertificateissue", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateissue; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strexservicemanno", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strexservicemanno; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strDomicilestate", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strDomicilestate; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strtypeofdisable", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strtypeofdisable; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strcertificateno1", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateno1; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@dt_certificateissuedate1", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dt_certificateissuedate1; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strcertificateissue1", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateissue1; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@stremployeecode", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.stremployeecode; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strgrade", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strgrade; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strplaceposting", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strplaceposting; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strpresentdesignation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strpresentdesignation; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@dt_presententrydate", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dt_presententrydate; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@fk_advertiseid", SqlDbType.Int)).Value = idInt; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strapplyproper", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strapplyproper; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strMotherName", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strMotherName; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strSpouseName", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strSpouseName; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strAlternate_EmaiID", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strAlternate_EmaiID; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPANNo", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strPANNo; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strAadharNo", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strAadharNo; //Pass the parameter


                    cmd.Parameters.Add(outScore);

                    try
                    {

                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.ExecuteNonQuery();
                        var intID = "";
                        if (cmd.Parameters["@newstrApplicationNo"].Value != null)
                        {
                            intID = cmd.Parameters["@newstrApplicationNo"].Value.ToString();

                        }
                        else
                        {
                            intID = ApplicationNo.ToString();
                        }
                        tbl_mst_CandidateQualification_temp obj = new tbl_mst_CandidateQualification_temp();

                        var qualification = tblQulifi.tbl_mst_CandidateQualification_temp.Where(x => x.Application_No == intID);
                        foreach (var candidatequali in qualification)
                        {
                            tblQulifi.Entry(candidatequali).State = EntityState.Deleted;
                        }
                        tblQulifi.SaveChanges();
                        for (int i = 0; i <= 3; i++)
                        {

                            var j = i.ToString();
                            if (j == "0")
                            {
                                j = "";
                            }

                            if (!string.IsNullOrEmpty(frm["Str_course" + j]) || !string.IsNullOrEmpty(frm["Str_board" + j]) || !string.IsNullOrEmpty(frm["Str_passingdetails" + j]) || !string.IsNullOrEmpty(frm["Str_passingyear" + j]))
                            {
                                obj.Str_exampassed = frm["Str_exampassed" + j];
                                obj.Str_course = frm["Str_course" + j];
                                obj.Str_board = frm["Str_board" + j];
                                obj.Str_passingdetails = frm["Str_passingdetails" + j];
                                obj.Str_duration = frm["Str_duration" + j];
                                obj.EduQulifi = frm["EduQulifi"];

                                if (frm["StrRemarks" + j] != "Pursuing")
                                {
                                    obj.Str_passingyear = frm["Str_passingyear" + j];
                                }
                                else
                                {
                                    obj.Str_passingyear = frm["hidMaxExpdate"];
                                }
                                //Bhadshkar 190918
                                //obj.Str_passingyear = frm["Str_passingyear" + j];


                                obj.Str_division = frm["Str_division" + j];
                                obj.Str_Marks = frm["Str_Marks" + j];
                                obj.StrRemarks = frm["StrRemarks" + j];

                                obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                obj.Fk_int_CandidateRegistrationID = candidateId;
                                obj.Application_No = intID;
                                tblQulifi.tbl_mst_CandidateQualification_temp.Add(obj);
                                tblQulifi.SaveChanges();
                            }
                        }


                        for (int i = 1; i <= 4; i++)
                        {

                            var j = i.ToString();
                            if (!string.IsNullOrEmpty(frm["others_exampassed" + j]) || !string.IsNullOrEmpty(frm["others_course" + j]) || !string.IsNullOrEmpty(frm["others_board" + j]) || !string.IsNullOrEmpty(frm["others_passingdetails" + j]))
                            {
                                obj.Str_exampassed = frm["others_exampassed" + j];
                                obj.Str_course = frm["others_course" + j];
                                obj.Str_board = frm["others_board" + j];

                                if (frm["others_Remarks" + j] != "Pursuing")
                                {
                                    obj.Str_passingyear = frm["others_passingyear" + j];
                                }
                                else
                                {
                                    obj.Str_passingyear = frm["hidMaxExpdate"];
                                }

                                obj.Str_passingdetails = frm["others_passingdetails" + j];
                                obj.Str_duration = frm["others_duration" + j];
                                //obj.Str_passingyear = frm["others_passingyear" + j];
                                obj.Str_division = frm["others_division" + j];
                                obj.Str_Marks = frm["others_Marks" + j];
                                obj.EduQulifi = frm["EduQulifi"];
                                obj.StrRemarks = frm["others_Remarks" + j];
                                obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                obj.Fk_int_CandidateRegistrationID = candidateId;
                                obj.Application_No = intID;
                                tblQulifi.tbl_mst_CandidateQualification_temp.Add(obj);
                                tblQulifi.SaveChanges();
                            }
                        }




                        tbl_mst_CandidateExperience_temp objExp = new tbl_mst_CandidateExperience_temp();

                        var exp = tblExperience.tbl_mst_CandidateExperience_temp.Where(x => x.ApplicationNo == intID);
                        foreach (var candidateexp in exp)
                        {
                            tblExperience.Entry(candidateexp).State = EntityState.Deleted;
                        }
                        tblExperience.SaveChanges();

                        for (int i = 0; i <= 11; i++)
                        {

                            var j = i.ToString();
                            if (j == "0")
                            {
                                j = "";
                            }

                            if (!string.IsNullOrEmpty(frm["str_organisation" + j]) && !string.IsNullOrEmpty(frm["dt_fromdate" + j]) && !string.IsNullOrEmpty(frm["str_organisationType" + j]))
                            {
                                //!string.IsNullOrEmpty(frm["dt_todate" + j]
                                if ((frm["StrEmploymentPresentStatus" + j] == "Currently Working") || ((frm["StrEmploymentPresentStatus" + j] == "Previous Employment") && (!string.IsNullOrEmpty(frm["dt_todate" + j]))))
                                {
                                    objExp.Str_designation = frm["Str_designation" + j];
                                    objExp.dt_fromdate = Convert.ToDateTime(frm["dt_fromdate" + j]);

                                    if (!string.IsNullOrEmpty(frm["dt_todate" + j]))
                                    {
                                        objExp.dt_todate = Convert.ToDateTime(frm["dt_todate" + j]);
                                    }
                                    else
                                    {
                                        objExp.dt_todate = Convert.ToDateTime(frm["hidMaxExpdate"]);
                                    }

                                    objExp.str_noyears = frm["str_noyears" + j];
                                    objExp.str_organisation = frm["str_organisation" + j];
                                    objExp.str_organisationType = frm["str_organisationType" + j];
                                    objExp.str_remarks = frm["str_remarks" + j];
                                    objExp.str_organisationType = frm["str_organisationType" + j];
                                    objExp.str_CTC = frm["str_CTC" + j];
                                    objExp.str_PayScale = frm["str_PayScale" + j];
                                    objExp.StrEmploymentPresentStatus = frm["StrEmploymentPresentStatus" + j];

                                    objExp.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                    objExp.Fk_CandidateRegistrationID = candidateId;
                                    objExp.ApplicationNo = intID;
                                    tblExperience.tbl_mst_CandidateExperience_temp.Add(objExp);
                                    tblExperience.SaveChanges();
                                }
                            }
                        }

                        tbl_NextBelowGrade_temp objnexbellow = new tbl_NextBelowGrade_temp();

                        var Experien = tblExperience.tbl_NextBelowGrade_temp.Where(x => x.strApplicationNo == intID);
                        foreach (var candidatbellow in Experien)
                        {
                            tblExperience.Entry(candidatbellow).State = EntityState.Deleted;
                        }
                        tblExperience.SaveChanges();

                        if (!string.IsNullOrEmpty(frm["strimmediateGrade"]) || !string.IsNullOrEmpty(frm["dt_immediatefromdate"]) || !string.IsNullOrEmpty(frm["dt_immediatetodate"]))
                        {
                            objnexbellow.strGrade = frm["strimmediateGrade"];
                            objnexbellow.dtFromDate = frm["dt_immediatefromdate"];
                            objnexbellow.dtTodate = frm["dt_immediatetodate"];
                            objnexbellow.strYear = frm["str_immediatenoyears"];
                            objnexbellow.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                            objnexbellow.Fk_CandidateRegistrationID = candidateId;
                            objnexbellow.strApplicationNo = intID;
                            tblExperience.tbl_NextBelowGrade_temp.Add(objnexbellow);
                            tblExperience.SaveChanges();
                        }


                        tbl_mst_CandidateAwardScholarship_temp objAward = new tbl_mst_CandidateAwardScholarship_temp();
                        var award = objAwardcon.tbl_mst_CandidateAwardScholarship_temp.Where(x => x.Application_No == intID);
                        foreach (var candidateaward in award)
                        {
                            objAwardcon.Entry(candidateaward).State = EntityState.Deleted;
                        }
                        objAwardcon.SaveChanges();
                        for (int i = 0; i <= 2; i++)
                        {
                            var j = i.ToString();
                            if (j == "0")
                            {
                                j = "";
                            }

                            if (!string.IsNullOrEmpty(frm["straward" + j]))
                            {
                                objAward.straward = frm["straward" + j];
                                objAward.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                objAward.Fk_candidateregistration = candidateId;
                                objAward.Application_No = intID;
                                objAwardcon.tbl_mst_CandidateAwardScholarship_temp.Add(objAward);
                                objAwardcon.SaveChanges();
                            }
                        }



                        tbl_mst_CandidatePublicationPaperPresentation_temp objPublication = new tbl_mst_CandidatePublicationPaperPresentation_temp();
                        var PaperPresentation = objPublicationcon.tbl_mst_CandidatePublicationPaperPresentation_temp.Where(x => x.Application_No == intID);
                        foreach (var candidatePaperPresentation in PaperPresentation)
                        {
                            objPublicationcon.Entry(candidatePaperPresentation).State = EntityState.Deleted;
                        }
                        objPublicationcon.SaveChanges();
                        for (int i = 0; i <= 2; i++)
                        {
                            var j = i.ToString();
                            if (j == "0")
                            {
                                j = "";
                            }

                            if (!string.IsNullOrEmpty(frm["str_Publication_PaperPresentation" + j]))
                            {
                                objPublication.str_Publication_PaperPresentation = frm["str_Publication_PaperPresentation" + j];
                                objPublication.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                objPublication.Fk_candidateregistration = candidateId;
                                objPublication.Application_No = intID;
                                objPublicationcon.tbl_mst_CandidatePublicationPaperPresentation_temp.Add(objPublication);
                                objPublicationcon.SaveChanges();
                            }
                        }

                        //Other Details
                        tbl_mst_CandidateOtherDetails_temp objOtherDetails = new tbl_mst_CandidateOtherDetails_temp();
                        var OtherDetails = objOtherDetailsContext.tbl_mst_CandidateOtherDetails_temp.Where(x => x.strApplicationNo == intID);
                        foreach (var Other in OtherDetails)
                        {
                            objOtherDetailsContext.Entry(Other).State = EntityState.Deleted;
                        }
                        objOtherDetailsContext.SaveChanges();

                        objOtherDetails.Fk_CandidateRegistrationID = candidateId;
                        objOtherDetails.strApplicationNo = intID;
                        objOtherDetails.strProfessionalBodies = frm["strProfessionalBodies"];
                        objOtherDetails.strJoiningTimeReq = frm["strJoiningTimeReq"];
                        objOtherDetails.strJoinEarly = frm["strJoinEarly"];
                        objOtherDetails.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        objOtherDetailsContext.tbl_mst_CandidateOtherDetails_temp.Add(objOtherDetails);
                        objOtherDetailsContext.SaveChanges();

                        //Upload Section

                        tbl_mst_candidatephotoupload_temp tbl_mst_candidatephotoupload = new tbl_mst_candidatephotoupload_temp();
                        TempData["Appno"] = intID;
                        var appno = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails_temp.Where(x => x.strApplicationNo == intID).FirstOrDefault();
                        var Photoupload = objcandidatephotoupload.tbl_mst_candidatephotoupload_temp.Where(x => x.str_applicationno == intID);




                        foreach (var candidatephotoupload in Photoupload)
                        {
                            objcandidatephotoupload.Entry(candidatephotoupload).State = EntityState.Deleted;
                        }
                        objcandidatephotoupload.SaveChanges();




                        HttpPostedFileBase str_uploadphoto = Request.Files["str_uploadphoto"];
                        HttpPostedFileBase str_uploadsignature = Request.Files["str_uploadsignature"];


                        if (str_uploadphoto.ContentLength > 0)
                        {
                            var fileExtension = Path.GetExtension(str_uploadphoto.FileName);
                            var AutoGenFileName = "Photo" + "-" + System.DateTime.Now.Ticks.ToString();
                            var path = Path.Combine(Server.MapPath("~/Upload/Photo/"), AutoGenFileName + fileExtension);
                            str_uploadphoto.SaveAs(path);
                            string fl = path.Substring(path.LastIndexOf("\\"));
                            string[] split = fl.Split('\\');
                            string newpath = split[1];
                            string imagepath = "~/Upload/Photo/" + newpath;
                            tbl_mst_candidatephotoupload.str_uploadphoto = imagepath;

                        }
                        else
                        {
                            tbl_mst_candidatephotoupload.str_uploadphoto = frm["hiduploadphotopath"];
                        }


                        if (str_uploadsignature.ContentLength > 0)
                        {
                            var fileExtension = Path.GetExtension(str_uploadsignature.FileName);
                            var AutoGenFileName = "Signature" + "-" + System.DateTime.Now.Ticks.ToString();
                            var path = Path.Combine(Server.MapPath("~/Upload/Signature/"), AutoGenFileName + fileExtension);
                            str_uploadsignature.SaveAs(path);
                            string fl = path.Substring(path.LastIndexOf("\\"));
                            string[] split = fl.Split('\\');
                            string newpath = split[1];
                            string imagepath = "~/Upload/Signature/" + newpath;
                            tbl_mst_candidatephotoupload.str_uploadsignature = imagepath;

                        }

                        else
                        {
                            tbl_mst_candidatephotoupload.str_uploadsignature = frm["hiduploadsignaturepath"];
                        }


                        tbl_mst_candidatephotoupload.str_applicationno = intID;
                        tbl_mst_candidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        tbl_mst_candidatephotoupload.fk_intcandidateid = appno.fk_CandidateId;
                        tbl_mst_candidatephotoupload.is_active = "YES";
                        objcandidatephotoupload.tbl_mst_candidatephotoupload_temp.Add(tbl_mst_candidatephotoupload);
                        objcandidatephotoupload.SaveChanges();


                        ViewBag.message = "Your Application has been saved to Draft";
                        return View();


                    }

                    finally
                    {

                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }




            }

            else
            {
                if (frm["strExserviceMan"] == "No" && frm["strInternalCandidate"] == "No")
                {
                    //double daysFrsh = (Convert.ToDateTime(freCompdate) - Convert.ToDateTime(candidateDOB)).TotalDays;
                    //double Years = (daysFrsh / 365) - Convert.ToDouble(AgeRelaxationValue);

                    //if (Years > Convert.ToDouble(fremaxage))

                    DateTime date2 = Convert.ToDateTime(freCompdate);
                    DateTime date1 = Convert.ToDateTime(candidateDOB);

                    TimeSpan diff = date2 - date1;
                    int Years = (diff.Days / 366);
                    DateTime workingDate = date1.AddYears(Years);
                    while (workingDate.AddYears(1) <= date2)
                    {
                        workingDate = workingDate.AddYears(1);
                        Years++;
                    }
                    //---------------------------------------------
                    //months
                    diff = date2 - workingDate;
                    int Months = diff.Days / 31;
                    workingDate = workingDate.AddMonths(Months);
                    while (workingDate.AddMonths(1) <= date2)
                    {
                        workingDate = workingDate.AddMonths(1);
                        Months++;
                    }
                    //---------------------------------------------
                    //weeks and days
                    diff = date2 - workingDate;
                    int Days = diff.Days;

                    int monthDay = Months * 30 + Days;
                    Years = Years - Convert.ToInt32(AgeRelaxationValue);
                    if ((Years > Convert.ToInt32(fremaxage)) || (Years == Convert.ToInt32(fremaxage) && monthDay != 0))
                    {
                        ViewBag.Message = "Age Criteria not met";
                        //return RedirectToAction("CandidatePersonalDetails", "");
                        //return RedirectToAction("CandidatePersonalDetails", "RecruitmentCareer", new { id = id });
                        return View();

                    }

                }


                if (minExpAll.str_minexp != null && frm["strInternalCandidate"] == "No")
                {
                    double days = Convert.ToInt32(minExpAll.str_minexp) * 365;
                    double days1 = 0;
                    if (frm["totalYear"] != null && frm["totalYear"] != "")
                    {
                        days1 = Convert.ToInt32(frm["totalYear"]);
                    }


                    if (Convert.ToDouble(days1) < Convert.ToDouble(days))
                    {
                        ViewBag.Message = "Experience Criteria not met";
                        //return RedirectToAction("CandidatePersonalDetails", "");
                        //return RedirectToAction("CandidatePersonalDetails", "RecruitmentCareer", new { id = id });
                        return View();

                    }


                }

                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString))
                {
                    SqlParameter outScore = new SqlParameter("@newstrApplicationNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                    var cmd = new SqlCommand("sp_AddModifyCandidatePersonalDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add(new SqlParameter("@Pk_int_CandidateRegistrationID", SqlDbType.VarChar)).Value = Convert.ToInt32(Pk_int_CandidateRegistrationID);//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@ApplicationNo", SqlDbType.VarChar)).Value = ApplicationNo;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@fk_CandidateId", SqlDbType.VarChar)).Value = candidateId;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@fk_postid", SqlDbType.Int)).Value = tbl_mst_CandidatePersonalDetails.fk_postid;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@fk_dicipline", SqlDbType.Int)).Value = tbl_mst_CandidatePersonalDetails.fk_dicipline;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strApplicantName", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strApplicantName;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@dtDOB", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dtDOB;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strFatherName", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strFatherName; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strEmail", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strEmail; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strNationality", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strNationality; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strGender", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strGender; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strCategory", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strCategory; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strMaritalStatus", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strMaritalStatus; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPWD", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPWD; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strExserviceMan", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strExserviceMan; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strInternalCandidate", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strInternalCandidate; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strEmployedIn", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strEmployedIn; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strCorrespondenceAddress", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strCorrespondenceAddress; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strState", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strState; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strDistrict", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strDistrict; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strNearestPostOffice", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strNearestPostOffice; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strNearestPoliceStation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strNearestPoliceStation; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strNearestRailwaystation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strNearestRailwaystation; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPin", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPin; //Pass the parameter
                    //cmd.Parameters.Add(new SqlParameter("@strSTDCode", SqlDbType.VarChar)).Value = Vw_CandidateRegistration.strSTDCode.Trim(); //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strTelephone", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strTelephone; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strMobileNo", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strMobileNo; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentAddress", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentAddress; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentState", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentState; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentDistrict", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentDistrict; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentNearestPostOffice", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentNearestPostOffice; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentNearestPoliceStation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentNearestPoliceStation; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentNearestRailwayStation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentNearestRailwayStation; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentPinCode", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentPinCode; //Pass the parameter
                    // cmd.Parameters.Add(new SqlParameter("@strPermanentSTDCode", SqlDbType.VarChar)).Value = Vw_CandidateRegistration.strPermanentSTDCode.Trim(); //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentTelephoneNo", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentTelephoneNo; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPermanentMobile1", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPermanentMobile1; //Pass the parameter
                    //cmd.Parameters.Add(new SqlParameter("@dt_updatedate", SqlDbType.DateTime)).Value = current; //Pass the parameter
                    //cmd.Parameters.Add(new SqlParameter("@dt_entrydate", SqlDbType.DateTime)).Value = current; //Pass the parameter                
                    //cmd.Parameters.Add(new SqlParameter("@isactive", SqlDbType.Bit)).Value = true; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strsubcaste", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strsubcaste; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strcertificateno", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateno; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@dt_certificateissuedate", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dt_certificateissuedate; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strcertificateissue", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateissue; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strexservicemanno", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strexservicemanno; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strDomicilestate", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strDomicilestate; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strtypeofdisable", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strtypeofdisable; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strcertificateno1", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateno1; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@dt_certificateissuedate1", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dt_certificateissuedate1; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strcertificateissue1", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateissue1; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@stremployeecode", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.stremployeecode; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strgrade", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strgrade; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strplaceposting", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strplaceposting; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strpresentdesignation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strpresentdesignation; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@dt_presententrydate", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dt_presententrydate; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@fk_advertiseid", SqlDbType.Int)).Value = idInt; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strapplyproper", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strapplyproper; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strMotherName", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strMotherName; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strSpouseName", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strSpouseName; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strAlternate_EmaiID", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strAlternate_EmaiID; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strPANNo", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strPANNo; //Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@strAadharNo", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strAadharNo; //Pass the parameter


                    cmd.Parameters.Add(outScore);

                    try
                    {

                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.ExecuteNonQuery();
                        var intID = "";
                        if (cmd.Parameters["@newstrApplicationNo"].Value != null)
                        {
                            intID = cmd.Parameters["@newstrApplicationNo"].Value.ToString();

                        }
                        else
                        {
                            intID = ApplicationNo.ToString();
                        }
                        tbl_mst_CandidateQualification obj = new tbl_mst_CandidateQualification();

                        var qualification = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Application_No == intID);
                        foreach (var candidatequali in qualification)
                        {
                            tblQulifi.Entry(candidatequali).State = EntityState.Deleted;
                        }
                        tblQulifi.SaveChanges();
                        for (int i = 0; i <= 3; i++)
                        {

                            var j = i.ToString();
                            if (j == "0")
                            {
                                j = "";
                            }

                            if (!string.IsNullOrEmpty(frm["Str_exampassed" + j]) || !string.IsNullOrEmpty(frm["Str_course" + j]) || !string.IsNullOrEmpty(frm["Str_board" + j]) || !string.IsNullOrEmpty(frm["Str_passingdetails" + j]) || !string.IsNullOrEmpty(frm["Str_passingyear" + j]))
                            {
                                obj.Str_exampassed = frm["Str_exampassed" + j];
                                obj.Str_course = frm["Str_course" + j];
                                obj.Str_board = frm["Str_board" + j];
                                obj.Str_passingdetails = frm["Str_passingdetails" + j];
                                obj.Str_duration = frm["Str_duration" + j];


                                if (frm["StrRemarks" + j] != "Pursuing")
                                {
                                    obj.Str_passingyear = frm["Str_passingyear" + j];
                                }
                                else
                                {
                                    obj.Str_passingyear = frm["hidMaxExpdate"];
                                }
                                //Bhadshkar 190918
                                //obj.Str_passingyear = frm["Str_passingyear" + j];


                                obj.Str_division = frm["Str_division" + j];
                                obj.Str_Marks = frm["Str_Marks" + j];
                                obj.StrRemarks = frm["StrRemarks" + j];

                                obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                obj.Fk_int_CandidateRegistrationID = candidateId;
                                obj.Application_No = intID;
                                tblQulifi.tbl_mst_CandidateQualification.Add(obj);
                                tblQulifi.SaveChanges();
                            }
                        }


                        for (int i = 1; i <= 4; i++)
                        {

                            var j = i.ToString();
                            if (!string.IsNullOrEmpty(frm["others_exampassed" + j]) || !string.IsNullOrEmpty(frm["others_course" + j]) || !string.IsNullOrEmpty(frm["others_board" + j]) || !string.IsNullOrEmpty(frm["others_passingdetails" + j]))
                            {
                                obj.Str_exampassed = frm["others_exampassed" + j];
                                obj.Str_course = frm["others_course" + j];
                                obj.Str_board = frm["others_board" + j];

                                if (frm["others_Remarks" + j] != "Pursuing")
                                {
                                    obj.Str_passingyear = frm["others_passingyear" + j];
                                }
                                else
                                {
                                    obj.Str_passingyear = frm["hidMaxExpdate"];
                                }

                                obj.Str_passingdetails = frm["others_passingdetails" + j];
                                obj.Str_duration = frm["others_duration" + j];
                                //obj.Str_passingyear = frm["others_passingyear" + j];
                                obj.Str_division = frm["others_division" + j];
                                obj.Str_Marks = frm["others_Marks" + j];

                                obj.StrRemarks = frm["others_Remarks" + j];
                                obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                obj.Fk_int_CandidateRegistrationID = candidateId;
                                obj.Application_No = intID;
                                tblQulifi.tbl_mst_CandidateQualification.Add(obj);
                                tblQulifi.SaveChanges();
                            }
                        }




                        tbl_mst_CandidateExperience objExp = new tbl_mst_CandidateExperience();

                        var exp = tblExperience.tbl_mst_CandidateExperience.Where(x => x.ApplicationNo == intID);
                        foreach (var candidateexp in exp)
                        {
                            tblExperience.Entry(candidateexp).State = EntityState.Deleted;
                        }
                        tblExperience.SaveChanges();

                        for (int i = 0; i <= 11; i++)
                        {

                            var j = i.ToString();
                            if (j == "0")
                            {
                                j = "";
                            }

                            if (!string.IsNullOrEmpty(frm["str_organisation" + j]) && !string.IsNullOrEmpty(frm["dt_fromdate" + j]) && !string.IsNullOrEmpty(frm["str_organisationType" + j]))
                            {

                                if ((frm["StrEmploymentPresentStatus" + j] == "Currently Working") || ((frm["StrEmploymentPresentStatus" + j] == "Previous Employment") && (!string.IsNullOrEmpty(frm["dt_todate" + j]))))
                                {
                                    objExp.Str_designation = frm["Str_designation" + j];
                                    objExp.dt_fromdate = Convert.ToDateTime(frm["dt_fromdate" + j]);

                                    if (frm["StrEmploymentPresentStatus" + j] == "Currently Working")
                                    {
                                        objExp.dt_todate = Convert.ToDateTime(frm["hidMaxExpdate"]);

                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(frm["dt_todate" + j]))
                                        {
                                            objExp.dt_todate = Convert.ToDateTime(frm["dt_todate" + j]);
                                        }
                                        //else
                                        //{
                                        //    ViewBag.Message = "To date can not be blank";
                                        //    return View();
                                        //}
                                    }

                                    objExp.str_noyears = frm["str_noyears" + j];
                                    objExp.str_organisation = frm["str_organisation" + j];
                                    objExp.str_organisationType = frm["str_organisationType" + j];
                                    objExp.str_remarks = frm["str_remarks" + j];
                                    objExp.str_organisationType = frm["str_organisationType" + j];
                                    objExp.str_CTC = frm["str_CTC" + j];
                                    objExp.str_PayScale = frm["str_PayScale" + j];
                                    objExp.StrEmploymentPresentStatus = frm["StrEmploymentPresentStatus" + j];

                                    objExp.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                    objExp.Fk_CandidateRegistrationID = candidateId;
                                    objExp.ApplicationNo = intID;
                                    tblExperience.tbl_mst_CandidateExperience.Add(objExp);
                                    tblExperience.SaveChanges();
                                }
                            }
                        }

                        tbl_NextBelowGrade objnexbellow = new tbl_NextBelowGrade();
                        if (!string.IsNullOrEmpty(frm["strimmediateGrade"]) || !string.IsNullOrEmpty(frm["dt_immediatefromdate"]) || !string.IsNullOrEmpty(frm["dt_immediatetodate"]))
                        {
                            objnexbellow.strGrade = frm["strimmediateGrade"];
                            objnexbellow.dtFromDate = frm["dt_immediatefromdate"];
                            objnexbellow.dtTodate = frm["dt_immediatetodate"];
                            objnexbellow.strYear = frm["str_immediatenoyears"];
                            objnexbellow.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                            objnexbellow.Fk_CandidateRegistrationID = candidateId;
                            objnexbellow.strApplicationNo = intID;
                            tblExperience.tbl_NextBelowGrade.Add(objnexbellow);
                            tblExperience.SaveChanges();
                        }


                        tbl_mst_CandidateAwardScholarship objAward = new tbl_mst_CandidateAwardScholarship();
                        var award = objAwardcon.tbl_mst_CandidateAwardScholarship.Where(x => x.Application_No == intID);
                        foreach (var candidateaward in award)
                        {
                            objAwardcon.Entry(candidateaward).State = EntityState.Deleted;
                        }
                        objAwardcon.SaveChanges();
                        for (int i = 0; i <= 2; i++)
                        {
                            var j = i.ToString();
                            if (j == "0")
                            {
                                j = "";
                            }

                            if (!string.IsNullOrEmpty(frm["straward" + j]))
                            {
                                objAward.straward = frm["straward" + j];
                                objAward.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                objAward.Fk_candidateregistration = candidateId;
                                objAward.Application_No = intID;
                                objAwardcon.tbl_mst_CandidateAwardScholarship.Add(objAward);
                                objAwardcon.SaveChanges();
                            }
                        }



                        tbl_mst_CandidatePublicationPaperPresentation objPublication = new tbl_mst_CandidatePublicationPaperPresentation();
                        var PaperPresentation = objPublicationcon.tbl_mst_CandidatePublicationPaperPresentation.Where(x => x.Application_No == intID);
                        foreach (var candidatePaperPresentation in PaperPresentation)
                        {
                            objPublicationcon.Entry(candidatePaperPresentation).State = EntityState.Deleted;
                        }
                        objPublicationcon.SaveChanges();
                        for (int i = 0; i <= 2; i++)
                        {
                            var j = i.ToString();
                            if (j == "0")
                            {
                                j = "";
                            }

                            if (!string.IsNullOrEmpty(frm["str_Publication_PaperPresentation" + j]))
                            {
                                objPublication.str_Publication_PaperPresentation = frm["str_Publication_PaperPresentation" + j];
                                objPublication.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                objPublication.Fk_candidateregistration = candidateId;
                                objPublication.Application_No = intID;
                                objPublicationcon.tbl_mst_CandidatePublicationPaperPresentation.Add(objPublication);
                                objPublicationcon.SaveChanges();
                            }
                        }

                        //Other Details
                        tbl_mst_CandidateOtherDetails objOtherDetails = new tbl_mst_CandidateOtherDetails();
                        var OtherDetails = objOtherDetailsContext.tbl_mst_CandidateOtherDetails.Where(x => x.strApplicationNo == intID);
                        foreach (var Other in OtherDetails)
                        {
                            objOtherDetailsContext.Entry(Other).State = EntityState.Deleted;
                        }
                        objOtherDetailsContext.SaveChanges();

                        objOtherDetails.Fk_CandidateRegistrationID = candidateId;
                        objOtherDetails.strApplicationNo = intID;
                        objOtherDetails.strProfessionalBodies = frm["strProfessionalBodies"];
                        objOtherDetails.strJoiningTimeReq = frm["strJoiningTimeReq"];
                        objOtherDetails.strJoinEarly = frm["strJoinEarly"];
                        objOtherDetails.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        objOtherDetailsContext.tbl_mst_CandidateOtherDetails.Add(objOtherDetails);
                        objOtherDetailsContext.SaveChanges();

                        //Upload Section

                        tbl_mst_candidatephotoupload tbl_mst_candidatephotoupload = new tbl_mst_candidatephotoupload();
                        TempData["Appno"] = intID;
                        var appno = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.strApplicationNo == intID).FirstOrDefault();
                        var Photoupload = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.str_applicationno == intID);
                        foreach (var candidatephotoupload in Photoupload)
                        {
                            objcandidatephotoupload.Entry(candidatephotoupload).State = EntityState.Deleted;
                        }
                        objcandidatephotoupload.SaveChanges();

                        HttpPostedFileBase str_uploadphoto = Request.Files["str_uploadphoto"];
                        HttpPostedFileBase str_uploadsignature = Request.Files["str_uploadsignature"];


                        if (str_uploadphoto.ContentLength > 0)
                        {
                            var fileExtension = Path.GetExtension(str_uploadphoto.FileName);
                            var AutoGenFileName = "Photo" + "-" + System.DateTime.Now.Ticks.ToString();
                            var path = Path.Combine(Server.MapPath("~/Upload/Photo/"), AutoGenFileName + fileExtension);
                            str_uploadphoto.SaveAs(path);
                            string fl = path.Substring(path.LastIndexOf("\\"));
                            string[] split = fl.Split('\\');
                            string newpath = split[1];
                            string imagepath = "~/Upload/Photo/" + newpath;
                            tbl_mst_candidatephotoupload.str_uploadphoto = imagepath;
                        }

                        else
                        {
                            tbl_mst_candidatephotoupload.str_uploadphoto = frm["hiduploadphotopath"];
                        }


                        if (str_uploadsignature.ContentLength > 0)
                        {
                            var fileExtension = Path.GetExtension(str_uploadsignature.FileName);
                            var AutoGenFileName = "Signature" + "-" + System.DateTime.Now.Ticks.ToString();
                            var path = Path.Combine(Server.MapPath("~/Upload/Signature/"), AutoGenFileName + fileExtension);
                            str_uploadsignature.SaveAs(path);
                            string fl = path.Substring(path.LastIndexOf("\\"));
                            string[] split = fl.Split('\\');
                            string newpath = split[1];
                            string imagepath = "~/Upload/Signature/" + newpath;
                            tbl_mst_candidatephotoupload.str_uploadsignature = imagepath;

                        }

                        else
                        {
                            tbl_mst_candidatephotoupload.str_uploadsignature = frm["hiduploadsignaturepath"];
                        }


                        tbl_mst_candidatephotoupload.str_applicationno = intID;
                        tbl_mst_candidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        tbl_mst_candidatephotoupload.fk_intcandidateid = appno.fk_CandidateId;
                        tbl_mst_candidatephotoupload.is_active = "YES";
                        objcandidatephotoupload.tbl_mst_candidatephotoupload.Add(tbl_mst_candidatephotoupload);
                        objcandidatephotoupload.SaveChanges();


                        //DD Details

                        //tbl_mst_CandidateDDDetails objtbl_mst_CandidateDDDetails = new tbl_mst_CandidateDDDetails();
                        //var DDDetails = objtbl_mst_CandidateDDDetailsContext.tbl_mst_CandidateDDDetails.Where(x => x.strApplicationNo == intID);
                        //foreach (var DD in DDDetails)
                        //{
                        //    objtbl_mst_CandidateDDDetailsContext.Entry(DD).State = EntityState.Deleted;
                        //}
                        //objtbl_mst_CandidateDDDetailsContext.SaveChanges();

                        //objtbl_mst_CandidateDDDetails.Fk_CandidateRegistrationID = candidateId;
                        //objtbl_mst_CandidateDDDetails.strApplicationNo = intID;
                        //objtbl_mst_CandidateDDDetails.strOrderNo = frm["strOrderNo"];
                        //objtbl_mst_CandidateDDDetails.strIssuingBankName = frm["strBankName"];
                        //objtbl_mst_CandidateDDDetails.strIssuingBranch = frm["strBranch"];
                        //objtbl_mst_CandidateDDDetails.dtIssueDate = Convert.ToDateTime(frm["dtIssueDate"]);
                        //objtbl_mst_CandidateDDDetails.decAmount = Convert.ToDecimal(frm["decAmount"]);
                        //objtbl_mst_CandidateDDDetails.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        //objtbl_mst_CandidateDDDetailsContext.tbl_mst_CandidateDDDetails.Add(objtbl_mst_CandidateDDDetails);
                        //objtbl_mst_CandidateDDDetailsContext.SaveChanges();

                        //DD Details

                        ViewBag.message = "Account Created";
                        return RedirectToAction("PayOnline", "Payment", new { AppNo = intID });

                        //ViewBag.Message = string.Format("Data updated successfully!");
                        //return View();
                        //return RedirectToAction("ApplicationPrint", "RecruitmentCareer", new { AppNo = id });
                        //return RedirectToAction("ApplicationPrint", "RecruitmentCareer", new { AppNo = id });
                        //return RedirectToAction("CandidatePersonalDetailsphotoupload?id=" + intID);
                    }
                    //catch (Exception ex)
                    //{
                    //    ViewBag.message("Message: " + ex.Message);
                    //    return View();
                    //}
                    finally
                    {

                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }

                }
            }



        }

        public ActionResult EditCandidatePersonalDetails(string appid)
        {
            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            if (CandiadateId == 0)
            {
                return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            }
            else
            {
                var obj1 = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.strApplicationNo == appid).FirstOrDefault();
                var expTotal = tblExperience.tbl_mst_CandidateExperience.Where(x => x.ApplicationNo == appid).ToList();
                var details = objAcknowledgement.Vw_Applicationdetails.Where(x => x.strApplicationNo == appid).FirstOrDefault();


                //if (details.DisciplineName != "Assistant Manager (Fresher)" && details.dt_entrydate < Convert.ToDateTime("21/09/2018") && current < Convert.ToDateTime("01/10/2018"))
                //if (obj1.dt_updatedate == null && current< Convert.ToDateTime("29/09/2018"))

                if (details.strApplicationNo == "06Estt/1/2005/2018019472018" || details.strApplicationNo == "06Estt/1/2005/2018029742018" || details.strApplicationNo == "06Estt/1/2005/2018091752018" || details.strApplicationNo == "06Estt/1/2005/2018119462018" || details.strApplicationNo == "06Estt/1/2005/2018143892018" || details.strApplicationNo == "06Estt/1/2005/2018189112018")

                {
                    // if ((expTotal.Count() > 0 && expTotal.FirstOrDefault().dtEntyDate < Convert.ToDateTime("21/09/2018")) || expTotal.Count() == 0)
                    if (details.strApplicationNo == "06Estt/1/2005/2018019472018" || details.strApplicationNo == "06Estt/1/2005/2018029742018" || details.strApplicationNo == "06Estt/1/2005/2018091752018" || details.strApplicationNo == "06Estt/1/2005/2018119462018" || details.strApplicationNo == "06Estt/1/2005/2018143892018" || details.strApplicationNo == "06Estt/1/2005/2018189112018")
                    {

                        ViewBag.Str_exampassed4 = new SelectList(objcourse.tbl_mst_course.ToList(), "Str_Coursename", "Str_Coursename");
                        ViewBag.Str_exampassed5 = new SelectList(objcourse.tbl_mst_course.ToList(), "Str_Coursename", "Str_Coursename");
                        var diciplineId = objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.Pk_Disciplineid == obj1.fk_dicipline).Select(x => x.fk_diciplineid).ToList();

                        ViewBag.fk_dicipline = new SelectList(dc.tbl_mst_Discipline.Where(t => diciplineId.Contains(t.Pk_Disciplineid)), "Pk_Disciplineid", "DisciplineName", obj1.fk_dicipline);
                        ViewBag.fk_postid = new SelectList((from s in objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.Pk_Postid == obj1.fk_postid).ToList()
                                                            select new
                                                            {
                                                                fk_postid = s.fk_postid,
                                                                FullName = s.Postname + " ( " + s.DisciplineName + " )"
                                                            }),
                              "fk_postid",
                              "FullName",
                               obj1.fk_postid);

                        // End Personal Information Bhashkar 21/09/2018 

                        // Educational Qualification Details Bhashkar 21/09/2018 

                        var postCaitareaDetails = objqualification.tbl_transaction_Postcriteria.Where(x => x.fk_postid == obj1.fk_postid && x.fk_advertisementid == obj1.fk_advertiseid).FirstOrDefault();
                        ViewData["hidMaxExpdate"] = postCaitareaDetails.dt_compareDate.Value.ToShortDateString().Replace("/", "-");

                        if (postCaitareaDetails.strPostIsFreshersAllowed != "Yes")
                        {
                            ViewData["is_freshers"] = "No";
                        }
                        else
                        {
                            ViewData["is_freshers"] = "Yes";
                        }

                        string sampleSentence = postCaitareaDetails.str_qualification;
                        string[] words = System.Text.RegularExpressions.Regex.Split(sampleSentence, "@");



                        List<Qulification> fstSubject = new List<Qulification>();

                        foreach (var quliName in words)
                        {
                            Qulification qu = new Qulification() { str_qualification = quliName.Trim(' ') };
                            fstSubject.Add(qu);
                        }

                        int numberLoop = 0;
                        var educationAll = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == obj1.fk_CandidateId && x.Application_No == obj1.strApplicationNo).ToList();


                        if (educationAll.Count() > 0)
                        {
                            ViewBag.EduQulifi = new SelectList(fstSubject, "str_qualification", "str_qualification");//, educationAll.FirstOrDefault().EduQulifi);
                            numberLoop = 2 + 2;//educationAll.FirstOrDefault().EduQulifi.Split(new[] { "WITH" }, StringSplitOptions.None).Length;
                            if (educationAll.Count() < numberLoop)
                            {
                                numberLoop = educationAll.Count();
                            }

                        }
                        else
                        {
                            ViewBag.EduQulifi = new SelectList(fstSubject, "str_qualification", "str_qualification");
                        }




                        string j = "";
                        int i = 0;
                        for (i = 0; i < numberLoop; i++)
                        {
                            if (i == 0)
                            {
                                j = "";
                            }
                            else
                            {
                                j = i.ToString();
                            }

                            ViewData["Str_exampassed" + j] = educationAll[i].Str_exampassed;
                            ViewData["Str_course" + j] = educationAll[i].Str_course;
                            ViewData["Str_board" + j] = educationAll[i].Str_board;
                            ViewData["Str_passingdetails" + j] = educationAll[i].Str_passingdetails;
                            if (educationAll[i].Str_passingyear != null && educationAll[i].Str_passingyear != "")
                            {
                                ViewData["Str_passingyear" + j] = Convert.ToDateTime(educationAll[i].Str_passingyear).ToShortDateString().Replace("/", "-");
                            }
                            ViewData["Str_duration" + j] = educationAll[i].Str_duration;
                            ViewData["Str_Marks" + j] = educationAll[i].Str_Marks;
                            ViewData["Str_division" + j] = educationAll[i].Str_division;
                            ViewData["StrRemarks" + j] = educationAll[i].StrRemarks;


                        }


                        j = "";

                        int k = 1;

                        for (; i < educationAll.Count; i++)
                        {

                            ViewData["others_exampassed" + k] = educationAll[i].Str_exampassed;
                            ViewData["others_course" + k] = educationAll[i].Str_course;
                            ViewData["others_board" + k] = educationAll[i].Str_board;
                            ViewData["others_passingdetails" + k] = educationAll[i].Str_passingdetails;
                            //ViewData["others_passingyear" + k] = educationAll[i].Str_passingyear;

                            if (educationAll[i].Str_passingyear != null && educationAll[i].Str_passingyear != "")
                            {
                                ViewData["others_passingyear" + k] = Convert.ToDateTime(educationAll[i].Str_passingyear).ToShortDateString().Replace("/", "-");
                            }

                            ViewData["others_duration" + k] = educationAll[i].Str_duration;
                            ViewData["others_Marks" + k] = educationAll[i].Str_Marks;
                            ViewData["others_division" + k] = educationAll[i].Str_division;
                            ViewData["others_Remarks" + k] = educationAll[i].StrRemarks;
                            k++;

                        }

                        //End  Educational Qualification Details Bhashkar 21/09/2018 




                        // Experience Details (Chronological Order - Starting with First Job) Bhashkar 21/09/2018 


                        ViewBag.str_organisationType = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        ViewBag.str_organisationType1 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        ViewBag.str_organisationType2 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        ViewBag.str_organisationType3 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        ViewBag.str_organisationType4 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        //NewAdd
                        ViewBag.str_organisationType5 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        ViewBag.str_organisationType6 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        ViewBag.str_organisationType7 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        ViewBag.str_organisationType8 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        ViewBag.str_organisationType9 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        ViewBag.str_organisationType10 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        ViewBag.str_organisationType11 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                        //NewAdd


                        var expAll = tblExperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == obj1.fk_CandidateId && x.ApplicationNo == obj1.strApplicationNo).ToList();
                        numberLoop = expAll.Count();
                        j = "";
                        i = 0;
                        for (i = 0; i < numberLoop; i++)
                        {
                            if (i == 0)
                            {
                                j = "";
                            }
                            else
                            {
                                j = i.ToString();
                            }

                            ViewData["str_organisationType" + j] = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType", expAll[i].str_organisationType);
                            ViewData["StrEmploymentPresentStatus" + j] = expAll[i].StrEmploymentPresentStatus;
                            ViewData["str_organisation" + j] = expAll[i].str_organisation;
                            ViewData["Str_designation" + j] = expAll[i].Str_designation;
                            ViewData["str_CTC" + j] = expAll[i].str_CTC;
                            ViewData["str_PayScale" + j] = expAll[i].str_PayScale;
                            ViewData["dt_fromdate" + j] = expAll[i].dt_fromdate.ToShortDateString().Replace("/", "-");
                            ViewData["dt_todate" + j] = expAll[i].dt_todate.ToShortDateString().Replace("/", "-");
                            ViewData["str_noyears" + j] = expAll[i].str_noyears;
                        }

                        // End Experience Details (Chronological Order - Starting with First Job) Bhashkar 21/09/2018


                        //Experience in immediate next below Grade ( for PSU/Government/Semi-Government Employees ) Bhashkar 21/09/2018

                        var ImdNextBellowGrade = tblExperience.tbl_NextBelowGrade.Where(x => x.Fk_CandidateRegistrationID == obj1.fk_CandidateId && x.strApplicationNo == obj1.strApplicationNo).ToList();

                        if (ImdNextBellowGrade.Count() > 0)
                        {
                            ViewData["strimmediateGrade"] = ImdNextBellowGrade.FirstOrDefault().strGrade;
                            ViewData["dt_immediatefromdate"] = ImdNextBellowGrade.FirstOrDefault().dtFromDate;
                            ViewData["dt_immediatetodate"] = ImdNextBellowGrade.FirstOrDefault().dtTodate;
                            ViewData["str_immediatenoyears"] = ImdNextBellowGrade.FirstOrDefault().strYear;
                        }

                        //End Experience in immediate next below Grade ( for PSU/Government/Semi-Government Employees ) Bhashkar 21/09/2018



                        //Award & Scholarship

                        var awardll = objAwardcon.tbl_mst_CandidateAwardScholarship.Where(x => x.Fk_candidateregistration == obj1.fk_CandidateId && x.Application_No == obj1.strApplicationNo).ToList();
                        numberLoop = awardll.Count();
                        j = "";
                        i = 0;
                        for (i = 0; i < numberLoop; i++)
                        {
                            if (i == 0)
                            {
                                j = "";
                            }
                            else
                            {
                                j = i.ToString();
                            }
                            ViewData["straward" + j] = awardll[i].straward;
                        }


                        //End Award & Scholarship


                        //Publication & Paper Presentation
                        var Publication = objPublicationcon.tbl_mst_CandidatePublicationPaperPresentation.Where(x => x.Fk_candidateregistration == obj1.fk_CandidateId && x.Application_No == obj1.strApplicationNo).ToList();
                        numberLoop = Publication.Count();
                        j = "";
                        i = 0;
                        for (i = 0; i < numberLoop; i++)
                        {
                            if (i == 0)
                            {
                                j = "";
                            }
                            else
                            {
                                j = i.ToString();
                            }
                            ViewData["str_Publication_PaperPresentation" + j] = Publication[i].str_Publication_PaperPresentation;
                        }
                        //End Publication & Paper Presentation


                        //Other Details Bhashkar 21/09/2018

                        var otherDetails = objOtherDetailsContext.tbl_mst_CandidateOtherDetails.Where(x => x.Fk_CandidateRegistrationID == obj1.fk_CandidateId && x.strApplicationNo == obj1.strApplicationNo).ToList();

                        if (otherDetails.Count() > 0)
                        {
                            ViewData["strProfessionalBodies"] = otherDetails.FirstOrDefault().strProfessionalBodies;
                            ViewData["strJoiningTimeReq"] = otherDetails.FirstOrDefault().strJoiningTimeReq;
                            ViewData["strJoinEarly"] = otherDetails.FirstOrDefault().strJoinEarly;
                        }

                        //End Other Details Bhashkar 21/09/2018


                        //Upload Details Bhashkar 21/09/2018

                        var uploadDetails = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == obj1.fk_CandidateId && x.str_applicationno == obj1.strApplicationNo).ToList();

                        if (uploadDetails.Count() > 0)
                        {
                            if (!string.IsNullOrEmpty(uploadDetails.FirstOrDefault().str_uploadphoto))
                            {
                                ViewData["hidstr_uploadphoto"] = Utility.ImageToBase64(Server.MapPath(uploadDetails.FirstOrDefault().str_uploadphoto));
                                ViewData["hiduploadphotopath"] = uploadDetails.FirstOrDefault().str_uploadphoto;
                            }
                            else
                            {
                                ViewData["hidstr_uploadphoto"] = "";
                                ViewData["hiduploadphotopath"] = "";
                            }
                            if (!string.IsNullOrEmpty(uploadDetails.FirstOrDefault().str_uploadsignature))
                            {
                                ViewData["hidstr_uploadsignature"] = Utility.ImageToBase64(Server.MapPath(uploadDetails.FirstOrDefault().str_uploadsignature));
                                ViewData["hiduploadsignaturepath"] = uploadDetails.FirstOrDefault().str_uploadsignature;
                            }
                            else
                            {
                                ViewData["hidstr_uploadsignature"] = "";
                                ViewData["hiduploadsignaturepath"] = "";
                            }

                        }

                        //End Other Details Bhashkar 21/09/2018

                        ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender", obj1.strGender);
                        ViewBag.strCategory = new SelectList(objCast.Castes.OrderBy(x => x.strCasteName).ToList(), "strCasteName", "strCasteName", obj1.strCategory);
                        ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName", obj1.strtypeofdisable);
                        ViewBag.strgrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName", obj1.strgrade);
                        var loginDetails = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(x => x.Candidate_Pk_intID == CandiadateId).FirstOrDefault();
                        ViewBag.strApplicantName = loginDetails.strCandidateFName + " " + loginDetails.strCandidateMName + " " + loginDetails.strCandidateLName;
                        ViewBag.strDomicilestate = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", obj1.strDomicilestate);
                        ViewBag.strState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", obj1.strState);
                        ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", obj1.strPermanentState);

                        return View(obj1);
                    }
                }
                else
                {
                    return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
                }
            }
            return View();
        }

        [HttpPost]
        public ActionResult EditCandidatePersonalDetails(tbl_mst_CandidatePersonalDetails tbl_mst_CandidatePersonalDetails, FormCollection frm)
        {
            if (current >= Convert.ToDateTime("14/10/2018"))
            {
                return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
            }

            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            if (CandiadateId == 0)
            {
                return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            }

            string intID = tbl_mst_CandidatePersonalDetails.strApplicationNo;

            ViewBag.strState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.str_organisationType = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType1 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType2 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType3 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType4 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            //NewAdd 
            ViewBag.str_organisationType5 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType6 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType7 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType8 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType9 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType10 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            ViewBag.str_organisationType11 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
            //NewAdd
            ViewBag.strDomicilestate = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName");
            ViewBag.strgrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName");
            //ViewBag.strpresentdesignation = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strDesignationName", "strDesignationName");
            ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender");
            ViewBag.strCategory = new SelectList(objCast.Castes.ToList(), "strCasteName", "strCasteName");
            ViewBag.fk_dicipline = new SelectList(objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.fk_advertisementid == tbl_mst_CandidatePersonalDetails.fk_advertiseid).ToList(), "fk_diciplineid", "DisciplineName");
            ViewBag.fk_postid = new SelectList((from s in objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.fk_advertisementid == tbl_mst_CandidatePersonalDetails.fk_advertiseid).ToList()
                                                select new
                                                {
                                                    fk_postid = s.fk_postid,
                                                    FullName = s.Postname + " ( " + s.DisciplineName + " )"
                                                }),
                 "fk_postid",
                 "FullName"
                 );
            ViewBag.EduQulifi = new SelectList("", "");


            int candidateId = Convert.ToInt32(Session["UserID"]);

            var Postcriteria = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == tbl_mst_CandidatePersonalDetails.fk_postid && x.fk_advertisementid == tbl_mst_CandidatePersonalDetails.fk_advertiseid).FirstOrDefault();
            var minExpAll = objpostnew.tbl_mst_Postnew.Where(x => x.Pk_Postid == tbl_mst_CandidatePersonalDetails.fk_postid).FirstOrDefault();



            string expmaxage = Postcriteria.str_postMaxage.ToString();
            string fremaxage = Postcriteria.str_postMaxage.ToString();
            string expCompdate = Postcriteria.dt_compareDate.ToString();
            string freCompdate = Postcriteria.dt_compareDate.ToString();
            var candidateDOB = Convert.ToDateTime(frm["dtDOB"]);

            string category1 = "";
            string category2 = frm["strGender"];
            string category3 = frm["strCategory"];
            if (frm["strPWD"] == "Yes")
            {
                category1 = "PWD";
            }
            var category = new string[] { category1, category2, category3 };
            var AgeRelaxationValue = objAgeRelaxation.tbl_mstAgeRelaxation.Where(x => category.Contains(x.strCategory)).Sum(x => x.AgeRelaxationYear);

            if (AgeRelaxationValue == null)
            {
                AgeRelaxationValue = 0;
            }



            if (frm["strExserviceMan"] == "No" && frm["strInternalCandidate"] == "No")
            {
                //double daysFrsh = (Convert.ToDateTime(freCompdate) - Convert.ToDateTime(candidateDOB)).TotalDays;
                //double Years = (daysFrsh / 365) - Convert.ToDouble(AgeRelaxationValue);

                DateTime date2 = Convert.ToDateTime(freCompdate);
                DateTime date1 = Convert.ToDateTime(candidateDOB);

                TimeSpan diff = date2 - date1;
                int Years = (diff.Days / 366) - Convert.ToInt32(AgeRelaxationValue);
                DateTime workingDate = date1.AddYears(Years);
                while (workingDate.AddYears(1) <= date2)
                {
                    workingDate = workingDate.AddYears(1);
                    Years++;
                }
                //---------------------------------------------
                //months
                diff = date2 - workingDate;
                int Months = diff.Days / 31;
                workingDate = workingDate.AddMonths(Months);
                while (workingDate.AddMonths(1) <= date2)
                {
                    workingDate = workingDate.AddMonths(1);
                    Months++;
                }
                //---------------------------------------------
                //weeks and days
                diff = date2 - workingDate;
                int Days = diff.Days;

                int monthDay = Months * 30 + Days;
                Years = Years - Convert.ToInt32(AgeRelaxationValue);
                if ((Years > Convert.ToInt32(fremaxage)) || (Years == Convert.ToInt32(fremaxage) && monthDay != 0))
                {
                    ViewBag.Message = "Age Criteria not met";
                    //return RedirectToAction("CandidatePersonalDetails", "");
                    //return RedirectToAction("CandidatePersonalDetails", "RecruitmentCareer", new { id = id });
                    return View();

                }

            }


            if (minExpAll.str_minexp != null && frm["strInternalCandidate"] == "No")
            {
                double days = Convert.ToInt32(minExpAll.str_minexp) * 365;
                double days1 = 0;
                if (frm["totalYear"] != null && frm["totalYear"] != "")
                {
                    days1 = Convert.ToInt32(frm["totalYear"]);
                }


                if (Convert.ToDouble(days1) < Convert.ToDouble(days))
                {
                    ViewBag.Message = "Experience Criteria not met";
                    //return RedirectToAction("CandidatePersonalDetails", "");
                    //return RedirectToAction("CandidatePersonalDetails", "RecruitmentCareer", new { id = id });
                    return View();

                }


            }



            tbl_mst_CandidateQualification obj = new tbl_mst_CandidateQualification();

            var qualification = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Application_No == intID);
            foreach (var candidatequali in qualification)
            {
                tblQulifi.Entry(candidatequali).State = EntityState.Deleted;
            }
            tblQulifi.SaveChanges();
            for (int i = 0; i <= 3; i++)
            {

                var j = i.ToString();
                if (j == "0")
                {
                    j = "";
                }

                if (!string.IsNullOrEmpty(frm["Str_exampassed" + j]) || !string.IsNullOrEmpty(frm["Str_course" + j]) || !string.IsNullOrEmpty(frm["Str_board" + j]) || !string.IsNullOrEmpty(frm["Str_passingdetails" + j]) || !string.IsNullOrEmpty(frm["Str_passingyear" + j]))
                {
                    obj.Str_exampassed = frm["Str_exampassed" + j];
                    obj.Str_course = frm["Str_course" + j];
                    obj.Str_board = frm["Str_board" + j];
                    obj.Str_passingdetails = frm["Str_passingdetails" + j];
                    obj.Str_duration = frm["Str_duration" + j];


                    if (frm["StrRemarks" + j] != "Pursuing")
                    {
                        obj.Str_passingyear = frm["Str_passingyear" + j];
                    }
                    else
                    {
                        obj.Str_passingyear = frm["hidMaxExpdate"];
                    }
                    //Bhadshkar 190918
                    //obj.Str_passingyear = frm["Str_passingyear" + j];


                    obj.Str_division = frm["Str_division" + j];
                    obj.Str_Marks = frm["Str_Marks" + j];
                    obj.StrRemarks = frm["StrRemarks" + j];

                    obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    obj.Fk_int_CandidateRegistrationID = candidateId;
                    obj.Application_No = intID;
                    tblQulifi.tbl_mst_CandidateQualification.Add(obj);
                    tblQulifi.SaveChanges();
                }
            }


            for (int i = 1; i <= 4; i++)
            {

                var j = i.ToString();
                if (!string.IsNullOrEmpty(frm["others_exampassed" + j]) || !string.IsNullOrEmpty(frm["others_course" + j]) || !string.IsNullOrEmpty(frm["others_board" + j]) || !string.IsNullOrEmpty(frm["others_passingdetails" + j]))
                {
                    obj.Str_exampassed = frm["others_exampassed" + j];
                    obj.Str_course = frm["others_course" + j];
                    obj.Str_board = frm["others_board" + j];

                    if (frm["others_Remarks" + j] != "Pursuing")
                    {
                        obj.Str_passingyear = frm["others_passingyear" + j];
                    }
                    else
                    {
                        obj.Str_passingyear = frm["hidMaxExpdate"];
                    }

                    obj.Str_passingdetails = frm["others_passingdetails" + j];
                    obj.Str_duration = frm["others_duration" + j];
                    //obj.Str_passingyear = frm["others_passingyear" + j];
                    obj.Str_division = frm["others_division" + j];
                    obj.Str_Marks = frm["others_Marks" + j];

                    obj.StrRemarks = frm["others_Remarks" + j];
                    obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    obj.Fk_int_CandidateRegistrationID = candidateId;
                    obj.Application_No = intID;
                    tblQulifi.tbl_mst_CandidateQualification.Add(obj);
                    tblQulifi.SaveChanges();
                }
            }




            tbl_mst_CandidateExperience objExp = new tbl_mst_CandidateExperience();

            var exp = tblExperience.tbl_mst_CandidateExperience.Where(x => x.ApplicationNo == intID);
            foreach (var candidateexp in exp)
            {
                tblExperience.Entry(candidateexp).State = EntityState.Deleted;
            }
            tblExperience.SaveChanges();

            for (int i = 0; i <= 11; i++)
            {

                var j = i.ToString();
                if (j == "0")
                {
                    j = "";
                }

                if (!string.IsNullOrEmpty(frm["str_organisation" + j]) && !string.IsNullOrEmpty(frm["dt_fromdate" + j]) && !string.IsNullOrEmpty(frm["str_organisationType" + j]))
                {

                    if ((frm["StrEmploymentPresentStatus" + j] == "Currently Working") || ((frm["StrEmploymentPresentStatus" + j] == "Previous Employment") && (!string.IsNullOrEmpty(frm["dt_todate" + j]))))
                    {
                        objExp.Str_designation = frm["Str_designation" + j];
                        objExp.dt_fromdate = Convert.ToDateTime(frm["dt_fromdate" + j]);

                        if (frm["StrEmploymentPresentStatus" + j] == "Currently Working")
                        {
                            objExp.dt_todate = Convert.ToDateTime(frm["hidMaxExpdate"]);

                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(frm["dt_todate" + j]))
                            {
                                objExp.dt_todate = Convert.ToDateTime(frm["dt_todate" + j]);
                            }
                            //else
                            //{
                            //    ViewBag.Message = "To date can not be blank";
                            //    return View();
                            //}
                        }

                        objExp.str_noyears = frm["str_noyears" + j];
                        objExp.str_organisation = frm["str_organisation" + j];
                        objExp.str_organisationType = frm["str_organisationType" + j];
                        objExp.str_remarks = frm["str_remarks" + j];
                        objExp.str_organisationType = frm["str_organisationType" + j];
                        objExp.str_CTC = frm["str_CTC" + j];
                        objExp.str_PayScale = frm["str_PayScale" + j];
                        objExp.StrEmploymentPresentStatus = frm["StrEmploymentPresentStatus" + j];

                        objExp.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        objExp.Fk_CandidateRegistrationID = candidateId;
                        objExp.ApplicationNo = intID;
                        tblExperience.tbl_mst_CandidateExperience.Add(objExp);
                        tblExperience.SaveChanges();
                    }
                }
            }

            tbl_NextBelowGrade objnexbellow = new tbl_NextBelowGrade();

            var NextBelowGrade = tblExperience.tbl_NextBelowGrade.Where(x => x.strApplicationNo == intID);
            foreach (var Other in NextBelowGrade)
            {
                tblExperience.Entry(Other).State = EntityState.Deleted;
            }
            tblExperience.SaveChanges();

            if (!string.IsNullOrEmpty(frm["strimmediateGrade"]) || !string.IsNullOrEmpty(frm["dt_immediatefromdate"]) || !string.IsNullOrEmpty(frm["dt_immediatetodate"]))
            {
                objnexbellow.strGrade = frm["strimmediateGrade"];
                objnexbellow.dtFromDate = frm["dt_immediatefromdate"];
                objnexbellow.dtTodate = frm["dt_immediatetodate"];
                objnexbellow.strYear = frm["str_immediatenoyears"];
                objnexbellow.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objnexbellow.Fk_CandidateRegistrationID = candidateId;
                objnexbellow.strApplicationNo = intID;
                tblExperience.tbl_NextBelowGrade.Add(objnexbellow);
                tblExperience.SaveChanges();
            }


            tbl_mst_CandidateAwardScholarship objAward = new tbl_mst_CandidateAwardScholarship();
            var award = objAwardcon.tbl_mst_CandidateAwardScholarship.Where(x => x.Application_No == intID);
            foreach (var candidateaward in award)
            {
                objAwardcon.Entry(candidateaward).State = EntityState.Deleted;
            }
            objAwardcon.SaveChanges();
            for (int i = 0; i <= 2; i++)
            {
                var j = i.ToString();
                if (j == "0")
                {
                    j = "";
                }

                if (!string.IsNullOrEmpty(frm["straward" + j]))
                {
                    objAward.straward = frm["straward" + j];
                    objAward.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    objAward.Fk_candidateregistration = candidateId;
                    objAward.Application_No = intID;
                    objAwardcon.tbl_mst_CandidateAwardScholarship.Add(objAward);
                    objAwardcon.SaveChanges();
                }
            }



            tbl_mst_CandidatePublicationPaperPresentation objPublication = new tbl_mst_CandidatePublicationPaperPresentation();
            var PaperPresentation = objPublicationcon.tbl_mst_CandidatePublicationPaperPresentation.Where(x => x.Application_No == intID);
            foreach (var candidatePaperPresentation in PaperPresentation)
            {
                objPublicationcon.Entry(candidatePaperPresentation).State = EntityState.Deleted;
            }
            objPublicationcon.SaveChanges();
            for (int i = 0; i <= 2; i++)
            {
                var j = i.ToString();
                if (j == "0")
                {
                    j = "";
                }

                if (!string.IsNullOrEmpty(frm["str_Publication_PaperPresentation" + j]))
                {
                    objPublication.str_Publication_PaperPresentation = frm["str_Publication_PaperPresentation" + j];
                    objPublication.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    objPublication.Fk_candidateregistration = candidateId;
                    objPublication.Application_No = intID;
                    objPublicationcon.tbl_mst_CandidatePublicationPaperPresentation.Add(objPublication);
                    objPublicationcon.SaveChanges();
                }
            }

            //Other Details
            tbl_mst_CandidateOtherDetails objOtherDetails = new tbl_mst_CandidateOtherDetails();
            var OtherDetails = objOtherDetailsContext.tbl_mst_CandidateOtherDetails.Where(x => x.strApplicationNo == intID);
            foreach (var Other in OtherDetails)
            {
                objOtherDetailsContext.Entry(Other).State = EntityState.Deleted;
            }
            objOtherDetailsContext.SaveChanges();

            objOtherDetails.Fk_CandidateRegistrationID = candidateId;
            objOtherDetails.strApplicationNo = intID;
            objOtherDetails.strProfessionalBodies = frm["strProfessionalBodies"];
            objOtherDetails.strJoiningTimeReq = frm["strJoiningTimeReq"];
            objOtherDetails.strJoinEarly = frm["strJoinEarly"];
            objOtherDetails.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            objOtherDetailsContext.tbl_mst_CandidateOtherDetails.Add(objOtherDetails);
            objOtherDetailsContext.SaveChanges();

            //Upload Section

            tbl_mst_candidatephotoupload tbl_mst_candidatephotoupload = new tbl_mst_candidatephotoupload();
            TempData["Appno"] = intID;
            var appno = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.strApplicationNo == intID).FirstOrDefault();
            var Photoupload = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.str_applicationno == intID);
            foreach (var candidatephotoupload in Photoupload)
            {
                objcandidatephotoupload.Entry(candidatephotoupload).State = EntityState.Deleted;
            }
            objcandidatephotoupload.SaveChanges();

            HttpPostedFileBase str_uploadphoto = Request.Files["str_uploadphoto"];
            HttpPostedFileBase str_uploadsignature = Request.Files["str_uploadsignature"];


            if (str_uploadphoto.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(str_uploadphoto.FileName);
                var AutoGenFileName = "Photo" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Photo/"), AutoGenFileName + fileExtension);
                str_uploadphoto.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                string imagepath = "~/Upload/Photo/" + newpath;
                tbl_mst_candidatephotoupload.str_uploadphoto = imagepath;
            }

            else
            {
                tbl_mst_candidatephotoupload.str_uploadphoto = frm["hiduploadphotopath"];
            }


            if (str_uploadsignature.ContentLength > 0)
            {
                var fileExtension = Path.GetExtension(str_uploadsignature.FileName);
                var AutoGenFileName = "Signature" + "-" + System.DateTime.Now.Ticks.ToString();
                var path = Path.Combine(Server.MapPath("~/Upload/Signature/"), AutoGenFileName + fileExtension);
                str_uploadsignature.SaveAs(path);
                string fl = path.Substring(path.LastIndexOf("\\"));
                string[] split = fl.Split('\\');
                string newpath = split[1];
                string imagepath = "~/Upload/Signature/" + newpath;
                tbl_mst_candidatephotoupload.str_uploadsignature = imagepath;

            }

            else
            {
                tbl_mst_candidatephotoupload.str_uploadsignature = frm["hiduploadsignaturepath"];
            }

            tbl_mst_candidatephotoupload.str_applicationno = intID;
            tbl_mst_candidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            tbl_mst_candidatephotoupload.fk_intcandidateid = appno.fk_CandidateId;
            tbl_mst_candidatephotoupload.is_active = "YES";
            objcandidatephotoupload.tbl_mst_candidatephotoupload.Add(tbl_mst_candidatephotoupload);
            objcandidatephotoupload.SaveChanges();
            ViewBag.message = "Account Created";
            return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");


        }

        [HttpPost]
        public ActionResult QualificationByPost(int fk_postid, int fk_advertiseid)
        {
            var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == fk_postid && x.fk_advertisementid == fk_advertiseid).FirstOrDefault() ?? new tbl_transaction_Postcriteria();

            var IsCertificateRequired = postCaitareaDetails.IsCertificateRequired;
            ViewBag.IsCertificateRequired = IsCertificateRequired;
            ViewBag.CertificateDetails = postCaitareaDetails.CertificateDetails;
            ViewBag.ValidFirstAid = postCaitareaDetails.ValidFirstAid;
            string sampleSentence = postCaitareaDetails.str_qualification ?? "";
            string[] words = System.Text.RegularExpressions.Regex.Split(sampleSentence, "@");
            List<Qulification> fstSubject = new List<Qulification>();
            foreach (var quliName in words)
            {
                if (quliName != "")
                {
                    Qulification qu = new Qulification() { str_qualification = quliName.Trim(' ') };
                    fstSubject.Add(qu);
                }
            }
            ViewBag.strEssentialQualification = new SelectList((from s in fstSubject
                                                                select new
                                                                {
                                                                    id = s.str_qualification,
                                                                    Name = s.str_qualification
                                                                }), "id", "name", null);

            return Json(new { EssebtialQualification = ViewBag.strEssentialQualification, IsCertificateRequired = ViewBag.IsCertificateRequired, CertificateDetails = ViewBag.CertificateDetails, ValidFirstAid = ViewBag.ValidFirstAid });

        }
        [HttpPost]
        public ActionResult Postbydiscipline(int fk_dicipline, int fk_advertiseid)
        {
            //&& x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid
            //var Unit = fk_intUnitId.ToString();

            int pkId = Convert.ToInt32(Session["UserID"]);
            if (pkId != 0)
            {
                var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault() ?? new tbl_mst_CandidatePersonalDetails(); ;

                var Postlist = objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.fk_diciplineid == fk_dicipline && x.fk_advertisementid == fk_advertiseid).ToList();

                int fk_postid = (Postlist.FirstOrDefault() ?? new Vw_Postdesiciplinedetails()).fk_postid;
                // int? fk_advertiseid = CandidatePersonalDetails.fk_advertiseid;
                var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == fk_postid && x.fk_advertisementid == fk_advertiseid).FirstOrDefault() ?? new tbl_transaction_Postcriteria();

                string sampleSentence = postCaitareaDetails.str_qualification ?? "";
                string[] words = System.Text.RegularExpressions.Regex.Split(sampleSentence, "@");
                List<Qulification> fstSubject = new List<Qulification>();
                foreach (var quliName in words)
                {
                    if (quliName != "")
                    {
                        Qulification qu = new Qulification() { str_qualification = quliName.Trim(' ') };
                        fstSubject.Add(qu);
                    }
                }
                ViewBag.strEssentialQualification = new SelectList((from s in fstSubject
                                                                    select new
                                                                    {
                                                                        id = s.str_qualification,
                                                                        Name = s.str_qualification
                                                                    }), "id", "name", CandidatePersonalDetails.strEssentialQualification);

                return Json(new { PostMaster = Postlist, EssebtialQualification = ViewBag.strEssentialQualification });
            }
            else
            {
                var Postlist = objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.fk_diciplineid == fk_dicipline).ToList();
                return Json(new { PostMaster = Postlist });
            }

        }

        [HttpPost]
        public ActionResult PostbyDesignation(string grade)
        {
            //var Unit = fk_intUnitId.ToString();
            //tbl_mst_Postnewcontext obj =new tbl_mst_Postnewcontext();
            var gradebydeg = objGrade_Designation.tbl_mstGrade_Designation.Where(x => x.strGradeName == grade).FirstOrDefault().strDesignationName;
            return Json(new { Designation = gradebydeg });

        }

        public ActionResult ApplicationDashboard(string AppNo)
        {
            ViewBag.strApplicationNo = AppNo;
            return View();
        }

        public ActionResult ApplicantDashboard()
        {
            vw_PostwithDisciplineContext pwd = new vw_PostwithDisciplineContext();

            int candidateId = Convert.ToInt32(Session["UserID"]);
            if (candidateId > 0)
            {
                var candidatedetails = objAcknowledgement.Vw_Applicationdetails.Where(a => a.fk_CandidateId == candidateId).OrderByDescending(x => x.strApplicationNo).ToList();

                int? postId = candidatedetails.FirstOrDefault().fk_postid;
                int? diciplineid = candidatedetails.FirstOrDefault().fk_diciplineid;
                string strApplicationNo = candidatedetails.FirstOrDefault().strApplicationNo;

                var checkGrade = pwd.vw_PostwithDiscipline.Where(x => x.fk_discipline == diciplineid && x.Pk_Postid == postId).FirstOrDefault().str_Grade;
                ViewBag.showHallTicket = "No";
                if (checkGrade == "E-0" || checkGrade == "E-1" || checkGrade == "E-2" || checkGrade == "E-3" || checkGrade == "E-4")
                {
                    ViewBag.showHallTicket = "Yes";
                }

                ViewBag.feeClaimDetailsCount = objtbl_mst_CandidateDDDetailsContext.tbl_mstFeeClaim_new.Where(x => x.fk_intCandidateId == candidateId).ToList().Count();

                //var checkData = objtbl_mst_CandidateDDDetailsContext.tbl_mstFeeClaim.Where(x => x.fk_intCandidateId == candidateId).ToList();
                //string applicationNumber = "06Estt/1/2005/2018098402018,06Estt/1/2005/2018177942018,06Estt/1/2005/2018177942018,06Estt/1/2005/2018173722018,06Estt/1/2005/2018135322018,06Estt/1/2005/2018151302018,06Estt/1/2005/2018017252018,06Estt/1/2005/2018202052018,06Estt/1/2005/2018201812018,06Estt/1/2005/2018141342018,06Estt/1/2005/2018120152018,06Estt/1/2005/2018153272018,06Estt/1/2005/2018089812018,06Estt/1/2005/2018078782018,06Estt/1/2005/2018124852018,06Estt/1/2005/2018208082018,06Estt/1/2005/2018200872018,06Estt/1/2005/2018093222018,06Estt/1/2005/2018107722018,06Estt/1/2005/2018158342018";
                //if (checkData.Count() > 0 && applicationNumber.Contains(checkData.FirstOrDefault().strApplicationNo) && checkData.FirstOrDefault().dtUpdateDate == null)
                //{
                //    ViewBag.status = "Edit";
                //}



                string applicationNumber = "06Estt/1/2005/2018013222018, 06Estt/1/2005/2018173762018, 06Estt/1/2005/2018150032018, 06Estt/1/2005/2018165062018, 06Estt/1/2005/2018199092018, 06Estt/1/2005/2018019262018, 06Estt/1/2005/2018045632018, 06Estt/1/2005/2018127532018, 06Estt/1/2005/2018222432018, 06Estt/1/2005/2018040542018, 06Estt/1/2005/2018196442018, 06Estt/1/2005/2018065662018, 06Estt/1/2005/2018151062018, 06Estt/1/2005/2018071992018, 06Estt/1/2005/2018100602018, 06Estt/1/2005/2018099372018, 06Estt/1/2005/2018155452018, 06Estt/1/2005/2018008512018, 06Estt/1/2005/2018185992018, 06Estt/1/2005/2018148852018, 06Estt/1/2005/2018043602018, 06Estt/1/2005/2018174862018, 06Estt/1/2005/2018115442018, 06Estt/1/2005/2018087432018, 06Estt/1/2005/2018120072018, 06Estt/1/2005/2018196492018, 06Estt/1/2005/2018222502018, 06Estt/1/2005/2018197462018, 06Estt/1/2005/2018148062018, 06Estt/1/2005/2018230282018, 06Estt/1/2005/2018040282018, 06Estt/1/2005/2018109432018, 06Estt/1/2005/2018057902018, 06Estt/1/2005/2018146222018, 06Estt/1/2005/2018210602018, 06Estt/1/2005/2018061492018, 06Estt/1/2005/2018021832018, 06Estt/1/2005/2018031422018, 06Estt/1/2005/2018090442018, 06Estt/1/2005/2018009702018, 06Estt/1/2005/2018213202018, 06Estt/1/2005/2018204052018, 06Estt/1/2005/2018108302018, 06Estt/1/2005/2018024412018, 06Estt/1/2005/2018055592018, 06Estt/1/2005/2018030192018, 06Estt/1/2005/2018135232018, 06Estt/1/2005/2018031902018, 06Estt/1/2005/2018217082018, 06Estt/1/2005/2018143812018, 06Estt/1/2005/2018010692018, 06Estt/1/2005/2018221662018, 06Estt/1/2005/2018033442018, 06Estt/1/2005/2018136152018, 06Estt/1/2005/2018042152018, 06Estt/1/2005/2018184782018, 06Estt/1/2005/2018132122018, 06Estt/1/2005/2018144482018, 06Estt/1/2005/2018220142018, 06Estt/1/2005/2018162332018, 06Estt/1/2005/2018135712018, 06Estt/1/2005/2018079302018, 06Estt/1/2005/2018184402018, 06Estt/1/2005/2018072832018, 06Estt/1/2005/2018166062018, 06Estt/1/2005/2018008922018, 06Estt/1/2005/2018200132018, 06Estt/1/2005/2018011542018, 06Estt/1/2005/2018192742018, 06Estt/1/2005/2018018742018, 06Estt/1/2005/2018151412018, 06Estt/1/2005/2018028572018, 06Estt/1/2005/2018085082018, 06Estt/1/2005/2018229982018, 06Estt/1/2005/2018135272018, 06Estt/1/2005/2018215992018, 06Estt/1/2005/2018003752018, 06Estt/1/2005/2018042232018, 06Estt/1/2005/2018028222018, 06Estt/1/2005/2018068232018, 06Estt/1/2005/2018131122018, 06Estt/1/2005/2018078552018, 06Estt/1/2005/2018030302018, 06Estt/1/2005/2018166922018, 06Estt/1/2005/2018144712018, 06Estt/1/2005/2018040602018, 06Estt/1/2005/2018224012018, 06Estt/1/2005/2018043962018, 06Estt/1/2005/2018136232018, 06Estt/1/2005/2018229572018, 06Estt/1/2005/2018146662018, 06Estt/1/2005/2018119322018, 06Estt/1/2005/2018208792018, 06Estt/1/2005/2018104822018, 06Estt/1/2005/2018108762018, 06Estt/1/2005/2018163662018, 06Estt/1/2005/2018148222018, 06Estt/1/2005/2018105172018, 06Estt/1/2005/2018122172018, 06Estt/1/2005/2018004682018, 06Estt/1/2005/2018213792018, 06Estt/1/2005/2018094072018, 06Estt/1/2005/2018103682018, 06Estt/1/2005/2018131042018, 06Estt/1/2005/2018177762018, 06Estt/1/2005/2018174412018, 06Estt/1/2005/2018065122018, 06Estt/1/2005/2018130162018, 06Estt/1/2005/2018114382018, 06Estt/1/2005/2018148202018, 06Estt/1/2005/2018202272018, 06Estt/1/2005/2018054512018, 06Estt/1/2005/2018101082018, 06Estt/1/2005/2018200992018, 06Estt/1/2005/2018150502018, 06Estt/1/2005/2018083682018, 06Estt/1/2005/2018134722018, 06Estt/1/2005/2018046092018, 06Estt/1/2005/2018157412018, 06Estt/1/2005/2018184012018, 06Estt/1/2005/2018196082018, 06Estt/1/2005/2018120312018, 06Estt/1/2005/2018106682018, 06Estt/1/2005/2018127882018, 06Estt/1/2005/2018172842018, 06Estt/1/2005/2018133102018, 06Estt/1/2005/2018049962018, 06Estt/1/2005/2018072642018, 06Estt/1/2005/2018013022018, 06Estt/1/2005/2018193072018, 06Estt/1/2005/2018129902018, 06Estt/1/2005/2018212322018, 06Estt/1/2005/2018173452018, 06Estt/1/2005/2018068542018, 06Estt/1/2005/2018123672018, 06Estt/1/2005/2018180612018, 06Estt/1/2005/2018216742018, 06Estt/1/2005/2018034992018, 06Estt/1/2005/2018210352018, 06Estt/1/2005/2018122092018, 06Estt/1/2005/2018011862018, 06Estt/1/2005/2018055512018, 06Estt/1/2005/2018042172018, 06Estt/1/2005/2018003972018, 06Estt/1/2005/2018046882018, 06Estt/1/2005/2018054292018, 06Estt/1/2005/2018071042018, 06Estt/1/2005/2018206242018, 06Estt/1/2005/2018152962018, 06Estt/1/2005/2018096672018, 06Estt/1/2005/2018140022018, 06Estt/1/2005/2018201462018, 06Estt/1/2005/2018180032018, 06Estt/1/2005/2018054142018, 06Estt/1/2005/2018057072018, 06Estt/1/2005/2018218952018, 06Estt/1/2005/2018150282018, 06Estt/1/2005/2018064902018, 06Estt/1/2005/2018203182018, 06Estt/1/2005/2018145312018, 06Estt/1/2005/2018043242018, 06Estt/1/2005/2018190752018, 06Estt/1/2005/2018165892018, 06Estt/1/2005/2018040662018, 06Estt/1/2005/2018095092018, 06Estt/1/2005/2018096902018, 06Estt/1/2005/2018046422018, 06Estt/1/2005/2018065812018, 06Estt/1/2005/2018056322018, 06Estt/1/2005/2018127632018, 06Estt/1/2005/2018181052018, 06Estt/1/2005/2018205552018, 06Estt/1/2005/2018094412018, 06Estt/1/2005/2018062032018, 06Estt/1/2005/2018090602018, 06Estt/1/2005/2018128462018, 06Estt/1/2005/2018191642018, 06Estt/1/2005/2018086262018, 06Estt/1/2005/2018145242018, 06Estt/1/2005/2018063472018, 06Estt/1/2005/2018176452018, 06Estt/1/2005/2018011432018, 06Estt/1/2005/2018153512018, 06Estt/1/2005/2018151292018, 06Estt/1/2005/2018150792018, 06Estt/1/2005/2018056102018, 06Estt/1/2005/2018079152018, 06Estt/1/2005/2018086412018, 06Estt/1/2005/2018113812018, 06Estt/1/2005/2018042922018, 06Estt/1/2005/2018086172018, 06Estt/1/2005/2018163162018, 06Estt/1/2005/2018126092018, 06Estt/1/2005/2018117992018, 06Estt/1/2005/2018176372018, 06Estt/1/2005/2018208112018, 06Estt/1/2005/2018177292018, 06Estt/1/2005/2018122102018, 06Estt/1/2005/2018140282018, 06Estt/1/2005/2018230802018, 06Estt/1/2005/2018134672018, 06Estt/1/2005/2018151852018, 06Estt/1/2005/2018184742018, 06Estt/1/2005/2018170672018, 06Estt/1/2005/2018049392018, 06Estt/1/2005/2018210122018, 06Estt/1/2005/2018011152018, 06Estt/1/2005/2018018592018, 06Estt/1/2005/2018083052018,";
                //if (checkData.Count() > 0 && applicationNumber.Contains(checkData.FirstOrDefault().strApplicationNo))
                //{
                //  ViewBag.status = "Edit";
                //}
                //ViewBag.checkFeesDataCount = objtbl_mst_CandidateDDDetailsContext.tbl_dumData_Fee_Claim.Where(x => x.strApplicationNo == strApplicationNo).ToList().Count();

                ViewBag.checkFeesDataCount = 0;
                if (applicationNumber.Contains(strApplicationNo))
                {
                    ViewBag.checkFeesDataCount = 1;
                }


                ViewBag.DraftDetails = objAcknowledgement.vw_DraftData.Where(a => a.fk_CandidateId == candidateId).ToList();
                return View(candidatedetails);
            }
            else
            {
                return RedirectToAction("CandidateLogin");
            }
        }

        public ActionResult NoApplicantDashboard()
        {
            vw_PostwithDisciplineContext pwd = new vw_PostwithDisciplineContext();

            int candidateId = Convert.ToInt32(Session["UserID"]);
            if (candidateId > 0)
            {

                return View();
            }
            else
            {
                return RedirectToAction("CandidateLogin");
            }
        }

        public ActionResult TestApplicantDashboard()
        {

            int candidateId = Convert.ToInt32(Session["UserID"]);
            if (candidateId > 0)
            {
                var candidatedetails = objAcknowledgement.Vw_Applicationdetails.Where(a => a.fk_CandidateId == candidateId).OrderByDescending(x => x.strApplicationNo).ToList();
                ViewBag.DraftDetails = objAcknowledgement.vw_DraftData.Where(a => a.fk_CandidateId == candidateId).ToList();

                return View(candidatedetails);
            }
            else
            {
                return RedirectToAction("CandidateLogin");
            }
        }



        //Bhashkar by gourab 23/10/17
        public ActionResult ApplicationPrint(string AppNo)
        {

            var getViewDetail = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo).ToList();
            var getViewDetailOnlyPhoto = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo && !string.IsNullOrEmpty(a.str_uploadphoto)).ToList();
            var getViewDetailOnlySignature = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo && !string.IsNullOrEmpty(a.str_uploadsignature)).ToList();

            var candidatedetails = objAcknowledgement.Vw_Applicationdetails.Where(a => a.strApplicationNo == AppNo).ToList();

            if (getViewDetail.Count != 0 && getViewDetailOnlyPhoto.Count != 0 && getViewDetailOnlySignature.Count != 0)
            {
                eRequirtmentForm chl = new eRequirtmentForm();
                var reportdetails = getViewDetail.FirstOrDefault();
                var candidate = candidatedetails.FirstOrDefault();
                //var postdetails = objpostdesicipline.Vw_Postdesiciplinedetails.Where(a => a.fk_postid == candidate.fk_postid).FirstOrDefault();
                chl.HeadLine4 = "Application Form No.:" + " " + reportdetails.str_applicationno;
                chl.ApplicationNo = Convert.ToString(reportdetails.str_applicationno);
                chl.HCLLogo = @"~/images/hcl_logo.jpg";
                //chl.HCLPhoto = @"~/images/hcl_new_photo.jpg";
                chl.HCLPhoto = reportdetails.str_uploadphoto;
                chl.SignPhoto = reportdetails.str_uploadsignature;
                chl.HeadLine1 = "Hindustan Copper Limited";
                chl.HeadLine2 = "(A Govt. of India Enteprise)";
                chl.HeadLine3 = "Kolkata-700019";
                chl.decipline = candidate.DisciplineName;
                chl.post = candidate.Postname;
                var mem = chl.CreateRequirtment();

                // ~/uploads/beec94a8-a56d-4657-a8a2-cc54a7679e9bsnapshot-005.jpg
                byte[] bytesInStream = mem.ToArray();



                Response.Clear();
                Response.ContentType = "application/force-download";
                Response.AddHeader("content-disposition", "attachment;    filename=" + reportdetails.str_applicationno + ".pdf");
                Response.BinaryWrite(bytesInStream);
                Response.End();
                Session["upload"] = "ok";
                return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");

            }
            else
            {
                return RedirectToAction("UploadPhotoSignature", "RecruitmentCareer", new { AppNo = AppNo });
            }
            // return View();
        }

        public ActionResult UploadPhotoSignature(string AppNo)
        {
            TempData["AppNo"] = AppNo;
            return View();
        }

        [HttpPost]
        public ActionResult UploadPhotoSignature(FormCollection frm)
        {
            string AppNo = TempData["AppNo"].ToString();

            var candidatedetails = objAcknowledgement.Vw_Applicationdetails.Where(a => a.strApplicationNo == AppNo).FirstOrDefault();
            var getViewDetail = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo).ToList();
            foreach (var candidatephotoupload in getViewDetail)
            {
                objcandidatephotoupload.Entry(candidatephotoupload).State = EntityState.Deleted;
            }
            objcandidatephotoupload.SaveChanges();

            getViewDetail = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo).ToList();

            if (getViewDetail.Count == 0)
            {

                tbl_mst_candidatephotoupload tbl_mst_candidatephotoupload = new tbl_mst_candidatephotoupload();

                HttpPostedFileBase str_uploadphoto = Request.Files["str_uploadphoto"];
                HttpPostedFileBase str_uploadsignature = Request.Files["str_uploadsignature"];

                if (str_uploadphoto.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(str_uploadphoto.FileName);
                    var AutoGenFileName = "Photo" + "-" + System.DateTime.Now.Ticks.ToString();
                    var path = Path.Combine(Server.MapPath("~/Upload/Photo/"), AutoGenFileName + fileExtension);
                    str_uploadphoto.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/Upload/Photo/" + newpath;
                    tbl_mst_candidatephotoupload.str_uploadphoto = imagepath;

                }

                if (str_uploadsignature.ContentLength > 0)
                {
                    var fileExtension = Path.GetExtension(str_uploadsignature.FileName);
                    var AutoGenFileName = "Signature" + "-" + System.DateTime.Now.Ticks.ToString();
                    var path = Path.Combine(Server.MapPath("~/Upload/Signature/"), AutoGenFileName + fileExtension);
                    str_uploadsignature.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/Upload/Signature/" + newpath;
                    tbl_mst_candidatephotoupload.str_uploadsignature = imagepath;

                }


                //string AcknowledgeId = objcandidatephotoupload.ACknowledgmentID();
                //tbl_mst_candidatephotoupload.str_acknowledgementno = AcknowledgeId;
                tbl_mst_candidatephotoupload.str_applicationno = AppNo;
                tbl_mst_candidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                tbl_mst_candidatephotoupload.fk_intcandidateid = candidatedetails.fk_CandidateId;
                tbl_mst_candidatephotoupload.is_active = "YES";
                objcandidatephotoupload.tbl_mst_candidatephotoupload.Add(tbl_mst_candidatephotoupload);
                objcandidatephotoupload.SaveChanges();
                ViewBag.Message = string.Format("Data updated successfully!");
            }
            //return View();
            return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");

        }

        [HttpPost]
        public ActionResult Essential(int fk_postid)
        {

            var PostMaster = objPost.tbl_mst_Post.Where(x => x.Pk_Postid == fk_postid).FirstOrDefault();
            return Json(new { Post = PostMaster.Fk_Qualification });

        }

        [HttpPost]
        public ActionResult FillQualification(int postId, int addId)
        {
            string FresherExprence = "Fresher";

            var postCaitareaDetails = objqualification.tbl_transaction_Postcriteria.Where(x => x.fk_postid == postId && x.fk_advertisementid == addId).FirstOrDefault();
            //var postDetails = objpostnew.tbl_mst_Postnew.Where(x => x.Pk_Postid == postId).FirstOrDefault();




            if (postCaitareaDetails.strPostIsFreshersAllowed != "Yes")
            {
                FresherExprence = "Exprence";
            }


            string sampleSentence = postCaitareaDetails.str_qualification;
            string[] words = System.Text.RegularExpressions.Regex.Split(sampleSentence, "@");
            List<string> fstSubject = new List<string>();
            foreach (var quliName in words)
            {
                fstSubject.Add(quliName.Trim(' '));
            }


            string castAll = postCaitareaDetails.str_caste;
            string[] words1 = System.Text.RegularExpressions.Regex.Split(castAll, ",");
            List<string> cast = new List<string>();
            foreach (var quliName in words1)
            {
                cast.Add(quliName.Trim(' '));
            }

            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            var CandidateRegistrationDraft = objtbl_temp_CandidateApplicationDetails.tbl_temp_CandidateApplicationDetails.Where(x => x.fk_CandidateId == CandiadateId && x.fk_advertiseid == addId && x.fk_postid == postId).FirstOrDefault();

            return Json(new { fstQuli = fstSubject, ErrorCount = words.Count(), CandidateRegistrationDraft = CandidateRegistrationDraft, FresherExprence = FresherExprence, compareDateExperience = postCaitareaDetails.dt_compareDate, castAll = cast });

        }

        [HttpPost]
        public ActionResult getpostdetails(int addId, int postId, string Fresher)
        {
            var allow = "Yes";
            var minexpValue = objpostnew.tbl_mst_Postnew.Where(x => x.Pk_Postid == postId).FirstOrDefault().str_minexp;
            if (Convert.ToInt32(minexpValue) > 0 && Fresher == "Yes")
            {
                allow = "No";
            }
            return Json(new { allow = allow });
        }

        public ActionResult AcknowledgementReport(string AppNo)
        {

            if (current >= Convert.ToDateTime("14/10/2018"))
            {
                return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
            }
            var getViewDetail = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo).ToList();
            var getViewDetailOnlyPhoto = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo && !string.IsNullOrEmpty(a.str_uploadphoto)).ToList();
            var getViewDetailOnlySignature = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo && !string.IsNullOrEmpty(a.str_uploadsignature)).ToList();
            if (getViewDetail.Count != 0 && getViewDetailOnlyPhoto.Count != 0 && getViewDetailOnlySignature.Count != 0)
            {

                var acknowledgement = objAcknowledgement.Vw_Applicationdetails.Where(x => x.strApplicationNo == AppNo).FirstOrDefault();
                var unit = acknowledgement.Fk_unitid;
                var post = acknowledgement.fk_postid;
                var discipline = acknowledgement.fk_diciplineid;
                var candidateId = acknowledgement.Pk_int_CandidateRegistrationID;
                var advno = acknowledgement.fk_advertiseid;
                var date = acknowledgement.dt_entrydate.Value.ToString("ddMMyy");
                ViewBag.candidateRegistrationId = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(x => x.Candidate_Pk_intID == acknowledgement.fk_CandidateId).FirstOrDefault().Candidate_Code;


                var tran = objAcknowledgement.tbl_transactions.Where(x => x.strApplicationNo == AppNo && x.strStatus == "success").FirstOrDefault();
                if (acknowledgement.strPWD == "Yes" || acknowledgement.strInternalCandidate == "Yes")
                {
                    ViewBag.paymentDetails = "NA";
                }
                else
                {
                    ViewBag.paymentDetails = "Bank Ref. No. : " + tran.strBankRefNum + " Amount : " + tran.decPayuAmount + " Date : " + tran.dtTransactionsDate;
                }


                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString))
                {
                    SqlParameter outPar1 = new SqlParameter("@newacknowledgementNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                    SqlParameter outPar2 = new SqlParameter("@newNoticeNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                    var cmd = new SqlCommand("sp_AcknowledgementReport", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@unitId", SqlDbType.Int)).Value = unit;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@postId", SqlDbType.Int)).Value = post;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@disciplineId", SqlDbType.Int)).Value = discipline;
                    cmd.Parameters.Add(new SqlParameter("@candidateId", SqlDbType.Int)).Value = candidateId;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@noticeId", SqlDbType.Int)).Value = advno;//Pass the parameter
                    cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.VarChar)).Value = date;//Pass the parameter
                    cmd.Parameters.Add(outPar1);
                    cmd.Parameters.Add(outPar2);

                    try
                    {

                        if (con.State != ConnectionState.Open)
                            con.Open();
                        cmd.ExecuteNonQuery();
                        ViewBag.acknowledgementNo = cmd.Parameters["@newacknowledgementNo"].Value.ToString();
                        ViewBag.noticeNo = cmd.Parameters["@newNoticeNo"].Value.ToString();
                    }
                    finally
                    {

                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }

                }

                return View(acknowledgement);

            }

            else
            {
                return RedirectToAction("UploadPhotoSignature", "RecruitmentCareer", new { AppNo = AppNo });
            }
        }
        //public ActionResult SaveDraft()
        //{
        //    return View();
        //}

        public ActionResult Hallticket(string AppNo)
        {

            var Hallticket = objAcknowledgement.vw_HallTicket.Where(x => x.strApplicationNo == AppNo).FirstOrDefault();
            int checkData = objContext.tbl_mstRTIScheme.Where(x => x.strApplicationNo == AppNo).ToList().Count();
            var getViewDetailOnlyPhoto = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo && !string.IsNullOrEmpty(a.str_uploadphoto) && !string.IsNullOrEmpty(a.str_uploadsignature)).ToList();

            if (getViewDetailOnlyPhoto.Count() == 0)
            {
                return RedirectToAction("UploadPhotoSignature", "RecruitmentCareer", new { AppNo = AppNo });
            }
            else
            {

                if (Hallticket != null && checkData > 0)
                {
                    return View(Hallticket);
                }
                else if (Hallticket != null && checkData == 0)
                {
                    return RedirectToAction("RTIScheme", "RecruitmentCareer", new { AppNo = AppNo });
                }
                else
                {
                    //return RedirectToAction("ApplicantDashboard", "RecruitmentCareer", new { AppNo = AppNo }).WithNotification(NotificationStatus.Error, @"You are not eligible for getting Hallticket.");

                    ViewBag.Message = "You are not eligible for getting Hallticket. Please check your Application and Acknowledgement Slip";
                    return View(Hallticket);
                }
            }
        }


        public ActionResult InterviewLetter(string AppNo)

        {
            ViewBag.courrentDate = (DateTime.UtcNow + TimeSpan.Parse("05:30:00")).ToShortDateString();
            var InterviewLetter = objAcknowledgement.vw_InterviewLetter.Where(x => x.strApplicationNo == AppNo).FirstOrDefault();
            if (InterviewLetter != null)
            {
                return View(InterviewLetter);
            }
            else
            {
                ViewBag.Message = "You are not eligible for getting Interview Letter.";
                return View();
            }

        }

        public ActionResult RTIScheme(string AppNo)
        {
            if (current >= Convert.ToDateTime("14/10/2018"))
            {
                return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
            }
            TempData["AppNo"] = AppNo;
            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            if (CandiadateId == 0)
            {
                return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            }

            int checkData = objContext.tbl_mstRTIScheme.Where(x => x.strApplicationNo == AppNo).ToList().Count();
            if (checkData > 0)
            {
                return RedirectToAction("Hallticket", "RecruitmentCareer", new { AppNo = AppNo });
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult RTIScheme(string btnSubmit, string id)
        {
            if (current >= Convert.ToDateTime("14/10/2018"))
            {
                return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
            }
            string AppNo = TempData["AppNo"].ToString();
            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            if (CandiadateId == 0)
            {
                return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            }

            var checkData = objContext.tbl_mstRTIScheme.Where(x => x.strApplicationNo == AppNo).FirstOrDefault();
            if (checkData == null)
            {
                tbl_mstRTIScheme obj = new tbl_mstRTIScheme();
                obj.strApplicationNo = AppNo;
                obj.strAnswer = btnSubmit;
                obj.dtEntryDate = current;
                objContext.tbl_mstRTIScheme.Add(obj);
                objContext.SaveChanges();
            }
            return RedirectToAction("Hallticket", "RecruitmentCareer", new { AppNo = AppNo });
        }

        public ActionResult FeeClaim(string AppNo)
        {
            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            if (CandiadateId == 0)
            {
                return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            }

            var transactions = objAcknowledgement.tbl_transactions.Where(x => x.fkintApplicantId == CandiadateId && x.strApplicationNo == AppNo && x.strStatus == "success").FirstOrDefault();


            if (transactions != null && current > Convert.ToDateTime("25/01/2021 11:00") && current < Convert.ToDateTime("09/02/2021 23:59:59"))
            {
                var regDetails = objAcknowledgement.Vw_Applicationdetails.Where(x => x.fk_CandidateId == CandiadateId && x.strApplicationNo == AppNo).FirstOrDefault();
                ViewBag.strEmail = regDetails.strEmail;
                ViewBag.strMobileNo = regDetails.strMobileNo;
                ViewBag.strApplicantName = regDetails.strApplicantName;
                ViewBag.strApplicationNo = regDetails.strApplicationNo;

                ViewBag.decAmount = transactions.decHCLAmount;
                ViewBag.decAmount = transactions.decHCLAmount;

                var FeeClaim = objtbl_mst_CandidateDDDetailsContext.tbl_mstFeeClaim.Where(x => x.fk_intCandidateId == CandiadateId && x.strApplicationNo == AppNo).ToList();

                if (FeeClaim.Count() >= 1)
                {
                    ViewBag.staicbfname = FeeClaim.FirstOrDefault().strBeneName;
                    ViewBag.staicBfAcNo = FeeClaim.FirstOrDefault().strBeneAccountNumber;
                    ViewBag.staicBfIfcs = FeeClaim.FirstOrDefault().strIFSCCode;
                    ViewBag.staicBfBankName = FeeClaim.FirstOrDefault().strBeneficiaryBankName;
                    ViewBag.staicBfBrumchAddress = FeeClaim.FirstOrDefault().strAdress1;
                }


                var checkData = objtbl_mst_CandidateDDDetailsContext.tbl_mstFeeClaim_new.Where(x => x.fk_intCandidateId == CandiadateId && x.strApplicationNo == AppNo).ToList();
                string applicationNumber = "06Estt/1/2005/2018013222018, 06Estt/1/2005/2018173762018, 06Estt/1/2005/2018150032018, 06Estt/1/2005/2018165062018, 06Estt/1/2005/2018199092018, 06Estt/1/2005/2018019262018, 06Estt/1/2005/2018045632018, 06Estt/1/2005/2018127532018, 06Estt/1/2005/2018222432018, 06Estt/1/2005/2018040542018, 06Estt/1/2005/2018196442018, 06Estt/1/2005/2018065662018, 06Estt/1/2005/2018151062018, 06Estt/1/2005/2018071992018, 06Estt/1/2005/2018100602018, 06Estt/1/2005/2018099372018, 06Estt/1/2005/2018155452018, 06Estt/1/2005/2018008512018, 06Estt/1/2005/2018185992018, 06Estt/1/2005/2018148852018, 06Estt/1/2005/2018043602018, 06Estt/1/2005/2018174862018, 06Estt/1/2005/2018115442018, 06Estt/1/2005/2018087432018, 06Estt/1/2005/2018120072018, 06Estt/1/2005/2018196492018, 06Estt/1/2005/2018222502018, 06Estt/1/2005/2018197462018, 06Estt/1/2005/2018148062018, 06Estt/1/2005/2018230282018, 06Estt/1/2005/2018040282018, 06Estt/1/2005/2018109432018, 06Estt/1/2005/2018057902018, 06Estt/1/2005/2018146222018, 06Estt/1/2005/2018210602018, 06Estt/1/2005/2018061492018, 06Estt/1/2005/2018021832018, 06Estt/1/2005/2018031422018, 06Estt/1/2005/2018090442018, 06Estt/1/2005/2018009702018, 06Estt/1/2005/2018213202018, 06Estt/1/2005/2018204052018, 06Estt/1/2005/2018108302018, 06Estt/1/2005/2018024412018, 06Estt/1/2005/2018055592018, 06Estt/1/2005/2018030192018, 06Estt/1/2005/2018135232018, 06Estt/1/2005/2018031902018, 06Estt/1/2005/2018217082018, 06Estt/1/2005/2018143812018, 06Estt/1/2005/2018010692018, 06Estt/1/2005/2018221662018, 06Estt/1/2005/2018033442018, 06Estt/1/2005/2018136152018, 06Estt/1/2005/2018042152018, 06Estt/1/2005/2018184782018, 06Estt/1/2005/2018132122018, 06Estt/1/2005/2018144482018, 06Estt/1/2005/2018220142018, 06Estt/1/2005/2018162332018, 06Estt/1/2005/2018135712018, 06Estt/1/2005/2018079302018, 06Estt/1/2005/2018184402018, 06Estt/1/2005/2018072832018, 06Estt/1/2005/2018166062018, 06Estt/1/2005/2018008922018, 06Estt/1/2005/2018200132018, 06Estt/1/2005/2018011542018, 06Estt/1/2005/2018192742018, 06Estt/1/2005/2018018742018, 06Estt/1/2005/2018151412018, 06Estt/1/2005/2018028572018, 06Estt/1/2005/2018085082018, 06Estt/1/2005/2018229982018, 06Estt/1/2005/2018135272018, 06Estt/1/2005/2018215992018, 06Estt/1/2005/2018003752018, 06Estt/1/2005/2018042232018, 06Estt/1/2005/2018028222018, 06Estt/1/2005/2018068232018, 06Estt/1/2005/2018131122018, 06Estt/1/2005/2018078552018, 06Estt/1/2005/2018030302018, 06Estt/1/2005/2018166922018, 06Estt/1/2005/2018144712018, 06Estt/1/2005/2018040602018, 06Estt/1/2005/2018224012018, 06Estt/1/2005/2018043962018, 06Estt/1/2005/2018136232018, 06Estt/1/2005/2018229572018, 06Estt/1/2005/2018146662018, 06Estt/1/2005/2018119322018, 06Estt/1/2005/2018208792018, 06Estt/1/2005/2018104822018, 06Estt/1/2005/2018108762018, 06Estt/1/2005/2018163662018, 06Estt/1/2005/2018148222018, 06Estt/1/2005/2018105172018, 06Estt/1/2005/2018122172018, 06Estt/1/2005/2018004682018, 06Estt/1/2005/2018213792018, 06Estt/1/2005/2018094072018, 06Estt/1/2005/2018103682018, 06Estt/1/2005/2018131042018, 06Estt/1/2005/2018177762018, 06Estt/1/2005/2018174412018, 06Estt/1/2005/2018065122018, 06Estt/1/2005/2018130162018, 06Estt/1/2005/2018114382018, 06Estt/1/2005/2018148202018, 06Estt/1/2005/2018202272018, 06Estt/1/2005/2018054512018, 06Estt/1/2005/2018101082018, 06Estt/1/2005/2018200992018, 06Estt/1/2005/2018150502018, 06Estt/1/2005/2018083682018, 06Estt/1/2005/2018134722018, 06Estt/1/2005/2018046092018, 06Estt/1/2005/2018157412018, 06Estt/1/2005/2018184012018, 06Estt/1/2005/2018196082018, 06Estt/1/2005/2018120312018, 06Estt/1/2005/2018106682018, 06Estt/1/2005/2018127882018, 06Estt/1/2005/2018172842018, 06Estt/1/2005/2018133102018, 06Estt/1/2005/2018049962018, 06Estt/1/2005/2018072642018, 06Estt/1/2005/2018013022018, 06Estt/1/2005/2018193072018, 06Estt/1/2005/2018129902018, 06Estt/1/2005/2018212322018, 06Estt/1/2005/2018173452018, 06Estt/1/2005/2018068542018, 06Estt/1/2005/2018123672018, 06Estt/1/2005/2018180612018, 06Estt/1/2005/2018216742018, 06Estt/1/2005/2018034992018, 06Estt/1/2005/2018210352018, 06Estt/1/2005/2018122092018, 06Estt/1/2005/2018011862018, 06Estt/1/2005/2018055512018, 06Estt/1/2005/2018042172018, 06Estt/1/2005/2018003972018, 06Estt/1/2005/2018046882018, 06Estt/1/2005/2018054292018, 06Estt/1/2005/2018071042018, 06Estt/1/2005/2018206242018, 06Estt/1/2005/2018152962018, 06Estt/1/2005/2018096672018, 06Estt/1/2005/2018140022018, 06Estt/1/2005/2018201462018, 06Estt/1/2005/2018180032018, 06Estt/1/2005/2018054142018, 06Estt/1/2005/2018057072018, 06Estt/1/2005/2018218952018, 06Estt/1/2005/2018150282018, 06Estt/1/2005/2018064902018, 06Estt/1/2005/2018203182018, 06Estt/1/2005/2018145312018, 06Estt/1/2005/2018043242018, 06Estt/1/2005/2018190752018, 06Estt/1/2005/2018165892018, 06Estt/1/2005/2018040662018, 06Estt/1/2005/2018095092018, 06Estt/1/2005/2018096902018, 06Estt/1/2005/2018046422018, 06Estt/1/2005/2018065812018, 06Estt/1/2005/2018056322018, 06Estt/1/2005/2018127632018, 06Estt/1/2005/2018181052018, 06Estt/1/2005/2018205552018, 06Estt/1/2005/2018094412018, 06Estt/1/2005/2018062032018, 06Estt/1/2005/2018090602018, 06Estt/1/2005/2018128462018, 06Estt/1/2005/2018191642018, 06Estt/1/2005/2018086262018, 06Estt/1/2005/2018145242018, 06Estt/1/2005/2018063472018, 06Estt/1/2005/2018176452018, 06Estt/1/2005/2018011432018, 06Estt/1/2005/2018153512018, 06Estt/1/2005/2018151292018, 06Estt/1/2005/2018150792018, 06Estt/1/2005/2018056102018, 06Estt/1/2005/2018079152018, 06Estt/1/2005/2018086412018, 06Estt/1/2005/2018113812018, 06Estt/1/2005/2018042922018, 06Estt/1/2005/2018086172018, 06Estt/1/2005/2018163162018, 06Estt/1/2005/2018126092018, 06Estt/1/2005/2018117992018, 06Estt/1/2005/2018176372018, 06Estt/1/2005/2018208112018, 06Estt/1/2005/2018177292018, 06Estt/1/2005/2018122102018, 06Estt/1/2005/2018140282018, 06Estt/1/2005/2018230802018, 06Estt/1/2005/2018134672018, 06Estt/1/2005/2018151852018, 06Estt/1/2005/2018184742018, 06Estt/1/2005/2018170672018, 06Estt/1/2005/2018049392018, 06Estt/1/2005/2018210122018, 06Estt/1/2005/2018011152018, 06Estt/1/2005/2018018592018, 06Estt/1/2005/2018083052018,";





                //var checkFeesData = objtbl_mst_CandidateDDDetailsContext.tbl_dumData_Fee_Claim.Where(x => x.strApplicationNo == AppNo).ToList();
                if (checkData.Count() == 0 && applicationNumber.Contains(AppNo))
                {
                    return View();
                }
                else
                {

                    if (applicationNumber.Contains(checkData.FirstOrDefault().strApplicationNo) && checkData.FirstOrDefault().dtUpdateDate == null)
                    {
                        ViewBag.status = "";
                    }
                    else
                    {
                        ViewBag.status = "Done";
                    }
                    return View(checkData.FirstOrDefault());
                    //return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");            
                }
            }
            else
            {
                return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
            }
        }

        [HttpPost]
        public ActionResult FeeClaim(tbl_mstFeeClaim_new obj, FormCollection frm)
        {
            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            if (CandiadateId == 0)
            {
                return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            }
            ModelState.Remove("pk_intFeeClaimId");

            if (ModelState.IsValid && current > Convert.ToDateTime("25/01/2021 11:00") && current < Convert.ToDateTime("09/02/2021 23:59:59"))
            {
                var checkData = objtbl_mst_CandidateDDDetailsContext.tbl_mstFeeClaim_new.Where(x => x.fk_intCandidateId == CandiadateId && x.strApplicationNo == obj.strApplicationNo).ToList();
                var regDetails = objAcknowledgement.Vw_Applicationdetails.Where(x => x.fk_CandidateId == CandiadateId && x.strApplicationNo == obj.strApplicationNo).FirstOrDefault();
                //var checkFeesData = objtbl_mst_CandidateDDDetailsContext.tbl_dumData_Fee_Claim.Where(x => x.strApplicationNo == obj.strApplicationNo).ToList();
                string applicationNumber = "06Estt/1/2005/2018013222018, 06Estt/1/2005/2018173762018, 06Estt/1/2005/2018150032018, 06Estt/1/2005/2018165062018, 06Estt/1/2005/2018199092018, 06Estt/1/2005/2018019262018, 06Estt/1/2005/2018045632018, 06Estt/1/2005/2018127532018, 06Estt/1/2005/2018222432018, 06Estt/1/2005/2018040542018, 06Estt/1/2005/2018196442018, 06Estt/1/2005/2018065662018, 06Estt/1/2005/2018151062018, 06Estt/1/2005/2018071992018, 06Estt/1/2005/2018100602018, 06Estt/1/2005/2018099372018, 06Estt/1/2005/2018155452018, 06Estt/1/2005/2018008512018, 06Estt/1/2005/2018185992018, 06Estt/1/2005/2018148852018, 06Estt/1/2005/2018043602018, 06Estt/1/2005/2018174862018, 06Estt/1/2005/2018115442018, 06Estt/1/2005/2018087432018, 06Estt/1/2005/2018120072018, 06Estt/1/2005/2018196492018, 06Estt/1/2005/2018222502018, 06Estt/1/2005/2018197462018, 06Estt/1/2005/2018148062018, 06Estt/1/2005/2018230282018, 06Estt/1/2005/2018040282018, 06Estt/1/2005/2018109432018, 06Estt/1/2005/2018057902018, 06Estt/1/2005/2018146222018, 06Estt/1/2005/2018210602018, 06Estt/1/2005/2018061492018, 06Estt/1/2005/2018021832018, 06Estt/1/2005/2018031422018, 06Estt/1/2005/2018090442018, 06Estt/1/2005/2018009702018, 06Estt/1/2005/2018213202018, 06Estt/1/2005/2018204052018, 06Estt/1/2005/2018108302018, 06Estt/1/2005/2018024412018, 06Estt/1/2005/2018055592018, 06Estt/1/2005/2018030192018, 06Estt/1/2005/2018135232018, 06Estt/1/2005/2018031902018, 06Estt/1/2005/2018217082018, 06Estt/1/2005/2018143812018, 06Estt/1/2005/2018010692018, 06Estt/1/2005/2018221662018, 06Estt/1/2005/2018033442018, 06Estt/1/2005/2018136152018, 06Estt/1/2005/2018042152018, 06Estt/1/2005/2018184782018, 06Estt/1/2005/2018132122018, 06Estt/1/2005/2018144482018, 06Estt/1/2005/2018220142018, 06Estt/1/2005/2018162332018, 06Estt/1/2005/2018135712018, 06Estt/1/2005/2018079302018, 06Estt/1/2005/2018184402018, 06Estt/1/2005/2018072832018, 06Estt/1/2005/2018166062018, 06Estt/1/2005/2018008922018, 06Estt/1/2005/2018200132018, 06Estt/1/2005/2018011542018, 06Estt/1/2005/2018192742018, 06Estt/1/2005/2018018742018, 06Estt/1/2005/2018151412018, 06Estt/1/2005/2018028572018, 06Estt/1/2005/2018085082018, 06Estt/1/2005/2018229982018, 06Estt/1/2005/2018135272018, 06Estt/1/2005/2018215992018, 06Estt/1/2005/2018003752018, 06Estt/1/2005/2018042232018, 06Estt/1/2005/2018028222018, 06Estt/1/2005/2018068232018, 06Estt/1/2005/2018131122018, 06Estt/1/2005/2018078552018, 06Estt/1/2005/2018030302018, 06Estt/1/2005/2018166922018, 06Estt/1/2005/2018144712018, 06Estt/1/2005/2018040602018, 06Estt/1/2005/2018224012018, 06Estt/1/2005/2018043962018, 06Estt/1/2005/2018136232018, 06Estt/1/2005/2018229572018, 06Estt/1/2005/2018146662018, 06Estt/1/2005/2018119322018, 06Estt/1/2005/2018208792018, 06Estt/1/2005/2018104822018, 06Estt/1/2005/2018108762018, 06Estt/1/2005/2018163662018, 06Estt/1/2005/2018148222018, 06Estt/1/2005/2018105172018, 06Estt/1/2005/2018122172018, 06Estt/1/2005/2018004682018, 06Estt/1/2005/2018213792018, 06Estt/1/2005/2018094072018, 06Estt/1/2005/2018103682018, 06Estt/1/2005/2018131042018, 06Estt/1/2005/2018177762018, 06Estt/1/2005/2018174412018, 06Estt/1/2005/2018065122018, 06Estt/1/2005/2018130162018, 06Estt/1/2005/2018114382018, 06Estt/1/2005/2018148202018, 06Estt/1/2005/2018202272018, 06Estt/1/2005/2018054512018, 06Estt/1/2005/2018101082018, 06Estt/1/2005/2018200992018, 06Estt/1/2005/2018150502018, 06Estt/1/2005/2018083682018, 06Estt/1/2005/2018134722018, 06Estt/1/2005/2018046092018, 06Estt/1/2005/2018157412018, 06Estt/1/2005/2018184012018, 06Estt/1/2005/2018196082018, 06Estt/1/2005/2018120312018, 06Estt/1/2005/2018106682018, 06Estt/1/2005/2018127882018, 06Estt/1/2005/2018172842018, 06Estt/1/2005/2018133102018, 06Estt/1/2005/2018049962018, 06Estt/1/2005/2018072642018, 06Estt/1/2005/2018013022018, 06Estt/1/2005/2018193072018, 06Estt/1/2005/2018129902018, 06Estt/1/2005/2018212322018, 06Estt/1/2005/2018173452018, 06Estt/1/2005/2018068542018, 06Estt/1/2005/2018123672018, 06Estt/1/2005/2018180612018, 06Estt/1/2005/2018216742018, 06Estt/1/2005/2018034992018, 06Estt/1/2005/2018210352018, 06Estt/1/2005/2018122092018, 06Estt/1/2005/2018011862018, 06Estt/1/2005/2018055512018, 06Estt/1/2005/2018042172018, 06Estt/1/2005/2018003972018, 06Estt/1/2005/2018046882018, 06Estt/1/2005/2018054292018, 06Estt/1/2005/2018071042018, 06Estt/1/2005/2018206242018, 06Estt/1/2005/2018152962018, 06Estt/1/2005/2018096672018, 06Estt/1/2005/2018140022018, 06Estt/1/2005/2018201462018, 06Estt/1/2005/2018180032018, 06Estt/1/2005/2018054142018, 06Estt/1/2005/2018057072018, 06Estt/1/2005/2018218952018, 06Estt/1/2005/2018150282018, 06Estt/1/2005/2018064902018, 06Estt/1/2005/2018203182018, 06Estt/1/2005/2018145312018, 06Estt/1/2005/2018043242018, 06Estt/1/2005/2018190752018, 06Estt/1/2005/2018165892018, 06Estt/1/2005/2018040662018, 06Estt/1/2005/2018095092018, 06Estt/1/2005/2018096902018, 06Estt/1/2005/2018046422018, 06Estt/1/2005/2018065812018, 06Estt/1/2005/2018056322018, 06Estt/1/2005/2018127632018, 06Estt/1/2005/2018181052018, 06Estt/1/2005/2018205552018, 06Estt/1/2005/2018094412018, 06Estt/1/2005/2018062032018, 06Estt/1/2005/2018090602018, 06Estt/1/2005/2018128462018, 06Estt/1/2005/2018191642018, 06Estt/1/2005/2018086262018, 06Estt/1/2005/2018145242018, 06Estt/1/2005/2018063472018, 06Estt/1/2005/2018176452018, 06Estt/1/2005/2018011432018, 06Estt/1/2005/2018153512018, 06Estt/1/2005/2018151292018, 06Estt/1/2005/2018150792018, 06Estt/1/2005/2018056102018, 06Estt/1/2005/2018079152018, 06Estt/1/2005/2018086412018, 06Estt/1/2005/2018113812018, 06Estt/1/2005/2018042922018, 06Estt/1/2005/2018086172018, 06Estt/1/2005/2018163162018, 06Estt/1/2005/2018126092018, 06Estt/1/2005/2018117992018, 06Estt/1/2005/2018176372018, 06Estt/1/2005/2018208112018, 06Estt/1/2005/2018177292018, 06Estt/1/2005/2018122102018, 06Estt/1/2005/2018140282018, 06Estt/1/2005/2018230802018, 06Estt/1/2005/2018134672018, 06Estt/1/2005/2018151852018, 06Estt/1/2005/2018184742018, 06Estt/1/2005/2018170672018, 06Estt/1/2005/2018049392018, 06Estt/1/2005/2018210122018, 06Estt/1/2005/2018011152018, 06Estt/1/2005/2018018592018, 06Estt/1/2005/2018083052018,";

                var FeeClaim = objtbl_mst_CandidateDDDetailsContext.tbl_mstFeeClaim.Where(x => x.fk_intCandidateId == CandiadateId && x.strApplicationNo == obj.strApplicationNo).ToList();
                if (checkData.Count() == 0 && applicationNumber.Contains(obj.strApplicationNo))
                {
                    obj.fk_intCandidateId = CandiadateId;
                    obj.dtEntryDate = current;

                    obj.strBeneName = FeeClaim.FirstOrDefault().strBeneName;
                    obj.strBeneAccountNumber = FeeClaim.FirstOrDefault().strBeneAccountNumber;
                    obj.strBeneficiaryBankName = FeeClaim.FirstOrDefault().strBeneficiaryBankName;
                    obj.strAdress1 = FeeClaim.FirstOrDefault().strAdress1;

                    objtbl_mst_CandidateDDDetailsContext.tbl_mstFeeClaim_new.Add(obj);
                    objtbl_mst_CandidateDDDetailsContext.SaveChanges();
                    ViewBag.message = "Data submited successfully !";
                    var message = "Dear Candidate,<br><br><br>Your application fee claim details as submitted by you is as<br> follows: <br><br> Beneficiary Name : " + obj.strBeneName + "<br> Beneficiary Account No : " + obj.strBeneAccountNumber + "<br> Beneficiary IFSC Code : " + obj.strIFSCCode + "<br> Beneficiary Bank Name : " + obj.strBeneficiaryBankName + "<br> Beneficiary Branch Address : " + obj.strAdress1;
                    Utility.SendEmail(obj.strEmail, "Your application fee claim details", message);
                }
                //else
                //{
                //    obj = checkData.FirstOrDefault();
                //    string applicationNumber = "06Estt/1/2005/2018013222018, 06Estt/1/2005/2018173762018, 06Estt/1/2005/2018150032018, 06Estt/1/2005/2018165062018, 06Estt/1/2005/2018199092018, 06Estt/1/2005/2018019262018, 06Estt/1/2005/2018045632018, 06Estt/1/2005/2018127532018, 06Estt/1/2005/2018222432018, 06Estt/1/2005/2018040542018, 06Estt/1/2005/2018196442018, 06Estt/1/2005/2018065662018, 06Estt/1/2005/2018151062018, 06Estt/1/2005/2018071992018, 06Estt/1/2005/2018100602018, 06Estt/1/2005/2018099372018, 06Estt/1/2005/2018155452018, 06Estt/1/2005/2018008512018, 06Estt/1/2005/2018185992018, 06Estt/1/2005/2018148852018, 06Estt/1/2005/2018043602018, 06Estt/1/2005/2018174862018, 06Estt/1/2005/2018115442018, 06Estt/1/2005/2018087432018, 06Estt/1/2005/2018120072018, 06Estt/1/2005/2018196492018, 06Estt/1/2005/2018222502018, 06Estt/1/2005/2018197462018, 06Estt/1/2005/2018148062018, 06Estt/1/2005/2018230282018, 06Estt/1/2005/2018040282018, 06Estt/1/2005/2018109432018, 06Estt/1/2005/2018057902018, 06Estt/1/2005/2018146222018, 06Estt/1/2005/2018210602018, 06Estt/1/2005/2018061492018, 06Estt/1/2005/2018021832018, 06Estt/1/2005/2018031422018, 06Estt/1/2005/2018090442018, 06Estt/1/2005/2018009702018, 06Estt/1/2005/2018213202018, 06Estt/1/2005/2018204052018, 06Estt/1/2005/2018108302018, 06Estt/1/2005/2018024412018, 06Estt/1/2005/2018055592018, 06Estt/1/2005/2018030192018, 06Estt/1/2005/2018135232018, 06Estt/1/2005/2018031902018, 06Estt/1/2005/2018217082018, 06Estt/1/2005/2018143812018, 06Estt/1/2005/2018010692018, 06Estt/1/2005/2018221662018, 06Estt/1/2005/2018033442018, 06Estt/1/2005/2018136152018, 06Estt/1/2005/2018042152018, 06Estt/1/2005/2018184782018, 06Estt/1/2005/2018132122018, 06Estt/1/2005/2018144482018, 06Estt/1/2005/2018220142018, 06Estt/1/2005/2018162332018, 06Estt/1/2005/2018135712018, 06Estt/1/2005/2018079302018, 06Estt/1/2005/2018184402018, 06Estt/1/2005/2018072832018, 06Estt/1/2005/2018166062018, 06Estt/1/2005/2018008922018, 06Estt/1/2005/2018200132018, 06Estt/1/2005/2018011542018, 06Estt/1/2005/2018192742018, 06Estt/1/2005/2018018742018, 06Estt/1/2005/2018151412018, 06Estt/1/2005/2018028572018, 06Estt/1/2005/2018085082018, 06Estt/1/2005/2018229982018, 06Estt/1/2005/2018135272018, 06Estt/1/2005/2018215992018, 06Estt/1/2005/2018003752018, 06Estt/1/2005/2018042232018, 06Estt/1/2005/2018028222018, 06Estt/1/2005/2018068232018, 06Estt/1/2005/2018131122018, 06Estt/1/2005/2018078552018, 06Estt/1/2005/2018030302018, 06Estt/1/2005/2018166922018, 06Estt/1/2005/2018144712018, 06Estt/1/2005/2018040602018, 06Estt/1/2005/2018224012018, 06Estt/1/2005/2018043962018, 06Estt/1/2005/2018136232018, 06Estt/1/2005/2018229572018, 06Estt/1/2005/2018146662018, 06Estt/1/2005/2018119322018, 06Estt/1/2005/2018208792018, 06Estt/1/2005/2018104822018, 06Estt/1/2005/2018108762018, 06Estt/1/2005/2018163662018, 06Estt/1/2005/2018148222018, 06Estt/1/2005/2018105172018, 06Estt/1/2005/2018122172018, 06Estt/1/2005/2018004682018, 06Estt/1/2005/2018213792018, 06Estt/1/2005/2018094072018, 06Estt/1/2005/2018103682018, 06Estt/1/2005/2018131042018, 06Estt/1/2005/2018177762018, 06Estt/1/2005/2018174412018, 06Estt/1/2005/2018065122018, 06Estt/1/2005/2018130162018, 06Estt/1/2005/2018114382018, 06Estt/1/2005/2018148202018, 06Estt/1/2005/2018202272018, 06Estt/1/2005/2018054512018, 06Estt/1/2005/2018101082018, 06Estt/1/2005/2018200992018, 06Estt/1/2005/2018150502018, 06Estt/1/2005/2018083682018, 06Estt/1/2005/2018134722018, 06Estt/1/2005/2018046092018, 06Estt/1/2005/2018157412018, 06Estt/1/2005/2018184012018, 06Estt/1/2005/2018196082018, 06Estt/1/2005/2018120312018, 06Estt/1/2005/2018106682018, 06Estt/1/2005/2018127882018, 06Estt/1/2005/2018172842018, 06Estt/1/2005/2018133102018, 06Estt/1/2005/2018049962018, 06Estt/1/2005/2018072642018, 06Estt/1/2005/2018013022018, 06Estt/1/2005/2018193072018, 06Estt/1/2005/2018129902018, 06Estt/1/2005/2018212322018, 06Estt/1/2005/2018173452018, 06Estt/1/2005/2018068542018, 06Estt/1/2005/2018123672018, 06Estt/1/2005/2018180612018, 06Estt/1/2005/2018216742018, 06Estt/1/2005/2018034992018, 06Estt/1/2005/2018210352018, 06Estt/1/2005/2018122092018, 06Estt/1/2005/2018011862018, 06Estt/1/2005/2018055512018, 06Estt/1/2005/2018042172018, 06Estt/1/2005/2018003972018, 06Estt/1/2005/2018046882018, 06Estt/1/2005/2018054292018, 06Estt/1/2005/2018071042018, 06Estt/1/2005/2018206242018, 06Estt/1/2005/2018152962018, 06Estt/1/2005/2018096672018, 06Estt/1/2005/2018140022018, 06Estt/1/2005/2018201462018, 06Estt/1/2005/2018180032018, 06Estt/1/2005/2018054142018, 06Estt/1/2005/2018057072018, 06Estt/1/2005/2018218952018, 06Estt/1/2005/2018150282018, 06Estt/1/2005/2018064902018, 06Estt/1/2005/2018203182018, 06Estt/1/2005/2018145312018, 06Estt/1/2005/2018043242018, 06Estt/1/2005/2018190752018, 06Estt/1/2005/2018165892018, 06Estt/1/2005/2018040662018, 06Estt/1/2005/2018095092018, 06Estt/1/2005/2018096902018, 06Estt/1/2005/2018046422018, 06Estt/1/2005/2018065812018, 06Estt/1/2005/2018056322018, 06Estt/1/2005/2018127632018, 06Estt/1/2005/2018181052018, 06Estt/1/2005/2018205552018, 06Estt/1/2005/2018094412018, 06Estt/1/2005/2018062032018, 06Estt/1/2005/2018090602018, 06Estt/1/2005/2018128462018, 06Estt/1/2005/2018191642018, 06Estt/1/2005/2018086262018, 06Estt/1/2005/2018145242018, 06Estt/1/2005/2018063472018, 06Estt/1/2005/2018176452018, 06Estt/1/2005/2018011432018, 06Estt/1/2005/2018153512018, 06Estt/1/2005/2018151292018, 06Estt/1/2005/2018150792018, 06Estt/1/2005/2018056102018, 06Estt/1/2005/2018079152018, 06Estt/1/2005/2018086412018, 06Estt/1/2005/2018113812018, 06Estt/1/2005/2018042922018, 06Estt/1/2005/2018086172018, 06Estt/1/2005/2018163162018, 06Estt/1/2005/2018126092018, 06Estt/1/2005/2018117992018, 06Estt/1/2005/2018176372018, 06Estt/1/2005/2018208112018, 06Estt/1/2005/2018177292018, 06Estt/1/2005/2018122102018, 06Estt/1/2005/2018140282018, 06Estt/1/2005/2018230802018, 06Estt/1/2005/2018134672018, 06Estt/1/2005/2018151852018, 06Estt/1/2005/2018184742018, 06Estt/1/2005/2018170672018, 06Estt/1/2005/2018049392018, 06Estt/1/2005/2018210122018, 06Estt/1/2005/2018011152018, 06Estt/1/2005/2018018592018, 06Estt/1/2005/2018083052018,";
                //    if (applicationNumber.Contains(obj.strApplicationNo) && obj.dtUpdateDate == null)
                //    {
                //    obj.strBeneName = frm["strBeneName"];
                //    obj.strBeneAccountNumber = frm["strBeneAccountNumber"];
                //    obj.strIFSCCode = frm["strIFSCCode"];
                //    obj.strBeneficiaryBankName = frm["strBeneficiaryBankName"];
                //    obj.strAdress1 = frm["strAdress1"];
                //    obj.dtUpdateDate = current;
                //    objtbl_mst_CandidateDDDetailsContext.Entry(obj).State = EntityState.Modified;                   
                //    objtbl_mst_CandidateDDDetailsContext.SaveChanges();
                //    ViewBag.message = "Data update successfully !";
                //    var message = "Dear Candidate,<br><br><br>Your application fee claim details as updated by you is as<br> follows: <br><br> Beneficiary Name : " + obj.strBeneName + "<br> Beneficiary Account No : " + obj.strBeneAccountNumber + "<br> Beneficiary IFSC Code : " + obj.strIFSCCode + "<br> Beneficiary Bank Name : " + obj.strBeneficiaryBankName + "<br> Beneficiary Branch Address : " + obj.strAdress1;
                //    Utility.SendEmail(obj.strEmail, "Your application fee claim details", message);
                //    return View(obj);
                //    }
                //    else{
                //    return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
                //    }

                //}

                return RedirectToAction("FeeClaim");

            }
            else
            {
                ViewBag.message = "Beneficiary IFSC Code to be Filled !";
                string messages = string.Join("; ", ModelState.Values
                                        .SelectMany(x => x.Errors)
                                        .Select(x => x.ErrorMessage));
                return View(obj);
            }
        }

    }
}
