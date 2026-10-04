using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Data;
using System.Web.Script.Serialization;
using System.Text;
using System.Drawing;
using Image = System.Web.UI.WebControls.Image;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;
using System.Net.Mail;
using System.Collections;
using System.ComponentModel;
using System.Security.Cryptography;

//File extention rename
using System.Runtime.InteropServices;
//File extention rename
namespace Hindustancopperlimited.GlobalClass
{


    public enum EnmDateFormat
    {
        DDMMYYYY,
        MMDDYYYY,
        YYYYMMDD
    }
    public class Utility
    {


        //private static readonly ILog log = LogManager.GetLogger("DFSLogger");
        public static DataSet StaffDataSet;



        public static int[] StringToIntArray(string myNumbers)
        {
            List<int> myIntegers = new List<int>();
            Array.ForEach(myNumbers.Split(",".ToCharArray()), s =>
            {
                int currentInt;
                if (Int32.TryParse(s, out currentInt))
                    myIntegers.Add(currentInt);
            });
            return myIntegers.ToArray();
        }

        public static string checkFileExtention(string ext)
        {
            string valid = "YES";
            ext = ext.ToLower();
            //if (ext == ".aspx" || ext == ".asp" || ext == ".php" || ext == ".jsp" || ext == ".html" || ext == ".exe" || ext == ".htm")
            //{
            //    valid="NO";
            //}
            return valid;
        }

        public static string Encrypt(string clearText)
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


        public static string Decrypt(string cipherText)
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


        public static string GenerateSHA512String(string inputString)
        {
            SHA512 sha512 = SHA512Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(inputString);
            byte[] hash = sha512.ComputeHash(bytes);
            return GetStringFromHash(hash);
        }



        private static string GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        public static string SendMail(string toMail, string subject, string body)
        {

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("srv1.cloudserverzone.com");
            mail.From = new MailAddress("Hindustan Copper Limited");
            mail.To.Add(toMail);
            mail.Subject = subject;

            mail.Body = @"<div id='container'>" +

                                    "<h4 style='margin-bottom: 0;'>" +
                                      "Dear Sir,</h4>" +

                            "<div id='header'  style='text-align: left;' >" +

                                    "<h4 style='margin-bottom: 0;'>" +
                                       "" + body + "</h4>" +

                            "</div>" +

                             "<div id='footer' style='clear: both; text-align: left; padding-top:20px;'>" + " Thanks,</div>" +
                             "<div id='footer' style='clear: both; text-align: left;'><a href='http://hindustancopper.com/'>Hindustan Copper Limited</a><div>" +
                        "<div id='Div1' style='clear: both; text-align: center;'>" +
                        "</div>" +
                         " <img src='http://hindustancopper.com/Content/img/logo2.png'> ";

            mail.IsBodyHtml = true;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("hcl_ho@hindustancopper.com", "welcome1");
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
            return "";
        }


        public static string substring(string value, string value2, int length)
        {

            if (!string.IsNullOrEmpty(value2))
            {
                return value = value2;
            }
            else
            {
                if (!string.IsNullOrEmpty(value) && value.Length > length)
                {
                    value = value.Substring(0, length - 1).Replace(",", "");

                }

                else if (!string.IsNullOrEmpty(value))
                {
                    value = value.Replace(",", "");
                }
            }
            return value;

        }

        public static string RemoveComma(string value)
        {

            if (!string.IsNullOrEmpty(value))
            {
                value = value.Replace(",", "");
            }
            return value;
        }


        public static string addData(string value, string addData)
        {
            string returnvalue = "";
            if (!string.IsNullOrEmpty(value))
            {
                returnvalue = value + addData;
            }
            return returnvalue;
        }



