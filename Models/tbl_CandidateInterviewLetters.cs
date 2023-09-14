using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class tbl_CandidateInterviewLetters
    {
        public int BBB { get; set; }
        public string str_discipline { get; set; }
        public string AAAA { get; set; }
        [Key]
        public int fk_CandidateId { get; set; }
        public string strApplicantName { get; set; }
        public DateTime dt_Interview { get; set; }
        public int fk_RegistrationId { get; set; }
     
    }
}