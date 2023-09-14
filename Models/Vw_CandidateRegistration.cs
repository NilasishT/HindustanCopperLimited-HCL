using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class Vw_CandidateRegistration
    {
 [Key]
 
 public int Pk_int_CandidateRegistrationID { get; set; }
 public int fk_CandidateId { get; set; }
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
 public DateTime? dt_updatedate { get; set; }
 public DateTime? dt_entrydate { get; set; }
 public bool? isactive { get; set; }
 public string strsubcaste { get; set; }
 public string strcertificateno { get; set; }
 public DateTime? dt_certificateissuedate { get; set; }
 public string strcertificateissue { get; set; }
 public string strexservicemanno { get; set; }
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
 public int pk_candidateuploadid { get; set; }
 public int? fk_intcandidateid { get; set; }
 public string str_uploadphoto { get; set; }
 public string str_uploadsignature { get; set; }
 public string is_active { get; set; }
 public string str_applicationno { get; set; }
 public int? Fk_candidateregistration { get; set; }
 public string str_Publication_PaperPresentation { get; set; }
 public int? Pk_intPublication_PaperPresentation { get; set; }
 public int? Fk_int_CandidateRegistrationID { get; set; }
 public string Str_exampassed { get; set; }
 public string Str_board { get; set; }
 public string Str_passingdetails { get; set; }
 public string Str_duration { get; set; }
 public string Str_passingyear { get; set; }
 public string Str_division { get; set; }
 public string Str_Marks { get; set; }
 public string strApplicationNo { get; set; }
 public int? fk_advertiseid { get; set; }
 public string strDomicilestate { get; set; }

        
    }
}
       
  