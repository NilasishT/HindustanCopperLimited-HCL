using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_feedback
    {
        [Key]
        public int Pk_Titleid { get; set; }
        public int Fk_titleid { get; set; }

        public string strtitle_name { get; set; }
        public string strf_name { get; set; }
        public string strm_name { get; set; }
        public string strl_name { get; set; }
        public string str_email { get; set; }

        public string str_ph { get; set; }
        public string str_zipcode { get; set; }
        public string str_city { get; set; }
        public string str_address { get; set; }
        public string str_state { get; set; }
        public string str_country { get; set; }
        public string str_comment { get; set; }
        public string str_cntactp { get; set; }


        public DateTime? dtupdate_date { get; set; }
        public DateTime? dtentrydate { get; set; }
        public bool? isactive { get; set; }

    }
}