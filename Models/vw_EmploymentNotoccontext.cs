using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_EmploymentNotoccontext : DbContext
    {
        public vw_EmploymentNotoccontext()
            : base("name=HclEntities")
        {
        }
        public DbSet<vw_EmploymentNotoc> vw_EmploymentNotoc { get; set; }

         protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             modelBuilder.Entity<vw_EmploymentNotoc>().HasKey(p => p.Pk_employmentid);
             modelBuilder.Entity<vw_EmploymentNotoc>().Property(c => c.Pk_employmentid)
                 .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

             base.OnModelCreating(modelBuilder);
         }
    }
}