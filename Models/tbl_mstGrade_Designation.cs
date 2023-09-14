using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstGrade_Designation
    {
        [Key]
        public int pk_intGrade_DesignationID { get; set; }
        public string strGradeName { get; set; }
        public string strDesignationName { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public string strStatus { get; set; }

    }
}








