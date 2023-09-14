using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class VendorsNew
    {
        [Key]
        public int Pk_intNewVendorRegistrationID { get; set; }
        public string strVendorRegistrationID { get; set; }
        //public string Fk_intUnitId { get; set; }

       
        public string strNameofFirmCompany { get; set; }

      
        public string strCorrespondenceAddress { get; set; }

      
       
        //[StringLength(11, ErrorMessage = "The STD Code with Phone must contains 11 digits", MinimumLength = 11)]
        public string strPhone1 { get; set; }


        //public string strFax1 { get; set; }
      
      
        public string strEmail1 { get; set; }


        public string strWebsite1 { get; set; }

        public string strstrRegisteredOfficeAddress { get; set; }

      
       
        ////[StringLength(11, ErrorMessage = "The STD Code with Phone must contains 11 digits", MinimumLength = 11)]
        //public string strPhone2 { get; set; }

        public string strFax { get; set; }
      
      
        //public string strEmail2 { get; set; }


        //public string strWebsite2 { get; set; }

        //public string strFactoryAddress { get; set; }


        ////[StringLength(11, ErrorMessage = "The STD Code with Phone must contains 11 digits", MinimumLength = 11)]
        //public string strPhone3 { get; set; }

        
        //public string strFax2 { get; set; }
        //public string strFax2 { get; set; }

       // public string strFax2 { get; set; }
      
        public string strNameContactPerson { get; set; }
      
        public string strDesignationofContactPerson { get; set; }

        
        public string strNameContactPerson1 { get; set; }
        public string strDesignationofContactPerson1 { get; set; }
        public string strGSTNo { get; set; }

        public string strSTD4 { get; set; }
      
       
        //[StringLength(11, ErrorMessage = "The STD Code with Phone must contains 11 digits", MinimumLength = 11)]
        public string strPhoneoffice { get; set; }
        //[RegularExpression(@"[-+]?[0-9]*\.?[0-9]?[0-9]", ErrorMessage = "Number required.")]
        //[StringLength(11, ErrorMessage = "The STD Code with Phone must contains 11 digits", MinimumLength = 11)]
        public string strPhoneResidence { get; set; }
      
       
        //[StringLength(10, ErrorMessage = "The Mobile must contains 10 digits", MinimumLength = 10)]
        public string strMobile { get; set; }
      
      
        public string strEmail { get; set; }

        public int? fk_intConstitutionFirmID { get; set; }        
        public int? int_fk_CompanyStatusID { get; set; }
        public string strIsManpowerSupplier { get; set; }

        public string strTypeofIndustry { get; set; }
        public int? intfk_CategoryID { get; set; }
        public string strPANNo { get; set; }
        
        public string strRegistrationApplied { get; set; }
        
        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public string strActive { get; set; }
        public string strPending { get; set; }

        public string strComments { get; set; }
        
        public string strVerify { get; set; }
        
        public string Fk_intDepartment { get; set; }

        public string Fk_intUnitId { get; set; }
        public string str_company_others { get; set; }
        public string str_companydesc { get; set; }

        public string str_serviceprovidertype { get; set; }

        public string str_city { get; set; }
        public string str_state { get; set; }
        public string str_country { get; set; }
        public string str_pin { get; set; }

     
    }
}
