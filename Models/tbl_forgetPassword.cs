using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_forgetPassword
    {
        [Key]
        public int pk_Id { get; set; }
        public int intCandidateId { get; set; }
        public string strAutoId { get; set; }
        public DateTime? dtDatetime { get; set; }
    }
}