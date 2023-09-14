using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_DraftData
    {
        [Key]
        public int Pk_int_CandidateRegistrationID { get; set; }
        public string AppStatus { get; set; }
        public int fk_CandidateId { get; set; }
    }
}