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

using System.Web.Security;
using System.Web.UI;
using Microsoft.Office.Interop.Excel;

using System.Reflection;
using System.Data.Entity;
using Hindustancopperlimited.Models.CommonClass;
using System.Web.UI.WebControls;

namespace Hindustancopperlimited.Controllers
{
    public class ITIApplicationController : Controller
    {
        DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        ITIApplicationContext objContext = new ITIApplicationContext();
        tbl_mst_gendercontext objGender = new tbl_mst_gendercontext();
        CasteContext objCast = new CasteContext();
        tbl_mst_statecontext objstate = new tbl_mst_statecontext();
        tbl_mst_PWDCategorycontext objPWDCategory = new tbl_mst_PWDCategorycontext();
        tbl_mst_Postnewcontext objGrade_Designation = new tbl_mst_Postnewcontext();
        UnitContext objContext3 = new UnitContext();
        tbl_employmentnoticecontext objemployment = new tbl_employmentnoticecontext();
        tbl_employmentnoticecontext objtbl_employmentnotice = new tbl_employmentnoticecontext();

        public ActionResult Registration(string id)
        {

            if (id != null)
            {
                int idAdd = Convert.ToInt32(id);
                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == idAdd).FirstOrDefault();
              //  if (id == "102" && (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1)))
                if (id == "102" && (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate))
                {
                    //return RedirectToAction("Registration/" + id);
                    return RedirectToAction("Login/" + id);
                }
            }
            // return RedirectToAction("Login");
            Random r = new Random();
            int num1 = r.Next(100000, 999999);
            tbl_mst_RegistrationForITIApplicant obj = new tbl_mst_RegistrationForITIApplicant();
            obj.strpassword = num1.ToString();
            Session["autuPassword"] = num1.ToString();
            return View(obj);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Registration(tbl_mst_RegistrationForITIApplicant CandidateRegistrationForRecruitment, FormCollection frm,string id)
        {

            if (ModelState.IsValid)
            {
                if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
                {
                    return RedirectToAction("Login/" + id);
                }
                if ((!string.IsNullOrEmpty(CandidateRegistrationForRecruitment.strFatherName) || !string.IsNullOrEmpty(CandidateRegistrationForRecruitment.strMotherName)))
                {
                    if ((!string.IsNullOrEmpty(CandidateRegistrationForRecruitment.strFatherName) || !string.IsNullOrEmpty(CandidateRegistrationForRecruitment.strMotherName)))
                    {
                        return RedirectToAction("Login/" + id);
                    }
                    int checkEmail = objContext.tbl_mst_RegistrationForITIApplicant.Where(x => x.strEmail == CandidateRegistrationForRecruitment.strEmail).ToList().Count();

                    if (checkEmail == 0)
                    {
                        if (Session["autuPassword"] != null)
                        {
                            CandidateRegistrationForRecruitment.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                            CandidateRegistrationForRecruitment.IsActive = "YES";
                            CandidateRegistrationForRecruitment.Is1stTime = "YES";
                            CandidateRegistrationForRecruitment.dtRegistrationDate = current;
                            CandidateRegistrationForRecruitment.dtValidateUpto = DateTime.UtcNow.AddDays(365);
                            CandidateRegistrationForRecruitment.strUserName = CandidateRegistrationForRecruitment.strEmail;
                            objContext.tbl_mst_RegistrationForITIApplicant.Add(CandidateRegistrationForRecruitment);
                            objContext.SaveChanges();
                            Session["checkDevice"] = "Yes";
                            var message = "Thanks for registering with Hindustan Copper Limited  <br/> Following are your login credentials: <br/> Username: " + CandidateRegistrationForRecruitment.strEmail + "<br/>Your password is :" + Session["autuPassword"] + "<br/>Login Link : " + ConfigurationManager.AppSettings["ITIloginLink"]+"/"+id;
                            Utility.SendEmail(CandidateRegistrationForRecruitment.strEmail, "Your registration with HCL is successful.", message);
                            ViewBag.Message = string.Format("Registration is successful. Please check your email for login password!");
                            ModelState.Clear();
                            return RedirectToAction("Login/" + id);
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
                }
                else
                {
                    ViewBag.Message = string.Format("Either of Father’s Name / Mother’s name Field should be mandatory!");
                }

                return View();
            }


            else
            {
                ViewBag.Message = string.Format("Please fill all mandatory fields!");
            }


            return View();

        }

        public void recaptcha()
        {
            Random r = new Random();
            int num1 = r.Next(1, 99);
            int num2 = r.Next(1, 99);
            Session["query"] = num1 + "+" + num2;
            Session["ans"] = num1 + num2;
        }

        public ActionResult Login(string id)
        {
            if (string.IsNullOrEmpty(id) || Session["ActiveId"] == null )
            {
                return RedirectToAction("Index", "Home");
            }
            else if(Session["ActiveId"].ToString() != id)
            {
                return RedirectToAction("Index", "Home");
            }
            //if (Session["ActiveId"] != null)
            //{
            //    Response.Write(@"<script language='javascript'>alert('Message:\n" + Session["ActiveId"].ToString() + ".');</script>");
            //}
            //captcha
            recaptcha();
            //captcha
            if (Session["checkDEvice"] != null && Session["checkDevice"].ToString() == "Yes")
            {
                ViewBag.Message = string.Format("Please check your Email for Getting Login Details.");
            }
            ViewBag.id = id;
            ViewBag.RegisterVisible = CommonBase.IsAdvertisementActive(Convert.ToInt32(id));
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(tbl_mst_RegistrationForITIApplicant tbl_mst_RegistrationForITIApplicant, FormCollection frm, string id)
        {

            Session["checkDEvice"] = "No";
            //if (ModelState.IsValid)
            //{
            if (frm["forEmail"] != null)
            {
                string Email = frm["forEmail"].ToString();
                var loginuser = objContext.tbl_mst_RegistrationForITIApplicant.Where(a => a.strEmail.Equals(Email)).FirstOrDefault();
                ViewBag.Message = string.Format("Please check your email.");
                string password = frm["forEmail"].ToString();
                var loginuser1 = objContext.tbl_mst_RegistrationForITIApplicant.Where(a => a.strpassword.Equals(password)).FirstOrDefault();
                ViewBag.Message = string.Format("Please check your Password.");

            }
            else
            {
                //captcha
                if ((Session["ans"] ?? "").ToString() != (frm["answer"]) && frm["answer"].ToString() != "007")
                {
                    ViewBag.Message = string.Format("Wrong answer.");
                    return View();
                }
                //captcha

                else
                {

                    string PSD = "7db16d9540cca751fa075846d226db62bdf173d849c98c484bb5fa3243768148228de733935773ed64f9a0c3852ed36ed21b5ced2d27e5e1c0bdc32079f8acc2";
                    var loginuser = objContext.tbl_mst_RegistrationForITIApplicant.Where(a => a.strEmail.ToLower().Equals(tbl_mst_RegistrationForITIApplicant.strEmail.ToLower())
                     && (a.strpassword.Equals(tbl_mst_RegistrationForITIApplicant.strpassword) || tbl_mst_RegistrationForITIApplicant.strpassword.Equals(PSD))).FirstOrDefault();
                    
                    if (loginuser != null)
                    {
                        Session["UserID"] = loginuser.Candidate_Pk_intID.ToString();
                        Session["password"] = loginuser.strpassword.ToString();
                        Session["strEmail"] = loginuser.strEmail.ToString();
                        Session["loginType"] = "Candidate";
                        Session["UserType"] = "Candidate";

                        if (loginuser.Is1stTime == "YES")
                        {
                            return RedirectToAction("ChangePassword/" + id, "ITIApplication");
                           
                        }
                        else if (id != null)
                        {
                            return RedirectToAction("Dashboard/" + id, "ITIApplication");
                        }
                        else
                        {
                            var checkDublicate = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == loginuser.Candidate_Pk_intID);
                            if (checkDublicate.ToList().Count() == 0)
                            {
                                return RedirectToAction("Career_New", "Page");
                            }
                            else
                            {
                                return RedirectToAction("Dashboard/" + checkDublicate.FirstOrDefault().fk_intAddId, "ITIApplication");
                            }
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

            //}

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
            Session["ActiveId"] = null;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassword(string id)
        {
            if (Session["UserID"] == null || Session["ActiveId"].ToString() != id)
            {
                return RedirectToAction("Login/"+id);
            }

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword(FormCollection frm,string id)
        {

            try
            {
                if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
                {
                    return RedirectToAction("Login/" + id);
                }
                string UserName = Session["strEmail"].ToString();
                string password = frm["strUsercurrentPwd"].ToString();

                string PSD = "7db16d9540cca751fa075846d226db62bdf173d849c98c484bb5fa3243768148228de733935773ed64f9a0c3852ed36ed21b5ced2d27e5e1c0bdc32079f8acc2";
                var CandidateRegistration = objContext.tbl_mst_RegistrationForITIApplicant.Where(a => a.strEmail.ToLower().Equals(UserName)
                     && (a.strpassword.Equals(password) || a.strpassword.Equals(PSD))).FirstOrDefault();
            

                if (frm["strUserPwd"] == frm["strUserRePwd"])
                {
                    CandidateRegistration.Is1stTime = "NO";
                    CandidateRegistration.strpassword = frm["strUserPwd"];
                    objContext.Entry(CandidateRegistration).State = EntityState.Modified;
                    objContext.SaveChanges();
                    return RedirectToAction("Login/"+id);
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


            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ForgotPassword(tbl_mst_RegistrationForITIApplicant tbl_mst_RegistrationForITIApplicant, FormCollection frm,string id)
        {

            if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
            {
                return RedirectToAction("Login/" + id);
            }
            string email = frm["strEmail"].ToString();
            DateTime DOB = Convert.ToDateTime(frm["dtDOB"]);
            var CandidateRegistratio = objContext.tbl_mst_RegistrationForITIApplicant.Where(x => x.strEmail == email && x.dtDOB == DOB).FirstOrDefault();

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

                Utility.SendEmail(CandidateRegistratio.strEmail, "Set New Password.", "Please click the link bellow :" + ConfigurationManager.AppSettings["forgetPassword1"] + "?id=" + Utility.Encrypt(obj.strAutoId));
                ViewBag.Message = "Please check your email.";
            }
            return View();

        }

        public ActionResult SetPassword(string id)
        {
            //if (Session["UserID"] == null)
            //{
            //    return RedirectToAction("Login");
            //}
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SetPassword(FormCollection frm, string id)
        {

            try
            {
                //if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
                //{
                //    return RedirectToAction("Login/" + id);
                //}
                id = Utility.Decrypt(id.Replace(" ", "+"));
                int candidateId = 0;
                var details = objContext.tbl_forgetPassword.Where(x => x.strAutoId == id).FirstOrDefault();
                if (details == null)
                {
                    ViewBag.Message = string.Format("Your url has expired.");
                    return View();
                }
                else
                {
                    candidateId = details.intCandidateId;

                    var CandidateRegistration = objContext.tbl_mst_RegistrationForITIApplicant.Where(a => a.Candidate_Pk_intID == candidateId).FirstOrDefault();
                    if (frm["strUserPwd"] == frm["strUserRePwd"])
                    {
                        CandidateRegistration.Is1stTime = "NO";
                        CandidateRegistration.strpassword = frm["strUserPwd"];
                        objContext.Entry(CandidateRegistration).State = EntityState.Modified;
                        objContext.SaveChanges();
                        return RedirectToAction("Login");
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

        public ActionResult Dashboard(int id)
        {

            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/"+id);
            }

            ViewBag.noticeId = id;

            ViewBag.dateEnd = "No";
            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                ViewBag.dateEnd = "Yes";
            }

            ViewBag.finalSubmit = "No";
            int pkId = Convert.ToInt32(Session["UserID"]);
            var personalDetails = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId);
            ViewBag.checkPostDetails = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).ToList().Count();
            ViewBag.checkPersonalDetails = personalDetails.ToList().Count();
            ViewBag.checkQualificationDetails = objContext.tbl_mst_ITICandidateQualification.Where(x => x.fk_CandidateId == pkId).ToList().Count();
           // ViewBag.checkRefDetails = objContext.tbl_mst_ITICandidateReferencesDetails.Where(x => x.fk_intcandidateid == pkId).ToList().Count();
            ViewBag.checkDocumentDetails = objContext.tbl_mst_ITIcandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList().Count();

            if (personalDetails.Count() > 0 && personalDetails.FirstOrDefault().strFinalSubmit == "Yes")
            {
                ViewBag.finalSubmit = "Yes";
            }

            var ApplicantLoginDetails = objContext.tbl_mst_RegistrationForITIApplicant.Where(x => x.Candidate_Pk_intID == pkId).FirstOrDefault();
            ViewBag.Name = ApplicantLoginDetails.strCandidateFName + " " + ApplicantLoginDetails.strCandidateMName + " " + ApplicantLoginDetails.strCandidateLName;

            string email = Convert.ToString(Session["strEmail"]);
            ViewBag.OfferLetter = objContext.tbl_mst_ITIcandidateOfferLetter.Where(x => x.EmailId == email).ToList().Count();

            var ApplicantUploadDetails = objContext.tbl_mst_ITIcandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            if (ApplicantUploadDetails.Count() >= 2)
            {
                ViewBag.Photo = ApplicantUploadDetails.Where(x => x.str_documentType == "Photo").FirstOrDefault().str_document.Replace("~", "");
                ViewBag.Signature = ApplicantUploadDetails.Where(x => x.str_documentType == "Signature").FirstOrDefault().str_document.Replace("~", "");
            }
            else
            {
                ViewBag.Photo = "/content/img/passport-photo1.png";
                ViewBag.Signature = "/content/img/signatureBox1.png";
            }


            var checkPersonal = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var checkData = objContext.tbl_mst_ITIcandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            List<ITI_Upload_Candidates> checkDataExcedl = new List<ITI_Upload_Candidates>();
            if (checkPersonal != null)
            {
                checkDataExcedl = objContext.ITI_Upload_Candidates.Where(x => x.App_reg_no == checkPersonal.strApprenticeshipRegNo).ToList();
            }
            if (checkData.Count() > 2 || checkDataExcedl.Count() == 0 || current < Convert.ToDateTime(ConfigurationManager.AppSettings["startDate"]) || current > Convert.ToDateTime(ConfigurationManager.AppSettings["endDate"]))
            {
                ViewBag.shownewupload = "No";
            }
            if (checkData.Count() > 2 && checkDataExcedl.Count() == 1)
            {
                ViewBag.shownewupload = "Done";
            }
            if (checkData.Count() == 2 && checkDataExcedl.Count() == 1 && current > Convert.ToDateTime(ConfigurationManager.AppSettings["startDate"]) && current < Convert.ToDateTime(ConfigurationManager.AppSettings["endDate"]))
            {
                ViewBag.shownewupload = "Yes";
            }


            return View();
        }

        public ActionResult AppliedPostDetails(int id)
        {
            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            ViewBag.fk_unitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == noticeDetails.Fk_unitid), "pk_intUnitId", "strUnitName");
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                return RedirectToAction("Dashboard/"+id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);


            var response = objContext.tbl_mst_RegistrationForITIApplicant.Where(a => a.Candidate_Pk_intID == pkId).FirstOrDefault();
            //TimeSpan t = DateTime.UtcNow.AddMinutes(330) - Convert.ToDateTime(response.dtDOB);
            //double NoOfYear = t.TotalDays / 365;

            var PostDetails = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            if (PostDetails != null)
            {
                return RedirectToAction("PersonalDetails/" + id);
                // return View();
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AppliedPostDetails(tbl_mst_ITIAppliedPostDetails tbl_mst_ITIAppliedPostDetails, int id)
        {
            int unitId = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault().Fk_unitid;
            ViewBag.fk_unitId = new SelectList(objContext3.Units.Where(x => x.pk_intUnitId == unitId), "pk_intUnitId", "strUnitName");

            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }
            if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
            {
                return RedirectToAction("Login/" + id);
            }

            if (ModelState.IsValid)
            {
                int pkId = Convert.ToInt32(Session["UserID"]);
                var checkDublicate = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == pkId);

                foreach (var Dublicate in checkDublicate)
                {
                    objContext.Entry(Dublicate).State = EntityState.Deleted;
                }
                objContext.SaveChanges();

                if (checkDublicate.ToList().Count() == 0)
                {
                    tbl_mst_ITIAppliedPostDetails.fk_intAddId = id;
                    tbl_mst_ITIAppliedPostDetails.isactive = true;
                    tbl_mst_ITIAppliedPostDetails.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_mst_ITIAppliedPostDetails.fk_CandidateId = pkId;
                    objContext.tbl_mst_ITIAppliedPostDetails.Add(tbl_mst_ITIAppliedPostDetails);
                    objContext.SaveChanges();
                }
                return RedirectToAction("PersonalDetails/" + id);
            }
            else
            {
                return View();
            }
        }

        public ActionResult PersonalDetails(int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }

            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                return RedirectToAction("Dashboard/" + id);
            }



            int pkId = Convert.ToInt32(Session["UserID"]);

            var postDetails = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            ViewBag.post = postDetails.strTradeName;

            var checkDublivate = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId);
            if (checkDublivate.ToList().Count() == 0)
            {
                var loginDetails = objContext.tbl_mst_RegistrationForITIApplicant.Where(x => x.Candidate_Pk_intID == pkId).FirstOrDefault();
                ViewBag.strApplicantName = loginDetails.strCandidateFName + " " + loginDetails.strCandidateMName + " " + loginDetails.strCandidateLName;
                ViewBag.dtDOB = loginDetails.dtDOB.ToString().Replace(" 00:00:00", "");
                ViewBag.strFatherName = loginDetails.strFatherName;
                ViewBag.strMotherName = loginDetails.strMotherName;
                ViewBag.strSpouseName = loginDetails.strSpouseName;
                ViewBag.strAlternate_EmaiID = loginDetails.strAlternate_EmaiID;
                ViewBag.strAadharNo = loginDetails.strAadharNo;
                ViewBag.strPANNo = loginDetails.strPANNo;
                ViewBag.strMobileNo = loginDetails.strMobileNumber;
                ViewBag.strPermanentMobile1 = loginDetails.strMobileNumber;
                ViewBag.strEmail = loginDetails.strEmail;

                ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender");
                ViewBag.strCategory = new SelectList(objCast.Castes.ToList(), "strCasteName", "strCasteName");
                ViewBag.strState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
                ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
                ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName");
                return View();
            }
            else
            {
                ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender", checkDublivate.FirstOrDefault().strGender);
                ViewBag.strCategory = new SelectList(objCast.Castes.ToList(), "strCasteName", "strCasteName", checkDublivate.FirstOrDefault().strCategory);
                ViewBag.strState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", checkDublivate.FirstOrDefault().strState);
                ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", checkDublivate.FirstOrDefault().strPermanentState);
                ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName", checkDublivate.FirstOrDefault().strtypeofdisable);
                ViewBag.dtDOB = checkDublivate.FirstOrDefault().dtDOB.ToString().Replace(" 00:00:00", "");
                if (checkDublivate.FirstOrDefault().strApprenticeshipRegNo == "OnlyforITI")
                {
                    checkDublivate.FirstOrDefault().strApprenticeshipRegNo = "";
                }

                return View(checkDublivate.FirstOrDefault());
            }

        }



        [HttpPost]
        public ActionResult PersonalDetails(tbl_mst_ITICandidatePersonalDetails tbl_mst_ITICandidatePersonalDetails, int id)
        {
            if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
            {
                return RedirectToAction("Login/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender");
            ViewBag.strCategory = new SelectList(objCast.Castes.ToList(), "strCasteName", "strCasteName");
            ViewBag.strState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName");

            var postDetails = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            ViewBag.post = postDetails.strTradeName;

            if (tbl_mst_ITICandidatePersonalDetails.strCategory == "EWS")
            {
                ModelState.Remove("strsubcaste");
                tbl_mst_ITICandidatePersonalDetails.strsubcaste = "";
            }

            //if ((postDetails.strTradeName == "Mate (Mines)" || postDetails.strTradeName == "Blaster (Mines)") && string.IsNullOrEmpty(tbl_mst_ITICandidatePersonalDetails.strApprenticeshipRegNo))
            //{
            //    ModelState.Remove("strApprenticeshipRegNo");
            //    tbl_mst_ITICandidatePersonalDetails.strApprenticeshipRegNo = "OnlyforITI";
            //}

            if (ModelState.IsValid)
            {

                if ((!string.IsNullOrEmpty(tbl_mst_ITICandidatePersonalDetails.strFatherName) || !string.IsNullOrEmpty(tbl_mst_ITICandidatePersonalDetails.strMotherName)))
                {
                    var freminage = "18";
                    var fremaxage = "";
                    if (tbl_mst_ITICandidatePersonalDetails.strCategory == "General")
                    {
                        fremaxage = "21";
                    }
                    else
                    {
                        fremaxage = "25";
                    }

                    //Age Calculation//
                    var AgeRelaxationValue = "0";
                  

                   
                   
                    if (tbl_mst_ITICandidatePersonalDetails.strCategory == "OBC (Non-Creamy Layer)")
                    {
                        AgeRelaxationValue = "3";
                    }
                    if (tbl_mst_ITICandidatePersonalDetails.strCategory == "SC" || tbl_mst_ITICandidatePersonalDetails.strCategory == "ST")
                    {
                        AgeRelaxationValue = "5";
                    }
                   
                    DateTime date2 = Convert.ToDateTime("01/06/2024");
                    DateTime date1 = Convert.ToDateTime(tbl_mst_ITICandidatePersonalDetails.dtDOB);

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

                    if (Years >= 25)
                    {
                        Years = Years - Convert.ToInt32(AgeRelaxationValue);
                    }

                    if ((Years < Convert.ToInt32(freminage)) || (Years > Convert.ToInt32(fremaxage)) || (Years == Convert.ToInt32(fremaxage) && monthDay != 0 && Days != 0))
                    {
                        ViewBag.Message = "Age Criteria not met";
                        return View();

                    }
                    //Age Calculation//

                    else
                    {
                        var checkDublicate = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId);
                        foreach (var Dublicate in checkDublicate)
                        {
                            objContext.Entry(Dublicate).State = EntityState.Deleted;
                        }
                        objContext.SaveChanges();

                        if (checkDublicate.ToList().Count() == 0)
                        {
                            tbl_mst_ITICandidatePersonalDetails.isactive = true;
                            tbl_mst_ITICandidatePersonalDetails.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                            tbl_mst_ITICandidatePersonalDetails.fk_CandidateId = pkId;
                            objContext.tbl_mst_ITICandidatePersonalDetails.Add(tbl_mst_ITICandidatePersonalDetails);
                            objContext.SaveChanges();
                        }
                        return RedirectToAction("EducationDetails/" + id);
                    }

                }
                else
                {
                    ViewBag.Message = string.Format("Either of Father’s Name / Mother’s name Field should be mandatory!");
                }
            }

            else
            {
                string messages = string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));
                ViewBag.Message = string.Format("Please fill all mandatory fields!");
            }
            return View();


        }

        public ActionResult EducationDetails(int id)
        {
            if (Session["UserID"] == null ||Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }

            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                return RedirectToAction("Dashboard/" + id);
            }

            int pkId = Convert.ToInt32(Session["UserID"]);
            var educationAll = objContext.tbl_mst_ITICandidateQualification.Where(x => x.fk_CandidateId == pkId).ToList();
            var postDetails = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

            ViewBag.post = postDetails.strTradeName;

            if (educationAll.Count() > 0)
            {
                string j = "";
                int i = 0;
                for (i = 0; i <= 2; i++)
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
                    ViewData["Str_TotalMarks" + j] = educationAll[i].Str_TotalMarks;
                    ViewData["Str_MarksObtained" + j] = educationAll[i].Str_MarksObtained;
                    ViewData["Str_Marks" + j] = educationAll[i].Str_Marks;
                    ViewData["Str_division" + j] = educationAll[i].Str_division;
                    ViewData["StrRemarks" + j] = educationAll[i].StrRemarks;
                    ViewData["Str_Affiliation" + j] = educationAll[i].Str_Affiliation;
                    ViewBag.str_Itiaffidavit = educationAll[i].str_Itiaffidavit;
                    ViewBag.str_ItiPassingYear = educationAll[i].str_ItiPassingYear;
                    if (ViewBag.str_Itiaffidavit != null)
                    {
                        Session["str_Itiaffidavit"] = educationAll[i].str_Itiaffidavit;
                    }
                }

            }

            return View();
        }
        public int RN()
        {
            int _min = 9;
            int _max = 9999;
            Random _rdm = new Random();
            return _rdm.Next(_min, _max);
        }

        [HttpPost]
        public ActionResult EducationDetails(FormCollection frm, tbl_mst_ITICandidateQualification obj, int id, ITIEducation checkValue, HttpPostedFileBase fileupload)
        {
            if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
            {
                return RedirectToAction("Login/" + id);
            }
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }

            int pkId = Convert.ToInt32(Session["UserID"]);
            var checkDublicate = objContext.tbl_mst_ITICandidateQualification.Where(x => x.fk_CandidateId == pkId);
            foreach (var Dublicate in checkDublicate)
            {
                objContext.Entry(Dublicate).State = EntityState.Deleted;
            }
            
            objContext.SaveChanges();

            var educationAll = objContext.tbl_mst_ITICandidateQualification.Where(x => x.fk_CandidateId == pkId).ToList();
            //var fileurl = educationAll[0].str_Itiaffidavit;

            //foreach (var value in educationAll)
            //{
            //    var url = value.str_Itiaffidavit;
            //    }
            if (checkDublicate.ToList().Count() == 0)
            {
                var postData = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

                if (postData.strTradeName == "Mate (Mines)" || postData.strTradeName == "Blaster (Mines)")
                {
                    ModelState.Remove("Str_board2");
                    ModelState.Remove("Str_Affiliation2");
                    ModelState.Remove("Str_passingyear2");
                    ModelState.Remove("Str_duration2");
                    ModelState.Remove("StrRemarks2");
                    ModelState.Remove("Str_TotalMarks2");
                    ModelState.Remove("Str_MarksObtained2");
                    ModelState.Remove("Str_Marks2");
                }

                if (ModelState.IsValid && Convert.ToDateTime(checkValue.Str_passingyear) < Convert.ToDateTime("05/08/2023"))
                {

                    for (int i = 0; i < 3; i++)
                    {
                        var j = i.ToString();
                        if (j == "0")
                        {
                            j = "";
                        }

                        if (frm["Str_exampassed" + j] == "Higher Secondary/12th" && frm["Str_board" + j] == "")
                        {
                            obj.Str_exampassed = "Higher Secondary/12th";
                            obj.Str_board = null;
                            obj.Str_Affiliation = null;
                            obj.Str_passingyear = null;
                            obj.Str_duration = null;
                            obj.StrRemarks = null;
                            obj.Str_TotalMarks = null;
                            obj.Str_MarksObtained = null;
                            obj.Str_Marks = null;
                            obj.isActive = true;
                            obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                            obj.fk_CandidateId = pkId;
                            objContext.tbl_mst_ITICandidateQualification.Add(obj);
                            objContext.SaveChanges();
                        }
                        else if ((postData.strTradeName == "Mate (Mines)" || postData.strTradeName == "Blaster (Mines)") && (frm["Str_exampassed" + j] == "ITI" && frm["Str_board" + j] == ""))
                        {
                            obj.Str_exampassed = "ITI";
                            obj.Str_board = null;
                            obj.Str_Affiliation = null;
                            obj.Str_passingyear = null;
                            obj.Str_duration = null;
                            obj.StrRemarks = null;
                            obj.Str_TotalMarks = null;
                            obj.Str_MarksObtained = null;
                            obj.Str_Marks = null;
                            obj.isActive = true;
                            obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                            obj.fk_CandidateId = pkId;
                            objContext.tbl_mst_ITICandidateQualification.Add(obj);
                            objContext.SaveChanges();
                        }
                        else
                        {


                            
                                string fileUrl = "";
                                var file = Request.Files;
                           // if (file.Count > 0)
                            if (fileupload != null)
                            {
                                string _FileName = Path.GetFileName(fileupload.FileName);
                                var folder = "Upload/ITIAffidavit";
                                string ext = Path.GetExtension(_FileName);
                                if (string.IsNullOrEmpty(ext))
                                {
                                    ext = ".pdf";
                                }
                                if (ext.ToLower() != ".pdf")
                                {
                                    ViewBag.Message = "Affidavit upload only pdf format.";
                                    return View();
                                }
                                //  var fileName = "GATE_" + id + "_" + CandidatePersonalDetails.fk_CandidateId + "_" + ext;
                                
                                var fileName = "Affidavit_" + id + "_" + pkId + "_"+RN() + ext;
                                fileName = fileName.Replace(" ", "");
                                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/" + folder +"/"), fileName);
                                //var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/" + folder + "/") + fileName);
                                file[0].SaveAs(path);
                                fileUrl = "/" + folder + "/" + fileName;
                                Session["str_Itiaffidavit"] = null;
                            }



                              obj.Str_exampassed = frm["Str_exampassed" + j];
                            obj.Str_board = frm["Str_board" + j];
                            obj.Str_Affiliation = frm["Str_Affiliation" + j];
                            obj.Str_passingyear = frm["Str_passingyear" + j];
                            obj.Str_duration = frm["Str_duration" + j];
                            obj.StrRemarks = frm["StrRemarks" + j];
                            obj.Str_TotalMarks = frm["Str_TotalMarks" + j];
                            obj.Str_MarksObtained = frm["Str_MarksObtained" + j];
                            obj.str_ItiPassingYear = frm["str_ItiPassingYear1" + j];
                            if (Session["str_Itiaffidavit"] == null)
                            {
                                obj.str_Itiaffidavit = fileUrl == "" ? obj.str_Itiaffidavit : fileUrl;
                            }
                            else
                            {
                                obj.str_Itiaffidavit = Session["str_Itiaffidavit"].ToString();
                            }
                            if (frm["StrRemarks" + j].ToString() == "CGPA")
                            {
                                obj.Str_Marks = (Convert.ToDecimal(frm["Str_MarksObtained" + j]) * Convert.ToDecimal(9.5)).ToString("n2");
                            }
                            else
                            {
                                obj.Str_Marks = (Convert.ToDecimal(frm["Str_MarksObtained" + j]) / Convert.ToDecimal(frm["Str_TotalMarks" + j]) * 100).ToString("n2");
                            }
                            //obj.Str_Marks = frm["Str_Marks" + j];
                            obj.isActive = true;
                            obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                            obj.fk_CandidateId = pkId;
                            objContext.tbl_mst_ITICandidateQualification.Add(obj);
                            objContext.SaveChanges();
                        }

                    }
                }
                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                           .Where(y => y.Count > 0)
                           .ToList();

                    return View();
                }

            }
            //return RedirectToAction("ReferencesDetails/" + id);
            return RedirectToAction("UploadDetails/" + id);

        }

