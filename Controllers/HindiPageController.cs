using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Models;

using System.Data;
using Hindustancopperlimited.GlobalClass;
using System.Data.Objects;

namespace Hindustancopperlimited.Controllers
{
    public class HindiPageController : Controller
    {
        tbl_mstPageDetailContext dbContext001 = new tbl_mstPageDetailContext();
        tbl_mst_IndexPageContentContext dbContext002 = new tbl_mst_IndexPageContentContext();

        tbl_mst_InvestorRelationsPageContext db = new tbl_mst_InvestorRelationsPageContext();
        tbl_mstDepartmentContext _objContext = new tbl_mstDepartmentContext();
        VendorRegistrationContext objContext = new VendorRegistrationContext();
        tbl_mstDepartmentContext objContext8 = new tbl_mstDepartmentContext();
        tbl_feedbacktitlecontext objtitle = new tbl_feedbacktitlecontext();
        tbl_feedbackcontext objfeedback = new tbl_feedbackcontext();
        //TenderContext _tenderContext = new TenderContext();
        //DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        //
        // GET: /HindiPage/
        TenderContext _tenderContext = new TenderContext();
        DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        tbl_employmentnoticecontext objNotice = new tbl_employmentnoticecontext();
        vw_EmploymentNotoccontext objVwNotice = new vw_EmploymentNotoccontext();
        tbl_AnnualReportsContext objtbl_AnnualReports = new tbl_AnnualReportsContext();
        tbl_PriceCircularContext objtbl_PriceCircular = new tbl_PriceCircularContext();
        tbl_ManagementKeyExecutivesContext objManagmntExectve = new tbl_ManagementKeyExecutivesContext();
        vw_SpotbookingTenderContext objSpotbookingTenderdetails = new vw_SpotbookingTenderContext();
        //Dustu//

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
        public ActionResult Sustainability()
        {
            return View();
        }
        public ActionResult ThirdPartyRTIauditReport()
        {
            return View();
        }
        //Note:-Added By Beas
        [OutputCache(Duration = 300, VaryByParam = "none")]
        public ActionResult Index()
        {
            #region Old CodeBlock-07102026
            // string Generatehash512(string text)
            //{

            //    byte[] message = Encoding.UTF8.GetBytes(text);

            //    UnicodeEncoding UE = new UnicodeEncoding();
            //    byte[] hashValue;
            //    SHA512Managed hashString = new SHA512Managed();
            //    string hex = "";
            //    hashValue = hashString.ComputeHash(message);
            //    foreach (byte x in hashValue)
            //    {
            //        hex += String.Format("{0:x2}", x);
            //    }
            //    return hex;

            //}

            // string Generatetxnid()
            //{

            //    Random rnd = new Random();
            //    string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
            //    string txnid1 = strHash.ToString().Substring(0, 20);

            //    return txnid1;
            //}


            //string firstName ="Peeyush";
            //string amount = "10.00";
            //string productInfo = "Application Fee";
            //string email = "test@gmail.com";
            //string phone ="7499984133";
            //string surl = ConfigurationManager.AppSettings["surl"];
            //string furl = ConfigurationManager.AppSettings["furl"];

            //string udf1 = "56789";
            //string udf2 = "67890";
            //string udf3 = "7890";
            //string udf4 = "7890-";
            //string udf5 = "General";

            //RemotePost myremotepost = new RemotePost();
            //string key = ConfigurationManager.AppSettings["MERCHANT_KEY"];
            //string salt = ConfigurationManager.AppSettings["SALT"];

            //myremotepost.Url = ConfigurationManager.AppSettings["PAYU_BASE_URL"];

            //myremotepost.Add("key", key);
            //string txnid = Generatetxnid();
            //myremotepost.Add("txnid", txnid);
            //myremotepost.Add("amount", amount);
            //myremotepost.Add("productinfo", productInfo);
            //myremotepost.Add("firstname", firstName);
            //myremotepost.Add("phone", phone);
            //myremotepost.Add("email", email);

            //myremotepost.Add("udf1", udf1);
            //myremotepost.Add("udf2", udf2);
            //myremotepost.Add("udf3", udf3);
            //myremotepost.Add("udf4", udf4);
            //myremotepost.Add("udf5", udf5);

            //myremotepost.Add("surl", surl);//Change the success url here depending upon the port number of your local system.
            //myremotepost.Add("furl", furl);//Change the failure url here depending upon the port number of your local system.

            ////myremotepost.Add("service_provider", "payu_paisa");

            //string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|" + udf1 + "|" + udf2 + "|" + udf3 + "|" + udf4 + "|" + udf5 + "||||||" + salt;
            //string hash = Generatehash512(hashString);
            //myremotepost.Add("hash", hash);
            //myremotepost.Post();




            //var hitCount = _tenderContext.tbl_hitCount.Where(x => x.strPageName == "Hindi").FirstOrDefault();           
            //hitCount.intQuantity = hitCount.intQuantity + 1;
            //_tenderContext.Entry(hitCount).State = EntityState.Modified;
            //_tenderContext.SaveChanges();
            //ViewBag.hitCount = hitCount.intQuantity;



            //ViewBag.MainBrief = dbContext002.tbl_mst_IndexPageContent.FirstOrDefault().strHindiMainBrief;


            //ViewBag.visionMission = dbContext002.tbl_mst_IndexPageContent.FirstOrDefault().strHindiVisionMission;

            //ViewBag.plant_Facility = dbContext002.tbl_mst_IndexPageContent.FirstOrDefault().strHindiPlantFacility;


            //ViewBag.Management = dbContext002.tbl_mst_IndexPageContent.FirstOrDefault().strHindiManagement;
            #endregion Old CodeBlock-07102026

            Session["Page"] = "Hindi";
            var Tenders = _tenderContext.vw_tenderEOI.OrderByDescending(x => x.pk_intTenderId).ToList();
            ViewBag.Events = _objContext.tbl_mst_Events.Where(x => x.dtExpiryDate > current).OrderByDescending(x => x.Pk_intEventID).ToList();
            ViewBag.Awards = _objContext.tbl_mst_AchievementAndAward.OrderByDescending(x => x.Pk_intAwardID).ToList();
            ViewBag.CovidNews = _objContext.tbl_mst_News.Where(x => x.strNewsType == "Covid News").Take(5).ToList();
            return View(Tenders);
        }



