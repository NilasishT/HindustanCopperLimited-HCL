using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstWorkmanDetails
    {
        [Key]
        public int pk_WorkmanDetailsid { get; set; }
        [DisplayName("Employee Code")]
        public string strEmpCode { get; set; }
        [DisplayName("Name")]
        public string strName { get; set; }
        [DisplayName("Surname")]
        public string strSName { get; set; }
        [DisplayName("Father's Name")]
        public string strFName { get; set; }
        [DisplayName("DOB")]
        public DateTime dtDOB { get; set; }
        [DisplayName("Gender")]
        public string strGenger { get; set; }
        [DisplayName("Designation")]
        public string strDesignation { get; set; }
        [DisplayName("Type of Contractor")]
        public string strTypeofCont { get; set; }
        [DisplayName("Category")]
        public string strCategory { get; set; }
        [DisplayName("Work Order")]
        public string strWorkOrder { get; set; }
        [DisplayName("Address")]
        public string strAddress { get; set; }
        [DisplayName("Mobile No.")]
        public string strMobileNo { get; set; }
        [DisplayName("Email Id")]
        public string strEmailId { get; set; }
        [DisplayName("Pan No.")]
        public string strPanNo { get; set; }
        [DisplayName("Aadhar No.")]
        public string strAadharNo { get; set; }
        [DisplayName("Name of Bank")]
        public string strNameofBank { get; set; }
        [DisplayName("Bank Account No.")]
        public string strBankACNo { get; set; }
        [DisplayName("Select Photo")]
        public string strPhotopath { get; set; }
        [DisplayName("Reason of Termination")]
        public string strReasonofTermi { get; set; }
        [DisplayName("Date of Termination")]
        public Nullable<System.DateTime> dtTerminate { get; set; }
        public Nullable<bool> isActive { get; set; }
        public Nullable<System.DateTime> dtAddedDate { get; set; }
        public Nullable<System.DateTime> dtUpdateDate { get; set; }

    }
}