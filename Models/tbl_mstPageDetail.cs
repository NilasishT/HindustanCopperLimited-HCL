using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstPageDetail
    {
        [Key]
        public int Pk_intAllStaticPageID { get; set; }
        public string strPageTitle { get; set; }
        public string strPageDetails { get; set; }

        public string strHindiPageTitle { get; set; }
        public string strHindiPageDetails { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public Boolean IsActive { get; set; }


    }
}