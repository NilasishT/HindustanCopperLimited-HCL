using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace Hindustancopperlimited.Models
{
    public class tbl_NextBelowGrade
    {
        [Key]
        public int Pk_nextBelowId { get; set; }
        public int Fk_CandidateRegistrationID { get; set; }
        public string strGrade { get; set; }
        public string strApplicationNo { get; set; }
        public string dtFromDate { get; set; }
        public string dtTodate { get; set; }
        public string strYear { get; set; }
        public DateTime? dtEntryDate { get; set; }
    }

    public class tbl_NextBelowGrade_temp
    {
        [Key]
        public int Pk_nextBelowId { get; set; }
        public int Fk_CandidateRegistrationID { get; set; }
        public string strGrade { get; set; }
        public string strApplicationNo { get; set; }
        public string dtFromDate { get; set; }
        public string dtTodate { get; set; }
        public string strYear { get; set; }
        public DateTime? dtEntryDate { get; set; }
    }
}