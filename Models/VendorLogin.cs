using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class VendorLogin
    {
        [Key]
        public int pk_intVendorUserId { get; set; }
        public string strUserName { get; set; }
        public string strUserPwd { get; set; }
        public string strIsActive { get; set; }
        public DateTime? dtActivedate { get; set; }
        public DateTime? dtUpdatedate { get; set; }
        public DateTime? dtDeActiveDate { get; set; }
        public string strusertype { get; set; }
        public string Fk_intUnitId { get; set; }

    }





}