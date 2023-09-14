using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_Candidateapprovedetails
    {
        [Key]
        public int pk_Approveid { get; set; }
        public string str_approvetype { get; set; }
        public string str_Applicationno { get; set; }
        public string str_Applicantname { get; set; }
        public DateTime? dt_apporovedate { get; set; }
        public string isactive { get; set; }
    }
}


