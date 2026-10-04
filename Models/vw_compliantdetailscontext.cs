using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_compliantdetailscontext : DbContext
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

        public List<compliantdetails> GetCompliantData(int userId, bool bitDeletedFlag)
        {
            return this.Database.SqlQuery<compliantdetails>(
                "sp_Complaint @p0, @p1",
                userId, bitDeletedFlag
            ).ToList();
        }
        public List<compliantdetailsSummary> GetCompliantDataDistinct(int userId, bool bitDeletedFlag)
        {
            var data = this.Database.SqlQuery<compliantdetailsSummary>(
                "EXEC sp_Complaint_distinct @p0, @p1",
                userId, bitDeletedFlag
            ).ToList();

            //var result = data.Select(c => new compliantdetailsSummary
            //{
            //    intGrievanceId = c.intGrievanceId,
            //    vchCompRegNo = c.vchCompRegNo,
            //    dtmCompRegDate = c.dtmCompRegDate,
            //    vchComplainType = c.vchComplainType,
            //    vchCompAgainstOff = c.vchCompAgainstOff,
            //    vchOffDesig = c.vchOffDesig,
            //    vchComplainDetails = c.vchComplainDetails,
            //    vchFileName = c.vchFileName
            //})
            //.Distinct()
            //.ToList();

            return data;
        }


    }
}