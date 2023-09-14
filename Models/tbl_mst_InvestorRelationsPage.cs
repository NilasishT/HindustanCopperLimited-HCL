using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_InvestorRelationsPage
    {
        [Key]
        public int pk_int_InvestorRelationsID { get; set; }
        public string strEnglishText { get; set; }
        public string strHindiText { get;set; }

        public string strHindiFileUpload { get; set; }
        public string strEnglishFileUpload { get; set; }
        public string strPageType { get; set; }
        public string strSubhead { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }

        public bool? isActive { get; set; }

    }
}

      
      
      
      
      