using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CandidateTransitionCertificateDetailsContext : DbContext
    {
        public tbl_mst_CandidateTransitionCertificateDetailsContext() : base("name=HclEntities")
        {
        }
        public DbSet<tbl_mst_CandidateTransitionCertificateDetails> tbl_mst_CandidateTransitionDetails { get; set; }
    }
    public class tbl_mst_CandidateTransitionCertificateDetails
    {
        [Key]
        public int Id { get; set; }
        public int? fk_CandidateId { get; set; }
        public string TransitionCertificateName { get; set; }
        public string InstitueName { get; set; }
        public string TransitionIssueDate { get; set; }
        public string TransitionExpiryDate { get; set; }
        public string Remark { get; set; }
        //public string str_Certificate_New { get; set; }
        public string Application_No { get; set; }
        public int? fk_advertiseid { get; set; }

        public DateTime? dt_entrydate { get; set; }

    }
}