using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_Grade
    {
        [Key]

        public int pk_intGrade { get; set; }
        public string strGradeName { get; set; }
       
        
    }
}