        public static string SendEmailForVendor(string emailId, string subject, string message)
        {

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
                if (cs != "Data Source=DFSSERVER;Initial Catalog=Hindustancopperlimited;User ID=sa;Password=dfs@123")
                {

                    string appUserName = "hcl_ho@hindustancopper.com";
                    var msg = new MailMessage();
                    msg.From = new MailAddress(appUserName);
                    msg.To.Add(new MailAddress(emailId));
                    msg.Subject = subject;

                    msg.Body = @"<div id='container'>" +
                                    "<h4 style='margin-bottom: 0;'>" +
                                      "Dear Sir,</h4>" +

                            "<div id='header'  style='text-align: left;' >" +

                                    "<h4 style='margin-bottom: 0;'>" +
                                       "" + message + "</h4>" +

                            "</div>" +

                             "<div id='footer' style='clear: both; text-align: left; padding-top:20px;'>" + " Thanks,</div>" +
                             "<div id='footer' style='clear: both; text-align: left;'><a href='http://hindustancopper.com/'>Hindustan Copper Limited</a><div>" +
                        "<div id='Div1' style='clear: both; text-align: center;'>" +
                        "</div>" +
                         " <img src='http://hindustancopper.com/Content/img/logo2.png'> ";

                    msg.IsBodyHtml = true;
                    msg.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                    msg.Priority = MailPriority.High;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "127.0.0.1";
                    smtpClient.Send(msg);

                }
            }
            catch
            {
                emailId = "";
            }

            return emailId;

        }

        public static string SendEmailWhidoutAttachment(string emailId, string subject, string message)
        {

            try
            {
                string appHost = "smtp.gmail.com";
                string appUserName = "donotreplykmdaonline@gmail.com";
                string appPwd = "kmdaonline#123";





                MailMessage msg = new MailMessage();
                msg.From = new MailAddress(appUserName);
                msg.Subject = subject;
                msg.Body = message;
                msg.IsBodyHtml = true;

                string[] multi = emailId.Split(',');
                foreach (string multiemailid in multi)
                {
                    msg.To.Add(new MailAddress(multiemailid));
                }

                SmtpClient smtp = new SmtpClient();
                smtp.Host = appHost;
                smtp.EnableSsl = true;

                NetworkCredential network = new NetworkCredential();
                network.UserName = msg.From.Address;
                network.Password = appPwd;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = network;
                smtp.Port = 587;
                smtp.Send(msg);

            }
            catch
            {
                emailId = "";
            }

            return emailId;
        }



        public static string SendEmail(string emailId, string subject, string message)
        {

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
                if (cs != "Data Source=DFSSERVER;Initial Catalog=Hindustancopperlimited;User ID=sa;Password=dfs@123")
                {

                    string appUserName = "hcl_ho@hindustancopper.com";
                    var msg = new MailMessage();
                    msg.From = new MailAddress(appUserName);
                    msg.To.Add(new MailAddress(emailId));
                    msg.Subject = subject;

                    msg.Body = @"<div id='container'>" +

                            "<div id='header'  style='text-align: left;' >"
                                   + message +
                            "</div>" +

                             "<div id='footer' style='clear: both; text-align: left; padding-top:20px;'>" + " Thanks,</div>" +
                             "<div id='footer' style='clear: both; text-align: left;'><a href='http://hindustancopper.com/'>Hindustan Copper Limited</a><div>" +
                        "<div id='Div1' style='clear: both; text-align: center;'>" +
                        "</div>" +
                         " <img src='http://hindustancopper.com/Content/img/logo2.png'> ";

                    msg.IsBodyHtml = true;
                    msg.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                    msg.Priority = MailPriority.High;
                    SmtpClient smtpClient = new SmtpClient();
                    //smtpClient.Host = "127.0.0.1";
                    smtpClient.Host = "hindustancopper.relay.tmes-in.trendmicro.com";
                    smtpClient.Send(msg);
                    //if (emailId == "rahul.giri007@outlook.com")
                    //{
                    //    TestSendEmail("rahul.giri007@outlook.com", subject, "message");
                    //}
                }
            }
            catch
            {
                emailId = "";
            }

            //catch (Exception ex)
            //{
            //    emailId = "";
            //    return ex.Message.ToString();
            //}