        public ActionResult CompanyProfile()
        {
            //ViewBag.CompanyProfile = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "कम्पनी प्रोफाइल").FirstOrDefault().strHindiPageDetails;
            return View();
        }

        public ActionResult MinisterSecretary()
        {
            //ViewBag.MinisterSecretary = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "मंत्री और सचिव").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        
        public ActionResult StatementOfDeviation()
        {
            //ViewBag.MinisterSecretary = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "मंत्री और सचिव").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        public ActionResult TheBoard()
        {
            ViewBag.TheBoard = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "बोर्ड").FirstOrDefault().strHindiPageDetails;
            return View();
        }


        public ActionResult ManagementPhilosophy()
        {
            //ViewBag.ManagementPhilosophy = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "प्रबंधन का सिद्धांत").FirstOrDefault().strHindiPageDetails;
            return View();
        }


        //Bhashkar 27/10/2017

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
                    Utility.SendEmail("hcl_ho@hindustancopper.com", "Feedback mail", tbl_feedback.str_comment);
                    ModelState.Clear();
                    return View();
                }
            }

            return View();

        }


        public ActionResult PlantsandOffices()
        {
            //ViewBag.PlantsandOffices = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "संयंत्र एवं कार्यालय").FirstOrDefault().strHindiPageDetails;
            return View();
        }


        public ActionResult SalesOffices()
        {
            // ViewBag.SalesOffices = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "बिक्री कार्यालय").FirstOrDefault().strHindiPageDetails;
            return View();
        }

        public ActionResult Events()
        {
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            var Event = objContext8.tbl_mst_Events.Where(x => x.dtExpiryDate > current).ToList();
            //var Event = objContext8.tbl_mst_Events.ToList();
            return View(Event);
        }

        public ActionResult Award()
        {
            var Award = objContext8.tbl_mst_AchievementAndAward.ToList();
            return View(Award);
        }

        public ActionResult Godowns()
        {
            ViewBag.Godowns = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "गोदाम").FirstOrDefault().strHindiPageDetails;
            return View();
        }


        public ActionResult VisionandMission()
        {
            ViewBag.VisionandMission = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "विज़न एवं मिशन").FirstOrDefault().strHindiPageDetails;
            return View();
        }



        public ActionResult EmployeeSection()
        {
            return View();
        }

        public ActionResult Achievements()
        {
            //ViewBag.Achievements = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "उपलब्धियाँ").FirstOrDefault().strHindiPageDetails;
            return View();
        }




        public ActionResult OfficeandGodown()
        {
            //ViewBag.OfficeandGodown = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "कार्यालय और गोदाम").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        public ActionResult PriceCircular()
        {
            //var tbl_PriceCircular = objtbl_PriceCircular.tbl_PriceCircular.ToList();
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
            ViewBag.TenYearsataGlance = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "10 वर्ष एक नज़र में (रु. करोड़ में)").FirstOrDefault().strHindiPageDetails;
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


        public ActionResult AnnouncementGromis()
        {
            return View();
        }
        public ActionResult Announcement()
        {
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            var tbl_mst_News = objContext8.tbl_mst_News.Where(x => x.strNewsType == "Announcement" && EntityFunctions.TruncateTime(x.dtExpiryDate) >= EntityFunctions.TruncateTime(current)).ToList();
            return View(tbl_mst_News);
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










        public ActionResult MCCPlant()
        {
            return View();
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


        public ActionResult NormsforDischarge()
        {
            return View();
        }




        public ActionResult others()
        {
            return View();
        }



        public ActionResult PIO()
        {
            return View();
        }



        public ActionResult ProcedureforInformationretrieval()
        {
            return View();
        }







        public ActionResult TenderListforDetails(int id)
        {
            try
            {
                TempData["UserID"] = Session["UserID"];
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
                        string Id = objContext.VendorRegistrations.Where(x => x.strVendorRegistrationID == vendorCode).FirstOrDefault().Pk_intNewVendorRegistrationID.ToString();
                        TenderDetails = TenderDetails.Where(x => x.strVendorsId.Contains(Id)).ToList();
                        if (TenderDetails.Count == 0)
                        {
                            TempData["totValue"] = "0";
                        }
                    }
                }
                return View(TenderDetails);
            }
            catch { }

            return View();

        }



        // debtana start


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

        public ActionResult CorporatePresentation()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Corporate/ Investor Presentation").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
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


        //debtana  end


        public ActionResult AnnualReportInvestorRelation()
        {
            return View();
        }




        //Dustu//

        //sanjib//
        public ActionResult ManagementKeyExecutives()
        {
            var ManagementKeyExecutiveslist = objManagmntExectve.tbl_ManagementKeyExecutives.OrderByDescending(x => x.pk_int_ManagementKeyExecutives).ToList();
            return View(ManagementKeyExecutiveslist);
        }
        //sanjib//

        //Avi
        public ActionResult MOUwithGOI()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "NewsRoom-MOUwithGOI").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
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


        //public ActionResult PhotoGallery()
        //{
        //    return View();
        //}

        public ActionResult PhotoGallery()
        {
            using (var db = new UploadPhotoContext())
            {
                var photos = db.UploadPhotoGallery
                               .OrderByDescending(x => x.id)
                               .ToList();

                return View(photos);
            }
        }

        public ActionResult PhotoGallery1()
        {
            return View();
        }

        public ActionResult PhotoGallery2()
        {
            return View();
        }

        public ActionResult Investors()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Notice-Investors").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }
        // debanko
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
        public ActionResult InvestorRelations()
        {
            return View();
        }
        public ActionResult TenderList()
        {


            var Tenders = _tenderContext.vw_TendetList.Where(x => x.dtActiveDate < current && x.dtClosingDate >= current).OrderByDescending(x => x.dtEnquiryDate).ToList();
            return View(Tenders);
        }

        //Debanko
        public ActionResult ArcrivedTenderListHindi()
        {
            var ArcrivedTenders = _tenderContext.vw_TendetList.Where(x => x.dtClosingDate < current).OrderByDescending(x => x.dtEnquiryDate).ToList();
            return View(ArcrivedTenders);
        }



        #region LME Tender

        public ActionResult LMETenderList()
        {
            var list = objSpotbookingTenderdetails.vw_SpotbookingTender.Where(x => x.dt_closingtime >= current).OrderByDescending(x => x.Pk_int_tenderid).ToList();
            return View(list);
        }

        #endregion

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
        public ActionResult ContactUs()
        {
            ViewBag.ContactUs = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "हमसे संपर्क करें").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        public ActionResult Career()
        {
            var Notice = objVwNotice.vw_EmploymentNotoc.Where(x => x.dtviewdate <= current && x.isactive == true).OrderByDescending(x => x.Pk_employmentid).ToList();
            return View(Notice);
        }
        public ActionResult Career_New()
        {
            Session["Page"] = "Hindi";
            tbl_mst_NoticeCorrigendumcontext objtbl_mst_NoticeCorrigendumcontext = new tbl_mst_NoticeCorrigendumcontext();
            //var Notice = objAdvertisementNotice.Vw_AdvertisementNotice.Where(x => x.dtviewdate <= current && x.isactive == true).OrderByDescending(x => x.Pk_employmentid).ToList();
            var Notice = objNotice.tbl_employmentnotice.Where(x => x.dtviewdate <= current && x.isactive == true && x.dtexpirydate > current).OrderByDescending(x => x.Pk_employmentid).ToList();

            Notice.ToList().ForEach(d =>
            {

                d.Corrigendum = objtbl_mst_NoticeCorrigendumcontext.tbl_mst_NoticeCorrigendum.Where(x => x.fk_empnoticeid == d.Pk_employmentid).ToList(); ;
            });
            var NoticeDetails = Notice.OrderByDescending(x => x.Pk_employmentid).ToList();

            return View(NoticeDetails);
        }
        public ActionResult HRRules()
        {
            return View();
        }
        public ActionResult ApplicationForm()
        {
            return View();
        }


        public ActionResult ContinuousCastCopperRod()
        {

            ViewBag.ContinuousCastCopperRod = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "कन्टिन्युअस कास्ट कॉपर वायर रॉड").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        public ActionResult CopperCathode()
        {

            ViewBag.CopperCathode = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "कॉपर कैथोड").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        public ActionResult CopperConcentrate()
        {

            ViewBag.CopperConcentrate = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "ताम्र सान्द्र").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        public ActionResult CopperSulpahte()
        {

            ViewBag.CopperSulpahte = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "कॉपर सल्फेट").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        public ActionResult SulphuricAcid()
        {

            ViewBag.SulphuricAcid = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "सल्फ्यूरिक एसिड").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        public ActionResult Reverts()
        {

            ViewBag.Reverts = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "रिवर्ट्स").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        public ActionResult AnodeSlime()
        {

            ViewBag.AnodeSlime = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "ऐनोड स्लाइम").FirstOrDefault().strHindiPageDetails;
            return View();
        }
        public ActionResult NickelHydroxide()
        {

            ViewBag.NickelHydroxide = dbContext001.tbl_mstPageDetail.Where(x => x.strHindiPageTitle == "निकल हाइड्रोक्साइड").FirstOrDefault().strHindiPageDetails;
            return View();
        }




        public ActionResult RelatedLink()
        {
            return View();
        }
        public ActionResult StateMinistry()
        {
            return View();
        }


        public ActionResult BudgetAllocations()
        {
            return View();
        }

        public ActionResult CategoryDocuments()
        {
            return View();
        }


        public ActionResult companysec()
        {
            return View();
        }


        public ActionResult Concessionpermits()
        {
            return View();
        }


        public ActionResult DecisionMaking()
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

        public ActionResult GCPPlant()
        {
            return View();
        }
        public ActionResult ICCPlant()
        {
            return View();
        }
        public ActionResult Informationinelectronic()
        {
            return View();
        }

        public ActionResult KCCPlant()
        {
            return View();
        }


        //Avi//






        //Mohua//

        public ActionResult RIAct()
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

        public ActionResult inhouse()
        {
            return View();
        }

        public ActionResult CSR()
        {
            return View();
        }

        public ActionResult SBAbhiyan()
        {
            return View();
        }

        public ActionResult Environment()
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






        public ActionResult RepresentationProcess()
        {
            return View();
        }


        public ActionResult RulesRegulations()
        {
            return View();
        }



        public ActionResult StatementsfromBoard()
        {
            return View();
        }
        public ActionResult SubsidyPrograms()
        {
            return View();
        }


        public ActionResult TCCPlant()
        {
            return View();
        }
        public ActionResult PressRelease()
        {
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            var tbl_mst_News = objContext8.tbl_mst_News.Where(x => x.strNewsType == "Press Release" && EntityFunctions.TruncateTime(x.dtExpiryDate) >= EntityFunctions.TruncateTime(current)).ToList();
            return View(tbl_mst_News);
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

        //Mohua//

        //Shoumya

        public ActionResult Req74()
        {
            return View();
        }


        public ActionResult BusinessDetails_Hindi()
        {
            return View();
        }
        public ActionResult CapacityBuilding()
        {
            return View();
        }

        public ActionResult IndependentExternalMonitor()
        {
            return View();
        }

        public ActionResult AudioOrVideoRecordings()
        {
            var InvestorRelationPageList = db.tbl_mst_InvestorRelationsPage.Where(x => x.strPageType == "Audio or VideoRecordings").OrderByDescending(x => x.pk_int_InvestorRelationsID).ToList();
            return View(InvestorRelationPageList);
        }

        public ActionResult VideoPlayAGM58()
        {
            return View();
        }


    }

}

