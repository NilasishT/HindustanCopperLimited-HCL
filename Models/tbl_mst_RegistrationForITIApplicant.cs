using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseGeneratedAttribute = System.ComponentModel.DataAnnotations.DatabaseGeneratedAttribute;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_RegistrationForITIApplicant : DbContext
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
        [MinLengthOrNull(10)]
        
        public string strPANNo { get; set; }
        [MinLengthOrNull(12)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string strAadharNo { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Invalid")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string strMobileNumber { get; set; }
        public string IsActive { get; set; }
    }
}