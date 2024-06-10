using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_TradesForITI
    {
        [Key]
        public int Pk_intTradeid { get; set; }
        public string str_Trade { get; set; }
        public string is_active { get; set; }
    }
}