using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_Qualification
    {
        [Key]

        public int Pk_Qualification { get; set; }
        public string QualificationStatus { get; set; }
        public string Qualification_name { get; set; }
       
    }
}