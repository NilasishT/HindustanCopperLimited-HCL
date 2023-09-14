using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class vw_EligibleListGraduate
    {
        [Key]
        public int intCandidateId { get; set; }
        public int intAdvId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string RegNo { get; set; }
        public double Percentage { get; set; }
        public string Unit { get; set; }
        public string Trade { get; set; }
        public string AcknowledgementNo { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string PIN { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}