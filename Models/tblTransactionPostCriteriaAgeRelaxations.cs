using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    public class tblTransactionPostCriteriaAgeRelaxationsContext : DbContext
    {
        public tblTransactionPostCriteriaAgeRelaxationsContext()
            : base("name=HclEntities")
        {
        }
        public DbSet<tblTransactionPostCriteriaAgeRelaxations> tblTransactionPostCriteriaAgeRelaxations { get; set; }
    }
    public class tblTransactionPostCriteriaAgeRelaxations
    {
        [Key]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int CastCategoryId { get; set; }
        public string CasteCategory { get; set; }
        public int AgeRelax { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class clstblTransactionPostCriteriaAgeRelaxations
    {
        public void Update(List<tblTransactionPostCriteriaAgeRelaxations> list, int PostId)
        {

            using (tblTransactionPostCriteriaAgeRelaxationsContext db = new tblTransactionPostCriteriaAgeRelaxationsContext())
            {
                var cr = db.tblTransactionPostCriteriaAgeRelaxations.Where(f => f.PostId == PostId && f.IsDeleted == false).ToList();
                if (cr.Count > 0)
                {
                    cr.ForEach(a => a.IsDeleted = true);
                    db.SaveChanges();
                }

                list = list.Where(a => a.AgeRelax > 0).ToList();
                foreach (var q in list)
                {
                    var delRecord = db.tblTransactionPostCriteriaAgeRelaxations.Where(f => f.PostId == PostId && f.IsDeleted == true).FirstOrDefault();
                    if (delRecord != null)
                    {
                        delRecord.PostId = q.PostId;
                        delRecord.AgeRelax = q.AgeRelax;
                        delRecord.CastCategoryId = q.CastCategoryId;
                        delRecord.CasteCategory = q.CasteCategory;
                        delRecord.IsDeleted = false;
                        db.SaveChanges();
                    }
                    else
                    {
                        db.tblTransactionPostCriteriaAgeRelaxations.Add(q);
                        db.SaveChanges();
                    }
                }
            }
        }
    }
}