using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_dumData_Fee_Claim
    {
        [Key]
        public int pk_id { get; set; }
        public string strApplicationNo { get; set; }
    }
}