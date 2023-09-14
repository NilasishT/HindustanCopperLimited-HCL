using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_FinancialResults
    {
        [Key]
        public int pk_intFinanceResultId { get; set; }
        public string vchPerStatus { get; set; }

         public int? Fk_intPerticular { get; set; }
         public int? Fk_intYearId { get; set; }
         public int? vchHeading { get; set; }
         public DateTime? dtmCreatedOn { get; set; }
         public DateTime? dtmUpdatedOn { get; set; }
         public string vchProfStatus { get; set; }
         public int? intDeletedFlag { get; set; }


    }
}



