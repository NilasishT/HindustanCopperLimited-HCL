using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class BillDetails
    {
        [Key]
        public int Pk_Id { get; set; }
        public string UNIT { get; set; }
        public string VendorCode { get; set; }
        public string VendorGSTNo { get; set; }
        public string ContractNo { get; set; }
        public string InvoiceNo { get; set; }
        public string Invoicedate { get; set; }
        public string InvoiceAmount { get; set; }
        public string BillReceivedDate { get; set; }
        public string Remarks { get; set; }
        public string StatusinUserDept { get; set; }
        public string ProcessedinUserDept { get; set; }

    }
}