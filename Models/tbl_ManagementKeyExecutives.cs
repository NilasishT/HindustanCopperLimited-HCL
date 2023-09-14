using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_ManagementKeyExecutives
    {
        [Key]
        public int pk_int_ManagementKeyExecutives { get; set; }
        public int intSlNo { get; set; }

        public string strOfficeType{ get; set; }
        public string strOfficeType_Hindi { get; set; }

        public string strName  { get; set; }   
        public string strname_Hindi { get; set; }

        public string strDesignation { get; set; }
        public string strDesignation_Hindi { get; set; }

        public string strReaponsibilityArea { get; set; }
        public string strReaponsibilityArea_Hindi { get; set; }       
       
        public string strPhone { get; set; }
        public string strEmailId { get; set; }

        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public string strStatus { get; set; }

    }
}