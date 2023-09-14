using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_TenderWiseVendor
    {
        [Key]
        public int pk_intId {get;set;}
        public int fk_intTenderId {get;set;}
        public int fk_intNewVendorRegistrationID {get;set;}
        public bool isActive {get;set;}
        public DateTime dtEntryDate {get;set;}
        public DateTime dtUpdateDate {get;set;}

        public virtual tbl_mst_tender tender { get; set; }
        public virtual VendorRegistration vender { get; set; }
    }
}