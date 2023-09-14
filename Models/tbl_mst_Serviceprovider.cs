using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_Serviceprovider
    {
        [Key]
        public int Pk_int_serviceprovider { get; set; }
        public string str_desc { get; set; }
        public string is_active { get; set; }
    }
}


