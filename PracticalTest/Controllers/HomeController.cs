using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PracticalTest.Models;
using System.Data.Entity;

namespace PracticalTest.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// Add/Edit New Employee
        /// </summary>
        /// <param name="id">EmployeeId</param>
        /// <returns></returns>
        public ActionResult Add(int id = 0)
        {
            try
            {
                var employee = new EmployeeModel();
                if (id > 0)
                {

                    employee = GetEmployee(id).FirstOrDefault();

                }
                return View(employee);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Save Employee Details
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Add(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                   
                    var employee = new Employee();
                    bool ok = TryUpdateModel(employee, collection);
                    using (PracticalTestEntities pt = new PracticalTestEntities())
                    {
                        if (employee.EmployeeId == 0)
                        {
                            pt.Employees.Add(employee);
                        }
                        else
                        {
                            pt.Entry(employee).State = EntityState.Modified;
                        }
                        pt.SaveChanges();
                       
                    }
                }
                return RedirectToAction("List");
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (PracticalTestEntities pt = new PracticalTestEntities())
                {
                    var Data = pt.Employees.Include("EmployeeDepartments").Where(x => x.EmployeeId == id).FirstOrDefault();
                    pt.Employees.Remove(Data);
                    pt.SaveChanges();
                }
                return RedirectToAction("List");

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public ActionResult DeleteDepartment(int id)
        {
            try
            {
                using (PracticalTestEntities pt = new PracticalTestEntities())
                {
                    var Data = pt.DepartmentMasters.Where(x => x.DepartmentId == id).FirstOrDefault();
                    pt.DepartmentMasters.Remove(Data);
                    pt.SaveChanges();
                }
                return RedirectToAction("Department", new { id = 0 });

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        /// <summary>
        /// Employee List with all properties
        /// </summary>
        /// <returns></returns>
        public ActionResult List()
        {
            try
            {

                List<EmployeeModel> list = GetEmployee();
                return View(list);


            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
        private List<EmployeeModel> GetEmployee(int id = 0)
        {
            try
            {
                using (PracticalTestEntities pt = new PracticalTestEntities())
                {
                    var Data = pt.Employees.Where(x => id > 0 ? x.EmployeeId == id : true).Select(x => new EmployeeModel()
                    {
                        EmployeeId = x.EmployeeId,
                        Name = x.Name,
                        Address = x.Address,
                        Surname = x.Surname,
                        Qualification = x.Qualification,
                        DepartmentList = (from ed in pt.EmployeeDepartments
                                          join d in pt.DepartmentMasters on ed.DepartmentId equals d.DepartmentId
                                          where id > 0 ? ed.EmployeeId == id : true
                                          select new Department()
                                          {
                                              Name = d.DepartmentName,
                                              DepartmentId = d.DepartmentId
                                          }).ToList()
                    });
                    return Data.ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }
        /// <summary>
        /// Add Departments
        /// </summary>
        /// <param name="id">DepartmentId</param>
        /// <returns></returns>
        public ActionResult Department(int id = 0)
        {
            try
            {
                var Department = new DepartmentMaster();
                if (id > 0)
                {
                    using (PracticalTestEntities pt = new PracticalTestEntities())
                    {
                        Department = pt.DepartmentMasters.Where(x => x.DepartmentId == id).FirstOrDefault();
                    }
                }
                return View(Department);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        /// <summary>
        /// Save Department Details
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Department(FormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    DepartmentMaster d = new DepartmentMaster();
                    bool ok = TryUpdateModel(d, collection);
                    using (PracticalTestEntities pt = new PracticalTestEntities())
                    {
                        if (d.DepartmentId == 0)
                        {
                            pt.DepartmentMasters.Add(d);
                        }
                        else
                        {
                            pt.Entry(d).State = EntityState.Modified;
                        }

                        pt.SaveChanges();
                    }
                }
                return RedirectToAction("Department", new { id = 0 });
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public ActionResult DepartmentList()
        {
            try
            {
                using (PracticalTestEntities pt = new PracticalTestEntities())
                {
                    List<DepartmentMaster> list = pt.DepartmentMasters.ToList();
                    return View(list);
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}