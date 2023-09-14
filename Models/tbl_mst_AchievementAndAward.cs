using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_AchievementAndAward
    {
        [Key]
        public int Pk_intAwardID { get; set; }
        public string strSubjectdfsEnglish { get; set; }
        public string strDescriptiondfsEnglish { get; set; }
        public DateTime? dtAwardDate { get; set; }
        public DateTime? dtExpiryDate { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public string strAwardFile { get; set; }
        public bool? IsActive { get; set; }
        public string strSubjectdfsHindi { get; set; }
        public string strDescriptiondfsHindi { get; set; }
    }
}