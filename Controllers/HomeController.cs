using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Models;
using System.Data;
using Hindustancopperlimited.GlobalClass;
using System.Data.SqlClient;
using System.Configuration;
using Hindustancopperlimited.Models.CommonClass;
using NPOI.SS.Formula.Functions;
using DataAccessLayer;
using System.Threading.Tasks;

namespace Hindustancopperlimited.Controllers
{

    public class HomeController : Controller
    {
        //
        // GET: /Home/
     

        TenderContext _tenderContext = new TenderContext();
        tbl_mstDepartmentContext _objContext = new tbl_mstDepartmentContext();
        tbl_mstDepartmentContext objContext8 = new tbl_mstDepartmentContext();

        tbl_mst_IndexPageContentContext dbContext002 = new tbl_mst_IndexPageContentContext();
        DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        public ActionResult Test()
        
        {
            
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString);
            DataSet ds = new DataSet();
            try
            {
                //Utility.TestSendEmail("rahul.giri@infoneotech.com", "test", "test");
                Utility.SendEmail("rahul.giri@infoneotech.com", "test", "test");
                SqlCommand cmd = new SqlCommand("[dbo].[uspCOunter]", con);
                
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@fk_advertisementid", SqlDbType.Int).Value = 109;
                cmd.CommandTimeout = 5000;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            string Response = "";
            foreach (DataRow q in ds.Tables[0].Rows)
            {
                Response += "<tr>";
                //Response += "<td>" + q["DisciplineName"].ToString() + "</td>";
                Response += "<td>" + q[0].ToString() + "</td>";
                Response += "<td>" + q[1].ToString() + "</td>";
                Response += "<td>" + q[2].ToString() + "</td>";
                Response += "<td>" + q[3].ToString() + "</td>";
                Response += "</tr>";
            }
            Response = "<table class=\"table\"><thead> <tr> <th>PostName</th><th>Category</th><th>Total Candidate</th> <th>Fees</th> </tr> </thead> <tbody>" + Response + "</tbody><table>";
            //ViewData["Data"] = CommonBase.ConvertToJObjectList(ds.Tables[0]);
            ViewBag.Response = Response;
            return View();
        }
        public ActionResult Test1()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[uspCounter_New]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 5000;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            string Response = "";
            foreach (DataRow q in ds.Tables[0].Rows)
            {
                Response += "<tr>";
                //Response += "<td>" + q["DisciplineName"].ToString() + "</td>";
                Response += "<td>" + q[0].ToString() + "</td>";
                Response += "<td>" + q[1].ToString() + "</td>";
                Response += "<td>" + q[2].ToString() + "</td>";
                Response += "<td>" + q[3].ToString() + "</td>";
               // Response += "<td>" + q[4].ToString() + "</td>";
                Response += "</tr>";
            }
            Response = "<table class=\"table\"><thead> <tr> <th>PostName</th><th>Category</th><th>Total Candidate</th> <th>Fees</th> </tr> </thead> <tbody>" + Response + "</tbody><table>";
            //ViewData["Data"] = CommonBase.ConvertToJObjectList(ds.Tables[0]);
            ViewBag.Response = Response;
            return View();
        }


