using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_mst_LMEdetails
    {
        [Key]
        public int pk_lmeusermaster { get; set; }
        public string str_lmedescription { get; set; }
        public string str_lmetype { get; set; }
        public string isactive { get; set; }
        public string isreal { get; set; }
        public DateTime? dt_StartDate { get; set; }
        public DateTime? dt_EndDate { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }
    }
}


