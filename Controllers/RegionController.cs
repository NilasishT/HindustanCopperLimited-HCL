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
using System.Data.Entity.Validation;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Web.Routing;
using System.Web.Security;
using Hindustancopperlimited.GlobalClass;
using Microsoft.Office.Interop.Excel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.OleDb;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using NPOI.HSSF.UserModel;

namespace Hindustancopperlimited.Controllers
{
    public class RegionController : BaseController
    {
        //
        // GET: /RegionUser/

        AdminLoginContext objContext = new AdminLoginContext();
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
        public ActionResult Login()
        {
            //captcha
            recaptcha();
            //captcha
            return View();


        }
        
        [HttpPost]

        public ActionResult Login(RegionUser objUser, FormCollection frm)
        {
            
            if (ModelState.IsValid)
            {
                if (frm["forEmail"] != null)
                {
                    string Email = frm["forEmail"].ToString();
                    var loginuser = objContext.RegionUser.Where(a => a.strEmail.Equals(Email)).FirstOrDefault();
                    ViewBag.Message = string.Format("Please check your email.");
                    Utility.SendEmail(frm["forEmail"].ToString(), "Password", "Your Password is :" + Decrypt(loginuser.strUserPwd));

                }
                else
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
                        var pass = Encrypt(objUser.strUserPwd);
                        var decryptpass = Decrypt(pass);

                        // var loginuser = objContext.LOGINs.Where(a => a.strEmail.Equals(objUser.strEmail) && a.strUserPwd.Equals(decryptpass)).FirstOrDefault();

                        var loginuser = objContext.RegionUser.Where(a => a.strEmail.Equals(objUser.strEmail) && a.strUserPwd.Equals(pass)).FirstOrDefault();
                        if (loginuser != null)
                        {

                            Session["UserID"] = loginuser.pk_intRegionUserId.ToString();
                            Session["UserName"] = loginuser.strUserName.ToString();
                            Session["strEmail"] = loginuser.strEmail.ToString();

                            //if (Convert.IsDBNull(loginuser.Fk_intUnitId))
                            //    Session["UserType"] = "Admin";
                            //else
                            //    Session["UserType"] = "";
                            Session["strMenuRightID"] = loginuser.strMenuRightID;
                            // Session["UnitId"] = loginuser.Fk_intUnitId;
                            Session["UserType"] = loginuser.strusertype;
                            Session["UserRegion"] = loginuser.strRegion;
                            Session["Designation"] = "";


                            //if (Session["UserType"].ToString() == "Super Admin")
                            //{
                            //    Session["strMenuRightID"] = "0";
                            //}

                            //SessionContext.SetAuthenticationToken(Session["UserName"].ToString(), false, loginuser);
                            return RedirectToAction("Dashboard", "Admin");
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
                }

            }

            return View();
        }




        private string Decrypt(string cipherText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }


        private string Encrypt(string clearText)
        {
            string EncryptionKey = "MAKV2SPBNI99212";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }


    }
}
