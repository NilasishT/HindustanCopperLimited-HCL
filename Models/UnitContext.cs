using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class UnitContext : DbContext
    {
        public UnitContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<Unit> Units { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>().HasKey(p => p.pk_intUnitId);
            modelBuilder.Entity<Unit>().Property(c => c.pk_intUnitId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}