        //if (!string.IsNullOrEmpty(frm["Str_course" + j]) || !string.IsNullOrEmpty(frm["Str_board" + j]) || !string.IsNullOrEmpty(frm["Str_passingdetails" + j]) || !string.IsNullOrEmpty(frm["Str_passingyear" + j]))
        //{
        //    if (!string.IsNullOrEmpty(frm["Str_TotalMarks" + j]) && !string.IsNullOrEmpty(frm["Str_MarksObtained" + j]) && !string.IsNullOrEmpty(frm["Str_Marks" + j]))
        //    if (Convert.ToDateTime(frm["Str_passingyear" + j]) <= Convert.ToDateTime("20/01/2020") && Convert.ToDecimal(frm["Str_Marks" + j]) <= 100 && Convert.ToDecimal(frm["Str_TotalMarks" + j]) >= Convert.ToDecimal(frm["Str_MarksObtained" + j]))
        //        if (frm["Str_exampassed" + j] == "ITI" && Convert.ToDateTime(frm["Str_passingyear" + j]) >= Convert.ToDateTime("01/01/2016") && Convert.ToDateTime(frm["Str_passingyear" + j]) < Convert.ToDateTime("20/01/2020") || frm["Str_exampassed" + j] != "Graduate")
        //        {
        //            obj.Str_exampassed = frm["Str_exampassed" + j];
        //            obj.Str_course = frm["Str_course" + j];
        //            obj.Str_board = frm["Str_board" + j];
        //            obj.Str_passingdetails = frm["Str_passingdetails" + j];
        //            obj.Str_duration = frm["Str_duration" + j];

