using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalTest.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Qualification is required.")]
        public string Qualification { get; set; }
        [Required(ErrorMessage = "Department is required.")]
        public string DepartmentId { get; set; }
        [Required(ErrorMessage ="Contact Number is required.")]
        public string ContactNumber { get; set; }

        public List<Department> DepartmentList { get; set; }
    }
}