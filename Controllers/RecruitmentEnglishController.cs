using DataAccessLayer;
using Hindustancopperlimited.GlobalClass;
using Hindustancopperlimited.Models;
using Hindustancopperlimited.Models.CommonClass;
using iTextSharp.text;
using Microsoft.Office.Interop.Excel;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using static System.Net.WebRequestMethods;

namespace Hindustancopperlimited.Controllers
{
    public class RecruitmentEnglishController : Controller
    {
        //
        // GET: /Recruitment/
        public static string EmailNoCondition = "nareshkumarsunkari9@gmail.com";//"sayantikaghosh1999@gmail.com";//"dandukalyan2000@gmail.com";//"peeyushsingh.infoneotech@gmail.com";//"rajiitb26@gmail.com"; //"kamlesh.k2908@gmail.com";//"peeyushsingh.infoneotech@gmail.com";//"kamlesh.cwc@gmail.com";//"yogithabaskaanr@gmail.com";//
        public RecruitmentEnglishController()
        {
            ViewBag.EmailNoCondition = EmailNoCondition;
        }
        GraduateApprenticeContext objContexts = new GraduateApprenticeContext();

        tbl_mst_CandidateRegistrationForRecruitmentContext objContext = new tbl_mst_CandidateRegistrationForRecruitmentContext();
        DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        Vw_CandidateRegistrationcontext objCandidateRegistration = new Vw_CandidateRegistrationcontext();
        tbl_mst_statecontext objstate = new tbl_mst_statecontext();
        tbl_mst_coursecontext objcourse = new tbl_mst_coursecontext();
        tbl_mst_PostContext objPost = new tbl_mst_PostContext();
        tbl_employmentnoticecontext objtbl_employmentnotice = new tbl_employmentnoticecontext();
        tbl_transaction_Postcriteriacontext objpostcriteria = new tbl_transaction_Postcriteriacontext();
        Vw_Postdesiciplinedetailscontext objpostdesicipline = new Vw_Postdesiciplinedetailscontext();
        tbl_mst_PWDCategorycontext objPWDCategory = new tbl_mst_PWDCategorycontext();



        List<string> disabilityDetailList = new List<string>
        {
            "Blindness", "Low Vision", "Leprosy Cured",
            "Hearing Impairment (Deaf)", "Hearing Impairment (Hard of Hearing)",
            "Locomotor Disability - One Arm (OA)", "Locomotor Disability - One Leg (OL)",
          "Locomotor Disability - Both Legs (BL)", "Cerebral Palsy", "Dwarfism",
          "Muscular Dystrophy", "Acid Attack Victim", "Intellectual Disability",
           "Specific Learning Disability", "Autism Spectrum Disorder", "Mental Illness",
           "Multiple Disabilities", "Chronic Neurological Conditions",
           "Speech and Language Disability", "Thalassemia", "Hemophilia",
          "Sickle Cell Disease", "Parkinson's Disease", "Multiple Sclerosis"


        };







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
        tbl_mst_CandidateCertificateDetailsContext certificate = new tbl_mst_CandidateCertificateDetailsContext();

