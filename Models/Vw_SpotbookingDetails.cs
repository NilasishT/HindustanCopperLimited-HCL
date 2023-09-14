using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_SpotbookingDetails
    {
        [Key]
        public int Pk_intOrderID { get; set; }
       

        public string str_fname { get; set; }
        public string str_mname { get; set; }
        public string str_lname { get; set; }
        public string str_email { get; set; }
        public string str_phno { get; set; }
        public string str_officeno { get; set; }
        public string str_mobile { get; set; }
        public string str_fax { get; set; }
        public string str_address { get; set; }
        public string str_city { get; set; }
        public string str_state { get; set; }
        public string str_pin { get; set; }
        public string str_district { get; set; }
        public string str_country { get; set; }
        public string str_panno { get; set; }
        public string str_gstno { get; set; }
        public string str_namefirm { get; set; }
        public string str_pw { get; set; }
        public string str_confirmpw { get; set; }
        public DateTime? dt_entrydate { get; set; }
        public DateTime? dt_updatedate { get; set; }
        public string Isactive { get; set; }
        public string str_code { get; set; }

        public string str_CustomerStatus { get; set; }
        public DateTime? dt_CustomerStatusDate { get; set; }
        public string str_Remarks { get; set; }

        public string fk_region { get; set; }

        public string strOrganisationName { get; set; }
        public DateTime? dtOrderDate { get; set; }
        public string strProducts { get; set; }
        public string strOrderType { get; set; }
        public string strOrderOption { get; set; }
        public string strLiftingOption { get; set; }
        public DateTime? tmRealBookingTime { get; set; }
        public double? fltProductPrice { get; set; }
        public string fltBookedQuantity { get; set; }
        public string strComments { get; set; }
        public string strcode { get; set; }
        public string str_OrderStatus { get; set; }
        public DateTime? dt_OrderStatusDate { get; set; }
        public string str_OrderStatusRemarks { get; set; }
        public string str_orderid { get; set; }
        public string str_deliveryplace { get; set; }
        public string str_bookingbasicprice { get; set; }
        public string str_bookingquantityaccept { get; set; }
        public string str_bookingproductaccept { get; set; }
        public int Pk_Registrationid { get; set; }
        public DateTime? dtOrderDatetime { get; set; }
        
    }
}