using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Login
    {
        [Key]
        public int pk_intUserId { get; set; }
        public string strUserName { get; set; }
        public string strUserPwd { get; set; }
        public string strDesignation { get; set; }
        public string strEmail { get; set; }
        public DateTime? dtEntrydate { get; set; }
        public DateTime? dtUpdatedate { get; set; }
        public string strusertype { get; set; }
        public int? Fk_intUnitId { get; set; }
        public string strMenuRightID { get; set; }

    }




    public class tbl_MenuMaster
    {
        [Key]
        public int pk_intMenuId { get; set; }
        public Nullable<int> fk_intModuleId { get; set; }
        public string strMenuText { get; set; }
        public string strMenuAction { get; set; }
        public string strMenuController { get; set; }
        public Nullable<bool> bitIsAdmin { get; set; }
        public Nullable<int> intMenuParentId { get; set; }
        public Nullable<int> intOrderId { get; set; }
        public Nullable<bool> bitIsVisible { get; set; }
    }

    public class tbl_MenuMasterContext : DbContext
    {
        public tbl_MenuMasterContext()
            : base("name=HclEntities")
        {


        }


        public DbSet<tbl_MenuMaster> tbl_MenuMaster { get; set; }

    }


}