using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class vw_CONTRACT_WORKMAN_WAGES : DbContext
    {
    [Key]
    public int ID { get; set; }

    public string NAME { get; set; }
    public string SURNAME { get; set; }
    public string strVendorRegistrationID { get; set; }

    public double? CONTRACTORID { get; set; }
    public double? WORKMANID { get; set; }
    public string MNTH { get; set; }
    public string YEAR { get; set; }      
    public double? ATTENDANCE { get; set; }
    public double? WAGERATE { get; set; }
    public string OTHERS { get; set; }
    public double? TOTALDEDUCTION { get; set; }
    public decimal? NETAMOUNT { get; set; }
    public DateTime? BANKDEPOSITDATE { get; set; }
    public string REMARKS { get; set; }        
    public double? WORKORDERID { get; set; }

    public double? LOCATIONID { get; set; }
    public double? ABSENTDAYS { get; set; }
    public DateTime? PFDEPOSITDATE { get; set; }

    public double? BASICPAY { get; set; }
    public double? VDA { get; set; }
    public double? SDA { get; set; }

    public double? UGALLOW { get; set; }
    public double? BONUS { get; set; }
    public double? PFGROSS { get; set; }

    public double? ATTENDANCEBONUS { get; set; }
    public double? PENSION { get; set; }
    public double? ADDLINCR { get; set; }
    public double? GROSS { get; set; }
    public double? NETPAY { get; set; }
        
    public double? PF { get; set; }
    public double? OTHERALLOWANCE { get; set; }
    public double? OTWAGES { get; set; }
    public double? NORMALWAGESEARNED { get; set; }
    public double? OTHERDEDUCTION { get; set; }
    public string CATCODE { get; set; }
    public DateTime? CREATIONDATE { get; set; }
    public DateTime? MODIFICATIONDATE { get; set; }
    public string APPROVED { get; set; }
    public string WORKORDERNO { get; set; }
    }
}









