using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUD_ADO.Models
{
    public class Student
    {
        [Required]
        public int ID { get; set; }
        [Required]
        public String FirstName { get; set; }
        [Required]
        public String LastName { get; set; }
        [Required]
        public String Stream { get; set; }
        [Required]
        public int Marks { get; set; }
    }
}