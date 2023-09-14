using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_gendercontext:DbContext
    {
        public tbl_mst_gendercontext()
            : base("name=HclEntities")
        {
        }

        public DbSet<tbl_mst_gender> tbl_mst_gender { get; set; }
      

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_mst_gender>().HasKey(p => p.Pk_intGenderid);
            modelBuilder.Entity<tbl_mst_gender>().Property(c => c.Pk_intGenderid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
           
            base.OnModelCreating(modelBuilder);
        }
    }
}