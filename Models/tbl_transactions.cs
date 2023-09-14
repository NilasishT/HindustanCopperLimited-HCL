using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_transactions
    {
        [Key]
        public int pk_intTransactionsId { get; set; }
        public string strTransactionsId { get; set; }
        public Nullable<int> fkintApplicantId { get; set; }
        public Nullable<int> fk_advertisementid { get; set; }
        public Nullable<int> fk_CandidateRegistrationID { get; set; }
        public string strApplicationNo { get; set; }
        public Nullable<decimal> decHCLAmount { get; set; }
        public Nullable<decimal> decPayuAmount { get; set; }
        public string strMihPayId { get; set; }
        public string strMode { get; set; }
        public string strStatus { get; set; }
        public string strError { get; set; }
        public string strPgType { get; set; }
        public string strBankRefNum { get; set; }
        public string strUnmappedstatus { get; set; }
        public string strPayUMoneyId { get; set; }
        public Nullable<System.DateTime> dtTransactionsDate { get; set; }
    }
}