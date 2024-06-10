using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Models;
using Hindustancopperlimited.GlobalClass;
using System.Web.Security;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Security.Cryptography;
using Hindustancopperlimited.Models.CommonClass;
using Microsoft.Office.Interop.Excel;
using System.Data.Entity;
using System.Text.RegularExpressions;
using Org.BouncyCastle.Asn1.Cmp;
using System.Runtime.InteropServices.ComTypes;

namespace Hindustancopperlimited.Controllers
{
    public class RecruitmentNewController : Controller
    {
        //
        // GET: /Recruitment/
        public static string EmailNoCondition = "nareshkumarsunkari9@gmail.com";//"sayantikaghosh1999@gmail.com";//"dandukalyan2000@gmail.com";//"peeyushsingh.infoneotech@gmail.com";//"rajiitb26@gmail.com"; //"kamlesh.k2908@gmail.com";//"peeyushsingh.infoneotech@gmail.com";//"kamlesh.cwc@gmail.com";//"yogithabaskaran@gmail.com";//
        public RecruitmentNewController()
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
                            var message = "Thanks for registering with Hindustan Copper Limited  <br> Following are your login credentials: <br> Username: " + CandidateRegistrationForRecruitment.strEmail + "<br>Your password is :" + Session["autuPassword"] + "<br>Login Link : " + "https://www.hindustancopper.com/RecruitmentNew/CandidateLogin" + "/" + id;
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
            recaptcha();
            //captcha
            if (Session["checkDEvice"] != null && Session["checkDevice"].ToString() == "Yes")
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


                        if (id != null && loginuser.Is1stTime != "YES")
                        {
                            return RedirectToAction("Dashboard/" + id, "RecruitmentNew");
                        }
                        else if (loginuser.Is1stTime == "YES")
                        {
                            return RedirectToAction("ChangePassword", "RecruitmentNew");
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
                                return RedirectToAction("Dashboard/" + checkDublicate.FirstOrDefault().fk_advertiseid, "RecruitmentNew");
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

                Utility.SendEmail(CandidateRegistratio.strEmail, "Set New Password.", "Please click the link bellow :https://hindustancopper.com/RecruitmentNew/SetPassword?id=" + Utility.Encrypt(obj.strAutoId));
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
                //IQueryable<tbl_CandidateInterviewLetters> inter = objContexts.tbl_CandidateInterviewLetters.Where(x => x.fk_CandidateId == pkId).AsQueryable();
                //if (inter != null)
                //{
                //    ViewBag.InterviewLetter = objContexts.vw_InterviewCall.Where(x => x.CandidateId == pkId).FirstOrDefault();
                //}
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
                if (Session["UserID"] == null || Convert.ToInt64(Session["ActiveId" + id]) != id)
                {
                    return RedirectToAction("CandidateLogin/" + id);
                }
                int pkId = Convert.ToInt32(Session["UserID"]);

                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
                //if (!CheckEmailExclude() && (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1)))
                //{
                //    return RedirectToAction("Dashboard/" + id);
                //}
                int? fk_dicipline;
                var checkDublivate = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId);
                var checkDublivate_obj = checkDublivate.FirstOrDefault() ?? new tbl_mst_CandidatePersonalDetails();

                //if (checkDublivate_obj != null && checkDublivate_obj.fk_advertiseid != id) {
                //    return RedirectToAction("CandidatePersonalDetails/" + checkDublivate_obj.fk_advertiseid);
                //}
                fk_dicipline = checkDublivate_obj.fk_dicipline;
                int? fk_postid = checkDublivate_obj.fk_postid;

                ViewBag.IsFinalSubmit = checkDublivate_obj.strFinalSubmit;
                List<Vw_Postdesiciplinedetails> listDis = new Common().GetPostdesiciplinedetails(id);
                var newList = listDis.GroupBy(a => a.fk_diciplineid).Select(a => a.FirstOrDefault()).ToList();
                ViewBag.fk_dicipline = new SelectList(newList, "Pk_Disciplineid", "DisciplineName", fk_dicipline);

                ViewBag.fk_postid = new SelectList(newList, "Pk_Postid", "Postname", fk_postid);

