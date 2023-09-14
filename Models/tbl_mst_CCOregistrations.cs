using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CCOregistrations
    {
        [Key]
        public int Pk_CCOid { get; set; }
        public string str_code { get; set; }
        public string str_fname { get; set; }
        public string str_lname { get; set; }
        public string str_email { get; set; }
        public string str_mobile { get; set; }
        public string str_phone { get; set; }
        public string str_pw { get; set; }
       
    }
}

