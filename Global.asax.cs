using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Hindustancopperlimited.Models;
using System.Data;

namespace Hindustancopperlimited
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        TenderContext _tenderContext = new TenderContext();

        protected void Application_Start()
        {            
            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            //Application["lastUpdated"] = "06/01/2020 17:10:13";
            //Application["NoOfVisitors"] = _tenderContext.tbl_hitCount.FirstOrDefault().intQuantity; 

        }

        //protected void Session_Start(object sender, EventArgs e)
        protected void Session_Start()
        {
            Application.Lock();
            //if (Application["lastUpdated"].ToString() == "06/01/2020 17:10:13")
            //{
            //    Application["lastUpdated"] = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            //}
            try
            {
                var hitData = _tenderContext.tbl_hitCount.FirstOrDefault();
                hitData.intQuantity = hitData.intQuantity + 1;
                hitData.LastUpdate = DateTime.Now;
                _tenderContext.Entry(hitData).State = EntityState.Modified;
                _tenderContext.SaveChanges();
                Application["NoOfVisitors"] = hitData.intQuantity + 1;
                Application["lastUpdated"] = hitData.LastUpdate;
            }
            catch { }
            Application.UnLock();
        }
        //Hit Counter

       
       
    }
}