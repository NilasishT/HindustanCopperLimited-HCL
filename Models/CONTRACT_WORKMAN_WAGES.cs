using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Hindustancopperlimited.Models
{
    public class CONTRACT_WORKMAN_WAGES : DbContext
    {
        [Key]
            public int ID { get; set; }

            [DisplayName("Contractor ID")]
            public double? CONTRACTORID { get; set; }
            [DisplayName("Workman")]
            public double? WORKMANID { get; set; }
            [DisplayName("Month")]
            public string MNTH { get; set; }
            [DisplayName("Year")]
            public string YEAR { get; set; }
            [DisplayName("Attendance")]
            public double? ATTENDANCE { get; set; }
            [DisplayName("Wage Rate")]
            public double? WAGERATE { get; set; }
            [DisplayName("Others")]
            public string OTHERS { get; set; }
            [DisplayName("Total Deduction")]
            public double? TOTALDEDUCTION { get; set; }
            [DisplayName("Net Amount")]
            public decimal NETAMOUNT { get; set; }
            [DisplayName("Bank Deposit Date")]
            public DateTime? BANKDEPOSITDATE { get; set; }
            public string REMARKS { get; set; }
            [DisplayName("Work Order")]
            public double? WORKORDERID { get; set; }

            [DisplayName("Location")]
            public double? LOCATIONID { get; set; }
            [DisplayName("Absent Days")]
            public double? ABSENTDAYS { get; set; }
            [DisplayName("PF Deposit Date")]
            public DateTime? PFDEPOSITDATE { get; set; }

            [DisplayName("Basic Pay")]
            public double? BASICPAY { get; set; }
            [DisplayName("VDA")]
            public double? VDA { get; set; }
            [DisplayName("SDA")]
            public double? SDA { get; set; }

            [DisplayName("UG Allow")]
            public double? UGALLOW { get; set; }
            [DisplayName("Bonus")]
            public double? BONUS { get; set; }
            [DisplayName("PF Gross")]
            public double? PFGROSS { get; set; }

            [DisplayName("Attendance Bonus")]
            public double? ATTENDANCEBONUS { get; set; }
            [DisplayName("Pension")]
            public double? PENSION { get; set; }
            [DisplayName("Addlincr")]
            public double? ADDLINCR { get; set; }
            [DisplayName("Gross")]
            public double? GROSS { get; set; }
            [DisplayName("Netpay")]
            public double? NETPAY { get; set; }

            [DisplayName("PF")]
            public double? PF { get; set; }
            [DisplayName("Other Allowance")]
            public double? OTHERALLOWANCE { get; set; }
            [DisplayName("OT Wages")]
            public double? OTWAGES { get; set; }
            [DisplayName("Normal Wages Earned")]
            public double? NORMALWAGESEARNED { get; set; }
            [DisplayName("Other Deduction")]
            public double? OTHERDEDUCTION { get; set; }
            [DisplayName("Cat Code")]
            public string CATCODE { get; set; }
            [DisplayName("Creation Date")]
            public DateTime? CREATIONDATE { get; set; }
            [DisplayName("Modification Date")]
            public DateTime? MODIFICATIONDATE { get; set; }
            public DateTime? APPROVALDATE { get; set; }
            public string APPROVALBY { get; set; }
            public string APPROVED { get; set; }
        
    }
}









