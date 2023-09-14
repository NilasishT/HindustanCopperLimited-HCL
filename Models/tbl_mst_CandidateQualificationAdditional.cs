

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CandidateQualificationAdditionalContext : DbContext
    {
        public tbl_mst_CandidateQualificationAdditionalContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<tbl_mst_CandidateQualificationAdditional> tbl_mst_CandidateQualificationAdditional { get; set; }
    }
    public class tbl_mst_CandidateQualificationAdditional
    {
        [Key]
        public int Id { get; set; }
        public int CandidateId { get; set; }
        public string Str_exampassed { get; set; }
        public string Str_course { get; set; }
        public string Str_board { get; set; }
        public string Str_passingdetails { get; set; }
        public string Str_duration { get; set; }
        public string Str_passingyear { get; set; }
        public string Str_division { get; set; }
        public string Str_Marks { get; set; }
        public string StrRemarks { get; set; }
        public string EduQulifi { get; set; }
        public DateTime? dtEntryDate { get; set; }
        public string Application_No { get; set; }

    }
}