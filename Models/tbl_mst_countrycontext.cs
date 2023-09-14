using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_countrycontext :DbContext
    {

        public tbl_mst_countrycontext()
            : base("name=HclEntities")
        {
        }

        public DbSet<tbl_mst_country> tbl_mst_country { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_mst_country>().HasKey(p => p.Pk_Countryid);
            modelBuilder.Entity<tbl_mst_country>().Property(c => c.Pk_Countryid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}