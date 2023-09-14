using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstDepartment
    {
        [Key]
        public int pk_intID { get; set; }
        public string strDepartmentName { get; set; }
        public bool isActive { get; set; }
    }
}