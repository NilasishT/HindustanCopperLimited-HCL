using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace Hindustancopperlimited.Models
{
    [Table("UploadPhotoGallery")]
    public class UploadPhotoGallery
    {
        [Key]
        public int id { get; set; }
        public string strPhotoContent { get; set; }

        public string strPhotoHindiContent { get; set; }
        public string PhotoGallery { get; set; }

    }
}