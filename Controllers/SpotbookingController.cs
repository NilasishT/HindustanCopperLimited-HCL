using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Hindustancopperlimited.Models;
using System.Configuration;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using Hindustancopperlimited.GlobalClass;
using System.Web.Security;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Security.Principal;
using System.Web.Routing;
using System.Data.Entity.Validation;
using Microsoft.Office.Interop.Excel;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.OleDb;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html;
using iTextSharp.text.html.simpleparser;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using NPOI.HSSF.UserModel;
using System.Text.RegularExpressions;

namespace Hindustancopperlimited.Controllers
{
    public class SpotbookingController : BaseController
    {
        DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        Spotbookingregistrationcontext objSpotbookingregistrationcontext = new Spotbookingregistrationcontext();
        tbl_mst_statecontext objstate = new tbl_mst_statecontext();
        tbl_mst_ProductsContext objProducts = new tbl_mst_ProductsContext();
        tbl_mst_OrderTypesContext objOrderTypes = new tbl_mst_OrderTypesContext();
        tbl_mst_OrderOptionsContext objOrderOptions = new tbl_mst_OrderOptionsContext();
        tbl_mst_countrycontext objcountry = new tbl_mst_countrycontext();
        tbl_mst_SpotbookingOrdersContext objSpotbookingOrders = new tbl_mst_SpotbookingOrdersContext();
        SpotbookingLoginContext objSpotbookingLogin = new SpotbookingLoginContext();
        tbl_mst_LMEdetailscontext objLMEdetails = new tbl_mst_LMEdetailscontext();
        UnitContext objContext3 = new UnitContext();
        tbl_mst_Spotbooking_TenderContext objtender = new tbl_mst_Spotbooking_TenderContext();
        vw_SpotbookingTenderContext objSpotbookingTenderdetails = new vw_SpotbookingTenderContext();
        tbl_MailContentContext objMailContent = new tbl_MailContentContext();

        public ActionResult SpotbookingRegistration()
        {
            ViewBag.str_state = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.str_country = new SelectList(objcountry.tbl_mst_country.ToList(), "Str_country", "Str_country");
            ViewBag.fk_region = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Region" && x.isactive == "YES").ToList(),
           "str_lmedescription", "str_lmedescription");

            return View();
        }
        [HttpPost]
        public ActionResult SpotbookingRegistration(SpotbookingRegistrationdetails SpotbookingRegistrationdetails, FormCollection frm)
        {
            ViewBag.str_state = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename");
            ViewBag.str_country = new SelectList(objcountry.tbl_mst_country.ToList(), "Str_country", "Str_country");
            ViewBag.fk_region = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Region" && x.isactive=="YES").ToList(),
            "str_lmedescription", "str_lmedescription");
            //ViewBag.success = "Not Ok";
            if ((frm["str_pw"] == frm["str_confirmpw"]))
            {
                int checkData = objSpotbookingregistrationcontext.SpotbookingRegistrationdetails.Where(x => x.str_email == SpotbookingRegistrationdetails.str_email ).ToList().Count();
                int check = objSpotbookingregistrationcontext.SpotbookingRegistrationdetails.Where(x => x.str_namefirm == SpotbookingRegistrationdetails.str_namefirm ).ToList().Count();
                int checkpan = objSpotbookingregistrationcontext.SpotbookingRegistrationdetails.Where(x => x.str_panno == SpotbookingRegistrationdetails.str_panno).ToList().Count();
                int checkgst = objSpotbookingregistrationcontext.SpotbookingRegistrationdetails.Where(x => x.str_gstno == SpotbookingRegistrationdetails.str_gstno).ToList().Count();
                if (checkData == 0)
                {


                    if (check == 0)
                    {
                        if (checkpan == 0)
                        {
                            if (checkgst == 0)
                            {
                                string Id = objSpotbookingregistrationcontext.AutoVendorRegistrationID();
                                SpotbookingRegistrationdetails.Isactive = "YES";
                                SpotbookingRegistrationdetails.dt_entrydate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                                SpotbookingRegistrationdetails.str_code = Id;
                                SpotbookingRegistrationdetails.str_CustomerStatus = "Pending";                                
                                objSpotbookingregistrationcontext.SpotbookingRegistrationdetails.Add(SpotbookingRegistrationdetails);
                                objSpotbookingregistrationcontext.SaveChanges();

                                var MaillContent = objMailContent.tbl_MailContent.OrderByDescending(x => x.strMailPurposeType == "Customer Creation").FirstOrDefault();
                                if (MaillContent != null)
                                {
                                    var adminemail = "ho_mkt@hindustancopper.com";
                                    StringBuilder stringBuilder = new StringBuilder(MaillContent.strBody);
                                    stringBuilder.Replace("{adminemail}", adminemail);
                                    string EmailBody = stringBuilder.ToString();

                                    Utility.SendEmail(SpotbookingRegistrationdetails.str_email, MaillContent.strSubject, EmailBody);
                                }

                                ViewBag.Message = string.Format("Your UserId is =" + Id +". Please Check your Email");
                                ViewData["Msg"]="OK";

                            }
                            else
                            {
                                ViewBag.Message = string.Format("GST NO. Already Exists");
                            }
                        }
                        else
                        {
                            ViewBag.Message = string.Format("PAN NO. Already Exists");
                        }
                    }
                    else
                    {
                        ViewBag.Message = string.Format("Company Name Already Exists");
                    }
                }

                else
                {
                    ViewBag.Message = string.Format("The Email Id Already Registered! ");
                }

            }
            else
            {
                ViewBag.Message = string.Format("Password and Confirm Password do not match");

            }

            
            
