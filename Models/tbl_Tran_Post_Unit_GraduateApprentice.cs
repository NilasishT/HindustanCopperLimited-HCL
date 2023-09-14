using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_Tran_Post_Unit_GraduateApprentice
    {
        [Key]
        public int pk_intId { get; set; }
        public int fk_intUnitId { get; set; }
        public string strPostName { get; set; }
        public string strQualification { get; set; }
        public bool bitSC { get; set; }
        public bool bitST { get; set; }
        public bool bitOBC { get; set; }
        public bool bitGeneral { get; set; }
        public bool bitPWD { get; set; }
        public string strCategory { get; set; }
    }
}