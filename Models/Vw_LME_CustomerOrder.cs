using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data;

namespace Hindustancopperlimited.Models
{
    public class Vw_LME_CustomerOrder
    {
        [Key]
        public int Pk_intOrderID { get; set; }
        public string OrganisationName { get; set; }

        public string ProductName { get; set; }

        public Double? ProductPrice { get; set; }

        public string OrderType { get; set; }

        public string OrderOption { get; set; }

        public string OrderID { get; set; }


        public DateTime? OrderDate { get; set; }
        public DateTime? BookingTime { get; set; }
        public string BookingQuantity { get; set; }
        public string LiftingOption { get; set; }

        public string Code { get; set; }

        public string OrderStatus { get; set; }
        public DateTime? OrderStatusdate { get; set; }

        public string OrdertatusRemarks { get; set; }
        public string DeliveryPalce { get; set; }
        public string BookingBasicPrice { get; set; }

        public string BookingQuantityAccept { get; set; }
        public string BookingProductAccept { get; set; }
        public string Comment { get; set; }







    }
}