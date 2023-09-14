using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class tbl_mst_InvestorRelationsPageContext : DbContext
    {
        public tbl_mst_InvestorRelationsPageContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<tbl_mst_InvestorRelationsPage> tbl_mst_InvestorRelationsPage { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_mst_InvestorRelationsPage>().HasKey(p => p.pk_int_InvestorRelationsID);
            modelBuilder.Entity<tbl_mst_InvestorRelationsPage>().Property(c => c.pk_int_InvestorRelationsID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}