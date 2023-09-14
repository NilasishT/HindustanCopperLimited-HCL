using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_LME_CustomerListContext : DbContext
    {

        public Vw_LME_CustomerListContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<Vw_LME_CustomerList> Vw_LME_CustomerList { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vw_LME_CustomerList>().HasKey(p => p.Pk_Registrationid);
            modelBuilder.Entity<Vw_LME_CustomerList>().Property(c => c.Pk_Registrationid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}