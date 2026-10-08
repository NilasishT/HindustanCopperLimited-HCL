using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Hindustancopperlimited.Models;
using System.Data;
using Microsoft.Office.Interop.Excel;
using NPOI.SS.Formula.Functions;

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
        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            HttpContext.Current.Response.AddHeader("x-frame-options", "SAMEORIGIN");
            HttpContext.Current.Response.AddHeader("X-Content-Type-Options", "nosniff");
            //HttpContext.Current.Response.AddHeader("Content-Security-Policy", "default-src 'self'");
            //Note:-Added By Beas
            HttpContext.Current.Response.AddHeader("Referrer-Policy", "strict-origin-when-cross-origin");
            // 1. Strict-Transport-Security (HSTS) - Forces HTTPS for 1 year
            HttpContext.Current.Response.AddHeader("Strict-Transport-Security", "max-age=31536000; includeSubDomains");
            // 2. Content-Security-Policy (CSP) - Whitelists your fonts, scripts, and local content safely
            // Cloudflare Insights is allowed through static.cloudflareinsights.com
            HttpContext.Current.Response.AddHeader(
                "Content-Security-Policy",
                "default-src 'self'; " +
                "script-src 'self' 'unsafe-inline' 'unsafe-eval' https://static.cloudflareinsights.com; " +
                "style-src 'self' 'unsafe-inline' https://fonts.googleapis.com https://cdnjs.cloudflare.com; " +
                "font-src 'self' https://fonts.gstatic.com https://cdnjs.cloudflare.com data:; " +
                "img-src 'self' data: https:;"
            );
            //Note:-Added By Beas
        }
    }
}