using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_SpotbookingDetailscontext:DbContext
    {

        public Vw_SpotbookingDetailscontext()
            : base("name=HclEntities")
        {
        }

        public DbSet<Vw_SpotbookingDetails> Vw_SpotbookingDetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vw_SpotbookingDetails>().HasKey(p => p.Pk_intOrderID);
            modelBuilder.Entity<Vw_SpotbookingDetails>().Property(c => c.Pk_intOrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}