using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;

namespace Hindustancopperlimited.Models
{
    public class ITIApplicationContext : DbContext
    {
        public ITIApplicationContext()
            : base("name=HclEntities")
        {
        }

        public DbSet<tbl_mst_RegistrationForITIApplicant> tbl_mst_RegistrationForITIApplicant { get; set; }
        public DbSet<tbl_forgetPassword> tbl_forgetPassword { get; set; }
        public DbSet<tbl_mst_ITICandidatePersonalDetails> tbl_mst_ITICandidatePersonalDetails { get; set; }
        public DbSet<tbl_mst_ITIAppliedPostDetails> tbl_mst_ITIAppliedPostDetails { get; set; }
        public DbSet<tbl_mst_ITICandidateQualification> tbl_mst_ITICandidateQualification { get; set; }
        public DbSet<tbl_mst_ITIcandidatephotoupload> tbl_mst_ITIcandidatephotoupload { get; set; }
        public DbSet<tbl_mst_ITICandidateReferencesDetails> tbl_mst_ITICandidateReferencesDetails { get; set; }
        public DbSet<vw_ITIApplicationDetails> vw_ITIApplicationDetails { get; set; }
        public DbSet<tbl_mst_ITIReferencesDetails> tbl_mst_ITIReferencesDetails { get; set; }
        public DbSet<AuditLog> AuditLogs { get; set; }
        public DbSet<tbl_mst_ITIcandidateOfferLetter> tbl_mst_ITIcandidateOfferLetter { get; set; }
        public DbSet<ITI_Upload_Candidates> ITI_Upload_Candidates { get; set; }
        public DbSet<vw_itinew> vw_itinew { get; set; }
        public DbSet<vw_itiuploadfilestatus> vw_itiuploadfilestatus { get; set; }
        

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<tbl_mst_CandidateRegistrationForRecruitment>().HasKey(p => p.Candidate_Pk_intID);
            modelBuilder.Entity<tbl_mst_CandidateRegistrationForRecruitment>().Property(c => c.Candidate_Pk_intID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            base.OnModelCreating(modelBuilder);
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
            try
        {
            // Call the original SaveChanges(), which will save both the changes made and the audit records
            return base.SaveChanges();
        }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }
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