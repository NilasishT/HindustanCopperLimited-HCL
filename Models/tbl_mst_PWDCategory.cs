using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_mst_PWDCategory
    {
         [Key]
        public int Pk_intPWDCatId { get; set; }
        public string str_CatName { get; set; }
        public string ShortName { get; set; }
        public string is_active { get; set; }
    }
}

