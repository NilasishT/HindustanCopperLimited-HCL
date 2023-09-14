using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class BillStatus
    {
        [Key]
        public int Pk_Id { get; set; }
        public string VendorCode { get; set; }
        public string VendorGSTNo { get; set; }
        public string ContractNo { get; set; }
        public string InvoiceNo { get; set; }
        public string Invoicedate { get; set; }
        public string InvoiceAmount { get; set; }
        public string BillReceivedDate { get; set; }
        public string Billstatus { get; set; }
        public string AsonDate { get; set; }
        public string DeptPlace { get; set; }
        public string ConcernedOfficerName { get; set; }
        public string AmountReleased { get; set; }
        public string PaymentDate { get; set; }

      
      
      

    }
}