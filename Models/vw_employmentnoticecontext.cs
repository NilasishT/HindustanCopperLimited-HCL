using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class vw_employmentnoticecontext : DbContext
    {
        public vw_employmentnoticecontext()
            : base("name=HclEntities")
        {
        }
        public DbSet<vw_employmentnotice> vw_employmentnotice { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vw_employmentnotice>().HasKey(p => p.Pk_employmentid);
            modelBuilder.Entity<vw_employmentnotice>().Property(c => c.Pk_employmentid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}