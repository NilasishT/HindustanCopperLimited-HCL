using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_Postdesiciplinedetails
    {
        public int Pk_Disciplineid { get; set; }
        public string DisciplineName { get; set; }
        public string DisciplineDescription { get; set; }
        public bool? IsActive { get; set; }
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
        public Int64? intvacancy { get; set; }
        public string str_postCTC { get; set; }
        public string str_postGrade { get; set; }
        public string str_postMinage { get; set; }
        public string str_postMaxage { get; set; }
        public int? Pk_Postid { get; set; }
        public int? fk_discipline { get; set; }
        public string Postname { get; set; }
        public string str_Grade { get; set; }
        public string Payscale { get; set; }
        public string Is_active { get; set; }
        public string str_ctc { get; set; }
        public string str_minage { get; set; }
        public string str_maxage { get; set; }
        public string Emptitle { get; set; }
        public string Empnoticeno { get; set; }
        //my param
        public string strExServicemen { get; set; }
        public DateTime? dtcompareDate { get; set; }
        public int? Fk_unitid { get; set; }

    }
}