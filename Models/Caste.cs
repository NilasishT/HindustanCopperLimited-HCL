using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Caste
    {
        [Key]
        public int pk_intCasteId { get; set; }
        public string strCasteName { get; set; }
        public bool? IsActive { get; set; }
    }
}