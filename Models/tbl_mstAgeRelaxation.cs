using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstAgeRelaxation
    {
        [Key]
        public int pk_CasteAgeRelaxId { get; set; }
        public string strCategory { get; set; }
        public int AgeRelaxationYear { get; set; }
        public bool isActive { get; set; }
      

    }
}