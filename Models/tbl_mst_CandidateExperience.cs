using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CandidateExperience
    {
        [Key]
        public int Pk_Experienceid { get; set; }
        public int Fk_CandidateRegistrationID { get; set; }
        public string Str_designation { get; set; }
        public DateTime dt_fromdate { get; set; }
        public DateTime dt_todate { get; set; }
        public string str_noyears { get; set; }
        public string str_organisation { get; set; }
        public string str_remarks { get; set; }
        public DateTime? dtEntyDate { get; set; }
        public string ApplicationNo { get; set; }
        public string str_organisationType { get; set; }
        public string str_CTC { get; set; }
        public string str_PayScale { get; set; }
        public string StrEmploymentPresentStatus { get; set; }

        public string str_UploadExpCertificate { get; set; }

        public int? fk_advertiseid { get; set; }


        public string str_PresentEmployerName { get; set; }

        public string str_PresentGrade { get; set; }

        public string dt_DateOfEntryGrade { get; set; }

        public string dt_DateOfEntryScalePay { get; set; }


        public string str_MonthlyGrossSalary { get; set; }

        public string str_OrgTurnover { get; set; }

        public string str_JobDescription { get; set; }

        public string str_UploadPLStatement { get; set; }

        public string str_UploadJobDesc { get; set; }


        public string str_UploadOtherDoc { get; set; }


        public string str_PvtEmployerName { get; set; }

        public string str_PvtJobDesignation { get; set; }

        public string str_GovtJobDesignation { get; set; }


        public string str_PvtUploadOtherDoc { get; set; }


        public string str_PvtUploadJobDesc { get; set; }

        public string str_PvtJobDescription { get; set; }


        public string str_ScaleOfPay { get; set; }


        public string str_RegistrationNo { get; set; }

        public string str_stateMedicalcouncil { get; set; }


        public DateTime dt_RegistrationValidTill { get; set; }

        public string str_uploadregistrationCertificate { get; set; }




    }

    public class tbl_mst_CandidateExperience_temp
    {
        [Key]
        public int Pk_Experienceid { get; set; }
        public int Fk_CandidateRegistrationID { get; set; }
        public string Str_designation { get; set; }
        public DateTime dt_fromdate { get; set; }
        public DateTime dt_todate { get; set; }
        public string str_noyears { get; set; }
        public string str_organisation { get; set; }
        public string str_remarks { get; set; }
        public DateTime? dtEntyDate { get; set; }
        public string ApplicationNo { get; set; }
        public string str_organisationType { get; set; }
        public string str_CTC { get; set; }
        public string str_PayScale { get; set; }
        public string StrEmploymentPresentStatus { get; set; }





    }
}