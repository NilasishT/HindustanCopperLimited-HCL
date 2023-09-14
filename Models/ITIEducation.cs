using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Hindustancopperlimited.Models
{
    public class ITIEducation
    {
        [Required]
        
        public string Str_exampassed { get; set; }
        [Required]
        
        public string Str_board { get; set; }
        
        public string Str_Affiliation { get; set; }
        [Required]
        [DateLessThan("Str_passingyear2", AllowEquality = true)]
        public string Str_passingyear { get; set; }
        [Required]        
        public string Str_duration { get; set; }
        [Required]      
        public string StrRemarks { get; set; }
        [Required]
        [IfMaxValue("StrRemarks", "CGPA", "10")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid")]
        public string Str_TotalMarks { get; set; }
        [Required]
        [NumericLessThan("Str_TotalMarks", AllowEquality = true)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid")]
        public string Str_MarksObtained { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid")]
        public string Str_Marks { get; set; }

        [Required]        
        public string Str_exampassed1 { get; set; }
        public string Str_board1 { get; set; }        
        public string Str_Affiliation1 { get; set; }
        public string Str_passingyear1 { get; set; } 
        public string Str_duration1 { get; set; }
        public string StrRemarks1 { get; set; }
        [IfMaxValue("StrRemarks1", "CGPA", "10")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid")]
        public string Str_TotalMarks1 { get; set; }
        [NumericLessThan("Str_TotalMarks1", AllowEquality = true)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid")]
        public string Str_MarksObtained1 { get; set; }
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid")]
        public string Str_Marks1 { get; set; }


        [Required]        
        public string Str_exampassed2 { get; set; }
        [Required]        
        public string Str_board2 { get; set; }
        [Required]        
        public string Str_Affiliation2 { get; set; }
        [Required]
        public string Str_passingyear2 { get; set; }
        [Required]        
        public string Str_duration2 { get; set; }
        [Required]
        public string StrRemarks2 { get; set; }
        [Required]
        [IfMaxValue("StrRemarks2", "CGPA", "10")]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid")]
        public string Str_TotalMarks2 { get; set; }
        [Required]
        [NumericLessThan("Str_TotalMarks2", AllowEquality = true)]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid")]
        public string Str_MarksObtained2 { get; set; }
        [Required]
        [RegularExpression(@"\d+(\.\d{1,2})?", ErrorMessage = "Invalid")]
        public string Str_Marks2 { get; set; }

    }
}