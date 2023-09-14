using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace Hindustancopperlimited.Models
{
    public class BillTrackingContext: DbContext
    {
        public BillTrackingContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<ContractDetails> ContractDetails { get; set; }
        public DbSet<BillDetails> BillDetails { get; set; }
        public DbSet<BillStatus> BillStatus { get; set; }
        public DbSet<UploadBillTracking> UploadBillTracking { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContractDetails>().HasKey(p => p.Pk_Id);
            modelBuilder.Entity<ContractDetails>().Property(c => c.Pk_Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }

    }
}