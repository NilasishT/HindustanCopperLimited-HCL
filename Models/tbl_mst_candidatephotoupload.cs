using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_candidatephotoupload
    {

        [Key]
        public int pk_candidateuploadid { get; set; }
        public int? fk_intcandidateid { get; set; }
        public string str_uploadphoto { get; set; }
        public string str_uploadsignature { get; set; }
        public string is_active { get; set; }
        public string str_applicationno { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }
       
    }

    public class tbl_mst_candidatephotoupload_temp
    {

        [Key]
        public int pk_candidateuploadid { get; set; }
        public int? fk_intcandidateid { get; set; }
        public string str_uploadphoto { get; set; }
        public string str_uploadsignature { get; set; }
        public string is_active { get; set; }
        public string str_applicationno { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }

    }
}

