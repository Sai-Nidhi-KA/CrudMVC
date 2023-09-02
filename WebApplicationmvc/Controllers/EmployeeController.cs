using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationmvc.DataAccess;
using WebApplicationmvc.Models;

namespace WebApplicationmvc.Controllers
{
    public class EmployeeController : Controller
    {

        DataAccessLayer dataAccessLayer = new DataAccessLayer();
        // GET: Employee
        public ActionResult Index()
        {
            var employeesList = dataAccessLayer.GetEmployees();
            if(employeesList.Count == 0)
            {
                TempData["InfoMessage"] = "Currently employee details are not available";
            }
            return View(employeesList);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeModel employeeModel)
        {
            bool IsInserted = false;
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    IsInserted = dataAccessLayer.InsertDetails(employeeModel);
                    if(IsInserted)
                    {
                        TempData["SuccessMessage"] = "Employee deatils saves successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unabled to save employee details";
                    }
                    
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            var employees = dataAccessLayer.GetEmployeeById(id).FirstOrDefault();
            if(employees == null )
            {
                TempData["InfoMessage"] = " employee details are not available with Id" +id.ToString();
                 return RedirectToAction("Index");
            }
            return View(employees);
        }

        // POST: Employee/Edit/5
        [HttpPost,ActionName("Edit")]
        public ActionResult Update(EmployeeModel employeeModel)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    bool IsUpdated = dataAccessLayer.UpdateDetails(employeeModel);
                    if (IsUpdated)
                    {
                        TempData["SuccessMessage"] = "Employee deatils updated successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unabled to update employee details";
                    }

                }
                

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var employees = dataAccessLayer.GetEmployeeById(id).FirstOrDefault();
                if (employees == null)
                {
                    TempData["InfoMessage"] = " employee details are not available with Id" + id.ToString();
                    return RedirectToAction("Index");
                }
                return View(employees);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }

        }

        // POST: Employee/Delete/5
        [HttpPost,ActionName("Delete")]
        public ActionResult DeleteConfirmation(int Id)
        {
            try
            {
                // TODO: Add delete logic here
                if (ModelState.IsValid)
                {
                    bool result = dataAccessLayer.DeleteDetail(Id);
                    if (result)
                    {
                        TempData["SuccessMessage"] = "Employee deatils deleted successfully";
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Unabled to delete employee details";

                    }
                }

                        return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return View();
            }
        }
    }
}
