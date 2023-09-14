using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class RegionUser
    {
        [Key]
        public int pk_intRegionUserId { get; set; }
        public string strUserName { get; set; }
        public string strUserPwd { get; set; }
        public string strDesignation { get; set; }
        public string strEmail { get; set; }
        public DateTime? dtEntrydate { get; set; }
        public DateTime? dtUpdatedate { get; set; }
        public string strusertype { get; set; }
        public string strRegion { get; set; }
        public string strMenuRightID { get; set; }

    }




   

}