using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_Eventsimagedetails
    {
         [Key]
        public int pk_int_imagedetails { get; set; }
        public int fk_int_eventid { get; set; }
        public string str_uploadfile { get; set; }
        public string is_active { get; set; }
    }
}
