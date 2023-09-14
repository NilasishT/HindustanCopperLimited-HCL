using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstDengue
    {
        [Key]
        public int pkId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Age { get; set; }
        public string Sex { get; set; }
        public string Phoneno { get; set; }
        public string UphcUnitNo { get; set; }
        public string Ward { get; set; }
        public string Igm { get; set; }
        public string Nsi { get; set; }
        public string Platelet { get; set; }
        public string Remarks { get; set; }
    }
}