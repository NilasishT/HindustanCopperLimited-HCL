using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_Products
    {
        [Key]
        public int pk_intProductId { get; set; }
        public string strProductName { get; set; }
    }
}