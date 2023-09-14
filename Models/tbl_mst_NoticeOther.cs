using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_NoticeOther
    {
        [Key]
        public int pk_Otherid { get; set; }
        public int? fk_empnoticeid { get; set; }
        public string str_empnoticeno { get; set; }
        public DateTime? dt_closingextenddate { get; set; }
        public DateTime? dt_noticeextenddate { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public string str_upload { get; set; }
        public string str_uploadhindi { get; set; }
        public string isactive { get; set; }
    }
}