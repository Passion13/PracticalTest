//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PracticalTest
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeDepartment
    {
        public int EmployeeDepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public byte DepartmentId { get; set; }
    
        public virtual DepartmentMaster DepartmentMaster { get; set; }
        public virtual Employee Employee { get; set; }
    }
}
