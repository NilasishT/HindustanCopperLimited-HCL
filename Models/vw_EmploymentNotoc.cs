using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_EmploymentNotoc
    {
        public int Pk_employmentid { get; set; }
        public int Fk_unitid { get; set; }

        public string strEmploymentType { get; set; }

        public string PostList { get; set; }

        public string strPostid { get; set; }
        public string Empnoticeno { get; set; }
        public string Emptitle { get; set; }

        public string Empdetail { get; set; }

        public string Strupload { get; set; }
        public DateTime? dtstartdate { get; set; }
        public DateTime? dtclosedate { get; set; }
        public DateTime? dtviewdate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public DateTime? dtexpirydate { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public bool? isactive { get; set; }
    }
}