using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_compliantdetailscontext:DbContext
    {
        public vw_compliantdetailscontext()
            : base("name=HclEntities")
        {
        }

        public DbSet<vw_compliantdetails> vw_compliantdetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vw_compliantdetails>().HasKey(p => p.intGrievanceId);
            modelBuilder.Entity<vw_compliantdetails>().Property(c => c.intGrievanceId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }

        public List<compliantdetails> GetCompliantData(int userId)
        {
            //return this.Database.SqlQuery<MenuModel>(
            //    "stp_GetUserMenu {0}, {1}",userId, userType).ToList<MenuModel>();

            return this.Database.SqlQuery<compliantdetails>(
              "sp_Complaint {0}", userId).ToList<compliantdetails>();
        }
    }
}