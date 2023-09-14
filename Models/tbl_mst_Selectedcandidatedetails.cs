using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_Selectedcandidatedetails
    {
        [Key]
        public int pk_Selectcandidateid { get; set; }
        public string str_Selecttype { get; set; }
        public string str_Applicationno { get; set; }
      //public string str_Applicantname { get; set; }
        public DateTime? dt_apporovedate { get; set; }
        public string isactive { get; set; }
    }
}


