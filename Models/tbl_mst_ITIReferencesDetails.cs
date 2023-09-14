using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_ITIReferencesDetails
    {
        [Key]
        public int pk_RefId { get; set; }
        public string str_Name { get; set; }
        public string str_Code { get; set; }
        public string str_Designation { get; set; }
        public string str_Deptt { get; set; }
    }
}