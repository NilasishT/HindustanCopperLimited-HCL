using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_tenderEOI
    {
        [Key]
        public int pk_intTenderId { get; set; }
        public string strSnippet { get; set; }
        public string strSnippethindi { get; set; }
        public string strFileUpload { get; set; }
        public string strFileuploadhindi { get; set; }
        public string strType { get; set; }

    }
}




