using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace Hindustancopperlimited.Models
{
    public class AdminLoginContext : DbContext
    {
        public AdminLoginContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<Login> LOGINs { get; set; }
        public DbSet<tbl_MenuMaster> tbl_MenuMaster { get; set; }
        public DbSet<RegionUser> RegionUser { get; set; }
        public DbSet<M_UserMaster> M_UserMaster { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>().HasKey(p => p.pk_intUserId);
            modelBuilder.Entity<Login>().Property(c => c.pk_intUserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }


        public List<MenuModel> GetUserRightList(int userId, string userType, string strMenuRightID)
        {
            //return this.Database.SqlQuery<MenuModel>(
            //"stp_getUserMenuRightList {0}, {1}", userId, userType).ToList<MenuModel>();
            return this.Database.SqlQuery<MenuModel>(
            "stp_getUserMenuRightList {0}, {1} , {2}", userId, userType, strMenuRightID).ToList<MenuModel>();
        }

        public List<MenuModel> GetUserMenu(int userId, string userType, string strMenuRightID)
        {
            //return this.Database.SqlQuery<MenuModel>(
            //    "stp_GetUserMenu {0}, {1}",userId, userType).ToList<MenuModel>();

            return this.Database.SqlQuery<MenuModel>(
              "stp_GetUserMenu {0}, {1}, {2}", userId, userType, strMenuRightID).ToList<MenuModel>();
        }
    }
}