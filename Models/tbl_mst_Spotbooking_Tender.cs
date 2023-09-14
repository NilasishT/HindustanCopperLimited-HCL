using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_Spotbooking_Tender
    {
        [Key]
        public int Pk_int_tenderid { get; set; }
        public int fk_productid { get; set; }
        public int fk_unit { get; set; }
        public string str_quantity { get; set; }
        public string str_resevedprice { get; set; }
        public string str_currency { get; set; }
        public string str_upload { get; set; }
        public DateTime? dt_closingtime { get; set; }
        //public DateTime? dt_closingdate { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public string is_active { get; set; }
    }
}



