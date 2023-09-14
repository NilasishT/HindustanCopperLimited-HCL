using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_course
    {
        [Key]
        public int Pk_Courseid { get; set; }
        public int Int_vieworder { get; set; }
        public string Str_Coursename { get; set; }
    }
}