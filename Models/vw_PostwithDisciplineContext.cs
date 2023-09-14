using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_PostwithDisciplineContext : DbContext
    {
        public vw_PostwithDisciplineContext()
            : base("name=HclEntities")
        {
        }
        public DbSet<vw_PostwithDiscipline> vw_PostwithDiscipline { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vw_PostwithDiscipline>().HasKey(p => p.Pk_Postid);
            modelBuilder.Entity<vw_PostwithDiscipline>().Property(c => c.Pk_Postid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}