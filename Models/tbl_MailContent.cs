using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_MailContent
    {
        [Key]
        public int pk_intMailId { get; set; }
        public string strTitle { get; set; }
        public string strSubject { get; set; }
        public string strBody { get; set; }
        public string strSign { get; set; }
        public string strMailPurposeType { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }

    }
}