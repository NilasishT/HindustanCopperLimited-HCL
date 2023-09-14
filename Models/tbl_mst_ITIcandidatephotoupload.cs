using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_ITIcandidatephotoupload
    {
        [Key]
        public int pk_candidateuploadid { get; set; }
        public int fk_intcandidateid { get; set; }
        public string str_documentType { get; set; }
        public string str_document { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public bool? isactive { get; set; }
    }
}