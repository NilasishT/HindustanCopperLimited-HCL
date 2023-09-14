using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_AdvertisementNotice
    {
        public int Pk_criteriaid { get; set; }
        public int fk_advertisementid { get; set; }
        public int fk_postid { get; set; }
        public int fk_diciplineid { get; set; }
        public string str_gender { get; set; }
        public string str_caste { get; set; }
        public string str_pwd { get; set; }
        public string str_qualification { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public string str_vacancy { get; set; }
        public string str_postCTC { get; set; }
        public string str_postGrade { get; set; }
        public string str_postMinage { get; set; }
        public string str_postMaxage { get; set; }
        public int Pk_employmentid { get; set; }
        public int Fk_unitid { get; set; }
        public string strPostid { get; set; }
        public string strEmploymentType { get; set; }
        public string Empnoticeno { get; set; }
        public string Emptitle { get; set; }
        public string Empdetail { get; set; }
        public string Strupload { get; set; }
        public DateTime? dtstartdate { get; set; }
        public DateTime? dtclosedate { get; set; }
        public DateTime? dtviewdate { get; set; }
        public DateTime? dtexpirydate { get; set; }
        public bool? isactive { get; set; }
        public DateTime? dtUpdateDate { get; set; }

    }
}

