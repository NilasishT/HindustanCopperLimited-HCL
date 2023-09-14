using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CandidateExperience
    {
          [Key]
      public int       Pk_Experienceid   { get ; set ; }
      public int       Fk_CandidateRegistrationID   { get ; set ; }
      public string    Str_designation   { get ; set ; }
      public DateTime  dt_fromdate   { get ; set ; }
      public DateTime  dt_todate { get; set; }
      public string    str_noyears   { get ; set ; }
      public string    str_organisation   { get ; set ; }
      public string    str_remarks   { get ; set ; }
      public DateTime? dtEntyDate { get; set; }
      public string    ApplicationNo { get; set; }
      public string    str_organisationType { get; set; }
      public string    str_CTC { get; set; }
      public string    str_PayScale { get; set; }
      public string    StrEmploymentPresentStatus { get; set; }

    }

    public class tbl_mst_CandidateExperience_temp
    {
        [Key]
        public int Pk_Experienceid { get; set; }
        public int Fk_CandidateRegistrationID { get; set; }
        public string Str_designation { get; set; }
        public DateTime dt_fromdate { get; set; }
        public DateTime dt_todate { get; set; }
        public string str_noyears { get; set; }
        public string str_organisation { get; set; }
        public string str_remarks { get; set; }
        public DateTime? dtEntyDate { get; set; }
        public string ApplicationNo { get; set; }
        public string str_organisationType { get; set; }
        public string str_CTC { get; set; }
        public string str_PayScale { get; set; }
        public string StrEmploymentPresentStatus { get; set; }

    }
}