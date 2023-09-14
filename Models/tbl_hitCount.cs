using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_hitCount
    {

        [Key]
        public int pk_intHitCount { get; set; }
        public int intQuantity { get; set; }
        public DateTime LastUpdate { get; set; }
      
    }
}