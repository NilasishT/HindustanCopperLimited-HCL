using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_FinancialYear
    {
        [Key]
        public int Pk_int_FinYear { get; set; }
        public string strFinancialYear { get; set; }
        public int? intPeriodInMonths { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public bool? IsActive { get; set; }
    }
}