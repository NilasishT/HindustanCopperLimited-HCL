using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_OrderTypes
    {
        [Key]
        public int pk_intOrderTypeId { get; set; }
        public string strOrderType { get; set; }
    }
}