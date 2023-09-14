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
using System.IO;
using Hindustancopperlimited.GlobalClass;
using System.Text;
using System.Security.Cryptography;
using System.Data.Entity.Validation;
using System.Web.Security;
using System.Web.UI;
using Microsoft.Office.Interop.Excel;
using System.Data.Entity;

namespace Hindustancopperlimited.Controllers
{
    public class VendorRegistrationController : Controller
    {
        VendorRegistrationContext objContext;
        VendorsNewContext objContextNew;
        UnitContext objContext1;
        CasteContext objContext2;
        CompanyContext objContext3;
        ConstitutionFirmCotext objContext4;
        ItemDescriptionContext objContext5;
        VendorLoginContext vContest;
        tbl_mstDepartmentContext objContext8 = new tbl_mstDepartmentContext();
        tbl_mst_Serviceprovidercontext objprovider = new tbl_mst_Serviceprovidercontext();
        tbl_mst_countrycontext objcountry = new tbl_mst_countrycontext();
        tbl_mst_statecontext objstate = new tbl_mst_statecontext();
        public VendorRegistrationController()
        {
            objContext = new VendorRegistrationContext();
            objContextNew = new VendorsNewContext();
            objContext1 = new UnitContext();
            objContext2 = new CasteContext();
            objContext3 = new CompanyContext();
            objContext4 = new ConstitutionFirmCotext();
            objContext5 = new ItemDescriptionContext();
            vContest = new VendorLoginContext();
        }


        //Close 01/03/2019 Bhashkar

        //public ActionResult Create()
        //{
        //    ViewBag.int_fk_CompanyStatusID = new SelectList(objContext3.Companys.ToList(), "pk_CompanyStatusID", "strCompanyStatusName");
        //    ViewBag.Fk_intUnitId = new SelectList(objContext1.Units.ToList(), "pk_intUnitId", "strUnitName");
        //    ViewBag.Fk_intDepartment = new SelectList(objContext8.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");
        //    return View(new VendorRegistration());
        //}
        //[ValidateAntiForgeryToken]
        //[HttpPost]
        //public ActionResult Create(VendorRegistration VendorRegistration, FormCollection frm)
        //{

        //    ViewBag.int_fk_CompanyStatusID = new SelectList(objContext3.Companys.ToList(), "pk_CompanyStatusID", "strCompanyStatusName");
        //    ViewBag.Fk_intUnitId = new SelectList(objContext1.Units.ToList(), "pk_intUnitId", "strUnitName");
        //    ViewBag.Fk_intDepartment = new SelectList(objContext8.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");

        //    if (ModelState.IsValid)
        //    {

        //        int checkData = objContext.VendorRegistrations.Where(x => x.strNameofFirmCompany == VendorRegistration.strNameofFirmCompany).ToList().Count();

        //        if (checkData == 0)
        //        {

        //            string VendorId = objContext.AutoVendorRegistrationID();
        //            VendorRegistration.Fk_intUnitId = frm["hidFk_intUnitId"];
        //            VendorRegistration.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        //            VendorRegistration.dtApplicationDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        //            VendorRegistration.Fk_intDepartment = frm["hidFk_intDepartment"];
        //            VendorRegistration.strVendorRegistrationID = VendorId;
        //            VendorRegistration.strActive = "NO";
        //            VendorRegistration.strPending = "NO";
        //            VendorRegistration.strVerify = "NO";
        //            objContext.VendorRegistrations.Add(VendorRegistration);
        //            objContext.SaveChanges();


