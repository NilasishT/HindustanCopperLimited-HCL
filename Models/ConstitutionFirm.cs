using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class ConstitutionFirm
    {
        [Key]
        public int pk_intConstitutionFirmID { get; set; }
        public string strConstitutionFirm { get; set; }

    }
}