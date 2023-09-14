using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class VendorRegistration
    {

        [Key]
        public int Pk_intNewVendorRegistrationID { get; set; }
        public string strVendorRegistrationID { get; set; }
        public string Fk_intUnitId { get; set; }

        [Required(ErrorMessage = "Required")]
        public string strNameofFirmCompany { get; set; }
        [Required(ErrorMessage = "Required")]
        public string strCorrespondenceAddress { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"[-+]?[0-9]*\.?[0-9]?[0-9]", ErrorMessage = "Number required.")]
        //[StringLength(11, ErrorMessage = "The STD Code with Phone must contains 11 digits", MinimumLength = 11)]
        public string strPhone1 { get; set; }


        public string strFax1 { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string strEmail1 { get; set; }


        public string strWebsite1 { get; set; }
        [Required(ErrorMessage = "Required")]
        public string strstrRegisteredOfficeAddress { get; set; }

        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"[-+]?[0-9]*\.?[0-9]?[0-9]", ErrorMessage = "Number required.")]
        //[StringLength(11, ErrorMessage = "The STD Code with Phone must contains 11 digits", MinimumLength = 11)]
        public string strPhone2 { get; set; }

        public string strFax { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string strEmail2 { get; set; }


        public string strWebsite2 { get; set; }

        public string strFactoryAddress { get; set; }


        //[StringLength(11, ErrorMessage = "The STD Code with Phone must contains 11 digits", MinimumLength = 11)]
        public string strPhone3 { get; set; }

        public string strReferenceUpload1 { get; set; }
        public string strReferenceUpload2 { get; set; }
        public string strReferenceUpload3 { get; set; }
        public string strReferenceUpload4 { get; set; }
        public string strReferenceUpload5 { get; set; }

        public string strFax2 { get; set; }
        //public string strFax2 { get; set; }

       // public string strFax2 { get; set; }
        [Required(ErrorMessage = "Required")]
        public string strNameContactPerson { get; set; }
        [Required(ErrorMessage = "Required")]
        public string strDesignationofContactPerson { get; set; }

        
        public string strNameContactPerson1 { get; set; }
        public string strDesignationofContactPerson1 { get; set; }
        public string strGSTNo { get; set; }

        public string strSTD4 { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"[-+]?[0-9]*\.?[0-9]?[0-9]", ErrorMessage = "Number required.")]
        //[StringLength(11, ErrorMessage = "The STD Code with Phone must contains 11 digits", MinimumLength = 11)]
        public string strPhoneoffice { get; set; }
        //[RegularExpression(@"[-+]?[0-9]*\.?[0-9]?[0-9]", ErrorMessage = "Number required.")]
        //[StringLength(11, ErrorMessage = "The STD Code with Phone must contains 11 digits", MinimumLength = 11)]
        public string strPhoneResidence { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression(@"[-+]?[0-9]*\.?[0-9]?[0-9]", ErrorMessage = "Number required.")]
        //[StringLength(10, ErrorMessage = "The Mobile must contains 10 digits", MinimumLength = 10)]
        public string strMobile { get; set; }
        [Required(ErrorMessage = "Required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string strEmail { get; set; }

        public int? fk_intConstitutionFirmID { get; set; }
        public string strConstitutionofthefirmfile1 { get; set; }
        public string strConstitutionofthefirmfile2 { get; set; }
        public int? int_fk_CompanyStatusID { get; set; }
        public string strYearofEstablishment { get; set; }
        public string strTypeofIndustry { get; set; }
        public int? intfk_CasteID { get; set; }
        public string strIfOtherpleaseindicatetheTypeofIndustry { get; set; }
        public string strTypeofIndustryfile1 { get; set; }
        public string strcategoryMSMED { get; set; }

        public string strUANCertificateNo { get; set; }
        public string strUANCertificateValidity { get; set; }
        public string strSSICertificateNo { get; set; }
        public string strSSICertificateValidity { get; set; }
        public string strNSICCertificateNo { get; set; }
        public string strNSICCertificateValidity { get; set; }
        public string strAcknowledgementtoEntrepreneurCertificateNo { get; set; }
        public string strAcknowledgementtoEntrepreneurCertificateValidity { get; set; }
        public string strAnyotherGovtBodyCertificateNo { get; set; }
        public string strAnyotherGovtBodyCertificateValidity { get; set; }


        public string strCSTRegistrationNo { get; set; }
        public string strCSTRegistrationdocument { get; set; }
        public string strST_VATRegistrationNo { get; set; }
        public string strST_VATRegistrationdocument { get; set; }
        public string strExciseControlCode { get; set; }
        public string strExciseControldocument { get; set; }
        public string strTradeLicenceNo { get; set; }
        public string strTradeLicencedocument { get; set; }
        public string strServiceTaxRegistrationNo { get; set; }
        public string strServiceTaxRegistrationdocument { get; set; }
        public string strPANNo { get; set; }
        public string strPANNodocument { get; set; }

        public string strItemDescription1 { get; set; }
        public string strItemDescription2 { get; set; }
        public string strItemDescription3 { get; set; }
        public string strItemDescription4 { get; set; }
        public string strItemDescription5 { get; set; }

        public string strLOV1 { get; set; }
        public string strLOV2 { get; set; }
        public string strLOV3 { get; set; }
        public string strLOV4 { get; set; }
        public string strLOV5 { get; set; }

        public string strDescriptionofMachineEquipment1 { get; set; }
        public string strDescriptionofMachineEquipment2 { get; set; }
        public string strDescriptionofMachineEquipment3 { get; set; }
        public string strDescriptionofMachineEquipment4 { get; set; }
        public string strDescriptionofMachineEquipment5 { get; set; }

        public string strQuantity1 { get; set; }
        public string strQuantity2 { get; set; }
        public string strQuantity3 { get; set; }
        public string strQuantity4 { get; set; }
        public string strQuantity5 { get; set; }

        public string strSpecificationCapacity1 { get; set; }
        public string strSpecificationCapacity2 { get; set; }
        public string strSpecificationCapacity3 { get; set; }
        public string strSpecificationCapacity4 { get; set; }
        public string strSpecificationCapacity5 { get; set; }

        public string strISOaccredited { get; set; }
        public string strISOaccrediteddocument { get; set; }

        public string strproductscertifiedtoBIS { get; set; }

        public string strNameofyourBanker { get; set; }
        public string strAddressofyourBanker { get; set; }
        public string strAccountNo { get; set; }
        public string strMICRCode { get; set; }
        public string strIFSCCode { get; set; }
        public string strFinancialYear1 { get; set; }
        public string strTurnover1 { get; set; }
        public string strFinancialYear2 { get; set; }
        public string strTurnover2 { get; set; }
        public string strFinancialYear3 { get; set; }
        public string strTurnover3 { get; set; }

        public string strRegistrationApplied { get; set; }
        public string strMachineryDocument { get; set; }





        public string strdesItemsSupplied1 { get; set; }
        public string strdesItemsSupplied2 { get; set; }
        public string strdesItemsSupplied3 { get; set; }
        public string strdesItemsSupplied4 { get; set; }
        public string strdesItemsSupplied5 { get; set; }

        public string strnameofmajorcustomer1 { get; set; }
        public string strnameofmajorcustomer2 { get; set; }
        public string strnameofmajorcustomer3 { get; set; }
        public string strnameofmajorcustomer4 { get; set; }
        public string strnameofmajorcustomer5 { get; set; }


        public string strContractualdelivery1 { get; set; }
        public string strContractualdelivery2 { get; set; }
        public string strContractualdelivery3 { get; set; }
        public string strContractualdelivery4 { get; set; }
        public string strContractualdelivery5 { get; set; }


        public string strActualdeliveryperiod1 { get; set; }
        public string strActualdeliveryperiod2 { get; set; }
        public string strActualdeliveryperiod3 { get; set; }
        public string strActualdeliveryperiod4 { get; set; }
        public string strActualdeliveryperiod5 { get; set; }


        public string strNameofApplicant { get; set; }

        public DateTime? dtApplicationDate { get; set; }
        public string strPlace { get; set; }

        public string strBalancesheetandProfitAndLoss { get; set; }
        public string strMajorPurchaseOrders { get; set; }

        public DateTime? dtEntryDate { get; set; }
        public DateTime? dtUpdateDate { get; set; }
        public string strActive { get; set; }
        public string strPending { get; set; }

        public string strComments { get; set; }

        public string strISOSpe { get; set; }
        public string strOtherConstitution { get; set; }

        public string strVerify { get; set; }
        public DateTime? dtVerifyDate { get; set; }
        public DateTime? dtActiveDate { get; set; }
        public DateTime? dtPendingDate { get; set; }

        public string Fk_intDepartment { get; set; }


        public string strMSMEDocument { get; set; }
        public string strFinancialYearDoc1 { get; set; }
        public string strFinancialYearDoc2 { get; set; }
        public string strFinancialYearDoc3 { get; set; }

    }
}
