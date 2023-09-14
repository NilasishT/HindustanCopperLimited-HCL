using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class vw_PostDetailsContext : DbContext
    {
        public vw_PostDetailsContext()
            : base("name=HclEntities")
        {
        }
        public DbSet<vw_PostDetails> vw_PostDetails { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<vw_PostDetails>().HasKey(p => p.Pk_Postid);
            modelBuilder.Entity<vw_PostDetails>().Property(c => c.Pk_Postid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}