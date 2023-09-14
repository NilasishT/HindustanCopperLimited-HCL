using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class ItemDescription
    {

        [Key]
        public int Pk_intItemDescription { get; set; }
        public string strItemDescriptionName { get; set; }
        public string strItemDescriptionCode { get; set; }

      
    }
}