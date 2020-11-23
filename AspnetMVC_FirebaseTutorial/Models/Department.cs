using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace AspnetMVC_FirebaseTutorial.Models
{
    public class Department
    {
        [Key]
        public string id { get; set; }

        [Required]
        [Display(Name = "DepartmentName")]
        public string DepartmentName { get; set; }

        [Display(Name = "FileName")]
        public string FromFile { get; set; }

    }
}