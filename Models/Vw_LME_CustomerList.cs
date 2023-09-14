using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data;

namespace Hindustancopperlimited.Models
{
    public class Vw_LME_CustomerList
    {
        [Key]
        public int Pk_Registrationid { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; }

        public string ContactDetails { get; set; }

        public string AddressDetails { get; set; }

        public string PAN { get; set; }

        public string GST { get; set; }
        

        public string NameOfFirm { get; set; }
        public string Code { get; set; }
        public string CustomerStatus { get; set; }
        public string Remarks { get; set; }
        
        public DateTime? CustomerStatusDate { get; set; }


    }
}