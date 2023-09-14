using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_VendorBlackListed
    {
        [Key]
        public int Pk_Id { get; set; }
        public string strVendorCode { get; set; }
        public DateTime? dtFromDate { get; set; }
        public DateTime? dtToDate { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public string strRemarks { get; set; }
    }
}