        [OutputCache(Duration = 300, VaryByParam = "none")] // Caches the full page output for 5 minutes
        public ActionResult Index()
        {
            #region Old CodeBlock-07102026
            //int AgeRelaxationValue = 0;
            //var fremaxage = 28;
            //var freminage = 18;
            //AgeRelaxationValue = Models.CommonClass.CommonBase.AgeRelaxation("OBC ", false, false);
            //DateTime date2 = Convert.ToDateTime("2022-09-01");
            //DateTime date1 = Convert.ToDateTime("1992-09-01");
            //var obj = Models.CommonClass.CommonBase.CalculateAge(date1, date2);
            //int Years = obj.Years;
            //int monthDay = obj.Months;
            //int Days = obj.Days;
            //if ((Years < Convert.ToInt32(freminage)) || ((Years) > Convert.ToInt32(fremaxage + AgeRelaxationValue)) || (Years > Convert.ToInt32(fremaxage + AgeRelaxationValue) && monthDay != 0 && Days != 0))
            //{
            //    ViewBag.Message = "Age Criteria not met";
            //    return View();
            //}
            //using (tblTransactionPostCriteriaAgeRelaxationsContext db = new tblTransactionPostCriteriaAgeRelaxationsContext())
            //{
            //    tblTransactionPostCriteriaAgeRelaxations obj = new tblTransactionPostCriteriaAgeRelaxations();
            //    obj.AgeRelax = 1;
            //    obj.CastCategoryId = 1;
            //    obj.PostId = 1;
            //    obj.IsDeleted = false;
            //    db.tblTransactionPostCriteriaAgeRelaxations.Add(obj);
            //    db.SaveChanges();
            //}
            //tbl_mst_PWDCategorycontext objPWDCategory = new tbl_mst_PWDCategorycontext();
            //var lsit = objPWDCategory.tbl_mst_PWDCategory.ToList();
            //objPWDCategory.Dispose();
            //var aa = Utility.Encrypt("123456");
            //Hindustancopperlimited.GlobalClass.Utility.SendEmailWhidoutAttachment("avishakebasuab@gmail.com", "subject", "message");
            //var hitCount = _tenderContext.tbl_hitCount.Where(x => x.strPageName == "Page").FirstOrDefault();
            //hitCount.intQuantity = hitCount.intQuantity + 1;
            //_tenderContext.Entry(hitCount).State = EntityState.Modified;
            //_tenderContext.SaveChanges();
            //ViewBag.hitCount = hitCount.intQuantity;

            //ViewBag.MainBrief = dbContext002.tbl_mst_IndexPageContent.FirstOrDefault().strMainBrief;
            //ViewBag.visionMission = dbContext002.tbl_mst_IndexPageContent.FirstOrDefault().strVisionMission;
            //ViewBag.plant_Facility = dbContext002.tbl_mst_IndexPageContent.FirstOrDefault().strPlantFacility;
            //ViewBag.Management = dbContext002.tbl_mst_IndexPageContent.FirstOrDefault().strManagement;
            #endregion Old CodeBlock-07102026

            Session["Page"] = "English";
            var Tenders = _tenderContext.vw_tenderEOI.OrderByDescending(x => x.pk_intTenderId).ToList();
            ViewBag.Events = _objContext.tbl_mst_Events.Where(x => x.dtExpiryDate > current).OrderByDescending(x => x.Pk_intEventID).ToList();
            ViewBag.Awards = _objContext.tbl_mst_AchievementAndAward.OrderByDescending(x => x.Pk_intAwardID).ToList();
            //ViewBag.CovidNews = _objContext.tbl_mst_News.Where(x => x.strNewsType == "Covid News").Take(5).ToList();

            return View(Tenders);
        }



        public ActionResult TopNews()
        {
            var News = objContext8.tbl_mst_News.Where(x => x.dtExpiryDate > current).OrderByDescending(x => x.Pk_intNewsID).ToList();
            return View(News);
        }

        public ActionResult WebsitePolicies()
        {
            return View();
        }
        public ActionResult Sustainability()
        {
            return View();
        }       
        
        
        public ActionResult ITICandidateTest()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString);
            DataSet ds = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("[dbo].[uspITIApplicationCounter]", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandTimeout = 5000;
                SqlDataAdapter adp = new SqlDataAdapter(cmd);
                adp.Fill(ds);
                cmd.Dispose();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ds.Dispose();
            }
            string Response = "";
            foreach (DataRow q in ds.Tables[0].Rows)
            {
                Response += "<tr>";
                //Response += "<td>" + q["DisciplineName"].ToString() + "</td>";
                Response += "<td>" + q[0].ToString() + "</td>";
                Response += "<td>" + q[1].ToString() + "</td>";
                Response += "<td>" + q[2].ToString() + "</td>";
               // Response += "<td>" + q[3].ToString() + "</td>";
                Response += "</tr>";
            }
            Response = "<table class=\"table\"><thead> <tr> <th>PostName</th><th>Category</th><th>Total Candidate</th>  </tr> </thead> <tbody>" + Response + "</tbody><table>";
            //ViewData["Data"] = CommonBase.ConvertToJObjectList(ds.Tables[0]);
            ViewBag.Response = Response;
            return View();
        }
       

    }


}
