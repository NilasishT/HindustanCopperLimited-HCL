using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_EOI
    {

        [Key]
        public int Pk_int_EOI { get; set; }
        public string strSnippet { get; set; }
        public string strFileUpload { get; set; }
        public string strStatus { get; set; }
        public DateTime? dtupdateDate { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtClosingDate { get; set; }

        public bool IsImportant { get; set; }
        public string strSnippethindi { get; set; }
        public string strFileuploadhindi { get; set; }
      

      
    }
}