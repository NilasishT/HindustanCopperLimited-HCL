using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using DatabaseGeneratedOption = System.ComponentModel.DataAnnotations.DatabaseGeneratedOption;

namespace Hindustancopperlimited.Models
{
    public class ConstitutionFirmCotext : DbContext
    {

        public ConstitutionFirmCotext()
            : base("name=HclEntities")
        {
        }

        public DbSet<ConstitutionFirm> ConstitutionFirms { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConstitutionFirm>().HasKey(p => p.pk_intConstitutionFirmID);
            modelBuilder.Entity<ConstitutionFirm>().Property(c => c.pk_intConstitutionFirmID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}