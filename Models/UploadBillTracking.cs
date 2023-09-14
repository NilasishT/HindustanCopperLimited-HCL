using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class UploadBillTracking
    {
        [Key]
        public int id { get; set; }
        public int fkUnitId { get; set; }
        public string PurchaseOrders { get; set; }
        public string BillSubmitted { get; set; }
        public string BillStatus { get; set; }
        public DateTime EntryDate { get; set; }

    }
}