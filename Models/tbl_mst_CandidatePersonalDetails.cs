using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Globalization;
using System.Reflection;
using System.Web.Mvc;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_CandidatePersonalDetails
    {
        [Key]
        public int Pk_int_CandidateRegistrationID { get; set; }
        public int? fk_CandidateId { get; set; }
        [Required]
        public string strApplicantName { get; set; }
        [Required]
        public DateTime? dtDOB { get; set; }
        public string strFatherName { get; set; }
        [Required]
        public string strEmail { get; set; }
        [Required]
        public string strNationality { get; set; }
        [Required]
        public string strGender { get; set; }
        [Required]
        public string strCategory { get; set; }
        [Required]
        public string strMaritalStatus { get; set; }
        [Required]
        public string strPWD { get; set; }
        public string strExserviceMan { get; set; }
        [Required]
        public string strInternalCandidate { get; set; }
        [Required]
        public string strEmployedIn { get; set; }
        [Required]
        public string strCorrespondenceAddress { get; set; }
        [Required]
        public string strState { get; set; }
        [Required]
        public string strDistrict { get; set; }
        public string strNearestPostOffice { get; set; }
        public string strNearestPoliceStation { get; set; }
        [Required]
        public string strNearestRailwaystation { get; set; }
        [Required]
        public string strPin { get; set; }
        public string strTelephone { get; set; }
        public string strMobileNo { get; set; }
        [Required]
        public string strPermanentAddress { get; set; }
        [Required]
        public string strPermanentState { get; set; }
        [Required]
        public string strPermanentDistrict { get; set; }
        public string strPermanentNearestPostOffice { get; set; }
        public string strPermanentNearestPoliceStation { get; set; }
        [Required]
        public string strPermanentNearestRailwayStation { get; set; }
        [Required]
        public string strPermanentPinCode { get; set; }
        public string strPermanentTelephoneNo { get; set; }
        public string strPermanentMobile1 { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public bool? isactive { get; set; }

        [RequiredIfNot("strCategory", "General,OBC (Non-Creamy Layer)", "")]
        public string strsubcaste { get; set; }
        [RequiredIfNot("strCategory", "General,OBC (Non-Creamy Layer)", "")]
        public string strcertificateno { get; set; }
        [RequiredIfNot("strCategory", "General,OBC (Non-Creamy Layer)", "")]
        public DateTime? dt_certificateissuedate { get; set; }
        [RequiredIfNot("strCategory", "General,OBC (Non-Creamy Layer)", "")]
        public string strcertificateissue { get; set; }

        [RequiredIf("strExserviceMan", "Yes", "")]
        public string strexservicemanno { get; set; }


        public string strtypeofdisable { get; set; }

        public string strcertificateno1 { get; set; }

        public DateTime? dt_certificateissuedate1 { get; set; }

        public string strcertificateissue1 { get; set; }

        [RequiredIf("strInternalCandidate", "Yes", "")]
        public string stremployeecode { get; set; }
        [RequiredIf("strInternalCandidate", "Yes", "")]
        public string strgrade { get; set; }
        [RequiredIf("strInternalCandidate", "Yes", "")]
        public string strplaceposting { get; set; }
        [RequiredIf("strInternalCandidate", "Yes", "")]
        public string strpresentdesignation { get; set; }
        [RequiredIf("strInternalCandidate", "Yes", "")]
        public DateTime? dt_presententrydate { get; set; }


        [Required]
        public string strapplyproper { get; set; }
        [Required]
        public int? fk_postid { get; set; }

        public int? fk_dicipline { get; set; }
        public string strApplicationNo { get; set; }
        [Required]
        public string strDomicilestate { get; set; }
        public int? fk_advertiseid { get; set; }
        public string str_status { get; set; }
        public string is_freshers { get; set; }
        public string strMotherName { get; set; }
        public string strSpouseName { get; set; }
        public string strAlternate_EmaiID { get; set; }
        public string strPANNo { get; set; }
        public string strAadharNo { get; set; }
        public string strFinalSubmit { get; set; }
        public DateTime? dtFinalSubmitDate { get; set; }
        public int? CasteCategoryId { get; set; }
        public string strEssentialQualification { get; set; }
        public string strDisableDetail { get; set; }

        public string strSportsperson { get; set; }
    }

    public class tbl_mst_CandidatePersonalDetails_temp
    {
        [Key]
        public int Pk_int_CandidateRegistrationID { get; set; }
        public int? fk_CandidateId { get; set; }
        public string strApplicantName { get; set; }
        public DateTime? dtDOB { get; set; }
        public string strFatherName { get; set; }
        public string strEmail { get; set; }
        public string strNationality { get; set; }
        public string strGender { get; set; }
        public string strCategory { get; set; }
        public string strMaritalStatus { get; set; }
        public string strPWD { get; set; }
        public string strExserviceMan { get; set; }
        public string strInternalCandidate { get; set; }
        public string strEmployedIn { get; set; }
        public string strCorrespondenceAddress { get; set; }
        public string strState { get; set; }
        public string strDistrict { get; set; }
        public string strNearestPostOffice { get; set; }
        public string strNearestPoliceStation { get; set; }
        public string strNearestRailwaystation { get; set; }
        public string strPin { get; set; }
        public string strTelephone { get; set; }
        public string strMobileNo { get; set; }
        public string strPermanentAddress { get; set; }
        public string strPermanentState { get; set; }
        public string strPermanentDistrict { get; set; }
        public string strPermanentNearestPostOffice { get; set; }
        public string strPermanentNearestPoliceStation { get; set; }
        public string strPermanentNearestRailwayStation { get; set; }
        public string strPermanentPinCode { get; set; }
        public string strPermanentTelephoneNo { get; set; }
        public string strPermanentMobile1 { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public bool? isactive { get; set; }
        public string strsubcaste { get; set; }
        public string strcertificateno { get; set; }
        public DateTime? dt_certificateissuedate { get; set; }
        public string strcertificateissue { get; set; }
        public string strexservicemanno { get; set; }
        public string strtypeofdisable { get; set; }
        public string strcertificateno1 { get; set; }
        public DateTime? dt_certificateissuedate1 { get; set; }
        public string strcertificateissue1 { get; set; }
        public string stremployeecode { get; set; }
        public string strgrade { get; set; }
        public string strplaceposting { get; set; }
        public string strpresentdesignation { get; set; }
        public DateTime? dt_presententrydate { get; set; }
        public string strapplyproper { get; set; }
        public int? fk_postid { get; set; }
        public int? fk_dicipline { get; set; }
        public string strApplicationNo { get; set; }
        public string strDomicilestate { get; set; }
        public int? fk_advertiseid { get; set; }
        public string str_status { get; set; }

        public string is_freshers { get; set; }

        public string strMotherName { get; set; }
        public string strSpouseName { get; set; }
        public string strAlternate_EmaiID { get; set; }
        public string strPANNo { get; set; }
        public string strAadharNo { get; set; }

        public string strSportsperson { get; set; }
    }


    public class RequiredIfAttribute : ValidationAttribute
    {
        private String PropertyName { get; set; }
        private String ErrorMessage { get; set; }
        private Object DesiredValue { get; set; }

        public RequiredIfAttribute(String propertyName, Object desiredvalue, String errormessage)
        {
            this.PropertyName = propertyName;
            this.DesiredValue = desiredvalue;
            this.ErrorMessage = errormessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            if (proprtyvalue != null && proprtyvalue.ToString() == DesiredValue.ToString() && value == null)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }

    public class RequiredIfNotAttribute : ValidationAttribute
    {
        private String PropertyName { get; set; }
        private String ErrorMessage { get; set; }
        private Object DesiredValue { get; set; }

        public RequiredIfNotAttribute(String propertyName, Object desiredvalue, String errormessage)
        {
            this.PropertyName = propertyName;
            this.DesiredValue = desiredvalue;
            this.ErrorMessage = errormessage;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            //if (proprtyvalue != null && proprtyvalue.ToString() != DesiredValue.ToString() && value == null)
            if (proprtyvalue != null && DesiredValue.ToString().Split(',').Where(a => a != proprtyvalue.ToString()).FirstOrDefault() == null && value == null && DesiredValue.ToString() != "General")
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }

    public class NumericLessThanAttribute : ValidationAttribute
    {
        private const string lessThanErrorMessage = "{0} must be less than {1}.";
        private const string lessThanOrEqualToErrorMessage = "{0} must be less than or equal to {1}.";

        public string OtherProperty { get; private set; }

        private bool allowEquality;

        public bool AllowEquality
        {
            get { return this.allowEquality; }
            set
            {
                this.allowEquality = value;

                // Set the error message based on whether or not
                // equality is allowed
                this.ErrorMessage = (value ? lessThanOrEqualToErrorMessage : lessThanErrorMessage);
            }
        }

        public NumericLessThanAttribute(string otherProperty)
            : base(lessThanErrorMessage)
        {
            if (otherProperty == null) { throw new ArgumentNullException("otherProperty"); }
            this.OtherProperty = otherProperty;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, this.OtherProperty);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "Could not find a property named {0}.", OtherProperty));
            }

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);

            if (otherPropertyValue == null)
            {
                return null;
            }

            if (value == null)
            {
                return null;
            }

            decimal decValue;
            decimal decOtherPropertyValue;

            // Check to ensure the validating property is numeric
            if (!decimal.TryParse(value.ToString(), out decValue))
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", validationContext.DisplayName));
            }

            // Check to ensure the other property is numeric
            if (!decimal.TryParse(otherPropertyValue.ToString(), out decOtherPropertyValue))
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", OtherProperty));
            }

            // Check for equality
            if (AllowEquality && decValue == decOtherPropertyValue)
            {
                return null;
            }
            // Check to see if the value is greater than the other property value
            else if (decValue > decOtherPropertyValue)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return null;
        }

        public static string FormatPropertyForClientValidation(string property)
        {
            if (property == null)
            {
                throw new ArgumentException("Value cannot be null or empty.", "property");
            }
            return "*." + property;
        }


    }

    public class DateLessThanAttribute : ValidationAttribute
    {
        private const string lessThanErrorMessage = "{0} must be less than {1}.";
        private const string lessThanOrEqualToErrorMessage = "{0} must be less than or equal to {1}.";

        public string OtherProperty { get; private set; }

        private bool allowEquality;

        public bool AllowEquality
        {
            get { return this.allowEquality; }
            set
            {
                this.allowEquality = value;

                // Set the error message based on whether or not
                // equality is allowed
                this.ErrorMessage = (value ? lessThanOrEqualToErrorMessage : lessThanErrorMessage);
            }
        }

        public DateLessThanAttribute(string otherProperty)
            : base(lessThanErrorMessage)
        {
            if (otherProperty == null) { throw new ArgumentNullException("otherProperty"); }
            this.OtherProperty = otherProperty;
        }

        public override string FormatErrorMessage(string name)
        {
            return String.Format(CultureInfo.CurrentCulture, ErrorMessageString, name, this.OtherProperty);
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            PropertyInfo otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);

            if (otherPropertyInfo == null)
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "Could not find a property named {0}.", OtherProperty));
            }

            object otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);


            if (otherPropertyValue == null)
            {
                return null;
            }

            DateTime decValue;
            DateTime decOtherPropertyValue;


            // Check to ensure the validating property is numeric
            if (!DateTime.TryParse(value.ToString(), out decValue))
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", validationContext.DisplayName));
            }

            // Check to ensure the other property is numeric
            if (!DateTime.TryParse(otherPropertyValue.ToString(), out decOtherPropertyValue))
            {
                return new ValidationResult(String.Format(CultureInfo.CurrentCulture, "{0} is not a numeric value.", OtherProperty));
            }

            // Check for equality
            if (AllowEquality && decValue == decOtherPropertyValue)
            {
                return null;
            }
            // Check to see if the value is greater than the other property value
            else if (decValue > decOtherPropertyValue)
            {
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }

            return null;
        }

        public static string FormatPropertyForClientValidation(string property)
        {
            if (property == null)
            {
                throw new ArgumentException("Value cannot be null or empty.", "property");
            }
            return "*." + property;
        }


    }

    public class IfMaxValueAttribute : ValidationAttribute
    {
        private String PropertyName { get; set; }
        private string MainValue { get; set; }
        private Object DesiredValue { get; set; }

        public IfMaxValueAttribute(String propertyName, Object desiredvalue, string MainValue)
        {
            this.PropertyName = propertyName;
            this.DesiredValue = desiredvalue;
            this.MainValue = MainValue;
        }

        protected override ValidationResult IsValid(object value, ValidationContext context)
        {
            Object instance = context.ObjectInstance;
            Type type = instance.GetType();
            Object proprtyvalue = type.GetProperty(PropertyName).GetValue(instance, null);
            if (value != null && proprtyvalue.ToString() == DesiredValue.ToString() && value.ToString() != MainValue)
            {
                return new ValidationResult(ErrorMessage);
            }
            return ValidationResult.Success;
        }
    }

    public class MinLengthOrNullAttribute : ValidationAttribute
    {
        public int MinLength { get; set; }

        public MinLengthOrNullAttribute(int minLength)
        {
            MinLength = minLength;
        }

        public override Boolean IsValid(Object value)
        {
            return value == null || (value as string).Length == MinLength;
        }
    }
}
