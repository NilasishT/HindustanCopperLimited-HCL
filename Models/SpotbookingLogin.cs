using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class SpotbookingLogin
    {
        [Key]
        public int pk_intUserId { get; set; }
        public string strUserName { get; set; }
        public string strpw { get; set; }
        public string strIsActive { get; set; }
        public string str_email { get; set; }
        public DateTime? dtActivedate { get; set; }
        public DateTime? dtDeActiveDate { get; set; }
       
    }
}



