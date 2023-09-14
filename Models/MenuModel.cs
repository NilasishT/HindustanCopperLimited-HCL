using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class MenuModel
    {
        public int pk_intMenuId { get; set; }
        public Nullable<int> fk_intModuleId { get; set; }
        public string strMenuText { get; set; }
        public string strMenuAction { get; set; }
        public string strMenuController { get; set; }
        public Nullable<bool> bitIsAdmin { get; set; }
        //public Nullable<int> intMenuParentId { get; set; }
        public int intMenuParentId { get; set; }
        public Nullable<int> intOrderId { get; set; }
        public string strMenuFullpath { get; set; }
        //public bool bitViewRight { get; set; }
        //public bool bitCreateRight { get; set; }
        //public bool bitEditRight { get; set; }
        //public bool bitDeleteRight { get; set; }
        //public bool bitApprovalRight { get; set; }

        public int bitViewRight { get; set; }
        public int bitCreateRight { get; set; }
        public int bitEditRight { get; set; }
        public int bitDeleteRight { get; set; }
        public int bitApprovalRight { get; set; }
    }
}