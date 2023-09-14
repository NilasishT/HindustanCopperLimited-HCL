using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mstCategoryContext : DbContext
    {
        public tbl_mstCategoryContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<tbl_mstCategory> tbl_mstCategory { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_mstCategory>().HasKey(p => p.Pk_intCategoryID);
            modelBuilder.Entity<tbl_mstCategory>().Property(c => c.Pk_intCategoryID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}