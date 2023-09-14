using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class BankerAnnexureA
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public decimal SevAmount { get; set; }
        [Required]
        public decimal ThiAmount { get; set; }
        [Required]
        public decimal ThreeAmount { get; set; }
        [Required]
        public decimal SixAmount { get; set; }
        [Required]
        public decimal SevInt { get; set; }
        [Required]
        public decimal ThiInt { get; set; }
        [Required]
        public decimal ThreeInt { get; set; }
        [Required]
        public decimal SixInt { get; set; }


        [Required]
        public string Bank { get; set; }
        [Required]
        public string Branch { get; set; }
        [Required]
        public string IFS { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}