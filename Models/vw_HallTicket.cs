using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_HallTicket
    {
        [Key]
        public int pk_intId { get; set; }
        public string strApplicationNo { get; set; }
        public string Emptitle { get; set; }
        public string DisciplineName { get; set; }
        public string Postname { get; set; }
        public string strApplicantName { get; set; }
        public string strCorrespondenceAddress { get; set; }
        public string strState { get; set; }
        public string strDistrict { get; set; }
        public string strPin { get; set; }
        public string strHallTicketNo { get; set; }
        public string strVenue { get; set; }

        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Pincode { get; set; }
        public string Phone { get; set; }

        public string strDate { get; set; }
        public string strTime { get; set; }
        public string str_uploadphoto { get; set; }
        public string str_uploadsignature { get; set; }
    }
}