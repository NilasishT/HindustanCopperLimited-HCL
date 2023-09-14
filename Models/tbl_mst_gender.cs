using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_gender
    {
        [Key]
        public int Pk_intGenderid { get; set; }
        public string str_gender { get; set; }
        public string is_active { get; set; }
    }
}

