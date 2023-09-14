using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Hindustancopperlimited.Models
{
    public class CONTRACT_WORKMAN_DETAILS : DbContext
    {
        [Key]
        public int ID { get; set; }
       //Shoumya
        //[Required(ErrorMessage = "Required")]
        [DisplayName("Name")]
        public string NAME { get; set; }
        [DisplayName("Middlename")]
        public string MIDDLENAME { get; set; }
        //[Required(ErrorMessage = "Required")]
        [DisplayName("Surname")]
        public string SURNAME { get; set; }
        //[Required(ErrorMessage = "Required")]
        [DisplayName("Date of Birth")]
        public DateTime? DATEOFBIRTH { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Gender")]
        public string SEX { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Father Name")]
        public string FATHERNAME { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Employment Type")]
        public string EMPLOYMENTTYPE { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Designation")]
        public string DESIGNATION { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Wage Rate")]
        public double? WAGERATE { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Wage Period")]
        
        public string WAGEPERIOD { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Permanent Address")]
        public string PERMANENTADDRESS { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Permanent PIN Code")]
        public string PERMANENTPINCODE { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Present Address")]
        public string PRESENTADRESS { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Present PIN Code")]
        public string PRESENTPINCODE { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("PAN No.")]
        public string PANNO { get; set; }
        [DisplayName("Aadhar No.")]
        public string AADHARNO { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Mobile No.")]
        public string MOBILENO { get; set; }
        //shoumya
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        [DisplayName("Email")]
        
        public string EMAIL { get; set; }
        [DisplayName("PF Type")]
        public string PFTYPE { get; set; }
        [DisplayName("PF No.")]
        public string PFNO { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Bank A/c No.")]
        public string BANKACNO { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Caste")]
        public string CASTE { get; set; }
        [DisplayName("Educational Qualification")]
        public string EDUQUAL { get; set; }
        [DisplayName("Technical Qualification")]
        public string TECHQUAL { get; set; }
        [DisplayName("Date of Commencement")]
        public DateTime? DATEOFCOMMENCEMENT { get; set; }

        [DisplayName("Date of Termination/Not-Termination")]
        public DateTime? DATEOFTERMINATION { get; set; }
        [DisplayName("Reasons")]
        public string REASONS { get; set; }

        [DisplayName("Creationtime")]
        public DateTime? CREATIONTIME { get; set; }
        [DisplayName("Modification Time")]
        public DateTime? MODIFCATIONTIME { get; set; }

        [DisplayName("Contractor ID")]
        public int? CONTRACTORID { get; set; }
        [Required(ErrorMessage = "Required")]
        [DisplayName("Bank Name")]
        public string BANKNAME { get; set; }
        [DisplayName("PF Other")]
        public string PFOTHER { get; set; }
        [DisplayName("Nominee 1")]
        public string NOMINEE1 { get; set; }
        [DisplayName("Relation 1")]
        public string RELATION1 { get; set; }
        [DisplayName("Nominee 2")]
        public string NOMINEE2 { get; set; }
        [DisplayName("Relation 2")]
        public string RELATION2 { get; set; }
        [DisplayName("Nominee Other 1")]
        public string NOMINEEOTH1 { get; set; }
        [DisplayName("Nominee Other 2")]
        public string NOMINEEOTH2 { get; set; }
        [DisplayName("Workman Unique Identification Number")]
        public string WUIN { get; set; }
        [DisplayName("Initial Medical Examination Date")]
        public DateTime? INITMEDEXAMDATE { get; set; }
        [DisplayName("Periodical Medical Examination Date")]
        public DateTime? PRDMEDEXAMDATE { get; set; }
        [DisplayName("Vocational Training Date")]
        public DateTime? VTCTRNGDATE { get; set; }
        [DisplayName("Category Code")]
        public string CATCODE { get; set; }
        [DisplayName("UG Allowed")]
        public string UGALLOWED { get; set; }
        [DisplayName("UG Allowance Per %")]
        public double? UGALLOWEDPER { get; set; }
        [DisplayName("PF Allowed")]
        public string PFALLOWED { get; set; }
        [DisplayName("PF Per")]
        public double? PFPER { get; set; }
        [DisplayName("Pension Allowed")]
        public string PENSIONALLOWED { get; set; }
        [DisplayName("Pension Allowed Per")]
        public double? PENSIONALLOWEDPER { get; set; }
        [DisplayName("Additional Increment Allowed")]
        public string ADDLINCRALLOWED { get; set; }
        [DisplayName("Additional Increment %")]
        public double? ADDLINCRPER { get; set; }
        [DisplayName("Bonus Allowed")]
        public string BONUSALLOWED { get; set; }
        [DisplayName("Bonus Allowed Per")]
        public double? BONUSALLOWEDPER { get; set; }
        [DisplayName("Attd Bonus Allowed")]
        public string ATTDBONUSALLOWED { get; set; }
        [DisplayName("Attd Bonus Allowed Per")]
        public double? ATTDBONUSALLOWEDPER { get; set; }
        [DisplayName("Result Framework Document")]
        public string RFD { get; set; }
        [DisplayName("LOI")]
        public double? LOI { get; set; }
        [DisplayName("Photo")]
        public string PHOTO { get; set; }

        public string  ISTERMINATION { get; set; }

        [DisplayName("Employee State Insurance Number (ESI No.)")]
        public string ESINO { get; set; } 
    }
}



	


