using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CandidateAwardScholarship
    {
        [Key]
        public int Pk_intcandidateawardscholarship { get; set; }
        public int Fk_candidateregistration { get; set; }
        public string straward { get; set; }       
        public DateTime? dtEntyDate { get; set; }

        public string Application_No { get; set; } 
    }

    public class tbl_mst_CandidateAwardScholarship_temp
    {
        [Key]
        public int Pk_intcandidateawardscholarship { get; set; }
        public int Fk_candidateregistration { get; set; }
        public string straward { get; set; }
        public DateTime? dtEntyDate { get; set; }

        public string Application_No { get; set; }
    }
}