        //            VendorLoginContext objVendorLoginContext = new VendorLoginContext();
        //            VendorLogin objVendorLogin = new VendorLogin();
        //            int checkobjVendorLogin = objVendorLoginContext.VendorLogin.Where(x => x.strUserName == VendorId).ToList().Count;
        //            if (checkobjVendorLogin == 0)
        //            {
        //                objVendorLogin.Fk_intUnitId = frm["hidFk_intUnitId"];
        //                objVendorLogin.strUserName = VendorId;
        //                if (frm["hidFk_intDepartment"] != "" && frm["hidFk_intDepartment"] != null)
        //                {
        //                    objVendorLogin.strusertype = "CONTRACTOR";
        //                }
        //                else
        //                {
        //                    objVendorLogin.strusertype = "VENDOR";
        //                }

                        
        //                objVendorLogin.strUserPwd = Encrypt(VendorRegistration.strMobile);
        //                objVendorLogin.strIsActive = "YES";
        //                objVendorLogin.dtActivedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        //                objVendorLoginContext.VendorLogin.Add(objVendorLogin);
        //                objVendorLoginContext.SaveChanges();
        //            }


        //            ViewBag.Message = "Data has been save successfully. ";

        //            Utility.SendEmailForVendor(frm["strEmail"].ToString(), "Hindustan Copper Limited (HCL) Vendor Registration", "Your vendor code is  : " + VendorId + ". Please Click Here to login :  " + "http://hindustancopper.com/VendorRegistration/login");
        //            return RedirectToAction("SetPassword/" + VendorId);
        //        }

        //        else
        //        {
        //            ViewBag.Message = "The Name of Firm/Company already exists.";
        //            return View();
        //        }

        //    }

        //    string messages = string.Join("; ", ModelState.Values
        //                               .SelectMany(x => x.Errors)
        //                               .Select(x => x.ErrorMessage));


        //    ViewBag.Message = messages;

        //    return View();



        //}

        //Close 01/03/2019 Bhashkar

        [HttpPost]
        public ActionResult checkCompanyName(string NameofFirmCompany)
        {
            var already = "No";
            int checkData = objContext.VendorRegistrations.Where(x => x.strNameofFirmCompany == NameofFirmCompany).ToList().Count();
            if (checkData > 0)
            {
                already = "Yes";
            }
            return Json(new { already = already });
        }


        [HttpPost]
        public ActionResult checkGST(string GSTNo)
        {
            var already = "No";
            int checkData = objContextNew.VendorsNews.Where(x => x.strGSTNo == GSTNo).ToList().Count();
            if (checkData > 0)
            {
                already = "Yes";
            }
            return Json(new { already = already });
        }


        [NoDirectAccess]
        public ActionResult SetPassword(string id)
        {

            VendorLoginContext objVendorLoginContext = new VendorLoginContext();
            VendorLogin VendorLogin = objVendorLoginContext.VendorLogin.Single(x => x.strUserName == id);
            return View(VendorLogin);
        }

        [HttpPost]
        public ActionResult SetPassword(string id, FormCollection frm)
        {
            VendorLoginContext objVendorLoginContext = new VendorLoginContext();
            VendorLogin VendorLogin = objVendorLoginContext.VendorLogin.Single(x => x.strUserName == id);




            if ((frm["strUserPwd"] == frm["strUserRePwd"]))
            {
                if (frm["strUserPwd"].Length < 6)
                {
                    ViewBag.Message = string.Format("Password cannot be less than 6 characters.");
                    return View(VendorLogin);
                }
                else
                {
                    VendorLogin.strUserPwd = Encrypt(frm["strUserPwd"]);
                    objVendorLoginContext.Entry(VendorLogin).State = EntityState.Modified;
                    objVendorLoginContext.SaveChanges();
                    return RedirectToAction("Login");
                }


            }

            else
            {
                ViewBag.Message = string.Format("Password and Re-Password do not match.");
                return View(VendorLogin);
            }

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

                VendorLoginContext objVendorLoginContext = new VendorLoginContext();

                var pass = Encrypt(frm["strUsercurrentPwd"]);
                string UserName = Session["VendorCode"].ToString();
                var VendorLogin = objVendorLoginContext.VendorLogin.Where(a => a.strUserName.Equals(UserName) && a.strUserPwd.Equals(pass)).FirstOrDefault();


                if (frm["strUserPwd"] == frm["strUserRePwd"])
                {
                    VendorLogin.strUserPwd = Encrypt(frm["strUserPwd"]);
                    objVendorLoginContext.Entry(VendorLogin).State = EntityState.Modified;
                    objVendorLoginContext.SaveChanges();
                    return RedirectToAction("Login");
                }
                ViewBag.Message = string.Format("Password and Re-Password do not match.");
                return View(VendorLogin);
            }
            catch
            {
                ViewBag.Message = string.Format("Password and Re-Password do not match.");
                return View();
            }
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
        public ActionResult ForgotPassword()
        {
            
            return View();


        }



