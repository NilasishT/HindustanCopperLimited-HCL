using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_PostDetails
    {
       
       
        public int Pk_Postid { get; set; }
        public int Fk_Disciplineid { get; set; }
        public string Postname { get; set; }
        //public string Postnumber { get; set; }

        public string PostNamewithDisciplineName { get; set; }
            

        public string Fk_intGrade { get; set; }

        public string Payscale { get; set; }

        //public string Maxage { get; set; }
        public string Minexp { get; set; }
        public string Isfresher { get; set; }
       // public string OtherQualification { get; set; }
        public string Fk_Qualification { get; set; }

        public DateTime? dtcompareDate { get; set; }
        public DateTime? dtExpiryDate { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public bool? IsActive { get; set; }
    }
}