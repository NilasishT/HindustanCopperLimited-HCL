using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class vw_Addendum
    {

        [Key]
        public int pk_intAddendumId { get; set; }
        public int pk_intTenderId { get; set; }
        public int fk_intUnitId { get; set; }
        public string strEnquiryNo { get; set; }
        public string strEnquiryTitle { get; set; }
        public bool isImportant { get; set; }
        public decimal numCostofTender { get; set; }
        public DateTime? dtEnquiryDate { get; set; }
        public DateTime dtActiveDate { get; set; }
        public DateTime dtClosingDate { get; set; }
        public decimal numEarnestMoney { get; set; }
        public string strTenderType { get; set; }
        public string strBiddersQualification { get; set; }
        public string strBiddingInstruction { get; set; }
        public string strFilePath { get; set; }
        public string strFilePath1 { get; set; }
        public string strFilePath2 { get; set; }
        public string strFilePath3 { get; set; }
        public string strFilePath4 { get; set; }
        public bool IsActive { get; set; }
        public string strFinancialYear { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public string strVendorsId { get; set; }
        public string strSignature { get; set; } 
        public string strFileName { get; set; }
        
    }
}