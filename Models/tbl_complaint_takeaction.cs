using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace Hindustancopperlimited.Models
{
    public class tbl_complaint_takeaction
    {
        [Key]
        public int pk_actionid { get; set; }
         public int? fk_userid { get; set; }
        public int? fk_complaintid { get; set; }
       
        public DateTime? dt_entrydate { get; set; }
        public string isactive { get; set; }
        public string str_upload1 { get; set; }
        public string str_upload2 { get; set; }
        public string str_remarks { get; set; }
    }
}

