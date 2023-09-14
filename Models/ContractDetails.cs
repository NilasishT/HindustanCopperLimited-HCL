using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class ContractDetails
    {
        [Key]
        public int Pk_Id { get; set; }
        public string UNIT { get; set; }
        public string VendorCode { get; set; }
        public string VendorGSTNo { get; set; }
        public string ContractNo { get; set; }
        public string ContractDescription { get; set; }
        public string ContractStartDate { get; set; }
        public string ContractEndDate { get; set; }
        public string EngineerInCharge { get; set; }
        public string Department { get; set; }
        public string Section { get; set; }
        public string BasicAmount { get; set; }
        public string Taxtype { get; set; }
        public string Tax { get; set; }
        public string TotalValue { get; set; }
        public string PaymentTerms { get; set; }
        public string ExtendDate1 { get; set; }
        public string ExtendDate2 { get; set; }
        public string ExtendDate3 { get; set; }
        public string ExtendDate4 { get; set; }
        public string ExtendDate5 { get; set; }
        public string BGAmount { get; set; }
        public string BGStartDate { get; set; }
        public string BGEnddate { get; set; }
        public string BGextensionDate1 { get; set; }
        public string BGextensionDate2 { get; set; }
        public string BGextensionDate3 { get; set; }
        public string BGextensionDate4 { get; set; }
        public string BGextensionDate5 { get; set; }
    }
}