using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_LME_CustomerOrderContext : DbContext
    {

        public Vw_LME_CustomerOrderContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<Vw_LME_CustomerOrder> Vw_LME_CustomerOrder { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vw_LME_CustomerOrder>().HasKey(p => p.Pk_intOrderID);
            modelBuilder.Entity<Vw_LME_CustomerOrder>().Property(c => c.Pk_intOrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}