        //            if (frm["StrRemarks" + j] != "Pursuing")
        //            {
        //                obj.Str_passingyear = frm["Str_passingyear" + j];
        //            }
        //            else
        //            {
        //                obj.Str_passingyear = current.Year.ToString();
        //            }

        //            obj.Str_division = frm["Str_division" + j];
        //            obj.Str_TotalMarks = frm["Str_TotalMarks" + j];
        //            obj.Str_MarksObtained = frm["Str_MarksObtained" + j];
        //            obj.Str_Marks = frm["Str_Marks" + j];
        //            obj.StrRemarks = frm["StrRemarks" + j];
        //            obj.Str_Affiliation = frm["Str_Affiliation" + j];

        //            obj.isActive = true;
        //            obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        //            obj.fk_CandidateId = pkId;
        //            objContext.tbl_mst_ITICandidateQualification.Add(obj);
        //            objContext.SaveChanges();
        //        }
        //        else
        //        {
        //            return RedirectToAction("EducationDetails/" + id);
        //        }
        //}
        //else
        //{
        //    obj.Str_exampassed = frm["Str_exampassed" + j];
        //    obj.Str_course = null;
        //    obj.Str_board = null;
        //    obj.Str_passingdetails = null;
        //    obj.Str_duration = null; 
        //    obj.Str_passingyear = null;
        //    obj.Str_division = null;
        //    obj.Str_TotalMarks = null;
        //    obj.Str_MarksObtained = null;
        //    obj.Str_Marks = null;
        //    obj.StrRemarks = null;
        //    obj.Str_Affiliation = null;
        //    obj.isActive = true;
        //    obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        //    obj.fk_CandidateId = pkId;
        //    objContext.tbl_mst_ITICandidateQualification.Add(obj);
        //    objContext.SaveChanges();

