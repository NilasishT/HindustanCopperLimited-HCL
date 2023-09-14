using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_Quarterlyreport
    {
        [Key]
        public int Pk_ReportId { get; set; }
        public string ParticularDesc { get; set; }
        public int QuarterId { get; set; }
        public string txtData { get; set; }
        public double? numSalesData { get; set; }
        public int numYear { get; set; }
      }
}