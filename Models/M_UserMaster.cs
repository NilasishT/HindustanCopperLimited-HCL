using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    public class M_UserMaster
    {
        [Key]
        public int pk_intUserId { get; set; }
        public string vchUserId { get; set; }
        public string vchUserName { get; set; }
        public string vchPassword { get; set; }
        public string vchFullName { get; set; }
        public string vchPresAddress { get; set; }
        public string vchPermAddress { get; set; }
        public string vchPhotoPath { get; set; }
        public int? vchFileSize { get; set; }
        public string vchUnitId { get; set; }
        public string vchDeptId { get; set; }
        public string vchDesigId { get; set; }
        public string vchOffNo { get; set; }
        public string vchMobNo { get; set; }
        public string vchFaxNo { get; set; }
        public string vchEmpId { get; set; }
        public string vchEmailId { get; set; }
        public string vchReligion { get; set; }
        public string vchGender { get; set; }
        public DateTime? dtmDoj { get; set; }
        public DateTime? dtmDob { get; set; }
        public string vchUserStatus { get; set; }
        public string vchAdminPrev { get; set; }
        public string vchCreatedBy { get; set; }
        public DateTime? dtmCreatedOn { get; set; }
        public string vchUpdatedBy { get; set; }
        public DateTime? dtmUpdatedOn { get; set; }
        public bool? bitDeletedFlag { get; set; }

    }
}