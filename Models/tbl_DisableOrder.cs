using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_DisableOrder
    {
        [Key]
        public int pk_intDisableOrderId { get; set; }
        public DateTime dtFromDate { get; set; }
        public DateTime dtTodate { get; set; }
    }
}