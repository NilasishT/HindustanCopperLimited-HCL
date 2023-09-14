using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_AnnualReports
    {
        [Key]
        public int pk_intAnnualReport { get; set; }
        public string strHeadline { get; set; }
        public string strReportUpload { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }

        public string strStatus { get; set; }
        public string strHeadline_hindi { get; set; }
        public string strReportUpload_hindi { get; set; }
    }
}
