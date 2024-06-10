using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using System.Data.Entity.Infrastructure;

namespace Hindustancopperlimited.Models
{
    public class tbl_transaction_PostcriteriacontextForITI : DbContext
    {
        public tbl_transaction_PostcriteriacontextForITI()
            : base("name=HclEntities")
        {
        }

        public DbSet<tbl_transaction_PostcriteriaForITI> tbl_transaction_PostcriteriaForITI { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_transaction_PostcriteriaForITI>().HasKey(p => p.Pk_criteriaid);
            modelBuilder.Entity<tbl_transaction_PostcriteriaForITI>().Property(c => c.Pk_criteriaid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
        }


     

    }
}