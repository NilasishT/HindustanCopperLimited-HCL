using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_PriceCircular
    {
        [Key]
        public int pk_intPriceCircular { get; set; }
        public string strHeadline { get; set; }
        public string strReportUpload { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public string strStatus { get; set; }
        public string strHeadline_hindi { get; set; }
        public string strReportupload_hindi { get; set; }

    }
}

