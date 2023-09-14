using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class Vw_AdvertisementNoticeContext:DbContext
    {

        public Vw_AdvertisementNoticeContext()
            : base("name=HclEntities")
        {
        }
        public DbSet<Vw_AdvertisementNotice> Vw_AdvertisementNotice { get; set; }
       

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vw_AdvertisementNotice>().HasKey(p => p.Pk_employmentid);
            modelBuilder.Entity<Vw_AdvertisementNotice>().Property(c => c.Pk_employmentid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}