        [HttpPost]
        public ActionResult ForgotPassword(FormCollection frm)
        {

            if (ModelState.IsValid)
            {
                if (frm["forEmail"] != null)
                {
                    string VendorCode = frm["forEmail"].ToString();
                    string ConEmail = frm["forCONEmail"].ToString();
                    string ConMobile = frm["MOBILEforEmail"].ToString();

                    VendorsNew VendorRegistration = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == VendorCode && x.strEmail == ConEmail && x.strMobile == ConMobile).FirstOrDefault();
                    if (VendorRegistration != null)
                    {
                        Utility.SendEmail(VendorRegistration.strEmail, "Your password has been changed by you.", "Your password has been changed by you.");
                        return RedirectToAction("SetPassword/" + VendorRegistration.strVendorRegistrationID);
                    }
                    else
                    {
                        ViewBag.Message = string.Format("Invalied Input.");
                        return View();
                    }
                    //ViewBag.Message = string.Format("Please check your email.");
                    //Utility.SendEmail(VendorRegistration.strEmail, "Please set your password from HCL", "Click Here   :  " + "http://hcl.dfssolutions.com/VendorRegistration/SetPassword/" + VendorRegistration.strVendorRegistrationID);
                }
                

            }

            return View();
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
        public ActionResult Login(FormCollection frm)
        {

            if (ModelState.IsValid)
            {
                if (frm["forEmail"] != null)
                {
                    string VendorCode = frm["forEmail"].ToString();
                    string ConEmail = frm["forCONEmail"].ToString();
                    string ConMobile = frm["MOBILEforEmail"].ToString();

                    VendorsNew VendorRegistration = objContextNew.VendorsNews.Where(x => x.strVendorRegistrationID == VendorCode && x.strEmail == ConEmail).FirstOrDefault();
                    if (VendorRegistration != null)
                    {
                        if (VendorRegistration.strMobile.Substring(6, 4) == ConMobile)
                        {
                            Utility.SendEmail(VendorRegistration.strEmail, "Your password has been changed by you.", "Your password has been changed by you.");
                            return RedirectToAction("SetPassword/" + VendorRegistration.strVendorRegistrationID);
                        }
                    }
                    else
                    {
                        ViewBag.Message = string.Format("Invalied Input.");
                        return View();
                    }
                    //ViewBag.Message = string.Format("Please check your email.");
                    //Utility.SendEmail(VendorRegistration.strEmail, "Please set your password from HCL", "Click Here   :  " + "http://hcl.dfssolutions.com/VendorRegistration/SetPassword/" + VendorRegistration.strVendorRegistrationID);
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

                        var pass = Encrypt(frm["strUserPwd"]);
                        var decryptpass = Decrypt(pass);

                        DateTime currentDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");

                        string UserName = frm["strUserName"];
                        var loginuser = vContest.VendorLogin.Where(a => a.strUserName.Equals(UserName) && a.strUserPwd.Equals(pass)).FirstOrDefault();



                        if (loginuser != null)
                        {
                            tbl_VendorBlackListedContext objtbl_VendorBlackListedContext = new tbl_VendorBlackListedContext();
                            var checkBalckList = objtbl_VendorBlackListedContext.tbl_VendorBlackListed.Where(x => x.strVendorCode == UserName && x.dtFromDate < currentDate && x.dtToDate > currentDate).FirstOrDefault();
                            if (checkBalckList == null)
                            {

                                Session["UserID"] = loginuser.pk_intVendorUserId.ToString();
                                Session["VendorCode"] = loginuser.strUserName.ToString();
                                Session["VendorUnitId"] = loginuser.Fk_intUnitId;
                                Session["UserType"] = loginuser.strusertype;
                                Session["strMenuRightID"] = "0";
                                Session["code"] = "0";
                                return RedirectToAction("Dashboard", "Admin");
                            }
                            else
                            {
                                ViewBag.Message = string.Format("You are debarred from " + checkBalckList.dtFromDate.Value.ToString("dd/MMM/yyyy") + " to " + checkBalckList.dtToDate.Value.ToString("dd/MMM/yyyy"));
                                return View();
                            }

                        }
                        else
                        {
                            //captcha
                            recaptcha();
                            //captcha
                            ViewBag.Message = string.Format("Invalid Vendor Code or Password.");
                            return View();
                        }
                    }
                }

            }

