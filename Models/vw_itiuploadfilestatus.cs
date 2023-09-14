using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class vw_itiuploadfilestatus
    {
        [Key]
        public int sl { get; set; }

        public string Ack_No { get; set; }
        public string App_reg_no { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Trade_Name { get; set; }
        public string ten { get; set; }
        public string ITI { get; set; }
        public string Affidavit { get; set; }
        public string file_status { get; set; }
        public int fk_CandidateId { get; set; }


    }
}
