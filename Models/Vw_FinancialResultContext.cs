using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class Vw_FinancialResultContext: DbContext
    {
        public Vw_FinancialResultContext()
            : base("name=HclEntities")
        {
        }
        public DbSet<Vw_FinancialResult> Vw_FinancialResult { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vw_FinancialResult>().HasKey(p => p.pk_intFinanceResultId);
            modelBuilder.Entity<Vw_FinancialResult>().Property(c => c.pk_intFinanceResultId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}