                using (var ctx = new tbl_mst_CandidateCertificateDetailsContext())
                {
                    var qte = ctx.tbl_mst_CandidateCertificateDetails.Where(a => a.fk_CandidateId == pkId).ToList();
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
                    ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.ToList(), "str_gender", "str_gender");
                    ViewBag.strCategory = new SelectList(objCast.Castes.OrderBy(x => x.strCasteName).ToList(), "strCasteName", "strCasteName");
                    using (tblCasteCategoriesContext db = new tblCasteCategoriesContext())
                    {
                        ViewBag.CasteCategoryId = new SelectList((from s in db.tblCasteCategories.ToList()
                                                                  select new
                                                                  {
                                                                      CasteCategoryId = s.Id,
                                                                      Name = s.Name
                                                                  }),
                            "CasteCategoryId",
                            "Name",
                            null);
                    }

                    ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.Where(x => x.is_active == "yes").ToList(), "str_CatName", "str_CatName");
                    ViewBag.strgrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName");
                    ViewBag.strDomicilestate = new SelectList(objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(), "statename", "statename");
                    ViewBag.strState = new SelectList(objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(), "statename", "statename");
                    ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(), "statename", "statename");
                    int CandiadateId = Convert.ToInt32(Session["UserID"]);
                    var loginDetails = objContext.tbl_mst_CandidateRegistrationForRecruitment.Where(x => x.Candidate_Pk_intID == CandiadateId).FirstOrDefault();
                    ViewBag.strApplicantName = loginDetails.strCandidateFName + " " + loginDetails.strCandidateMName + " " + loginDetails.strCandidateLName;
                    ViewBag.dtDOB = Convert.ToDateTime(loginDetails.dtDOB).ToString("dd-MM-yyyy");

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
                    var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == postId && x.fk_advertisementid == id).FirstOrDefault();
                    if (postCaitareaDetails != null)
                    {
                        sampleSentence = postCaitareaDetails.str_qualification;
                    }
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
                    string strEssen = checkDublivate_obj.strEssentialQualification;
                    ViewBag.strEssentialQualification = new SelectList((from s in fstSubject
                                                                        select new
                                                                        {
                                                                            id = s.str_qualification,
                                                                            Name = s.str_qualification
                                                                        }), "id", "name", strEssen);

                    return View();
                }
                else
                {


                    using (tblCasteCategoriesContext db = new tblCasteCategoriesContext())
                    {
                        ViewBag.CasteCategoryId = new SelectList((from s in db.tblCasteCategories.ToList()
                                                                  select new
                                                                  {
                                                                      CasteCategoryId = s.Id,
                                                                      Name = s.Name
                                                                  }),
                            "CasteCategoryId",
                            "Name",
                             checkDublivate_obj.CasteCategoryId);
                    }

                    ViewBag.fk_postid = new SelectList(listDis.Where(a => a.fk_discipline == fk_dicipline), "Pk_Postid", "Postname", fk_postid);

                    ViewBag.fk_advertiseid = id;
                    int? postId = checkDublivate_obj.fk_postid;
                    var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == postId && x.fk_advertisementid == id).FirstOrDefault();
                    var list = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_advertisementid == id).ToList();
                    if (postCaitareaDetails == null)
                    {
                        Response.Redirect("/RecruitmentNew/Dashboard/" + id);
                        return View();
                    }
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
                                                                        }), "id", "name", checkDublivate_obj.strEssentialQualification);

                    string pwdAll = postCaitareaDetails.str_pwd;
                    string[] words3 = System.Text.RegularExpressions.Regex.Split(pwdAll, ",");
                    List<string> pwd = new List<string>();
                    foreach (var quliName in words3)
                    {
                        pwd.Add(quliName.Trim(' '));
                    }

                    ViewBag.dtDOB = Convert.ToDateTime(checkDublivate_obj.dtDOB).ToString("dd-MM-yyyy");

                    ViewBag.strGender = new SelectList(objGender.tbl_mst_gender.Where(t => Gender.Contains(t.str_gender)), "str_gender", "str_gender", checkDublivate_obj.strGender);
                    ViewBag.strCategory = new SelectList(objCast.Castes.Where(t => cast.Contains(t.strCasteName)), "strCasteName", "strCasteName", checkDublivate_obj.strCategory);
                    ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.Where(t => pwd.Contains(t.str_CatName) && t.Pk_intPWDCatId == 1 || t.Pk_intPWDCatId == 2 || t.Pk_intPWDCatId == 3 || t.Pk_intPWDCatId == 4), "str_CatName", "str_CatName", checkDublivate_obj.strtypeofdisable);

                    //    ViewBag.strgrade = new SelectList(objGrade_Designation.tbl_mstGrade_Designation.ToList(), "strGradeName", "strGradeName", checkDublivate.FirstOrDefault().strgrade);
                    ViewBag.strDomicilestate = new SelectList(objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(), "statename", "statename", checkDublivate_obj.strDomicilestate);
                    ViewBag.strState = new SelectList(objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(), "statename", "statename", checkDublivate_obj.strState);
                    ViewBag.strPermanentState = new SelectList(objstate.tbl_mst_state.OrderBy(x => x.statename).ToList(), "statename", "statename", checkDublivate_obj.strPermanentState);
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
                ViewBag.strtypeofdisable = new SelectList(objPWDCategory.tbl_mst_PWDCategory.Where(x => x.is_active == "yes").ToList(), "str_CatName", "str_CatName", tbl_mst_CandidatePersonalDetails.strtypeofdisable);
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
                var fremaxage = ConfigurationManager.AppSettings["MaxAge_Adv" + id] ?? "40";

                if (CommonBase.IsAgeCriteriaNotMatch(tbl_mst_CandidatePersonalDetails.dtDOB, postCaitareaDetails.dt_compareDate, freminage, fremaxage, tbl_mst_CandidatePersonalDetails.strCategory, tbl_mst_CandidatePersonalDetails.strPWD == "Yes", tbl_mst_CandidatePersonalDetails.strExserviceMan == "Yes", tbl_mst_CandidatePersonalDetails.strSportsperson == "Yes"))
                {
                    ViewBag.Message = "Age Criteria Not Met";
                    return View();
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


                        using (var ctx = new tbl_mst_CandidateCertificateDetailsContext())
                        {
                            int ii = 0;
                            List<tbl_mst_CandidateCertificateDetails> list = new List<tbl_mst_CandidateCertificateDetails>();
                            for (int i = 0; i < 2; i++)
                            {
                                tbl_mst_CandidateCertificateDetails obj = new tbl_mst_CandidateCertificateDetails();
                                ii = i;
                                if (!string.IsNullOrEmpty(frm["CertificateName" + ii]))
                                {
                                    obj.fk_CandidateId = candidateId;
                                    obj.CertificateName = Convert.ToString(frm["CertificateName" + ii]);
                                    obj.CertificateNo = Convert.ToString(frm["CertificateNo" + ii]);
                                    obj.CertificateIssueDate = Convert.ToString(frm["CertificateIssueDate" + ii]);
                                    obj.CertificateExpiryDate = Convert.ToString(frm["CertificateExpiryDate" + ii]);
                                    obj.IssuingAuthority = Convert.ToString(frm["IssuingAuthority" + ii]);
                                    list.Add(obj);
                                }
                            }
                            var qte = ctx.tbl_mst_CandidateCertificateDetails.Where(a => a.fk_CandidateId == candidateId).ToList();
                            if (qte.Count == list.Count)
                            {
                                qte.ForEach(a => a.CertificateName = a.CertificateName + DateTime.UtcNow.ToString("ddMMyyHHmmss"));
                                ctx.SaveChanges();
                                int newi = 0;
                                foreach (var q in qte)
                                {
                                    q.fk_CandidateId = list[newi].fk_CandidateId;
                                    q.CertificateName = list[newi].CertificateName;
                                    q.CertificateNo = list[newi].CertificateNo;
                                    q.CertificateIssueDate = list[newi].CertificateIssueDate;
                                    q.CertificateExpiryDate = list[newi].CertificateExpiryDate;
                                    q.IssuingAuthority = list[newi].IssuingAuthority;
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
                                foreach (var q in list)
                                {
                                    ctx.tbl_mst_CandidateCertificateDetails.Add(q);
                                    ctx.SaveChanges();
                                }

                            }

                        }


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
                            cmd.Parameters.Add(new SqlParameter("@strPWD", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strPWD; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strExserviceMan", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strExserviceMan; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strInternalCandidate", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strInternalCandidate; //Pass the parameter


                            cmd.Parameters.Add(new SqlParameter("@strReligion", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strReligion; //Pass the parameter



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
                            cmd.Parameters.Add(new SqlParameter("@strDisableDetail", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strDisableDetail; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strcertificateno1", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateno1; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@dt_certificateissuedate1", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dt_certificateissuedate1; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strcertificateissue1", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strcertificateissue1; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@stremployeecode", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.stremployeecode; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strgrade", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strgrade; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strplaceposting", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strplaceposting; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strpresentdesignation", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strpresentdesignation; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@dt_presententrydate", SqlDbType.DateTime)).Value = tbl_mst_CandidatePersonalDetails.dt_presententrydate; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@fk_advertiseid", SqlDbType.Int)).Value = id; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strapplyproper", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strapplyproper; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strMotherName", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strMotherName; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strSpouseName", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strSpouseName; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strAlternate_EmaiID", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strAlternate_EmaiID; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strPANNo", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strPANNo; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strAadharNo", SqlDbType.NVarChar)).Value = tbl_mst_CandidatePersonalDetails.strAadharNo; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strEssentialQualification", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strEssentialQualification; //Pass the parameter
                            cmd.Parameters.Add(new SqlParameter("@strSportsperson", SqlDbType.VarChar)).Value = tbl_mst_CandidatePersonalDetails.strSportsperson; //Pass the parameter
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

                //string pwdAll = postCaitareaDetails.str_pwd;
                //string[] words3 = System.Text.RegularExpressions.Regex.Split(pwdAll, ",");
                //List<string> pwd = new List<string>();
                //foreach (var quliName in words3)
                //{
                //    pwd.Add(quliName.Trim(' '));
                //}

                return Json(new { GenderAll = Gender, castAll = cast, });

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
                ViewBag.hidMaxExpdate = Convert.ToDateTime("01/01/2024");
                ViewBag.IsGATERequired = postCaitareaDetails.IsGATERequired;
                Session["IsGATERequired"] = postCaitareaDetails.IsGATERequired;



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


                var educationAll = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == CandidatePersonalDetails.fk_CandidateId).ToList();
                if (educationAll.Count() > 0)
                {
                    if (educationAll.FirstOrDefault().EduQulifi != null)
                    {
                        ViewBag.selectValue = educationAll.FirstOrDefault().EduQulifi;
                        //ViewBag.EduQulifi = new SelectList(fstSubject, "str_qualification", "str_qualification", educationAll.FirstOrDefault().EduQulifi);
                    }
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
                            ViewData["Str_passingyear" + j] = Convert.ToDateTime(educationAll[i].Str_passingyear).ToString("yyyy-MM-dd").Replace("/", "-");
                        }
                        ViewData["Str_duration" + j] = educationAll[i].Str_duration;
                        ViewData["Str_Marks" + j] = educationAll[i].Str_Marks;
                        ViewData["Str_division" + j] = educationAll[i].Str_division;
                        ViewData["StrRemarks" + j] = educationAll[i].StrRemarks;

                        if (educationAll[i].Str_course != "" && educationAll[i].Str_duration == "")
                        {
                            ViewBag.chk_IsPersuing = "true";
                        }
                        else
                        {
                            ViewBag.chk_IsPersuing = "false";
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
                            ViewBag.PassingYear1 = response[0].PassingYear;
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
        public ActionResult EducationDetails(FormCollection frm, tbl_mst_CandidateQualification obj, int id)
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
                for (int i = 0; i <= 4; i++)
                {
                    var j = i.ToString();
                    if (j == "0")
                    {
                        j = "";
                    }

                    if ((frm["Str_exampassed" + j] ?? "") == CandidatePersonalDetails.strEssentialQualification)
                    {
                        if (!chk_IsPersuing)
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
                        //if ((Convert.ToString(postName.Postname) == "Management Trainee" || Convert.ToString(postName.Postname) == "Graduate Engineer Trainee") && i==2)
                        //{
                        //    IsMarksRequiredMatched = (Convert.ToDecimal(frm["Str_Marks" + j]) >= 60);

                        //}
                    }

                }
                string validmsg = "";
                for (var i = 0; i < myList.Count; i++)
                {
                    var myString = myList[i];
                    if (i == myList.Count - 1 && myList[i].ToString() != "")
                    {
                        // this is the last item in the list
                        //if ((Convert.ToString(postName.Postname) == "Management Trainee" || Convert.ToString(postName.Postname) == "Graduate Engineer Trainee"))
                        //{
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
                        //}



                    }
                }


                if (!IsMarksRequiredMatched)
                {
                    ViewBag.Message = validmsg;
                    return View();
                }
                if (!IsRequiredMatched && chk_IsPersuing != true)
                {
                    ViewBag.IsGATERequired = postCaitareaDetails.IsGATERequired;
                    var educationAll = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == CandidatePersonalDetails.fk_CandidateId).ToList();
                    if (educationAll.Count() > 0)
                    {
                        if (educationAll.FirstOrDefault().EduQulifi != null)
                        {
                            ViewBag.selectValue = educationAll.FirstOrDefault().EduQulifi;
                            //ViewBag.EduQulifi = new SelectList(fstSubject, "str_qualification", "str_qualification", educationAll.FirstOrDefault().EduQulifi);
                        }
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
                            ViewData["Str_Marks" + j] = educationAll[i].Str_Marks;
                            ViewData["Str_division" + j] = educationAll[i].Str_division;
                            ViewData["StrRemarks" + j] = educationAll[i].StrRemarks;
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
                                ViewBag.PassingYear1 = response[0].PassingYear;
                                ViewBag.RegistrationNo1 = response[0].RegistrationNo;
                                ViewBag.str_GATEResult = response[0].str_GATEResult;
                                //ViewBag.Remark1 = response[0].Remark;

                                //ViewBag.GateEssentialQuali1 = new SelectList(fstSubject, "str_qualification", "str_qualification", response[0].EssentialQualificationForPost);
                            }

                        }
                    }

                    ViewBag.Message = "Essential Qualification with " + (CandidatePersonalDetails.strCategory == "SC" || CandidatePersonalDetails.strCategory == "ST" ? "55" : "60") + "% marks in the qualifying degree";
                    // ViewBag.Message = "Essential Qualification Not Mached With Current Post";
                    return View();

                }
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
                    for (int i = 1; i < 3; i++)
                    {
                        if (frm["Str_exampassed_add_" + i] != null && !string.IsNullOrEmpty(frm["Str_passingdetails_add_" + i]))
                        {
                            //Convert.ToDateTime(frm["Str_passingyear_add_" + i]) <= postCaitareaDetails.dt_compareDate 
                            if (frm["Str_passingyear_add_" + i] != "" && Convert.ToDateTime(frm["Str_passingyear_add_" + i]) <= DateTime.Now && Convert.ToDecimal(frm["Str_Marks_add_" + i]) <= 100)
                            {
                                tbl_mst_CandidateQualificationAdditional ao = new tbl_mst_CandidateQualificationAdditional();
                                ao.EduQulifi = frm["EduQulifi_add_" + i];
                                ao.Str_exampassed = frm["Str_exampassed_add_" + i].Trim();
                                ao.Str_course = frm["Str_course_add_" + i];
                                ao.Str_board = frm["Str_board_add_" + i];
                                ao.Str_passingdetails = frm["Str_passingdetails_add_" + i];
                                ao.Str_duration = frm["Str_duration_add_" + i];
                                if (frm["StrRemarks_add_" + i] != "Pursuing")
                                {
                                    ao.Str_passingyear = frm["Str_passingyear_add_" + i];
                                }
                                else
                                {
                                    ao.Str_passingyear = current.Year.ToString();
                                }
                                ao.Str_division = frm["Str_division_add_" + i];
                                ao.Str_Marks = frm["Str_Marks_add_" + i];
                                ao.StrRemarks = frm["StrRemarks_add_" + i];
                                ao.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                ao.CandidateId = pkId;
                                ao.Application_No = CandidatePersonalDetails.strApplicationNo;
                                //ctx.tbl_mst_CandidateQualificationAdditional.Add(ao);
                                //ctx.SaveChanges();
                                addList.Add(ao);
                            }
                        }
                    }


                    if (addList.Count >= qte.Count)
                    {
                        for (int i = 0; i < addList.Count; i++)
                        {
                            if (i < qte.Count)
                            {
                                qte[i] = addList[i];
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
                                qte[i] = addList[i];
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
                    if (file.Count > 0)
                    {
                        var folder = "Upload/GATECertificate";
                        string ext = Path.GetExtension(file[0].FileName);
                        ///  long size = fi.Length;  
                        ///  file_size > 1048576 || file_size < 20480
                        var aa = file[0].ContentLength;
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
                            ViewBag.Message = "GATE Document upload only pdf format.";
                            return View();
                        }
                        var fileName = "GATE_" + id + "_" + CandidatePersonalDetails.fk_CandidateId + "_" + ext;
                        fileName = fileName.Replace(" ", "");
                        var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/" + folder + "/") + fileName);
                        file[0].SaveAs(path);
                        fileUrl = "/" + folder + "/" + fileName;
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
                        ViewBag.Message = "GATE Qualification can not be blank.";
                        return View();
                    }
                    if ((list.Select(a => a.str_GATEResult).FirstOrDefault() ?? "") == "")
                    {
                        ViewBag.Message = "GATE Document upload  is required can not be blank.";
                        return View();
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
                var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();

                var eduDetails = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == pkId).OrderByDescending(a => a.Pk_Qualification).FirstOrDefault();
                ViewBag.QualiDate = "";
                if (eduDetails != null)
                {
                    ViewBag.QualiDate = eduDetails.Str_passingyear;
                    // ViewBag.dt_fromdate = eduDetails.Str_passingyear;
                }

                ViewBag.strEssentialQualification = CandidatePersonalDetails.strEssentialQualification;
                ViewBag.IsFinalSubmit = CandidatePersonalDetails.strFinalSubmit;
                //if (CandidatePersonalDetails != null && CandidatePersonalDetails.strFinalSubmit == "Yes")
                //{
                //    ViewBag.Message = string.Format("Your Final Submission have been done. You can not update information!");
                //    return View();
                //}
                var datecertificatestart = certificate.tbl_mst_CandidateCertificateDetails.Where(x => x.fk_CandidateId == pkId && (x.CertificateName == "Valid Mate Certificate of Competency for Metalliferous Mine(Unrestricted)") || (x.CertificateName == "Valid Blaster Certificate of Competency for Metalliferous Mine (Unrestricted)") || (x.CertificateName == "Valid 1st Class Winding Engine Driver’s Certificate") || (x.CertificateName == "Valid 2nd Class Winding Engine Driver’s Certificate")).Select(a => a.CertificateIssueDate).FirstOrDefault();
                if (!string.IsNullOrEmpty(datecertificatestart))
                {
                    //ViewBag.datecertificatestart = Convert.ToDateTime(DateTime.ParseExact(datecertificatestart, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture)).ToString("yyyy-MM-dd");

                    DateTime dt = DateTime.ParseExact(datecertificatestart.ToString(), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture); ;
                    ViewBag.datecertificatestart = dt.ToString("yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);


                }

                var noticeDetails = objtbl_employmentnotice.tbl_employmentnotice.Where(x => x.Pk_employmentid == id).FirstOrDefault();
                //if (!CheckEmailExclude() && (current < noticeDetails.dtstartdate || current > noticeDetails.dtclosedate.Value.AddDays(1) || CandidatePersonalDetails.strFinalSubmit == "Yes"))
                if (!CheckEmailExclude() && (current <= noticeDetails.dtstartdate || current >= noticeDetails.dtclosedate || CandidatePersonalDetails.strFinalSubmit == "Yes"))
                {
                    return RedirectToAction("Dashboard/" + id);
                }

                ViewBag.str_organisationType = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType1 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType2 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");
                ViewBag.str_organisationType3 = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType");


                var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid).FirstOrDefault();
                ViewBag.hidMaxExpdate = postCaitareaDetails.dt_compareDate.Value.ToString("dd-MM-yyyy");
                ViewBag.fk_postid = new SelectList(new List<tbl_mst_Postnew>(), "Pk_Postid", "Postname", null);

                var expAll = tblExperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == CandidatePersonalDetails.fk_CandidateId).ToList();
                int numberLoop = expAll.Count();
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
                    string totalExp = "0";
                    if (expAll != null)
                    {
                        decimal dectotalExp = 0;
                        foreach (var getTotalExp in expAll.ToList())
                        {
                            dectotalExp = dectotalExp + Convert.ToDecimal(getTotalExp.str_noyears);
                        }
                        var totalYears = Math.Truncate(dectotalExp / 365);
                        var totalMonths = Math.Truncate((dectotalExp % 365) / 30);
                        var remainingDays = Math.Truncate((dectotalExp % 365) % 30);
                        totalExp = totalYears + " Years " + totalMonths + " Months " + remainingDays + "  Days ";
                    }
                    ViewData["str_organisationType" + j] = new SelectList(objOType.tbl_mstOrganisationType.Where(x => x.isActive == true).ToList(), "strOrganisationType", "strOrganisationType", expAll[i].str_organisationType);
                    ViewData["StrEmploymentPresentStatus" + j] = expAll[i].StrEmploymentPresentStatus;
                    ViewData["str_organisation" + j] = expAll[i].str_organisation;
                    ViewData["Str_designation" + j] = expAll[i].Str_designation;
                    ViewData["str_CTC" + j] = expAll[i].str_CTC;
                    ViewData["str_PayScale" + j] = expAll[i].str_PayScale;
                    ViewData["dt_fromdate" + j] = expAll[i].dt_fromdate.ToString("yyyy-MM-dd").Replace("/", "-");
                    ViewData["dt_todate" + j] = expAll[i].dt_todate.ToString("yyyy-MM-dd").Replace("/", "-");
                    ViewData["str_noyears" + j] = expAll[i].str_noyears;
                    ViewData["totalYearproper" + j] = totalExp;
                }

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

                int startApplicatId = Convert.ToInt32(ConfigurationManager.AppSettings["startId"]);
                int pkId = Convert.ToInt32(Session["UserID"]);


                var CandidatePersonalDetails = objcanpersonaldetails.tbl_mst_CandidatePersonalDetails.Where(x => x.fk_CandidateId == pkId).FirstOrDefault();


                //Akshat Code to check Experience

                var postName = objGrade_Designation.tbl_mst_Postnew.Where(x => x.Pk_Postid == CandidatePersonalDetails.fk_postid).FirstOrDefault();
                if (!string.IsNullOrEmpty(frm["totalYearproper"]))
                {
                    string ExperienceData = Convert.ToString(frm["totalYearproper"]);
                    string resultString = Regex.Match(ExperienceData, @"\d+").Value;
                    if ((Convert.ToString(postName.Postname) == "Senior Manager") && Convert.ToInt32(resultString) < 9)// || Convert.ToString(postName.Postname) == "Graduate Engineer Trainee"))
                    {
                        ViewBag.Message = "Experience Is Not Met With Requirement";
                        return View();

                    }
                    if ((Convert.ToString(postName.Postname) == "Deputy Manager") && Convert.ToInt32(resultString) < 3)// || Convert.ToString(postName.Postname) == "Graduate Engineer Trainee"))
                    {
                        ViewBag.Message = "Experience Is Not Met With Requirement";
                        return View();

                    }

                }

                //End From Here 


                ViewBag.IsFinalSubmit = CandidatePersonalDetails.strFinalSubmit;
                if (CandidatePersonalDetails != null && CandidatePersonalDetails.strFinalSubmit == "Yes")
                {
                    ViewBag.Message = string.Format("Your Final Submission have been done. You can not update information!");
                    return View();
                }

                var checkDublicate = tblExperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == pkId);
                var educationAll = tblQulifi.tbl_mst_CandidateQualification.Where(x => x.Fk_int_CandidateRegistrationID == pkId).ToList();
                var postCaitareaDetails = objpostcriteria.tbl_transaction_Postcriteria.Where(x => x.fk_postid == CandidatePersonalDetails.fk_postid && x.fk_advertisementid == CandidatePersonalDetails.fk_advertiseid).FirstOrDefault();

                ViewBag.hidMaxExpdate = postCaitareaDetails.dt_compareDate.Value.ToString("dd-MM-yyyy");

                foreach (var Dublicate in checkDublicate)
                {
                    tblExperience.Entry(Dublicate).State = EntityState.Deleted;
                }
                tblExperience.SaveChanges();
                if (checkDublicate.ToList().Count() == 0 && pkId > startApplicatId)
                {

                    for (int i = 0; i <= 3; i++)
                    {

                        var j = i.ToString();
                        if (j == "0")
                        {
                            j = "";
                        }

                        if (!string.IsNullOrEmpty(frm["str_organisationType" + j]) && !string.IsNullOrEmpty(frm["StrEmploymentPresentStatus" + j]) && !string.IsNullOrEmpty(frm["str_organisation" + j]) && !string.IsNullOrEmpty(frm["Str_designation" + j]) && !string.IsNullOrEmpty(frm["dt_fromdate" + j]) && !string.IsNullOrEmpty(frm["str_noyears" + j]) && !string.IsNullOrEmpty(frm["totalYearproper"]))
                        {

                            if ((frm["str_organisationType" + j] != "Private" && frm["str_organisationType" + j] != "Other"))
                            {

                                objExp.Str_designation = frm["Str_designation" + j];

                                objExp.dt_fromdate = Convert.ToDateTime(frm["dt_fromdate" + j]);
                                if (frm["StrEmploymentPresentStatus" + j] == "Currently Working")
                                {
                                    objExp.dt_todate = Convert.ToDateTime(frm["hidMaxExpdate"]);

                                }
                                else
                                {
                                    objExp.dt_todate = Convert.ToDateTime(frm["dt_todate" + j]);
                                }
                                objExp.str_noyears = frm["str_noyears" + j];
                                objExp.str_organisation = frm["str_organisation" + j];
                                objExp.str_organisationType = frm["str_organisationType" + j];
                                objExp.str_remarks = frm["str_remarks" + j];
                                objExp.str_organisationType = frm["str_organisationType" + j];
                                objExp.str_CTC = "";
                                objExp.str_PayScale = frm["str_PayScale" + j];
                                objExp.StrEmploymentPresentStatus = frm["StrEmploymentPresentStatus" + j];
                                objExp.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                objExp.Fk_CandidateRegistrationID = pkId;
                                objExp.ApplicationNo = CandidatePersonalDetails.strApplicationNo;
                                tblExperience.tbl_mst_CandidateExperience.Add(objExp);
                                tblExperience.SaveChanges();
                            }

                            else
                            {
                                if ((frm["str_organisationType" + j] == "Private" || frm["str_organisationType" + j] == "Other") && !string.IsNullOrEmpty(frm["str_CTC" + j]))
                                {
                                    objExp.Str_designation = frm["Str_designation" + j];

                                    objExp.dt_fromdate = Convert.ToDateTime(frm["dt_fromdate" + j]);
                                    if (frm["StrEmploymentPresentStatus" + j] == "Currently Working")
                                    {
                                        objExp.dt_todate = Convert.ToDateTime(frm["hidMaxExpdate"]);

                                    }
                                    else
                                    {
                                        objExp.dt_todate = Convert.ToDateTime(frm["dt_todate" + j]);
                                    }
                                    objExp.str_noyears = frm["str_noyears" + j];
                                    objExp.str_organisation = frm["str_organisation" + j];
                                    objExp.str_organisationType = frm["str_organisationType" + j];
                                    objExp.str_remarks = frm["str_remarks" + j];
                                    objExp.str_organisationType = frm["str_organisationType" + j];
                                    objExp.str_CTC = frm["str_CTC" + j];
                                    objExp.str_PayScale = "";
                                    objExp.StrEmploymentPresentStatus = frm["StrEmploymentPresentStatus" + j];
                                    objExp.dtEntyDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                    objExp.Fk_CandidateRegistrationID = pkId;
                                    objExp.ApplicationNo = CandidatePersonalDetails.strApplicationNo;
                                    tblExperience.tbl_mst_CandidateExperience.Add(objExp);
                                    tblExperience.SaveChanges();
                                }
                            }

                        }
                    }


                }


                var expDetails = tblExperience.tbl_mst_CandidateExperience.Where(x => x.Fk_CandidateRegistrationID == pkId);

                decimal totalExpYear = 0;
                if (expDetails.Count() > 0)
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

                if ((educationAll.Count() == 1 && totalExpYear >= 3) || (educationAll.Count() == 1 && totalExpYear >= 5) || (educationAll.Count >= 2 && totalExpYear >= 1) || (educationAll.Count >= 3 && totalExpYear >= 1) || (educationAll.Count >= 3 && totalExpYear <= 1) || (educationAll.Count >= 2 && totalExpYear >= 3) || (educationAll.Count >= 1 && totalExpYear <= 2))
                {
                    return RedirectToAction("UploadDetails/" + id);
                }
                else
                {
                    if ((educationAll.Count() == 4 && totalExpYear >= 2 && educationAll.Where(x => x.Str_exampassed.Trim() == subjectName).Count() == 0 && CandidatePersonalDetails.fk_postid == newpostIdforexp) || (educationAll.Count() == 5 && CandidatePersonalDetails.fk_postid == newpostIdforexp) || (educationAll.Count() == 3 && CandidatePersonalDetails.fk_postid == newpostIdforfre && totalExpYear >= 1) || (educationAll.Count() == 2 && CandidatePersonalDetails.fk_postid == newpostIdforexp && totalExpYear >= 1))
                    {
                        return RedirectToAction("UploadDetails/" + id);
                    }
                    else
                    {

                        if ((educationAll.Count() == 3 && CandidatePersonalDetails.strExserviceMan == "Yes" && educationAll.Where(x => x.Str_exampassed.Trim() == subjectName).Count() == 0 && CandidatePersonalDetails.fk_postid == newpostIdforexp) || (educationAll.Count() == 5 && CandidatePersonalDetails.fk_postid == newpostIdforexp) || (educationAll.Count() == 1 && CandidatePersonalDetails.fk_postid == newpostIdforfre && CandidatePersonalDetails.strExserviceMan == "Yes"))
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
                return RedirectToAction("CandidateLogin/" + id, "RecruitmentNew/" + id);
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
                return RedirectToAction("CandidateLogin/" + id, "RecruitmentNew/" + id);
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


                if ((updatePersonalDetails.strCategory == "EWS" && updatePersonalDetails.strInternalCandidate == "No") || (updatePersonalDetails.strCategory == "OBC (Non-Creamy Layer)" && updatePersonalDetails.strInternalCandidate == "No") || (updatePersonalDetails.strCategory == "General" && updatePersonalDetails.strInternalCandidate == "No"))
                {
                    return RedirectToAction("PayOnline/" + id);
                }
                else
                {
                    //updatePersonalDetails.strPWD = "No";
                    updatePersonalDetails.strFinalSubmit = "Yes";
                    updatePersonalDetails.dtFinalSubmitDate = current;
                    objcanpersonaldetails.Entry(updatePersonalDetails).State = EntityState.Modified;
                    objcanpersonaldetails.SaveChanges();
                    return RedirectToAction("Acknowledgement/" + id);
                }
            }

            //       else if ((educationAll.Count() == 4 && educationAll.Where(x => x.Str_exampassed.Trim() == subjectName).Count() == 0 && updatePersonalDetails.strExserviceMan == "Yes" && updatePersonalDetails.fk_postid == newpostIdforexp) || (educationAll.Count() == 5 && updatePersonalDetails.fk_postid == newpostIdforexp) || (educationAll.Count() == 3 && updatePersonalDetails.fk_postid == newpostIdforfre && updatePersonalDetails.strExserviceMan == "Yes"))

            //if ((educationAll.Count() >= 3 && totalExpYear == 0 && Convert.ToString(postName.Postname) == "Management Trainee") || (educationAll.Count() >= 3 && totalExpYear >= 0 && Convert.ToString(postName.Postname) == "Graduate Engineer Trainee")) 
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
                    var mem = chl.CreateRequirtment();
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
                    string surl = "https://www.hindustancopper.com/RecruitmentNew/Success" + "/" + id;// ConfigurationManager.AppSettings["surl"] + "/" + id;
                                                                                                      //string surl = "https://hcl.infoneotech.com/RecruitmentNew/Success" + "/" + id;// ConfigurationManager.AppSettings["surl"] + "/" + id;
                    string furl = "https://www.hindustancopper.com/RecruitmentNew/Failed" + "/" + id;// ConfigurationManager.AppSettings["furl"] + "/" + id;
                    //string furl = "https://hcl.infoneotech.com/RecruitmentNew/Failed" + "/" + id;// ConfigurationManager.AppSettings["furl"] + "/" + id;

                    string udf1 = details.strApplicationNo;
                    string udf2 = details.fk_CandidateId.ToString();
                    string udf3 = details.Pk_int_CandidateRegistrationID.ToString();
                    string udf4 = details.dtDOB.ToString();
                    string udf5 = details.strCategory.ToString();

                    RemotePost myremotepost = new RemotePost();
                    string key = "T6slPe";
                    string salt = "xGLsVGI3LHboLCR4HTkU1ASc9LYCzt3f";

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
                return RedirectToAction("Login/" + id);
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
    }
}
