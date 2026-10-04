using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CandidateQualification
    {
        [Key]
        public int Pk_Qualification { get; set; }
        public int Fk_int_CandidateRegistrationID { get; set; }
        public string Str_exampassed { get; set; }
        public string Str_course { get; set; }
        public string Str_board { get; set; }
        public string Str_passingdetails { get; set; }
        public string Str_duration { get; set; }
        public string Str_passingyear { get; set; }
        public string Str_division { get; set; }
        public string Str_Marks { get; set; }
        public string StrRemarks { get; set; }
        public string EduQulifi { get; set; }
        public DateTime? dtEntyDate { get; set; }

        public string Application_No { get; set; }
        public int? fk_advertiseid { get; set; }
        public string str_UploadCertificate { get; set; }

        public string StrExamMedium { get; set; }
        public string Str_electivesubject { get; set; }
    }

    public class tbl_mst_CandidateQualification_temp
    {
        [Key]
        public int Pk_Qualification { get; set; }
        public int Fk_int_CandidateRegistrationID { get; set; }
        public string Str_exampassed { get; set; }
        public string Str_course { get; set; }
        public string Str_board { get; set; }
        public string Str_passingdetails { get; set; }
        public string Str_duration { get; set; }
        public string Str_passingyear { get; set; }
        public string Str_division { get; set; }
        public string Str_Marks { get; set; }
        public string StrRemarks { get; set; }
        public string EduQulifi { get; set; }
        public DateTime? dtEntyDate { get; set; }

        public string Application_No { get; set; }

    }
}