            return View();
        }
        public ActionResult EditSpotbookingRegistration()
        {

            int id = Convert.ToInt32(Session["UserID"]);
            var SpotbookingRegistrationdetails = objSpotbookingregistrationcontext.SpotbookingRegistrationdetails.Single(x => x.Pk_Registrationid == id);
            ViewBag.str_state = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", SpotbookingRegistrationdetails.str_state);
            ViewBag.str_country = new SelectList(objcountry.tbl_mst_country.ToList(), "Str_country", "Str_country", SpotbookingRegistrationdetails.str_country);
            ViewBag.fk_region = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Region" && x.isactive == "YES").ToList(),
            "str_lmedescription", "str_lmedescription", SpotbookingRegistrationdetails.fk_region);
            return View(SpotbookingRegistrationdetails);
           
        }
        //[HttpPost]
        //public ActionResult EditSpotbookingRegistration(SpotbookingRegistrationdetails SpotbookingRegistrationdetails, FormCollection frm)
        //{
        //    ViewBag.str_state = new SelectList(objstate.tbl_mst_state.ToList(), "statename", "statename", SpotbookingRegistrationdetails.str_state);
        //    ViewBag.str_country = new SelectList(objcountry.tbl_mst_country.ToList(), "Str_country", "Str_country", SpotbookingRegistrationdetails.str_country);
        //    ViewBag.fk_region = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Region" && x.isactive == "YES").ToList(),
        //    "str_lmedescription", "str_lmedescription", SpotbookingRegistrationdetails.fk_region);
        //    if ((frm["str_pw"] == frm["str_confirmpw"]))
        //    {

        //        SpotbookingRegistrationdetails.dt_updatedate = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        //        SpotbookingRegistrationdetails.str_CustomerStatus = "Approved";
        //        objSpotbookingregistrationcontext.Entry(SpotbookingRegistrationdetails).State = EntityState.Modified;
        //        objSpotbookingregistrationcontext.SaveChanges();
        //        ViewBag.Message = "Data updated Successfully.";
        //    }
        //    else
        //    {
        //        ViewBag.Message = string.Format("Password and Confirm Password do not match");

        //    }
        //    return View();
        //}
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
        public ActionResult Login(SpotbookingRegistrationdetails SpotbookingRegistrationdetails,FormCollection frm)
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



                    var loginuser = objSpotbookingregistrationcontext.SpotbookingRegistrationdetails.Where(a => a.str_code.Equals(SpotbookingRegistrationdetails.str_code) && a.str_pw.Equals(SpotbookingRegistrationdetails.str_pw)).FirstOrDefault();

                    if (loginuser != null)
                    {
                        if (loginuser.str_CustomerStatus == "Approved")
                        {

                            Session["UserID"] = loginuser.Pk_Registrationid.ToString();
                            Session["code"] = loginuser.str_code.ToString();
                            Session["UserType"] = "LMECustomer";
                            Session["Name"] = loginuser.str_namefirm.ToString();
                            Session["strMenuRightID"] = "0";
                            //  SessionContext.SetAuthenticationToken(Session["UserName"].ToString(), false, loginuser);

                            return RedirectToAction("Dashboard", "Admin");
                        }
                        else
                        {
                            //captcha
                            recaptcha();
                            //captcha
                            ViewBag.Message = string.Format("You Are Not Approved By Admin.");
                            return View();
                        }
                    }
                    else
                    {
                        //captcha
                        recaptcha();
                        //captcha
                        ViewBag.Message = string.Format("User name and password incorrect");
                        return View();
                    }
                }


            }

            

            return View();

        }


        public ActionResult Logout()
        {
            HttpCookie cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            Request.Cookies.Clear();
            Session["UserID"] = null;
            Session["code"] = null;
            Session["UserType"] = null;
            Session["Name"] = null;
            return RedirectToAction("Index", "Home");
        }



       
        // forgot password

        public ActionResult ForgotPassword()
        {

            return View();
        }



        [HttpPost]

        public ActionResult ForgotPassword(SpotbookingRegistrationdetails SpotbookingRegistrationdetails, FormCollection frm)
        {
            string email = frm["str_email"].ToString();

            var Registration = objSpotbookingregistrationcontext.SpotbookingRegistrationdetails.Where(x => x.str_email == email ).FirstOrDefault();

            if (Registration == null)
            {
                ViewBag.Message = "Please put the correct Email";
            }
            else
            {
                Utility.SendEmail(Registration.str_email, "Please Write Down", "Your password is :" + Registration.str_pw);
                ViewBag.Message = "Password will be send.Please check your email.";
            }
            return View();

        }

        [HttpGet]
        public ActionResult OrderBooking()
        {
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            tbl_DisableOrderContext obj = new tbl_DisableOrderContext();

            int checkData = obj.tbl_DisableOrder.Where(x => x.dtFromDate <= current && x.dtTodate >= current).ToList().Count();

            if (checkData == 0)
            {
                ViewBag.hidCurrenth = current.Hour;
                ViewBag.hidCurrentm = current.Minute.ToString().PadLeft(2, '0');
                ViewBag.hidCurrents = current.Second.ToString().PadLeft(2, '0');
                ViewBag.dtOrderDate = current.ToShortDateString();
                ViewBag.strProducts = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Product of Interest" && x.dt_StartDate <= current && (x.dt_EndDate >= current || x.dt_EndDate == null)).ToList(), "str_lmedescription", "str_lmedescription");
                ViewBag.strOrderType = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Order Type" && x.isactive == "YES" && x.dt_StartDate <= current && (x.dt_EndDate >= current || x.dt_EndDate == null)).ToList().OrderBy(x => x.str_lmedescription), "str_lmedescription", "str_lmedescription");
                //ViewBag.str_deliveryplace = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Delivery Place" && x.isactive == "YES").ToList(), "str_lmedescription", "str_lmedescription");
                ViewBag.str_deliveryplace = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Delivery Place" && x.isactive == "YES" && x.dt_StartDate <= current && (x.dt_EndDate >= current || x.dt_EndDate == null)).ToList(), "str_lmedescription", "str_lmedescription");
                ViewBag.strLiftingOption = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Lifting Option" && x.isactive == "YES").ToList(), "str_lmedescription", "str_lmedescription");
                ViewBag.strOrderOption = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Booking Option" && x.isactive == "YES").ToList(), "str_lmedescription", "str_lmedescription");
                ViewData["CompanyName"] = Session["Name"].ToString();
                return View();
            }
            else
            {
                return RedirectToAction("ListOrders");
            }
        }

        [HttpPost]
        public ActionResult OrderBooking(tbl_mst_SpotbookingOrders tbl_mst_SpotbookingOrders,FormCollection frm)
        {
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");

            ViewBag.hidCurrenth = current.Hour;
            ViewBag.hidCurrentm = current.Minute;
            ViewBag.hidCurrents = current.Second;
            ViewBag.dtOrderDate = current.ToShortDateString();

            ViewBag.strProducts = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Product of Interest" && x.dt_StartDate <= current && (x.dt_EndDate >= current || x.dt_EndDate == null)).ToList(), "str_lmedescription", "str_lmedescription");            
            //ViewBag.strProducts = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Product of Interest" && x.isactive == "YES").ToList(), "str_lmedescription", "str_lmedescription");
            ViewBag.strOrderType = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Order Type" && x.isactive == "YES" && x.dt_StartDate <= current && (x.dt_EndDate >= current || x.dt_EndDate == null)).ToList(), "str_lmedescription", "str_lmedescription");
            ViewBag.str_deliveryplace = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Delivery Place" && x.isactive == "YES").ToList(), "str_lmedescription", "str_lmedescription");
            ViewBag.strLiftingOption = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Lifting Option" && x.isactive == "YES").ToList(), "str_lmedescription", "str_lmedescription");
            ViewBag.strOrderOption = new SelectList(objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Booking Option" && x.isactive == "YES").ToList(), "str_lmedescription", "str_lmedescription");
            ViewData["CompanyName"] = Session["Name"].ToString();
            tbl_mst_SpotbookingOrders.strcode = Session["code"].ToString();
            //tbl_mst_SpotbookingOrders.tmRealBookingTime = Convert.ToString(frm["tmRealBookingTimeh"] + ":" + frm["tmRealBookingTimem"] + ":" + frm["tmRealBookingTimes"] +" "+ frm["tmRealBookingTimeampm"]);

            //Regex specialChar = new Regex("^[a-zA-Z ]*$");
            bool blnContainsSpecialCharacters = false;

            //if (!string.IsNullOrEmpty(tbl_mst_SpotbookingOrders.strComments))
            //{
            //    blnContainsSpecialCharacters = specialChar.IsMatch(tbl_mst_SpotbookingOrders.strComments);
            //}

            Regex charecter = new Regex(@"^[0-9]\d{0,9}(\.\d{1,3})?%?$");
            bool blnContainsCharacters = charecter.IsMatch(tbl_mst_SpotbookingOrders.fltBookedQuantity);

            if (blnContainsSpecialCharacters == true)
            {
                ViewBag.Message = string.Format("Special Characters is not allowed in Comments.");
            }
            else
            {
                if (blnContainsCharacters == false)
                {
                    ViewBag.Message = string.Format("Characters is not allowed in Booked Quantity.");
                }
                else
                {
                    string hou = current.Hour.ToString();
                    string min = current.Minute.ToString();
                    string sec = current.Second.ToString();

                    if (frm["tmRealBookingTimeh"] != null)
                    {
                        hou = frm["tmRealBookingTimeh"];
                        if (frm["tmRealBookingTimeampm"] == "PM" && hou!="12")
                        {
                            hou = (Convert.ToInt32(hou) + 12).ToString();
                        }

                    }
                    if (frm["tmRealBookingTimem"] != null)
                    {
                        min = frm["tmRealBookingTimem"];
                    }
                    if (frm["tmRealBookingTimes"] != null)
                    {
                        sec = frm["tmRealBookingTimes"];
                    }

                    string strrealDate = Convert.ToString(frm["dtOrderDate"] + " " + hou + ":" + min + ":" + sec);


                    tbl_mst_SpotbookingOrders.tmRealBookingTime = Convert.ToDateTime(strrealDate);

                    DateTime entrytime = Convert.ToDateTime(tbl_mst_SpotbookingOrders.tmRealBookingTime);
                    tbl_mst_SpotbookingOrders.dtOrderDatetime = current;
                    DateTime dt1 = current.AddMinutes(-30);



                    if (dt1 < entrytime)
                    {
                        if (ModelState.IsValid)
                        {
                            string Id = objSpotbookingOrders.AutoOrderID();
                            tbl_mst_SpotbookingOrders.str_orderid = Id;
                            //tbl_mst_SpotbookingOrders.tmRealBookingTime = Convert.ToDateTime(Utility.ConvertToValidDateString((frm["tmRealBookingTimeh"] + frm["tmRealBookingTimem"] + frm["tmRealBookingTimes"] + frm["tmRealBookingTimeampm"]), EnmDateFormat.DDMMYYYY));
                            //tbl_mst_SpotbookingOrders.tmRealBookingTime = Convert.ToString(frm["tmRealBookingTimeh"] + ":" + frm["tmRealBookingTimem"] + ":" + frm["tmRealBookingTimes"] + frm["tmRealBookingTimeampm"]);
                            tbl_mst_SpotbookingOrders.str_OrderStatus = "Pending";
                            objSpotbookingOrders.tbl_mst_SpotbookingOrders.Add(tbl_mst_SpotbookingOrders);
                            objSpotbookingOrders.SaveChanges();
                            ViewBag.Message = string.Format("Data saved successfully !");
                            ModelState.Clear();
                            var loginuser = objSpotbookingregistrationcontext.SpotbookingRegistrationdetails.Where(a => a.str_code.Equals(tbl_mst_SpotbookingOrders.strcode)).FirstOrDefault();
                            string emailcontent = "Hi,<br> We shall be shortly sending you the confirmation (acceptance / non acceptance)of the following LME Booking received at Hindustan Copper Limited subject to receipt of Security Deposit of 5 % of consignment value (LME CSP Booking) or 5 % of applicable Financial Arrangement (LME Average booking) at the respective HCL Regional Sales Office Finance. <a href='http://hindustancopper.com/Spotbooking/PdfSpotBookingRegistrationPrint?Order='" + tbl_mst_SpotbookingOrders .Pk_intOrderID+ "'>Click hear to show order details</a>";
                            Utility.SendEmail(loginuser.str_email, "Order Creation", emailcontent);
                        }
                    }
                    else
                    {
                        ViewBag.Message = string.Format("Time not be less than 30 min from Current time");
                    }
                }
            }
            ModelState.Clear();
            return View();
        }

        #region Real Value

        [HttpPost]
        public ActionResult Real(string strOrderType)
        {
            var PostMaster = objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmedescription == strOrderType).ToList();
            var isReal = 0;

            if (PostMaster.FirstOrDefault().isreal != "YES")
            {
                PostMaster = objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Booking Option" && x.isreal == "NO" && x.isactive == "YES").ToList();
                
            }
            else
            {
                PostMaster = objLMEdetails.tbl_mst_LMEdetails.Where(x => x.str_lmetype == "Booking Option" && x.isactive == "YES").ToList();
                isReal = 1;
            }


            return Json(new { Post = PostMaster,Real=isReal});

        }

        #endregion

        #region TenderProduct

        [HttpPost]
        public ActionResult TenderProduct(string Products)
        {
            string Quantity = "";
            string ResevedPrice = "";
            string Currency = "";
            var SpotbookingTender = objSpotbookingTenderdetails.vw_SpotbookingTender.Where(x => x.str_lmedescription == Products && x.dt_closingtime>=current).FirstOrDefault();
            if (SpotbookingTender != null)
            {
                Quantity = SpotbookingTender.str_quantity;
                ResevedPrice = SpotbookingTender.str_resevedprice;
                Currency = SpotbookingTender.str_currency;
            }
            return Json(new { Quantity = Quantity, ResevedPrice = ResevedPrice, Currency = Currency });

        }
        #endregion

        #region CurrentTime

        [HttpPost]
        public ActionResult CurrentTime()
        {
            DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
            return Json(new { currenth = current.Hour, currentm = current.Minute, currents = current.Second });

        }
        #endregion


        public ActionResult ListOrders()
        {
            {
                //DateTime data = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                var list = objSpotbookingOrders.tbl_mst_SpotbookingOrders.OrderByDescending(x => x.Pk_intOrderID).ToList();
                var id = Session["code"].ToString();
                if (Session["UserType"].ToString() == "LMECustomer")
                {
                    list = list.Where(x => x.strcode == id).ToList();
                }
                return View(list);
            }
        }

        [HttpPost]
        public ActionResult ListOrders(FormCollection frm)
        {
            //int OrderId = Convert.ToInt32(Session["str_orderid"]);


            if (frm["str_OrderStatus"] == "All")
            {
               
                
                
                var id = Session["code"].ToString();
                var Orders = objSpotbookingOrders.tbl_mst_SpotbookingOrders.Where(x => x.strcode == id).ToList();
                if (frm["dtDate2"] != "" && frm["dtDate1"] != "")
                {
                    var todate = Convert.ToDateTime(frm["dtDate2"].ToString());
                    var fromdate = Convert.ToDateTime(frm["dtDate1"].ToString());
                    Orders = Orders.Where(x => x.dtOrderDate >= fromdate && x.dtOrderDate <= todate).ToList();
                }


                return View(Orders);
            }
            else if (frm["dtDate2"] != "" && frm["dtDate1"] != "" && frm["str_OrderStatus"] == "")
            {
                var todate = Convert.ToDateTime(frm["dtDate2"].ToString());
                var fromdate = Convert.ToDateTime(frm["dtDate1"].ToString());
                var id = Session["code"].ToString();
                var Orders = objSpotbookingOrders.tbl_mst_SpotbookingOrders.Where(x => x.dtOrderDate >= fromdate && x.dtOrderDate <= todate && x.strcode == id).ToList();
                return View(Orders);
            }
            
            else
            {
                var id = Session["code"].ToString();
                var order = frm["str_OrderStatus"];

                var Orders = objSpotbookingOrders.tbl_mst_SpotbookingOrders.Where(x => x.strcode == id && x.str_OrderStatus == order).ToList();

                if (frm["dtDate2"] != "" && frm["dtDate1"] != "")
                {
                    var todate = Convert.ToDateTime(frm["dtDate2"].ToString());
                    var fromdate = Convert.ToDateTime(frm["dtDate1"].ToString());
                    Orders = Orders.Where(x => x.dtOrderDate >= fromdate && x.dtOrderDate <= todate).ToList();
                }


                return View(Orders);
            }

            
           
        }

        public ActionResult EditOrders(int id)
        {
            var Order = objSpotbookingOrders.tbl_mst_SpotbookingOrders.Where(x => x.Pk_intOrderID == id).FirstOrDefault();
            @ViewBag.Id = id;
            return View(Order); 
        }



        public void PdfSpotBookingRegistrationPrint(int Order)
        {
            SpotBookingRegistrationPrint chl = new SpotBookingRegistrationPrint();
          
            chl.Hcllogo = "~/Content/img/logo.png";
            chl.HeadLine1 = "Hindustan Copper Limited ";
            chl.HeadLine2 = "(A Govt. of India Enteprise)";
            chl.HeadLine3 = "Kolkata-700019";
            chl.HeadLine4 = "";
            //chl.HeadLine5 = "Application For Admission To B.A./B.Sc./B.Com. 1st Year";
            chl.HeadLine5 = "";
            chl.Orderid = Order.ToString();
            //chl.HeadLine7 = "Session " + sessionDetails.strSession;
            var mem = chl.CreateChallan();
            byte[] bytesInStream = mem.ToArray();
            Response.Clear();
            Response.ContentType = "application/force-download";
            Response.AddHeader("content-disposition", "attachment;    filename=OrderDetails" + ".pdf");
            Response.BinaryWrite(bytesInStream);
            Response.End();
        }



    }
}


