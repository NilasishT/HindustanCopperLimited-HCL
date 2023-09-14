using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Unit
    {
        [Key]
        public int pk_intUnitId { get; set; }
        public string strUnitName { get; set; }
        public string strUnitCode { get; set; }
        public string strUnitAddress { get; set; }
        public string strContactInfo { get; set; }
        public bool? isActive { get; set; }

        //public List<VendorRegistration> VendorRegistrations { get; set; }
       
    }
}