using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_Postnew
    {
        [Key]
        public int Pk_Postid { get; set; }
        public int fk_discipline { get; set; }
        public string Postname { get; set; }
        public string str_Grade { get; set; }
        public string Payscale { get; set; }

        public string Is_active { get; set; }
        public string str_ctc { get; set; }
        public string str_minage { get; set; }
        public string str_maxage { get; set; }
        public string str_minexp { get; set; }
        public string str_maxexp { get; set; }
        public string strIsFreshersAllowed { get; set; }
        public DateTime? dtcompareDate { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }

    }
}
