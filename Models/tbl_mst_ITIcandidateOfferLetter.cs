using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_ITIcandidateOfferLetter
    {
        [Key]
        public int Pk_intITIOfferLetterId { get; set; }
        public string RegdNo { get; set; }
        public string Appportalregdno { get; set; }
        public string NAME { get; set; }
        public string FatherName { get; set; }
        public string EmailId { get; set; }
        public string Trade { get; set; }
        public string ApprenticeshipTrainingDuration { get; set; }
        public string InitialmonthlyrateofStipend { get; set; }
        public string Dateofdocumentvertification { get; set; }
        public string Reportingtime { get; set; }
    }
}