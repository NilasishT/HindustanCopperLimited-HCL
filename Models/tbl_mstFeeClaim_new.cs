using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstFeeClaim_new
    {
        [Key]
        public int pk_intFeeClaimId { get; set; }        
        
        public int? fk_intCandidateId { get; set; }
        public string strApplicationNo { get; set; }

        public string strType { get; set; }
        public string strExternalRefNo { get; set; }
        public int? intDebitAccountNumber { get; set; }
        public decimal? decAmount { get; set; }       
        public string strBeneName { get; set; }
        public string strBeneficiaryBankName { get; set; }
        public string strAdress1 { get; set; }
        public string strAdress2 { get; set; }
        public string strAdress3 { get; set; }
        public string strBeneAccountNumber { get; set; }
        [Required]
      
        public string strIFSCCode { get; set; }
        public string strPurpose1 { get; set; }
        public string strPurpose2 { get; set; }
        public string strPurpose3 { get; set; }
        public string strDepartmentCode { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public string strApplicantName { get; set; }
        public string strEmail { get; set; }
        public string strMobileNo { get; set; }

    }
}