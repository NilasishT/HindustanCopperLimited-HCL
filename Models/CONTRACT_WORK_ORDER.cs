using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;



namespace Hindustancopperlimited.Models
{
    public class CONTRACT_WORK_ORDER : DbContext
    {
        [Key]
        public int ID { get; set; }

        [DisplayName("Select the HCL Plant/Unit")]
        public int? WO_UNIT { get; set; }

        [DisplayName("Work Order No.")]
        public string WORKORDERNO { get; set; }

        [DisplayName("Name of Work")]
        public string NAMEOFTHEWORK { get; set; }

        [DisplayName("Establishment")]
        public string ESTABLISHMENT { get; set; }

        [DisplayName("Establishment Address")]
        public string ESTABLISHMENTADDRESS { get; set; }

        [DisplayName("Name of Company")]
        public string NAMEOFTHECOMPANY { get; set; }

        [DisplayName("Location of Work")]
        public string LOCATIONOFWORK { get; set; }

        [DisplayName("Date of Commencement")]
        public DateTime? DATEOFCOMMENCEMENT { get; set; }

        [DisplayName("Date of Completion Work")]
        public DateTime? DATEOFCOMPLETIONWORK { get; set; }

        [DisplayName("Maximum No. of Employees")]
        public int? MAXNOOFEMPLOYEES { get; set; }

        [DisplayName("Work Order Issued By")]
        public string WORKORDERISSUEDBY { get; set; }

        [DisplayName("Labour Licence")]
        public string LABOURLICENCE { get; set; }

        [DisplayName("Name of the Principal Employer")]
        public string NAMEOFTHEPRINCIPALEMPLOYER { get; set; }

        [DisplayName("Principal Employer Address")]
        public string PRINCIPALEMPLOYERADDRESS { get; set; }

        [DisplayName("Work Order Area")]
        public string WO_AREA { get; set; }

        [DisplayName("Work Order Headquarter")]
        public string WO_HQ { get; set; }

        [DisplayName("Work Order File")]
        public string WO_FILE { get; set; }

         [DisplayName("Remarks")]
        public string REMARKS { get; set; }



        public int? CONTRACTORID { get; set; }
        public string RFD { get; set; } 
        public DateTime? APPROVALDATE { get; set; }
        public string APPROVALBY { get; set; }
        public string APPROVED { get; set; }
        public string MODIFIEDBY { get; set; }
        public DateTime? MODIFICATIONDATE { get; set; }
        public string CREATEDBY { get; set; }
        public DateTime? CREATIONDATE { get; set; }


       
        
       


        

        

       

       

        

       

        
        
       
        
       
           
    }
}



	





