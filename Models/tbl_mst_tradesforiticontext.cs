using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace Hindustancopperlimited.Models
{
    public class tbl_mst_tradesforiticontext : DbContext
    {
        public tbl_mst_tradesforiticontext()
            : base("name=HclEntities")
        {
        }

        public DbSet<tbl_mst_TradesForITI> tbl_tradesforiti { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_mst_TradesForITI>().HasKey(p => p.Pk_intTradeid);
            modelBuilder.Entity<tbl_mst_TradesForITI>().Property(c => c.Pk_intTradeid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}