            return View();
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

        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            Request.Cookies.Clear();
            Session["UserID"] = null;
            Session["VendorCode"] = null;
            Session["VendorUnitId"] = null;
            Session["UserType"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult New()  
        {

            ViewBag.str_country = new SelectList(objcountry.tbl_mst_country.ToList(), "Str_country", "Str_country", "India");
            ViewBag.str_state = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.int_fk_CompanyStatusID = new SelectList(objContext3.Companys.ToList(), "pk_CompanyStatusID", "strCompanyStatusName");
            ViewBag.Fk_intUnitId = new SelectList(objContext1.Units.ToList(), "pk_intUnitId", "strUnitName");
            ViewBag.Fk_intDepartment = new SelectList(objContext8.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");
            //ViewBag.fk_intConstitutionFirmID = new SelectList(objContext4.ConstitutionFirms.ToList(), "pk_intConstitutionFirmID", "strConstitutionFirm", VendorsNew.fk_intConstitutionFirmID);
            ViewBag.fk_intConstitutionFirmID = new SelectList(objContext4.ConstitutionFirms.ToList(), "pk_intConstitutionFirmID", "strConstitutionFirm");
            ViewBag.strRegistrationApplied = new SelectList(objContext5.ItemDescriptions.ToList(), "Pk_intItemDescription", "strItemDescriptionName");
            //ViewBag.intfk_CasteID = new SelectList(objContext2.Castes.ToList(), "pk_intCasteId", "strCasteName", VendorRegistration.intfk_CasteID);
            ViewBag.intfk_CategoryID = new SelectList(objContext2.Castes.ToList(), "pk_intCasteId", "strCasteName");

            ViewBag.str_serviceprovidertype = new SelectList(objprovider.tbl_mst_Serviceprovider.ToList(), "str_desc", "str_desc");
            return View(new VendorsNew());
            //return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult New(VendorsNew VendorsNew, FormCollection frm)
        {

            ViewBag.str_country = new SelectList(objcountry.tbl_mst_country.ToList(), "Str_country", "Str_country", frm["Str_country"]);
            ViewBag.str_state = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.int_fk_CompanyStatusID = new SelectList(objContext3.Companys.ToList(), "pk_CompanyStatusID", "strCompanyStatusName");
            ViewBag.Fk_intUnitId = new SelectList(objContext1.Units.ToList(), "pk_intUnitId", "strUnitName");
            ViewBag.Fk_intDepartment = new SelectList(objContext8.tbl_mstDepartment.Where(x => x.isActive == true).ToList(), "pk_intID", "strDepartmentName");
            //ViewBag.fk_intConstitutionFirmID = new SelectList(objContext4.ConstitutionFirms.ToList(), "pk_intConstitutionFirmID", "strConstitutionFirm", VendorsNew.fk_intConstitutionFirmID);
            ViewBag.fk_intConstitutionFirmID = new SelectList(objContext4.ConstitutionFirms.ToList(), "pk_intConstitutionFirmID", "strConstitutionFirm");
            ViewBag.strRegistrationApplied = new SelectList(objContext5.ItemDescriptions.ToList(), "Pk_intItemDescription", "strItemDescriptionName");
            //ViewBag.intfk_CasteID = new SelectList(objContext2.Castes.ToList(), "pk_intCasteId", "strCasteName", VendorRegistration.intfk_CasteID);
            ViewBag.intfk_CategoryID = new SelectList(objContext2.Castes.ToList(), "pk_intCasteId", "strCasteName");

            ViewBag.str_serviceprovidertype = new SelectList(objprovider.tbl_mst_Serviceprovider.ToList(), "str_desc", "str_desc");

            if (ModelState.IsValid)
            {
                //int checkData = objContextNew.VendorsNew.Where(x => x.strNameofFirmCompany == VendorsNew.strNameofFirmCompany).ToList().Count();

                //if (checkData == 0)
                //{
                string VendorId = objContextNew.AutoVendorRegistrationID();
                //var gst = frm["strGSTNo"];
                //var pan = gst.Substring(gst.Length - 13);
                VendorsNew.Fk_intUnitId = frm["hidFk_intUnitId"];
                //VendorsNew.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                //VendorsNew.dtApplicationDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                VendorsNew.Fk_intDepartment = frm["hidFk_intDepartment"];
                VendorsNew.strRegistrationApplied = frm["hidstrRegistrationApplied"];
                //VendorsNew.strIsManpowerSupplier = frm["strIsManpowerSupplier"];
                VendorsNew.strVendorRegistrationID = VendorId;
                VendorsNew.strActive = "YES";
                VendorsNew.strPending = "NO";
                VendorsNew.strVerify = "YES";
                VendorsNew.dtEntryDate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                objContextNew.VendorsNews.Add(VendorsNew);
                objContextNew.SaveChanges();

                VendorLoginContext objVendorLoginContext = new VendorLoginContext();
                VendorLogin objVendorLogin = new VendorLogin();
                int checkobjVendorLogin = objVendorLoginContext.VendorLogin.Where(x => x.strUserName == VendorId).ToList().Count;
                if (checkobjVendorLogin == 0)
                {
                    objVendorLogin.Fk_intUnitId = frm["hidFk_intUnitId"];
                    objVendorLogin.strUserName = VendorId;
                    if (frm["strIsManpowerSupplier"] == "Yes")
                    {
                        objVendorLogin.strusertype = "CONTRACTOR";
                    }
                    else
                    {
                        objVendorLogin.strusertype = "VENDOR";
                    }
                    objVendorLogin.strUserPwd = Encrypt(VendorsNew.strMobile);
                    objVendorLogin.strIsActive = "YES";
                    objVendorLogin.dtActivedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    objVendorLoginContext.VendorLogin.Add(objVendorLogin);
                    objVendorLoginContext.SaveChanges();
                }

                ViewBag.Message = "Data has been save successfully. ";

                Utility.SendEmailForVendor(frm["strEmail"].ToString(), "Hindustan Copper Limited (HCL) Vendor Registration", "Your vendor code is  : " + VendorId + ". Please Click Here to login :  " + "http://hindustancopper.com/VendorRegistration/login");
                return RedirectToAction("SetPassword/" + VendorId);
                //}

                //else
                //{
                //    ViewBag.Message = "The Name of Firm/Company already exists.";
                //    return View();
                //}

            }

            string messages = string.Join("; ", ModelState.Values
                                       .SelectMany(x => x.Errors)
                                       .Select(x => x.ErrorMessage));
            ViewBag.Message = messages;

            return View();
        }

        //[HttpPost]
        //public ActionResult checkPAN(string GSTNo, string PanNo)
        //{
        //    var already = "No";
        //    var gst = GSTNo;
        //    var valid = gst.Substring(2, 11);
        //    var pan = PanNo;
        //    if (valid != pan)
        //    {
        //        already = "Yes";
        //    }
        //    else
        //    {

        //    }
        //    return Json(new { already = already });
        //}




    }
}