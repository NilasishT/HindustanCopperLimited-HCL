using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstRTIScheme
    {
        [Key]
        public int pk_intRTISchemeId { get; set; }
        public string strApplicationNo { get; set; }
        public int fk_CandidateId { get; set; }
        public string strAnswer { get; set; }
        public DateTime dtEntryDate { get; set; }
    }
}