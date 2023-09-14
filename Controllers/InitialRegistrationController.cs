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


namespace Hindustancopperlimited.Controllers
{
    public class InitialRegistrationController : Controller
    {
         InitialRegistrationContext objContext;

         public InitialRegistrationController()
        {
            objContext = new InitialRegistrationContext();
        }

         public ActionResult SignUp()
         {
             return View(new Login());
         }

         [HttpPost]
         public ActionResult SignUp(InitialRegistration user_reg)
         {
             objContext.UserRegistrations.Add(user_reg);
             objContext.SaveChanges();
             return RedirectToAction("Index", "Login");
         }
         
    }
}
