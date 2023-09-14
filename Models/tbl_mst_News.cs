using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
    {
    public class tbl_mst_News
    {
        [Key]
        public int Pk_intNewsID { get; set; }
        public string strSubjectdfsEnglish { get; set; }
        public DateTime? dtExpiryDate { get; set; }
        public string IsStatus { get; set; }        
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdatedate { get; set; }
        public string strNewsType { get; set; }
        public string strFileEnglish { get; set; }
        public string strSubjectdfshindi { get; set; }
        public string strFileHindi { get; set; }
    }
}





 















