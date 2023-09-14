using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class vw_AveragePaymentReport
    {
        [Key]
        public int ID { get; set; }
        public int totalEmployee { get; set; }
        public double GROSS { get; set; }
        public double NETPAY { get; set; }
        public string NAMEOFTHEWORK { get; set; }
        public string WORKORDERNO { get; set; }
        public DateTime? DATEOFCOMPLETIONWORK { get; set; }
        public DateTime? DATEOFCOMMENCEMENT { get; set; }
        public string strUnitName { get; set; }
        public string strUnitCode { get; set; }
        public string WO_AREA { get; set; }
        public string strNameofFirmCompany { get; set; }
        public string strstrRegisteredOfficeAddress { get; set; }
        public string MNTH { get; set; }
        public string YEAR { get; set; }
        public int NOOFWORKERS { get; set; }
        public decimal AVGSALARY { get; set; }
        public double ATTENDANCE { get; set; }
    }
}