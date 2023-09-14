using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_temp_CandidateApplicationDetails
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
        public string strExserviceMan { get; set; }
        public string strInternalCandidate { get; set; }
        public string strEmployedIn { get; set; }
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
        public string strsubcaste { get; set; }
        public string strcertificateno { get; set; }
        public DateTime? dt_certificateissuedate { get; set; }
        public string strcertificateissue { get; set; }
        public string strexservicemanno { get; set; }
        public string strDomicilestate { get; set; }
        public string strtypeofdisable { get; set; }
        public string strcertificateno1 { get; set; }
        public DateTime? dt_certificateissuedate1 { get; set; }
        public string strcertificateissue1 { get; set; }
        public string stremployeecode { get; set; }
        public string strgrade { get; set; }
        public string strplaceposting { get; set; }
        public string strpresentdesignation { get; set; }
        public DateTime? dt_presententrydate { get; set; }
        public string strapplyproper { get; set; }
        public int? fk_postid { get; set; }
        public string strApplicationNo { get; set; }
        public int? fk_advertiseid { get; set; }
        public string str_status { get; set; }
        public string Str_exampassed { get; set; }
        public string Str_board { get; set; }
        public string Str_passingdetails { get; set; }
        public string Str_duration { get; set; }
        public string Str_passingyear { get; set; }
        public string Str_division { get; set; }
        public string Str_Marks { get; set; }
        public string Str_exampassed1 { get; set; }
        public string Str_board1 { get; set; }
        public string Str_passingdetails1 { get; set; }
        public string Str_duration1 { get; set; }
        public string Str_passingyear1 { get; set; }
        public string Str_division1 { get; set; }
        public string Str_Marks1 { get; set; }

        public string Str_exampassed2 { get; set; }
        public string Str_board2 { get; set; }
        public string Str_passingdetails2 { get; set; }
        public string Str_duration2 { get; set; }
        public string Str_passingyear2 { get; set; }
        public string Str_division2 { get; set; }
        public string Str_Marks2 { get; set; }
        public string Str_exampassed3 { get; set; }
        public string Str_board3 { get; set; }
        public string Str_passingdetails3 { get; set; }
        public string Str_duration3 { get; set; }
        public string Str_passingyear3 { get; set; }
        public string Str_division3 { get; set; }
        public string Str_Marks3 { get; set; }



        public string others_exampassed1 { get; set; }
        public string others_course1 { get; set; }
        public string others_board1 { get; set; }
        public string others_passingdetails1 { get; set; }
        public string others_passingyear1 { get; set; }
        public string others_duration1 { get; set; }
        public string others_Marks1 { get; set; }
        public string others_division1 { get; set; }
        public string others_Remarks1 { get; set; }


        public string others_exampassed2 { get; set; }
        public string others_course2 { get; set; }
        public string others_board2 { get; set; }
        public string others_passingdetails2 { get; set; }
        public string others_passingyear2 { get; set; }
        public string others_duration2 { get; set; }
        public string others_Marks2 { get; set; }
        public string others_division2 { get; set; }
        public string others_Remarks2 { get; set; }

        public string others_exampassed3 { get; set; }
        public string others_course3 { get; set; }
        public string others_board3 { get; set; }
        public string others_passingdetails3 { get; set; }
        public string others_passingyear3 { get; set; }
        public string others_duration3 { get; set; }
        public string others_Marks3 { get; set; }
        public string others_division3 { get; set; }
        public string others_Remarks3 { get; set; }


        public string others_exampassed4 { get; set; }
        public string others_course4 { get; set; }
        public string others_board4 { get; set; }
        public string others_passingdetails4 { get; set; }
        public string others_passingyear4 { get; set; }
        public string others_duration4 { get; set; }
        public string others_Marks4 { get; set; }
        public string others_division4 { get; set; }
        public string others_Remarks4 { get; set; }


        public string Str_designation { get; set; }
        public DateTime? dt_fromdate { get; set; }
        public DateTime? dt_todate { get; set; }
        public string str_noyears { get; set; }
        public string str_organisation { get; set; }
        public string StrRemarks { get; set; }
        public string Str_designation1 { get; set; }
        public DateTime? dt_fromdate1 { get; set; }
        public DateTime? dt_todate1 { get; set; }
        public string str_noyears1 { get; set; }
        public string str_organisation1 { get; set; }
        public string StrRemarks1 { get; set; }
        public string Str_designation2 { get; set; }
        public DateTime? dt_fromdate2 { get; set; }
        public DateTime? dt_todate2 { get; set; }
        public string str_noyears2 { get; set; }
        public string str_organisation2 { get; set; }
        public string StrRemarks2 { get; set; }
        public string Str_designation3 { get; set; }
        public DateTime? dt_fromdate3 { get; set; }
        public DateTime? dt_todate3 { get; set; }
        public string str_noyears3 { get; set; }
        public string str_organisation3 { get; set; }
        public string StrRemarks3 { get; set; }
        public string Str_designation4 { get; set; }
        public DateTime? dt_fromdate4 { get; set; }
        public DateTime? dt_todate4 { get; set; }
        public string str_noyears4 { get; set; }
        public string str_organisation4 { get; set; }
        public string str_remarks4 { get; set; }
        public string straward { get; set; }
        public string straward1 { get; set; }
        public string straward2 { get; set; }
        public string str_Publication_PaperPresentation { get; set; }
        public string str_Publication_PaperPresentation1 { get; set; }
        public string str_Publication_PaperPresentation2 { get; set; }
        public string strApplicationNo1 { get; set; }
        public string strProfessionalBodies { get; set; }
        public string strJoiningTimeReq { get; set; }
        public string strJoinEarly { get; set; }
        public string str_uploadphoto { get; set; }
        public string str_uploadsignature { get; set; }
        public string strOrderNo { get; set; }
        public string strIssuingBankName { get; set; }
        public string strIssuingBranch { get; set; }
        public DateTime? dtIssueDate { get; set; }
        public Decimal? decAmount { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public bool? isactive { get; set; }
        public string isexperience { get; set; }
        public string EduQulifi { get; set; }


        public string strMotherName { get; set; }
        public string strSpouseName { get; set; }
        public string strAlternate_EmaiID { get; set; }
        public string strPANNo { get; set; }
        public string strAadharNo { get; set; }


        public string Str_course { get; set; }
        public string Str_course1 { get; set; }
        public string Str_course2 { get; set; }
        public string Str_course3 { get; set; }

    }
}