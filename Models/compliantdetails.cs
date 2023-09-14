using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class compliantdetails
    {
        
       
        public int id { get; set; }
        public int? pk_actionid { get; set; }
        public int intGrievanceId { get; set; }
        public string vchComplainer { get; set; }
        public string vchCity { get; set; }
        public string vchComplainerAddress { get; set; }
        public string vchPin { get; set; }
        public string vchStdCode { get; set; }
        public string vchLPhoneNo { get; set; }
        public string vchContactNo { get; set; }
        public string vchEmail { get; set; }
        public DateTime? dtmDob { get; set; }
        public string vchGender { get; set; }
        public string vchComplainType { get; set; }
        public string vchLocation { get; set; }
        public string vchComplainDetails { get; set; }
        public string vchCompAgainstOff { get; set; }
        public string vchOffDesig { get; set; }
        public string vchFileName { get; set; }
        //public string intFileSize { get; set; }
        public DateTime? dtmCompRegDate { get; set; }
        public string vchCompStatus { get; set; }
        public string vchCompRegNo { get; set; }
        public string vchRegisteredBy { get; set; }
        //public string bitDeletedFlag { get; set; }
        //public int pk_actionid { get; set; }
        public int? fk_userid { get; set; }
        public int? fk_complaintid { get; set; }
        public string str_upload1 { get; set; }
        public string str_upload2 { get; set; }
        public string str_remarks { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public string isactive { get; set; }

    }
}