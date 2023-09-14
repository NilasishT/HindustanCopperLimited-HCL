using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_ContractLabour
    {
        [Key]
        public int Sl { get; set; }
        public string Description { get; set; }
        public string Unit { get; set; }
        public string Department { get; set; }
        public string LOINo { get; set; }      
        public string LOIDate { get; set; }
        public string WorkOrderNo { get; set; }
        public string WorkOrderDate { get; set; }
        public string PartyName { get; set; }
        public string PartyAddress { get; set; }
        public string TotalWagesPaid { get; set; }
        public string AverageSalary { get; set; }        
        public string Engaged { get; set; }
        
        

    }
}