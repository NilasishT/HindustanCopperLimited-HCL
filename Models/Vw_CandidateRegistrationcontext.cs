using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_CandidateRegistrationcontext:DbContext
    {
        public Vw_CandidateRegistrationcontext()
            : base("name=HclEntities")
        {
        }

        public DbSet<Vw_CandidateRegistration> Vw_CandidateRegistration { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vw_CandidateRegistration>().HasKey(p => p.Pk_int_CandidateRegistrationID);
            modelBuilder.Entity<Vw_CandidateRegistration>().Property(c => c.Pk_int_CandidateRegistrationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}