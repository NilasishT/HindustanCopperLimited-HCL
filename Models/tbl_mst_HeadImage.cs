using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_HeadImage
    {
        [Key]
        public int pk_intHeadImageID { get; set; }
        public string strImageTitle { get; set; }
        public string strImagePath { get; set; }


        public string strHindiImageTitle { get; set; }
        public string strHindiImagePath { get; set; }


        public string strCategory { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdatedate { get; set; }

        public bool? IsActive { get; set; }
      

    }
}