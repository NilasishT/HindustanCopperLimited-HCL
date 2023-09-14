using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstOrganisationType
    {
        [Key]
        public int pk_intOrganisationTypeId { get; set; }
        public string strOrganisationType { get; set; }
        public bool isActive { get; set; }
      

    }
}