using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_Discipline
    {
        [Key]
        
        public int Pk_Disciplineid { get; set; }
        public string DisciplineName { get; set; }
        public string DisciplineDescription { get; set; }
        
        public bool? IsActive { get; set; }
        
    }
}