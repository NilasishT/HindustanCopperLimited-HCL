using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_Postdesiciplinedetailscontext : DbContext
    {
        public Vw_Postdesiciplinedetailscontext()
            : base("name=HclEntities")
        {
        }

        public DbSet<Vw_Postdesiciplinedetails> Vw_Postdesiciplinedetails { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vw_Postdesiciplinedetails>().HasKey(p => p.Pk_criteriaid);
            modelBuilder.Entity<Vw_Postdesiciplinedetails>().Property(c => c.Pk_criteriaid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}