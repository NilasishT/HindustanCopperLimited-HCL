using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Company
    {

        [Key]
        public int pk_CompanyStatusID { get; set; }
        public string strCompanyStatusName { get; set; }
    }
}