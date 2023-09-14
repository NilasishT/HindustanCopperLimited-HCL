using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;

namespace Hindustancopperlimited.Models
{
    public class vw_VendorRegistrationsListContext : DbContext
    {
        public vw_VendorRegistrationsListContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<vw_VendorRegistrationsList> vw_VendorRegistrationsLists { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Unit>().HasKey(p => p.pk_intUnitId);
            //modelBuilder.Entity<Unit>().Property(c => c.pk_intUnitId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<vw_VendorRegistrationsList>().HasKey(p => p.Pk_intNewVendorRegistrationID);
            modelBuilder.Entity<vw_VendorRegistrationsList>().Property(c => c.Pk_intNewVendorRegistrationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


           
            //modelBuilder.Entity<VendorRegistration>().HasRequired(p => p.Unit)
            //   .WithMany(b => b.VendorRegistrations).HasForeignKey(b => b.Fk_intUnitId);
            
            
           
            base.OnModelCreating(modelBuilder);

        }

       




    }
}