using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_Notice_Corrigendmcontext:DbContext
    {
        public Vw_Notice_Corrigendmcontext()
            : base("name=HclEntities")
        {
        }
        public DbSet<Vw_Notice_Corrigendm> Vw_Notice_Corrigendm { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vw_Notice_Corrigendm>().HasKey(p => p.pk_corriengdumid);
            modelBuilder.Entity<Vw_Notice_Corrigendm>().Property(c => c.pk_corriengdumid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}