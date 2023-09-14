using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_Post
    {
        [Key]
        public int Pk_Postid { get; set; }
        public int Fk_Disciplineid { get; set; }
        public string Postname { get; set; }
      
        
        public string Fk_intGrade { get; set; }
        
        public string Payscale { get; set; }

        
        public string Minexp { get; set; }
        public string Isfresher { get; set; }

        public string Fk_Qualification { get; set; }
        

        public string Postnumber_gen { get; set; }
        public string Postnumber_obc { get; set; }
        public string Postnumber_sc { get; set; }
        public string Postnumber_st { get; set; }
        public string Postnumber_pwd { get; set; }
        public string Maxage_freshers { get; set; }
        public string Maxage_exp { get; set; }
         public string Minage_freshers { get; set; }
        public string Minage_exp { get; set; }

        public DateTime? dtcompareDate { get; set; }
        public DateTime? dtExpiryDate { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public DateTime? dtstartdate { get; set; }
        public bool? IsActive { get; set; }

    }
}

