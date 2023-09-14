using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class Repository
    {
    }
    public class clsListWithStatus<T>
    {
        public clsListWithStatus()
        {
            statuscode = 200;
            status = "success";
            data = new List<T>();
            msg = "";
        }
        public int statuscode { get; set; }
        public string status { get; set; }
        public List<T> data { get; set; }
        public string msg { get; set; }
    }
    public class clsHomePageBanner
    {
        public string Id { get; set; }
        public string ImageUrl { get; set; }
        public string HindiImageUrl { get; set; }
        public string Title { get; set; }
        public string HindiTitle { get; set; }
        public string IsActive { get; set; }
        public string OrderIndex { get; set; }
    }
    public class tblHomePageBanner : clsHomePageBanner
    {
        public string Mode { get; set; }
        public clsListWithStatus<clsHomePageBanner> GetHomePageBanner(tblHomePageBanner o)
        {
            o = o ?? new tblHomePageBanner();
            clsListWithStatus<clsHomePageBanner> ob = new clsListWithStatus<clsHomePageBanner>();
            ob.data = new List<clsHomePageBanner>();
            string constr = ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.uspHomePageBanner_Get", con))
                {
                    cmd.CommandTimeout = 600;
                    cmd.Parameters.AddWithValue("Id", o.Id);
                    cmd.Parameters.AddWithValue("ImageUrl", o.ImageUrl);
                    cmd.Parameters.AddWithValue("HindiImageUrl", o.HindiImageUrl);
                    cmd.Parameters.AddWithValue("Title", o.Title);
                    cmd.Parameters.AddWithValue("HindiTitle", o.HindiTitle);
                    cmd.Parameters.AddWithValue("IsActive", o.IsActive);
                    cmd.Parameters.AddWithValue("OrderIndex", o.OrderIndex);
                    cmd.Parameters.Add("Result", SqlDbType.NVarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("msg", SqlDbType.NVarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ConnectionState.Closed == con.State)
                    {
                        con.Open();
                    }
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        clsHomePageBanner obj = new clsHomePageBanner();
                        obj.Id = Convert.ToString(dr["Id"]);
                        obj.ImageUrl = Convert.ToString(dr["ImageUrl"]);
                        obj.HindiImageUrl = Convert.ToString(dr["HindiImageUrl"]);
                        obj.Title = Convert.ToString(dr["Title"]);
                        obj.HindiTitle = Convert.ToString(dr["HindiTitle"]);
                        obj.IsActive = Convert.ToString(dr["IsActive"]);
                        obj.OrderIndex = Convert.ToString(dr["OrderIndex"]);
                        ob.data.Add(obj);
                    }
                    dr.Close();
                    if (ConnectionState.Open == con.State)
                    {
                        con.Close();
                    }
                    string res = cmd.Parameters["Result"].Value.ToString();
                    ob.msg = cmd.Parameters["msg"].Value.ToString();
                    long ii = 0;
                    if (Int64.TryParse(res, out ii) == false)
                    {
                        ob.status = "error";
                        ob.statuscode = 300;
                        ob.msg = res;
                    }
                    //ob = PshCommon.GetPaging<clsHomePageBanner>(ob);
                }
            }
            return ob;
        }
        public clsListWithStatus<clsHomePageBanner> ManageHomePageBanner(tblHomePageBanner o)
        {
            o = o ?? new tblHomePageBanner();
            clsListWithStatus<clsHomePageBanner> ob = new clsListWithStatus<clsHomePageBanner>();
            string res = "error";
            string constr = ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.uspHomePageBanner_Manage", con))
                {
                    cmd.CommandTimeout = 600;
                    cmd.Parameters.AddWithValue("Mode", o.Mode);
                    cmd.Parameters.AddWithValue("Id", o.Id);
                    cmd.Parameters.AddWithValue("ImageUrl", o.ImageUrl);
                    cmd.Parameters.AddWithValue("HindiImageUrl", o.HindiImageUrl);
                    cmd.Parameters.AddWithValue("Title", o.Title);
                    cmd.Parameters.AddWithValue("HindiTitle", o.HindiTitle);
                    cmd.Parameters.AddWithValue("IsActive", o.IsActive);
                    cmd.Parameters.AddWithValue("OrderIndex", o.OrderIndex);
                    cmd.Parameters.Add("Result", SqlDbType.NVarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("msg", SqlDbType.NVarChar, 2000).Direction = ParameterDirection.Output;
                    cmd.CommandType = CommandType.StoredProcedure;
                    if (ConnectionState.Closed == con.State)
                    {
                        con.Open();
                    }
                    var i = cmd.ExecuteNonQuery();
                    if (ConnectionState.Open == con.State)
                    {
                        con.Close();
                    }
                    res = cmd.Parameters["Result"].Value.ToString();
                    string msg = cmd.Parameters["msg"].Value.ToString();
                    long ii = 0;
                    if (Int64.TryParse(res, out ii) == false)
                    {
                        ob.status = "error";
                        ob.statuscode = 300;
                        ob.msg = res;
                    }
                }
                return ob;
            }
        }
    }
    //[HttpPost]
    //public JsonResult GetHomePageBanner(tblHomePageBanner o)
    //{
    //    var ob = new tblHomePageBanner().GetHomePageBanner(o);
    //    return Json(ob, JsonRequestBehavior.AllowGet);
    //}
    //[HttpPost]
    //public JsonResult ManageHomePageBanner(tblHomePageBanner o)
    //{
    //   var ob = new tblHomePageBanner().ManageHomePageBanner(o);
    //    return Json(ob, JsonRequestBehavior.AllowGet);
    // }
}