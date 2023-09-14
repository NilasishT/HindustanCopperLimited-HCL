using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class SpotbookingRegistrationdetails
    {
        [Key]
        public int Pk_Registrationid { get; set; }
       
        public string str_fname { get; set; }
        public string str_mname { get; set; }
        public string str_lname { get; set; }
        public string str_email { get; set; }
        public string str_phno { get; set; }
        public string str_officeno { get; set; }
        public string str_mobile { get; set; }
        public string str_fax { get; set; }
        public string str_address { get; set; }
        public string str_city { get; set; }
        public string str_state { get; set; }
        public string str_pin { get; set; }
        public string str_district { get; set; }
        public string str_country { get; set; }
        public string str_panno { get; set; }
        public string str_gstno { get; set; }
        public string str_namefirm { get; set; }
        public string str_pw { get; set; }
        public string str_confirmpw { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public string Isactive { get; set; }
        public string str_code { get; set; }

        public string str_CustomerStatus { get; set; }
        public DateTime? dt_CustomerStatusDate { get; set; }
        public string str_Remarks { get; set; }

        public string fk_region { get; set; }
    }
}