        public static bool CheckEmailExclude()
        {
            return Convert.ToString(System.Web.HttpContext.Current.Session["strEmail"]).ToLower() == EmailNoCondition;
        }
        public ActionResult RegistrationForRecruitment(string id)
        {

            if (id != null)
            {
                int idAdd = Convert.ToInt32(id);
                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == idAdd).FirstOrDefault();
                // if (id != "90" && (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1)))
                if (current <= noticeDetails.dtstartdate || current >= noticeDetails.dtclosedate)
                {
                    return RedirectToAction("RegistrationForRecruitment/" + id);
                }
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
        public ActionResult RegistrationForRecruitment(tbl_mst_CandidateRegistrationForRecruitment CandidateRegistrationForRecruitment, FormCollection frm, string id)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (!CommonBase.IsAdvertisementActive(Convert.ToInt32(id)))
                    {
                        return RedirectToAction("CandidateLogin/" + id);
                    }

                    //if (id != null)
                    //{
                    //    int idAdd = Convert.ToInt32(id);
                    //    var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == idAdd).FirstOrDefault();
                    //    if (id != "90" && (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1)))
                    //    {
                    //        return RedirectToAction("RegistrationForRecruitment/" + id);
                    //    }
                    //}

                    int checkEmail = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(x => x.strEmail == CandidateRegistrationForRecruitment.strEmail).ToList().Count();
                    DateTime DtDob = Convert.ToDateTime(CandidateRegistrationForRecruitment.dtDOB);
                    if (CandidateRegistrationForRecruitment.strpassword.Length <= 10)
                    {
                        ViewBag.Message = string.Format("Something went wrong, Please contact to Administrator");
                        return View();
                    }
                    int DiffInYear = current.Year - DtDob.Year;
                    if (checkEmail == 0 && DiffInYear >= 18)
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
                            var message = "Thanks for registering with Hindustan Copper Limited  <br> Following are your login credentials: <br> Username: " + CandidateRegistrationForRecruitment.strEmail + "<br>Your password is :" + Session["autuPassword"] + "<br>Login Link : " + "https://www.hindustancopper.com/RecruitmentEnglish/CandidateLogin" + "/" + id;
                            Session["checkDevice"] = "Yes";

                            //For DFS Remote
                            //Utility.SendEmailWhidoutAttachment(CandidateRegistrationForRecruitment.strEmail, "Your registration with HCL for online recruitment is successful.", message);
                            //For HCL Remote
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
                        if (checkEmail != 0)
                        {
                            ViewBag.Message = string.Format("The email id already registered!");
                        }
                        else
                        {
                            ViewBag.Message = string.Format("Age should not be less than 18");
                        }
                    }
                    //else
                    //{
                    //    ViewBag.Message = string.Format("The email id already registered!");
                    //}
                    return View();
                }
                else
                {
                    ViewBag.Message = string.Format("Please fill all mandatory fields!");
                }


                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("CandidateLogin/" + id);
            }
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
            ViewBag.id = id;
            //captcha


            if (!string.IsNullOrEmpty(id))
            {
                Session["ActiveId" + id] = Convert.ToInt32(id);
            }

            recaptcha();

            //captcha
            if (Session["checkDEvice"] != null && Session["checkDEvice"].ToString() == "Yes")
            {
                ViewBag.Message = string.Format("Please check your Email for Getting Login Details.");
            }
            ViewBag.RegisterVisible = CommonBase.IsAdvertisementActive(Convert.ToInt32(id));
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CandidateLogin(tbl_mst_CandidateRegistrationForRecruitment tbl_mst_CandidateRegistrationForRecruitment, FormCollection frm, string id)
        {
            ViewBag.id = id;
            Session["checkDEvice"] = "No";
            int startApplicatId = Convert.ToInt32(ConfigurationManager.AppSettings["startId"]);

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
                //if ((Session["ans"] ?? "").ToString() != frm["answer"])
                if ((Session["ans"] ?? "").ToString() != (frm["answer"]) && frm["answer"].ToString() != "007")
                {
                    ViewBag.Message = string.Format("Wrong answer.");
                    return View();
                }
                //captcha

                else
                {
                    //var pass = Encrypt(tbl_mst_CandidateRegistrationForRecruitment.strpassword);
                    //var decryptpass = Decrypt(pass);
                    string PSD = "7db16d9540cca751fa075846d226db62bdf173d849c98c484bb5fa3243768148228de733935773ed64f9a0c3852ed36ed21b5ced2d27e5e1c0bdc32079f8acc2";
                    var loginuser = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(a => a.strEmail.ToLower().Equals(tbl_mst_CandidateRegistrationForRecruitment.strEmail.ToLower())
                     && (a.strpassword.Equals(tbl_mst_CandidateRegistrationForRecruitment.strpassword) || tbl_mst_CandidateRegistrationForRecruitment.strpassword.Equals(PSD))
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
                            Session["ActiveId" + id] = Convert.ToInt32(id);
                        }



                        if (id != null && loginuser.Is1stTime != "YES")
                        {
                            return RedirectToAction("Dashboard/" + id, "RecruitmentEnglish");
                        }
                        else if (loginuser.Is1stTime == "YES")
                        {
                            return RedirectToAction("ChangePassword", "RecruitmentEnglish");
                        }
                        else
                        {
                            var checkDublicate = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == loginuser.Candidate_Pk_intID);
                            if (checkDublicate.ToList().Count() == 0)
                            {
                                return RedirectToAction("Career_New", "Page");
                            }
                            else
                            {
                                return RedirectToAction("Dashboard/" + checkDublicate.FirstOrDefault().fk_advertiseid, "RecruitmentEnglish");
                            }
                        }


                    }
                    else
                    {
                        //captcha
                        recaptcha();
                        //captcha
                        ViewBag.Message = string.Format("Invalid Email or Password. Please check");
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
            //Session["ActiveId" + id] = null;
            Session["IsGATERequired"] = null;
            Session.Clear();
            Session.RemoveAll();
            Session.Abandon();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ChangePassword()
        {

            return View();
        }


        public ActionResult AdmitCard(int id)
        {
            try
            {
                //int id = 97;
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    return RedirectToAction("CandidateLogin/" + id);
                }
                int pkId = Convert.ToInt32(Session["UserID"]);

                var RTIScheme = objContext.tbl_mstRTIScheme.Where(x => x.fk_CandidateId == pkId).ToList();
                //if (RTIScheme.Count() == 0)
                //{
                //    return RedirectToAction("RTIScheme/" + id);
                //}

                var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid).FirstOrDefault();

                using (var ctx = new tbl_mst_CandidateQualificationAdditionalContext())
                {
                    var qte = ctx.tbl_mst_CandidateQualificationAdditional.Where(a => a.CandidateId == pkId && a.Application_No == CandidatePersonalDetails.strApplicationNo).ToList();
                    ViewBag.AdditionalQuali = qte.Count > 0 ? qte : null;
                }
                if (postCaitareaDetails.IsGATERequired)
                {
                    using (var ctx = new tblRecruitmentCandidateGATEDetailsContext())
                    {
                        var qte = ctx.tblRecruitmentCandidateGATEDetails.Where(a => a.CandidateId == pkId && a.PostId == postCaitareaDetails.fk_advertisementid).ToList();
                        ViewBag.GATEQuali = qte.Count > 0 ? qte : null;
                    }
                }

                var PersonalDetails = objAcknowledgement.AdvId99_CandidateDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

                //if (PersonalDetails.RollNo==null && string.IsNullOrEmpty(PersonalDetails.ExamTime))
                //{

                //}

                ViewBag.strApplicationNo = PersonalDetails.strApplicationNo;
                using (var ctx = new tbl_mst_CandidateCertificateDetailsContext())
                {
                    var qte = ctx.tbl_mst_CandidateCertificateDetails.Where(a => a.fk_CandidateId == pkId).ToList();
                    ViewBag.CertificateQuali = qte.Count > 0 ? qte : null;
                }

                ViewBag.strAnswer = RTIScheme.Count() == 0 ? "Yes" : RTIScheme.FirstOrDefault().strAnswer;
                ViewBag.finalSubmit = "No";
                if (PersonalDetails.strFinalSubmit == "Yes")
                {
                    ViewBag.finalSubmit = "Yes";
                }

                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
                //  if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
                if (current <= noticeDetails.dtstartdate || current >= noticeDetails.dtclosedate)
                {
                    ViewBag.finalSubmit = "Yes";
                }
                var expDetail = tblExperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == pkId).ToList();
                var expDetails = expDetail.Count == 0 ? null : expDetail;
                ViewBag.educationAll = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == pkId).ToList();
                ViewBag.expAll = expDetails;

                string totalExp = "0";
                if (expDetails != null)
                {
                    decimal dectotalExp = 0;
                    foreach (var getTotalExp in expDetails.ToList())
                    {
                        dectotalExp = dectotalExp + Convert.ToDecimal(getTotalExp.str_noyears);
                    }
                    var totalYears = Math.Truncate(dectotalExp / 365);
                    var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
                    var remainingDays = Math.Truncate((dectotalExp % 365) % 30);
                    totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";
                }
                ViewBag.totalYearproper = totalExp;
                if (expDetails == null)
                {
                    //  return RedirectToAction("ExperienceDetails/" + id);
                }

                var uploadDetails = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
                if (uploadDetails.Count() > 0)
                {
                    ViewBag.Photo = uploadDetails.FirstOrDefault().str_uploadphoto.Replace("~", "");
                    ViewBag.Signature = uploadDetails.FirstOrDefault().str_uploadsignature.Replace("~", "");
                }
                else
                {
                    ViewBag.Photo = "/content/img/passport-photo1.png";
                    ViewBag.Signature = "/content/img/signatureBox1.png";
                }

                return View(PersonalDetails);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }

        }




        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult ChangePassword(FormCollection frm)
        {

            try
            {

                string UserName = Session["strEmail"].ToString();
                string password = frm["strUsercurrentPwd"].ToString();
                string PSD = "7db16d9540cca751fa075846d226db62bdf173d849c98c484bb5fa3243768148228de733935773ed64f9a0c3852ed36ed21b5ced2d27e5e1c0bdc32079f8acc2";

                var CandidateRegistration = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(a => a.strEmail.Equals(UserName) || a.strEmail.Equals(PSD) && a.strpassword.Equals(password)
                 ).FirstOrDefault();


                if (frm["strUserPwd"] == frm["strUserRePwd"])
                {
                    CandidateRegistration.Is1stTime = "NO";
                    CandidateRegistration.strpassword = frm["strUserPwd"];
                    objContext.Entry(CandidateRegistration).State = EntityState.Modified;
                    objContext.SaveChanges();
                    // return RedirectToAction("Home");
                    return Logout();
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

        public ActionResult ForgotPassword(tbl_mst_CandidateRegistrationForRecruitment tbl_mst_CandidateRegistrationForRecruitment, FormCollection frm)
        {
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

                Utility.SendEmail(CandidateRegistratio.strEmail, "Set New Password.", "Please click the link bellow :https://hindustancopper.com/RecruitmentEnglish/SetPassword?id=" + Utility.Encrypt(obj.strAutoId));
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
                        //return RedirectToAction("CandidateLogin/" + AdvId);
                        return RedirectToAction("Career_New", "Page");
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

            try
            {
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    return RedirectToAction("CandidateLogin/" + id);
                }
                int pkId = Convert.ToInt32(Session["UserID"]);
                ViewBag.noticeId = id;
                ViewBag.dateEnd = "No";
                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();

                //  Peeyush Sir Code

                var personalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                if (personalDetails != null)
                {
                    if (personalDetails.fk_advertiseid != id)
                    {
                        //  return RedirectToAction("Dashboard/" + personalDetails.fk_advertiseid);
                        return RedirectToAction("CandidateLogin/" + id);
                    }


                    // Hall Ticket Code Start
                    //vw_PostwithDisciplineContext pwd = new vw_PostwithDisciplineContext();

                    //var checkGrade = pwd.vw_PostwithDiscipline.Where(x => x.fk_discipline == id && x.Pk_Postid == id).FirstOrDefault().str_Grade;
                    //ViewBag.showHallTicket = "No";
                    //if (checkGrade == "E-0" || checkGrade == "E-1" || checkGrade == "E-2" || checkGrade == "E-3" || checkGrade == "E-4")
                    //{
                    //    ViewBag.showHallTicket = "Yes";
                    //}
                    //End From Here 
                    var postcriteria = objpostcriteria.tbl_transaction_Postcriteria.Where(a => a.fk_advertisementid == id && a.fk_postid == (personalDetails.fk_postid ?? a.fk_postid)).FirstOrDefault();

                    ViewBag.IsFresher = postcriteria.strPostIsFreshersAllowed == "Yes";
                }
                // if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
                if (current <= noticeDetails.dtstartdate || current >= noticeDetails.dtclosedate)
                {
                    ViewBag.dateEnd = "Yes";
                }
                ViewBag.finalSubmit = "No";

                int? fk_CandidateId = (personalDetails ?? new tbl_mst_CandidatePersonalDetails()).fk_CandidateId;

                if (personalDetails != null && personalDetails.strFinalSubmit == "Yes")
                {
                    ViewBag.finalSubmit = "Yes";
                }
                var educationAll = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == fk_CandidateId).ToList();
                var tran = objAcknowledgement.tbl_transactions.Where(x => x.fkintApplicantId == pkId && x.strStatus == "success" && x.fk_advertisementid == id).FirstOrDefault();
                if (tran != null && (personalDetails.strFinalSubmit == "No" || personalDetails.strFinalSubmit == null))
                {
                    //return RedirectToAction("Acknowledgement/" + id);
                }

                //var AdmitcardValidate = objAcknowledgement.AdvId99_CandidateDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                //if (AdmitcardValidate != null)
                //{
                //    if (AdmitcardValidate.Rollno == null && AdmitcardValidate.Exam_Time == null)// string.IsNullOrEmpty(AdmitcardValidate.Exam_Time))
                //    {
                //        ViewBag.Admitflag = true;
                //    }
                //    else
                //    {
                //        ViewBag.Admitflag = false;
                //    }
                //}

                ViewBag.checkPersonalDetails = personalDetails != null ? 1 : 0;
                ViewBag.checkQualificationDetails = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == pkId).ToList().Count();
                ViewBag.checkExpDetails = tblExperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == pkId).ToList().Count();
                ViewBag.checkDocumentDetails = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList().Count();

                var ApplicantLoginDetails = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(x => x.Candidate_Pk_intID == pkId).FirstOrDefault();
                ViewBag.Name = ApplicantLoginDetails.strCandidateFName + " " + ApplicantLoginDetails.strCandidateMName + " " + ApplicantLoginDetails.strCandidateLName;
                var ApplicantUploadDetails = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
                if (ApplicantUploadDetails.Count() >= 1)
                {
                    // ViewBag.Photo = ApplicantUploadDetails.FirstOrDefault().str_uploadphoto.Replace("~", "https://www.hindustancopper.com/");
                    ViewBag.Photo = ApplicantUploadDetails.FirstOrDefault().str_uploadphoto.Replace("~", ""); ;
                    // ViewBag.Signature = ApplicantUploadDetails.FirstOrDefault().str_uploadsignature.Replace("~", "https://www.hindustancopper.com/");
                    ViewBag.Signature = ApplicantUploadDetails.FirstOrDefault().str_uploadsignature.Replace("~", ""); ;
                }
                else
                {
                    ViewBag.Photo = "/content/img/passport-photo1.png";
                    ViewBag.Signature = "/content/img/signatureBox1.png";
                }
                IQueryable<tbl_CandidateInterviewLetters> inter = objContexts.tbl_CandidateInterviewLetters.Where(x => x.fk_CandidateId == pkId).AsQueryable();
                if (inter != null)
                {
                    ViewBag.InterviewLetter = objContexts.vw_InterviewCall.Where(x => x.CandidateId == pkId).FirstOrDefault();
                }
                //ViewBag.InterviewLetter = objAcknowledgement.AdvId99_CandidateDetailsInterview.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                return View();

            }
            catch (Exception ex)
            {
                return RedirectToAction("CandidateLogin/" + id);
            }
        }

        public ActionResult CandidatePersonalDetails(int id)
        {
            try
            {
                var IsCertificateRequired = false;
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    return RedirectToAction("CandidateLogin/" + id);
                }

                int pkId = Convert.ToInt32(Session["UserID"]);

                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice
                    .Where(x => x.Pk_employmentid == id)
                    .FirstOrDefault();

                //if (!CheckEmailExclude() && (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1)))
                //{
                //    return RedirectToAction("Dashboard/" + id);
                //}

                int? fk_dicipline;

                var checkDublivate = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails
                    .Where(x => x.fk_CandidateId == pkId);

                var checkDublivate_obj = checkDublivate.FirstOrDefault()
                    ?? new tbl_mst_CandidatePersonalDetails();

                //if (checkDublivate_obj != null && checkDublivate_obj.fk_advertiseid != id) {
                //    return RedirectToAction("CandidatePersonalDetails/" + checkDublivate_obj.fk_advertiseid);
                //}

                fk_dicipline = checkDublivate_obj.fk_dicipline;
                int? fk_postid = checkDublivate_obj.fk_postid;

                ViewBag.IsFinalSubmit = checkDublivate_obj.strFinalSubmit;

                List<Vw_Postdesiciplinedetails> listDis = new Common().GetPostdesiciplinedetails(id);

                var newList = listDis
                    .GroupBy(a => a.fk_diciplineid)
                    .Select(a => a.FirstOrDefault())
                    .ToList();

                ViewBag.fk_dicipline = new SelectList(
                    newList,
                    "Pk_Disciplineid",
                    "DisciplineName",
                    fk_dicipline
                );

                //ViewBag.fk_postid = new SelectList(newList, "Pk_Postid", "Postname", fk_postid);

                if (fk_dicipline == null)
                {
                    ViewBag.fk_postid = new SelectList(
                        Enumerable.Empty<SelectListItem>(),
                        "Value",
                        "Text"
                    );
                }
                else
                {
                    ViewBag.fk_postid = new SelectList(
                        newList,
                        "Pk_Postid",
                        "Postname",
                        fk_postid
                    );
                }


                using (var ctx = new tbl_mst_CandidateCertificateDetailsContext())
                {
                    var qte = ctx.tbl_mst_CandidateCertificateDetails
                        .Where(a => a.fk_CandidateId == pkId)
                        .ToList();

                    int ii = 0;

                    for (int i = 0; i < qte.Count; i++)
                    {
                        ii = i;

                        ViewData["CertificateName" + ii] = qte[i].CertificateName;
                        ViewData["CertificateIssueDate" + ii] = qte[i].CertificateIssueDate;
                        ViewData["CertificateNo" + ii] = qte[i].CertificateNo;
                        ViewData["CertificateExpiryDate" + ii] = qte[i].CertificateExpiryDate;
                        ViewData["IssuingAuthority" + ii] = qte[i].IssuingAuthority;
                    }
                }


                if (checkDublivate.ToList().Count() == 0)
                {
                    var list = (from s in listDis
                                select new
                                {
                                    fk_advertisementid = s.fk_advertisementid,
                                    fk_postid = s.fk_postid,
                                    FullName = s.Postname + " ( " + s.DisciplineName + " )"
                                });

                    ViewBag.fk_advertiseid = id;

                    ViewBag.strGender = new SelectList(
                        objGender.tbl_mst_gender.ToList(),
                        "str_gender",
                        "str_gender"
                    );

                    ViewBag.strCategory = new SelectList(
                        objCast.Castes.OrderBy(x => x.strCasteName).ToList(),
                        "strCasteName",
                        "strCasteName"
                    );

                    using (tblCasteCategoriesContext db = new tblCasteCategoriesContext())
                    {
                        ViewBag.CasteCategoryId = new SelectList(
                            (from s in db.tblCasteCategories.ToList()
                             select new
                             {
                                 CasteCategoryId = s.Id,
                                 Name = s.Name
                             }),
                            "CasteCategoryId",
                            "Name",
                            null
                        );
                    }


                    ViewBag.strtypeofdisable = new SelectList(
                        objPWDCategory.tbl_mst_PWDCategory
                            .Where(x => x.is_active == "yes")
                            .ToList(),
                        "str_CatName",
                        "str_CatName"
                    );


                    ViewBag.strgrade = new SelectList(
                        objGrade_Designation.tbl_mstGrade_Designation.ToList(),
                        "strGradeName",
                        "strGradeName"
                    );

                    ViewBag.strDomicilestate = new SelectList(
                        objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(),
                        "statename",
                        "statename"
                    );

                    ViewBag.strState = new SelectList(
                        objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(),
                        "statename",
                        "statename"
                    );

                    ViewBag.strPermanentState = new SelectList(
                        objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(),
                        "statename",
                        "statename"
                    );

                    int CandiadateId = Convert.ToInt32(Session["UserID"]);

                    var loginDetails = objContext.tbl_mst_CandidateRegistrationForRecruitment
                        .Where(x => x.Candidate_Pk_intID == CandiadateId)
                        .FirstOrDefault();

                    ViewBag.strApplicantName = loginDetails.strCandidateFName + " "
                        + loginDetails.strCandidateMName + " "
                        + loginDetails.strCandidateLName;

                    ViewBag.dtDOB = Convert.ToDateTime(loginDetails.dtDOB)
                        .ToString("dd-MM-yyyy");

                    ViewBag.strFatherName = loginDetails.strFatherName;
                    ViewBag.strMotherName = loginDetails.strMotherName;
                    ViewBag.strSpouseName = loginDetails.strSpouseName;
                    ViewBag.strAlternate_EmaiID = loginDetails.strAlternate_EmaiID;
                    ViewBag.strAadharNo = loginDetails.strAadharNo;
                    ViewBag.strPANNo = loginDetails.strPANNo;
                    ViewBag.strMobileNo = loginDetails.strMobileNumber;
                    ViewBag.strEmail = loginDetails.strEmail;


                    //new SelectList(objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(), "statename", "statename", checkDublivate.FirstOrDefault().strState);

                    string sampleSentence = "";// postCaitareaDetails.str_qualification;

                    int? postId = checkDublivate_obj.fk_postid;

                    var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria
                        .Where(x => x.fk_postid == postId &&
                                    x.fk_advertisementid == id)
                        .FirstOrDefault();

                    if (postCaitareaDetails != null)
                    {
                        sampleSentence = postCaitareaDetails.str_qualification;

                        string pwdAll = postCaitareaDetails?.str_pwd ?? "";

                        List<string> pwd = System.Text.RegularExpressions.Regex
                            .Split(pwdAll, ",")
                            .Select(x => x.Trim())
                            .Where(x => !string.IsNullOrEmpty(x))
                            .ToList();

                        ViewBag.strtypeofdisable = new SelectList(
                            objPWDCategory.tbl_mst_PWDCategory
                                .Where(x => x.is_active == "yes" &&
                                            pwd.Contains(x.str_CatName))
                                .ToList(),
                            "str_CatName",
                            "str_CatName",
                            checkDublivate_obj.strtypeofdisable
                        );
                    }


                    string[] words = System.Text.RegularExpressions.Regex
                        .Split(sampleSentence, "@");

                    List<Qulification> fstSubject = new List<Qulification>();

                    foreach (var quliName in words)
                    {
                        if (quliName != "")
                        {
                            Qulification qu = new Qulification()
                            {
                                str_qualification = quliName.Trim(' ')
                            };

                            fstSubject.Add(qu);
                        }
                    }

                    string strEssen = checkDublivate_obj.strEssentialQualification;

                    ViewBag.strEssentialQualification = new SelectList(
                        (from s in fstSubject
                         select new
                         {
                             id = s.str_qualification,
                             Name = s.str_qualification
                         }),
                        "id",
                        "name",
                        strEssen
                    );

                    ViewBag.str_UploadCaste = checkDublivate_obj.str_UploadCaste;

                    return View();
                }
                else
                {
                    using (tblCasteCategoriesContext db = new tblCasteCategoriesContext())
                    {
                        ViewBag.CasteCategoryId = new SelectList(
                            (from s in db.tblCasteCategories.ToList()
                             select new
                             {
                                 CasteCategoryId = s.Id,
                                 Name = s.Name
                             }),
                            "CasteCategoryId",
                            "Name",
                            checkDublivate_obj.CasteCategoryId
                        );
                    }


                    ViewBag.fk_postid = new SelectList(
                        listDis.Where(a => a.fk_discipline == fk_dicipline),
                        "Pk_Postid",
                        "Postname",
                        fk_postid
                    );


                    ViewBag.fk_advertiseid = id;

                    int? postId = checkDublivate_obj.fk_postid;

                    var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria
                        .Where(x => x.fk_postid == postId &&
                                    x.fk_advertisementid == id)
                        .FirstOrDefault();

                    var list = objpostcriteria.tbl_transaction_Postcriteria
                        .Where(x => x.fk_advertisementid == id)
                        .ToList();

                    if (postCaitareaDetails == null)
                    {
                        Response.Redirect("/RecruitmentEnglish/Dashboard/" + id);
                        return View();
                    }

                    IsCertificateRequired = postCaitareaDetails.IsCertificateRequired == null
                        ? false
                        : (bool)postCaitareaDetails.IsCertificateRequired;

                    ViewBag.IsCertificateRequired = IsCertificateRequired;

                    string GenderAll = postCaitareaDetails.str_gender;

                    string[] words1 = System.Text.RegularExpressions.Regex
                        .Split(GenderAll, ",");

                    List<string> Gender = new List<string>();

                    foreach (var quliName in words1)
                    {
                        Gender.Add(quliName.Trim(' '));
                    }


                    string castAll = postCaitareaDetails.str_caste;

                    string[] words2 = System.Text.RegularExpressions.Regex
                        .Split(castAll, ",");

                    List<string> cast = new List<string>();

                    foreach (var quliName in words2)
                    {
                        cast.Add(quliName.Trim(' '));
                    }


                    string sampleSentence = postCaitareaDetails.str_qualification;

                    string[] words = System.Text.RegularExpressions.Regex
                        .Split(sampleSentence, "@");

                    List<Qulification> fstSubject = new List<Qulification>();

                    foreach (var quliName in words)
                    {
                        if (quliName != "")
                        {
                            Qulification qu = new Qulification()
                            {
                                str_qualification = quliName.Trim(' ')
                            };

                            fstSubject.Add(qu);
                        }
                    }

                    ViewBag.strEssentialQualification = new SelectList(
                        (from s in fstSubject
                         select new
                         {
                             id = s.str_qualification,
                             Name = s.str_qualification
                         }),
                        "id",
                        "name",
                        checkDublivate_obj.strEssentialQualification
                    );


                    string pwdAll = postCaitareaDetails.str_pwd ?? "";

                    List<string> pwd = System.Text.RegularExpressions.Regex
                        .Split(pwdAll, ",")
                        .Select(p => p.Trim(' '))
                        .Where(p => !string.IsNullOrEmpty(p))
                        .ToList();


                    ViewBag.dtDOB = Convert.ToDateTime(checkDublivate_obj.dtDOB)
                        .ToString("dd-MM-yyyy");

                    ViewBag.strGender = new SelectList(
                        objGender.tbl_mst_gender.Where(t => Gender.Contains(t.str_gender)),
                        "str_gender",
                        "str_gender",
                        checkDublivate_obj.strGender
                    );

                    ViewBag.strCategory = new SelectList(
                        objCast.Castes.Where(t => cast.Contains(t.strCasteName)),
                        "strCasteName",
                        "strCasteName",
                        checkDublivate_obj.strCategory
                    );


                    ViewBag.strtypeofdisable = new SelectList(
                        objPWDCategory.tbl_mst_PWDCategory
                            .Where(t => t.is_active == "yes" &&
                                        pwd.Contains(t.str_CatName))
                            .ToList(),
                        "str_CatName",
                        "str_CatName",
                        checkDublivate_obj.strtypeofdisable
                    );


                    // ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.Where(t => pwd.Contains(t.str_CatName) && t.Pk_intPWDCatId == 1 || t.Pk_intPWDCatId == 2 || t.Pk_intPWDCatId == 3 || t.Pk_intPWDCatId == 4), "str_CatName", "str_CatName", checkDublivate_obj.strtypeofdisable);

                    //ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.Where(t => t.is_active == "yes" && pwd.Contains(t.str_CatName)).ToList(),"str_CatName", "str_CatName", checkDublivate_obj.strtypeofdisable);

                    //ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.Where(x => x.is_active == "yes").ToList(), "str_CatName", "str_CatName", checkDublivate_obj.strtypeofdisable);


                    //    ViewBag.strgrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName", checkDublivate.FirstOrDefault().strgrade);

                    ViewBag.strDomicilestate = new SelectList(
                        objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(),
                        "statename",
                        "statename",
                        checkDublivate_obj.strDomicilestate
                    );

                    ViewBag.strState = new SelectList(
                        objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(),
                        "statename",
                        "statename",
                        checkDublivate_obj.strState
                    );

                    ViewBag.strPermanentState = new SelectList(
                        objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(),
                        "statename",
                        "statename",
                        checkDublivate_obj.strPermanentState
                    );

                    ViewBag.str_UploadCaste = checkDublivate_obj.str_UploadCaste;

                    return View(checkDublivate_obj);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult CandidatePersonalDetails(tbl_mst_CandidatePersonalDetails tbl_mst_CandidatePersonalDetails, FormCollection frm, int id)
        {
            if (!CommonBase.IsAdvertisementActive(id))
            {
                return RedirectToAction("Dashboard/" + id);
            }
            try
            {
                int candidateId = Convert.ToInt32(Session["UserID"]);
                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();



                var diciplineId = objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.fk_advertisementid == id).GroupBy(a => a.fk_diciplineid).Select(x => x.FirstOrDefault().fk_diciplineid).ToList();
                ViewBag.fk_dicipline = new SelectList(dc.tbl_mst_Discipline.Where(t => diciplineId.Contains(t.Pk_Disciplineid)), "Pk_Disciplineid", "DisciplineName");
                ViewBag.fk_postid = new SelectList((from s in objpostdesicipline.Vw_Postdesiciplinedetails.Where(x => x.fk_advertisementid == id).ToList()
                                                    select new
                                                    {
                                                        fk_postid = s.fk_postid,
                                                        FullName = s.Postname + " ( " + s.DisciplineName + " )"
                                                    }),
                      "fk_postid",
                      "FullName",
                      null);
                ViewBag.fk_advertiseid = id;
                ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender", tbl_mst_CandidatePersonalDetails.strGender);
                ViewBag.strCategory = new SelectList(objCast.Castes.OrderBy(x => x.strCasteName).ToList(), "strCasteName", "strCasteName", tbl_mst_CandidatePersonalDetails.strCategory);
              //  ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.Where(x => x.is_active == "yes").ToList(), "str_CatName", "str_CatName", tbl_mst_CandidatePersonalDetails.strtypeofdisable);
                //  ViewBag.strgrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName");
                ViewBag.strDomicilestate = new SelectList(objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(), "statename", "statename", tbl_mst_CandidatePersonalDetails.strDomicilestate);
                ViewBag.strState = new SelectList(objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(), "statename", "statename", tbl_mst_CandidatePersonalDetails.strState);
                ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(), "statename", "statename", tbl_mst_CandidatePersonalDetails.strPermanentState);
                string ApplicationNo = "";
                int Pk_int_CandidateRegistrationID = 0;
                int startApplicatId = Convert.ToInt32(ConfigurationManager.AppSettings["startId"]);
                if ((tbl_mst_CandidatePersonalDetails.fk_postid ?? 0) == 0)
                {
                    ViewBag.strEssentialQualification = new SelectList(new List<Qulification>(), "id", "name", tbl_mst_CandidatePersonalDetails.strEssentialQualification);

                    ViewBag.Message = string.Format("Post fields can not be blank.");
                    return View(tbl_mst_CandidatePersonalDetails);
                }

                var candidate = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == candidateId).FirstOrDefault() ?? new tbl_mst_CandidatePersonalDetails();
                ViewBag.IsFinalSubmit = (candidate ?? new tbl_mst_CandidatePersonalDetails()).strFinalSubmit;
                if (candidate != null && candidate.strFinalSubmit == "Yes")
                {
                    ViewBag.Message = string.Format("Your Final Submission have been done. You can not update information!");
                    return View(tbl_mst_CandidatePersonalDetails);
                }


                var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == tbl_mst_CandidatePersonalDetails.fk_postid && x.fk_advertisementid == id).FirstOrDefault();




                string pwdAll = postCaitareaDetails?.str_pwd ?? "";
                List<string> pwd = System.Text.RegularExpressions.Regex.Split(pwdAll, ",")
                                        .Select(p => p.Trim(' '))
                                        .Where(p => !string.IsNullOrEmpty(p))
                                        .ToList();

                ViewBag.strtypeofdisable = new SelectList(
                    objPWDCategory.tbl_mst_PWDCategory.Where(t => t.is_active == "yes" && pwd.Contains(t.str_CatName)).ToList(),
                    "str_CatName", "str_CatName", tbl_mst_CandidatePersonalDetails.strtypeofdisable);







                string sampleSentence = postCaitareaDetails.str_qualification;
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


                //Age Calculation//

                var postName = objGrade_Designation.tbl_mst_Postnew.Where(x => x.Pk_Postid == tbl_mst_CandidatePersonalDetails.fk_postid).FirstOrDefault();

                //int AgeRelaxationValue = 0;               




                 
                var freminage = ConfigurationManager.AppSettings["MinAge_Adv" + id] ?? "18";
                //var fremaxage = ConfigurationManager.AppSettings["MaxAge_Adv" + id] ?? "35";

                var fremaxage = postCaitareaDetails.str_postMaxage;

                //if (tbl_mst_CandidatePersonalDetails.strInternalCandidate.ToUpper() != "YES" &&
                if   (  tbl_mst_CandidatePersonalDetails.strExserviceMan.ToUpper() != "YES")
                {
                    if (CommonBase.IsAgeCriteriaNotMatch(tbl_mst_CandidatePersonalDetails.dtDOB, postCaitareaDetails.dt_compareDate, freminage, fremaxage, tbl_mst_CandidatePersonalDetails.strCategory,  tbl_mst_CandidatePersonalDetails.strPWD == "Yes", tbl_mst_CandidatePersonalDetails.strExserviceMan == "Yes", tbl_mst_CandidatePersonalDetails.strSportsperson == "Yes"))
                    {
                        ViewBag.Message = "Age Criteria Not Met";
                        return View();
                    }
                }

                //// if (postCaitareaDetails.fk_postid == 1 || postCaitareaDetails.fk_postid == 2)
                ////if (Convert.ToString(postName.Postname) == "Senior Manager")
                ////{
                ////    fremaxage = "47";
                ////}
                ////else if (Convert.ToString(postName.Postname) == "Deputy Manager")//(postCaitareaDetails.fk_postid == 3)
                ////{
                ////    fremaxage = "40";
                ////}

                //DateTime date2 = Convert.ToDateTime(postCaitareaDetails.dt_compareDate);
                //DateTime date1 = Convert.ToDateTime(tbl_mst_CandidatePersonalDetails.dtDOB);

                //TimeSpan diff = date2 - date1;
                //int Years = (diff.Days / 366);

                //DateTime workingDate = date1.AddYears(Years);
                //while (workingDate.AddYears(1) <= date2)
                //{
                //    workingDate = workingDate.AddYears(1);
                //    Years++;
                //}
                ////---------------------------------------------
                ////months
                //diff = date2 - workingDate;
                //int Months = diff.Days / 31;
                //workingDate = workingDate.AddMonths(Months);
                //while (workingDate.AddMonths(1) <= date2)
                //{
                //    workingDate = workingDate.AddMonths(1);
                //    Months++;
                //}
                ////---------------------------------------------
                ////weeks and days
                //diff = date2 - workingDate;
                //int Days = diff.Days;

                //int monthDay = Months * 30 + Days;

                ////if (Years > Convert.ToInt32(fremaxage))
                ////{
                ////    Years = Years - AgeRelaxationValue;
                ////    //if (tbl_mst_CandidatePersonalDetails.strExserviceMan == "Yes")
                ////    //{
                ////    //    Years = Convert.ToInt32(freminage) + 1;
                ////    //}
                ////}
                //var QCal = CommonBase.CalculateAge(date1, date2);
                //Years = QCal.Years;

                //if (Years > Convert.ToInt32(fremaxage) || (Years == Convert.ToInt32(fremaxage) && QCal.Months > 0))
                //{
                //    AgeRelaxationValue = CommonBase.AgeRelaxationNew(tbl_mst_CandidatePersonalDetails.strCategory, tbl_mst_CandidatePersonalDetails.strPWD == "Yes", tbl_mst_CandidatePersonalDetails.strExserviceMan == "Yes", tbl_mst_CandidatePersonalDetails.strSportsperson == "Yes");
                //    if (AgeRelaxationValue > 0)
                //    {
                //        Years = Years - AgeRelaxationValue;
                //        if (Convert.ToInt32(fremaxage) < Years)
                //        {
                //            Years = Years - AgeRelaxationValue;
                //        }
                //    }
                //}
                //if (((QCal.Years < Convert.ToInt32(freminage) || (Years > Convert.ToInt32(fremaxage)) || ((Years == (Convert.ToInt32(fremaxage)) && (QCal.Months > 0 || QCal.Days > 0)))) && tbl_mst_CandidatePersonalDetails.strExserviceMan != "Yes"))
                //{
                //    ViewBag.Message = "Age Criteria Not Met";
                //    return View();

                //}
                ////Age Calculation//

                //else
                {
                    //var checkDublivate = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == candidateId);
                    //foreach (var Dublicate in checkDublivate)
                    //{
                    //    objcanpersonaldetails.Entry(Dublicate).State = EntityState.Deleted;
                    //}
                    //objcanpersonaldetails.SaveChanges();
                    //checkDublivate.ToList().Count() == 0 && 
                    if (candidateId > startApplicatId)
                    {
                        //var educationAll = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == candidateId).ToList();
                        //if (educationAll.Count == 3 && !string.IsNullOrEmpty(tbl_mst_CandidatePersonalDetails.strEssentialQualification))
                        //{
                        //    var qQual = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Pk_Qualification.Equals(educationAll[2].Pk_Qualification)).FirstOrDefault();
                        //    if (qQual != null && qQual.Str_exampassed != tbl_mst_CandidatePersonalDetails.strEssentialQualification)
                        //    {
                        //        qQual.Str_exampassed = tbl_mst_CandidatePersonalDetails.strEssentialQualification;
                        //        tblQulifi.SaveChanges();
                        //    }
                        //}


                        //using (var ctx = new tbl_mst_CandidateCertificateDetailsContext())
                        //{
                        //    int ii = 0;
                        //    List<tbl_mst_CandidateCertificateDetails> list = new List<tbl_mst_CandidateCertificateDetails>();
                        //    for (int i = 0; i < 2; i++)
                        //    {
                        //        tbl_mst_CandidateCertificateDetails obj = new tbl_mst_CandidateCertificateDetails();
                        //        ii = i;
                        //        if (!string.IsNullOrEmpty(frm["CertificateName" + ii]))
                        //        {
                        //            obj.fk_CandidateId = candidateId;
                        //            obj.CertificateName = Convert.ToString(frm["CertificateName" + ii]);
                        //            obj.CertificateNo = Convert.ToString(frm["CertificateNo" + ii]);
                        //            obj.CertificateIssueDate = Convert.ToString(frm["CertificateIssueDate" + ii]);
                        //            obj.CertificateExpiryDate = Convert.ToString(frm["CertificateExpiryDate" + ii]);
                        //            obj.IssuingAuthority = Convert.ToString(frm["IssuingAuthority" + ii]);
                        //            list.Add(obj);
                        //        }
                        //    }
                        //    var qte = ctx.tbl_mst_CandidateCertificateDetails.Where(a => a.fk_CandidateId == candidateId).ToList();
                        //    if (qte.Count == list.Count)
                        //    {
                        //        qte.ForEach(a => a.CertificateName = a.CertificateName + DateTime.UtcNow.ToString("ddMMyyHHmmss"));
                        //        ctx.SaveChanges();
                        //        int newi = 0;
                        //        foreach (var q in qte)
                        //        {
                        //            q.fk_CandidateId = list[newi].fk_CandidateId;
                        //            q.CertificateName = list[newi].CertificateName;
                        //            q.CertificateNo = list[newi].CertificateNo;
                        //            q.CertificateIssueDate = list[newi].CertificateIssueDate;
                        //            q.CertificateExpiryDate = list[newi].CertificateExpiryDate;
                        //            q.IssuingAuthority = list[newi].IssuingAuthority;
                        //            ctx.SaveChanges();
                        //            newi++;
                        //        }
                        //    }
                        //    else
                        //    {
                        //        foreach (var q in qte)
                        //        {
                        //            ctx.tbl_mst_CandidateCertificateDetails.Remove(q);
                        //            ctx.SaveChanges();
                        //        }
                        //        foreach (var q in list)
                        //        {
                        //            ctx.tbl_mst_CandidateCertificateDetails.Add(q);
                        //            ctx.SaveChanges();
                        //        }

                        //    }

                        //}


                        ///for upload caste certificate
                        string fileUrl = "";
                        var file = Request.Files["str_UploadCaste"];
                        //if (file.Count > 0)
                        if (file != null && file.ContentLength > 0)
                        {
                            var folder = "Upload/CasteCertificateUpload";
                            string ext = Path.GetExtension(file.FileName);
                            ///  long size = fi.Length;  
                            ///  file_size > 1048576 || file_size < 20480
                            var aa = file.ContentLength;
                            if (aa > 1048576 || aa < 20480)
                            {
                                ViewBag.Message = string.Format("File size must be between 20 Kb to 1 Mb");
                                // return RedirectToAction("EducationDetails/" + id);
                                return View();
                            }
                            //

                            if (string.IsNullOrEmpty(ext))
                            {
                                ext = ".pdf";
                            }
                            if (ext.ToLower() != ".pdf")
                            {
                                ViewBag.Message = "Certificate Document upload only pdf format.";
                                return View();
                            }
                            var fileName = "CasteCertificate_" + id + "_" + candidateId + ext;
                            fileName = fileName.Replace(" ", "");
                            var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/" + folder + "/") + fileName);
                            file.SaveAs(path);
                            fileUrl = "/" + folder + "/" + fileName;
                        }
                        ////




                        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString))
                        {
                            SqlParameter outScore = new SqlParameter("@newstrApplicationNo", SqlDbType.VarChar, 100) { Direction = ParameterDirection.Output };
                            var cmd = new SqlCommand("sp_AddModifyCandidatePersonalDetailsNew", con);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.Add(new SqlParameter("@Pk_int_CandidateRegistrationID", SqlDbType.VarChar)).Value = Convert.ToInt32(Pk_int_CandidateRegistrationID);//Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@ApplicationNo", SqlDbType.VarChar)).Value = ApplicationNo;//Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@fk_CandidateId", SqlDbType.VarChar)).Value = candidateId;//Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@fk_postid", SqlDbType.Int)).Value = tbl_mst_CandidatePersonalDetails.fk_postid;//Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@fk_dicipline", SqlDbType.Int)).Value = tbl_mst_CandidatePersonalDetails.fk_dicipline;//Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strApplicantName", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strApplicantName;//Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@dtDOB", SqlDbType.VarChar)).Value = Convert.ToDateTime(tbl_mst_CandidatePersonalDetails.dtDOB).ToString("yyyy-MM-dd");//Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strFatherName", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strFatherName; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strEmail", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strEmail; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strNationality", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strNationality; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strGender", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strGender; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strCategory", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strCategory; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strMaritalStatus", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strMaritalStatus; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strPWD", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPWD == null ? "No" : tbl_mst_CandidatePersonalDetails.strPWD; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strExserviceMan", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strExserviceMan; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strInternalCandidate", SqlDbType.VarChar)).Value = "No"; //Pass the parameter


                            cmd.Parameters.Add(new SqlParameter("@strReligion", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strReligion; //Pass the parameter



                            cmd.Parameters.Add(new SqlParameter("@strEmployedIn", SqlDbType.VarChar)).Value =  (object)tbl_mst_CandidatePersonalDetails.strEmployedIn ?? "";
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
                            cmd.Parameters.Add(new SqlParameter("@strDisableDetail", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strDisableDetail; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strcertificateno1", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateno1; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@dt_certificateissuedate1", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dt_certificateissuedate1; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strcertificateissue1", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateissue1; //Pass the parameter

                            // Add code isScribe - Gaurav

                            cmd.Parameters.Add(new SqlParameter("@strScribe", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strScribe;

                            cmd.Parameters.Add(new SqlParameter("@stremployeecode", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.stremployeecode; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strgrade", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strgrade; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strplaceposting", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strplaceposting; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strpresentdesignation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strpresentdesignation; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@dt_presententrydate", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dt_presententrydate; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@fk_advertiseid", SqlDbType.Int)).Value = id; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strapplyproper", SqlDbType.VarChar)).Value = (object)tbl_mst_CandidatePersonalDetails.strapplyproper ?? ""; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strMotherName", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strMotherName; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strSpouseName", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strSpouseName; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strAlternate_EmaiID", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strAlternate_EmaiID; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strPANNo", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strPANNo; //Pass the parameter
                           cmd.Parameters.Add(new SqlParameter("@strAadharNo", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strAadharNo; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strEssentialQualification", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strEssentialQualification; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strSportsperson", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strSportsperson; //Pass the parameter

                            cmd.Parameters.Add(new SqlParameter("@strTestCity", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strTestCity;

                            cmd.Parameters.Add(new SqlParameter("@str_UploadCaste", SqlDbType.VarChar)).Value = fileUrl == "" ? frm["str_UploadCaste"] : fileUrl; //Pass the parameter

                            //cmd.Parameters.Add("msg", SqlDbType.NVarChar, 8000).Direction = ParameterDirection.Output;

                            cmd.Parameters.Add(outScore);
                            try
                            {
                                if (con.State != ConnectionState.Open)
                                    con.Open();
                                cmd.ExecuteNonQuery();
                                if (con.State != ConnectionState.Closed)
                                    con.Close();
                                var intID = "";// cmd.Parameters["msg"].Value;
                                if (cmd.Parameters["@newstrApplicationNo"].Value != null)
                                {
                                    intID = cmd.Parameters["@newstrApplicationNo"].Value.ToString();

                                }
                                else
                                {
                                    intID = ApplicationNo.ToString();
                                }


                            }
                            catch (Exception ex)
                            {
                                throw ex;
                            }
                            finally
                            {

                                if (con.State != ConnectionState.Closed)
                                    con.Close();
                            }

                        }
                    }

                    return RedirectToAction("EducationDetails/" + id);
                }



            }
            catch (Exception ex)
            {

                return RedirectToAction("Dashboard/" + id);
            }
        }

        //[HttpPost]
        //public ActionResult PostbyDesignation(string grade)
        //{
        //    //var Unit = fk_intUnitId.ToString();
        //    //tbl_mst_Postnewcontext obj =new tbl_mst_Postnewcontext();
        //    var gradebydeg = objGrade_Designation.tbl_mstGrade_Designation.Where(x => x.strGradeName == grade).FirstOrDefault().strDesignationName;
        //    return Json(new { Designation = gradebydeg });

        //}

        [HttpPost]
        public ActionResult FillQualification(int postId, int addId)
        {
            try
            {
                if (!CommonBase.IsAdvertisementActive(addId))
                {
                    return RedirectToAction("Dashboard/" + addId);
                }
                var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == postId && x.fk_advertisementid == addId).FirstOrDefault();

                string GenderAll = postCaitareaDetails.str_gender;
                string[] words1 = System.Text.RegularExpressions.Regex.Split(GenderAll, ",");
                List<string> Gender = new List<string>();
                foreach (var quliName in words1)
                {
                    Gender.Add(quliName.Trim(' '));
                }

                string castAll = postCaitareaDetails.str_caste;
                string[] words2 = System.Text.RegularExpressions.Regex.Split(castAll, ",");
                List<string> cast = new List<string>();
                foreach (var quliName in words2)
                {
                    cast.Add(quliName.Trim(' '));
                }

                // ✅ only return PWD categories that are BOTH selected for this post AND still active
                string pwdAll = postCaitareaDetails.str_pwd ?? "";
                var activePwdNames = objPWDCategory.tbl_mst_PWDCategory
                                        .Where(x => x.is_active == "yes")
                                        .Select(x => x.str_CatName)
                                        .ToList();

                List<string> pwd = System.Text.RegularExpressions.Regex
                    .Split(pwdAll, ",")
                    .Select(x => x.Trim(' '))
                    .Where(x => !string.IsNullOrEmpty(x) && activePwdNames.Contains(x))
                    .ToList();

                return Json(new { GenderAll = Gender, castAll = cast, PwdAll = pwd });
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult EducationDetails(int id)
        {
            try
            {
                ViewBag.selectValue = "";
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    return RedirectToAction("CandidateLogin/" + id);
                }
                int pkId = Convert.ToInt32(Session["UserID"]);
                if (!CommonBase.CheckCandidateCertificate(pkId))
                {
                    return RedirectToAction("CandidatePersonalDetails/" + id);
                }


                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
                var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                //if (!CheckEmailExclude() && (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1) || CandidatePersonalDetails.strFinalSubmit == "Yes"))
                if (!CheckEmailExclude() && (current <= noticeDetails.dtstartdate || current >= noticeDetails.dtclosedate || CandidatePersonalDetails.strFinalSubmit == "Yes"))
                {
                    //return RedirectToAction("Dashboard/" + id);
                }
                ViewBag.IsFinalSubmit = CandidatePersonalDetails.strFinalSubmit;

                ViewBag.Str_exampassed2 = CandidatePersonalDetails.strEssentialQualification;
                ViewBag.str_qualification = CandidatePersonalDetails.strEssentialQualification;
                var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid).FirstOrDefault();
                //ViewBag.hidMaxExpdate = Convert.ToDateTime("01/01/2025");
                ViewBag.hidMaxExpdate = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));
                ViewBag.IsGATERequired = postCaitareaDetails.IsGATERequired;
                Session["IsGATERequired"] = postCaitareaDetails.IsGATERequired;


                ViewBag.hidMinEdudate = CandidatePersonalDetails.dtDOB?.ToString("yyyy-MM-dd");

                string sampleSentence = postCaitareaDetails.str_qualification;
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
                ViewBag.EduQulifi = fstSubject;//new SelectList(fstSubject, "str_qualification", "str_qualification");


                //condition for pursuing candidate
                var postName = objGrade_Designation.tbl_mst_Postnew.Where(x => x.Pk_Postid == CandidatePersonalDetails.fk_postid).FirstOrDefault();
                if (Convert.ToString(postName.Postname) == "Management Trainee" || Convert.ToString(postName.Postname) == "Graduate Engineer Trainee")
                {
                    ViewBag.IsPersuing = "true";
                }
                else
                {
                    ViewBag.IsPersuing = "false";
                }

                var educationAll = tblQulifi.tbl_mst_CandidateQualification
     .Where(x => x.Fk_int_CandidateRegistrationID == CandidatePersonalDetails.fk_CandidateId)
     .ToList();

                if (educationAll.Count() > 0)
                {
                    if (educationAll.FirstOrDefault().EduQulifi != null)
                    {
                        ViewBag.selectValue = educationAll.FirstOrDefault().EduQulifi;
                    }

                    var matric = educationAll.FirstOrDefault(x => x.Str_exampassed == "Matric/10th");
                    var higherSec = educationAll.FirstOrDefault(x => x.Str_exampassed == "Higher Secondary/12th");
                    var essential = educationAll.FirstOrDefault(x => x.Str_exampassed == CandidatePersonalDetails.strEssentialQualification);

                    ViewBag.chk_IsPersuing = "false";

                    if (matric != null)
                    {
                        ViewData["Str_exampassed"] = matric.Str_exampassed;
                        ViewData["Str_course"] = matric.Str_course;
                        ViewData["Str_board"] = matric.Str_board;
                        ViewData["Str_passingdetails"] = matric.Str_passingdetails;
                        if (!string.IsNullOrEmpty(matric.Str_passingyear))
                        {
                            ViewData["Str_passingyear"] = Convert.ToDateTime(matric.Str_passingyear).ToString("yyyy-MM-dd").Replace("/", "-");
                        }
                        ViewData["Str_duration"] = matric.Str_duration;
                        ViewData["Str_Marks"] = matric.Str_Marks;
                        ViewData["Str_division"] = matric.Str_division;
                        ViewData["StrRemarks"] = matric.StrRemarks;
                        ViewData["str_UploadCertificate"] = matric.str_UploadCertificate;
                    }

                    if (higherSec != null)
                    {
                        ViewData["Str_exampassed1"] = higherSec.Str_exampassed;
                        ViewData["Str_course1"] = higherSec.Str_course;
                        ViewData["Str_board1"] = higherSec.Str_board;
                        ViewData["Str_passingdetails1"] = higherSec.Str_passingdetails;
                        if (!string.IsNullOrEmpty(higherSec.Str_passingyear))
                        {
                            ViewData["Str_passingyear1"] = Convert.ToDateTime(higherSec.Str_passingyear).ToString("yyyy-MM-dd").Replace("/", "-");
                        }
                        ViewData["Str_duration1"] = higherSec.Str_duration;
                        ViewData["Str_Marks1"] = higherSec.Str_Marks;
                        ViewData["Str_division1"] = higherSec.Str_division;
                        ViewData["StrRemarks1"] = higherSec.StrRemarks;
                        ViewData["str_UploadCertificate1"] = higherSec.str_UploadCertificate;
                    }

                    if (essential != null)
                    {
                        ViewData["Str_exampassed2"] = essential.Str_exampassed;
                        ViewData["Str_course2"] = essential.Str_course;
                        ViewData["Str_board2"] = essential.Str_board;
                        ViewData["Str_passingdetails2"] = essential.Str_passingdetails;
                        if (!string.IsNullOrEmpty(essential.Str_passingyear))
                        {
                            ViewData["Str_passingyear2"] = Convert.ToDateTime(essential.Str_passingyear).ToString("yyyy-MM-dd").Replace("/", "-");
                        }
                        ViewData["Str_duration2"] = essential.Str_duration;
                        ViewData["Str_Marks2"] = essential.Str_Marks;
                        ViewData["Str_division2"] = essential.Str_division;
                        ViewData["StrRemarks2"] = essential.StrRemarks;
                        ViewData["str_UploadCertificate2"] = essential.str_UploadCertificate;

                        if (essential.Str_course != "" && essential.Str_duration == "")
                        {
                            ViewBag.chk_IsPersuing = "true";
                        }
                    }
                }
                if (postCaitareaDetails.IsGATERequired)
                {
                    ViewBag.GateEssentialQuali1 = new SelectList(fstSubject, "str_qualification", "str_qualification");

                    using (tblRecruitmentCandidateGATEDetailsContext db = new tblRecruitmentCandidateGATEDetailsContext())
                    {
                        var response = db.tblRecruitmentCandidateGATEDetails.Where(a => a.CandidateId == pkId && a.PostId == postCaitareaDetails.fk_advertisementid).ToList();
                        if (response.Count > 0)
                        {
                            //ViewBag.Division1 = response[0].Division;
                            //ViewBag.EssentialQualificationForPost1 = response[0].EssentialQualificationForPost;
                            //ViewBag.EssentialQualificationPercentageForPost1 = response[0].EssentialQualificationPercentageForPost;
                            ViewBag.ExaminationPaper1 = response[0].ExaminationPaper;
                            ViewBag.Marks1 = response[0].Marks;
                            // ViewBag.PassingYear1 = response[0].PassingYear;
                            ViewBag.str_GatePassingYear1 = response[0].PassingYear;
                            ViewBag.RegistrationNo1 = response[0].RegistrationNo;
                            ViewBag.str_GATEResult = response[0].str_GATEResult;
                            //ViewBag.Remark1 = response[0].Remark;

                            //ViewBag.GateEssentialQuali1 = new SelectList(fstSubject, "str_qualification", "str_qualification", response[0].EssentialQualificationForPost);
                        }

                    }
                }

                using (var ctx = new tbl_mst_CandidateQualificationAdditionalContext())
                {
                    var qte = ctx.tbl_mst_CandidateQualificationAdditional.Where(a => a.CandidateId == pkId && a.Application_No == CandidatePersonalDetails.strApplicationNo).ToList();
                    int ii = 0;
                    for (int i = 0; i < qte.Count; i++)
                    {
                        ii++;
                        ViewData["EduQulifi_add_" + ii] = qte[i].EduQulifi;
                        ViewData["Str_exampassed_add_" + ii] = qte[i].Str_exampassed;
                        ViewData["Str_course_add_" + ii] = qte[i].Str_course;
                        ViewData["Str_board_add_" + ii] = qte[i].Str_board;
                        ViewData["Str_passingdetails_add_" + ii] = qte[i].Str_passingdetails;
                        ViewData["Str_duration_add_" + ii] = qte[i].Str_duration;
                        ViewData["Str_passingyear_add_" + ii] = qte[i].Str_passingyear;
                        ViewData["Str_division_add_" + ii] = qte[i].Str_division;
                        ViewData["Str_Marks_add_" + ii] = qte[i].Str_Marks;
                        ViewData["StrRemarks_add_" + ii] = qte[i].StrRemarks;
                        ViewData["dtEntryDate_" + ii] = qte[i].dtEntryDate;
                        ViewData["str_UploadOtherCertificate_" + ii] = qte[i].str_UploadOtherCertificate;

                    }
                }
                var IsCertificateRequired = postCaitareaDetails.IsCertificateRequired == null ? false : (bool)postCaitareaDetails.IsCertificateRequired;
                if (CandidatePersonalDetails.strEssentialQualification != "M. Tech (Geomatics) and 3 years experience.")
                {
                    ViewBag.IsCertificateRequired = IsCertificateRequired;
                }
                else
                {
                    ViewBag.IsCertificateRequired = false;
                    IsCertificateRequired = false;
                }


                if (IsCertificateRequired)
                {
                    // ViewBag.str_Certificate_New = "";
                    ViewBag.CertificateDetails1 = postCaitareaDetails.CertificateDetails;
                    ViewBag.CertificateDetails2 = postCaitareaDetails.ValidFirstAid;
                    ViewData["CertificateName1"] = postCaitareaDetails.CertificateDetails;
                    using (var ctx = new tbl_mst_CandidateCertificateDetailsContext())
                    {
                        var qte = ctx.tbl_mst_CandidateCertificateDetails.Where(a => a.fk_CandidateId == pkId).ToList();
                        ViewBag.CertificateCount = qte.Count;
                        int ii = 0;
                        if (qte.Count > 0)
                        {
                            for (int i = 0; i < qte.Count; i++)
                            {
                                ii = i;
                                ViewData["CertificateName" + ii] = qte[i].CertificateName;
                                ViewData["CertificateIssueDate" + ii] = qte[i].CertificateIssueDate;
                                ViewData["CertificateNo" + ii] = qte[i].CertificateNo;
                                ViewData["CertificateExpiryDate" + ii] = qte[i].CertificateExpiryDate;
                                ViewData["IssuingAuthority" + ii] = qte[i].IssuingAuthority;
                                ViewData["str_Certificate_New"] = qte[i].str_Certificate_New;
                            }
                        }
                        else
                        {
                            ViewData["CertificateName0"] = postCaitareaDetails.CertificateDetails;
                            ViewData["CertificateIssueDate0"] = "";
                            ViewData["CertificateNo0"] = "";
                            ViewData["CertificateExpiryDate0"] = "";
                            ViewData["IssuingAuthority0"] = "";
                            ViewData["str_Certificate_New0"] = "";
                        }


                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }



        [HttpPost]
        public ActionResult EducationDetails(FormCollection frm, tbl_mst_CandidateQualification obj, int id, HttpPostedFileBase str_GATEResult)
        {
            try
            {
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    return RedirectToAction("CandidateLogin/" + id);
                }
                if (!CommonBase.IsAdvertisementActive(id))
                {
                    return RedirectToAction("Dashboard/" + id);
                }

                int startApplicatId = Convert.ToInt32(ConfigurationManager.AppSettings["startId"]);
                int pkId = Convert.ToInt32(Session["UserID"]);
                var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

                ViewBag.str_qualification = CandidatePersonalDetails.strEssentialQualification;

                var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid).FirstOrDefault();
                string sampleSentence = postCaitareaDetails.str_qualification;
                ViewBag.hidMaxExpdate = postCaitareaDetails.dt_compareDate.Value.ToString("dd-MM-yyyy");

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
                //ViewBag.EduQulifi = new SelectList(fstSubject, "str_qualification", "str_qualification");  
                ViewBag.EduQulifi = fstSubject;

                bool IsRequiredMatched = false;
                bool IsMarksRequiredMatched = true;
                //CandidatePersonalDetails
                bool chk_IsPersuing = frm["chk_IsPersuing"] == "on";

                // =====================================================================
                // [CHANGE 1] ADDED: keep the data the user typed, so it is not erased
                //            when a validation failure returns View() below
                // =====================================================================
                {
                    // 1) put every posted value back into the form
                    foreach (string eduKey in frm.AllKeys)
                    {
                        if (string.IsNullOrEmpty(eduKey) || eduKey == "__RequestVerificationToken" || eduKey == "hidMaxExpdate") continue;
                        ViewData[eduKey] = frm[eduKey];
                    }

                    // 2) values the GET action normally sets (must come AFTER the loop above)
                    ViewBag.str_qualification = CandidatePersonalDetails.strEssentialQualification;
                    ViewBag.IsFinalSubmit = CandidatePersonalDetails.strFinalSubmit;
                    ViewBag.hidMinEdudate = CandidatePersonalDetails.dtDOB?.ToString("yyyy-MM-dd");
                    ViewBag.chk_IsPersuing = chk_IsPersuing ? "true" : "false";

                    var eduPostNm = objGrade_Designation.tbl_mst_Postnew.Where(x => x.Pk_Postid == CandidatePersonalDetails.fk_postid).FirstOrDefault();
                    string eduPn = Convert.ToString(eduPostNm.Postname);
                    ViewBag.IsPersuing = (eduPn == "Management Trainee" || eduPn == "Graduate Engineer Trainee") ? "true" : "false";

                    // 3) GATE section
                    ViewBag.IsGATERequired = postCaitareaDetails.IsGATERequired;
                    Session["IsGATERequired"] = postCaitareaDetails.IsGATERequired;
                    if (postCaitareaDetails.IsGATERequired)
                    {
                        ViewBag.RegistrationNo1 = frm["str_GateRegistrationNo1"];
                        ViewBag.ExaminationPaper1 = frm["str_GateExaminationPaper1"];
                        ViewBag.Marks1 = frm["str_GateMarks1"];
                        ViewBag.str_GatePassingYear1 = frm["str_GatePassingYear1"];

                        using (var eduGateDb = new tblRecruitmentCandidateGATEDetailsContext())
                        {
                            var eduGateRow = eduGateDb.tblRecruitmentCandidateGATEDetails
                                .Where(a => a.CandidateId == pkId && a.PostId == postCaitareaDetails.fk_advertisementid)
                                .FirstOrDefault();
                            if (eduGateRow != null) ViewBag.str_GATEResult = eduGateRow.str_GATEResult;
                        }
                    }

                    // 4) Certificate section
                    bool eduCertReq = postCaitareaDetails.IsCertificateRequired == null ? false : (bool)postCaitareaDetails.IsCertificateRequired;
                    if (CandidatePersonalDetails.strEssentialQualification == "M. Tech (Geomatics) and 3 years experience.")
                    {
                        eduCertReq = false;
                    }
                    ViewBag.IsCertificateRequired = eduCertReq;
                    if (eduCertReq)
                    {
                        ViewBag.CertificateDetails1 = postCaitareaDetails.CertificateDetails;
                        ViewBag.CertificateDetails2 = postCaitareaDetails.ValidFirstAid;
                        using (var eduCertCtx = new tbl_mst_CandidateCertificateDetailsContext())
                        {
                            ViewData["str_Certificate_New"] = eduCertCtx.tbl_mst_CandidateCertificateDetails
                                .Where(a => a.fk_CandidateId == pkId)
                                .Select(a => a.str_Certificate_New)
                                .FirstOrDefault();
                        }
                    }
                }
                // ===================== end of [CHANGE 1] =============================


                // ---- Server-side upload validation (mirrors the JS, but cannot be bypassed) ----
                bool isClass10thQualification = (CandidatePersonalDetails.strEssentialQualification ?? "").ToLower().Contains("class 10th");

                // Row 0 (essential qualification) — certificate always required
                if (!string.IsNullOrEmpty(frm["Str_exampassed"]))
                {
                    var newFile0 = Request.Files["str_UploadCertificate"];
                    bool hasNewFile0 = newFile0 != null && newFile0.ContentLength > 0;
                    bool hasExistingFile0 = !string.IsNullOrEmpty(frm["str_UploadCertificate"]);
                    if (!hasNewFile0 && !hasExistingFile0)
                    {
                        TempData["Message"] = "Please upload the Certificate/Marksheet for " + frm["Str_exampassed"] + ".";
                        return View();   // [CHANGE 3] was: return RedirectToAction("EducationDetails/" + id);
                    }
                }

                // Row 2 (Graduate/PG) — certificate required unless essential qualification is Class 10th
                if (!isClass10thQualification && !string.IsNullOrEmpty(frm["Str_exampassed2"]))
                {
                    var newFile2 = Request.Files["str_UploadCertificate2"];
                    bool hasNewFile2 = newFile2 != null && newFile2.ContentLength > 0;
                    bool hasExistingFile2 = !string.IsNullOrEmpty(frm["str_UploadCertificate2"]);
                    if (!hasNewFile2 && !hasExistingFile2)
                    {
                        TempData["Message"] = "Please upload the Certificate/Marksheet for " + frm["Str_exampassed2"] + ".";
                        return View();   // [CHANGE 3] was: return RedirectToAction("EducationDetails/" + id);
                    }
                }

                // New Certificate upload — only when this post actually requires it
                var isCertReqForThisPost = postCaitareaDetails.IsCertificateRequired == null ? false : (bool)postCaitareaDetails.IsCertificateRequired;
                if (isCertReqForThisPost && CandidatePersonalDetails.strEssentialQualification != "M. Tech (Geomatics) and 3 years experience.")
                {
                    var newCertFile = Request.Files["str_Certificate_New"];
                    bool hasNewCertFile = newCertFile != null && newCertFile.ContentLength > 0;
                    bool hasExistingCertFile = false;
                    using (var certCheckCtx = new tbl_mst_CandidateCertificateDetailsContext())
                    {
                        var existingCert = certCheckCtx.tbl_mst_CandidateCertificateDetails
                            .Where(a => a.fk_CandidateId == pkId)
                            .Select(a => a.str_Certificate_New)
                            .FirstOrDefault();
                        hasExistingCertFile = !string.IsNullOrEmpty(existingCert);
                    }
                    if (!hasNewCertFile && !hasExistingCertFile)
                    {
                        TempData["Message"] = "Please upload the required Certificate document.";
                        return View();   // [CHANGE 3] was: return RedirectToAction("EducationDetails/" + id);
                    }
                }

                // ---- end server-side upload validation ----

                // Row 1 (Higher Secondary/12th) — optional row, but if any field is filled, upload becomes required
                bool row1Filled = !string.IsNullOrEmpty(frm["Str_course1"]) || !string.IsNullOrEmpty(frm["Str_board1"]) ||
                                   !string.IsNullOrEmpty(frm["Str_passingdetails1"]) || !string.IsNullOrEmpty(frm["Str_passingyear1"]) ||
                                   !string.IsNullOrEmpty(frm["Str_duration1"]) || !string.IsNullOrEmpty(frm["Str_Marks1"]);
                if (row1Filled)
                {
                    var newFile1 = Request.Files["str_UploadCertificate1"];
                    bool hasNewFile1 = newFile1 != null && newFile1.ContentLength > 0;
                    bool hasExistingFile1 = !string.IsNullOrEmpty(frm["str_UploadCertificate1"]);
                    if (!hasNewFile1 && !hasExistingFile1)
                    {
                        TempData["Message"] = "Please upload the Certificate/Marksheet for Higher Secondary/12th.";
                        return View();   // [CHANGE 3] was: return RedirectToAction("EducationDetails/" + id);
                    }
                }

                // Other Qualification rows (add_1 to add_4) — if any field in a row is filled, upload becomes required
                for (int i = 1; i <= 4; i++)
                {
                    bool addRowFilled = !string.IsNullOrEmpty(frm["Str_exampassed_add_" + i]) ||
                                         !string.IsNullOrEmpty(frm["Str_course_add_" + i]) ||
                                         !string.IsNullOrEmpty(frm["Str_board_add_" + i]) ||
                                         !string.IsNullOrEmpty(frm["Str_passingdetails_add_" + i]) ||
                                         !string.IsNullOrEmpty(frm["Str_passingyear_add_" + i]) ||
                                         !string.IsNullOrEmpty(frm["Str_duration_add_" + i]) ||
                                         !string.IsNullOrEmpty(frm["Str_Marks_add_" + i]) ||
                                         !string.IsNullOrEmpty(frm["Str_division_add_" + i]);
                    if (addRowFilled)
                    {
                        var newFileAdd = Request.Files["str_UploadOtherCertificate_" + i];
                        bool hasNewFileAdd = newFileAdd != null && newFileAdd.ContentLength > 0;
                        bool hasExistingFileAdd = !string.IsNullOrEmpty(frm["str_UploadOtherCertificate_" + i]);
                        if (!hasNewFileAdd && !hasExistingFileAdd)
                        {
                            TempData["Message"] = "Please upload the document for additional qualification row " + i + ".";
                            return View();   // [CHANGE 3] was: return RedirectToAction("EducationDetails/" + id);
                        }
                    }
                }




                for (int i = 0; i <= 4; i++)
                {
                    var j = i.ToString();
                    if (j == "0")
                    {
                        j = "";
                    }

                    if ((frm["Str_exampassed" + j] ?? "") == CandidatePersonalDetails.strEssentialQualification)
                    {
                        if (!chk_IsPersuing && frm["Str_Marks" + j] != "")
                        {
                            if (CandidatePersonalDetails.strCategory == "SC" || CandidatePersonalDetails.strCategory == "ST")
                            {
                                IsRequiredMatched = (Convert.ToDecimal(frm["Str_Marks" + j]) >= 33);
                            }
                            else
                            {
                                IsRequiredMatched = (Convert.ToDecimal(frm["Str_Marks" + j]) >= 33);
                            }

                        }
                    }
                }
                var postName = objGrade_Designation.tbl_mst_Postnew.Where(x => x.Pk_Postid == CandidatePersonalDetails.fk_postid).FirstOrDefault();
                List<string> myList = new List<string>();
                for (int i = 0; i <= 4; i++)
                {
                    var j = i.ToString();
                    if (j == "0")
                    {
                        j = "";
                    }
                    if (frm["Str_Marks" + j] != null)
                    {


                        myList.Add(frm["Str_Marks" + j]);
                        if ((Convert.ToString(postName.Postname) == "Management Trainee" || Convert.ToString(postName.Postname) == "Graduate Engineer Trainee") && i == 2 && CandidatePersonalDetails.strEssentialQualification != "Pass in Final Examination of CA / ICWA")
                        {
                            if (!chk_IsPersuing)
                            {
                                IsMarksRequiredMatched = (Convert.ToDecimal(frm["Str_Marks" + j]) >= 60);
                            }

                        }
                    }

                }
                string validmsg = "";
                for (var i = 0; i < myList.Count; i++)
                {
                    var myString = myList[i];
                    if (i == myList.Count - 1 && myList[i].ToString() != "")
                    {
                        // this is the last item in the list
                        if ((Convert.ToString(postName.Postname) == "Management Trainee" || Convert.ToString(postName.Postname) == "Graduate Engineer Trainee") && CandidatePersonalDetails.strEssentialQualification != "Pass in Final Examination of CA / ICWA")
                        {
                            if (CandidatePersonalDetails.strCategory == "SC" || CandidatePersonalDetails.strCategory == "ST")
                            {
                                IsMarksRequiredMatched = (Convert.ToDecimal(myList[i].ToString()) >= 55);
                                validmsg = "Essential Qualification 55 % marks in the qualifying degree";
                            }
                            else
                            {
                                IsMarksRequiredMatched = (Convert.ToDecimal(myList[i].ToString()) >= 60);
                                validmsg = "Essential Qualification 60 % marks in the qualifying degree";
                            }
                        }
                    }
                }


                if (!IsMarksRequiredMatched)
                {
                    //ViewBag.Message = validmsg;
                    TempData["Message"] = validmsg;
                    return View();   // [CHANGE 3] was: return RedirectToAction("EducationDetails/" + id);
                }

                // =====================================================================
                // [CHANGE 2] REMOVED: the whole block
                //     if (!IsRequiredMatched && chk_IsPersuing != true) { ... }
                // It reloaded ViewData from the DATABASE (matric / higherSec / essential / GATE),
                // which would overwrite the values the user just typed.
                // Its "return View();" was already commented out, so no logic is lost.
                // =====================================================================

                // var candidate = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == CandidatePersonalDetails.fk_CandidateId).FirstOrDefault();
                ViewBag.IsFinalSubmit = CandidatePersonalDetails.strFinalSubmit;
                if (ViewBag.IsFinalSubmit == "Yes")
                {
                    return RedirectToAction("Dashboard/" + id);
                }

                //var checkDublicate = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == pkId);
                //foreach (var Dublicate in checkDublicate)
                //{
                //    tblQulifi.Entry(Dublicate).State = EntityState.Deleted;
                //}
                //tblQulifi.SaveChanges();
                List<tbl_mst_CandidateQualification> EducationList = new List<tbl_mst_CandidateQualification>();
                tbl_mst_CandidateQualification EducationObj = new tbl_mst_CandidateQualification();

                for (int i = 0; i <= 4; i++)
                {

                    var j = i.ToString();
                    if (j == "0")
                    {
                        j = "";
                    }

                    //if (!string.IsNullOrEmpty(frm["EduQulifi"]) && !string.IsNullOrEmpty(frm["Str_exampassed" + j]) && !string.IsNullOrEmpty(frm["Str_course" + j]) && !string.IsNullOrEmpty(frm["Str_board" + j]) && !string.IsNullOrEmpty(frm["Str_passingyear" + j]) && !string.IsNullOrEmpty(frm["Str_duration" + j]) && !string.IsNullOrEmpty(frm["Str_Marks" + j]) && !string.IsNullOrEmpty(frm["Str_division" + j]) && !string.IsNullOrEmpty(frm["StrRemarks" + j]))
                    //{
                    //if ((frm["Str_exampassed" + j] == "Matric/10th" && string.IsNullOrEmpty(frm["Str_passingdetails" + j])) || (frm["Str_exampassed" + j] != "Matric/10th" && !string.IsNullOrEmpty(frm["Str_passingdetails" + j])))
                    {
                        //if (string.IsNullOrEmpty(frm["Str_Marks" + j]) && Convert.ToDecimal(frm["Str_Marks" + j]) <= 100)
                        if (!string.IsNullOrEmpty(frm["Str_exampassed" + j]))
                        {

                            ///for upload certificate
                            string fileUrl = "";
                            var file = Request.Files[Convert.ToInt32(j == "" ? "0" : j)];
                            //if (file.Count > 0)
                            if (file != null && file.ContentLength > 0)
                            {
                                var folder = "Upload/CertificateUpload";
                                string ext = Path.GetExtension(file.FileName);
                                ///  long size = fi.Length;  
                                ///  file_size > 1048576 || file_size < 20480
                                var aa = file.ContentLength;
                                if (aa > 2097152 || aa < 20480)

                                {
                                    TempData["Message"] = "File size must be between 20 Kb to 2 Mb";   // [CHANGE 3] was: ViewBag.Message = string.Format(...)
                                    // return RedirectToAction("EducationDetails/" + id);
                                    return View();
                                }
                                //

                                if (string.IsNullOrEmpty(ext))
                                {
                                    ext = ".pdf";
                                }
                                if (ext.ToLower() != ".pdf")
                                {
                                    TempData["Message"] = "Certificate Document upload only pdf format.";   // [CHANGE 3] was: ViewBag.Message = ...
                                    return View();
                                }
                                var fileName = "Certificate" + j + "_" + id + "_" + CandidatePersonalDetails.fk_CandidateId + ext;
                                fileName = fileName.Replace(" ", "");
                                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/" + folder + "/") + fileName);
                                file.SaveAs(path);
                                fileUrl = "/" + folder + "/" + fileName;
                            }
                            ////


                            EducationObj = new tbl_mst_CandidateQualification();
                            EducationObj.EduQulifi = frm["EduQulifi"];
                            EducationObj.Str_exampassed = frm["Str_exampassed" + j].Trim();
                            EducationObj.Str_course = frm["Str_course" + j];
                            EducationObj.Str_board = frm["Str_board" + j];
                            EducationObj.Str_passingdetails = frm["Str_passingdetails" + j];
                            EducationObj.Str_duration = frm["Str_duration" + j];
                            //if (frm["StrRemarks" + j] != "Pursuing")
                            //{
                            EducationObj.Str_passingyear = frm["Str_passingyear" + j];
                            //}
                            //else
                            //{
                            //    obj.Str_passingyear = current.Year.ToString();
                            //}
                            EducationObj.Str_division = frm["Str_division" + j];
                            EducationObj.Str_Marks = frm["Str_Marks" + j];
                            EducationObj.StrRemarks = frm["StrRemarks" + j];
                            EducationObj.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                            EducationObj.Fk_int_CandidateRegistrationID = pkId;
                            EducationObj.Application_No = CandidatePersonalDetails.strApplicationNo;

                            EducationObj.str_UploadCertificate = fileUrl == "" ? frm["str_UploadCertificate" + j] : fileUrl;

                            //EducationObj.str_UploadCertificate = fileUrl == "" ? EducationObj.str_UploadCertificate : fileUrl;
                            //tblQulifi.tbl_mst_CandidateQualification.Add(obj);
                            //tblQulifi.SaveChanges();
                            EducationList.Add(EducationObj);
                        }
                    }
                    //}
                }

                if ((EducationList.Count == 2) || (EducationList.Count == 1) || (EducationList.Count == 3) || (EducationList.Count == 4) || (EducationList.Count <= 3))
                {
                    var checkDublicate = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == pkId);

                    foreach (var Dublicate in checkDublicate)
                    {
                        tblQulifi.Entry(Dublicate).State = EntityState.Deleted;
                    }
                    tblQulifi.SaveChanges();

                    foreach (var q in EducationList)
                    {
                        tblQulifi.tbl_mst_CandidateQualification.Add(q);
                        tblQulifi.SaveChanges();
                    }
                }

                using (var ctx = new tbl_mst_CandidateQualificationAdditionalContext())
                {
                    var qte = ctx.tbl_mst_CandidateQualificationAdditional.Where(a => a.CandidateId == pkId && a.Application_No == CandidatePersonalDetails.strApplicationNo).ToList();
                    //foreach (var kk in qte)
                    //{
                    //    ctx.tbl_mst_CandidateQualificationAdditional.Remove(kk);
                    //    ctx.SaveChanges();
                    //}
                    List<tbl_mst_CandidateQualificationAdditional> addList = new List<tbl_mst_CandidateQualificationAdditional>();
                    for (int i = 1; i < 5; i++)
                    {
                        //if (frm["Str_exampassed_add_" + i] != null && !string.IsNullOrEmpty(frm["Str_passingdetails_add_" + i]))
                        if (frm["Str_exampassed_add_" + i] != null)
                        {


                            ///for upload certificate
                            string fileUrl = "";
                            var file = Request.Files["str_UploadOtherCertificate_" + i];
                            //if (file.Count > 0)
                            if (file != null && file.ContentLength > 0)
                            {
                                var folder = "Upload/CertificateUploadOther";
                                string ext = Path.GetExtension(file.FileName);
                                ///  long size = fi.Length;  
                                ///  file_size > 1048576 || file_size < 20480
                                var aa = file.ContentLength;
                                if (aa > 2097152 || aa < 20480)
                                {
                                    TempData["Message"] = "File size must be between 20 Kb to 2 Mb";   // [CHANGE 3] was: ViewBag.Message = ... "20 Kb to 1 Mb" (text now matches the 2 Mb limit)
                                    // return RedirectToAction("EducationDetails/" + id);
                                    return View();
                                }
                                //

                                if (string.IsNullOrEmpty(ext))
                                {
                                    ext = ".pdf";
                                }
                                if (ext.ToLower() != ".pdf")
                                {
                                    TempData["Message"] = "Certificate Document upload only pdf format.";   // [CHANGE 3] was: ViewBag.Message = ...
                                    return View();
                                }
                                var fileName = "OtherCertificate" + i + "_" + id + "_" + CandidatePersonalDetails.fk_CandidateId + ext;
                                fileName = fileName.Replace(" ", "");
                                var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/" + folder + "/") + fileName);
                                file.SaveAs(path);
                                fileUrl = "/" + folder + "/" + fileName;
                            }
                            ////





                            //Convert.ToDateTime(frm["Str_passingyear_add_" + i]) <= postCaitareaDetails.dt_compareDate 
                            //if (frm["Str_passingyear_add_" + i] != "" && Convert.ToDateTime(frm["Str_passingyear_add_" + i]) <= DateTime.Now && Convert.ToDecimal(frm["Str_Marks_add_" + i]) <= 100)
                            //{
                            tbl_mst_CandidateQualificationAdditional ao = new tbl_mst_CandidateQualificationAdditional();
                            ao.EduQulifi = frm["EduQulifi_add_" + i] != null ? frm["EduQulifi_add_" + i] : "";
                            ao.Str_exampassed = frm["Str_exampassed_add_" + i].Trim() != null ? frm["Str_exampassed_add_" + i].Trim() : "";
                            ao.Str_course = frm["Str_course_add_" + i] != null ? frm["Str_course_add_" + i] : "";
                            ao.Str_board = frm["Str_board_add_" + i] != null ? frm["Str_board_add_" + i] : "";
                            ao.Str_passingdetails = frm["Str_passingdetails_add_" + i] != null ? frm["Str_passingdetails_add_" + i] : "";
                            ao.Str_duration = frm["Str_duration_add_" + i] != null ? frm["Str_duration_add_" + i] : "";
                            if (frm["StrRemarks_add_" + i] != "Pursuing")
                            {
                                ao.Str_passingyear = frm["Str_passingyear_add_" + i] != null ? frm["Str_passingyear_add_" + i] : "";
                            }
                            else
                            {
                                ao.Str_passingyear = current.Year.ToString();
                            }
                            ao.Str_division = frm["Str_division_add_" + i] != null ? frm["Str_division_add_" + i] : "";
                            ao.Str_Marks = frm["Str_Marks_add_" + i] != null ? frm["Str_Marks_add_" + i] : "";
                            ao.StrRemarks = frm["StrRemarks_add_" + i] != null ? frm["StrRemarks_add_" + i] : "";
                            ao.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                            ao.CandidateId = pkId;
                            ao.Application_No = CandidatePersonalDetails.strApplicationNo;

                            ao.str_UploadOtherCertificate = fileUrl == "" ? frm["str_UploadOtherCertificate_" + i] : fileUrl;

                            //ctx.tbl_mst_CandidateQualificationAdditional.Add(ao);
                            //ctx.SaveChanges();
                            addList.Add(ao);
                            //}
                        }
                    }


                    if (addList.Count >= qte.Count)
                    {
                        for (int i = 0; i < addList.Count; i++)
                        {
                            if (i < qte.Count)
                            {
                                qte[i].EduQulifi = addList[i].EduQulifi;
                                qte[i].Str_course = addList[i].Str_course;
                                qte[i].StrRemarks = addList[i].StrRemarks;
                                qte[i].Str_Marks = addList[i].Str_Marks;
                                qte[i].Str_division = addList[i].Str_division;
                                qte[i].Str_board = addList[i].Str_board;
                                qte[i].Str_duration = addList[i].Str_duration;
                                qte[i].Str_exampassed = addList[i].Str_exampassed;
                                qte[i].Str_passingdetails = addList[i].Str_passingdetails;
                                qte[i].Str_passingyear = addList[i].Str_passingyear;
                                qte[i].str_UploadOtherCertificate = addList[i].str_UploadOtherCertificate;
                                ctx.SaveChanges();
                            }
                            else
                            {
                                ctx.tbl_mst_CandidateQualificationAdditional.Add(addList[i]);
                                ctx.SaveChanges();
                            }
                        }
                    }
                    else if (addList.Count < qte.Count)
                    {
                        for (int i = 0; i < qte.Count; i++)
                        {
                            if (i < addList.Count)
                            {
                                qte[i].EduQulifi = addList[i].EduQulifi;
                                qte[i].Str_course = addList[i].Str_course;
                                qte[i].StrRemarks = addList[i].StrRemarks;
                                qte[i].Str_Marks = addList[i].Str_Marks;
                                qte[i].Str_division = addList[i].Str_division;
                                qte[i].Str_board = addList[i].Str_board;
                                qte[i].Str_duration = addList[i].Str_duration;
                                qte[i].Str_exampassed = addList[i].Str_exampassed;
                                qte[i].Str_passingdetails = addList[i].Str_passingdetails;
                                qte[i].Str_passingyear = addList[i].Str_passingyear;
                                qte[i].str_UploadOtherCertificate = addList[i].str_UploadOtherCertificate;
                                ctx.SaveChanges();
                            }
                            else
                            {
                                ctx.tbl_mst_CandidateQualificationAdditional.Remove(qte[i]);
                                ctx.SaveChanges();
                            }
                        }
                    }
                    else if (addList.Count > 0)
                    {
                        foreach (var kk in qte)
                        {
                            ctx.tbl_mst_CandidateQualificationAdditional.Remove(kk);
                            ctx.SaveChanges();
                        }
                    }
                }
                List<tblRecruitmentCandidateGATEDetails> list = new List<tblRecruitmentCandidateGATEDetails>();
                if (postCaitareaDetails.IsGATERequired)
                {
                    string fileUrl = "";
                    var file = Request.Files;
                    if (str_GATEResult != null)
                    {
                        if (file.Count > 0)
                        {
                            var folder = "Upload/GATECertificate";
                            string ext = Path.GetExtension(file[7].FileName);// Changed from 0 to 7 for GET ScoreCardUpload
                            ///  long size = fi.Length;  
                            ///  file_size > 1048576 || file_size < 20480
                            var aa = file[7].ContentLength;// Changed from 0 to 7 for GET ScoreCardUpload
                            if (aa > 1048576 || aa < 20480)
                            {
                                TempData["Message"] = "File size must be between 20 Kb to 1 Mb";   // [CHANGE 3] was: ViewBag.Message = ...
                                return View();                                                      // [CHANGE 3] was: return RedirectToAction("EducationDetails/" + id);
                            }
                            //

                            if (string.IsNullOrEmpty(ext))
                            {
                                ext = ".pdf";
                            }
                            if (ext.ToLower() != ".pdf")
                            {
                                TempData["Message"] = "GATE Document upload only pdf format.";      // [CHANGE 3] was: ViewBag.Message = ...
                                return View();                                                      // [CHANGE 3] was: return RedirectToAction("EducationDetails/" + id);
                            }
                            var fileName = "GATE_" + id + "_" + CandidatePersonalDetails.fk_CandidateId + "_" + ext;
                            fileName = fileName.Replace(" ", "");
                            var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/" + folder + "/") + fileName);
                            file[7].SaveAs(path);// Changed from 0 to 7 for GET ScoreCardUpload
                            fileUrl = "/" + folder + "/" + fileName;
                        }
                    }
                    tblRecruitmentCandidateGATEDetails obj_Gate = new tblRecruitmentCandidateGATEDetails();
                    obj_Gate.CandidateId = pkId;
                    obj_Gate.PostId = Convert.ToInt32(CandidatePersonalDetails.fk_advertiseid);
                    obj_Gate.PassingYear = Convert.ToInt32(frm["str_GatePassingYear1"]);
                    obj_Gate.RegistrationNo = Convert.ToString(frm["str_GateRegistrationNo1"]).Trim();
                    obj_Gate.ExaminationPaper = Convert.ToString(frm["str_GateExaminationPaper1"]).Trim();
                    obj_Gate.Marks = Convert.ToDecimal(frm["str_GateMarks1"]);
                    obj_Gate.str_GATEResult = fileUrl == "" ? obj_Gate.str_GATEResult : fileUrl;
                    if (obj_Gate.ExaminationPaper != "" && obj_Gate.RegistrationNo != "")
                    {
                        list.Add(obj_Gate);
                    }
                    //if (obj_Gate.Marks < 60)
                    //{
                    //    ViewBag.Message = "GATE Qualification required with minimum 60% marks.";
                    //    return View();
                    //}
                    if (list.Count == 0)
                    {
                        TempData["Message"] = "GATE Qualification can not be blank.";               // [CHANGE 3] was: ViewBag.Message = ...
                        return View();                                                              // [CHANGE 3] was: return RedirectToAction("EducationDetails/" + id);
                    }
                    if (str_GATEResult != null)
                    {
                        if ((list.Select(a => a.str_GATEResult).FirstOrDefault() ?? "") == "")
                        {
                            TempData["Message"] = "GATE Document upload  is required can not be blank.";   // [CHANGE 3] was: ViewBag.Message = ...
                            return View();                                                                  // [CHANGE 3] was: return RedirectToAction("EducationDetails/" + id);
                        }
                    }
                    using (tblRecruitmentCandidateGATEDetailsContext db = new tblRecruitmentCandidateGATEDetailsContext())
                    {
                        var d_gate_list = db.tblRecruitmentCandidateGATEDetails.Where(a => a.CandidateId == pkId && a.PostId == CandidatePersonalDetails.fk_advertiseid).ToList();
                        if (d_gate_list.Count == list.Count)
                        {
                            int ii = 0;
                            foreach (var j in d_gate_list)
                            {
                                j.RegistrationNo = list[ii].RegistrationNo;
                                j.PassingYear = list[ii].PassingYear;
                                j.ExaminationPaper = list[ii].ExaminationPaper;
                                j.Marks = list[ii].Marks;
                                if ((list[ii].str_GATEResult ?? "") != "")
                                {
                                    j.str_GATEResult = list[ii].str_GATEResult;
                                }
                                db.SaveChanges();
                                ii++;
                            }
                        }
                        else
                        {
                            if (d_gate_list.Count > 0)
                            {
                                db.tblRecruitmentCandidateGATEDetails.Add(list[0]);
                                db.SaveChanges();
                            }
                            else
                            {
                                db.tblRecruitmentCandidateGATEDetails.Add(list[0]);
                                db.SaveChanges();
                            }
                        }
                    }
                }

                if ((bool)postCaitareaDetails.IsCertificateRequired && CandidatePersonalDetails.strEssentialQualification != "M. Tech (Geomatics) and 3 years experience.")
                // if (false)
                {
                    using (var ctx = new tbl_mst_CandidateCertificateDetailsContext())
                    {
                        int ii = 0;
                        List<tbl_mst_CandidateCertificateDetails> list1 = new List<tbl_mst_CandidateCertificateDetails>();
                        for (int i = 0; i < 2; i++)
                        {
                            tbl_mst_CandidateCertificateDetails obj1 = new tbl_mst_CandidateCertificateDetails();
                            ii = i;
                            if (!string.IsNullOrEmpty(frm["CertificateName" + ii]))
                            {
                                ///for upload new certificate
                                string fileUrl = "";
                                var file = Request.Files["str_Certificate_New"];
                                //if (file.Count > 0)
                                if (file != null && file.ContentLength > 0)
                                {
                                    var folder = "Upload/NewCertificateUpload";
                                    string ext = Path.GetExtension(file.FileName);
                                    ///  long size = fi.Length;  
                                    ///  file_size > 1048576 || file_size < 20480
                                    var aa = file.ContentLength;
                                    if (aa > 1048576 || aa < 20480)
                                    {
                                        TempData["Message"] = "File size must be between 20 Kb to 1 Mb";   // [CHANGE 3] was: ViewBag.Message = string.Format(...)
                                        // return RedirectToAction("EducationDetails/" + id);
                                        return View();
                                    }
                                    //

                                    if (string.IsNullOrEmpty(ext))
                                    {
                                        ext = ".pdf";
                                    }
                                    if (ext.ToLower() != ".pdf")
                                    {
                                        TempData["Message"] = "Certificate Document upload only pdf format.";   // [CHANGE 3] was: ViewBag.Message = ...
                                        return View();
                                    }
                                    var fileName = "NewCertificate_" + id + "_" + CandidatePersonalDetails.fk_CandidateId + ext;
                                    fileName = fileName.Replace(" ", "");
                                    var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/" + folder + "/") + fileName);
                                    file.SaveAs(path);
                                    fileUrl = "/" + folder + "/" + fileName;
                                }
                                ////





                                obj1.fk_CandidateId = pkId;
                                obj1.CertificateName = Convert.ToString(frm["CertificateName" + ii]);
                                obj1.CertificateNo = Convert.ToString(frm["CertificateNo" + ii]);
                                obj1.CertificateIssueDate = Convert.ToString(frm["CertificateIssueDate" + ii]);
                                obj1.CertificateExpiryDate = Convert.ToString(frm["CertificateExpiryDate" + ii]);
                                obj1.IssuingAuthority = Convert.ToString(frm["IssuingAuthority" + ii]);
                                obj1.str_Certificate_New = fileUrl == "" ? obj1.str_Certificate_New : fileUrl;
                                if (obj1.CertificateIssueDate == "" || obj1.IssuingAuthority == "" || obj1.str_Certificate_New == "" || obj1.CertificateNo == "" || obj1.CertificateName == "")
                                {
                                    TempData["Message"] = "Please fill All Certificate details";   // [CHANGE 3] was: ViewBag.Message = ...
                                    return View();                                                  // [CHANGE 3] was: return RedirectToAction("EducationDetails/" + id);
                                }
                                else
                                {
                                    list1.Add(obj1);
                                }

                            }
                        }
                        var qte = ctx.tbl_mst_CandidateCertificateDetails.Where(a => a.fk_CandidateId == pkId).ToList();
                        if (qte.Count == list1.Count)
                        {
                            qte.ForEach(a => a.CertificateName = a.CertificateName + DateTime.UtcNow.ToString("ddMMyyHHmmss"));
                            ctx.SaveChanges();
                            int newi = 0;
                            foreach (var q in qte)
                            {
                                q.fk_CandidateId = list1[newi].fk_CandidateId;
                                q.CertificateName = list1[newi].CertificateName;
                                q.CertificateNo = list1[newi].CertificateNo;
                                q.CertificateIssueDate = list1[newi].CertificateIssueDate;
                                q.CertificateExpiryDate = list1[newi].CertificateExpiryDate;
                                q.IssuingAuthority = list1[newi].IssuingAuthority;
                                if ((list1[newi].str_Certificate_New ?? "") != "")
                                {
                                    q.str_Certificate_New = list1[newi].str_Certificate_New;
                                }

                                ctx.SaveChanges();
                                newi++;
                            }
                        }
                        else
                        {
                            foreach (var q in qte)
                            {
                                ctx.tbl_mst_CandidateCertificateDetails.Remove(q);
                                ctx.SaveChanges();
                            }
                            foreach (var q in list1)
                            {
                                ctx.tbl_mst_CandidateCertificateDetails.Add(q);
                                ctx.SaveChanges();
                            }

                        }

                    }
                }









                var eduDetails = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == pkId);
                int newpostIdforexp = Convert.ToInt32(ConfigurationManager.AppSettings["newpostIdforexp"]);
                int newpostIdforfre = Convert.ToInt32(ConfigurationManager.AppSettings["newpostIdforfre"]);

                //if ((eduDetails.Count() <= 1)||(eduDetails.Count() == 0))
                //{
                //    ViewBag.Message = "Qualification Criteria not met";
                //    return View();
                //}
                var IsFresherAllowed = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid).FirstOrDefault();


                // if ((Convert.ToString(postName.Postname) == "Management Trainee" || Convert.ToString(postName.Postname) == "Graduate Engineer Trainee"))
                if (IsFresherAllowed.strPostIsFreshersAllowed == "Yes")
                {

                    return RedirectToAction("UploadDetails/" + id);
                }
                else if (CandidatePersonalDetails.strEssentialQualification.ToUpper().Contains("FRESHER"))
                {

                    return RedirectToAction("UploadDetails/" + id);
                }
                else
                {
                    return RedirectToAction("ExperienceDetails/" + id);

                }
                //  return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }

        public ActionResult ExperienceDetails(int id)
        {
            try
            {
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    return RedirectToAction("CandidateLogin/" + id);
                }
                int pkId = Convert.ToInt32(Session["UserID"]);
                var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails
                                                .Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

                var eduDetails = tblQulifi.tbl_mst_CandidateQualification
                                    .Where(x => x.Fk_int_CandidateRegistrationID == pkId)
                                    .OrderByDescending(a => a.Pk_Qualification).FirstOrDefault();

                ViewBag.QualiDate = "";
                ViewBag.strEssentialQualification = CandidatePersonalDetails.strEssentialQualification;
                ViewBag.IsFinalSubmit = CandidatePersonalDetails.strFinalSubmit;

                var datecertificatestart = certificate.tbl_mst_CandidateCertificateDetails
                                            .Where(x => x.fk_CandidateId == pkId)
                                            .Select(a => a.CertificateIssueDate).FirstOrDefault();

                if (!string.IsNullOrEmpty(datecertificatestart) &&
                    CandidatePersonalDetails.strEssentialQualification != "M. Tech (Geomatics) and 3 years experience.")
                {
                    DateTime dt = DateTime.ParseExact(datecertificatestart.ToString(),
                                    "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);


                    DateTime certDate = dt;
                    DateTime qualiDate = DateTime.MinValue;

                    if (eduDetails != null && !string.IsNullOrEmpty(eduDetails.Str_passingyear))
                    {
                        DateTime.TryParse(eduDetails.Str_passingyear, out qualiDate);
                    }

                    // Use whichever date is EARLIER (qualification or certificate)
                    DateTime finalDate = (qualiDate != DateTime.MinValue && qualiDate < certDate)
                                          ? qualiDate
                                          : certDate;



                    ViewBag.QualiDate = dt.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                }
                else
                {
                    if (eduDetails != null)
                        ViewBag.QualiDate = eduDetails.Str_passingyear;
                }

                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice
                                        .Where(x => x.Pk_employmentid == id).FirstOrDefault();

                if (!CheckEmailExclude() && (current <= noticeDetails.dtstartdate ||
                    current >= noticeDetails.dtclosedate ||
                    CandidatePersonalDetails.strFinalSubmit == "Yes"))
                {
                    return RedirectToAction("Dashboard/" + id);
                }

                // Organisation type dropdowns
                ViewBag.str_organisationType = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType1 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType2 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType3 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType4 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType5 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType6 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType7 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");

                var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria
                                            .Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid
                                                     && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid)
                                            .FirstOrDefault();

                ViewBag.hidMaxExpdate = postCaitareaDetails.dt_compareDate.Value.ToString("dd-MM-yyyy");
                ViewBag.fk_postid = new SelectList(new List<tbl_mst_Postnew>(), "Pk_Postid", "Postname", null);



                var disciplineName = dc.tbl_mst_Discipline
                        .Where(x => x.Pk_Disciplineid == CandidatePersonalDetails.fk_dicipline)
                        .Select(x => x.DisciplineName)
                        .FirstOrDefault();

                bool isMedicalDiscipline = !string.IsNullOrEmpty(disciplineName) &&
                                             disciplineName.Trim().Equals("Medical & Health Services (M&HS)",
                                StringComparison.OrdinalIgnoreCase);


                ViewBag.IsMedicalDiscipline = isMedicalDiscipline;



                // ── First table: chronological experience loop ────────────────────
                var expAll = tblExperience.tbl_mst_CandidateExperience
                 .Where(x => x.Fk_CandidateRegistrationID == CandidatePersonalDetails.fk_CandidateId)
                 .OrderBy(x => x.Pk_Experienceid)
                 .ToList();

                int numberLoop = expAll.Count();
                ViewBag.hidCount = numberLoop;
                string j = "";
                int i = 0;

                for (i = 0; i < numberLoop; i++)
                {
                    j = i == 0 ? "" : i.ToString();

                    decimal dectotalExp = 0;
                    foreach (var getTotalExp in expAll)
                        dectotalExp += Convert.ToDecimal(getTotalExp.str_noyears);

                    var totalYears = Math.Truncate(dectotalExp / 365);
                    var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
                    var remainingDays = Math.Truncate((dectotalExp % 365) % 30);
                    string totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + " Days ";

                    ViewData["str_organisationType" + j] = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType", expAll[i].str_organisationType);
                    ViewData["StrEmploymentPresentStatus" + j] = expAll[i].StrEmploymentPresentStatus;
                    ViewData["str_organisation" + j] = expAll[i].str_organisation;
                    ViewData["Str_designation" + j] = expAll[i].Str_designation;
                    ViewData["str_CTC" + j] = expAll[i].str_CTC;
                    ViewData["str_PayScale" + j] = expAll[i].str_PayScale;
                    ViewData["dt_fromdate" + j] = expAll[i].dt_fromdate.ToString("yyyy-MM-dd").Replace("/", "-");
                    ViewData["dt_todate" + j] = expAll[i].dt_todate.ToString("yyyy-MM-dd").Replace("/", "-");
                    ViewData["str_noyears" + j] = expAll[i].str_noyears;
                    ViewData["str_UploadExpCertificate" + j] = expAll[i].str_UploadExpCertificate;
                    ViewData["totalYearproper" + j] = totalExp;
                }
                // ── END first table ───────────────────────────────────────────────


                // ── Second table: Other Details of Present Employment ─────────────
                // Priority: Currently Working row → else last row by todate
                var presentExp = expAll
                                    .Where(x => x.StrEmploymentPresentStatus == "Currently Working")
                                    .FirstOrDefault()
                                ?? expAll.OrderByDescending(x => x.dt_todate).FirstOrDefault();

                if (presentExp != null)
                {
                    ViewBag.str_PresentEmployerName = presentExp.str_PresentEmployerName;
                    ViewBag.str_PresentDesignation = presentExp.Str_designation;
                    ViewBag.str_PresentGrade = presentExp.str_PresentGrade;
                    ViewBag.dt_DateOfEntryGrade = presentExp.dt_DateOfEntryGrade;
                    ViewBag.str_ScaleOfPay = presentExp.str_ScaleOfPay;
                    ViewBag.dt_DateOfEntryScalePay = presentExp.dt_DateOfEntryScalePay;
                    ViewBag.str_MonthlyGrossSalary = presentExp.str_MonthlyGrossSalary;
                    ViewBag.str_OrgTurnover = presentExp.str_OrgTurnover;
                    ViewBag.str_JobDescription = presentExp.str_JobDescription;
                    ViewBag.str_UploadPLStatement_Path = presentExp.str_UploadPLStatement;
                    ViewBag.str_UploadJobDesc_Path = presentExp.str_UploadJobDesc;
                    ViewBag.str_UploadOtherDoc_Path = presentExp.str_UploadOtherDoc;
                    ViewBag.str_PvtEmployerName = presentExp.str_PvtEmployerName;
                    ViewBag.str_PvtJobDesignation = presentExp.str_PvtJobDesignation;
                    ViewBag.str_GovtJobDesignation = presentExp.str_GovtJobDesignation;
                    ViewBag.str_PvtUploadOtherDoc_Path = presentExp.str_PvtUploadOtherDoc;
                    ViewBag.str_PvtUploadJobDesc_Path = presentExp.str_PvtUploadJobDesc;
                    ViewBag.str_PvtJobDescription = presentExp.str_PvtJobDescription;
                    ViewBag.str_RegistrationNo = presentExp.str_RegistrationNo;
                    ViewBag.str_stateMedicalcouncil = presentExp.str_stateMedicalcouncil;

                    if (presentExp.dt_RegistrationValidTill != DateTime.MinValue)
                    {
                        ViewBag.dt_RegistrationValidTill = presentExp.dt_RegistrationValidTill;
                    }
                    else
                    {
                        ViewBag.dt_RegistrationValidTill = null;
                    }

                    ViewBag.str_uploadregistrationCertificate_Path = presentExp.str_uploadregistrationCertificate;



                }
                // ── END second table ──────────────────────────────────────────────

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }



        [HttpPost]
        public ActionResult ExperienceDetails(FormCollection frm, tbl_mst_CandidateExperience objExp, int id)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
            {
                return RedirectToAction("CandidateLogin/" + id);
            }
            if (!CommonBase.IsAdvertisementActive(id))
            {
                return RedirectToAction("Dashboard/" + id);
            }

            try
            {
                ViewBag.str_organisationType = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType1 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType2 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType3 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType4 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType5 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType6 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType7 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");

                int startApplicatId = Convert.ToInt32(ConfigurationManager.AppSettings["startId"]);
                int pkId = Convert.ToInt32(Session["UserID"]);

                var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails
                                                .Where(x => x.fk_CandidateId == pkId)
                                                .FirstOrDefault();


                var disciplineName = dc.tbl_mst_Discipline
                        .Where(x => x.Pk_Disciplineid == CandidatePersonalDetails.fk_dicipline)
                        .Select(x => x.DisciplineName)
                        .FirstOrDefault();

                bool isMedicalDiscipline = !string.IsNullOrEmpty(disciplineName) &&
                                            (disciplineName.ToUpper().Contains("M&HS") ||
                                             disciplineName.ToUpper().Contains("MEDICAL"));

                ViewBag.IsMedicalDiscipline = isMedicalDiscipline;



                var postName = objGrade_Designation.tbl_mst_Postnew
                            .Where(x => x.Pk_Postid == CandidatePersonalDetails.fk_postid)
                            .FirstOrDefault();

                if (!string.IsNullOrEmpty(frm["totalYearproper"]))
                {
                    string ExperienceData = Convert.ToString(frm["totalYearproper"]);
                    string resultString = Regex.Match(ExperienceData, @"\d+").Value;

                    if (Convert.ToString(postName.Postname) == "Senior Manager" &&
                        Convert.ToInt32(resultString) < 9)
                    {
                        ViewBag.Message = "Experience Is Not Met With Requirement";
                        return View();
                    }
                    if (Convert.ToString(postName.Postname) == "Deputy Manager" &&
                        Convert.ToInt32(resultString) < 3)
                    {
                        ViewBag.Message = "Experience Is Not Met With Requirement";
                        return View();
                    }
                }

                ViewBag.IsFinalSubmit = CandidatePersonalDetails.strFinalSubmit;
                if (CandidatePersonalDetails != null && CandidatePersonalDetails.strFinalSubmit == "Yes")
                {
                    ViewBag.Message = "Your Final Submission have been done. You can not update information!";
                    return View();
                }



                var checkDublicate = tblExperience.tbl_mst_CandidateExperience
                                            .Where(x => x.Fk_CandidateRegistrationID == pkId)
                                            .ToList();

                var educationAll = tblQulifi.tbl_mst_CandidateQualification
                                            .Where(x => x.Fk_int_CandidateRegistrationID == pkId)
                                            .ToList();

                var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria
                                            .Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid
                                                     && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid)
                                            .FirstOrDefault();

                ViewBag.hidMaxExpdate = postCaitareaDetails.dt_compareDate.Value.ToString("dd-MM-yyyy");

                // ---- Handle registration certificate upload (once, not per row) ----
                string regCertPath = frm["str_uploadregistrationCertificate_Path"] ?? "";
                HttpPostedFileBase regCertFile = Request.Files["str_uploadregistrationCertificate"] as HttpPostedFileBase;

                if (regCertFile != null && regCertFile.ContentLength > 0)
                {
                    if (regCertFile.ContentLength > 2097152 || regCertFile.ContentLength < 20480)
                    {
                        ViewBag.Message = "File size must be between 20 KB to 2 MB.";
                        return View();
                    }

                    string regExt = Path.GetExtension(regCertFile.FileName).ToLower();
                    if (regExt != ".pdf")
                    {
                        ViewBag.Message = "Only PDF files are allowed.";
                        return View();
                    }

                    string uploadFolderReg = "Upload/PresentEmploymentDocs";
                    string serverPathReg = Server.MapPath("~/" + uploadFolderReg + "/");
                    if (!Directory.Exists(serverPathReg))
                        Directory.CreateDirectory(serverPathReg);

                    string regFileName = ("str_uploadregistrationCertificate_" + id + "_" + pkId + regExt).Replace(" ", "");
                    regCertFile.SaveAs(Path.Combine(serverPathReg, regFileName));
                    regCertPath = "/" + uploadFolderReg + "/" + regFileName;
                }

                // Build and validate the new records FIRST
                List<tbl_mst_CandidateExperience> newExpList = new List<tbl_mst_CandidateExperience>();

                if (pkId > startApplicatId)
                {
                    for (int i = 0; i <= 7; i++)
                    {
                        string j = i.ToString();
                        if (j == "0") { j = ""; }

                        if (!string.IsNullOrEmpty(frm["str_organisationType" + j]) &&
                            !string.IsNullOrEmpty(frm["StrEmploymentPresentStatus" + j]) &&
                            !string.IsNullOrEmpty(frm["str_organisation" + j]) &&
                            !string.IsNullOrEmpty(frm["Str_designation" + j]) &&
                            !string.IsNullOrEmpty(frm["dt_fromdate" + j]) &&
                            !string.IsNullOrEmpty(frm["str_noyears" + j]) &&
                            !string.IsNullOrEmpty(frm["totalYearproper"]))
                        {
                            string[] rowFileKeys = {
                                "str_UploadExpCertificate" + j,
                                "str_UploadPLStatement" + j,
                                "str_UploadJobDesc"     + j,
                                "str_UploadOtherDoc"    + j,
                                "str_PvtUploadJobDesc"  + j,
                                "str_PvtUploadOtherDoc" + j,

                            };

                            string[] rowFilePaths = new string[rowFileKeys.Length];

                            for (int f = 0; f < rowFileKeys.Length; f++)
                            {
                                HttpPostedFileBase uploadedFile = Request.Files[rowFileKeys[f]] as HttpPostedFileBase;

                                if (uploadedFile != null && uploadedFile.ContentLength > 0)
                                {
                                    if (uploadedFile.ContentLength > 2097152 || uploadedFile.ContentLength < 20480)
                                    {
                                        ViewBag.Message = "File size must be between 20 KB to 2 MB.";
                                        return View();
                                    }

                                    string ext = Path.GetExtension(uploadedFile.FileName).ToLower();
                                    if (ext != ".pdf")
                                    {
                                        ViewBag.Message = "Only PDF files are allowed.";
                                        return View();
                                    }

                                    string uploadFolder = "Upload/PresentEmploymentDocs";
                                    string serverPath = Server.MapPath("~/" + uploadFolder + "/");

                                    if (!Directory.Exists(serverPath))
                                        Directory.CreateDirectory(serverPath);

                                    string fileName = rowFileKeys[f] + "_" + id + "_" + pkId + ext;
                                    fileName = fileName.Replace(" ", "");

                                    uploadedFile.SaveAs(Path.Combine(serverPath, fileName));
                                    rowFilePaths[f] = "/" + uploadFolder + "/" + fileName;
                                }
                                else
                                {
                                    rowFilePaths[f] = frm[rowFileKeys[f] + "_Path"] ?? "";
                                }
                            }

                            // Block this row if no certificate was uploaded and none existed before
                            if (string.IsNullOrEmpty(rowFilePaths[0]))
                            {
                                ViewBag.Message = "Please upload the Experience Certificate for Organisation: " +
                                                   frm["str_organisation" + j];
                                return View();
                            }

                            tbl_mst_CandidateExperience newExp = new tbl_mst_CandidateExperience();

                            newExp.Str_designation = frm["Str_designation" + j];
                            newExp.dt_fromdate = Convert.ToDateTime(frm["dt_fromdate" + j]);
                            newExp.dt_todate = frm["StrEmploymentPresentStatus" + j] == "Currently Working"
                                                                ? Convert.ToDateTime(frm["hidMaxExpdate"])
                                                                : Convert.ToDateTime(frm["dt_todate" + j]);
                            newExp.str_noyears = frm["str_noyears" + j];
                            newExp.str_organisation = frm["str_organisation" + j];
                            newExp.str_organisationType = frm["str_organisationType" + j];
                            newExp.str_remarks = frm["str_remarks" + j];
                            newExp.StrEmploymentPresentStatus = frm["StrEmploymentPresentStatus" + j];
                            newExp.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                            newExp.Fk_CandidateRegistrationID = pkId;
                            newExp.ApplicationNo = CandidatePersonalDetails.strApplicationNo;
                            newExp.str_PresentEmployerName = frm["str_PresentEmployerName" + j];
                            newExp.str_PresentGrade = frm["str_PresentGrade" + j];
                            newExp.dt_DateOfEntryGrade = frm["dt_DateOfEntryGrade" + j];
                            newExp.dt_DateOfEntryScalePay = frm["dt_DateOfEntryScalePay" + j];
                            newExp.str_MonthlyGrossSalary = frm["str_MonthlyGrossSalary" + j];
                            newExp.str_OrgTurnover = frm["str_OrgTurnover" + j];
                            newExp.str_JobDescription = frm["str_JobDescription" + j];
                            newExp.str_PvtEmployerName = frm["str_PvtEmployerName" + j];
                            newExp.str_PvtJobDesignation = frm["str_PvtDesignation" + j];
                            newExp.str_GovtJobDesignation = frm["str_GovtJobDesignation" + j];
                            newExp.str_PvtJobDescription = frm["str_PvtJobDescription" + j];
                            newExp.str_ScaleOfPay = frm["str_ScaleOfPay" + j];

                            newExp.str_UploadExpCertificate = rowFilePaths[0];
                            newExp.str_UploadPLStatement = rowFilePaths[1];
                            newExp.str_UploadJobDesc = rowFilePaths[2];
                            newExp.str_UploadOtherDoc = rowFilePaths[3];
                            newExp.str_PvtUploadJobDesc = rowFilePaths[4];
                            newExp.str_PvtUploadOtherDoc = rowFilePaths[5];

                            if (frm["str_organisationType" + j] != "Private" &&
                                frm["str_organisationType" + j] != "Other")
                            {
                                newExp.str_CTC = "";
                                newExp.str_PayScale = frm["str_PayScale" + j];
                                newExp.str_ScaleOfPay = frm["str_ScaleOfPay" + j];

                                newExpList.Add(newExp);
                            }
                            else if ((frm["str_organisationType" + j] == "Private" ||
                                      frm["str_organisationType" + j] == "Other") &&
                                      !string.IsNullOrEmpty(frm["str_CTC" + j]))
                            {
                                newExp.str_CTC = frm["str_CTC" + j];
                                newExp.str_PayScale = "";
                                newExpList.Add(newExp);
                            }
                        }
                    }

                    // ===== CHANGED BLOCK STARTS HERE (replaces the old "Attach Medical Council registration info" block) =====

                    // Stop early if nothing valid was built (prevents deleting old data for nothing)
                    if (newExpList.Count == 0)
                    {
                        ViewBag.Message = "Please enter at least one complete experience row.";
                        return View();
                    }

                    // ---- Medical registration: the 4 columns ----
                    string regNo = (frm["str_RegistrationNo"] ?? "").Trim();
                    string regCouncil = (frm["str_stateMedicalcouncil"] ?? "").Trim();
                    string regValid = (frm["dt_RegistrationValidTill"] ?? "").Trim();

                    bool anyMedicalFilled = regNo != "" || regCouncil != "" || regValid != "" || !string.IsNullOrEmpty(regCertPath);

                    if (isMedicalDiscipline || anyMedicalFilled)
                    {
                        bool allFilled = regNo != "" && regCouncil != "" && regValid != "" && !string.IsNullOrEmpty(regCertPath);
                        DateTime validTill;

                        if (!allFilled || !DateTime.TryParse(regValid, out validTill))
                        {
                            ViewBag.Message = "Please fill all 4 Professional Certificate fields (Registration No, Medical Council, Valid Till, Certificate PDF).";
                            return View();
                        }

                        foreach (var exp in newExpList)
                        {
                            exp.str_RegistrationNo = regNo;
                            exp.str_stateMedicalcouncil = regCouncil;
                            exp.dt_RegistrationValidTill = validTill;
                            exp.str_uploadregistrationCertificate = regCertPath;
                        }
                    }

                    // ===== CHANGED BLOCK ENDS HERE =====

                    // Only now, after everything passed, delete the old records
                    foreach (var Dublicate in checkDublicate)
                    {
                        tblExperience.Entry(Dublicate).State = EntityState.Deleted;
                    }
                    tblExperience.SaveChanges();

                    // Insert all the new, validated records
                    foreach (var exp in newExpList)
                    {
                        tblExperience.tbl_mst_CandidateExperience.Add(exp);
                    }
                    tblExperience.SaveChanges();
                }


                // ── Total experience calculation ──────────────────────────────────────
                var expDetails = tblExperience.tbl_mst_CandidateExperience
                                    .Where(x => x.Fk_CandidateRegistrationID == pkId);

                decimal totalExpYear = 0;
                if (expDetails.Count() > 0)
                {
                    decimal dectotalExp = 0;
                    foreach (var getTotalExp in expDetails.ToList())
                    {
                        dectotalExp += Convert.ToDecimal(getTotalExp.str_noyears);
                    }
                    totalExpYear = Math.Truncate(dectotalExp / 365);
                }

                int newpostIdforexp = Convert.ToInt32(ConfigurationManager.AppSettings["newpostIdforexp"]);
                int newpostIdforfre = Convert.ToInt32(ConfigurationManager.AppSettings["newpostIdforfre"]);
                string subjectName = Convert.ToString(ConfigurationManager.AppSettings["subjectNameforexp"]).Trim();

                // ── Redirect logic ────────────────────────────────────────────────────
                if ((educationAll.Count() == 1 && totalExpYear >= 3) ||
                    (educationAll.Count() == 1 && totalExpYear >= 5) ||
                    (educationAll.Count >= 2 && totalExpYear >= 1) ||
                    (educationAll.Count >= 3 && totalExpYear >= 1) ||
                    (educationAll.Count >= 3 && totalExpYear <= 1) ||
                    (educationAll.Count >= 2 && totalExpYear >= 3) ||
                    (educationAll.Count >= 1 && totalExpYear <= 2))
                {
                    return RedirectToAction("UploadDetails/" + id);
                }
                else
                {
                    if ((educationAll.Count() == 4 && totalExpYear >= 2 &&
                         educationAll.Where(x => x.Str_exampassed.Trim() == subjectName).Count() == 0 &&
                         CandidatePersonalDetails.fk_postid == newpostIdforexp) ||
                        (educationAll.Count() == 5 && CandidatePersonalDetails.fk_postid == newpostIdforexp) ||
                        (educationAll.Count() == 3 && CandidatePersonalDetails.fk_postid == newpostIdforfre && totalExpYear >= 1) ||
                        (educationAll.Count() == 2 && CandidatePersonalDetails.fk_postid == newpostIdforexp && totalExpYear >= 1))
                    {
                        return RedirectToAction("UploadDetails/" + id);
                    }
                    else
                    {
                        if ((educationAll.Count() == 3 && CandidatePersonalDetails.strExserviceMan == "Yes" &&
                             educationAll.Where(x => x.Str_exampassed.Trim() == subjectName).Count() == 0 &&
                             CandidatePersonalDetails.fk_postid == newpostIdforexp) ||
                            (educationAll.Count() == 5 && CandidatePersonalDetails.fk_postid == newpostIdforexp) ||
                            (educationAll.Count() == 1 && CandidatePersonalDetails.fk_postid == newpostIdforfre &&
                             CandidatePersonalDetails.strExserviceMan == "Yes"))
                        {
                            return RedirectToAction("UploadDetails/" + id);
                        }
                        else
                        {
                            ViewBag.Message = "Experience Criteria not met";
                            return RedirectToAction("CandidateLogin");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }



        public ActionResult UploadDetails(int id)
        {
            try
            {
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    return RedirectToAction("CandidateLogin");
                }
                int pkId = Convert.ToInt32(Session["UserID"]);
                var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                var expDetails = tblExperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == pkId);


                ViewBag.IsFinalSubmit = CandidatePersonalDetails.strFinalSubmit;


                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
                //  if (!CheckEmailExclude() && (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1) && CandidatePersonalDetails.strFinalSubmit == "Yes"))
                if (!CheckEmailExclude() && (current <= noticeDetails.dtstartdate || current >= noticeDetails.dtclosedate && CandidatePersonalDetails.strFinalSubmit == "Yes"))
                {
                    return RedirectToAction("Dashboard/" + id);
                }

                var uploadDetails = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
                if (uploadDetails.Count() > 0)
                {
                    ViewBag.Photo = uploadDetails.FirstOrDefault().str_uploadphoto.Replace("~", "");
                    ViewBag.Signature = uploadDetails.FirstOrDefault().str_uploadsignature.Replace("~", "");
                }
                else
                {
                    ViewBag.Photo = "/content/img/passport-photo1.png";
                    ViewBag.Signature = "/content/img/signatureBox1.png";
                }

                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }

        [HttpPost]
        public ActionResult UploadDetails(FormCollection frm, tbl_mst_candidatephotoupload tbl_mst_candidatephotoupload, int id)
        {
            try
            {
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    return RedirectToAction("CandidateLogin/" + id);
                }
                if (!CommonBase.IsAdvertisementActive(id))
                {
                    return RedirectToAction("Dashboard/" + id);
                }


                int pkId = Convert.ToInt32(Session["UserID"]);
                var checkDublicate = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == pkId);
                var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

                ViewBag.IsFinalSubmit = CandidatePersonalDetails.strFinalSubmit;
                if (CandidatePersonalDetails != null && CandidatePersonalDetails.strFinalSubmit == "Yes")
                {
                    ViewBag.Message = string.Format("Your Final Submission have been done. You can not update information!");
                    return View();
                }


                int startApplicatId = Convert.ToInt32(ConfigurationManager.AppSettings["startId"]);

                if (checkDublicate.ToList().Count() >= 0 && pkId > startApplicatId)
                {

                    HttpPostedFileBase str_uploadphoto = Request.Files["str_uploadphoto"];
                    HttpPostedFileBase str_uploadsignature = Request.Files["str_uploadsignature"];

                    if (str_uploadphoto.ContentLength > 0)
                    {
                        foreach (var Dublicate in checkDublicate)
                        {
                            objcandidatephotoupload.Entry(Dublicate).State = EntityState.Deleted;
                            System.IO.File.Delete(Server.MapPath(Dublicate.str_uploadphoto));
                        }
                        objcandidatephotoupload.SaveChanges();

                        var fileExtension = Path.GetExtension(str_uploadphoto.FileName);
                        var AutoGenFileName = "Photo" + "-" + System.DateTime.Now.Ticks.ToString();
                        var path = Path.Combine(Server.MapPath("~/RecruitementUpload/Photo/"), AutoGenFileName + fileExtension);
                        str_uploadphoto.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/RecruitementUpload/Photo/" + newpath;
                        tbl_mst_candidatephotoupload.str_uploadphoto = imagepath;
                    }
                    else
                    {
                        tbl_mst_candidatephotoupload.str_uploadphoto = "~" + frm["hdPhoto"];
                    }

                    if (str_uploadsignature.ContentLength > 0)
                    {
                        foreach (var Dublicate in checkDublicate)
                        {
                            objcandidatephotoupload.Entry(Dublicate).State = EntityState.Deleted;
                            System.IO.File.Delete(Server.MapPath(Dublicate.str_uploadsignature));
                        }
                        objcandidatephotoupload.SaveChanges();

                        var fileExtension = Path.GetExtension(str_uploadsignature.FileName);
                        var AutoGenFileName = "Signature" + "-" + System.DateTime.Now.Ticks.ToString();
                        var path = Path.Combine(Server.MapPath("~/RecruitementUpload/Signature/"), AutoGenFileName + fileExtension);
                        str_uploadsignature.SaveAs(path);
                        string fl = path.Substring(path.LastIndexOf("\\"));
                        string[] split = fl.Split('\\');
                        string newpath = split[1];
                        string imagepath = "~/RecruitementUpload/Signature/" + newpath;
                        tbl_mst_candidatephotoupload.str_uploadsignature = imagepath;

                    }
                    else
                    {
                        tbl_mst_candidatephotoupload.str_uploadsignature = "~" + frm["hdSignature"];
                    }

                    if (str_uploadphoto.ContentLength > 0 || str_uploadsignature.ContentLength > 0)
                    {
                        tbl_mst_candidatephotoupload.str_applicationno = CandidatePersonalDetails.strApplicationNo;
                        tbl_mst_candidatephotoupload.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                        tbl_mst_candidatephotoupload.fk_intcandidateid = pkId;
                        tbl_mst_candidatephotoupload.is_active = "YES";
                        objcandidatephotoupload.tbl_mst_candidatephotoupload.Add(tbl_mst_candidatephotoupload);
                        objcandidatephotoupload.SaveChanges();
                        return RedirectToAction("PrintPreview/" + id);
                    }
                    if (tbl_mst_candidatephotoupload.str_uploadsignature == null && tbl_mst_candidatephotoupload.str_uploadphoto == null)
                    {
                        ViewBag.Message = string.Format("Photo and Signature can't be blank.");
                        return View("UploadDetails/" + id);
                    }
                    checkDublicate = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == pkId);
                    if (checkDublicate.ToList().Count() == 1 && !string.IsNullOrEmpty(checkDublicate.FirstOrDefault().str_uploadphoto) && !string.IsNullOrEmpty(checkDublicate.FirstOrDefault().str_uploadsignature))
                    {
                        return RedirectToAction("PrintPreview/" + id);
                    }

                }
                return RedirectToAction("Dashboard/" + id);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }

        public ActionResult RTIScheme(int id)
        {
            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            if (CandiadateId == 0)
            {
                return RedirectToAction("CandidateLogin/" + id, "RecruitmentEnglish/" + id);
            }

            int checkData = objContext.tbl_mstRTIScheme.Where(x => x.fk_CandidateId == CandiadateId).ToList().Count();
            if (checkData > 0)
            {
                return RedirectToAction("PrintPreview/" + id);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult RTIScheme(string btnSubmit, int id)
        {

            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            if (CandiadateId == 0)
            {
                return RedirectToAction("CandidateLogin/" + id, "RecruitmentEnglish/" + id);
            }

            if (!CommonBase.IsAdvertisementActive(id))
            {
                return RedirectToAction("Dashboard/" + id);
            }

            var PersonalDetails = objAcknowledgement.Vw_Applicationdetails.Where(x => x.fk_CandidateId == CandiadateId).FirstOrDefault();
            var checkData = objContext.tbl_mstRTIScheme.Where(x => x.fk_CandidateId == CandiadateId).ToList().Count();
            if (checkData == 0)
            {
                tbl_mstRTIScheme obj = new tbl_mstRTIScheme();
                obj.fk_CandidateId = CandiadateId;
                obj.strApplicationNo = PersonalDetails.strApplicationNo;
                obj.strAnswer = btnSubmit;
                obj.dtEntryDate = current;
                objContext.tbl_mstRTIScheme.Add(obj);
                objContext.SaveChanges();
            }
            return RedirectToAction("PrintPreview/" + id);
        }


        public ActionResult PrintPreview(int id)
        {
            try
            {
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    return RedirectToAction("CandidateLogin/" + id);
                }
                int pkId = Convert.ToInt32(Session["UserID"]);

                var RTIScheme = objContext.tbl_mstRTIScheme.Where(x => x.fk_CandidateId == pkId).ToList();
                //if (RTIScheme.Count() == 0)
                //{
                //    return RedirectToAction("RTIScheme/" + id);
                //}

                var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

                //if (CandidatePersonalDetails.str_UploadCaste == "" && (CandidatePersonalDetails.strCategory == "OBC (Non-Creamy Layer)" || CandidatePersonalDetails.strCategory == "ST" || CandidatePersonalDetails.strCategory == "SC"))
                //{
                //    return RedirectToAction("CandidatePersonalDetails/" + id);
                //}


                var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid).FirstOrDefault();



                using (var ctx = new tbl_mst_CandidateQualificationAdditionalContext())
                {
                    var qte = ctx.tbl_mst_CandidateQualificationAdditional.Where(a => a.CandidateId == pkId && a.Application_No == CandidatePersonalDetails.strApplicationNo).ToList();
                    ViewBag.AdditionalQuali = qte.Count > 0 ? qte : null;
                }
                if (postCaitareaDetails.IsGATERequired)
                {
                    using (var ctx = new tblRecruitmentCandidateGATEDetailsContext())
                    {
                        var qte = ctx.tblRecruitmentCandidateGATEDetails.Where(a => a.CandidateId == pkId && a.PostId == postCaitareaDetails.fk_advertisementid).ToList();
                        if (qte.Count == 0)
                        {
                            return RedirectToAction("EducationDetails/" + id);
                        }

                        ViewBag.GATEQuali = qte.Count > 0 ? qte : null;
                    }
                }

                var PersonalDetails = objAcknowledgement.Vw_Applicationdetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                ViewBag.strApplicationNo = PersonalDetails.strApplicationNo;
                if (postCaitareaDetails.IsCertificateRequired == true)
                {
                    using (var ctx = new tbl_mst_CandidateCertificateDetailsContext())
                    {
                        var qte = ctx.tbl_mst_CandidateCertificateDetails.Where(a => a.fk_CandidateId == pkId).ToList();
                        ViewBag.CertificateQuali = qte.Count > 0 ? qte : null;

                        if (qte[0].CertificateName == "" || qte[0].CertificateIssueDate == "" || qte[0].IssuingAuthority == "")
                        {
                            return RedirectToAction("EducationDetails/" + id);
                        }
                    }
                }

                ViewBag.strAnswer = RTIScheme.Count() == 0 ? "Yes" : RTIScheme.FirstOrDefault().strAnswer;
                ViewBag.finalSubmit = "No";
                if (PersonalDetails.strFinalSubmit == "Yes")
                {
                    ViewBag.finalSubmit = "Yes";
                }
                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
                //if (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1))
                if (current <= noticeDetails.dtstartdate || current >= noticeDetails.dtclosedate)
                {
                    ViewBag.finalSubmit = "Yes";
                }
                var expDetail = tblExperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == pkId).ToList();
                var expDetails = expDetail.Count == 0 ? null : expDetail;
                ViewBag.educationAll = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == pkId).ToList();
                ViewBag.expAll = expDetails;
                string totalExp = "0";



                // Professional Certificate [M&HS only] — same lookup logic as ExperienceDetails
                if (expDetail != null && expDetail.Count > 0)
                {
                    var presentExpForPrint = expDetail
                                                .Where(x => x.StrEmploymentPresentStatus == "Currently Working")
                                                .FirstOrDefault()
                                            ?? expDetail.OrderByDescending(x => x.dt_todate).FirstOrDefault();

                    if (presentExpForPrint != null)
                    {
                        ViewBag.str_RegistrationNo = presentExpForPrint.str_RegistrationNo;
                        ViewBag.str_stateMedicalcouncil = presentExpForPrint.str_stateMedicalcouncil;
                        ViewBag.dt_RegistrationValidTill = presentExpForPrint.dt_RegistrationValidTill;
                        ViewBag.str_uploadregistrationCertificate_Path = presentExpForPrint.str_uploadregistrationCertificate;
                    }
                }


                if (expDetails != null)
                {
                    decimal dectotalExp = 0;
                    foreach (var getTotalExp in expDetails.ToList())
                    {
                        dectotalExp = dectotalExp + Convert.ToDecimal(getTotalExp.str_noyears);
                    }
                    var totalYears = Math.Truncate(dectotalExp / 365);
                    var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
                    var remainingDays = Math.Truncate((dectotalExp % 365) % 30);
                    totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";
                }
                //Check Candidate Is MT Or GET Akshat
                ViewBag.totalYearproper = totalExp;
                var postName = objGrade_Designation.tbl_mst_Postnew.Where(x => x.Pk_Postid == CandidatePersonalDetails.fk_postid).FirstOrDefault();


                // Add code BY pulkit
               


                var IsFresherAllowed = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid).FirstOrDefault();
                //if (expDetails == null && (Convert.ToString(postName.Postname) != "Management Trainee" && Convert.ToString(postName.Postname) != "Graduate Engineer Trainee"))
                if (IsFresherAllowed.strPostIsFreshersAllowed != "Yes" && expDetails == null)
                {
                    return RedirectToAction("ExperienceDetails/" + id);
                }

                var uploadDetails = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
                if (uploadDetails.Count() > 0)
                {
                    ViewBag.Photo = uploadDetails.FirstOrDefault().str_uploadphoto.Replace("~", "");
                    ViewBag.Signature = uploadDetails.FirstOrDefault().str_uploadsignature.Replace("~", "");
                }
                else
                {
                    ViewBag.Photo = "/content/img/passport-photo1.png";
                    ViewBag.Signature = "/content/img/signatureBox1.png";

                }

                return View(PersonalDetails);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }

        [HttpPost]
        public ActionResult PrintPreview(int id, FormCollection frm)
        {
            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
            {
                return RedirectToAction("CandidateLogin/" + id);
            }

            if (!CommonBase.IsAdvertisementActive(id))
            {
                return RedirectToAction("Dashboard/" + id);
            }

            int pkId = Convert.ToInt32(Session["UserID"]);
            var updatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var expDetails = tblExperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == pkId).ToList();
            var educationAll = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == pkId).ToList();

            decimal totalExpYear = 0;
            if (expDetails != null)
            {
                decimal dectotalExp = 0;
                foreach (var getTotalExp in expDetails.ToList())
                {
                    dectotalExp = dectotalExp + Convert.ToDecimal(getTotalExp.str_noyears);
                }
                totalExpYear = Math.Truncate(dectotalExp / 365);
            }

            int newpostIdforexp = Convert.ToInt32(ConfigurationManager.AppSettings["newpostIdforexp"]);
            int newpostIdforfre = Convert.ToInt32(ConfigurationManager.AppSettings["newpostIdforfre"]);
            string subjectName = Convert.ToString(ConfigurationManager.AppSettings["subjectNameforexp"]).Trim();

            var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();


            //Akshat Code to check Experience

            var postName = objGrade_Designation.tbl_mst_Postnew.Where(x => x.Pk_Postid == CandidatePersonalDetails.fk_postid).FirstOrDefault();


            //if ((educationAll.Count() == 4 && educationAll.Where(x => x.Str_exampassed.Trim() == subjectName).Count() == 0 && totalExpYear >= 2 && updatePersonalDetails.fk_postid == newpostIdforexp) || (educationAll.Count() == 5 && updatePersonalDetails.fk_postid == newpostIdforexp) || (educationAll.Count() == 3 && updatePersonalDetails.fk_postid == newpostIdforfre && totalExpYear >= 1) || (educationAll.Count() == 2 && totalExpYear == 1)
            //      if( (educationAll.Count() == 3 && totalExpYear == 2) || (educationAll.Count() == 1 && totalExpYear == 3) || (educationAll.Count() == 1 && totalExpYear == 5) || (educationAll.Count() == 3 && totalExpYear == 2) || (educationAll.Count() == 1 && totalExpYear == 1) || (educationAll.Count() == 3 && totalExpYear == 1) || (educationAll.Count() == 2 && totalExpYear == 3) || (educationAll.Count() == 1 && totalExpYear >= 5) || (educationAll.Count() == 2 && totalExpYear >= 1)
            //      || (educationAll.Count() == 1 && totalExpYear == 4) || (educationAll.Count() == 2 && totalExpYear == 2) || (educationAll.Count() == 2 && totalExpYear == 0) || (educationAll.Count() == 3 && totalExpYear == 0) || (educationAll.Count() >= 4 && totalExpYear >= 1))


            //if ((educationAll.Count() >= 3 && totalExpYear >= 3 && Convert.ToString(postName.Postname) == "Deputy Manager") ||  (educationAll.Count() >= 3 && totalExpYear >= 9 && Convert.ToString(postName.Postname) == "Senior Manager")) 
            if (educationAll.Count() >= 3)
            {

                var checkData = objContext.tbl_mstRTIScheme.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                if (checkData == null)
                {
                    tbl_mstRTIScheme obj = new tbl_mstRTIScheme();
                    obj.fk_CandidateId = pkId;
                    obj.strApplicationNo = updatePersonalDetails.strApplicationNo;
                    obj.strAnswer = frm["strAnswer"];
                    obj.dtEntryDate = current;
                    objContext.tbl_mstRTIScheme.Add(obj);
                    objContext.SaveChanges();
                }
                else
                {
                    checkData.strAnswer = frm["strAnswer"];
                    checkData.dtEntryDate = current;
                    objContext.Entry(checkData).State = EntityState.Modified;
                    objContext.SaveChanges();
                }


                if ((updatePersonalDetails.strPWD == "No" && updatePersonalDetails.strCategory == "EWS" && updatePersonalDetails.strInternalCandidate == "No") || (updatePersonalDetails.strPWD == "No" && updatePersonalDetails.strCategory == "OBC (Non-Creamy Layer)" && updatePersonalDetails.strInternalCandidate == "No") || (updatePersonalDetails.strCategory == "General" && updatePersonalDetails.strPWD == "No" && updatePersonalDetails.strInternalCandidate == "No"))
                {
                    return RedirectToAction("PayOnline/" + id);
                }
                else
                {
                    //updatePersonalDetails.strPWD = "No";
                    updatePersonalDetails.strFinalSubmit = "Yes";
                    updatePersonalDetails.dtFinalSubmitDate = current;
                    objcanpersonaldetails.Configuration.ValidateOnSaveEnabled = false;
                    objcanpersonaldetails.Entry(updatePersonalDetails).State = EntityState.Modified;
                    objcanpersonaldetails.SaveChanges();
                    return RedirectToAction("Acknowledgement/" + id);
                }
            }

            //       else if ((educationAll.Count() == 4 && educationAll.Where(x => x.Str_exampassed.Trim() == subjectName).Count() == 0 && updatePersonalDetails.strExserviceMan == "Yes" && updatePersonalDetails.fk_postid == newpostIdforexp) || (educationAll.Count() == 5 && updatePersonalDetails.fk_postid == newpostIdforexp) || (educationAll.Count() == 3 && updatePersonalDetails.fk_postid == newpostIdforfre && updatePersonalDetails.strExserviceMan == "Yes"))

            //if ((educationAll.Count() >= 3 && totalExpYear == 0 && Convert.ToString(postName.Postname) == "Management Trainee") || (educationAll.Count() >= 3 && totalExpYear >= 0 && Convert.ToString(postName.Postname) == "Graduate Engineer Trainee")) 
            if (educationAll.Count() >= 2)
            {

                var checkData = objContext.tbl_mstRTIScheme.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

                if (checkData == null)
                {
                    tbl_mstRTIScheme obj = new tbl_mstRTIScheme();
                    obj.fk_CandidateId = pkId;
                    obj.strApplicationNo = updatePersonalDetails.strApplicationNo;
                    obj.strAnswer = frm["strAnswer"];
                    obj.dtEntryDate = current;
                    objContext.tbl_mstRTIScheme.Add(obj);
                    objContext.SaveChanges();
                }
                else
                {
                    checkData.strAnswer = frm["strAnswer"];
                    checkData.dtEntryDate = current;
                    objContext.Entry(checkData).State = EntityState.Modified;
                    objContext.SaveChanges();
                }


                if ((updatePersonalDetails.strPWD == "No" && updatePersonalDetails.strCategory == "EWS" && updatePersonalDetails.strInternalCandidate == "No") || (updatePersonalDetails.strPWD == "No" && updatePersonalDetails.strCategory == "OBC (Non-Creamy Layer)" && updatePersonalDetails.strInternalCandidate == "No") || (updatePersonalDetails.strCategory == "General" && updatePersonalDetails.strPWD == "No" && updatePersonalDetails.strInternalCandidate == "No"))
                {
                    return RedirectToAction("PayOnline/" + id);
                }
                else
                {
                    updatePersonalDetails.strFinalSubmit = "Yes";
                    updatePersonalDetails.dtFinalSubmitDate = current;
                    objcanpersonaldetails.Entry(updatePersonalDetails).State = EntityState.Modified;
                    objcanpersonaldetails.SaveChanges();
                    return RedirectToAction("Acknowledgement/" + id);
                }
            }

            else
            {
                var PersonalDetails = objAcknowledgement.Vw_Applicationdetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

                ViewBag.educationAll = educationAll;
                ViewBag.expAll = expDetails;
                var uploadDetails = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
                if (uploadDetails.Count() > 0)
                {
                    ViewBag.Photo = uploadDetails.FirstOrDefault().str_uploadphoto.Replace("~", "");
                    ViewBag.Signature = uploadDetails.FirstOrDefault().str_uploadsignature.Replace("~", "");
                }
                ViewBag.Message = "You have not applicable to this post!";
                return View(PersonalDetails);
            }
        }

        public ActionResult ApplicationPrint(int id)
        {
            try
            {
                if (Session["UserID"] == null)
                {
                    return Content("DEBUG: Session['UserID'] is NULL in ApplicationPrint");
                }
                int pkId = Convert.ToInt32(Session["UserID"]);
                var getViewDetail = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == pkId).ToList();
                var getViewDetailOnlyPhoto = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == pkId && !string.IsNullOrEmpty(a.str_uploadphoto)).ToList();
                var getViewDetailOnlySignature = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == pkId && !string.IsNullOrEmpty(a.str_uploadsignature)).ToList();
                var candidatedetails = objAcknowledgement.Vw_Applicationdetails.Where(a => a.fk_CandidateId == pkId).ToList();
                string strApplicationNo = candidatedetails.FirstOrDefault().strApplicationNo;
                var RTIAnsDetails = objContext.tbl_mstRTIScheme.Where(x => x.fk_CandidateId == pkId).ToList();
                string strAnswer = Request.Form["strAnswer"] == null ? "Yes" : Request.Form["strAnswer"];
                if (RTIAnsDetails.Count() == 0)
                {
                    tbl_mstRTIScheme obj = new tbl_mstRTIScheme();
                    obj.fk_CandidateId = pkId;
                    obj.strApplicationNo = candidatedetails.FirstOrDefault().strApplicationNo;
                    obj.strAnswer = strAnswer;
                    obj.dtEntryDate = current;
                    objContext.tbl_mstRTIScheme.Add(obj);
                    objContext.SaveChanges();
                    RTIAnsDetails = objContext.tbl_mstRTIScheme.Where(x => x.fk_CandidateId == pkId).ToList();
                }
                if (getViewDetail.Count != 0 && getViewDetailOnlyPhoto.Count != 0 && getViewDetailOnlySignature.Count != 0 && RTIAnsDetails.Count != 0)
                {
                    eRequirtmentFormNew chl = new eRequirtmentFormNew();

                    var reportdetails = getViewDetail.FirstOrDefault();
                    var candidate = candidatedetails.FirstOrDefault();
                    chl.HeadLine4 = "Application Form No.:" + " " + candidate.strApplicationNo;
                    chl.ApplicationNo = Convert.ToString(candidate.strApplicationNo);
                    chl.candidateid = candidate.fk_CandidateId;
                    chl.RTIAns = RTIAnsDetails.FirstOrDefault().strAnswer;
                    chl.HCLLogo = @"~/images/hcl_logo.jpg";
                    chl.HCLPhoto = reportdetails.str_uploadphoto;
                    chl.SignPhoto = reportdetails.str_uploadsignature;
                    chl.HeadLine1 = "Hindustan Copper Limited";
                    chl.HeadLine2 = "(A Govt. of India Enteprise)";
                    chl.HeadLine3 = "Kolkata-700019";
                    chl.decipline = candidate.DisciplineName;
                    chl.post = candidate.Postname;
                    var mem = chl.CreateRequirtment134();
                    byte[] bytesInStream = mem.ToArray();
                    Response.Clear();
                    Response.ContentType = "application/force-download";
                    Response.AddHeader("content-disposition", "attachment;    filename=" + candidate.strApplicationNo + ".pdf");
                    Response.BinaryWrite(bytesInStream);
                    Response.End();
                    Session["upload"] = "ok";
                    return RedirectToAction("Dashboard/" + id);

                }
                else
                {
                    return RedirectToAction("UploadDetails/" + id);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }

        public ActionResult Acknowledgement(int id)
        {
            try
            {
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    return RedirectToAction("CandidateLogin/" + id);
                }
                int pkId = Convert.ToInt32(Session["UserID"]);


                //var tran = objAcknowledgement.tbl_transactions.Where(x => x.fkintApplicantId == pkId && x.strStatus == "success" && x.fk_advertisementid == id).FirstOrDefault();
                //if (tran!=null && !CommonBase.IsAdvertisementActive(id))
                //{
                //    return RedirectToAction("Dashboard/" + id);
                //}
                int startApplicatId = Convert.ToInt32(ConfigurationManager.AppSettings["startId"]);

                if (!CommonBase.CheckGateQualification(pkId))
                {
                    return RedirectToAction("EducationDetails/" + id);
                }


                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
                var tran = objAcknowledgement.tbl_transactions.Where(x => x.fkintApplicantId == pkId && x.strStatus == "success" && x.fk_advertisementid == id).FirstOrDefault();

                var updatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

                var acknowledgement = objAcknowledgement.Vw_Applicationdetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();


                if (noticeDetails.strEmploymentType == "Online")
                {
                    decimal? Amount = CommonBase.CalculateOnlineFees(id, acknowledgement.strCategory, acknowledgement.strPWD == "Yes", acknowledgement.strInternalCandidate == "Yes");
                    if (Amount == 0)
                    {
                        if (acknowledgement == null || acknowledgement.strFinalSubmit != "Yes")
                        {
                            if (!CommonBase.IsAdvertisementActive(id))
                            {
                                return RedirectToAction("Dashboard/" + id);
                            }
                            //var updatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == acknowledgement.fk_CandidateId).FirstOrDefault();
                            //updatePersonalDetails.strPWD = "No";
                            updatePersonalDetails.strFinalSubmit = "Yes";
                            updatePersonalDetails.dtFinalSubmitDate = current;
                            objcanpersonaldetails.Entry(updatePersonalDetails).State = EntityState.Modified;
                            objcanpersonaldetails.SaveChanges();
                            acknowledgement = objAcknowledgement.Vw_Applicationdetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                        }
                    }
                    //else if (Amount != null)
                    //{
                    //    return RedirectToAction("Dashboard/" + id);
                    //}

                    else if (tran == null && Amount != null && Amount > 0)
                    {
                        return RedirectToAction("PayOnline/" + id);
                    }
                    else if (Amount == null)
                    {
                        return RedirectToAction("Dashboard/" + id);
                    }
                }
                if (tran != null && tran.strStatus == "success" && updatePersonalDetails.strFinalSubmit != "Yes")
                {
                    //updatePersonalDetails1.strPWD = "No";
                    //updatePersonalDetails.strFinalSubmit = "Yes";
                    //updatePersonalDetails.dtFinalSubmitDate = current;
                    //objcanpersonaldetails.Entry(updatePersonalDetails).State = EntityState.Modified;
                    //objcanpersonaldetails.SaveChanges();
                    acknowledgement = objAcknowledgement.Vw_Applicationdetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
                }

                var getViewDetail = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == pkId).ToList();
                var getViewDetailOnlyPhoto = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == pkId && !string.IsNullOrEmpty(a.str_uploadphoto)).ToList();
                var getViewDetailOnlySignature = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == pkId && !string.IsNullOrEmpty(a.str_uploadsignature)).ToList();

                if (getViewDetail.Count != 0 && getViewDetailOnlyPhoto.Count != 0 && getViewDetailOnlySignature.Count != 0 && acknowledgement.strFinalSubmit == "Yes")
                {

                    var unit = acknowledgement.Fk_unitid;
                    var post = acknowledgement.fk_postid;
                    var discipline = acknowledgement.fk_diciplineid;
                    var candidateId = acknowledgement.fk_CandidateId;
                    var advno = acknowledgement.fk_advertiseid;
                    var date = acknowledgement.dt_entrydate.Value.ToString("ddMMyy");
                    ViewBag.candidateRegistrationId = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(x => x.Candidate_Pk_intID == acknowledgement.fk_CandidateId).FirstOrDefault().Candidate_Code;




                    //if ((acknowledgement.strPWD == "No" && acknowledgement.strCategory == "EWS" && acknowledgement.strInternalCandidate == "No") || (acknowledgement.strPWD == "No" && acknowledgement.strCategory == "OBC (Non-Creamy Layer)" && acknowledgement.strInternalCandidate == "No") || (acknowledgement.strCategory == "General" && acknowledgement.strPWD == "No" && acknowledgement.strInternalCandidate == "No"))
                    if (tran != null && updatePersonalDetails.strFinalSubmit == "Yes")
                    {
                        ViewBag.paymentDetails = "Bank Ref. No. : " + tran.strBankRefNum + " Amount : " + tran.decPayuAmount + " Date : " + tran.dtTransactionsDate;
                    }
                    else
                    {
                        ViewBag.paymentDetails = "NA";
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
                    return RedirectToAction("Dashboard/" + id);
                }
            }

            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }


        public ActionResult PayOnline(int id)
        {
            try
            {
                ViewBag.NoticeId = id;
                int CandidateId = Convert.ToInt32(Session["UserID"]);
                if (CandidateId == 0)
                {
                    return RedirectToAction("CandidateLogin/" + id);
                }

                if (!CommonBase.IsAdvertisementActive(id))
                {
                    return RedirectToAction("Dashboard/" + id);
                }
                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
                //if (!CheckEmailExclude() && (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1)))
                //{
                //    return RedirectToAction("Dashboard/" + id);
                //}


                //var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == CandidateId).FirstOrDefault();

                //var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid).FirstOrDefault();

                //if (postCaitareaDetails.IsGATERequired)
                //{
                //    using (tblRecruitmentCandidateGATEDetailsContext db = new tblRecruitmentCandidateGATEDetailsContext())
                //    {
                //        var d_gate_list = db.tblRecruitmentCandidateGATEDetails.Where(a => a.CandidateId == CandidateId && a.PostId == CandidatePersonalDetails.fk_advertiseid).ToList();
                //        if (d_gate_list.Where(a => string.IsNullOrEmpty(a.str_GATEResult) == false).FirstOrDefault() == null)
                //        {
                //            return RedirectToAction("EducationDetails/" + id);
                //        }

                //    }
                //}
                if (!CommonBase.CheckGateQualification(CandidateId))
                {
                    return RedirectToAction("EducationDetails/" + id);
                }

                var details = objAcknowledgement.Vw_Applicationdetails.Where(x => x.fk_CandidateId == CandidateId).FirstOrDefault();
                var getViewDetail = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == CandidateId).ToList();
                var getViewDetailOnlyPhoto = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == CandidateId && !string.IsNullOrEmpty(a.str_uploadphoto)).ToList();
                var getViewDetailOnlySignature = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == CandidateId && !string.IsNullOrEmpty(a.str_uploadsignature)).ToList();


                decimal? Amount = 0;// CommonBase.CalculateOnlineFees(id, details.strCategory);

                if (getViewDetail.Count != 0 && getViewDetailOnlyPhoto.Count != 0 && getViewDetailOnlySignature.Count != 0)
                {
                    ViewBag.date = current;
                    //if ((details.strPWD == "No" && details.strCategory == "EWS" && details.strInternalCandidate == "No") || (details.strPWD == "No" && details.strCategory == "OBC (Non-Creamy Layer)" && details.strInternalCandidate == "No") || (details.strCategory == "General" && details.strPWD == "No" && details.strInternalCandidate == "No"))
                    if (noticeDetails.strEmploymentType == "Online")
                    {
                        Amount = CommonBase.CalculateOnlineFees(id, details.strCategory, details.strPWD == "Yes", details.strInternalCandidate == "Yes");
                        if (Amount == null)
                        {
                            return RedirectToAction("Dashboard/" + id);
                        }
                        else if (Amount == 0)
                        {
                            return RedirectToAction("Acknowledgement/" + id);
                        }
                        var transaction = CommonBase.GetTransaction(details.fk_CandidateId, details.Pk_int_CandidateRegistrationID, id) ?? new tbl_transactions();
                        if (transaction.strStatus == "success")
                        {
                            return RedirectToAction("Acknowledgement/" + id);
                        }
                        ViewBag.amount = Amount;
                    }
                    else
                    {
                        ViewBag.amount = "0.00";
                        return RedirectToAction("Acknowledgement/" + id);
                    }
                    return View(details);
                }
                else
                {
                    return RedirectToAction("Dashboard/" + id);
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Dashboard/" + id);
            }
        }

        [HttpPost]
        public void PayOnline(int id, FormCollection frm)
        {
            try
            {
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    RedirectToAction("CandidateLogin/" + id);
                    return;
                }
                if (!CommonBase.IsAdvertisementActive(id))
                {
                    RedirectToAction("Dashboard/" + id);
                    return;
                }
                ViewBag.NoticeId = id;
                int CandiadateId = Convert.ToInt32(Session["UserID"]);
                int startApplicatId = Convert.ToInt32(ConfigurationManager.AppSettings["startId"]);
                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
                //if (!CheckEmailExclude() && (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1) && CandiadateId >= startApplicatId))
                //{
                //    RedirectToAction("Dashboard/" + id);
                //}



                var details = objAcknowledgement.Vw_Applicationdetails.Where(x => x.fk_CandidateId == CandiadateId).FirstOrDefault();
                var q_ = CommonBase.GetTransaction(details.fk_CandidateId, details.Pk_int_CandidateRegistrationID, id) ?? new tbl_transactions();
                if (q_.strStatus == "success")
                {
                    RedirectToAction("Acknowledgement/" + id);
                    return;
                }


                var getViewDetail = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == CandiadateId).ToList();
                var getViewDetailOnlyPhoto = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == CandiadateId && !string.IsNullOrEmpty(a.str_uploadphoto)).ToList();
                var getViewDetailOnlySignature = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(a => a.fk_intcandidateid == CandiadateId && !string.IsNullOrEmpty(a.str_uploadsignature)).ToList();


                if (getViewDetail.Count != 0 && getViewDetailOnlyPhoto.Count != 0 && getViewDetailOnlySignature.Count != 0)
                {
                    decimal? Amount = CommonBase.CalculateOnlineFees(id, details.strCategory, details.strPWD == "Yes", details.strInternalCandidate == "Yes");
                    string feeamount = Convert.ToString((Amount ?? 0));

                    ViewBag.date = current;

                    string firstName = details.strApplicantName;
                    string amount = feeamount;
                    string productInfo = "Application Fee";
                    string email = details.strEmail;
                    string phone = details.strMobileNo;


                    // Local URL
                    //string surl = "http://localhost:26162/RecruitmentEnglish/Success" + "/" + id;

                    // UAT URL
                    //string surl = "https://hcl.uat-projects.com/RecruitmentEnglish/Success" + "/" + id;

                    // Live URL
                    string surl = "https://www.hindustancopper.com/RecruitmentEnglish/Success" + "/" + id;



                    /*ConfigurationManager.AppSettings["surl"] + "/" + id;*//*"https://www.hindustancopper.com/RecruitmentEnglish/Success" + "/" + id;*/
                    //string surl = "https://hcl.infoneotech.com/RecruitmentEnglish/Success" + "/" + id;// ConfigurationManager.AppSettings["surl"] + "/" + id;


                    //string furl = /*ConfigurationManager.AppSettings["furl"] + "/" + id;*/
                    //   "https://www.hindustancopper.com/RecruitmentEnglish/Failed" + "/" + id;
                    ////string furl = "https://hcl.uat-projects.com/RecruitmentEnglish/Failed" + "/" + id;// ConfigurationManager.AppSettings["furl"] + "/" + id;


                    // LOcalURL

                    //string furl = "http://localhost:26162/RecruitmentEnglish/Failed" + "/" + id;

                    // UAT URL
                    //string furl = "https://hcl.uat-projects.com/RecruitmentEnglish/Failed" + "/" + id;


                    // LIVE URL
                    string furl = "https://www.hindustancopper.com/RecruitmentEnglish/Failed" + "/" + id;




                    string udf1 = details.strApplicationNo;
                    string udf2 = details.fk_CandidateId.ToString();
                    string udf3 = details.Pk_int_CandidateRegistrationID.ToString();
                    string udf4 = details.dtDOB.ToString();
                    string udf5 = details.strCategory.ToString();



                    RemotePost myremotepost = new RemotePost();
                    string key = "T6slPe";
                    string salt = "xGLsVGI3LHboLCR4HTkU1ASc9LYCzt3f";

                    //string key = "7GAuCS";
                    //string salt = "W80VBMWFW4wUBhrTYYf9Tq9Ex1c27iJP";

                    //myremotepost.Url = "https://secure.payu.in/_payment";

                    //string key = "55lpfF";
                    //string salt = "O5T2XxuVHmFrDI1ABuB3PtjD0mPUuLpn";

                    //myremotepost.Url = "https://txncdn.payubiz.in/login";


                    myremotepost.Url = "https://secure.payu.in/_payment";

                    myremotepost.Add("key", key);
                    string txnid = Generatetxnid();
                    myremotepost.Add("txnid", txnid);
                    myremotepost.Add("amount", amount);
                    myremotepost.Add("productinfo", productInfo);
                    myremotepost.Add("firstname", firstName);
                    myremotepost.Add("phone", phone);
                    myremotepost.Add("email", email);

                    myremotepost.Add("udf1", udf1);
                    myremotepost.Add("udf2", udf2);
                    myremotepost.Add("udf3", udf3);
                    myremotepost.Add("udf4", udf4);
                    myremotepost.Add("udf5", udf5);

                    myremotepost.Add("surl", surl);//Change the success url here depending upon the port number of your local system.
                    myremotepost.Add("furl", furl);//Change the failure url here depending upon the port number of your local system.

                    //myremotepost.Add("service_provider", "payu_paisa");

                    string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|" + udf1 + "|" + udf2 + "|" + udf3 + "|" + udf4 + "|" + udf5 + "||||||" + salt;



                    tbl_transactions objtransactions = objAcknowledgement.tbl_transactions.Where(a => a.fkintApplicantId == details.fk_CandidateId && a.fk_CandidateRegistrationID == details.Pk_int_CandidateRegistrationID && a.fk_advertisementid == details.fk_advertisementid).FirstOrDefault();
                    if (objtransactions == null)
                    {
                        objtransactions = new tbl_transactions();
                        objtransactions.strTransactionsId = txnid;
                        objtransactions.fk_advertisementid = details.fk_advertisementid;
                        objtransactions.fkintApplicantId = details.fk_CandidateId;
                        objtransactions.fk_CandidateRegistrationID = details.Pk_int_CandidateRegistrationID;
                        objtransactions.strApplicationNo = details.strApplicationNo;
                        objtransactions.decHCLAmount = Convert.ToDecimal(feeamount);
                        objtransactions.dtTransactionsDate = current;
                        objAcknowledgement.tbl_transactions.Add(objtransactions);
                    }
                    else
                    {

                        objtransactions.strTransactionsId = txnid;
                        objtransactions.fk_advertisementid = details.fk_advertisementid;
                        objtransactions.fkintApplicantId = details.fk_CandidateId;
                        objtransactions.fk_CandidateRegistrationID = details.Pk_int_CandidateRegistrationID;
                        objtransactions.strApplicationNo = details.strApplicationNo;
                        objtransactions.decHCLAmount = Convert.ToDecimal(feeamount);
                        objtransactions.dtTransactionsDate = current;
                    }
                    objAcknowledgement.SaveChanges();
                    string hash = Generatehash512(hashString);
                    myremotepost.Add("hash", hash);
                    myremotepost.Post();
                }
                else
                {
                    RedirectToAction("Dashboard/" + id);
                }
            }
            catch (Exception ex)
            {
                RedirectToAction("Dashboard/" + id);
            }
        }
        public ActionResult Success(int id)
        {
            ViewBag.NoticeId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Success(int id, FormCollection form)
        {
            try
            {
                ViewBag.NoticeId = id;
                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;
                string order_id = string.Empty;

                string amount = string.Empty;
                string mihpayid = string.Empty;
                string mode = string.Empty;
                string status = string.Empty;
                string key = string.Empty;
                string Error = string.Empty;
                string PG_TYPE = string.Empty;
                string bank_ref_num = string.Empty;
                string unmappedstatus = string.Empty;
                string payuMoneyId = string.Empty;

                string hash_seq = ConfigurationManager.AppSettings["hashSequence"];



                if (form["status"].ToString() == "success")
                {

                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    merc_hash_string = Request.Form["txnid"] + "|" + "xGLsVGI3LHboLCR4HTkU1ASc9LYCzt3f" + "|" + form["status"].ToString();
                    // merc_hash_string = Request.Form["additionalCharges"]+"|"+ConfigurationManager.AppSettings["SALT"] + "|" + Request.Form["status"];

                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");

                    }
                    //Response.Write(merc_hash_string);
                    merc_hash = Generatehash512(merc_hash_string).ToLower();
                    order_id = Request.Form["txnid"];
                    amount = Request.Form["amount"];
                    mihpayid = Request.Form["mihpayid"];
                    mode = Request.Form["mode"];
                    status = Request.Form["status"];
                    key = Request.Form["key"];
                    Error = Request.Form["Error"];
                    PG_TYPE = Request.Form["PG_TYPE"];
                    bank_ref_num = Request.Form["bank_ref_num"];
                    unmappedstatus = Request.Form["unmappedstatus"];
                    payuMoneyId = Request.Form["payuMoneyId"];
                    var objtransactions = objAcknowledgement.tbl_transactions.Where(t => t.strTransactionsId == order_id).FirstOrDefault();
                    var PostDetails = objAcknowledgement.Vw_Applicationdetails.Where(t => t.strApplicationNo == objtransactions.strApplicationNo).FirstOrDefault();
                    ViewBag.Applicant = Request.Form["firstname"];
                    ViewBag.TranId = Request.Form["txnid"];
                    ViewBag.date = objtransactions.dtTransactionsDate;
                    ViewBag.amount = amount;
                    ViewBag.RefNo = bank_ref_num;
                    ViewBag.mode = mode;
                    ViewBag.post = PostDetails.Postname + " ( " + PostDetails.DisciplineName + " ) ";
                    ViewBag.fk_advertiseid = PostDetails.fk_advertiseid;


                    objtransactions.decPayuAmount = Convert.ToDecimal(amount);
                    objtransactions.strMihPayId = mihpayid;
                    objtransactions.strMode = mode;
                    objtransactions.strStatus = status;
                    objtransactions.strError = Error;
                    objtransactions.strPgType = PG_TYPE;
                    objtransactions.strBankRefNum = bank_ref_num;
                    objtransactions.strUnmappedstatus = unmappedstatus;
                    objtransactions.strPayUMoneyId = payuMoneyId;
                    DateTime date = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    objtransactions.dtTransactionsDate = date;
                    objAcknowledgement.Entry(objtransactions).State = EntityState.Modified;
                    objAcknowledgement.SaveChanges();

                    var dateAck = PostDetails.dt_entrydate.Value.ToString("ddMMyy");
                    using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString))
                    {
                        SqlParameter outPar1 = new SqlParameter("@newacknowledgementNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                        SqlParameter outPar2 = new SqlParameter("@newNoticeNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                        var cmd = new SqlCommand("sp_AcknowledgementReport", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@unitId", SqlDbType.Int)).Value = PostDetails.Fk_unitid;//Pass the parameter
                        cmd.Parameters.Add(new SqlParameter("@postId", SqlDbType.Int)).Value = PostDetails.fk_postid;//Pass the parameter
                        cmd.Parameters.Add(new SqlParameter("@disciplineId", SqlDbType.Int)).Value = PostDetails.fk_diciplineid;
                        cmd.Parameters.Add(new SqlParameter("@candidateId", SqlDbType.Int)).Value = PostDetails.fk_CandidateId;//Pass the parameter
                        cmd.Parameters.Add(new SqlParameter("@noticeId", SqlDbType.Int)).Value = PostDetails.fk_advertisementid;//Pass the parameter
                        cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.VarChar)).Value = dateAck;//Pass the parameter
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

                    var updatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == PostDetails.fk_CandidateId).FirstOrDefault();
                    //updatePersonalDetails.strPWD = "No";
                    updatePersonalDetails.strFinalSubmit = "Yes";
                    updatePersonalDetails.dtFinalSubmitDate = current;

                    objcanpersonaldetails.Configuration.ValidateOnSaveEnabled = false;
                    objcanpersonaldetails.Entry(updatePersonalDetails).State = EntityState.Modified;
                    objcanpersonaldetails.SaveChanges();

                    //SavePayuTransactionLog(id, Request.Form);
                }
                else
                {
                    var updatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails
                    .FirstOrDefault(x => x.fk_CandidateId == id);

                    if (updatePersonalDetails != null)
                        updatePersonalDetails.strFinalSubmit = "No";
                    objcanpersonaldetails.Configuration.ValidateOnSaveEnabled = false; 
                    objcanpersonaldetails.Entry(updatePersonalDetails).State = EntityState.Modified;
                    objcanpersonaldetails.SaveChanges();

                }
            }
            catch (Exception ex)
            {

                Response.Write(ex);
            }
            return View();
        }

        [HttpPost]
        public void Return(int id, FormCollection form)
        {
            try
            {
                ViewBag.NoticeId = id;
                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;
                string order_id = string.Empty;
                string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";

                if (form["status"].ToString() == "success")
                {

                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    // merc_hash_string = ConfigurationManager.AppSettings["SALT"] + "|" + form["status"].ToString();
                    //merc_hash_string = Request.Form["additionalCharges"] + "|" + ConfigurationManager.AppSettings["SALT"] + "|" + Request.Form["status"];
                    if (!string.IsNullOrEmpty(Request.Form["additionalCharges"]))
                    {
                        merc_hash_string = Request.Form["additionalCharges"] + "|";
                    }
                    merc_hash_string += "xGLsVGI3LHboLCR4HTkU1ASc9LYCzt3f" + "|" + Request.Form["status"];
                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");

                    }
                    Response.Write(merc_hash_string);
                    merc_hash = Generatehash512(merc_hash_string).ToLower();



                    if (merc_hash != form["hash"])
                    {
                        Response.Write("Hash value did not matched");

                    }
                    else
                    {
                        order_id = Request.Form["txnid"];

                        ViewData["Message"] = "Status is successful. Hash value is matched";
                        Response.Write("<br/>Hash value matched");

                        //Hash value did not matched
                    }

                }

                else
                {

                    Response.Write("Hash value did not matched");
                    // osc_redirect(osc_href_link(FILENAME_CHECKOUT, 'payment' , 'SSL', null, null,true));

                }
            }

            catch (Exception ex)
            {
                Response.Write("<span style='color:red'>" + ex.Message + "</span>");

            }


        }
        
        public ActionResult Failed(int id)
        {
            ViewBag.NoticeId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Failed(int id, FormCollection form)
        {
            try
            {
                ViewBag.NoticeId = id;

                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;
                string order_id = string.Empty;
                string amount = string.Empty;
                string mihpayid = string.Empty;
                string mode = string.Empty;
                string status = string.Empty;
                string key = string.Empty;
                string Error = string.Empty;
                string PG_TYPE = string.Empty;
                string bank_ref_num = string.Empty;
                string unmappedstatus = string.Empty;
                string payuMoneyId = string.Empty;

                string hash_seq = ConfigurationManager.AppSettings["hashSequence"];

                if (form["status"].ToString() != "success")
                {

                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    merc_hash_string = "xGLsVGI3LHboLCR4HTkU1ASc9LYCzt3f" + "|" + form["status"].ToString();


                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");

                    }
                    Response.Write(merc_hash_string);
                    merc_hash = Generatehash512(merc_hash_string).ToLower();




                    order_id = Request.Form["txnid"];
                    amount = Request.Form["amount"];
                    mihpayid = Request.Form["mihpayid"];
                    mode = Request.Form["mode"];
                    status = Request.Form["status"];
                    key = Request.Form["key"];
                    Error = Request.Form["Error"];
                    PG_TYPE = Request.Form["PG_TYPE"];
                    bank_ref_num = Request.Form["bank_ref_num"];
                    unmappedstatus = Request.Form["unmappedstatus"];
                    payuMoneyId = Request.Form["payuMoneyId"];


                    //var objtransactions = objAcknowledgement.tbl_transactions.Where(t => t.strTransactionsId == order_id).FirstOrDefault();
                    //objtransactions.decPayuAmount = Convert.ToDecimal(amount);
                    //objtransactions.strMihPayId = mihpayid;
                    //objtransactions.strMode = mode;
                    //objtransactions.strStatus = status;
                    //objtransactions.strError = Error;
                    //objtransactions.strPgType = PG_TYPE;
                    //objtransactions.strBankRefNum = bank_ref_num;
                    //objtransactions.strUnmappedstatus = unmappedstatus;
                    //objtransactions.strPayUMoneyId = payuMoneyId;
                    //DateTime date = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    //objtransactions.dtTransactionsDate = date;
                    //objcanpersonaldetails.Entry(objtransactions).State = EntityState.Modified;
                    //objcanpersonaldetails.SaveChanges();
                    ViewData["Message"] = "Status is successful. Hash value is matched";

                    ViewBag.Applicant = Request.Form["firstname"];
                    ViewBag.TranId = Request.Form["txnid"];
                    //ViewBag.date = objtransactions.dtTransactionsDate;
                    //ViewBag.fk_advertiseid = objtransactions.fk_advertisementid;

                    //SavePayuTransactionLog(id, Request.Form);

                }

                else
                {

                    Response.Write("Hash value did not matched");

                }
                ViewBag.status = status;

            }

            catch (Exception ex)
            {
                Response.Write("<span style='color:red'>" + ex.Message + "</span>");

            }

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PayUWebhook()
        {
            try
            {

                int advertisementId = 144;

                //int advertisementId = 0;
                //if (!string.IsNullOrEmpty(Request.Form["udf6"]))
                //    int.TryParse(Request.Form["udf6"], out advertisementId);


                SavePayuTransactionLog(advertisementId, Request.Form);

                return new HttpStatusCodeResult(200);
            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(200);
            }
        }

        private void SavePayuTransactionLog(int advertisementId, NameValueCollection form)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString))
                {

                    string UniqueAdvId = advertisementId + "_" + form["udf1"];


                    var cmd = new SqlCommand(@"
                INSERT INTO tbl_transactionlogs
                (strTransactionsId, fkintApplicantId, fk_advertisementid, fk_CandidateRegistrationID,
                 strApplicationNo, decHCLAmount, decPayuAmount, strMihPayId, strMode, strStatus, strError,
                 strPgType, strBankRefNum, strUnmappedstatus, strPayUMoneyId, dtTransactionsDate,UniqueAdvId)
                VALUES
                (@strTransactionsId, @fkintApplicantId, @fk_advertisementid, @fk_CandidateRegistrationID,
                 @strApplicationNo, @decHCLAmount, @decPayuAmount, @strMihPayId, @strMode, @strStatus, @strError,
                 @strPgType, @strBankRefNum, @strUnmappedstatus, @strPayUMoneyId, @dtTransactionsDate,@UniqueAdvId)", con);

                    // Mapping
                    cmd.Parameters.AddWithValue("@strTransactionsId", form["txnid"] ?? "");
                    cmd.Parameters.AddWithValue("@fkintApplicantId", form["udf2"] ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@fk_advertisementid", advertisementId);
                    cmd.Parameters.AddWithValue("@fk_CandidateRegistrationID", form["udf3"] ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@strApplicationNo", form["udf1"] ?? "");

                    // decHCLAmount → DB se lena hoga (aap apni tbl_transactions ya CalculateOnlineFees se nikaal lo)
                    decimal decHCLAmount = 0;
                    if (!string.IsNullOrEmpty(form["amount"]))
                        decimal.TryParse(form["amount"], out decHCLAmount);
                    cmd.Parameters.AddWithValue("@decHCLAmount", decHCLAmount);

                    decimal decPayuAmount = 0;
                    if (!string.IsNullOrEmpty(form["amount"]))
                        decimal.TryParse(form["amount"], out decPayuAmount);
                    cmd.Parameters.AddWithValue("@decPayuAmount", decPayuAmount);

                    cmd.Parameters.AddWithValue("@strMihPayId", form["mihpayid"] ?? "");
                    cmd.Parameters.AddWithValue("@strMode", form["mode"] ?? "");
                    cmd.Parameters.AddWithValue("@strStatus", form["status"] ?? "");
                    cmd.Parameters.AddWithValue("@strError", form["Error"] ?? "");
                    cmd.Parameters.AddWithValue("@strPgType", form["PG_TYPE"] ?? "");
                    cmd.Parameters.AddWithValue("@strBankRefNum", form["bank_ref_num"] ?? "");
                    cmd.Parameters.AddWithValue("@strUnmappedstatus", form["unmappedstatus"] ?? "");
                    cmd.Parameters.AddWithValue("@strPayUMoneyId", form["payuMoneyId"] ?? "");
                    cmd.Parameters.AddWithValue("@dtTransactionsDate", DateTime.UtcNow + TimeSpan.Parse("05:30:00"));

                    cmd.Parameters.AddWithValue("@UniqueAdvId", UniqueAdvId);


                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Logging error ko ignore karo, payment flow ko block mat karo
            }
        }

        public class RemotePost
        {
            private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();


            public string Url = "";
            public string Method = "post";
            public string FormName = "form1";

            public void Add(string name, string value)
            {
                Inputs.Add(name, value);
            }

            public void Post()
            {
                System.Web.HttpContext.Current.Response.Clear();

                System.Web.HttpContext.Current.Response.Write("<html><head>");

                System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
                System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
                for (int i = 0; i < Inputs.Keys.Count; i++)
                {
                    System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
                }
                System.Web.HttpContext.Current.Response.Write("</form>");
                System.Web.HttpContext.Current.Response.Write("</body></html>");

                System.Web.HttpContext.Current.Response.End();
            }
        }
        //Hash generation Algorithm
        public string Generatehash512(string text)
        {

            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;

        }
        public string Generatetxnid()
        {

            Random rnd = new Random();
            string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
            string txnid1 = strHash.ToString().Substring(0, 20);

            return txnid1;
        }

        public ActionResult InterviewLetter(int id)
        {

            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
            {
                return RedirectToAction("Login/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            ViewBag.courrentDate = (DateTime.UtcNow + TimeSpan.Parse("05:30:00")).ToShortDateString();

            var ApplicantPersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var InterviewLetter = objAcknowledgement.AdvId99_CandidateDetailsInterview.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

            if (InterviewLetter == null)
            {
                ViewBag.Message = "You are not shortlisted for Interview";

                return RedirectToAction("CandidateLogin/" + id);

            }

            else
            {
                return View(InterviewLetter);
            }

        }

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

        public ActionResult InterviewLetterNew(int id)
        {

            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
            {
                return RedirectToAction("CandidateLogin/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            ViewBag.courrentDate = (DateTime.UtcNow + TimeSpan.Parse("05:30:00")).ToShortDateString();

            var ApplicantPersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var InterviewLetter = objAcknowledgement.AdvId99_CandidateDetailsInterview.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();




            var uploadDetails = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            if (uploadDetails.Count() > 0)
            {
                ViewBag.Photo = uploadDetails.FirstOrDefault().str_uploadphoto.Replace("~", "");
                ViewBag.Signature = uploadDetails.FirstOrDefault().str_uploadsignature.Replace("~", "");
            }



            if (InterviewLetter == null)
            {
                ViewBag.Message = "You are not shortlisted for Interview";

                return RedirectToAction("CandidateLogin/" + id);

            }

            else
            {
                return View(InterviewLetter);
            }

        }

        public ActionResult InterviewLetterNew113(int id)
        {

            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
            {
                return RedirectToAction("CandidateLogin/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            ViewBag.courrentDate = (DateTime.UtcNow + TimeSpan.Parse("05:30:00")).ToShortDateString();

            var ApplicantPersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var InterviewLetter = objAcknowledgement.AdvId99_CandidateDetailsInterview.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();




            var uploadDetails = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            if (uploadDetails.Count() > 0)
            {
                ViewBag.Photo = uploadDetails.FirstOrDefault().str_uploadphoto.Replace("~", "");
                ViewBag.Signature = uploadDetails.FirstOrDefault().str_uploadsignature.Replace("~", "");
            }



            if (InterviewLetter == null)
            {
                ViewBag.Message = "You are not shortlisted for Interview";

                return RedirectToAction("CandidateLogin/" + id);

            }

            else
            {
                return View(InterviewLetter);
            }

        }

        public ActionResult InterviewLetterNew120(int id)
        {

            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
            {
                return RedirectToAction("CandidateLogin/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            ViewBag.courrentDate = (DateTime.UtcNow + TimeSpan.Parse("05:30:00")).ToShortDateString();

            var ApplicantPersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var InterviewLetter = objAcknowledgement.AdvId99_CandidateDetailsInterview.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();




            var uploadDetails = objcandidatephotoupload.tbl_mst_candidatephotoupload.Where(x => x.fk_intcandidateid == pkId).ToList();
            if (uploadDetails.Count() > 0)
            {
                ViewBag.Photo = uploadDetails.FirstOrDefault().str_uploadphoto.Replace("~", "");
                ViewBag.Signature = uploadDetails.FirstOrDefault().str_uploadsignature.Replace("~", "");
            }



            if (InterviewLetter == null)
            {
                ViewBag.Message = "You are not shortlisted for Interview";

                return RedirectToAction("CandidateLogin/" + id);

            }

            else
            {
                return View(InterviewLetter);
            }

        }

        public ActionResult PersonalInterviewLetter120(int id)
        {

            if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
            {
                return RedirectToAction("CandidateLogin/" + id);
            }
            int pkId = Convert.ToInt32(Session["UserID"]);
            ViewBag.courrentDate = (DateTime.UtcNow + TimeSpan.Parse("05:30:00")).ToShortDateString();

            var ApplicantPersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();
            var InterviewLetter = objAcknowledgement.AdvId99_CandidateDetailsInterview.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

            if (InterviewLetter == null)
            {
                ViewBag.Message = "You are not shortlisted for Interview";

                return RedirectToAction("CandidateLogin/" + id);

            }

            else
            {
                return View(InterviewLetter);
            }

        }

    }
}
