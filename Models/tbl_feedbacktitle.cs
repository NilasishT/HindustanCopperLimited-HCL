using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_feedbacktitle
    {
        [Key]
       public int Pk_feedbacktitleid { get; set; }

       public string strtitle_name { get; set; }
    }
}