using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class InitialRegistration
    {
        [Key]
        public int pk_intRegisterUserID { get; set; }
        public string strPassword { get; set; }
        public string strFirstName { get; set; }
        public string strLastName { get; set; }
        public string strMiddleName { get; set; }
        public string struserName { get; set; }
        public string strMobile { get; set; }
        //public string strUserId { get; set; }
        public string strEmail { get; set; }

        public DateTime? dtEntrydate { get; set; }
        public DateTime? dtUpdatedate { get; set; }
    }
}