using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Web;

namespace DataAccessLayer
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class PAttr : Attribute
    {
        public PAttr(string propertyName)
        {
            PropertyName = propertyName;
        }

        public string PropertyName
        {
            get; set;
        }
    }
    public class JustForTest
    {
        //JustForTest ol = new JustForTest();
        //ol.Name = "Peeyush";
        //var dict = CreateDictFromObj(ol, "d");

        [PAttr("r,c,u")] public string Name { get; set; }

        [PAttr("d")] public string AccountName { get; set; }
        public string AAA { get; set; }

    }
    public class PshCommon
    {
        public static clsWithStatus<object> CheckModelValidation(object o, string Mode = "req")
        {
            clsWithStatus<object> response = new clsWithStatus<object>();
            response.data = o;
            Mode = Mode == "required" ? "req" : Mode;
            Dictionary<string, object> _dict = new Dictionary<string, object>();

            System.Reflection.PropertyInfo[] props = o.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                if (prop.Name.ToLower() == "mode" && Convert.ToString(prop.GetValue(o, null)) != "")
                {
                    Mode = Convert.ToString(prop.GetValue(o, null));
                }
                if (prop.GetValue(o, null) != null && prop.GetValue(o, null).GetType().Name == "String")
                {
                    prop.SetValue(o, string.Join(" ", Convert.ToString(prop.GetValue(o, null)).Split(' ').Where(a => !string.IsNullOrEmpty(a))));
                }
            }
            props = o.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                if (attrs.Length > 0)
                {
                    foreach (object attr in attrs)
                    {
                        if (attr.GetType().Name == "PAttr")
                        {
                            string CAttr = ((PAttr)attr).PropertyName;
                            if (CAttr != null && CAttr.Split(',').Where(q => q.ToLower() == Mode.ToLower()).FirstOrDefault() != null)
                            {
                                if (Convert.ToString(prop.GetValue(o, null)) == "")
                                {
                                    response.statuscode = 300;
                                    response.status = "error";
                                    response.msg = prop.Name + " can not be blank.";
                                    break;
                                }
                                else if (prop.Name.ToLower().Contains("email"))
                                {
                                    try
                                    {
                                        MailAddress m = new MailAddress(Convert.ToString(prop.GetValue(o, null)));
                                    }
                                    catch (FormatException)
                                    {
                                        response.statuscode = 300;
                                        response.status = "error";
                                        response.msg = prop.Name + " param has invalid value. Please enter valid email id.";
                                        break;
                                    }
                                }
                            }
                            else if (prop.Name.ToLower().Contains("email") && Convert.ToString(prop.GetValue(o, null)) != "")
                            {
                                try
                                {
                                    MailAddress m = new MailAddress(Convert.ToString(prop.GetValue(o, null)));
                                }
                                catch (FormatException)
                                {
                                    response.statuscode = 300;
                                    response.status = "error";
                                    response.msg = prop.Name + " has invalid emial id value.";
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (Convert.ToString(((System.Attribute)attr).TypeId).ToLower().Contains("stringlengthattribute"))
                            {
                                if (Convert.ToString(prop.GetValue(o, null)).Length < ((System.ComponentModel.DataAnnotations.StringLengthAttribute)attr).MinimumLength)
                                {
                                    response.statuscode = 300;
                                    response.status = "error";
                                    response.msg = prop.Name + " param value length should not be less than " + ((System.ComponentModel.DataAnnotations.StringLengthAttribute)attr).MinimumLength + " characters.";
                                    break;
                                }
                                if (Convert.ToString(prop.GetValue(o, null)).Length > ((System.ComponentModel.DataAnnotations.StringLengthAttribute)attr).MaximumLength)
                                {
                                    response.statuscode = 300;
                                    response.status = "error";
                                    response.msg = prop.Name + " param value length should not be greater than " + ((System.ComponentModel.DataAnnotations.StringLengthAttribute)attr).MaximumLength + " characters.";
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return response;
        }
        public static Dictionary<string, object> CreateDictFromObj(object o, string Mode = "r")
        {
            Dictionary<string, object> _dict = new Dictionary<string, object>();

            System.Reflection.PropertyInfo[] props = o.GetType().GetProperties();
            foreach (System.Reflection.PropertyInfo prop in props)
            {
                object[] attrs = prop.GetCustomAttributes(true);
                if (attrs.Length > 0)
                {
                    bool IsAdd = false;
                    foreach (object attr in attrs)
                    {
                        string CAttr = ((DataAccessLayer.PAttr)attr).PropertyName;
                        if (CAttr != null && IsAdd == false)
                        {
                            IsAdd = CAttr.Split(',').Where(q => q.ToLower() == Mode.ToLower()).FirstOrDefault() != null;
                        }
                        if (IsAdd == true)
                        {
                            break;
                        }
                    }
                    if (IsAdd)
                    {
                        _dict.Add(prop.Name, prop.GetValue(o, null));
                    }
                }
            }

            return _dict;
        }
        public static bool IsNullableType(Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));
        }
        public static List<T> MapDataReaderToList<T>(IDataReader dr)
        {
            List<T> list = new List<T>();
            if (dr.FieldCount == 0)
                return list;
            T obj = default(T);
            if (typeof(T).Name == "String" || typeof(T).Name == "Int32" || typeof(T).Name == "Int64" || typeof(T).Name == "Boolean" || typeof(T).Name == "Decimal" || typeof(T).Name == "Single")
            {
                var columnname = dr.GetName(0);
                Type targetType = IsNullableType(typeof(T)) ? Nullable.GetUnderlyingType(typeof(T)) : typeof(T);
                while (dr.Read())
                {
                    obj = (T)Convert.ChangeType(dr[columnname], targetType);
                    list.Add(obj);
                }
                return list;
            }
            List<string> fieldname = new List<string>();
            for (int i = 0; i < dr.FieldCount; i++) { fieldname.Add(dr.GetName(i)); }
            obj = Activator.CreateInstance<T>();
            List<PropertyInfo> results = obj.GetType().GetProperties().Where(m => fieldname.Any(b => b.ToLower() == m.Name.ToLower())).ToList();
            if (results.Count > 0)
            {
                List<Type> DataTypeList = new List<Type>();
                foreach (PropertyInfo prop in results)
                {
                    var targetType_ = IsNullableType(prop.PropertyType) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType;
                    DataTypeList.Add(targetType_);
                }
                int index = 0;
                while (dr.Read())
                {
                    index = 0;
                    obj = Activator.CreateInstance<T>();
                    foreach (PropertyInfo prop in results)
                    {
                        if (!object.Equals(dr[prop.Name], DBNull.Value))
                        {
                            prop.SetValue(obj, Convert.ChangeType(dr[prop.Name], DataTypeList[index]));
                        }
                        index++;
                    }
                    list.Add(obj);
                }
            }
            return list;
        }
        public DataTable ToDataTable<T>(List<T> items, bool IsColumn = true)
        {
            items = items ?? new List<T>();
            DataTable dataTable = new DataTable(typeof(T).Name);
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            PropertyInfo[] readableProperties = Props.Where(w => w.CanRead).ToArray();
            var columnNames = readableProperties.Select(s => s.Name).ToArray();
            if (IsColumn)
                foreach (PropertyInfo prop in Props)
                {
                    dataTable.Columns.Add(prop.Name);
                }
            foreach (T obj in items)
            {
                if (obj != null)
                    dataTable.Rows.Add(columnNames.Select(s => readableProperties.Single(s2 => s2.Name.Equals(s)).GetValue(obj)).ToArray());
            }
            return dataTable;
        }
        public static clsListWithStatus<T> DynamicSql<T>(string query, Dictionary<string, object> ip = null, Dictionary<string, object> op = null, bool IsSp = true, string connection = "con", int? CommandTimeout = null, bool IsPaging = false)
        {
            clsListWithStatus<T> ob = new clsListWithStatus<T>();
            CommandTimeout = CommandTimeout ?? 120;
            string cons = connection.Length > 50 && connection.ToLower().Contains("password") ? connection : ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cons))
            {
                try
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        if (IsSp)
                            cmd.CommandType = CommandType.StoredProcedure;
                        if (ip != null)
                            foreach (KeyValuePair<string, object> para in ip)
                            {
                                if (para.Value != null && para.Value.GetType().Name.ToLower() == "datatable")
                                    cmd.Parameters.AddWithValue(para.Key, para.Value).SqlDbType = SqlDbType.Structured;
                                else
                                    cmd.Parameters.AddWithValue(para.Key, para.Value);
                            }
                        if (op != null)
                        {
                            foreach (KeyValuePair<string, object> para in op)
                            {
                                cmd.Parameters.Add(para.Key, SqlDbType.NVarChar, 4000).Direction = ParameterDirection.Output;
                            }
                        }
                        cmd.CommandTimeout = Convert.ToInt32(CommandTimeout);
                        if (con.State == ConnectionState.Closed) con.Open();
                        SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                        if (dr.HasRows)
                        {
                            ob.data = MapDataReaderToList<T>(dr);
                        }
                        dr.Close();
                        if (con.State == ConnectionState.Open)
                            con.Close();
                        if (op != null)
                            foreach (KeyValuePair<string, object> para in op)
                            {
                                if (para.Key == "msg" && string.IsNullOrEmpty(ob.msg))
                                {
                                    ob.msg = cmd.Parameters[para.Key].Value.ToString() == "" ? ob.msg : cmd.Parameters[para.Key].Value.ToString();
                                }
                                else if (para.Key.ToLower() == "result")
                                {
                                    long i = 0;
                                    if (Int64.TryParse(cmd.Parameters[para.Key].Value.ToString(), out i) == false)
                                    {
                                        ob.statuscode = 300;
                                        ob.status = "error";
                                        ob.msg = cmd.Parameters[para.Key].Value.ToString();
                                    }
                                    else
                                    {
                                        ob.status = "success";
                                        if (op.Count == 1)
                                            ob.msg = cmd.Parameters[para.Key].Value.ToString();
                                    }
                                }
                            }
                        if (IsPaging == true)
                        {
                            GetPaging(ob);
                        }
                    }
                }
                catch (Exception ex)
                {
                    ob.statuscode = 500;
                    ob.status = "error";
                    ob.msg = ex.Message;
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                        con.Close();
                }
            }
            return ob;
        }
        public static clsListWithPaging<T> GetPaging<T>(clsListWithStatus<T> o)
        {
            clsListWithPaging<T> ob = new clsListWithPaging<T>();
            ob.statuscode = o.statuscode;
            ob.status = o.status;
            ob.msg = o.msg;
            try
            {
                if (ob.statuscode == 200 && ob.status == "success")
                {
                    ob.data = o.data;
                    var arr = ob.msg.Split(';');
                    if (arr.Length > 1)
                    {
                        foreach (var r in arr)
                        {
                            var st = r.Split('=');
                            if (st.Length > 1)
                            {
                                if (st[0].ToLower() == "totalrecord")
                                {
                                    ob.paging.TotalRecord = st[1];
                                }
                                if (st[0].ToLower() == "totalpage")
                                {
                                    ob.paging.TotalPage = st[1];
                                }
                                if (st[0].ToLower() == "pageindex")
                                {
                                    ob.paging.PageIndex = st[1];
                                }
                            }
                        }
                    }
                    if (o.data.Count() == 0)
                    {
                        ob.statuscode = 203;
                        ob.status = "success";
                    }
                    else if (ob.paging.TotalRecord == "0" && o.data.Count > 0)
                    {
                        ob.paging.PageIndex = "1";
                        ob.paging.TotalPage = "1";
                        ob.paging.TotalRecord = o.data.Count.ToString();
                    }
                    o.msg = Convert.ToInt64(ob.paging.TotalRecord).ToString() + " record(s) found!";
                }
            }
            catch
            {

            }
            return ob;
        }
    }
    public class clsListWithPaging<T>
    {
        public clsListWithPaging()
        {
            status = "success";
            statuscode = 200;
            data = new List<T>();
            paging = new clsPaging();
            msg = "";
        }
        public int statuscode { get; set; }
        public string status { get; set; }
        public List<T> data { get; set; }
        public clsPaging paging { get; set; }
        public string msg { get; set; }
    }
    public class clsListWithStatus<T>
    {
        public clsListWithStatus()
        {
            status = "success";
            statuscode = 200;
            data = new List<T>();
            msg = "";
        }
        public int statuscode { get; set; }
        public string status { get; set; }
        public List<T> data { get; set; }
        //public clsPaging paging { get; set; }
        public string msg { get; set; }
    }
    public class clsMyDropdown
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string ItemNumber { get; set; }
        public string CustomerId { get; set; }
        public string Url { get; set; }
    }
    public class clsTextValue
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    public class clsWithStatus<T>
    {
        public clsWithStatus()
        {
            status = "success";
            statuscode = 200;
            msg = "";
        }
        public int statuscode { get; set; }
        public string status { get; set; }
        public T data { get; set; }
        public string msg { get; set; }
    }
    public class clsPaging
    {
        public clsPaging()
        {
            PageIndex = "0"; TotalPage = "0"; TotalRecord = "0";
        }
        public string PageIndex { get; set; }
        public string TotalPage { get; set; }
        public string TotalRecord { get; set; }
    }

}