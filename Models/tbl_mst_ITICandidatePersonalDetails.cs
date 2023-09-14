using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_ITICandidatePersonalDetails
    {
        [Key]
        public int Pk_int_CandidateRegistrationID { get; set; }
        public int? fk_CandidateId { get; set; }
        [Required]
        
        public string strApplicantName { get; set; }
        [Required]
        public DateTime? dtDOB { get; set; }
        
        public string strFatherName { get; set; }
        [Required]
        
        public string strEmail { get; set; }
        [Required]
        
        public string strNationality { get; set; }
        [Required]
        
        public string strGender { get; set; }
        [Required]
        
        public string strCategory { get; set; }
        [Required]
        
        public string strMaritalStatus { get; set; }
        [Required]
        
        public string strPWD { get; set; }

        [Required]
        
        public string strCorrespondenceAddress { get; set; }
        [Required]
        
        public string strState { get; set; }
        [Required]
        
        public string strDistrict { get; set; }
        
        public string strNearestPostOffice { get; set; }
        
        public string strNearestPoliceStation { get; set; }
        [Required]
        
        public string strNearestRailwaystation { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Invalid")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string strPin { get; set; }
        [MinLengthOrNull(11)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string strTelephone { get; set; }
        [MinLengthOrNull(10)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string strMobileNo { get; set; }
        [Required]
        
        public string strPermanentAddress { get; set; }
        [Required]
        
        public string strPermanentState { get; set; }
        [Required]
        
        public string strPermanentDistrict { get; set; }
        
        public string strPermanentNearestPostOffice { get; set; }
        
        public string strPermanentNearestPoliceStation { get; set; }
        [Required]
        
        public string strPermanentNearestRailwayStation { get; set; }
        [Required]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Invalid")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string strPermanentPinCode { get; set; }
        [MinLengthOrNull(11)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string strPermanentTelephoneNo { get; set; }
        [MinLengthOrNull(10)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string strPermanentMobile1 { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public bool? isactive { get; set; }



        [RequiredIfNot("strCategory", "General", "")]
        
        public string strsubcaste { get; set; }
        [RequiredIfNot("strCategory", "General", "")]
        
        public string strcertificateno { get; set; }
        [RequiredIfNot("strCategory", "General", "")]        
        public DateTime? dt_certificateissuedate { get; set; }
        [RequiredIfNot("strCategory", "General", "")]
        
        public string strcertificateissue { get; set; }

        [RequiredIf("strPWD", "Yes", "")]
        
        public string strtypeofdisable { get; set; }
        [RequiredIf("strPWD", "Yes", "")]
        
        public string strcertificateno1 { get; set; }
        [RequiredIf("strPWD", "Yes", "")]
        public DateTime? dt_certificateissuedate1 { get; set; }
        [RequiredIf("strPWD", "Yes", "")]
        
        public string strcertificateissue1 { get; set; }

        
        public string strMotherName { get; set; }
        
        public string strSpouseName { get; set; }
        
        public string strAlternate_EmaiID { get; set; }
        [MinLengthOrNull(10)]
        
        public string strPANNo { get; set; }
        [MinLengthOrNull(12)]
        [RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid Number")]
        public string strAadharNo { get; set; }
        //Akshat Changes
        [Required]
       // [StringLength(13, MinimumLength = 10, ErrorMessage = "Invalid")]
        public string strApprenticeshipRegNo { get; set; }

        public string strFinalSubmit { get; set; }
        public DateTime? dtFinalSubmitDate { get; set; }

        
    }


  
}