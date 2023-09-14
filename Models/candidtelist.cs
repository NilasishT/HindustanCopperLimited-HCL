using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class candidtelist
    {
        public candidtelist()
        {
            List = new List<tbl_mst_CandidatePersonalDetails>();
        }

        public List<tbl_mst_CandidatePersonalDetails> List { get; set; }
    }
}