using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstCategory
    {
        [Key]
        public int Pk_intCategoryID { get; set; }
        public string strCategoryName { get; set; }
        public bool isActive { get; set; }

    }
}