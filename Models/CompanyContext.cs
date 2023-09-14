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
    public class CompanyContext : DbContext
    {
        public CompanyContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<Company> Companys { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>().HasKey(p => p.pk_CompanyStatusID);
            modelBuilder.Entity<Company>().Property(c => c.pk_CompanyStatusID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}