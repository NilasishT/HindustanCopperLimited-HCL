using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace Hindustancopperlimited.Models
{
    public class CONTRACT_WORKMAN_WORK : DbContext
    {
        [Key]
        public int ID { get; set; }

        public int CONTRACTORID { get; set; }
        public int WORKORDERID { get; set; }
        public int WORKMANID { get; set; }
        public DateTime? STARTDATE { get; set; }
        public DateTime? ENDDATE { get; set; }
        public DateTime? CREATIONDATE { get; set; }
        public DateTime? UPDATEDATE { get; set; }
    }
}