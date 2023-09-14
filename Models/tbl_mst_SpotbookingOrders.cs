using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_SpotbookingOrders
    {
        [Key]
        public int Pk_intOrderID { get; set; }
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
        public DateTime? dtOrderDatetime { get; set; }
       
    }
}