using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class Vw_FinancialResult
    {
        [Key]
        public int pk_intFinanceResultId { get; set; }
        public string strFinancialYear { get; set; }
       
        public DateTime? dtmCreatedOn { get; set; }
        public DateTime? dtmUpdatedOn { get; set; }
        public int? intPeriodInMonths { get; set; }
        public int? ParticularId { get; set; }
        public string ParticularDesc { get; set; }
        public string vchPerStatus { get; set; }
        public int? vchHeading { get; set; }
        public string vchProfStatus { get; set; }

        public int intDeletedFlag { get; set; }
        

    }
}