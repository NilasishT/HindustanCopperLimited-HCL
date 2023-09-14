using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Models;
using System.Configuration;
using System.Net;
using System.IO;


namespace Hindustancopperlimited.Controllers
{
    public class DengueController : Controller
    {
        //
        // GET: /Dengue/

        tbl_mstDengueContext obj = new tbl_mstDengueContext();
        public ActionResult Index()
        {
            var tbl_mstDengue = obj.tbl_mstDengue.OrderByDescending(x=>x.pkId).ToList();
            return View(tbl_mstDengue);
        }

        public ActionResult Create()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Create(tbl_mstDengue objtbl_mstDengue)
        {
            obj.tbl_mstDengue.Add(objtbl_mstDengue);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SendSMS(int id)
        {
            var tbl_mstDengue = obj.tbl_mstDengue.Where(x=>x.pkId==id).FirstOrDefault();
            ViewBag.Name = tbl_mstDengue.Name;
            ViewBag.Phoneno = tbl_mstDengue.Phoneno;
            ViewBag.message = "The test of " + tbl_mstDengue.Name + "," + tbl_mstDengue.Address + " is done and found Reactive";
            return View();
        }

        [HttpPost]
        public ActionResult SendSMS(int id,FormCollection frm)
        {
            SendSMSHowrah(frm["Phoneno"], frm["message"]);
            return RedirectToAction("Index");
        }


        public static string SendSMSHowrah(string mobileNo, string messageText)
        {
            string retVal = "";
            try
            {
                string mVaayooUrl = "http://api.infoskysolution.com/SendSMS/sendmsg.php?";
                string mVaayooUserId = "DATAFLOWT";
                string mVaayooPwd = "howrah";
                string mSend = "CMOHWH";

                if (mobileNo.Trim().Length > 0)
                {
                    mobileNo = mobileNo.Trim();

                    string strUrl = mVaayooUrl + "uname=" + mVaayooUserId + "&pass=" + mVaayooPwd + "&send=" + mSend + "&dest=" + mobileNo + "&msg=" + messageText;
                    WebRequest request = HttpWebRequest.Create(strUrl);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream s = (Stream)response.GetResponseStream();
                    StreamReader readStream = new StreamReader(s);
                    retVal = readStream.ReadToEnd();
                    response.Close();
                    s.Close();
                    readStream.Close();

                }
            }
            catch (Exception ex)
            {
                retVal = ex.Message;
            }
            return retVal;
        }


    }
}
