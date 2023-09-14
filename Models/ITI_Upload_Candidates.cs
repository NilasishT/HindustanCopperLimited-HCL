using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class ITI_Upload_Candidates
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
    }
}