using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class Approvecandidtelist
    {
        public Approvecandidtelist()
        {
            List = new List<tbl_mst_Selectedcandidatedetails>();
        }

        public List<tbl_mst_Selectedcandidatedetails> List { get; set; }
    }
}