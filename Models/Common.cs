using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Hindustancopperlimited.Models;

namespace Hindustancopperlimited.Models
{
    public class Common
    {
        public List<Vw_Postdesiciplinedetails> GetPostdesiciplinedetails(int Adv_Id)
        {
            Vw_Postdesiciplinedetails obj;
            List<Vw_Postdesiciplinedetails> list = new List<Vw_Postdesiciplinedetails>();
            string constr = ConfigurationManager.ConnectionStrings["HclEntities"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT Pk_Disciplineid ,DisciplineName ,DisciplineDescription ,IsActive ,Pk_criteriaid ,fk_advertisementid ,fk_postid ,fk_diciplineid ,str_gender ,str_caste ,str_pwd ,str_qualification ,dt_entrydate ,dt_updatedate ,str_postCTC ,str_postGrade ,str_postMinage ,str_postMaxage ,strExServicemen ,Pk_Postid ,fk_discipline ,Postname ,str_Grade ,Payscale ,Is_active ,str_ctc ,str_minage ,str_maxage ,dtcompareDate ,Emptitle ,Fk_unitid ,intvacancy ,Empnoticeno FROM dbo.Vw_Postdesiciplinedetails WHERE fk_advertisementid=@Adv_Id", con))
                {
                    cmd.CommandTimeout = 600;
                    cmd.Parameters.AddWithValue("Adv_Id", Adv_Id);
                    if (ConnectionState.Closed == con.State)
                    {
                        con.Open();
                    }
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        obj = new Vw_Postdesiciplinedetails();
                        obj.Pk_Disciplineid = Convert.ToInt32(dr["Pk_Disciplineid"] as int?);
                        obj.DisciplineName = Convert.ToString(dr["DisciplineName"]);
                        obj.DisciplineDescription = Convert.ToString(dr["DisciplineDescription"]);
                        obj.IsActive = (dr["IsActive"] as bool?);
                        obj.Pk_criteriaid = Convert.ToInt32(dr["Pk_criteriaid"]);
                        obj.fk_advertisementid = Convert.ToInt32(dr["fk_advertisementid"]);
                        obj.fk_postid = Convert.ToInt32(dr["fk_postid"]);
                        obj.fk_diciplineid = Convert.ToInt32(dr["fk_diciplineid"]);
                        obj.str_gender = Convert.ToString(dr["str_gender"]);
                        obj.str_caste = Convert.ToString(dr["str_caste"]);
                        obj.str_pwd = Convert.ToString(dr["str_pwd"]);
                        obj.str_qualification = Convert.ToString(dr["str_qualification"]);
                        obj.dt_entrydate = (dr["dt_entrydate"] as DateTime?);
                        obj.dt_updatedate = (dr["dt_updatedate"] as DateTime?);
                        obj.str_postCTC = Convert.ToString(dr["str_postCTC"]);
                        obj.str_postGrade = Convert.ToString(dr["str_postGrade"]);
                        obj.str_postMinage = Convert.ToString(dr["str_postMinage"]);
                        obj.str_postMaxage = Convert.ToString(dr["str_postMaxage"]);
                        obj.strExServicemen = Convert.ToString(dr["strExServicemen"]);
                        obj.Pk_Postid = (dr["Pk_Postid"] as int?);
                        obj.fk_discipline = Convert.ToInt32(dr["fk_discipline"]);
                        obj.Postname = Convert.ToString(dr["Postname"]);
                        obj.str_Grade = Convert.ToString(dr["str_Grade"]);
                        obj.Payscale = Convert.ToString(dr["Payscale"]);
                        obj.Is_active = Convert.ToString(dr["Is_active"]);
                        obj.str_ctc = Convert.ToString(dr["str_ctc"]);
                        obj.str_minage = Convert.ToString(dr["str_minage"]);
                        obj.str_maxage = Convert.ToString(dr["str_maxage"]);
                        obj.dtcompareDate = (dr["dtcompareDate"] as DateTime?);
                        obj.Emptitle = Convert.ToString(dr["Emptitle"]);
                        obj.Fk_unitid = (dr["Fk_unitid"] as int?);
                        obj.intvacancy = (dr["intvacancy"] as int?);
                        obj.Empnoticeno = Convert.ToString(dr["Empnoticeno"]);
                        list.Add(obj);
                    }
                    dr.Close();
                    if (ConnectionState.Open == con.State)
                    {
                        con.Close();
                    }
                }
            }
            return list;
        }


        //    var id = 1;
        //    var query = database.Posts    // your starting point - table in the "from" statement
        //       .Join(database.Post_Metas, // the source table of the inner join
        //          post => post.ID,        // Select the primary key (the first part of the "on" clause in an sql "join" statement)
        //          meta => meta.Post_ID,   // Select the foreign key (the second part of the "on" clause)
        //          (post, meta) => new { Post = post, Meta = meta }) // selection
        //       .Where(postAndMeta => postAndMeta.Post.ID == id);
    }
}