using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspnetMVC_FirebaseTutorial.Models
{
    public class Student
    {
        public string student_id { get; set; }
        public string fullname { get; set; }
        public string degree_title { get; set; }
        public string address { get; set; }
        public string phone { get; set; }
    }
}