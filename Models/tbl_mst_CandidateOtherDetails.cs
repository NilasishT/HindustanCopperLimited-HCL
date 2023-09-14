using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CandidateOtherDetails
    {
        [Key]
      public int pk_intOtherDetails { get; set; }
      public int Fk_CandidateRegistrationID   { get ; set ; }
      public string strApplicationNo { get; set; }
      public string strProfessionalBodies { get; set; }
      public string strJoiningTimeReq { get; set; }
      public string strJoinEarly { get; set; }
      public DateTime? dtEntyDate { get; set; }


    }


    public class tbl_mst_CandidateOtherDetails_temp
    {
        [Key]
        public int pk_intOtherDetails { get; set; }
        public int Fk_CandidateRegistrationID { get; set; }
        public string strApplicationNo { get; set; }
        public string strProfessionalBodies { get; set; }
        public string strJoiningTimeReq { get; set; }
        public string strJoinEarly { get; set; }
        public DateTime? dtEntyDate { get; set; }


    }
}