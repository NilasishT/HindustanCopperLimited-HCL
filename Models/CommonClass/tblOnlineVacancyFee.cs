using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Hindustancopperlimited.Models
{
    //public class tblCasteCategoriesContext : DbContext
    //{
    //    public tblCasteCategoriesContext() : base("name=HclEntities")
    //    {
    //    }
    //    public DbSet<tblCasteCategories> tblCasteCategories { get; set; }
    //}
    //public class tblCasteCategories
    //{
    //    [Key]
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public bool IsActive { get; set; }
    //}
    public class tblOnlineVacancyFeeContext : DbContext
    {
        public tblOnlineVacancyFeeContext() : base("name=HclEntities")
        {
        }
        public DbSet<tblOnlineVacancyFees> tblOnlineVacancyFees { get; set; }
    }
    public class tblOnlineVacancyFees
    {
        [Key]
        public int Id { get; set; }
        public int AdvertiseId { get; set; }
        public string Caste { get; set; }
        public decimal Amount { get; set; }
    }

}