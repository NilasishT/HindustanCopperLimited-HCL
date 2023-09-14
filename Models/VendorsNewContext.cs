using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Configuration;
using Hindustancopperlimited.GlobalClass;
using System.Data.Entity.Infrastructure;


namespace Hindustancopperlimited.Models
{
    public class VendorsNewContext : DbContext
    {
        public VendorsNewContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<VendorsNew> VendorsNews { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<tbl_mstWorkmanDetails> tbl_mstWorkmanDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<Unit>().HasKey(p => p.pk_intUnitId);
            //modelBuilder.Entity<Unit>().Property(c => c.pk_intUnitId)
            //    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


            modelBuilder.Entity<VendorsNew>().HasKey(p => p.Pk_intNewVendorRegistrationID);
            modelBuilder.Entity<VendorsNew>().Property(c => c.Pk_intNewVendorRegistrationID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);


           
            //modelBuilder.Entity<VendorRegistration>().HasRequired(p => p.Unit)
            //   .WithMany(b => b.VendorRegistrations).HasForeignKey(b => b.Fk_intUnitId);
            
            
           
            base.OnModelCreating(modelBuilder);

        }

        public String AutoVendorRegistrationID() 
            
        {
           
          SqlConnection conn=new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ToString());
          SqlCommand cmd = new SqlCommand("select 'HCLV'+ right('000000'+convert(varchar(6),cast((isnull(max(replace(strUserName,'HCLV','')),0)+1) as varchar)),6) as pk_intVendorUserId  from VendorLogins", conn);
            
            //cmd.CommandText = "select 'VENDOR'+ cast((max(Pk_intNewVendorRegistrationID)+1) as varchar)  from VendorRegistrations";
            conn.Open();
            string record = cmd.ExecuteScalar().ToString();
            //conn.Open();
            return record;
            //conn.Close();
           
        }

        public String AutoEmployeeRegistrationID()
        {

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["HclEntities"].ToString());
            SqlCommand cmd = new SqlCommand("select 'HCLE'+ right('000000'+convert(varchar(6),cast((isnull(max(pk_WorkmanDetailsid),0)+1) as varchar)),6) as pk_WorkmanDetailsid  from tbl_mstWorkmanDetails", conn);

            //cmd.CommandText = "select 'VENDOR'+ cast((max(Pk_intNewVendorRegistrationID)+1) as varchar)  from VendorRegistrations";
            conn.Open();
            string record = cmd.ExecuteScalar().ToString();
            //conn.Open();
            return record;
            //conn.Close();

        }

        public override int SaveChanges()
        {
            foreach (var ent in this.ChangeTracker.Entries().Where(p => p.State == System.Data.EntityState.Added || p.State == System.Data.EntityState.Deleted || p.State == System.Data.EntityState.Modified))
            {
                // For each changed record, get the audit record entries and add them
                foreach (AuditLog x in GetAuditRecordsForChange(ent))
                {
                    this.AuditLogs.Add(x);
                }
            }

            // Call the original SaveChanges(), which will save both the changes made and the audit records
            return base.SaveChanges();
        }


        private List<AuditLog> GetAuditRecordsForChange(DbEntityEntry dbEntry)
        {
            List<AuditLog> result = new List<AuditLog>();

            DateTime changeTime = DateTime.UtcNow;

            // Get the Table() attribute, if one exists
            //TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), false).SingleOrDefault() as TableAttribute;

            TableAttribute tableAttr = dbEntry.Entity.GetType().GetCustomAttributes(typeof(TableAttribute), true).SingleOrDefault() as TableAttribute;

            // Get table name (if it has a Table attribute, use that, otherwise get the pluralized name)
            string tableName = tableAttr != null ? tableAttr.Name : dbEntry.Entity.GetType().Name;

            // Get primary key value (If you have more than one key column, this will need to be adjusted)
            var keyNames = dbEntry.Entity.GetType().GetProperties().Where(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0).ToList();

            string keyName = keyNames[0].Name; //dbEntry.Entity.GetType().GetProperties().Single(p => p.GetCustomAttributes(typeof(KeyAttribute), false).Count() > 0).Name;

            if (dbEntry.State == System.Data.EntityState.Added)
            {
                // For Inserts, just add the whole record
                // If the entity implements IDescribableEntity, use the description from Describe(), otherwise use ToString()

                foreach (string propertyName in dbEntry.CurrentValues.PropertyNames)
                {
                    result.Add(new AuditLog()
                    {
                        AuditLogId = Guid.NewGuid(),
                        UserId = Convert.ToString(System.Web.HttpContext.Current.Session["UserID"]),
                        HostAddress = HttpContext.Current.Request.UserHostAddress.ToString(),
                        EventDateUTC = changeTime,
                        EventType = "A",    // Added
                        TableName = tableName,
                        RecordId = Convert.ToInt64(dbEntry.CurrentValues.GetValue<object>(keyName)),
                        ColumnName = propertyName,
                        NewValue = dbEntry.CurrentValues.GetValue<object>(propertyName) == null ? null : dbEntry.CurrentValues.GetValue<object>(propertyName).ToString()
                    }
                            );
                }
            }
            else if (dbEntry.State == System.Data.EntityState.Deleted)
            {
                // Same with deletes, do the whole record, and use either the description from Describe() or ToString()
                result.Add(new AuditLog()
                {
                    AuditLogId = Guid.NewGuid(),
                    UserId = Convert.ToString(System.Web.HttpContext.Current.Session["UserID"]),
                    HostAddress = HttpContext.Current.Request.UserHostAddress.ToString(),
                    EventDateUTC = changeTime,
                    EventType = "D", // Deleted
                    TableName = tableName,
                    RecordId = Convert.ToInt64(dbEntry.OriginalValues.GetValue<object>(keyName)),
                    ColumnName = "*ALL"
                    //NewValue = (dbEntry.OriginalValues.ToObject() is IDescribableEntity) ? (dbEntry.OriginalValues.ToObject() as IDescribableEntity).Describe() : dbEntry.OriginalValues.ToObject().ToString()
                }
                    );
            }
            else if (dbEntry.State == System.Data.EntityState.Modified)
            {
                foreach (string propertyName in dbEntry.OriginalValues.PropertyNames)
                {
                    // For updates, we only want to capture the columns that actually changed
                    if (!object.Equals(dbEntry.OriginalValues.GetValue<object>(propertyName), dbEntry.CurrentValues.GetValue<object>(propertyName)))
                    {
                        result.Add(new AuditLog()
                        {
                            AuditLogId = Guid.NewGuid(),
                            UserId = Convert.ToString(System.Web.HttpContext.Current.Session["UserID"]),
                            HostAddress = HttpContext.Current.Request.UserHostAddress.ToString(),
                            EventDateUTC = changeTime,
                            EventType = "M",    // Modified
                            TableName = tableName,
                            RecordId = Convert.ToInt64(dbEntry.OriginalValues.GetValue<object>(keyName)),
                            ColumnName = propertyName,
                            OriginalValue = dbEntry.OriginalValues.GetValue<object>(propertyName) == null ? null : dbEntry.OriginalValues.GetValue<object>(propertyName).ToString(),
                            NewValue = dbEntry.CurrentValues.GetValue<object>(propertyName) == null ? null : dbEntry.CurrentValues.GetValue<object>(propertyName).ToString()
                        }
                            );
                    }
                }
            }
            // Otherwise, don't do anything, we don't care about Unchanged or Detached entities

            return result;
        }

    }
}