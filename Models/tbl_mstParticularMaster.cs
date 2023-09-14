using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstParticularMaster
    {
        [Key]
        public int ParticularId { get; set; }
        public string ParticularDesc { get; set; }
        public string ParticularStatus { get; set; }
        public string strUnit { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}