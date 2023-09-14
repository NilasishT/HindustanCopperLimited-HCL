using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_state
    {
        [Key]
        public int Pk_stateid { get; set; }
        public string statename { get; set; }
    }
}