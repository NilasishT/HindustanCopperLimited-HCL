using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_Quarterlyreportcontext :DbContext
    {

        public Vw_Quarterlyreportcontext()
            : base("name=HclEntities")
        {
        }

        public DbSet<Vw_Quarterlyreport> Vw_Quarterlyreport { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vw_Quarterlyreport>().HasKey(p => p.Pk_ReportId);
            modelBuilder.Entity<Vw_Quarterlyreport>().Property(c => c.Pk_ReportId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}