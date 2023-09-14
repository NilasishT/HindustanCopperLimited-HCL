using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class Vw_Notice_Other
    {
        [Key]
        public int pk_Otherid { get; set; }
        public string Empnoticeno { get; set; }
        public string str_empnoticeno { get; set; }
        public string strType { get; set; }
        public DateTime? dt_closingextenddate { get; set; }
        public DateTime? dt_noticeextenddate { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public string str_upload { get; set; }
        public string str_uploadhindi { get; set; }
        public string isactive { get; set; }
        public string Emptitle { get; set; }
        public string EmptitleHindi { get; set; }
    }
}