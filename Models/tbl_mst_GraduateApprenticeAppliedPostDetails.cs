using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_GraduateApprenticeAppliedPostDetails
    {
        [Key]
        public int pk_intAppliedPostId { get; set; }
        [Required]
        public int fk_unitId { get; set; }
        public int fk_CandidateId { get; set; }
        [Required]
        public string strTradeName { get; set; }
        public string strApplicationNo { get; set; }
        public int? fk_intAddId { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public bool? isactive { get; set; }
        

    }
}
