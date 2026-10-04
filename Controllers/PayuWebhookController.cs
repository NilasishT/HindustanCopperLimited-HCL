using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hindustancopperlimited.Controllers
{
    public class PayuWebhookController : Controller
    {
        //
        // GET: /PayuWebhook/

        [HttpPost]
        [AllowAnonymous]
        public ActionResult PayUWebhook()
        {
            try
            {

                SavePayuTransactionLog(Request.Form);

                return new HttpStatusCodeResult(200);
            }
            catch (Exception ex)
            {

                return new HttpStatusCodeResult(200);
            }
        }


        private void SavePayuTransactionLog(NameValueCollection form)
        {
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString))
                {

                    var cmd = new SqlCommand(@"
                INSERT INTO tbl_transactionlogs
                (strTransactionsId, fkintApplicantId, fk_CandidateRegistrationID,
                 strApplicationNo, decHCLAmount, decPayuAmount, strMihPayId, strMode, strStatus, strError,
                 strPgType, strBankRefNum, strUnmappedstatus, strPayUMoneyId, dtTransactionsDate)
                VALUES
                (@strTransactionsId, @fkintApplicantId, @fk_CandidateRegistrationID,
                 @strApplicationNo, @decHCLAmount, @decPayuAmount, @strMihPayId, @strMode, @strStatus, @strError,
                 @strPgType, @strBankRefNum, @strUnmappedstatus, @strPayUMoneyId, @dtTransactionsDate)", con);

                    // Mapping
                    cmd.Parameters.AddWithValue("@strTransactionsId", form["txnid"] ?? "");
                    cmd.Parameters.AddWithValue("@fkintApplicantId", form["udf2"] ?? (object)DBNull.Value);
                    //cmd.Parameters.AddWithValue("@fk_advertisementid", advertisementId);
                    cmd.Parameters.AddWithValue("@fk_CandidateRegistrationID", form["udf3"] ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@strApplicationNo", form["udf1"] ?? "");

                    // decHCLAmount → DB se lena hoga (aap apni tbl_transactions ya CalculateOnlineFees se nikaal lo)
                    decimal decHCLAmount = 0;
                    if (!string.IsNullOrEmpty(form["amount"]))
                        decimal.TryParse(form["amount"], out decHCLAmount);
                    cmd.Parameters.AddWithValue("@decHCLAmount", decHCLAmount);

                    decimal decPayuAmount = 0;
                    if (!string.IsNullOrEmpty(form["amount"]))
                        decimal.TryParse(form["amount"], out decPayuAmount);
                    cmd.Parameters.AddWithValue("@decPayuAmount", decPayuAmount);

                    cmd.Parameters.AddWithValue("@strMihPayId", form["mihpayid"] ?? "");
                    cmd.Parameters.AddWithValue("@strMode", form["mode"] ?? "");
                    cmd.Parameters.AddWithValue("@strStatus", form["status"] ?? "");
                    cmd.Parameters.AddWithValue("@strError", form["Error"] ?? "");
                    cmd.Parameters.AddWithValue("@strPgType", form["PG_TYPE"] ?? "");
                    cmd.Parameters.AddWithValue("@strBankRefNum", form["bank_ref_num"] ?? "");
                    cmd.Parameters.AddWithValue("@strUnmappedstatus", form["unmappedstatus"] ?? "");
                    cmd.Parameters.AddWithValue("@strPayUMoneyId", form["payuMoneyId"] ?? "");
                    cmd.Parameters.AddWithValue("@dtTransactionsDate", DateTime.UtcNow + TimeSpan.Parse("05:30:00"));

                    //cmd.Parameters.AddWithValue("@UniqueAdvId", UniqueAdvId);


                    if (con.State != ConnectionState.Open)
                        con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Logging error ko ignore karo, payment flow ko block mat karo
            }
        }

    }
}
