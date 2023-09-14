using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CandidateRegistrationForRecruitment
    {
        [Key]
        public int Candidate_Pk_intID { get; set; }
        public string strCandidateLName { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public string Candidate_Code { get; set; }
        public string strCandidateMName { get; set; }
        [Required]
        public string strCandidateFName { get; set; }
        [Required]
        public DateTime? dtDOB { get; set; }
        [Required]
        public string strEmail { get; set; }
        public string strUserName { get; set; }
        public string strpassword { get; set; }
        public DateTime? dtRegistrationDate { get; set; }
        public DateTime? dtValidateUpto { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public string Is1stTime { get; set; }
        public string strFatherName { get; set; }
        public string strMotherName { get; set; }
        public string strSpouseName { get; set; }
        public string strAlternate_EmaiID { get; set; }
        public string strPANNo { get; set; }
        public string strAadharNo { get; set; }
        [Required]
        public string strMobileNumber { get; set; }
        public string IsActive { get; set; }  
    }

    
}