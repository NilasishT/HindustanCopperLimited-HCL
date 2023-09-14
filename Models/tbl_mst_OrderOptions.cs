using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_OrderOptions
    {
        [Key]
        public int pk_intOrderOptionId { get; set; }
        public string strOrderOption { get; set; }
    }
}