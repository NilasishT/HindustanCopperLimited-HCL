using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CandidateDDDetails
    {
        [Key]
      public int pk_intDDId { get; set; }
      public int Fk_CandidateRegistrationID   { get ; set ; }
      public string strApplicationNo { get; set; }
      public string strOrderNo { get; set; }
      public string strIssuingBankName { get; set; }
      public string strIssuingBranch { get; set; }
      public decimal? decAmount { get; set; }
      public DateTime? dtEntryDate { get; set; }
      public DateTime? dtUpdateDate { get; set; }
      public DateTime? dtIssueDate { get; set; }


    }
}