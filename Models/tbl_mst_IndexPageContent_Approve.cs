using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_IndexPageContent_Approve
    {
        [Key]
        public int pk_intIndexApproveID { get; set; }

        public int pk_intIndexID { get; set; }

        public string strMainBrief { get; set; }
        public string strHindiMainBrief { get; set; }

        public string strVisionMission { get; set; }
        public string strHindiVisionMission { get; set; }

        public string strPlantFacility { get; set; }
        public string strHindiPlantFacility { get; set; }

        public string strManagement { get; set; }
        public string strHindiManagement { get; set; }

        public bool? IsActive { get; set; }
        public DateTime? dtEntrydate { get; set; }
        public DateTime? dtUpdatedate { get; set; }

        public int intUserId { get; set; }

        


    }

}