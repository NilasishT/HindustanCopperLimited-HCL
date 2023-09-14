using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstEmployee
    {
        [Key]
        public int ID { get; set; }
        public string EmpCd { get; set; }
        public string F_Name { get; set; }
        public string Department { get; set; }
        public string Desg { get; set; }
        public string Catg { get; set; }
        public string EMailId { get; set; }
        public string Area { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public string vchPassword { get; set; }
        public string dtmCreatedOn { get; set; }
        public string intDeletedFlag { get; set; }
    }
}