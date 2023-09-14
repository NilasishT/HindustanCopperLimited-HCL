using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CandidateCertificateDetailsContext : DbContext
    {
        public tbl_mst_CandidateCertificateDetailsContext() : base("name=HclEntities")
        {
        }
        public DbSet<tbl_mst_CandidateCertificateDetails> tbl_mst_CandidateCertificateDetails { get; set; }
    }
    public class tbl_mst_CandidateCertificateDetails
    {
        [Key]
        public int Id { get; set; }
        public int? fk_CandidateId { get; set; }
        public string CertificateName { get; set; }
        public string CertificateNo { get; set; }
        public string CertificateIssueDate { get; set; }

        public string CertificateExpiryDate { get; set; }
        public string IssuingAuthority { get; set; }

        
    }
}