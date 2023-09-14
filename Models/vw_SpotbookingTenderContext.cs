using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_SpotbookingTenderContext:DbContext
    {
        public vw_SpotbookingTenderContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<vw_SpotbookingTender> vw_SpotbookingTender { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vw_SpotbookingTender>().HasKey(p => p.Pk_int_tenderid);
            modelBuilder.Entity<vw_SpotbookingTender>().Property(c => c.Pk_int_tenderid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
        
    }
}