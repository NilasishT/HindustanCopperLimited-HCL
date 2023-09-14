using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class vw_CONTRACT_WORKMAN_WORK
    {
        [Key]
        public int ID { get; set; }
        public DateTime? ENDDATE { get; set; }
        public DateTime? STARTDATE { get; set; }
        public string WORKORDERNO { get; set; }
        public string NAMEOFTHEWORK { get; set; }
        public string NAMEOFTHECOMPANY { get; set; }
        public string strNameofFirmCompany { get; set; }
        public string strVendorRegistrationID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string MIDDLENAME { get; set; }
        public DateTime? DATEOFBIRTH { get; set; }
        public string SEX { get; set; }
        public string FATHERNAME { get; set; }
        public string EMPLOYMENTTYPE { get; set; }
        public string DESIGNATION { get; set; }
        public int CONTRACTORID { get; set; }
        public int WorkorderId { get; set; }
        public int WORKMANID { get; set; }
    }
}