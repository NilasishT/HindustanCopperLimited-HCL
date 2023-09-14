using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_GraduateApprenticeRTI
    {
        [Key]
        public int Pk_intId { get; set; }
        public int? fk_CandidateId { get; set; }
        public int fk_intAddId { get; set; }
        public string strAnswer { get; set; }
        public bool? isactive { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }
    }
}