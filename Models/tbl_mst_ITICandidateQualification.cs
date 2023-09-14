using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_ITICandidateQualification
    {
        [Key]
        public int Pk_Qualification { get; set; }
        public int fk_CandidateId { get; set; }
        public string Str_exampassed { get; set; }
        public string Str_course { get; set; }
        public string Str_board { get; set; }
        public string Str_passingdetails { get; set; }
        public string Str_duration { get; set; }
        public string Str_passingyear { get; set; }
        public string Str_division { get; set; }
        public string Str_Marks { get; set; }
        public string StrRemarks { get; set; }
        public DateTime? dtEntyDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public bool? isActive { get; set; }
        public string Str_TotalMarks { get; set; }
        public string Str_MarksObtained { get; set; }
        public string Str_Affiliation { get; set; }
        public string str_Itiaffidavit { get; set; }
        public string str_ItiPassingYear { get; set; }

    }
}