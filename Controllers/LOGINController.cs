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
using System.Data.Entity;

namespace Hindustancopperlimited.Controllers
{
    public class LoginController : Controller
    {
        LoginContext objContext;

        public LoginController()
        {
            objContext = new LoginContext();
        }

        public ActionResult Index()
        {
            var login = objContext.UserRegistrations.ToList();
            return View(login);
        }


        [HttpPost]
      
        public ActionResult Index(InitialRegistration objUser)
        {
            if (ModelState.IsValid)
            {
                //using (System.Data.Entity.DB_Entities db = new DB_Entities())
                //{
                var login = objContext.UserRegistrations.ToList();
                var obj = objContext.UserRegistrations.Where(a => a.strEmail.Equals(objUser.strEmail) && a.strPassword.Equals(objUser.strPassword)).FirstOrDefault();
                if (obj != null)
                {
                   // Session["UserID"] = obj.strUserId.ToString();
                    Session["UserName"] = obj.struserName.ToString();
                    Session["strEmail"] = obj.strEmail.ToString();
                    return RedirectToAction("Create", "VendorRegistration");
                }
                else
                {
                    return RedirectToAction("Login");
                }

            }
            return RedirectToAction("Login");

        }


    }
}  