            return emailId;

        }




        public static string ConvertToValidDateString(string value, EnmDateFormat dateFormat)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            char[] separators = new char[] { '-', '.', '/' };

            string[] arrValue = value.Trim().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            string returnValue = string.Empty;

            if (arrValue.Length != 3) return string.Empty;

            switch (dateFormat)
            {
                case EnmDateFormat.DDMMYYYY:
                    returnValue = arrValue[2].Trim() + "-" + arrValue[1].Trim().PadLeft(2, '0') + "-" + arrValue[0].Trim().PadLeft(2, '0');
                    break;
                case EnmDateFormat.MMDDYYYY:
                    returnValue = arrValue[2].Trim() + "-" + arrValue[0].Trim().PadLeft(2, '0') + "-" + arrValue[1].Trim().PadLeft(2, '0');
                    break;
                case EnmDateFormat.YYYYMMDD:
                    returnValue = arrValue[0].Trim() + "-" + arrValue[1].Trim().PadLeft(2, '0') + "-" + arrValue[0].Trim().PadLeft(2, '0');
                    break;
            }

            return returnValue;
        }


        public static string ImageToBase64(string _imagePath)
        {
            string _base64String = null;

            using (System.Drawing.Image _image = System.Drawing.Image.FromFile(_imagePath))
            {
                using (MemoryStream _mStream = new MemoryStream())
                {
                    _image.Save(_mStream, _image.RawFormat);
                    byte[] _imageBytes = _mStream.ToArray();
                    _base64String = Convert.ToBase64String(_imageBytes);

                    return "data:image/jpg;base64," + _base64String;
                }
            }
        }

        //File extention rename
        [DllImport(@"urlmon.dll", CharSet = CharSet.Auto)]
        private extern static System.UInt32 FindMimeFromData(
            System.UInt32 pBC,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzUrl,
            [MarshalAs(UnmanagedType.LPArray)] byte[] pBuffer,
            System.UInt32 cbSize,
            [MarshalAs(UnmanagedType.LPStr)] System.String pwzMimeProposed,
            System.UInt32 dwMimeFlags,
            out System.UInt32 ppwzMimeOut,
            System.UInt32 dwReserverd
        );

        public static string getMimeFromFile(string filename)
        {
            //if (!File.Exists(filename))
            //    throw new FileNotFoundException(filename + " not found");

            if (filename == null)
            {
                return "unknown/unknown";
            }

            else
            {
                filename = filename.Replace("~", HttpContext.Current.Server.MapPath("~"));
                byte[] buffer = new byte[256];
                using (FileStream fs = new FileStream(filename, FileMode.Open))
                {
                    if (fs.Length >= 256)
                        fs.Read(buffer, 0, 256);
                    else
                        fs.Read(buffer, 0, (int)fs.Length);
                }
                try
                {
                    System.UInt32 mimetype;
                    FindMimeFromData(0, null, buffer, 256, null, 0, out mimetype, 0);
                    System.IntPtr mimeTypePtr = new IntPtr(mimetype);
                    string mime = Marshal.PtrToStringUni(mimeTypePtr);
                    Marshal.FreeCoTaskMem(mimeTypePtr);
                    if (mime != "application/x-msdownload")
                    {
                        return mime;
                    }
                    else
                    {
                        return "Invalied";
                    }
                }
                catch (Exception e)
                {
                    return "unknown/unknown";
                }
            }
        }



        public static string TestSendEmail(string emailId, string subject, string message)
        {

            try
            {
                string cs = ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
                if (cs != "Data Source=DFSSERVER;Initial Catalog=Hindustancopperlimited;User ID=sa;Password=dfs@123")
                {

                    string appUserName = "hcl_ho@hindustancopper.com";
                    var msg = new MailMessage();
                    msg.From = new MailAddress(appUserName);
                    msg.To.Add(new MailAddress(emailId));
                    msg.CC.Add(new MailAddress("rahul.giri@infoneotech.com"));
                    msg.Subject = subject;

                    msg.Body = @"<div id='container'>" +

                            "<div id='header'  style='text-align: left;' >"
                                   + message +
                            "</div>" +

                             "<div id='footer' style='clear: both; text-align: left; padding-top:20px;'>" + " Thanks,</div>" +
                             "<div id='footer' style='clear: both; text-align: left;'><a href='http://hindustancopper.com/'>Hindustan Copper Limited</a><div>" +
                        "<div id='Div1' style='clear: both; text-align: center;'>" +
                        "</div>" +
                         " <img src='http://hindustancopper.com/Content/img/logo2.png'> ";

                    msg.IsBodyHtml = true;
                    msg.BodyEncoding = System.Text.Encoding.GetEncoding("utf-8");
                    msg.Priority = MailPriority.High;
                    SmtpClient smtpClient = new SmtpClient();
                    smtpClient.Host = "hindustancopper.relay.tmes-in.trendmicro.com";
                    smtpClient.Send(msg);
                    // TestSendEmail("rahul.giri007@outlook.com", subject, message);
                }
            }
            catch
            {
                emailId = "";
            }

            return emailId;

        }






    }
    //File extention rename
    public class AuditableBase : IAuditable
    {
        ArrayList _objArrayListFieldName = new ArrayList();
        public object _oldObject { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<DateTime> CreatedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<DateTime> ModifiedOn { get; set; }
        public string TableNamedfs { get; set; }
        public string TablePKFieldNamedfs { get; set; }
        public string TablePKValuedfs { get; set; }
        public string ClientIpdfs { get; set; }
        public string TransactionTypedfs { get; set; }
        ArrayList _ModifiedFields = new ArrayList();
        public ArrayList ModifiedFields
        {
            get
            {
                return this._ModifiedFields;
            }
            set
            {
                this._ModifiedFields = value;
            }
        }

        public void table_PropertyChanging(object sender, PropertyChangingEventArgs e)
        {
            try
            {
                MethodInfo method = sender.GetType().GetMethod("Clone");
                object objectBeforepropertyChanged = method.Invoke(sender, null);
                sender.GetType().GetProperty("_oldObject").SetValue(sender, objectBeforepropertyChanged, null);
            }
            catch (Exception ex)
            {

            }

        }

        public void table_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {

            try
            {
                object oldObject = sender.GetType().GetProperty("_oldObject").GetValue(sender, null);
                object originalVal = oldObject.GetType().GetProperty(e.PropertyName).GetValue(oldObject, null);
                object newVal = sender.GetType().GetProperty(e.PropertyName).GetValue(sender, null);
                AuditValueObject objAuditValue = new AuditValueObject(e.PropertyName, originalVal, newVal);
                this.ModifiedFields.Add(objAuditValue);
                this.TableNamedfs = sender.GetType().Name;
                if (this.TablePKFieldNamedfs != null)
                {
                    this.TablePKValuedfs = Convert.ToString(sender.GetType().GetProperty(this.TablePKFieldNamedfs).GetValue(sender, null));
                }

            }
            catch (Exception ex)
            {

            }
        }

    }

    internal interface IAuditable
    {
        string CreatedBy { get; set; }
        Nullable<DateTime> CreatedOn { get; set; }
        string ModifiedBy { get; set; }
        Nullable<DateTime> ModifiedOn { get; set; }
        string TableNamedfs { get; set; }
        string TablePKFieldNamedfs { get; set; }
        string TablePKValuedfs { get; set; }
        string ClientIpdfs { get; set; }
        string TransactionTypedfs { get; set; }
        ArrayList ModifiedFields { get; set; }
    }

    public class AuditValueObject
    {
        public string FieldName { get; set; }
        public object OriginalValue { get; set; }
        public object NewValue { get; set; }
        public AuditValueObject()
        {
            this.FieldName = "";
            this.OriginalValue = null;
            this.NewValue = null;
        }
        public AuditValueObject(string FieldName, object OriginalValue, object NewValue)
        {
            this.FieldName = FieldName;
            this.OriginalValue = OriginalValue;
            this.NewValue = NewValue;
        }
    }
    public static class AuditUtility
    {

        private static string GetUserId()
        {
            string userId = "0";
            if (System.Web.HttpContext.Current != null)
                userId = Convert.ToString(System.Web.HttpContext.Current.Session["UserID"]);

            return userId;
        }

        private static void ProcessAuditFields(IList<System.Object> list, bool UpdateCreatedFields)
        {
            foreach (var item in list)
            {
                IAuditable entity = item as IAuditable;
                if (entity != null)
                {
                    entity.ClientIpdfs = HttpContext.Current.Request.UserHostAddress.ToString();
                    entity.TransactionTypedfs = "updated";
                    if (UpdateCreatedFields)
                    {
                        entity.CreatedBy = GetUserId();
                        entity.CreatedOn = DateTime.Now;
                        entity.TransactionTypedfs = "created";
                    }

                    entity.ModifiedBy = GetUserId();
                    entity.ModifiedOn = DateTime.Now;
                    ArrayList updatedFieldList = entity.ModifiedFields;


                    string strAuditValuesXML = "<root>";

                    foreach (AuditValueObject auditValue in updatedFieldList)
                    {
                        strAuditValuesXML = strAuditValuesXML + "<auditvalues>";
                        strAuditValuesXML = strAuditValuesXML + "<strFieldNamedfs><![CDATA[" + auditValue.FieldName + "]]></strFieldNamedfs>";
                        strAuditValuesXML = strAuditValuesXML + "<strOriginalValuedfs><![CDATA[" + Convert.ToString(auditValue.OriginalValue) + "]]></strOriginalValuedfs>";
                        strAuditValuesXML = strAuditValuesXML + "<strNewValuedfs><![CDATA[" + Convert.ToString(auditValue.NewValue) + "]]></strNewValuedfs>";
                        strAuditValuesXML = strAuditValuesXML + "</auditvalues>";

                    }
                    strAuditValuesXML = strAuditValuesXML + "</root>";

                    //DModel.stp_InsertAuditTrail(entity.TableNamedfs, entity.TransactionTypedfs, Convert.ToInt32(entity.ModifiedBy), entity.ClientIpdfs, entity.ModifiedOn, entity.ModifiedOn, entity.TablePKFieldNamedfs, entity.TablePKValuedfs, strAuditValuesXML);


                }
            }
        }

        internal static void ProcessInserts(IList<System.Object> list)
        {
            ProcessAuditFields(list, true);
        }

        internal static void ProcessUpdates(IList<System.Object> list)
        {
            ProcessAuditFields(list, false);
        }

    }

    public class CryptoUtility
    {
        protected string GetMD5Hash(string name)
        {

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] ba = md5.ComputeHash(GetFileBytes(name));
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
        public string Encrypt(string textToEncrypt, string FilePath)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] pwdBytes = GetFileBytes(FilePath);
            byte[] keyBytes = new byte[0x10];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            ICryptoTransform transform = rijndaelCipher.CreateEncryptor();
            byte[] plainText = Encoding.UTF8.GetBytes(textToEncrypt);
            return Convert.ToBase64String(transform.TransformFinalBlock(plainText, 0, plainText.Length));
        }
        public string Decrypt(string textToDecrypt, string FilePath)
        {
            RijndaelManaged rijndaelCipher = new RijndaelManaged();
            rijndaelCipher.Mode = CipherMode.CBC;
            rijndaelCipher.Padding = PaddingMode.PKCS7;
            rijndaelCipher.KeySize = 0x80;
            rijndaelCipher.BlockSize = 0x80;
            byte[] encryptedData = Convert.FromBase64String(textToDecrypt);
            byte[] pwdBytes = GetFileBytes(FilePath);
            byte[] keyBytes = new byte[0x10];
            int len = pwdBytes.Length;
            if (len > keyBytes.Length)
            {
                len = keyBytes.Length;
            }
            Array.Copy(pwdBytes, keyBytes, len);
            rijndaelCipher.Key = keyBytes;
            rijndaelCipher.IV = keyBytes;
            byte[] plainText = rijndaelCipher.CreateDecryptor().TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            return Encoding.UTF8.GetString(plainText);
        }
        Byte[] GetFileBytes(String filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;
                buffer = new byte[length];
                int count;
                int sum = 0;
                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

    }


}