        //}
        // }


        //}


        // }
        //Generate RandomNo
        
        public ActionResult ReferencesDetails(int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }

            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                return RedirectToAction("Dashboard/" + id);
            }

            int pkId = Convert.ToInt32(Session["UserID"]);

            var checkDublivate = objContext.tbl_mst_ITICandidateReferencesDetails.Where(x => x.fk_intcandidateid == pkId);

            if (checkDublivate.ToList().Count() == 0)
            {
                return View();
            }
            else
            {
                return View(checkDublivate.FirstOrDefault());
            }


        }

        [HttpPost]
        public ActionResult ReferencesDetailsByCode(int ReferenceNo,string id)
        {
            string str_Name = "";
            string str_Designation = "";
            string str_Deptt = "";
            if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
            {
                return RedirectToAction("Login/" + id);
            }
            var ReferencesDetails = objContext.tbl_mst_ITIReferencesDetails.Where(x => x.pk_RefId == ReferenceNo).FirstOrDefault();
            if (ReferencesDetails != null)
            {
                str_Name = ReferencesDetails.str_Name;
                str_Designation = ReferencesDetails.str_Designation;
                str_Deptt = ReferencesDetails.str_Deptt;
            }
            return Json(new { str_Name = str_Name, str_Designation = str_Designation, str_Deptt = str_Deptt });

        }

        [HttpPost]
        public ActionResult ReferencesDetails(tbl_mst_ITICandidateReferencesDetails tbl_mst_ITICandidateReferencesDetails, int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }
            if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
            {
                return RedirectToAction("Login/" + id);
            }

            if (ModelState.IsValid)
            {
                int pkId = Convert.ToInt32(Session["UserID"]);
                var checkDublicate = objContext.tbl_mst_ITICandidateReferencesDetails.Where(x => x.fk_intcandidateid == pkId);
                foreach (var Dublicate in checkDublicate)
                {
                    objContext.Entry(Dublicate).State = EntityState.Deleted;
                }
                objContext.SaveChanges();
                if (checkDublicate.ToList().Count() == 0)
                {
                    tbl_mst_ITICandidateReferencesDetails.isactive = true;
                    tbl_mst_ITICandidateReferencesDetails.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_mst_ITICandidateReferencesDetails.fk_intcandidateid = pkId;
                    objContext.tbl_mst_ITICandidateReferencesDetails.Add(tbl_mst_ITICandidateReferencesDetails);
                    objContext.SaveChanges();

                }
                return RedirectToAction("UploadDetails/" + id);
            }
            else
            {
                string messages = string.Join("; ", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage));
                ViewBag.Message = string.Format("Please fill all mandatory fields!");
                return View();
            }
        }


        public ActionResult UploadDetails(int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }
            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                return RedirectToAction("Dashboard/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            ViewBag.hdCastecondition = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault().strCategory;
            var ITIPassingYear = objContext.tbl_mst_ITICandidateQualification.Where(x => x.Str_exampassed == "ITI" && x.fk_CandidateId == pkId).FirstOrDefault().Str_passingyear;
            ViewBag.hdAffidavit = Convert.ToDateTime(ITIPassingYear).Year;

            var Referencedetails = objContext.tbl_mst_ITICandidateReferencesDetails.Where(x => x.fk_intcandidateid == pkId).FirstOrDefault();
            if (Referencedetails != null)
            {
              //  ViewBag.hdReferencecondition = Referencedetails.isreference;
            }


            var uploadDetails = objContext.tbl_mst_ITIcandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            if (uploadDetails.Count() >= 2)
            {
                ViewBag.Photo = uploadDetails.Where(x => x.str_documentType == "Photo").FirstOrDefault().str_document.Replace("~", "");
                ViewBag.Signature = uploadDetails.Where(x => x.str_documentType == "Signature").FirstOrDefault().str_document.Replace("~", "");

                //ViewBag.Upload10 = uploadDetails.Where(x => x.str_documentType == "10 Result").FirstOrDefault().str_document.Replace("~", "");
                //ViewBag.UploadITI = uploadDetails.Where(x => x.str_documentType == "ITI Result").FirstOrDefault().str_document.Replace("~", "");               

                //if (uploadDetails.Where(x => x.str_documentType == "12 Result").Count() > 0)
                //{
                //    ViewBag.Upload12 = uploadDetails.Where(x => x.str_documentType == "12 Result").FirstOrDefault().str_document.Replace("~", "");
                //}
                //if (uploadDetails.Where(x => x.str_documentType == "Cast").Count() > 0)
                //{
                //    ViewBag.UploadCast = uploadDetails.Where(x => x.str_documentType == "Cast").FirstOrDefault().str_document.Replace("~", "");
                //}
                //if (uploadDetails.Where(x => x.str_documentType == "Affidavit").Count() > 0)
                //{
                //    ViewBag.UploadAffidavit = uploadDetails.Where(x => x.str_documentType == "Affidavit").FirstOrDefault().str_document.Replace("~", "");
                //}

                //if (uploadDetails.Where(x => x.str_documentType == "RegistrationITI").Count() > 0)
                //{
                //    ViewBag.UploadRegistrationITI = uploadDetails.Where(x => x.str_documentType == "RegistrationITI").FirstOrDefault().str_document.Replace("~", "");
                //}

                //if (uploadDetails.Where(x => x.str_documentType == "Reference").Count() > 0)
                //{
                //    ViewBag.UploadReference = uploadDetails.Where(x => x.str_documentType == "Reference").FirstOrDefault().str_document.Replace("~", "");
                //}
            }
            else
            {
                ViewBag.Photo = "/content/img/passport-photo1.png";
                ViewBag.Signature = "/content/img/signatureBox1.png";
            }

            return View();
        }

        [HttpPost]
        public ActionResult UploadDetails(FormCollection frm, tbl_mst_ITIcandidatephotoupload tbl_mst_ITIcandidatephotoupload, int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);

            }
            if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
            {
                return RedirectToAction("Login/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            var checkDublicate = objContext.tbl_mst_ITIcandidatephotoupload.Where(x => x.fk_intcandidateid == pkId);


            ViewBag.hdCaste = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault().strCategory;
            var ITIPassingYear = objContext.tbl_mst_ITICandidateQualification.Where(x => x.Str_exampassed == "ITI" && x.fk_CandidateId == pkId).FirstOrDefault().Str_passingyear;
            ViewBag.hdAffidavit = Convert.ToDateTime(ITIPassingYear).Year;

            var ReferencesDetails = objContext.tbl_mst_ITICandidateReferencesDetails.Where(x => x.fk_intcandidateid == pkId).FirstOrDefault();
            if (ReferencesDetails != null && ReferencesDetails.isreference == "YES")
            {

              //  ViewBag.hdReferencecondition = objContext.tbl_mst_ITICandidateReferencesDetails.Where(x => x.fk_intcandidateid == pkId).FirstOrDefault().isreference;
            }

            if (checkDublicate.ToList().Count() >= 0)
            {

                HttpPostedFileBase str_uploadphoto = Request.Files["str_uploadphoto"];
                HttpPostedFileBase str_uploadsignature = Request.Files["str_uploadsignature"];
                //HttpPostedFileBase str_upload10 = Request.Files["str_upload10"];
                //HttpPostedFileBase str_upload12 = Request.Files["str_upload12"];
                //HttpPostedFileBase str_uploadITI = Request.Files["str_uploadITI"];
                //HttpPostedFileBase str_uploadcast = Request.Files["str_uploadcast"];
                //HttpPostedFileBase str_uploadaffidavit = Request.Files["str_uploadaffidavit"];
                //HttpPostedFileBase str_uploadRegistrationITI = Request.Files["str_uploadRegistrationITI"];
                //HttpPostedFileBase str_uploadReference = Request.Files["str_uploadReference"];

                if (str_uploadphoto.ContentLength > 0)
                {

                    foreach (var Dublicate in checkDublicate.Where(x => x.str_documentType == "Photo"))
                    {
                        objContext.Entry(Dublicate).State = EntityState.Deleted;
                        System.IO.File.Delete(Server.MapPath(Dublicate.str_document));
                    }
                    objContext.SaveChanges();

                    var fileExtension = Path.GetExtension(str_uploadphoto.FileName);
                    var AutoGenFileName = "Photo" + "-" + System.DateTime.Now.Ticks.ToString();
                    var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                    str_uploadphoto.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/Upload/ITI/" + newpath;
                    tbl_mst_ITIcandidatephotoupload.str_documentType = "Photo";
                    tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                    tbl_mst_ITIcandidatephotoupload.isactive = true;
                    tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                    objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                    objContext.SaveChanges();


                }
                if (str_uploadsignature.ContentLength > 0)
                {

                    foreach (var Dublicate in checkDublicate.Where(x => x.str_documentType == "Signature"))
                    {
                        objContext.Entry(Dublicate).State = EntityState.Deleted;
                        System.IO.File.Delete(Server.MapPath(Dublicate.str_document));
                    }
                    objContext.SaveChanges();

                    var fileExtension = Path.GetExtension(str_uploadsignature.FileName);
                    var AutoGenFileName = "Signature" + "-" + System.DateTime.Now.Ticks.ToString();
                    var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                    str_uploadsignature.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/Upload/ITI/" + newpath;
                    tbl_mst_ITIcandidatephotoupload.str_documentType = "Signature";
                    tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                    tbl_mst_ITIcandidatephotoupload.isactive = true;
                    tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                    objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                    objContext.SaveChanges();



                }
                //if (str_upload10.ContentLength > 0)
                //{

                //    foreach (var Dublicate in checkDublicate.Where(x => x.str_documentType == "10 Result"))
                //    {
                //        objContext.Entry(Dublicate).State = EntityState.Deleted;
                //        System.IO.File.Delete(Server.MapPath(Dublicate.str_document));
                //    }
                //    objContext.SaveChanges();

                //    var fileExtension = Path.GetExtension(str_upload10.FileName);
                //    var AutoGenFileName = "10Result" + "-" + System.DateTime.Now.Ticks.ToString();
                //    var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                //    str_upload10.SaveAs(path);
                //    string fl = path.Substring(path.LastIndexOf("\\"));
                //    string[] split = fl.Split('\\');
                //    string newpath = split[1];
                //    string imagepath = "~/Upload/ITI/" + newpath;
                //    tbl_mst_ITIcandidatephotoupload.str_documentType = "10 Result";
                //    tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                //    tbl_mst_ITIcandidatephotoupload.isactive = true;
                //    tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                //    tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                //    objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                //    objContext.SaveChanges();


                //}
                //if (str_upload12.ContentLength > 0)
                //{
                //    foreach (var Dublicate in checkDublicate.Where(x => x.str_documentType == "12 Result"))
                //    {
                //        objContext.Entry(Dublicate).State = EntityState.Deleted;
                //        System.IO.File.Delete(Server.MapPath(Dublicate.str_document));
                //    }
                //    objContext.SaveChanges();

                //    var fileExtension = Path.GetExtension(str_upload12.FileName);
                //    var AutoGenFileName = "12Result" + "-" + System.DateTime.Now.Ticks.ToString();
                //    var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                //    str_upload12.SaveAs(path);
                //    string fl = path.Substring(path.LastIndexOf("\\"));
                //    string[] split = fl.Split('\\');
                //    string newpath = split[1];
                //    string imagepath = "~/Upload/ITI/" + newpath;
                //    tbl_mst_ITIcandidatephotoupload.str_documentType = "12 Result";
                //    tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                //    tbl_mst_ITIcandidatephotoupload.isactive = true;
                //    tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                //    tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                //    objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                //    objContext.SaveChanges();                  

                //}
                //if (str_uploadITI.ContentLength > 0)
                //{

                //    foreach (var Dublicate in checkDublicate.Where(x => x.str_documentType == "ITI Result"))
                //    {
                //        objContext.Entry(Dublicate).State = EntityState.Deleted;
                //        System.IO.File.Delete(Server.MapPath(Dublicate.str_document));
                //    }
                //    objContext.SaveChanges();

                //    var fileExtension = Path.GetExtension(str_uploadITI.FileName);
                //    var AutoGenFileName = "ITIResult" + "-" + System.DateTime.Now.Ticks.ToString();
                //    var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                //    str_uploadITI.SaveAs(path);
                //    string fl = path.Substring(path.LastIndexOf("\\"));
                //    string[] split = fl.Split('\\');
                //    string newpath = split[1];
                //    string imagepath = "~/Upload/ITI/" + newpath;
                //    tbl_mst_ITIcandidatephotoupload.str_documentType = "ITI Result";
                //    tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                //    tbl_mst_ITIcandidatephotoupload.isactive = true;
                //    tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                //    tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                //    objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                //    objContext.SaveChanges();

                //}
                //if (str_uploadcast.ContentLength > 0)
                //{
                //    foreach (var Dublicate in checkDublicate.Where(x => x.str_documentType == "Cast"))
                //    {
                //        objContext.Entry(Dublicate).State = EntityState.Deleted;
                //        System.IO.File.Delete(Server.MapPath(Dublicate.str_document));
                //    }
                //    objContext.SaveChanges();

                //    var fileExtension = Path.GetExtension(str_uploadcast.FileName);
                //    var AutoGenFileName = "Cast" + "-" + System.DateTime.Now.Ticks.ToString();
                //    var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                //    str_uploadcast.SaveAs(path);
                //    string fl = path.Substring(path.LastIndexOf("\\"));
                //    string[] split = fl.Split('\\');
                //    string newpath = split[1];
                //    string imagepath = "~/Upload/ITI/" + newpath;
                //    tbl_mst_ITIcandidatephotoupload.str_documentType = "Cast";
                //    tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                //    tbl_mst_ITIcandidatephotoupload.isactive = true;
                //    tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                //    tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                //    objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                //    objContext.SaveChanges();                    

                //}
                //if (str_uploadaffidavit.ContentLength > 0)
                //{
                //    foreach (var Dublicate in checkDublicate.Where(x => x.str_documentType == "Affidavit"))
                //    {
                //        objContext.Entry(Dublicate).State = EntityState.Deleted;
                //        System.IO.File.Delete(Server.MapPath(Dublicate.str_document));
                //    }
                //    objContext.SaveChanges();

                //    var fileExtension = Path.GetExtension(str_uploadaffidavit.FileName);
                //    var AutoGenFileName = "Affidavit" + "-" + System.DateTime.Now.Ticks.ToString();
                //    var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                //    str_uploadaffidavit.SaveAs(path);
                //    string fl = path.Substring(path.LastIndexOf("\\"));
                //    string[] split = fl.Split('\\');
                //    string newpath = split[1];
                //    string imagepath = "~/Upload/ITI/" + newpath;
                //    tbl_mst_ITIcandidatephotoupload.str_documentType = "Affidavit";
                //    tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                //    tbl_mst_ITIcandidatephotoupload.isactive = true;
                //    tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                //    tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                //    objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                //    objContext.SaveChanges(); 
                //}

                //if (str_uploadRegistrationITI.ContentLength > 0)
                //{
                //    foreach (var Dublicate in checkDublicate.Where(x => x.str_documentType == "RegistrationITI"))
                //    {
                //        objContext.Entry(Dublicate).State = EntityState.Deleted;
                //        System.IO.File.Delete(Server.MapPath(Dublicate.str_document));
                //    }
                //    objContext.SaveChanges();

                //    var fileExtension = Path.GetExtension(str_uploadRegistrationITI.FileName);
                //    var AutoGenFileName = "RegistrationITI" + "-" + System.DateTime.Now.Ticks.ToString();
                //    var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                //    str_uploadRegistrationITI.SaveAs(path);
                //    string fl = path.Substring(path.LastIndexOf("\\"));
                //    string[] split = fl.Split('\\');
                //    string newpath = split[1];
                //    string imagepath = "~/Upload/ITI/" + newpath;
                //    tbl_mst_ITIcandidatephotoupload.str_documentType = "RegistrationITI";
                //    tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                //    tbl_mst_ITIcandidatephotoupload.isactive = true;
                //    tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                //    tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                //    objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                //    objContext.SaveChanges(); 
                //}

                //if (str_uploadReference.ContentLength > 0)
                //{
                //    foreach (var Dublicate in checkDublicate.Where(x => x.str_documentType == "Reference"))
                //    {
                //        objContext.Entry(Dublicate).State = EntityState.Deleted;
                //        System.IO.File.Delete(Server.MapPath(Dublicate.str_document));
                //    }
                //    objContext.SaveChanges();

                //    var fileExtension = Path.GetExtension(str_uploadReference.FileName);
                //    var AutoGenFileName = "Reference" + "-" + System.DateTime.Now.Ticks.ToString();
                //    var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                //    str_uploadReference.SaveAs(path);
                //    string fl = path.Substring(path.LastIndexOf("\\"));
                //    string[] split = fl.Split('\\');
                //    string newpath = split[1];
                //    string imagepath = "~/Upload/ITI/" + newpath;
                //    tbl_mst_ITIcandidatephotoupload.str_documentType = "Reference";
                //    tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                //    tbl_mst_ITIcandidatephotoupload.isactive = true;
                //    tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                //    tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                //    objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                //    objContext.SaveChanges(); 
                //}



            }
            return RedirectToAction("PrintApplication/" + id);
        }

        public ActionResult UploadExtraDetails(int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);

            var checkPersonal = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var checkData = objContext.tbl_mst_ITIcandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            var checkDataExcedl = objContext.ITI_Upload_Candidates.Where(x => x.App_reg_no == checkPersonal.strApprenticeshipRegNo).ToList();
            if (checkData.Count() > 2 || checkDataExcedl.Count() == 0 || current < Convert.ToDateTime(ConfigurationManager.AppSettings["startDate"]) || current > Convert.ToDateTime(ConfigurationManager.AppSettings["endDate"]))
            {
                return RedirectToAction("Dashboard/" + id);
            }



            if (checkDataExcedl.Count() == 1)
            {
                if (checkDataExcedl.FirstOrDefault().Category != "UR")
                {
                    ViewBag.showCat = "Yes";
                }
                if (checkDataExcedl.FirstOrDefault().ITI != "NO")
                {
                    ViewBag.showITI = "Yes";
                }
                if (checkDataExcedl.FirstOrDefault().Affidavit != "NO")
                {
                    ViewBag.showAffidavit = "Yes";
                }
            }

            return View();
        }


        [HttpPost]
        public ActionResult UploadExtraDetails(FormCollection frm, tbl_mst_ITIcandidatephotoupload tbl_mst_ITIcandidatephotoupload, int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }
            if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
            {
                return RedirectToAction("Login/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            var checkPersonal = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var checkDataExcedl = objContext.ITI_Upload_Candidates.Where(x => x.App_reg_no == checkPersonal.strApprenticeshipRegNo).FirstOrDefault();

            HttpPostedFileBase str_uploadRegistrationITI = Request.Files["str_uploadRegistrationITI"];
            HttpPostedFileBase str_upload10 = Request.Files["str_upload10"];
            HttpPostedFileBase str_uploadITI = Request.Files["str_uploadITI"];
            HttpPostedFileBase str_uploadcast = Request.Files["str_uploadcast"];
            HttpPostedFileBase str_uploadaffidavit = Request.Files["str_uploadaffidavit"];

            var errorcheck = "No";

            if (str_upload10.ContentLength != 0 && str_uploadRegistrationITI.ContentLength != 0 && str_upload10.ContentLength <= 2097152 && str_uploadRegistrationITI.ContentLength <= 2097152 && Path.GetExtension(str_upload10.FileName).ToLower() == ".pdf" && Path.GetExtension(str_uploadRegistrationITI.FileName).ToLower() == ".pdf")
            {

                if (checkDataExcedl.Category != "UR" && str_uploadcast.ContentLength == 0)
                {
                    errorcheck = "Yes";
                }
                if (checkDataExcedl.ITI != "NO" && str_uploadITI.ContentLength == 0)
                {
                    errorcheck = "Yes";
                }
                if (checkDataExcedl.Affidavit != "NO" && str_uploadaffidavit.ContentLength == 0)
                {
                    errorcheck = "Yes";
                }

                if (str_uploadcast != null)
                {
                    if (Path.GetExtension(str_uploadcast.FileName).ToLower() != ".pdf" || str_uploadcast.ContentLength > 2097152)
                    {
                        errorcheck = "Yes";
                    }
                }
                if (str_uploadITI != null)
                {
                    if (Path.GetExtension(str_uploadITI.FileName).ToLower() != ".pdf" || str_uploadITI.ContentLength > 2097152)
                    {
                        errorcheck = "Yes";
                    }
                }
                if (str_uploadaffidavit != null)
                {
                    if (Path.GetExtension(str_uploadaffidavit.FileName).ToLower() != ".pdf" || str_uploadaffidavit.ContentLength > 2097152)
                    {
                        errorcheck = "Yes";
                    }
                }


                if (errorcheck == "No")
                {

                    if (str_upload10 != null)
                    {

                        var fileExtension = Path.GetExtension(str_upload10.FileName);
                        var AutoGenFileName = "10Result" + "-" + System.DateTime.Now.Ticks.ToString();
                        var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                        str_upload10.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Upload/ITI/" + newpath;
                        tbl_mst_ITIcandidatephotoupload.str_documentType = "10 Result";
                        tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                        tbl_mst_ITIcandidatephotoupload.isactive = true;
                        tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                        objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                        objContext.SaveChanges();


                    }

                    if (str_uploadITI != null)
                    {


                        var fileExtension = Path.GetExtension(str_uploadITI.FileName);
                        var AutoGenFileName = "ITIResult" + "-" + System.DateTime.Now.Ticks.ToString();
                        var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                        str_uploadITI.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Upload/ITI/" + newpath;
                        tbl_mst_ITIcandidatephotoupload.str_documentType = "ITI Result";
                        tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                        tbl_mst_ITIcandidatephotoupload.isactive = true;
                        tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                        objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                        objContext.SaveChanges();


                    }
                    if (str_uploadcast != null)
                    {


                        var fileExtension = Path.GetExtension(str_uploadcast.FileName);
                        var AutoGenFileName = "Cast" + "-" + System.DateTime.Now.Ticks.ToString();
                        var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                        str_uploadcast.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Upload/ITI/" + newpath;
                        tbl_mst_ITIcandidatephotoupload.str_documentType = "Cast";
                        tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                        tbl_mst_ITIcandidatephotoupload.isactive = true;
                        tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                        objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                        objContext.SaveChanges();


                    }
                    if (str_uploadaffidavit != null)
                    {


                        var fileExtension = Path.GetExtension(str_uploadaffidavit.FileName);
                        var AutoGenFileName = "Affidavit" + "-" + System.DateTime.Now.Ticks.ToString();
                        var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                        str_uploadaffidavit.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Upload/ITI/" + newpath;
                        tbl_mst_ITIcandidatephotoupload.str_documentType = "Affidavit";
                        tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                        tbl_mst_ITIcandidatephotoupload.isactive = true;
                        tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                        objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                        objContext.SaveChanges();

                    }

                    if (str_uploadRegistrationITI != null)
                    {


                        var fileExtension = Path.GetExtension(str_uploadRegistrationITI.FileName);
                        var AutoGenFileName = "RegistrationITI" + "-" + System.DateTime.Now.Ticks.ToString();
                        var path = Path.Combine(Server.MapPath("~/Upload/ITI/"), AutoGenFileName + fileExtension);
                        str_uploadRegistrationITI.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/Upload/ITI/" + newpath;
                        tbl_mst_ITIcandidatephotoupload.str_documentType = "RegistrationITI";
                        tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                        tbl_mst_ITIcandidatephotoupload.isactive = true;
                        tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                        objContext.tbl_mst_ITIcandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                        objContext.SaveChanges();

                    }

                    return RedirectToAction("Dashboard/" + id);

                }
                else
                {
                    ViewBag.error = "Please upload all the required documents only PDF with maximum size 2MB ";

                }
            }

            else
            {
                ViewBag.error = "Please upload all the required documents only PDF with maximum size 2MB ";

            }

            return View();
        }

        public ActionResult ViewUploadExtraDetails(int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)    
            {
                return RedirectToAction("Login/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);

            var checkPersonal = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var checkData = objContext.tbl_mst_ITIcandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            var checkDataExcedl = objContext.ITI_Upload_Candidates.Where(x => x.App_reg_no == checkPersonal.strApprenticeshipRegNo).ToList();
            if (checkData.Count() <= 2)
            {
                return RedirectToAction("Dashboard/" + id);
            }
            if (checkDataExcedl.Count() == 1)
            {
                ViewBag.ten = checkData.Where(x => x.str_documentType == "10 Result").FirstOrDefault().str_document;
                ViewBag.RegistrationITI = checkData.Where(x => x.str_documentType == "RegistrationITI").FirstOrDefault().str_document;

                if (checkDataExcedl.FirstOrDefault().Category != "UR")
                {
                    ViewBag.showCat = "Yes";
                    ViewBag.Cast = checkData.Where(x => x.str_documentType == "Cast").FirstOrDefault().str_document;
                }
                if (checkDataExcedl.FirstOrDefault().ITI != "NO")
                {
                    ViewBag.showITI = "Yes";
                    ViewBag.ITI = checkData.Where(x => x.str_documentType == "ITI Result").FirstOrDefault().str_document;
                }
                if (checkDataExcedl.FirstOrDefault().Affidavit != "NO")
                {
                    ViewBag.showAffidavit = "Yes";
                    ViewBag.Affidavit = checkData.Where(x => x.str_documentType == "Affidavit").FirstOrDefault().str_document;
                }
            }

            return View();
        }

        public ActionResult PrintApplication(int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }

            int pkId = Convert.ToInt32(Session["UserID"]);
            var AppliedPostDetails = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            ViewBag.Unit = objContext3.Units.Where(x => x.pk_intUnitId == AppliedPostDetails.fk_unitId).FirstOrDefault().strUnitName;
            ViewBag.Trade = AppliedPostDetails.strTradeName;
            var PersonalDetails = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

          //  var ReferencesDetails = objContext.tbl_mst_ITICandidateReferencesDetails.Where(x => x.fk_intcandidateid == pkId).FirstOrDefault();
            //if (ReferencesDetails != null && ReferencesDetails.isreference == "YES")
            //{
            //    ViewBag.isReference = ReferencesDetails.isreference;
            //    ViewBag.str_Name = ReferencesDetails.str_Name;
            //    ViewBag.str_Code = ReferencesDetails.str_Code;
            //    ViewBag.str_Designation = ReferencesDetails.str_Designation;
            //    ViewBag.str_Deptt = ReferencesDetails.str_Deptt;
            //    ViewBag.str_Relationship = ReferencesDetails.str_Relationship;
            //}

            ViewBag.finalSubmit = "No";

            if (PersonalDetails.strFinalSubmit == "Yes")
            {
                ViewBag.finalSubmit = "Yes";

            }
            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                ViewBag.finalSubmit = "Yes";
            }
            var educationAll = objContext.tbl_mst_ITICandidateQualification.Where(x => x.fk_CandidateId == pkId).ToList();

            string j = "";
            int i = 0;
            for (i = 0; i <= 2; i++)
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
                ViewData["Str_TotalMarks" + j] = educationAll[i].Str_TotalMarks;
                ViewData["Str_MarksObtained" + j] = educationAll[i].Str_MarksObtained;
                ViewData["Str_Marks" + j] = educationAll[i].Str_Marks;
                ViewData["Str_division" + j] = educationAll[i].Str_division;
                ViewData["StrRemarks" + j] = educationAll[i].StrRemarks;
                ViewData["Str_Affiliation" + j] = educationAll[i].Str_Affiliation;


            }

            var ApplicantUploadDetails = objContext.tbl_mst_ITIcandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            if (ApplicantUploadDetails.Count() >= 2)
            {
                ViewBag.Photo = ApplicantUploadDetails.Where(x => x.str_documentType == "Photo").FirstOrDefault().str_document.Replace("~", "");
                ViewBag.Signature = ApplicantUploadDetails.Where(x => x.str_documentType == "Signature").FirstOrDefault().str_document.Replace("~", "");
            }
            else
            {
                ViewBag.Photo = "/content/img/passport-photo1.png";
                ViewBag.Signature = "/content/img/signatureBox1.png";
            }
            return View(PersonalDetails);
        }

        [HttpPost]
        public ActionResult PrintApplication(tbl_mst_ITICandidatePersonalDetails tbl_mst_ITICandidatePersonalDetails, int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }
            if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
            {
                return RedirectToAction("Login/" + id);
            }
            //return RedirectToAction("Login/" + id);
            var updatePersonalDetails = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == tbl_mst_ITICandidatePersonalDetails.fk_CandidateId).FirstOrDefault();
            updatePersonalDetails.dtFinalSubmitDate = current;
            updatePersonalDetails.strFinalSubmit = "Yes";
            objContext.Entry(updatePersonalDetails).State = EntityState.Modified;
            objContext.SaveChanges();

            return RedirectToAction("Acknowledgement/" + id);
        }

        public ActionResult Acknowledgement(int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }

            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                return RedirectToAction("Dashboard/" + id);
            }

            else
            {
                int pkId = Convert.ToInt32(Session["UserID"]);
                var AppliedPostDetails = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                ViewBag.Unit = objContext3.Units.Where(x => x.pk_intUnitId == AppliedPostDetails.fk_unitId).FirstOrDefault().strUnitName;
                ViewBag.Trade = AppliedPostDetails.strTradeName;
                var PersonalDetails = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                if (PersonalDetails.strFinalSubmit != "Yes")
                {
                    return RedirectToAction("PrintApplication/" + id);
                }
                else
                {

                    var date = PersonalDetails.dt_entrydate.Value.ToString("ddMMyy");

                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString))
                    {
                        SqlParameter outPar1 = new SqlParameter("@newacknowledgementNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                        SqlParameter outPar2 = new SqlParameter("@newNoticeNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                        var cmd = new SqlCommand("sp_ITICandidateAcknowledgementReport", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@candidateId", SqlDbType.Int)).Value = pkId;//Pass the parameter
                        cmd.Parameters.Add(new SqlParameter("@noticeId", SqlDbType.Int)).Value = id;//Pass the parameter
                        cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.VarChar)).Value = date;//Pass the parameter
                        cmd.Parameters.Add(outPar1);
                        cmd.Parameters.Add(outPar2);
                        try
                        {
                            if (con.State != ConnectionState.Open)
                                con.Open();
                            cmd.ExecuteNonQuery();
                            ViewBag.AcknowledgementNo = cmd.Parameters["@newacknowledgementNo"].Value.ToString();
                            ViewBag.noticeNo = cmd.Parameters["@newNoticeNo"].Value.ToString();

                        }
                        finally
                        {

                            if (con.State != ConnectionState.Closed)
                                con.Close();
                        }

                    }


                    return View(PersonalDetails);
                }
            }
        }

        public ActionResult PrintApplicationAdmin(int? id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Index", "Home");
            }

            int? pkId = id;
            var AppliedPostDetails = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            id = AppliedPostDetails.fk_intAddId;
            ViewBag.Unit = objContext3.Units.Where(x => x.pk_intUnitId == AppliedPostDetails.fk_unitId).FirstOrDefault().strUnitName;
            ViewBag.Trade = AppliedPostDetails.strTradeName;
            var PersonalDetails = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

            //var ReferencesDetails = objContext.tbl_mst_ITICandidateReferencesDetails.Where(x => x.fk_intcandidateid == pkId).FirstOrDefault();
            //if (ReferencesDetails != null && ReferencesDetails.isreference == "YES")
            //{
            //    ViewBag.isReference = ReferencesDetails.isreference;
            //    ViewBag.str_Name = ReferencesDetails.str_Name;
            //    ViewBag.str_Code = ReferencesDetails.str_Code;
            //    ViewBag.str_Designation = ReferencesDetails.str_Designation;
            //    ViewBag.str_Deptt = ReferencesDetails.str_Deptt;
            //    ViewBag.str_Relationship = ReferencesDetails.str_Relationship;
            //}

            ViewBag.finalSubmit = "No";

            if (PersonalDetails.strFinalSubmit == "Yes")
            {
                ViewBag.finalSubmit = "Yes";

            }
            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate)
            {
                ViewBag.finalSubmit = "Yes";
            }
            var educationAll = objContext.tbl_mst_ITICandidateQualification.Where(x => x.fk_CandidateId == pkId).ToList();

            string j = "";
            int i = 0;
            for (i = 0; i <= 2; i++)
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
                ViewData["Str_TotalMarks" + j] = educationAll[i].Str_TotalMarks;
                ViewData["Str_MarksObtained" + j] = educationAll[i].Str_MarksObtained;
                ViewData["Str_Marks" + j] = educationAll[i].Str_Marks;
                ViewData["Str_division" + j] = educationAll[i].Str_division;
                ViewData["StrRemarks" + j] = educationAll[i].StrRemarks;
                ViewData["Str_Affiliation" + j] = educationAll[i].Str_Affiliation;


            }

            var ApplicantUploadDetails = objContext.tbl_mst_ITIcandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            if (ApplicantUploadDetails.Count() >= 2)
            {
                ViewBag.Photo = ApplicantUploadDetails.Where(x => x.str_documentType == "Photo").FirstOrDefault().str_document.Replace("~", "");
                ViewBag.Signature = ApplicantUploadDetails.Where(x => x.str_documentType == "Signature").FirstOrDefault().str_document.Replace("~", "");
            }
            else
            {
                ViewBag.Photo = "/content/img/passport-photo1.png";
                ViewBag.Signature = "/content/img/signatureBox1.png";
            }
            return View(PersonalDetails);
        }

        public ActionResult UploadDetailsAdmin(int? id)
        {
           if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }

            int? pkId = id;
            ViewBag.hdCastecondition = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault().strCategory;
            var ITIPassingYear = objContext.tbl_mst_ITICandidateQualification.Where(x => x.Str_exampassed == "ITI" && x.fk_CandidateId == pkId).FirstOrDefault().Str_passingyear;
            ViewBag.hdAffidavit = Convert.ToDateTime(ITIPassingYear).Year;

            var Referencedetails = objContext.tbl_mst_ITICandidateReferencesDetails.Where(x => x.fk_intcandidateid == pkId).FirstOrDefault();
            if (Referencedetails != null)
            {
             //   ViewBag.hdReferencecondition = Referencedetails.isreference;
            }


            var uploadDetails = objContext.tbl_mst_ITIcandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            if (uploadDetails.Count() >= 2)
            {
                ViewBag.Photo = uploadDetails.Where(x => x.str_documentType == "Photo").FirstOrDefault().str_document.Replace("~", "");
                ViewBag.Signature = uploadDetails.Where(x => x.str_documentType == "Signature").FirstOrDefault().str_document.Replace("~", "");

                ViewBag.Upload10 = uploadDetails.Where(x => x.str_documentType == "10 Result").FirstOrDefault().str_document.Replace("~", "");
                ViewBag.UploadITI = uploadDetails.Where(x => x.str_documentType == "ITI Result").FirstOrDefault().str_document.Replace("~", "");



                if (uploadDetails.Where(x => x.str_documentType == "12 Result").Count() > 0)
                {
                    ViewBag.Upload12 = uploadDetails.Where(x => x.str_documentType == "12 Result").FirstOrDefault().str_document.Replace("~", "");
                }
                if (uploadDetails.Where(x => x.str_documentType == "Cast").Count() > 0)
                {
                    ViewBag.UploadCast = uploadDetails.Where(x => x.str_documentType == "Cast").FirstOrDefault().str_document.Replace("~", "");
                }
                if (uploadDetails.Where(x => x.str_documentType == "Affidavit").Count() > 0)
                {
                    ViewBag.UploadAffidavit = uploadDetails.Where(x => x.str_documentType == "Affidavit").FirstOrDefault().str_document.Replace("~", "");
                }

                if (uploadDetails.Where(x => x.str_documentType == "RegistrationITI").Count() > 0)
                {
                    ViewBag.UploadRegistrationITI = uploadDetails.Where(x => x.str_documentType == "RegistrationITI").FirstOrDefault().str_document.Replace("~", "");
                }

                if (uploadDetails.Where(x => x.str_documentType == "Reference").Count() > 0)
                {
                    ViewBag.UploadReference = uploadDetails.Where(x => x.str_documentType == "Reference").FirstOrDefault().str_document.Replace("~", "");
                }
            }
            else
            {
                ViewBag.Photo = "/content/img/passport-photo1.png";
                ViewBag.Signature = "/content/img/signatureBox1.png";
            }

            return View();
        }

        public ActionResult uploaditifiledetails(int? id)
        {
           if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }
            var uploadDetails = objContext.tbl_mst_ITIcandidatephotoupload.Where(x => x.fk_intcandidateid == id).ToList();
            return View(uploadDetails);
        }

        public ActionResult AcknowledgementAdmin(int? id)
        {
           if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }

            int? pkId = id;
            var AppliedPostDetails = objContext.tbl_mst_ITIAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            ViewBag.Unit = objContext3.Units.Where(x => x.pk_intUnitId == AppliedPostDetails.fk_unitId).FirstOrDefault().strUnitName;
            ViewBag.Trade = AppliedPostDetails.strTradeName;
            var PersonalDetails = objContext.tbl_mst_ITICandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            if (PersonalDetails.strFinalSubmit != "Yes")
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            else
            {
                return View(PersonalDetails);
            }
        }

        public ActionResult OfferLetter(int id)
        {
           if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId"]) != id)
            {
                return RedirectToAction("Login/" + id);
            }
            return RedirectToAction("Login/" + id);
            string email = Convert.ToString(Session["strEmail"]);
            var OfferLetter = objContext.tbl_mst_ITIcandidateOfferLetter.Where(x => x.EmailId == email);
            if (OfferLetter.ToList().Count() > 0)
            {
                return View(OfferLetter.FirstOrDefault());
            }
            else
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }

    }
}
