using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_ITICandidateReferencesDetails
    {
        [Key]
        public int pk_candidateRefId { get; set; }        
        public int fk_intcandidateid { get; set; }
        [RequiredIf("isreference", "YES", "")]
        public string str_Name { get; set; }
        [RequiredIf("isreference", "YES", "")]
        public string str_Code { get; set; }
        [RequiredIf("isreference", "YES", "")]
        public string str_Designation { get; set; }
        [RequiredIf("isreference", "YES", "")]
        public string str_Deptt { get; set; }
        [RequiredIf("isreference", "YES", "")]
        public string str_Relationship { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public bool? isactive { get; set; }
        [Required]
        public string isreference { get; set; }
    }
}