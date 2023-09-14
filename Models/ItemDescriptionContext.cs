using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;


namespace Hindustancopperlimited.Models
{
    public class ItemDescriptionContext: DbContext
    {

        public ItemDescriptionContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<ItemDescription> ItemDescriptions { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemDescription>().HasKey(p => p.Pk_intItemDescription);
            modelBuilder.Entity<ItemDescription>().Property(c => c.Pk_intItemDescription)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }
    }
}