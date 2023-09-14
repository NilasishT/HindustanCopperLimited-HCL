using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class tblRecruitmentCandidateGATEDetailsContext : DbContext
    {
        public tblRecruitmentCandidateGATEDetailsContext() : base("name=HclEntities")
        {
        }
        public DbSet<tblRecruitmentCandidateGATEDetails> tblRecruitmentCandidateGATEDetails { get; set; }
    }
    public class tblRecruitmentCandidateGATEDetails
    {
        [Key]
        public int Id { get; set; }
        public int PassingYear { get; set; }
        public string RegistrationNo { get; set; }
        public string ExaminationPaper { get; set; }
        public string str_GATEResult { get; set; }
        public decimal? Marks { get; set; }
        //public string Division { get; set; }
        //public string Remark { get; set; }
        //public string EssentialQualificationForPost { get; set; }
        //public decimal? EssentialQualificationPercentageForPost { get; set; }
        public int CandidateId { get; set; }
        public int PostId { get; set; }
    }
    
}