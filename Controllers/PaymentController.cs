using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using Hindustancopperlimited.Models;
using System.Configuration;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using System.Data.Entity;

namespace Hindustancopperlimited.Controllers
{
    public class PaymentController : Controller
    {
        DateTime current = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
        Vw_Applicationdetailscontext objcanpersonaldetails = new Vw_Applicationdetailscontext();
        tbl_mst_candidatephotouploadcontext photosig = new tbl_mst_candidatephotouploadcontext();
        public string action1 = string.Empty;
        public string hash1 = string.Empty;
        public string txnid1 = string.Empty;
        //
        // GET: /Payment/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult PayOnline(string AppNo)
        {
            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            if (CandiadateId == 0)
            {
                return RedirectToAction("CandidateLogin", "RecruitmentCareer");
            }

            if (current >= Convert.ToDateTime("14/10/2018"))
            {
                return RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
            }

            var details = objcanpersonaldetails.Vw_Applicationdetails.Where(x => x.strApplicationNo == AppNo).FirstOrDefault();
            //var detailsPhotoSignature = photosig.tbl_mst_candidatephotoupload.Where(x => x.str_applicationno == AppNo).FirstOrDefault();

            //if (detailsPhotoSignature != null)

            var getViewDetail = photosig.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo).ToList();
            var getViewDetailOnlyPhoto = photosig.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo && !string.IsNullOrEmpty(a.str_uploadphoto)).ToList();
            var getViewDetailOnlySignature = photosig.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo && !string.IsNullOrEmpty(a.str_uploadsignature)).ToList();



            if (getViewDetail.Count != 0 && getViewDetailOnlyPhoto.Count != 0 && getViewDetailOnlySignature.Count != 0)
            {
                ViewBag.date = current;


                if (details.strPWD == "Yes" || details.strInternalCandidate == "Yes")
                {
                    ViewBag.amount = "0.00";
                    return RedirectToAction("applicantDashboard", "RecruitmentCareer");
                }
                else
                {
                    if (details.strCategory == "SC" || details.strCategory == "ST")
                    {
                        ViewBag.amount = "500.00";
                    }
                    else
                    {
                        ViewBag.amount = "1000.00";
                    }
                }

                return View(details);
            }
            else
            {
                //return RedirectToAction("CandidatePersonalDetails", "RecruitmentCareer");
                return RedirectToAction("UploadPhotoSignature", "RecruitmentCareer", new { AppNo = AppNo });
            }
        }

        [HttpPost]
        public void PayOnline(string AppNo, FormCollection frm)
        {
            int CandiadateId = Convert.ToInt32(Session["UserID"]);
            if (CandiadateId == 0)
            {
                RedirectToAction("CandidateLogin", "RecruitmentCareer");
            }

            if (current >= Convert.ToDateTime("14/10/2018"))
            {
                RedirectToAction("ApplicantDashboard", "RecruitmentCareer");
            }

            var details = objcanpersonaldetails.Vw_Applicationdetails.Where(x => x.strApplicationNo == AppNo).FirstOrDefault();

            var getViewDetail = photosig.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo).ToList();
            var getViewDetailOnlyPhoto = photosig.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo && !string.IsNullOrEmpty(a.str_uploadphoto)).ToList();
            var getViewDetailOnlySignature = photosig.tbl_mst_candidatephotoupload.Where(a => a.str_applicationno == AppNo && !string.IsNullOrEmpty(a.str_uploadsignature)).ToList();

            if (getViewDetail.Count != 0 && getViewDetailOnlyPhoto.Count != 0 && getViewDetailOnlySignature.Count != 0)
            {
                ViewBag.date = current;
                string feeamount = "0.0";
                if (details.strPWD == "Yes" || details.strInternalCandidate == "Yes")
                {
                    ViewBag.amount = "0.00";
                    feeamount = "0";
                }
                else
                {
                    if (details.strCategory == "SC" || details.strCategory == "ST")
                    {
                        ViewBag.amount = "500.00";
                        feeamount = "500";
                    }
                    else
                    {
                        ViewBag.amount = "1000.00";
                        feeamount = "1000";
                    }
                }

                string firstName = details.strApplicantName;
                string amount = feeamount;
                string productInfo = "Application Fee";
                string email = details.strEmail;
                string phone = details.strMobileNo;
                string surl = ConfigurationManager.AppSettings["surl"];
                string furl = ConfigurationManager.AppSettings["furl"];

                string udf1 = details.strApplicationNo;
                string udf2 = details.fk_CandidateId.ToString();
                string udf3 = details.Pk_int_CandidateRegistrationID.ToString();
                string udf4 = details.dtDOB.ToString();
                string udf5 = details.strCategory.ToString();

                RemotePost myremotepost = new RemotePost();
                string key = ConfigurationManager.AppSettings["MERCHANT_KEY"];
                string salt = ConfigurationManager.AppSettings["SALT"];

                myremotepost.Url = ConfigurationManager.AppSettings["PAYU_BASE_URL"];

                myremotepost.Add("key", key);
                string txnid = Generatetxnid();
                myremotepost.Add("txnid", txnid);
                myremotepost.Add("amount", amount);
                myremotepost.Add("productinfo", productInfo);
                myremotepost.Add("firstname", firstName);
                myremotepost.Add("phone", phone);
                myremotepost.Add("email", email);

                myremotepost.Add("udf1", udf1);
                myremotepost.Add("udf2", udf2);
                myremotepost.Add("udf3", udf3);
                myremotepost.Add("udf4", udf4);
                myremotepost.Add("udf5", udf5);

                myremotepost.Add("surl", surl);//Change the success url here depending upon the port number of your local system.
                myremotepost.Add("furl", furl);//Change the failure url here depending upon the port number of your local system.

                myremotepost.Add("service_provider", "payu_paisa");

                string hashString = key + "|" + txnid + "|" + amount + "|" + productInfo + "|" + firstName + "|" + email + "|" + udf1 + "|" + udf2 + "|" + udf3 + "|" + udf4 + "|" + udf5 + "||||||" + salt;

               
                tbl_transactions objtransactions = new tbl_transactions();
                objtransactions.strTransactionsId = txnid;
                objtransactions.fkintApplicantId = details.fk_CandidateId;
                objtransactions.fk_advertisementid = details.fk_advertisementid;
                objtransactions.fk_CandidateRegistrationID = details.Pk_int_CandidateRegistrationID;
                objtransactions.strApplicationNo = details.strApplicationNo;
                objtransactions.decHCLAmount = Convert.ToDecimal(feeamount);
                objtransactions.dtTransactionsDate = current;
                objcanpersonaldetails.tbl_transactions.Add(objtransactions);
                objcanpersonaldetails.SaveChanges();

                string hash = Generatehash512(hashString);
                myremotepost.Add("hash", hash);
                myremotepost.Post();
            }
            else
            {
                RedirectToAction("UploadPhotoSignature", "RecruitmentCareer", new { AppNo = AppNo });
            }

        }
        public ActionResult Success()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Success(FormCollection form)
        {
            try
            {

                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;
                string order_id = string.Empty;

                string amount = string.Empty;
                string mihpayid = string.Empty;
                string mode = string.Empty;
                string status = string.Empty;
                string key = string.Empty;
                string Error = string.Empty;
                string PG_TYPE = string.Empty;
                string bank_ref_num = string.Empty;
                string unmappedstatus = string.Empty;
                string payuMoneyId = string.Empty;

                string hash_seq = ConfigurationManager.AppSettings["hashSequence"];



                if (form["status"].ToString() == "success")
                {

                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    merc_hash_string = Request.Form["txnid"] + "|" + ConfigurationManager.AppSettings["SALT"] + "|" + form["status"].ToString();
                    // merc_hash_string = Request.Form["additionalCharges"]+"|"+ConfigurationManager.AppSettings["SALT"] + "|" + Request.Form["status"];

                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");

                    }
                    //Response.Write(merc_hash_string);
                    merc_hash = Generatehash512(merc_hash_string).ToLower();


                    order_id = Request.Form["txnid"];
                    amount = Request.Form["amount"];
                    mihpayid = Request.Form["mihpayid"];
                    mode = Request.Form["mode"];
                    status = Request.Form["status"];
                    key = Request.Form["key"];
                    Error = Request.Form["Error"];
                    PG_TYPE = Request.Form["PG_TYPE"];
                    bank_ref_num = Request.Form["bank_ref_num"];
                    unmappedstatus = Request.Form["unmappedstatus"];
                    payuMoneyId = Request.Form["payuMoneyId"];

                    var objtransactions = objcanpersonaldetails.tbl_transactions.Where(t => t.strTransactionsId == order_id).FirstOrDefault();

                    var PostDetails = objcanpersonaldetails.Vw_Applicationdetails.Where(t => t.strApplicationNo == objtransactions.strApplicationNo).FirstOrDefault();





                    //objtransactions.decPayuAmount = Convert.ToDecimal(amount);
                    //objtransactions.strMihPayId = mihpayid;
                    //objtransactions.strMode = mode;
                    //objtransactions.strStatus = status;
                    //objtransactions.strError = Error;
                    //objtransactions.strPgType = PG_TYPE;
                    //objtransactions.strBankRefNum = bank_ref_num;
                    //objtransactions.strUnmappedstatus = unmappedstatus;
                    //objtransactions.strPayUMoneyId = payuMoneyId;
                    //DateTime date = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    //objtransactions.dtTransactionsDate = date;
                    //objcanpersonaldetails.Entry(objtransactions).State = EntityState.Modified;
                    //objcanpersonaldetails.SaveChanges();


                    ViewBag.Applicant = Request.Form["firstname"];
                    ViewBag.TranId = Request.Form["txnid"];
                    ViewBag.date = objtransactions.dtTransactionsDate;
                    ViewBag.amount = amount;
                    ViewBag.RefNo = bank_ref_num;
                    ViewBag.mode = mode;
                    ViewBag.post = PostDetails.Postname + " ( " + PostDetails.DisciplineName + " ) ";



                    // Acknowledgement Data
                    //var dateAck = PostDetails.dt_entrydate.Value.ToString("ddMMyy");
                    //using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString))
                    //{
                    //    SqlParameter outPar1 = new SqlParameter("@newacknowledgementNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };
                    //    SqlParameter outPar2 = new SqlParameter("@newNoticeNo", SqlDbType.VarChar, 50) { Direction = ParameterDirection.Output };

                    //    var cmd = new SqlCommand("sp_AcknowledgementReport", con);
                    //    cmd.CommandType = CommandType.StoredProcedure;
                    //    cmd.Parameters.Add(new SqlParameter("@unitId", SqlDbType.Int)).Value = PostDetails.Fk_unitid;//Pass the parameter
                    //    cmd.Parameters.Add(new SqlParameter("@postId", SqlDbType.Int)).Value = PostDetails.fk_postid;//Pass the parameter
                    //    cmd.Parameters.Add(new SqlParameter("@disciplineId", SqlDbType.Int)).Value = PostDetails.fk_diciplineid;
                    //    cmd.Parameters.Add(new SqlParameter("@candidateId", SqlDbType.Int)).Value = PostDetails.fk_CandidateId;//Pass the parameter
                    //    cmd.Parameters.Add(new SqlParameter("@noticeId", SqlDbType.Int)).Value = PostDetails.fk_advertisementid;//Pass the parameter
                    //    cmd.Parameters.Add(new SqlParameter("@date", SqlDbType.VarChar)).Value = dateAck;//Pass the parameter
                    //    cmd.Parameters.Add(outPar1);
                    //    cmd.Parameters.Add(outPar2);

                    //    try
                    //    {

                    //        if (con.State != ConnectionState.Open)
                    //            con.Open();
                    //        cmd.ExecuteNonQuery();
                    //        ViewBag.acknowledgementNo = cmd.Parameters["@newacknowledgementNo"].Value.ToString();
                    //        ViewBag.noticeNo = cmd.Parameters["@newNoticeNo"].Value.ToString();
                    //    }
                    //    finally
                    //    {

                    //        if (con.State != ConnectionState.Closed)
                    //            con.Close();
                    //    }

                    //}

                    //// End Acknowledgement Data

                }



            }

            catch (Exception ex)
            {

                Response.Write(ex);
            }


            return View();

        }


        [HttpPost]
        public void Return(FormCollection form)
        {
            try
            {

                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;
                string order_id = string.Empty;
                string hash_seq = "key|txnid|amount|productinfo|firstname|email|udf1|udf2|udf3|udf4|udf5|udf6|udf7|udf8|udf9|udf10";

                if (form["status"].ToString() == "success")
                {

                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    // merc_hash_string = ConfigurationManager.AppSettings["SALT"] + "|" + form["status"].ToString();
                    if (!string.IsNullOrEmpty(Request.Form["additionalCharges"]))
                    {
                        merc_hash_string = Request.Form["additionalCharges"] + "|";
                    }
                    merc_hash_string += ConfigurationManager.AppSettings["SALT"] + "|" + Request.Form["status"];

                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");

                    }
                    Response.Write(merc_hash_string);
                    merc_hash = Generatehash512(merc_hash_string).ToLower();



                    if (merc_hash != form["hash"])
                    {
                        Response.Write("Our Hash: " + merc_hash);
                        Response.Write("Response Hash: " + form["hash"]);
                        Response.Write("Hash value did not matched");

                    }
                    else
                    {
                        order_id = Request.Form["txnid"];

                        ViewData["Message"] = "Status is successful. Hash value is matched";
                        Response.Write("<br/>Hash value matched");

                        //Hash value did not matched
                    }

                }

                else
                {

                    Response.Write("Hash value did not matched");
                    // osc_redirect(osc_href_link(FILENAME_CHECKOUT, 'payment' , 'SSL', null, null,true));

                }
            }

            catch (Exception ex)
            {
                Response.Write("<span style='color:red'>" + ex.Message + "</span>");

            }


        }

        public ActionResult Failed()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Failed(FormCollection form)
        {
            try
            {

                string[] merc_hash_vars_seq;
                string merc_hash_string = string.Empty;
                string merc_hash = string.Empty;
                string order_id = string.Empty;
                string amount = string.Empty;
                string mihpayid = string.Empty;
                string mode = string.Empty;
                string status = string.Empty;
                string key = string.Empty;
                string Error = string.Empty;
                string PG_TYPE = string.Empty;
                string bank_ref_num = string.Empty;
                string unmappedstatus = string.Empty;
                string payuMoneyId = string.Empty;

                string hash_seq = ConfigurationManager.AppSettings["hashSequence"];

                if (form["status"].ToString() != "success")
                {

                    merc_hash_vars_seq = hash_seq.Split('|');
                    Array.Reverse(merc_hash_vars_seq);
                    merc_hash_string = ConfigurationManager.AppSettings["SALT"] + "|" + form["status"].ToString();


                    foreach (string merc_hash_var in merc_hash_vars_seq)
                    {
                        merc_hash_string += "|";
                        merc_hash_string = merc_hash_string + (form[merc_hash_var] != null ? form[merc_hash_var] : "");

                    }
                    Response.Write(merc_hash_string);
                    merc_hash = Generatehash512(merc_hash_string).ToLower();




                    order_id = Request.Form["txnid"];
                    amount = Request.Form["amount"];
                    mihpayid = Request.Form["mihpayid"];
                    mode = Request.Form["mode"];
                    status = Request.Form["status"];
                    key = Request.Form["key"];
                    Error = Request.Form["Error"];
                    PG_TYPE = Request.Form["PG_TYPE"];
                    bank_ref_num = Request.Form["bank_ref_num"];
                    unmappedstatus = Request.Form["unmappedstatus"];
                    payuMoneyId = Request.Form["payuMoneyId"];


                    var objtransactions = objcanpersonaldetails.tbl_transactions.Where(t => t.strTransactionsId == order_id).FirstOrDefault();
                    objtransactions.decPayuAmount = Convert.ToDecimal(amount);
                    objtransactions.strMihPayId = mihpayid;
                    objtransactions.strMode = mode;
                    objtransactions.strStatus = status;
                    objtransactions.strError = Error;
                    objtransactions.strPgType = PG_TYPE;
                    objtransactions.strBankRefNum = bank_ref_num;
                    objtransactions.strUnmappedstatus = unmappedstatus;
                    objtransactions.strPayUMoneyId = payuMoneyId;
                    DateTime date = DateTime.UtcNow + TimeSpan.Parse("05:30:00");
                    objtransactions.dtTransactionsDate = date;
                    objcanpersonaldetails.Entry(objtransactions).State = EntityState.Modified;
                    objcanpersonaldetails.SaveChanges();
                    ViewData["Message"] = "Status is successful. Hash value is matched";

                    ViewBag.Applicant = Request.Form["firstname"];
                    ViewBag.TranId = Request.Form["txnid"];
                    ViewBag.date = objtransactions.dtTransactionsDate;

                    //Response.Write("<br/>Hash value matched");

                    //Hash value did not matched


                }

                else
                {

                    Response.Write("Hash value did not matched");
                    // osc_redirect(osc_href_link(FILENAME_CHECKOUT, 'payment' , 'SSL', null, null,true));

                }
                ViewBag.status = status;

            }

            catch (Exception ex)
            {
                Response.Write("<span style='color:red'>" + ex.Message + "</span>");

            }

            return View();
        }

        public class RemotePost
        {
            private System.Collections.Specialized.NameValueCollection Inputs = new System.Collections.Specialized.NameValueCollection();


            public string Url = "";
            public string Method = "post";
            public string FormName = "form1";

            public void Add(string name, string value)
            {
                Inputs.Add(name, value);
            }

            public void Post()
            {
                System.Web.HttpContext.Current.Response.Clear();

                System.Web.HttpContext.Current.Response.Write("<html><head>");

                System.Web.HttpContext.Current.Response.Write(string.Format("</head><body onload=\"document.{0}.submit()\">", FormName));
                System.Web.HttpContext.Current.Response.Write(string.Format("<form name=\"{0}\" method=\"{1}\" action=\"{2}\" >", FormName, Method, Url));
                for (int i = 0; i < Inputs.Keys.Count; i++)
                {
                    System.Web.HttpContext.Current.Response.Write(string.Format("<input name=\"{0}\" type=\"hidden\" value=\"{1}\">", Inputs.Keys[i], Inputs[Inputs.Keys[i]]));
                }
                System.Web.HttpContext.Current.Response.Write("</form>");
                System.Web.HttpContext.Current.Response.Write("</body></html>");

                System.Web.HttpContext.Current.Response.End();
            }
        }

        //Hash generation Algorithm

        public string Generatehash512(string text)
        {

            byte[] message = Encoding.UTF8.GetBytes(text);

            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] hashValue;
            SHA512Managed hashString = new SHA512Managed();
            string hex = "";
            hashValue = hashString.ComputeHash(message);
            foreach (byte x in hashValue)
            {
                hex += String.Format("{0:x2}", x);
            }
            return hex;

        }


        public string Generatetxnid()
        {

            Random rnd = new Random();
            string strHash = Generatehash512(rnd.ToString() + DateTime.Now);
            string txnid1 = strHash.ToString().Substring(0, 20);

            return txnid1;
        }
    }
}