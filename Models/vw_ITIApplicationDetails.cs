using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_ITIApplicationDetails
    {
        [Key]
        public int Pk_int_CandidateRegistrationID { get; set; }
        public int? fk_CandidateId { get; set; }
        public string strApplicantName { get; set; }
        public DateTime? dtDOB { get; set; }
        public string strFatherName { get; set; }
        public string strEmail { get; set; }
        public string strNationality { get; set; }
        public string strGender { get; set; }
        public string strCategory { get; set; }
        public string strMaritalStatus { get; set; }
        public string strPWD { get; set; }
        public string strCorrespondenceAddress { get; set; }
        public string strState { get; set; }
        public string strDistrict { get; set; }
        public string strNearestPostOffice { get; set; }
        public string strNearestPoliceStation { get; set; }
        public string strNearestRailwaystation { get; set; }
        public string strPin { get; set; }
        public string strTelephone { get; set; }
        public string strMobileNo { get; set; }
        public string strPermanentAddress { get; set; }
        public string strPermanentState { get; set; }
        public string strPermanentDistrict { get; set; }
        public string strPermanentNearestPostOffice { get; set; }
        public string strPermanentNearestPoliceStation { get; set; }
        public string strPermanentNearestRailwayStation { get; set; }
        public string strPermanentPinCode { get; set; }
        public string strPermanentTelephoneNo { get; set; }
        public string strPermanentMobile1 { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public bool? isactive { get; set; }
        public string strsubcaste { get; set; }
        public string strcertificateno { get; set; }
        public DateTime? dt_certificateissuedate { get; set; }
        public string strcertificateissue { get; set; }
        public string strtypeofdisable { get; set; }
        public string strcertificateno1 { get; set; }
        public DateTime? dt_certificateissuedate1 { get; set; }
        public string strcertificateissue1 { get; set; }
        public string strMotherName { get; set; }
        public string strSpouseName { get; set; }
        public string strAlternate_EmaiID { get; set; }
        public string strPANNo { get; set; }
        public string strAadharNo { get; set; }
        public string strApprenticeshipRegNo { get; set; }
        public string strFinalSubmit { get; set; }
        public DateTime? dtFinalSubmitDate { get; set; }

        public string Candidate_Code { get; set; }
        public string strMobileNumber { get; set; }
        public string isreference { get; set; }
        public string str_Relationship { get; set; }
        public string str_Deptt { get; set; }
        public string str_Designation { get; set; }
        public string str_Code { get; set; }
        public string str_Name { get; set; }
        public string strTradeName { get; set; }



    }
}