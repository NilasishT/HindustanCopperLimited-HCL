using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class LoginContext : DbContext
    {
        public LoginContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<InitialRegistration> UserRegistrations { get; set; }
       
       


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<InitialRegistration>().HasKey(p => p.pk_intRegisterUserID);
            modelBuilder.Entity<InitialRegistration>().Property(c => c.pk_intRegisterUserID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}