using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace Hindustancopperlimited.Models
{
    public class tbl_Quarterly_Report
    {
        [Key]
        public int Pk_ReportId { get; set; }
        public int? QuarterId { get; set; }
        public int? ItemId { get; set; }
        public double? numSalesData { get; set; }
         public int? numYear { get; set; }
        public string txtData {get;set;}
        public DateTime? dtmCreatedOn { get; set; }
        public string vchProfStatus {get; set;}

        
    }
}
