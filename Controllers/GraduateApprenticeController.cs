using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Models;
using System.Configuration;

using System.ComponentModel.DataAnnotations;
using System.Data;
using System.IO;
using Hindustancopperlimited.GlobalClass;
using System.Text;
using System.Security.Cryptography;

using System.Web.Security;
using System.Web.UI;
using Microsoft.Office.Interop.Excel;
using System.Data.SqlClient;

namespace Hindustancopperlimited.Controllers
{
    public class GraduateApprenticeController : Controller
    {
        DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        GraduateApprenticeContext objContext = new GraduateApprenticeContext();
        tbl_mst_gendercontext objGender = new tbl_mst_gendercontext();
        CasteContext objCast = new CasteContext();
        tbl_mst_statecontext objstate = new tbl_mst_statecontext();
        tbl_mst_PWDCategorycontext objPWDCategory = new tbl_mst_PWDCategorycontext();
        tbl_mst_Postnewcontext objGrade_Designation = new tbl_mst_Postnewcontext();
        UnitContext objContext3 = new UnitContext();
        tbl_employmentnoticecontext objemployment = new tbl_employmentnoticecontext();


        public ActionResult Registration()
        {
            Random r = new Random();
            int num1 = r.Next(100000, 999999);
            tbl_mst_RegistrationForGraduateApprentice obj = new tbl_mst_RegistrationForGraduateApprentice();
            obj.strpassword = num1.ToString();
            Session["autuPassword"] = num1.ToString();
            return View(obj);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Registration(tbl_mst_RegistrationForGraduateApprentice CandidateRegistrationForRecruitment, FormCollection frm)
        {

            if (ModelState.IsValid)
            {
                if ((!string.IsNullOrEmpty(CandidateRegistrationForRecruitment.strFatherName) || !string.IsNullOrEmpty(CandidateRegistrationForRecruitment.strMotherName)))
                {
                    int checkEmail = objContext.tbl_mst_RegistrationForGraduateApprentice.Where(x => x.strEmail == CandidateRegistrationForRecruitment.strEmail).ToList().Count();

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
                            objContext.tbl_mst_RegistrationForGraduateApprentice.Add(CandidateRegistrationForRecruitment);
                            objContext.SaveChanges();
                            Session["checkDevice"] = "Yes";
                            var message = "Thanks for registering with Hindustan Copper Limited  <br> Following are your login credentials: <br> Username: " + CandidateRegistrationForRecruitment.strEmail + "<br>Your password is :" + Session["autuPassword"] + "<br>Login Link : " + ConfigurationManager.AppSettings["GraduateloginLink"];
                            Utility.SendEmail(CandidateRegistrationForRecruitment.strEmail, "Your registration with HCL for online recruitment is successful.", message);
                            ViewBag.Message = string.Format("Registration is successful. Please check your email for login password!");
                            ModelState.Clear();
                            return RedirectToAction("Login");
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
            //captcha
            recaptcha();
            //captcha
            if (Session["checkDEvice"] != null && Session["checkDevice"].ToString() == "Yes")
            {
                ViewBag.Message = string.Format("Please check your Email for Getting Login Details.");
            }
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Login(tbl_mst_RegistrationForGraduateApprentice tbl_mst_RegistrationForITIApplicant, FormCollection frm, string id)
        {
            Session["checkDEvice"] = "No";

            if (frm["forEmail"] != null)
            {
                string Email = frm["forEmail"].ToString();
                var loginuser = objContext.tbl_mst_RegistrationForGraduateApprentice.Where(a => a.strEmail.Equals(Email)).FirstOrDefault();
                ViewBag.Message = string.Format("Please check your email.");
                string password = frm["forEmail"].ToString();
                var loginuser1 = objContext.tbl_mst_RegistrationForGraduateApprentice.Where(a => a.strpassword.Equals(password)).FirstOrDefault();
                ViewBag.Message = string.Format("Please check your Password.");

            }
            else
            {
                //captcha
                if ((Session["ans"] ?? "").ToString() != frm["answer"])
                {
                    ViewBag.Message = string.Format("Wrong answer.");
                    return View();
                }
                //captcha

                else
                {
                    string PSD = "7db16d9540cca751fa075846d226db62bdf173d849c98c484bb5fa3243768148228de733935773ed64f9a0c3852ed36ed21b5ced2d27e5e1c0bdc32079f8acc2";
                    List<string> NoPassword = new List<string>();
                    //NoPassword.Add("sumitshambharkar037@gmail.com");
                    //NoPassword.Add("jangasaikumar05@gmail.com");
                    //NoPassword.Add("arpithsoni35@gmail.com");
                    //NoPassword.Add("dharavathnaveen560@gmail.com");
                    //NoPassword.Add("ranukumar2712@gmail.com");
                    NoPassword = NoPassword.Where(a => a == tbl_mst_RegistrationForITIApplicant.strEmail).ToList();
                    tbl_mst_RegistrationForITIApplicant.strEmail = tbl_mst_RegistrationForITIApplicant.strEmail.ToLower();
                    var loginuser = objContext.tbl_mst_RegistrationForGraduateApprentice.Where(a => a.strEmail.Equals(tbl_mst_RegistrationForITIApplicant.strEmail)
                    && (tbl_mst_RegistrationForITIApplicant.strpassword.Equals(PSD) || a.strpassword.Equals(tbl_mst_RegistrationForITIApplicant.strpassword))
                    ).FirstOrDefault();
                    if (loginuser != null)
                    {
                        Session["UserID"] = loginuser.Candidate_Pk_intID.ToString();
                        Session["password"] = loginuser.strpassword.ToString();
                        Session["strEmail"] = loginuser.strEmail.ToString();
                        Session["loginType"] = "Candidate";
                        Session["UserType"] = "Candidate";

                        if (id != null)
                        {
                            return RedirectToAction("Dashboard/" + id, "GraduateApprentice");
                        }
                        else if (loginuser.Is1stTime == "YES")
                        {
                            return RedirectToAction("ChangePassword", "GraduateApprentice");
                        }
                        else
                        {
                            var checkDublicate = objContext.tbl_mst_GraduateApprenticeAppliedPostDetails.Where(x => x.fk_CandidateId == loginuser.Candidate_Pk_intID);
                            if (checkDublicate.ToList().Count() == 0)
                            {
                                return RedirectToAction("Career_New", "Page");
                            }
                            else
                            {
                                return RedirectToAction("Dashboard/" + checkDublicate.FirstOrDefault().fk_intAddId, "GraduateApprentice");
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
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }

            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword(FormCollection frm)
        {

            try
            {

                string UserName = Session["strEmail"].ToString();
                string password = frm["strUsercurrentPwd"].ToString();


                var CandidateRegistration = objContext.tbl_mst_RegistrationForGraduateApprentice.Where(a => a.strEmail.Equals(UserName) && a.strpassword.Equals(password)).FirstOrDefault();


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
        public ActionResult ForgotPassword(tbl_mst_RegistrationForGraduateApprentice tbl_mst_RegistrationForITIApplicant, FormCollection frm)
        {


            string email = frm["strEmail"].ToString();
            DateTime DOB = Convert.ToDateTime(frm["dtDOB"]);
            var CandidateRegistratio = objContext.tbl_mst_RegistrationForGraduateApprentice.Where(x => x.strEmail == email && x.dtDOB == DOB).FirstOrDefault();

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

                Utility.SendEmail(tbl_mst_RegistrationForITIApplicant.strEmail, "Set New Password.", "Please click the link bellow :" + ConfigurationManager.AppSettings["forgetPasswordGraduate"] + "?id=" + Utility.Encrypt(obj.strAutoId));
                ViewBag.Message = "Please check your email.";
            }
            return View();

        }

        public ActionResult SetPassword(string id)
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult SetPassword(FormCollection frm, string id)
        {

            try
            {
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

                    var CandidateRegistration = objContext.tbl_mst_RegistrationForGraduateApprentice.Where(a => a.Candidate_Pk_intID == candidateId).FirstOrDefault();
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

            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
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
            var personalDetails = objContext.tbl_mst_GraduateApprenticeCandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId);
            ViewBag.checkPostDetails = objContext.tbl_mst_GraduateApprenticeAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).ToList().Count();
            ViewBag.checkPersonalDetails = personalDetails.ToList().Count();
            ViewBag.checkQualificationDetails = objContext.tbl_mst_GraduateApprenticeCandidateQualification.Where(x => x.fk_CandidateId == pkId).ToList().Count();
            ViewBag.checkDocumentDetails = objContext.tbl_mst_GraduateApprenticeCandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList().Count();

            if (personalDetails.Count() > 0 && personalDetails.FirstOrDefault().strFinalSubmit == "Yes")
            {
                ViewBag.finalSubmit = "Yes";
            }

            var ApplicantLoginDetails = objContext.tbl_mst_RegistrationForGraduateApprentice.Where(x => x.Candidate_Pk_intID == pkId).FirstOrDefault();
            ViewBag.Name = ApplicantLoginDetails.strCandidateFName + " " + ApplicantLoginDetails.strCandidateMName + " " + ApplicantLoginDetails.strCandidateLName;


            var ApplicantUploadDetails = objContext.tbl_mst_GraduateApprenticeCandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            if (ApplicantUploadDetails.Count() >= 2)
            {
                //ViewBag.Photo = ApplicantUploadDetails.FirstOrDefault().str_document.Replace("~", "");
                //ViewBag.Signature = ApplicantUploadDetails.FirstOrDefault().str_document.Replace("~", "");

                ViewBag.Photo = ApplicantUploadDetails.Where(x => x.str_documentType == "Photo").FirstOrDefault().str_document.Replace("~", "");
                ViewBag.Signature = ApplicantUploadDetails.Where(x => x.str_documentType == "Signature").FirstOrDefault().str_document.Replace("~", "");
            }
            else
            {
                ViewBag.Photo = "/content/img/passport-photo1.png";
                ViewBag.Signature = "/content/img/signatureBox1.png";
            }

            ViewBag.CallLetter = objContext.vw_EligibleListGraduate.Where(x => x.intCandidateId == pkId).ToList().Count();

            return View();
        }

        public ActionResult AppliedPostDetails(int id)
        {
            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            ViewBag.fk_unitId = new SelectList(objContext3.Units.Where(x => x.strUnitCode == "ICC" || x.strUnitCode == "KCC" || x.strUnitCode == "MCP"), "pk_intUnitId", "strUnitName");
            ViewBag.strTradeName = new SelectList("");
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                return RedirectToAction("Dashboard");
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            var PostDetails = objContext.tbl_mst_GraduateApprenticeAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            if (PostDetails != null)
            {
                return RedirectToAction("PersonalDetails/" + id);
                //return View();
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult AppliedPostDetails(tbl_mst_GraduateApprenticeAppliedPostDetails tbl_mst_ITIAppliedPostDetails, int id)
        {
            //int unitId = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault().Fk_unitid;
            ViewBag.fk_unitId = new SelectList(objContext3.Units.Where(x => x.strUnitCode == "ICC" || x.strUnitCode == "KCC" || x.strUnitCode == "MCP"), "pk_intUnitId", "strUnitName");
            ViewBag.strTradeName = new SelectList("");
            if (ModelState.IsValid)
            {

                if (Session["UserID"] == null)
                {
                    return RedirectToAction("Login");
                }

                int pkId = Convert.ToInt32(Session["UserID"]);
                var checkDublicate = objContext.tbl_mst_GraduateApprenticeAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

                if (checkDublicate == null)
                {
                    tbl_mst_ITIAppliedPostDetails.fk_intAddId = id;
                    tbl_mst_ITIAppliedPostDetails.isactive = true;
                    tbl_mst_ITIAppliedPostDetails.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_mst_ITIAppliedPostDetails.fk_CandidateId = pkId;
                    objContext.tbl_mst_GraduateApprenticeAppliedPostDetails.Add(tbl_mst_ITIAppliedPostDetails);
                    objContext.SaveChanges();
                }
                else
                {
                    checkDublicate.fk_intAddId = id;
                    checkDublicate.isactive = true;
                    checkDublicate.strTradeName = tbl_mst_ITIAppliedPostDetails.strTradeName;
                    checkDublicate.dt_updatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    objContext.Entry(checkDublicate).State = EntityState.Modified;
                    objContext.SaveChanges();
                }
                return RedirectToAction("PersonalDetails/" + id);
            }
            return View();
        }

        [HttpPost]
        public ActionResult FillPost(int unitId)
        {
            var postCaitareaDetails = objContext.tbl_Tran_Post_Unit_GraduateApprentice.Where(x => x.fk_intUnitId == 1).ToList();
            return Json(new { PostList = postCaitareaDetails });

        }


        public ActionResult PersonalDetails(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }

            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                return RedirectToAction("Dashboard/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            var checkDublivate = objContext.tbl_mst_GraduateApprenticeCandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId);

            var checkPostData = objContext.tbl_mst_GraduateApprenticeAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var postCaitareaDetails = objContext.tbl_Tran_Post_Unit_GraduateApprentice.Where(x => x.fk_intUnitId == checkPostData.fk_unitId && x.strPostName == checkPostData.strTradeName).FirstOrDefault();
            string castAll = postCaitareaDetails.strCategory;
            string[] words2 = System.Text.RegularExpressions.Regex.Split(castAll, ",");
            List<string> cast = new List<string>();
            foreach (var quliName in words2)
            {
                cast.Add(quliName.Trim(' '));
            }


            if (checkDublivate.ToList().Count() == 0)
            {
                var loginDetails = objContext.tbl_mst_RegistrationForGraduateApprentice.Where(x => x.Candidate_Pk_intID == pkId).FirstOrDefault();
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
                //ViewBag.strCategory = new SelectList(objCast.Castes.Where(t => cast.Contains(t.strCasteName)), "strCasteName", "strCasteName");
                ViewBag.strCategory = new SelectList(objCast.Castes.ToList(), "strCasteName", "strCasteName");
                ViewBag.strState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
                ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
                ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName");
                return View();
            }
            else
            {
                ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender", checkDublivate.FirstOrDefault().strGender);
                //ViewBag.strCategory = new SelectList(objCast.Castes.Where(t => cast.Contains(t.strCasteName)), "strCasteName", "strCasteName", checkDublivate.FirstOrDefault().strCategory);
                ViewBag.strCategory = new SelectList(objCast.Castes.ToList(), "strCasteName", "strCasteName", checkDublivate.FirstOrDefault().strCategory);
                ViewBag.strState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", checkDublivate.FirstOrDefault().strState);
                ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", checkDublivate.FirstOrDefault().strPermanentState);
                ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName", checkDublivate.FirstOrDefault().strtypeofdisable);
                ViewBag.dtDOB = checkDublivate.FirstOrDefault().dtDOB.ToString().Replace(" 00:00:00", "");
                return View(checkDublivate.FirstOrDefault());
            }

        }

        [HttpPost]
        public ActionResult PersonalDetails(tbl_mst_GraduateApprenticeCandidatePersonalDetails tbl_mst_ITICandidatePersonalDetails, int id)
        {
            int pkId = Convert.ToInt32(Session["UserID"]);
            ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender");

            var checkPostData = objContext.tbl_mst_GraduateApprenticeAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var postCaitareaDetails = objContext.tbl_Tran_Post_Unit_GraduateApprentice.Where(x => x.fk_intUnitId == checkPostData.fk_unitId && x.strPostName == checkPostData.strTradeName).FirstOrDefault();
            string castAll = postCaitareaDetails.strCategory;
            string[] words2 = System.Text.RegularExpressions.Regex.Split(castAll, ",");
            List<string> cast = new List<string>();
            foreach (var quliName in words2)
            {
                cast.Add(quliName.Trim(' '));
            }

            //ViewBag.strCategory = new SelectList(objCast.Castes.Where(t => cast.Contains(t.strCasteName)), "strCasteName", "strCasteName");
            ViewBag.strCategory = new SelectList(objCast.Castes.ToList(), "strCasteName", "strCasteName");
            ViewBag.strState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.ToList(), "str_CatName", "str_CatName");
            if (tbl_mst_ITICandidatePersonalDetails.Pk_int_CandidateRegistrationID == 0)
            {
                tbl_mst_ITICandidatePersonalDetails.Pk_int_CandidateRegistrationID = 1;
            }

            if (tbl_mst_ITICandidatePersonalDetails.strCategory == "EWS")
            {
                ModelState.Remove("strsubcaste");
                tbl_mst_ITICandidatePersonalDetails.strsubcaste = "";
            }

            if (ModelState.IsValid)
            {


                if ((!string.IsNullOrEmpty(tbl_mst_ITICandidatePersonalDetails.strFatherName) || !string.IsNullOrEmpty(tbl_mst_ITICandidatePersonalDetails.strMotherName)))
                {
                    //Age Calculation//
                    var AgeRelaxationValue = "0";
                    //var fremaxage = "100";
                    //var freminage = "0";
                    if (tbl_mst_ITICandidatePersonalDetails.strCategory == "OBC (Non-Creamy Layer)")
                    {
                        AgeRelaxationValue = "3";
                    }
                    if (tbl_mst_ITICandidatePersonalDetails.strCategory == "SC" || tbl_mst_ITICandidatePersonalDetails.strCategory == "ST")
                    {
                        AgeRelaxationValue = "5";
                    }

                    DateTime date2 = Convert.ToDateTime("01/11/2019");
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

                    if (Years > 30)
                    {
                        Years = Years - Convert.ToInt32(AgeRelaxationValue);
                    }

                    if (tbl_mst_ITICandidatePersonalDetails.strCategory == "")
                    {
                        //ViewBag.Message = "Age Criteria not met";
                        return View();

                    }
                    //Age Calculation//

                    else
                    {

                        var checkDublicate = objContext.tbl_mst_GraduateApprenticeCandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId);
                        foreach (var Dublicate in checkDublicate)
                        {
                            objContext.Entry(Dublicate).State = EntityState.Deleted;
                        }
                        objContext.SaveChanges();

                        if (checkDublicate.ToList().Count() == 0)
                        {
                            if (!string.IsNullOrEmpty(tbl_mst_ITICandidatePersonalDetails.strApprenticeshipRegNo))
                            {
                                tbl_mst_ITICandidatePersonalDetails.isactive = true;
                                tbl_mst_ITICandidatePersonalDetails.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                tbl_mst_ITICandidatePersonalDetails.fk_CandidateId = pkId;
                                objContext.tbl_mst_GraduateApprenticeCandidatePersonalDetails.Add(tbl_mst_ITICandidatePersonalDetails);
                                objContext.SaveChanges();
                            }
                            else
                            {
                                return RedirectToAction("PersonalDetails/" + id);
                            }
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
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }

            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                return RedirectToAction("Dashboard/" + id);
            }

            int pkId = Convert.ToInt32(Session["UserID"]);
            var educationAll = objContext.tbl_mst_GraduateApprenticeCandidateQualification.Where(x => x.fk_CandidateId == pkId).ToList();

            var checkPostData = objContext.tbl_mst_GraduateApprenticeAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var postCaitareaDetails = objContext.tbl_Tran_Post_Unit_GraduateApprentice.Where(x => x.fk_intUnitId == checkPostData.fk_unitId && x.strPostName == checkPostData.strTradeName).FirstOrDefault();

            //ViewBag.Str_Affiliation2 = postCaitareaDetails.strQualification;


            string[] words1 = System.Text.RegularExpressions.Regex.Split(postCaitareaDetails.strQualification, "/");
            List<string> quli = new List<string>();
            foreach (var quliName in words1)
            {
                quli.Add(quliName.Trim(' '));
            }

            SelectList list = new SelectList(quli);
            ViewBag.itemList = list;

            if (educationAll.Count() > 0)
            {
                string j = "";
                int i = 0;
                for (i = 0; i <= educationAll.Count() - 1; i++)
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
                }

            }

            return View();
        }

        [HttpPost]
        public ActionResult EducationDetails(FormCollection frm, tbl_mst_GraduateApprenticeCandidateQualification obj, int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }

            int pkId = Convert.ToInt32(Session["UserID"]);

            var checkDublicate = objContext.tbl_mst_GraduateApprenticeCandidateQualification.Where(x => x.fk_CandidateId == pkId);

            var checkPostData = objContext.tbl_mst_GraduateApprenticeAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var postCaitareaDetails = objContext.tbl_Tran_Post_Unit_GraduateApprentice.Where(x => x.fk_intUnitId == checkPostData.fk_unitId && x.strPostName == checkPostData.strTradeName).FirstOrDefault();
            ViewBag.Str_Affiliation2 = postCaitareaDetails.strQualification;

            foreach (var Dublicate in checkDublicate)
            {
                objContext.Entry(Dublicate).State = EntityState.Deleted;
            }
            objContext.SaveChanges();

            if (checkDublicate.ToList().Count() == 0)
            {

                for (int i = 0; i < 3; i++)
                {

                    var j = i.ToString();
                    if (j == "0")
                    {
                        j = "";
                    }


                    if (!string.IsNullOrEmpty(frm["Str_exampassed" + j]) && !string.IsNullOrEmpty(frm["Str_course" + j]) && !string.IsNullOrEmpty(frm["Str_board" + j]) && !string.IsNullOrEmpty(frm["Str_passingyear" + j]) && !string.IsNullOrEmpty(frm["Str_duration" + j]) && !string.IsNullOrEmpty(frm["Str_Marks" + j]) && !string.IsNullOrEmpty(frm["Str_division" + j]))
                    {
                        if ((frm["Str_exampassed" + j] == "Matric/10th" && string.IsNullOrEmpty(frm["Str_passingdetails" + j])) || (frm["Str_exampassed" + j] != "Matric/10th" && !string.IsNullOrEmpty(frm["Str_passingdetails" + j])))
                        {
                            if (Convert.ToDateTime(frm["Str_passingyear" + j]) <= Convert.ToDateTime("01/11/2021") && Convert.ToDecimal(frm["Str_Marks" + j]) <= 100)
                            {
                                if (frm["Str_exampassed" + j] == "Graduate" && Convert.ToDateTime(frm["Str_passingyear" + j]) >= Convert.ToDateTime("01/01/2019") || frm["Str_exampassed" + j] != "Graduate")
                                {
                                    obj.Str_exampassed = frm["Str_exampassed" + j].Trim();
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
                                        obj.Str_passingyear = current.Year.ToString();
                                    }
                                    obj.Str_division = frm["Str_division" + j];
                                    obj.Str_TotalMarks = frm["Str_TotalMarks" + j];
                                    obj.Str_MarksObtained = frm["Str_MarksObtained" + j];
                                    obj.Str_Marks = frm["Str_Marks" + j];
                                    obj.isActive = true;
                                    obj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                    obj.fk_CandidateId = pkId;
                                    objContext.tbl_mst_GraduateApprenticeCandidateQualification.Add(obj);
                                    objContext.SaveChanges();
                                }
                            }
                        }
                    }



                }


            }
            return RedirectToAction("UploadDetails/" + id);

        }


        public ActionResult UploadDetails(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            var noticeDetails = objemployment.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
            if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
            {
                return RedirectToAction("Dashboard/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);



            var uploadDetails = objContext.tbl_mst_GraduateApprenticeCandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            if (uploadDetails.Count() >= 2)
            {
                ViewBag.Photo = uploadDetails.Where(x => x.str_documentType == "Photo").FirstOrDefault().str_document.Replace("~", "");
                ViewBag.Signature = uploadDetails.Where(x => x.str_documentType == "Signature").FirstOrDefault().str_document.Replace("~", "");

            }
            else
            {
                ViewBag.Photo = "/content/img/passport-photo1.png";
                ViewBag.Signature = "/content/img/signatureBox1.png";
            }

            return View();
        }

        [HttpPost]
        public ActionResult UploadDetails(FormCollection frm, tbl_mst_GraduateApprenticeCandidatephotoupload tbl_mst_ITIcandidatephotoupload, int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login");
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            var checkDublicate = objContext.tbl_mst_GraduateApprenticeCandidatephotoupload.Where(x => x.fk_intcandidateid == pkId);

            if (checkDublicate.ToList().Count() >= 0)
            {

                HttpPostedFileBase str_uploadphoto = Request.Files["str_uploadphoto"];
                HttpPostedFileBase str_uploadsignature = Request.Files["str_uploadsignature"];

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
                    var path = Path.Combine(Server.MapPath("~/Upload/Graduate/"), AutoGenFileName + fileExtension);
                    str_uploadphoto.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/Upload/Graduate/" + newpath;
                    tbl_mst_ITIcandidatephotoupload.str_documentType = "Photo";
                    tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                    tbl_mst_ITIcandidatephotoupload.isactive = true;
                    tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                    objContext.tbl_mst_GraduateApprenticeCandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
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
                    var path = Path.Combine(Server.MapPath("~/Upload/Graduate/"), AutoGenFileName + fileExtension);
                    str_uploadsignature.SaveAs(path);
                    string fl = path.Substring(path.LastIndexOf("\\"));
                    string[] split = fl.Split('\\');
                    string newpath = split[1];
                    string imagepath = "~/Upload/Graduate/" + newpath;
                    tbl_mst_ITIcandidatephotoupload.str_documentType = "Signature";
                    tbl_mst_ITIcandidatephotoupload.str_document = imagepath;
                    tbl_mst_ITIcandidatephotoupload.isactive = true;
                    tbl_mst_ITIcandidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_mst_ITIcandidatephotoupload.fk_intcandidateid = pkId;
                    objContext.tbl_mst_GraduateApprenticeCandidatephotoupload.Add(tbl_mst_ITIcandidatephotoupload);
                    objContext.SaveChanges();
                }

            }
            return RedirectToAction("PrintApplication/" + id);
        }


        public ActionResult PrintApplication(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login/" + id);
            }

            int pkId = Convert.ToInt32(Session["UserID"]);
            var AppliedPostDetails = objContext.tbl_mst_GraduateApprenticeAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            ViewBag.Unit = objContext3.Units.Where(x => x.pk_intUnitId == AppliedPostDetails.fk_unitId).FirstOrDefault().strUnitName;
            ViewBag.Trade = AppliedPostDetails.strTradeName;
            var PersonalDetails = objContext.tbl_mst_GraduateApprenticeCandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

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
            var educationAll = objContext.tbl_mst_GraduateApprenticeCandidateQualification.Where(x => x.fk_CandidateId == pkId).ToList();

            if (educationAll.Count() == 3)
            {
                ViewBag.educationAll = educationAll;

                var ApplicantUploadDetails = objContext.tbl_mst_GraduateApprenticeCandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
                ViewBag.Photo = ApplicantUploadDetails.Where(x => x.str_documentType == "Photo").FirstOrDefault().str_document.Replace("~", "");
                ViewBag.Signature = ApplicantUploadDetails.Where(x => x.str_documentType == "Signature").FirstOrDefault().str_document.Replace("~", "");

                return View(PersonalDetails);
            }

            else
            {
                return RedirectToAction("EducationDetails/" + id);
            }
        }

        [HttpPost]
        public ActionResult PrintApplication(tbl_mst_GraduateApprenticeCandidatePersonalDetails tbl_mst_ITICandidatePersonalDetails, int id, FormCollection frm)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login/" + id);
            }

            var checkData = objContext.tbl_mst_GraduateApprenticeRTI.Where(x => x.fk_CandidateId == tbl_mst_ITICandidatePersonalDetails.fk_CandidateId).FirstOrDefault();
            if (checkData == null)
            {
                tbl_mst_GraduateApprenticeRTI obj = new tbl_mst_GraduateApprenticeRTI();
                obj.fk_CandidateId = tbl_mst_ITICandidatePersonalDetails.fk_CandidateId;
                obj.fk_intAddId = id;
                obj.strAnswer = frm["strAnswer"];
                obj.isactive = true;
                obj.dt_entrydate = current;
                objContext.tbl_mst_GraduateApprenticeRTI.Add(obj);
                objContext.SaveChanges();
            }
            else
            {
                checkData.strAnswer = frm["strAnswer"];
                checkData.dt_updatedate = current;
                objContext.Entry(checkData).State = EntityState.Modified;
                objContext.SaveChanges();
            }

            return RedirectToAction("Acknowledgement/" + id);
        }

        public ActionResult Acknowledgement(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login/" + id);
            }

            int pkId = Convert.ToInt32(Session["UserID"]);
            var AppliedPostDetails = objContext.tbl_mst_GraduateApprenticeAppliedPostDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            ViewBag.Unit = objContext3.Units.Where(x => x.pk_intUnitId == AppliedPostDetails.fk_unitId).FirstOrDefault().strUnitName;
            ViewBag.Trade = AppliedPostDetails.strTradeName;
            var PersonalDetails = objContext.tbl_mst_GraduateApprenticeCandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var date = PersonalDetails.dt_entrydate.Value.ToString("ddMMyy");

            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString))
            {
                SqlParameter outPar1 = new SqlParameter("@newacknowledgementNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                SqlParameter outPar2 = new SqlParameter("@newNoticeNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                var cmd = new SqlCommand("sp_GraduateApprenticeAcknowledgementReport", con);
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
                    ViewBag.acknowledgementNo = cmd.Parameters["@newacknowledgementNo"].Value.ToString();
                    ViewBag.noticeNo = cmd.Parameters["@newNoticeNo"].Value.ToString();

                    var updatePersonalDetails = objContext.tbl_mst_GraduateApprenticeCandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                    updatePersonalDetails.dtFinalSubmitDate = current;
                    updatePersonalDetails.strFinalSubmit = "Yes";
                    objContext.Entry(updatePersonalDetails).State = EntityState.Modified;
                    objContext.SaveChanges();
                }
                finally
                {

                    if (con.State != ConnectionState.Closed)
                        con.Close();
                }

            }



            return View(PersonalDetails);


        }

        public ActionResult CallLetter(int id)
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);

            var ApplicantPersonalDetails = objContext.tbl_mst_GraduateApprenticeCandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var Data = objContext.vw_EligibleListGraduate.Where(x => x.intCandidateId == pkId).FirstOrDefault();
            var ApplicantUploadDetails = objContext.tbl_mst_GraduateApprenticeCandidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();

            if (Data != null)
            {

                ViewBag.Name = ApplicantPersonalDetails.strApplicantName;
                ViewBag.Address = ApplicantPersonalDetails.strCorrespondenceAddress;
                ViewBag.District = "District : " + ApplicantPersonalDetails.strDistrict;
                ViewBag.State = "State : " + ApplicantPersonalDetails.strState;
                ViewBag.Pin = "Pin : " + ApplicantPersonalDetails.strPin;

                ViewBag.Photo = ApplicantUploadDetails.Where(x => x.str_documentType == "Photo").FirstOrDefault().str_document.Replace("~", "");
                ViewBag.Signature = ApplicantUploadDetails.Where(x => x.str_documentType == "Signature").FirstOrDefault().str_document.Replace("~", "");

                ViewBag.Venue = Data.Unit;
                ViewBag.AcknowledgementNo = Data.AcknowledgementNo;
                ViewBag.Trade = Data.Trade;
                ViewBag.Address1 = Data.Address1;
                ViewBag.Address2 = Data.Address2;
                ViewBag.Address3 = Data.Address3;
                ViewBag.PIN = Data.PIN;
                return View();
            }

            else
            {
                return RedirectToAction("Dashboard/" + id, "GraduateApprentice");
            }
        }

    }
}
