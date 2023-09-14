using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_Quarter
    {
        [Key]
        public int Pk_intQuarterID { get; set; }
        public string strQuarterName { get; set; }
        public string strFromMonth { get; set; }
        public string strToMonth { get; set; }

    }
}