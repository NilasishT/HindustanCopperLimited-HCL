using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class vw_InterviewCall
    {
        [Key]
        public int CandidateId { get; set; }
        public string code { get; set; }
       public string discipline { get; set; }
public int b { get; set; }
        

public int CandidateRegistrationID { get; set; }
        public DateTime  dt_Interview { get; set; }
        public string DOI { get; set; }
        public string ApplicantName { get; set; }
public int advertiseid { get; set; }
public string strApplicationNo { get; set; }
        public string strPermanentAddress { get; set; }
      public string strPin { get; set; }
        public string strNearestPoliceStation { get; set; }
        public string strCategory { get; set; }
public string strPermanentPinCode { get; set; }
        public string strState { get; set; }
        public string strCorrespondenceAddress { get; set; }
        public string strDistrict { get; set; }
    }
}