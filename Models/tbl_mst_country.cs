using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_country
    {
        [Key]
        public int Pk_Countryid { get; set; }
        public string Str_country { get; set; }
      
    }
}