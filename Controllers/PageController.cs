using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Controllers;
using Hindustancopperlimited.Models;
using System.IO;
using System.Data.Entity;
using System.Web.Security;
using Hindustancopperlimited.GlobalClass;
using System.Security.Cryptography;
using System.Text;
using System.Data;

using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Data.Objects;

namespace Hindustancopperlimited.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/

        tbl_mstPageDetailContext dbContext001 = new tbl_mstPageDetailContext();

        tbl_mst_InvestorRelationsPageContext db = new tbl_mst_InvestorRelationsPageContext();
        VendorRegistrationContext objContext = new VendorRegistrationContext();
        tbl_mstDepartmentContext objContext8 = new tbl_mstDepartmentContext();
        TenderContext _tenderContext = new TenderContext();
        DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        tbl_feedbackcontext objfeedback = new tbl_feedbackcontext();
        tbl_feedbacktitlecontext objtitle = new tbl_feedbacktitlecontext();
        tbl_employmentnoticecontext objNotice = new tbl_employmentnoticecontext();
        vw_EmploymentNotoccontext objVwNotice = new vw_EmploymentNotoccontext();
        tbl_AnnualReportsContext objtbl_AnnualReports = new tbl_AnnualReportsContext();
        tbl_PriceCircularContext objtbl_PriceCircular = new tbl_PriceCircularContext();
        tbl_mstEmployeeContext objEmployee = new tbl_mstEmployeeContext();
        //tbl_mstDepartmentContext objContext8 = new tbl_mstDepartmentContext();
        tbl_ManagementKeyExecutivesContext objManagmntExectve = new tbl_ManagementKeyExecutivesContext();
        Vw_AdvertisementNoticeContext objAdvertisementNotice = new Vw_AdvertisementNoticeContext();
        tbl_mst_Eventsimagedetailscontext objEventsimagedetails = new tbl_mst_Eventsimagedetailscontext();
        VendorsNewContext objContextNew = new VendorsNewContext();
        vw_SpotbookingTenderContext objSpotbookingTenderdetails = new vw_SpotbookingTenderContext();

        public ActionResult AnnexureA()
        {
            return View();
        }
        public ActionResult Sustainability()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AnnexureA(BankerAnnexureA obj)
        {
            return View();
        }

        public ActionResult BlackListedVendors()
        {
            return View();
        }

        public ActionResult ThirdPartyRTIauditReport()
        {
            return View();
        }

        public ActionResult ApplicationText()
        {
            return View();
        }

        public ActionResult VideoPlay()
        {
            return View();
        }
        public ActionResult VideoPlayAug()
        {
            return View();
        }
        public ActionResult VideoPlaySep()
        {
            return View();
        }

          public ActionResult VideoPlayOct()
        {
            return View();
        }



        public ActionResult Search(string id)
        {

            TempData["SearchText"] = id;

            return View();
        }

        public ActionResult CompanyProfile()
        {
            ViewBag.CompanyProfile = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Company Profile").FirstOrDefault().strPageDetails;
            return View();
        }

        public ActionResult TheBoard()
        {
            ViewBag.TheBoard = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "The Board").FirstOrDefault().strPageDetails;
            return View();
        }

        public ActionResult MinisterSecretary()
        {

            ViewBag.MinisterSecretary = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Minister & Secretary").FirstOrDefault().strPageDetails;
            return View();

        }

        public ActionResult ManagementPhilosophy()
        {
            ViewBag.ManagementPhilosophy = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Management Philosophy").FirstOrDefault().strPageDetails;
            return View();
        }

        public ActionResult ManagementKeyExecutives()
        {
            var ManagementKeyExecutiveslist = objManagmntExectve.tbl_ManagementKeyExecutives.OrderByDescending(x => x.pk_int_ManagementKeyExecutives).ToList();
            return View(ManagementKeyExecutiveslist);
        }

        public ActionResult PlantsandOffices()
        {
            ViewBag.PlantsandOffices = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Plant").FirstOrDefault().strPageDetails;
            return View();
        }
        public ActionResult Events()
        {
            //var Event = objContext8.tbl_mst_Events.ToList();
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            var Event = objContext8.tbl_mst_Events.Where(x => x.dtExpiryDate > current).ToList();
            return View(Event);
        }

        public ActionResult DetailsImageGallery1SubImages(int pkId, string imageTitle)
        {

            var tbl_mst_ImageGalleryDetails = objEventsimagedetails.tbl_mst_Eventsimagedetails.Where(x => x.fk_int_eventid == pkId).OrderByDescending(x => x.pk_int_imagedetails).ToList();
            TempData["ImageTitle"] = imageTitle;
            return View(tbl_mst_ImageGalleryDetails);

        }


        public ActionResult Award()
        {
            var Award = objContext8.tbl_mst_AchievementAndAward.ToList();
            return View(Award);
        }
        public ActionResult SalesOffices()
        {
            ViewBag.SalesOffices = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Sales Offices").FirstOrDefault().strPageDetails;
            return View();
        }

        public ActionResult Godowns()
        {
            ViewBag.Godowns = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Godown & Offices").FirstOrDefault().strPageDetails;
            return View();
        }

        public ActionResult VisionandMission()
        {
            ViewBag.VisionandMission = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Vision and Mission").FirstOrDefault().strPageDetails;
            return View();
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

        public ActionResult EmployeeSection()
        {
            //captcha
            recaptcha();
            //captcha
            return View();
        }

        [HttpPost]

        public ActionResult EmployeeSection(Login objUser, FormCollection frm)
        {
            if (ModelState.IsValid)
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

                    if (frm["EmpCd"] != null)
                    {
                        string Code = frm["EmpCd"].ToString();
                        var Employee = objEmployee.tbl_mstEmployee.Where(a => a.EmpCd.Equals(Code)).FirstOrDefault();
                        if (Employee != null)
                        {
                            if (Employee.intDeletedFlag == "0")
                            {
                                string PW = Employee.Password;
                                if (PW == frm["Password"])
                                {
                                    Session["code"] = Employee.ID.ToString();
                                    Session["Desg"] = Employee.Desg.ToString();
                                    Session["Name"] = Employee.F_Name.ToString();
                                    Session["Username"] = Employee.EmpCd.ToString();
                                    Session["UserId"] = Employee.ID.ToString();
                                    Session["UserType"] = "Employee";
                                    Session["strMenuRightID"] = "0";

                                    return RedirectToAction("Employeedetails");
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
                            else
                            {
                                //captcha
                                recaptcha();
                                //captcha
                                ViewBag.Message = string.Format("Invalid Email or Password.");
                                return View();

                            }
                        }
                        else
                        {
                            //captcha
                            recaptcha();
                            //captcha
                            ViewBag.Message = string.Format("Invalid Email ");
                            return View();
                        }
                    }

                }
            }

            return View();
        }
        public ActionResult Employeedetails()
        {

            ViewData["FName"] = Session["Name"].ToString();
            ViewData["Designation"] = Session["Desg"].ToString();
            return View();
        }

        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            Request.Cookies.Clear();
            Session["code"] = null;
            Session["Desg"] = null;
            Session["Name"] = null;
            Session["Username"] = null;
            Session["UserType"] = null;
            Session["strMenuRightID"] = null;
            return RedirectToAction("Index", "Home");
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

                string UserName = Session["Username"].ToString();
                string password = frm["strUsercurrentPwd"].ToString();

                var CandidateRegistration = objEmployee.tbl_mstEmployee.Where(a => a.EmpCd.Equals(UserName) && a.Password.Equals(password)).FirstOrDefault();


                if (frm["strUserPwd"] == frm["strUserRePwd"])
                {
                    CandidateRegistration.Password = frm["strUserPwd"];
                    objEmployee.Entry(CandidateRegistration).State = EntityState.Modified;
                    objEmployee.SaveChanges();
                    return RedirectToAction("EmployeeSection");
                }
                ViewBag.Message = string.Format("Password and Re-Password do not match.");
                return View(CandidateRegistration);
            }
            catch
            {
                ViewBag.Message = string.Format("Current Password do not match.");
                return View();
            }
        }

        // forgot password

        public ActionResult ForgotPassword()
        {

            return View();
        }



        [HttpPost]

        public ActionResult ForgotPassword(tbl_mstEmployee tbl_mstEmployee, FormCollection frm)
        {
            string email = frm["strEmail"].ToString();

            var Registration = objEmployee.tbl_mstEmployee.Where(x => x.EMailId == email).FirstOrDefault();

            if (Registration == null)
            {
                ViewBag.Message = "Please put the currect value.";
            }
            else
            {
                Utility.SendEmail(Registration.EMailId, "New Password.", "Your ID is :" + Registration.EmpCd + "Your password is :" + Registration.Password);
                ViewBag.Message = "Please check your email.";
            }
            return View();

        }


        public ActionResult Achievements()
        {
            ViewBag.Achievements = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Achievements").FirstOrDefault().strPageDetails;
            return View();
        }


        public ActionResult OfficeandGodown()
        {
            // ViewBag.OfficeandGodown = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Office & Godown").FirstOrDefault().strPageDetails;
            return View();
        }

        public ActionResult PriceCircular()
        {
            var tbl_PriceCircular = objtbl_PriceCircular.tbl_PriceCircular.OrderByDescending(x => x.pk_intPriceCircular).ToList();

            return View(tbl_PriceCircular);
        }

        public ActionResult SpotBooking()
        {
            return View();
        }
        public ActionResult FeedbackandBusiness()
        {
            return View();
        }

        public ActionResult MarketingPolicy()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Business-Marketing Policy").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult TenYearsataGlance()
        {
            ViewBag.TenYearsataGlance = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "10 Years at a Glance (Rs. In Lakhs)").FirstOrDefault().strPageDetails;
            return View();

        }


        public ActionResult QuarterlyPerformanceReport()
        {
            DateTime date = (DateTime.UtcNow + TimeSpan.Parse("05:30:00"));
            var month = date.Month;
            int intQuarter = 0;

            tbl_mstParticularMasterContext objParticularMaster = new tbl_mstParticularMasterContext();
            tbl_Quarterly_Reportcontext objQuarterlyReport = new tbl_Quarterly_Reportcontext();

            ViewBag.ParticularMaster = objParticularMaster.tbl_mstParticularMaster.Where(x => x.ParticularStatus == "FN").OrderBy(x => x.ParticularDesc).ToList();
            var QuarterlyReport = objQuarterlyReport.tbl_Quarterly_Report.Where(x => x.txtData == "FN").ToList();

            //
            if (month > 3 && month <= 6)
            {
                intQuarter = 1;
            }
            else if (month > 6 && month <= 9)
            {
                intQuarter = 2;
            }
            else if (month > 9)
            {
                intQuarter = 3;
            }
            else if (month <= 3)
            {
                intQuarter = 4;
            }

            //
            if (intQuarter == 1)
            {
                ViewBag.strCurrentSession = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year - 1;
                ViewBag.strLastYear = date.Year - 2;

                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;




            }
            if (intQuarter == 2)
            {
                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSession = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year;
                ViewBag.strLastYear = date.Year - 1;



                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;

            }
            if (intQuarter == 3)
            {
                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSession = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year;
                ViewBag.strLastYear = date.Year - 1;

                ViewBag.strCurrentSessions = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year;
                ViewBag.strLastYears = date.Year - 1;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;


            }
            if (intQuarter == 4)
            {
                ViewBag.strCurrentSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 4 + "-" + (date.Year - 3).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 2;
                ViewBag.strLastYearf = date.Year - 3;

                ViewBag.strCurrentSession = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year - 1;
                ViewBag.strLastYear = date.Year - 2;

                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;



            }

            return View(QuarterlyReport);
        }
        public ActionResult FirstQuaterly()
        {
            return View();
        }
        public ActionResult SecondQuaterly()
        {
            return View();
        }
        public ActionResult ThirdQuaterly()
        {
            return View();
        }
        public ActionResult FourthQuaterly()
        {
            return View();
        }

        public ActionResult Promotion()
        {
            var tbl_mst_News = objContext8.tbl_mst_News.Where(x => x.strNewsType == "List of Executives Promoted" && EntityFunctions.TruncateTime(x.dtExpiryDate) >= EntityFunctions.TruncateTime(current)).ToList();
            return View(tbl_mst_News);
        }

        public ActionResult OrganizationalChanges()
        {

            var tbl_mst_News = objContext8.tbl_mst_News.Where(x => x.strNewsType == "Organizational Changes" && EntityFunctions.TruncateTime(x.dtExpiryDate) >= EntityFunctions.TruncateTime(current)).ToList();
            return View(tbl_mst_News);
        }

        public ActionResult AnnualReport()
        {
            var tbl_AnnualReports = objtbl_AnnualReports.tbl_AnnualReports.OrderByDescending(x => x.pk_intAnnualReport).ToList();
            return View(tbl_AnnualReports);
        }

        public ActionResult AnnualReportSubsidiaryOrJV()
        {
            return View();
        }


        public ActionResult SalesVolume()
        {
            DateTime date = (DateTime.UtcNow + TimeSpan.Parse("05:30:00"));
            var month = date.Month;
            int intQuarter = 0;

            tbl_mstParticularMasterContext objParticularMaster = new tbl_mstParticularMasterContext();
            tbl_Quarterly_Reportcontext objQuarterlyReport = new tbl_Quarterly_Reportcontext();

            ViewBag.ParticularMaster = objParticularMaster.tbl_mstParticularMaster.Where(x => x.ParticularStatus == "S").OrderBy(x => x.ParticularDesc).ToList();
            var QuarterlyReport = objQuarterlyReport.tbl_Quarterly_Report.Where(x => x.txtData == "SD").ToList();

            //
            if (month > 3 && month <= 6)
            {
                intQuarter = 1;
            }
            else if (month > 6 && month <= 9)
            {
                intQuarter = 2;
            }
            else if (month > 9)
            {
                intQuarter = 3;
            }
            else if (month <= 3)
            {
                intQuarter = 4;
            }

            //
            if (intQuarter == 1)
            {
                ViewBag.strCurrentSession = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year - 1;
                ViewBag.strLastYear = date.Year - 2;

                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;




            }
            if (intQuarter == 2)
            {
                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSession = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year;
                ViewBag.strLastYear = date.Year - 1;



                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;

            }
            if (intQuarter == 3)
            {
                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSession = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year;
                ViewBag.strLastYear = date.Year - 1;

                ViewBag.strCurrentSessions = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year;
                ViewBag.strLastYears = date.Year - 1;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;


            }
            if (intQuarter == 4)
            {
                ViewBag.strCurrentSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 4 + "-" + (date.Year - 3).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 2;
                ViewBag.strLastYearf = date.Year - 3;

                ViewBag.strCurrentSession = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year - 1;
                ViewBag.strLastYear = date.Year - 2;

                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;



            }

            return View(QuarterlyReport);
        }

        public ActionResult SalesRevenue()
        {
            DateTime date = (DateTime.UtcNow + TimeSpan.Parse("05:30:00"));
            var month = date.Month;
            int intQuarter = 0;

            tbl_mstParticularMasterContext objParticularMaster = new tbl_mstParticularMasterContext();
            tbl_Quarterly_Reportcontext objQuarterlyReport = new tbl_Quarterly_Reportcontext();

            ViewBag.ParticularMaster = objParticularMaster.tbl_mstParticularMaster.Where(x => x.ParticularStatus == "S").OrderBy(x => x.ParticularDesc).ToList();
            var QuarterlyReport = objQuarterlyReport.tbl_Quarterly_Report.Where(x => x.txtData == "RD").ToList();

            //
            if (month > 3 && month <= 6)
            {
                intQuarter = 1;
            }
            else if (month > 6 && month <= 9)
            {
                intQuarter = 2;
            }
            else if (month > 9)
            {
                intQuarter = 3;
            }
            else if (month <= 3)
            {
                intQuarter = 4;
            }

            //
            if (intQuarter == 1)
            {
                ViewBag.strCurrentSession = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year - 1;
                ViewBag.strLastYear = date.Year - 2;

                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;




            }
            if (intQuarter == 2)
            {
                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSession = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year;
                ViewBag.strLastYear = date.Year - 1;



                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;

            }
            if (intQuarter == 3)
            {
                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSession = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year;
                ViewBag.strLastYear = date.Year - 1;

                ViewBag.strCurrentSessions = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year;
                ViewBag.strLastYears = date.Year - 1;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;


            }
            if (intQuarter == 4)
            {
                ViewBag.strCurrentSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 4 + "-" + (date.Year - 3).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 2;
                ViewBag.strLastYearf = date.Year - 3;

                ViewBag.strCurrentSession = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year - 1;
                ViewBag.strLastYear = date.Year - 2;

                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;



            }

            return View(QuarterlyReport);
        }

        public ActionResult ProductionReport()
        {
            DateTime date = (DateTime.UtcNow + TimeSpan.Parse("05:30:00"));
            var month = date.Month;
            int intQuarter = 0;

            tbl_mstParticularMasterContext objParticularMaster = new tbl_mstParticularMasterContext();
            tbl_Quarterly_Reportcontext objQuarterlyReport = new tbl_Quarterly_Reportcontext();

            ViewBag.ParticularMaster = objParticularMaster.tbl_mstParticularMaster.Where(x => x.ParticularStatus == "Z").ToList();
            var QuarterlyReport = objQuarterlyReport.tbl_Quarterly_Report.Where(x => x.txtData == "PD").ToList();

            //
            if (month > 3 && month <= 6)
            {
                intQuarter = 1;
            }
            else if (month > 6 && month <= 9)
            {
                intQuarter = 2;
            }
            else if (month > 9)
            {
                intQuarter = 3;
            }
            else if (month <= 3)
            {
                intQuarter = 4;
            }

            //
            if (intQuarter == 1)
            {
                ViewBag.strCurrentSession = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year - 1;
                ViewBag.strLastYear = date.Year - 2;

                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;




            }
            if (intQuarter == 2)
            {
                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSession = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year;
                ViewBag.strLastYear = date.Year - 1;



                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;

            }
            if (intQuarter == 3)
            {
                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;

                ViewBag.strCurrentSession = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year;
                ViewBag.strLastYear = date.Year - 1;

                ViewBag.strCurrentSessions = date.Year + "-" + (date.Year + 1).ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 1 + "-" + (date.Year).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year;
                ViewBag.strLastYears = date.Year - 1;

                ViewBag.strCurrentSessionf = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 1;
                ViewBag.strLastYearf = date.Year - 2;


            }
            if (intQuarter == 4)
            {
                ViewBag.strCurrentSessionf = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strLastSessionf = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessionf = date.Year - 4 + "-" + (date.Year - 3).ToString().Substring(2, 2);
                ViewBag.strCurrentYearf = date.Year - 2;
                ViewBag.strLastYearf = date.Year - 3;

                ViewBag.strCurrentSession = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSession = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSession = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYear = date.Year - 1;
                ViewBag.strLastYear = date.Year - 2;

                ViewBag.strCurrentSessions = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessions = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessions = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYears = date.Year - 1;
                ViewBag.strLastYears = date.Year - 2;

                ViewBag.strCurrentSessiont = date.Year - 1 + "-" + date.Year.ToString().Substring(2, 2);
                ViewBag.strLastSessiont = date.Year - 2 + "-" + (date.Year - 1).ToString().Substring(2, 2);
                ViewBag.strPrevLastSessiont = date.Year - 3 + "-" + (date.Year - 2).ToString().Substring(2, 2);
                ViewBag.strCurrentYeart = date.Year - 1;
                ViewBag.strLastYeart = date.Year - 2;



            }

            return View(QuarterlyReport);
        }


        public ActionResult ContinuousCastCopperRod()
        {
            ViewBag.ContinuousCastCopperRod = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Continuous Cast Copper Rod").FirstOrDefault().strPageDetails;
            return View();
        }
        public ActionResult CopperCathode()
        {
            ViewBag.CopperCathode = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Copper Cathode").FirstOrDefault().strPageDetails;
            return View();
        }
        public ActionResult CopperConcentrate()
        {
            ViewBag.CopperConcentrate = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Copper Concentrate").FirstOrDefault().strPageDetails;
            return View();
        }
        public ActionResult CopperSulpahte()
        {
            ViewBag.CopperSulpahte = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Copper Sulphate").FirstOrDefault().strPageDetails;
            return View();
        }

        public ActionResult SulphuricAcid()
        {
            ViewBag.SulphuricAcid = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Sulphuric Acid").FirstOrDefault().strPageDetails;
            return View();
        }
        public ActionResult Reverts()
        {
            ViewBag.Reverts = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Reverts").FirstOrDefault().strPageDetails;
            return View();
        }
        public ActionResult AnodeSlime()
        {
            ViewBag.AnodeSlime = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Anode Slime").FirstOrDefault().strPageDetails;
            return View();
        }
        public ActionResult NickelHydroxide()
        {
            ViewBag.NickelHydroxide = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Typical Nickel Cathode").FirstOrDefault().strPageDetails;
            return View();
        }



        public ActionResult BillServices()
        {
            return View();
        }
        public ActionResult Billpurchase()
        {
            return View();
        }
        public ActionResult ContractsPurchase()
        {
            return View();
        }


        public ActionResult InvestorRelations()
        {
            return View();
        }


        public ActionResult AnnualReturn()
        {
            return View();
        }


        // Start

        public ActionResult ChairmanAddress()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Chairman's Address").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }
        public ActionResult QuarterlyResult()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Quarterly Result").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);


        }

        //public ActionResult AnnualReport()
        //{
        //    var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Annual Report").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
        //    return View(InvestorRelationPageList);
        //}


        public ActionResult BusinessResponsibility()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Business Responsibility Report").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult CodeandPolicy()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Code and Policy").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult Compliance()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Compliance Report on Corporate Governance").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);

        }
        public ActionResult BoardCommittees()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Committees of the Board").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult TAndCIndependentDirectors()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "T&C of Appointment of Independent Directors").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult FamiliarizationProgramme()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Familiarization Programme imparted to Independent Directors").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult ResignationDirectors()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Resignation of Directors").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }


        public ActionResult InformationStockExchanges()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Event/ Information to Stock Exchanges").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult CreditRating()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Credit Rating of HCL").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult CriterianonexecutiveDirectors()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Criteria of making payment to non-executive Directors").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult Shareholding()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Shareholding Pattern").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }


        public ActionResult UnpaidandUnclaimedDividend()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Unpaid & Unclaimed Dividend").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult Tradingwindowclosurenotices()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Trading window closure notices").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }
        public ActionResult BookClosureAGM()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Book Closure & AGM").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult PostalBallot()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Postal Ballot").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult Regulation47Advertisements()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Advertisements under Regulation 47").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);


        }

        public ActionResult IEPF()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "IEPF").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult AudioOrVideoRecordings()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Audio or VideoRecordings").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }
        public ActionResult SecretarialComplianceReport()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Secretarial Compliance Report").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }
        public ActionResult StatementOfDeviation()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Statement of Deviation").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }
        public ActionResult CorporatePresentation()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Corporate/ Investor Presentation").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }
        public ActionResult ScheduleOfAnalyst()
        {
            //var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Corporate/ Investor Presentation").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View();
        }
        public ActionResult Complaints()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Complaints").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }
        public ActionResult Download()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Download").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }



        // end



        public ActionResult AnnualReportInvestorRelation()
        {
            return View();
        }
        public ActionResult companysec()
        {
            return View();
        }


        public ActionResult Investors()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Notice-Investors").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);

        }

        //debanko

        public ActionResult Archrive()
        {
            var ArchrivePageLst = db.tbl_mst_InvestorRelationsPage.Where(x => x.isActive == false).OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(ArchrivePageLst);
        }


        public ActionResult Legal()
        {
            return View();
        }

        public ActionResult Other()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Notice-Other").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);

        }

        public ActionResult MOUwithGOI()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "NewsRoom-MOUwithGOI").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }
        public ActionResult PressRelease()
        {
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            var tbl_mst_News = objContext8.tbl_mst_News.Where(x => x.strNewsType == "Press Release" && EntityFunctions.TruncateTime(x.dtExpiryDate) >= EntityFunctions.TruncateTime(current)).ToList();
            return View(tbl_mst_News);
        }


        public ActionResult NewsBanning()
        {
            return View();
        }
        public ActionResult NewsGROMIS()
        {
            return View();
        }
        public ActionResult NewsOffer(int id)
        {
            var tbl_mst_News = objContext8.tbl_mst_News.Where(x => x.Pk_intNewsID == id).FirstOrDefault();
            TempData["strSubjectdfsEnglish"] = tbl_mst_News.strSubjectdfsEnglish;
            TempData["strSubjectdfshindi"] = tbl_mst_News.strSubjectdfshindi;
            TempData["strFileEnglish"] = tbl_mst_News.strFileEnglish.Replace("~", "../..");
            TempData["strFileHindi"] = tbl_mst_News.strFileHindi.Replace("~", "../..");
            TempData["dtEntryDate"] = tbl_mst_News.dtExpiryDate.Value.ToString("dd/MMM/yyyy");
            return View();
        }



        public ActionResult CopperCommune()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "NewsRoom-CopperCommune").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }
        public ActionResult HouseJournals()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "NewsRoom-HouseJournals").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }
        public ActionResult AdGallery()
        {
            return View();
        }
        public ActionResult PhotoGallery()
        {
            return View();
        }
        public ActionResult PhotoGallery1()
        {
            return View();
        }
        public ActionResult Announcement()
        {
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            var tbl_mst_News = objContext8.tbl_mst_News.Where(x => x.strNewsType == "Announcement" && EntityFunctions.TruncateTime(x.dtExpiryDate) >= EntityFunctions.TruncateTime(current)).ToList();
            return View(tbl_mst_News);
        }

        public ActionResult AnnouncementGromis()
        {
            return View();
        }

        public ActionResult AnnouncementOffer(int id)
        {
            var tbl_mst_News = objContext8.tbl_mst_News.Where(x => x.Pk_intNewsID == id).FirstOrDefault();
            TempData["strSubjectdfsEnglish"] = tbl_mst_News.strSubjectdfsEnglish;
            TempData["strSubjectdfshindi"] = tbl_mst_News.strSubjectdfshindi;
            TempData["strFileEnglish"] = tbl_mst_News.strFileEnglish.Replace("~", "../..");
            TempData["strFileHindi"] = tbl_mst_News.strFileHindi.Replace("~", "../..");
            TempData["dtEntryDate"] = tbl_mst_News.dtExpiryDate.Value.ToString("dd/MMM/yyyy");

            return View();
        }

        public ActionResult RelatedLink()
        {
            return View();
        }
        public ActionResult RIAct()
        {
            return View();
        }
        public ActionResult StateMinistry()
        {
            return View();
        }
        public ActionResult CSR()
        {
            return View();
        }

        public ActionResult DecisionMaking()
        {
            return View();
        }

        public ActionResult HCLForum()
        {
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            var tbl_mst_Forum = objContext8.tbl_mst_News.Where(x => x.strNewsType == "News" && EntityFunctions.TruncateTime(x.dtExpiryDate) >= EntityFunctions.TruncateTime(current)).ToList();
            return View(tbl_mst_Forum);
            //return View();
        }

        public ActionResult Environment()
        {
            return View();
        }
        public ActionResult SBAbhiyan()
        {
            return View();
        }

        public ActionResult CategoryDocuments()
        {
            return View();
        }
        public ActionResult RepresentationProcess()
        {
            return View();
        }
        public ActionResult StatementsfromBoard()
        {
            return View();
        }
        public ActionResult GCPPlant()
        {
            return View();
        }

        public ActionResult ICCPlant()
        {
            return View();
        }

        public ActionResult RulesRegulations()
        {
            return View();
        }


        public ActionResult KCCPlant()
        {
            return View();
        }


        public ActionResult MCCPlant()
        {
            return View();
        }


        public ActionResult TCCPlant()
        {
            return View();
        }

        public ActionResult NormsforDischarge()
        {
            return View();
        }


        public ActionResult inhouse()
        {
            return View();
        }

        public ActionResult BudgetAllocations()
        {
            return View();
        }
        public ActionResult Concessionpermits()
        {
            return View();
        }
        public ActionResult EmployeeRemunerations()
        {
            return View();
        }
        public ActionResult EmployeeStrength()
        {
            return View();
        }
        public ActionResult Informationinelectronic()
        {
            return View();
        }

        public ActionResult others()
        {
            return View();
        }
        public ActionResult ProcedureforInformationretrieval()
        {
            return View();
        }
        public ActionResult SubsidyPrograms()
        {
            return View();
        }
        public ActionResult PIO()
        {
            return View();
        }
        public ActionResult BookingOptions()
        {
            return View();
        }
        public ActionResult Premium()
        {
            return View();
        }
        public ActionResult Discounts()
        {
            return View();
        }
        public ActionResult RealTimeLME()
        {
            return View();
        }
        public ActionResult ContactUs()
        {

            ViewBag.ContactUs = dbContext001.tbl_mstPageDetail.Where(x => x.strPageTitle == "Contact Us").FirstOrDefault().strPageDetails;
            return View();
        }
        public ActionResult Career()
        {
            var Notice = objVwNotice.vw_EmploymentNotoc.Where(x => x.dtviewdate <= current && x.isactive == true).OrderByDescending(x => x.Pk_employmentid).ToList();
            return View(Notice);
        }

        public ActionResult HRRules()
        {
            return View();
        }
        public ActionResult ApplicationForm()
        {
            return View();
        }
        public ActionResult Career_New()
        {
            Session["Page"] = "English";
            tbl_mst_NoticeCorrigendumcontext objtbl_mst_NoticeCorrigendumcontext = new tbl_mst_NoticeCorrigendumcontext();
            //var Notice = objAdvertisementNotice.Vw_AdvertisementNotice.Where(x => x.dtviewdate <= current && x.isactive == true).OrderByDescending(x => x.Pk_employmentid).ToList();


            var Notice = objNotice.tbl_employmentnotice.Where(x => x.dtviewdate <= current && x.isactive == true && x.dtexpirydate > current).OrderByDescending(x => x.Pk_employmentid).ToList();

            Notice.ToList().ForEach(d =>
            {
                d.Corrigendum = objtbl_mst_NoticeCorrigendumcontext.tbl_mst_NoticeCorrigendum.Where(x => x.fk_empnoticeid == d.Pk_employmentid).ToList();
                //d.Corrigendum = objtbl_mst_NoticeCorrigendumcontext.tbl_mst_NoticeCorrigendum.Where(x => x.fk_empnoticeid == d.Pk_employmentid).Select(c => c.str_upload).ToList();//
                //d.CorrigendumType = objtbl_mst_NoticeCorrigendumcontext.tbl_mst_NoticeCorrigendum.Where(x => x.fk_empnoticeid == d.Pk_employmentid).Select(c => c.strType).ToList();
            });
            var NoticeDetails = Notice.OrderByDescending(x => x.Pk_employmentid).ToList();

            return View(NoticeDetails);
            //return View();
        }

        public ActionResult TopNews()
        {
            var News = objContext8.tbl_mst_News.Where(x => x.dtExpiryDate > current && x.strNewsType == "Career News").OrderByDescending(x => x.Pk_intNewsID).ToList();
            return View(News);
        }

        public ActionResult screenreader()
        {
            return View();
        }


        public ActionResult TenderList()
        {


            var Tenders = _tenderContext.vw_TendetList.Where(x => x.dtActiveDate < current && x.dtClosingDate >= current).OrderByDescending(x => x.dtEnquiryDate).ToList();
            return View(Tenders);
        }

        //Debanko

        public ActionResult ArcrivedTenderList()
        {
            var ArcrivedTenders = _tenderContext.vw_TendetList.Where(x => x.dtClosingDate < current).OrderByDescending(x => x.dtEnquiryDate).ToList();
            return View(ArcrivedTenders);
        }

        //Shoumya

        public ActionResult EmployeeTender()
        {


            var Tenders = _tenderContext.vw_TendetList.OrderByDescending(x => x.dtEnquiryDate).ToList();
            return View(Tenders);
        }

        public ActionResult TenderListEmployee(int id)
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

                //vw_TendetList objvw_TendetList = new vw_TendetList
                //{
                //    Addendum = new List<string>(),
                //    Corrigendum = new List<string>(),
                //};

                //foreach (var add in checkAdde)
                //{
                //    objvw_TendetList.Addendum.Add(add.strFileName);
                //}

                //foreach (var add in checkCorr)
                //{
                //    objvw_TendetList.Corrigendum.Add(add.strFileName);
                //}
                var TenderDetails = details.ToList();

                //string userType = "";
                //if (TenderDetails.FirstOrDefault().strTenderType == "STE" || TenderDetails.FirstOrDefault().strTenderType == "LTE")
                //{
                //    if (Session["UserType"] != null)
                //    {
                //        userType = Session["UserType"].ToString();
                //    }

                //    if (userType == "VENDOR" || userType == "CONTRACTOR")
                //    {
                //        string vendorCode = Session["VendorCode"].ToString();
                //        string Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID.ToString();
                //        TenderDetails = TenderDetails.Where(x => x.strVendorsId.Contains(Id)).ToList();
                //        if (TenderDetails.Count == 0)
                //        {
                //            TempData["totValue"] = "0";
                //        }
                //    }
                //}
                return View(TenderDetails);
            }
            catch { }

            return View();

        }

        #region LME Tender

        private string SafeToLower(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            return value.ToLower();
        }

        public ActionResult LMETenderList()
        {
            var list = objSpotbookingTenderdetails.vw_SpotbookingTender.Where(x => x.dt_closingtime >= current).OrderByDescending(x => x.Pk_int_tenderid).ToList();
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

                var v = dc.vw_SpotbookingTender.Where(x => x.dt_closingtime >= current).OrderByDescending(x => x.Pk_int_tenderid).ToList();

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

        #endregion

        public ActionResult Feedback()
        {
            ViewBag.Fk_titleid = new SelectList(objtitle.tbl_feedbacktitle.ToList(), "Pk_feedbacktitleid", "strtitle_name");
            //captcha
            recaptcha();
            //captcha

            return View(new tbl_feedback());


        }
        [HttpPost]
        public ActionResult Feedback(tbl_feedback tbl_feedback, FormCollection frm)
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

                ViewBag.Fk_titleid = new SelectList(objtitle.tbl_feedbacktitle.ToList(), "Pk_feedbacktitleid", "strtitle_name");

                if (ModelState.IsValid)
                {
                    tbl_feedback.dtentrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    tbl_feedback.dtupdate_date = DateTime.UtcNow + TimeSpan.Parse("05:30:00");

                    tbl_feedback.isactive = true;

                    objfeedback.tbl_feedback.Add(tbl_feedback);
                    objfeedback.SaveChanges();

                    ViewBag.Message = string.Format("Your feedback saved successfully");
                    Utility.SendEmail(tbl_feedback.str_email, "Feedback mail", "Thank you for your feedback.We will contact you shortly.");
                    Utility.SendEmail("sampa_l@hindustancopper.com", "Feedback mail", tbl_feedback.str_comment);
                    ModelState.Clear();
                    return View();
                }
                else
                {
                    //captcha
                    recaptcha();
                    //captcha
                    ViewBag.Message = string.Format("Something Went Wrong");
                    return View();
                }

            }
            return View();

        }

        public ActionResult TenderListforDetails(int id)
        {
            try
            {
                TempData["Verify"] = "";
                TempData["UserID"] = Session["UserID"];


                var details = (from tender in _tenderContext.vw_TendetList
                               where
                                    tender.pk_intTenderId == id
                               select tender);

                details.ToList().ForEach(d =>
                {
                    d.Addendum = _tenderContext.tbl_mstAddendum.Where(x => x.fk_intTendorId == d.pk_intTenderId).Select(a => a.strFileName).ToList();
                    d.Corrigendum = _tenderContext.tbl_mstCorrigendum.Where(x => x.fk_intTendorId == d.pk_intTenderId).Select(c => c.strFileName).ToList();
                });


                var TenderDetails = details.ToList();

                string userType = "";
                if (TenderDetails.FirstOrDefault().strTenderType == "STE" || TenderDetails.FirstOrDefault().strTenderType == "LTE")
                {
                    if (Session["UserType"] != null)
                    {
                        userType = Session["UserType"].ToString();
                    }

                    if (userType == "VENDOR" || userType == "CONTRACTOR")
                    {
                        string vendorCode = Session["VendorCode"].ToString();
                        //string Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID.ToString();
                        string Id = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID.ToString();
                        TenderDetails = TenderDetails.Where(x => x.strVendorsId.Contains(Id)).ToList();
                        if (TenderDetails.Count == 0)
                        {
                            TempData["totValue"] = "0";
                        }
                    }
                }

                else
                {

                    if (Session["UserType"] != null)
                    {
                        userType = Session["UserType"].ToString();
                    }

                    if (userType == "VENDOR" || userType == "CONTRACTOR")
                    {
                        string vendorCode = Session["VendorCode"].ToString();
                        //string Verify = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().strVerify.ToString();
                        string Verify = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().strVerify.ToString();
                        if (Verify == "NO")
                        {
                            TempData["Verify"] = "NO";
                            TempData["totValue"] = "0";
                            TenderDetails = TenderDetails.Where(x => x.pk_intTenderId == 0).ToList();
                        }
                    }
                }
                return View(TenderDetails);
            }
            catch { }

            return View();

        }

        public ActionResult ExEmployeeCorner()
        {
            var News = objContext8.tbl_mst_News.Where(x => x.dtExpiryDate > current && x.strNewsType == "Ex-Employee Corner").OrderByDescending(x => x.Pk_intNewsID).ToList();
            return View(News);
        }

        public ActionResult SiteMap()
        {
            return View();
        }

        public ActionResult RTIFeesubmission()
        {
            return View();
        }

        public ActionResult QIP()
        {
            return View();
        }
        public ActionResult PreliminaryPlacement()
        {
            return View();
        }
        [NoDirectAccess]
        public ActionResult QIP2nd()
        {
            return View();
        }
        [NoDirectAccess]
        public ActionResult QIP3rd()
        {
            return View();
        }
        [NoDirectAccess]
        public ActionResult QIPShowDoc()
        {
            return View();
        }


        public ActionResult PlacementDocument()
        {
            return View();
        }
        [NoDirectAccess]
        public ActionResult PlacementDocument2nd()
        {
            return View();
        }
        [NoDirectAccess]
        public ActionResult PlacementDocument3rd()
        {
            return View();
        }
        [NoDirectAccess]
        public ActionResult PlacementDocumentShowDoc()
        {
            return View();
        }

        public ActionResult pankyc()
        {
            return View();
        }
        public ActionResult DetailOfBusiness()
        {
            return View();
        }

        public ActionResult Reg74OfSEBI()
        {
            return View();
        }

        public ActionResult CapacityBuilding()
        {
            return View();
        }


        public ActionResult PDF()
        {
            System.IO.FileStream fs = new FileStream(Server.MapPath("PDFs") + "\\" + "First PDF document.pdf", FileMode.Create);
            Document document = new Document(PageSize.A4, 25, 25, 30, 30);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            document.Add(new Paragraph("Hello World!"));
            PdfPTable table = new PdfPTable(1);
            table.WidthPercentage = 100;
            //var colWidthPercentages = new[] { 33f};
            var colWidthPercentages = new[] { 33f };
            table.SetWidths(colWidthPercentages);

            PdfPCell cell = new PdfPCell();
            cell.BorderWidth = 1;



            PdfPTable innerTable = new PdfPTable(1);
            innerTable.WidthPercentage = 100;

            PdfPCell innerCell = new PdfPCell();
            innerCell.BorderWidth = 1;

            PdfPTable wTable = new PdfPTable(3);
            colWidthPercentages = new[] { 25f, 5f, 70f };
            wTable.WidthPercentage = 100;
            wTable.SetWidths(colWidthPercentages);

            innerCell.AddElement(wTable);
            innerTable.AddCell(innerCell);

            //wTable.SetWidths(widths);
            //wTable.SpacingBefore = 0.5f;
            //wTable.SpacingAfter = 0.5f;

            //setAddTextToTable(wTable, true, 10f, "SL No.", true, MINIMUMHEIGHT_2);
            //setAddTextToTable(wTable, true, 10f, "Name", true, MINIMUMHEIGHT_2);
            //setAddTextToTable(wTable, true, 10f, "Course", true, MINIMUMHEIGHT_2);
            //setAddTextToTable(wTable, true, 10f, "Elective Subject", true, MINIMUMHEIGHT_2);

            document.Close();
            writer.Close();
            fs.Close();
            return View();
        }
    }
    //public ActionResult TenderListforDetails(int id)
    //{
    //    try
    //    {
    //        TempData["UserID"] = Session["UserID"];
    //        var details = (from tender in _tenderContext.vw_TendetList
    //                       where
    //                            tender.pk_intTenderId == id
    //                       select tender);

    //        details.ToList().ForEach(d =>
    //        {
    //            d.Addendum = _tenderContext.tbl_mstAddendum.Where(x => x.fk_intTendorId == d.pk_intTenderId).Select(a => a.strFileName).ToList();
    //            d.Corrigendum = _tenderContext.tbl_mstCorrigendum.Where(x => x.fk_intTendorId == d.pk_intTenderId).Select(c => c.strFileName).ToList();
    //        });


    //        var TenderDetails = details.ToList();

    //        string userType = "";
    //        string vendorCode = "";
    //        if (Session["VendorCode"] != null)
    //        {
    //            vendorCode = Session["VendorCode"].ToString();
    //        }
    //        var vendordetails = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault();



    //        if (TenderDetails.FirstOrDefault().strTenderType == "STE" || TenderDetails.FirstOrDefault().strTenderType == "LTE")
    //        {
    //            if (Session["UserType"] != null)
    //            {
    //                userType = Session["UserType"].ToString();
    //            }

    //            if (userType == "VENDOR" || userType == "CONTRACTOR")
    //            {

    //                string Id = vendordetails.Pk_intNewVendorRegistrationID.ToString();
    //                TenderDetails = TenderDetails.Where(x => x.strVendorsId.Contains(Id)).ToList();
    //                if (TenderDetails.Count == 0)
    //                {
    //                    TempData["totValue"] = "0";
    //                }
    //            }
    //        }

    //        if (TenderDetails.FirstOrDefault().strTenderType == "Open")
    //        {
    //            if (vendordetails.strVerify == "NO")
    //            {
    //                TempData["totValue"] = "0";
    //                TenderDetails = details.Where(x => x.pk_intTenderId == 0).ToList();
    //            }
    //        }


    //        return View(TenderDetails);
    //    }
    //    catch { }

    //    return View();

    //}




}




