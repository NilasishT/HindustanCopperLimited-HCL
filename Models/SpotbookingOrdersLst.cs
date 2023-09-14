using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class SpotbookingOrdersLst
    {
        public SpotbookingOrdersLst()
        {
            OrderList = new List<tbl_mst_SpotbookingOrders>();
        }

        public List<tbl_mst_SpotbookingOrders> OrderList { get; set; }
    }
}