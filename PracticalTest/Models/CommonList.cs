using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticalTest.Models
{
    public static class CommonList
    {
        public static SelectList DepartmentList()
        {
            using (PracticalTestEntities pt = new PracticalTestEntities())
            {
                return new SelectList(pt.DepartmentMasters.ToList(), "DepartmentId", "DepartmentName");
            }
        }
    }
}