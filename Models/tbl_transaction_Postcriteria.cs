using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_transaction_Postcriteria
    {
        [Key]
        public int Pk_criteriaid { get; set; }
        public int fk_advertisementid { get; set; }
        public int fk_postid { get; set; }
        public int fk_diciplineid { get; set; }

        public string str_gender { get; set; }
        public string str_caste { get; set; }
        public string str_pwd { get; set; }
        public string str_qualification { get; set; }
        public string str_postCTC { get; set; }
        public string str_postGrade { get; set; }
        public string str_postMinage { get; set; }
        public string str_postMaxage { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public DateTime? dt_compareDate { get; set; }
        public DateTime? dt_compareDateExperience { get; set; }
        public Int64? intvacancy { get; set; }
        public string strExServicemen { get; set; }
        public string str_postMinageExperience { get; set; }
        public string str_postMaxageExperience { get; set; }
        public DateTime? dt_compareDateExperienceforJob { get; set; }
        public string strPostIsFreshersAllowed { get; set; }
        public string strPostPaySacle { get; set; }
        public bool IsGATERequired { get; set; }
    }

    public class Qulification
    {
        public string str_qualification { get; set; }
    }
}

