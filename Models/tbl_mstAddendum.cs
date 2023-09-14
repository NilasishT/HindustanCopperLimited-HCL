using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstAddendum
    {

        [Key]
        public int pk_intAddendumId { get; set; }
        public int fk_intTendorId { get; set; }
        public string strFileName { get; set; }
         public string strFileNameHindi{ get; set; }
        public string strEnqueryNumber { get; set; }
        public DateTime? dtExtendedDate { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
    }
}