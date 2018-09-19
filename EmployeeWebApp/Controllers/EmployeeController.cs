using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeWebApp.Manager;
using EmployeeWebApp.Models;

namespace EmployeeWebApp.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        private EmployeeManager aManager=new EmployeeManager();
        public ActionResult Index()
        {
            List<Employee> alList = aManager.GetAllEmployee();
            return View(alList);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (aManager.IsEmployeeIdExist(employee.EmpId))
                    {
                        ViewBag.message = "Employee ID is already exist";
                    }
                    else if (aManager.IsEmailExist(employee.Email))
                    {
                        ViewBag.message = "Email is already exist";
                    }
                    else
                    {
                        int message = aManager.Save(employee);
                        if (message > 0)
                        {
                            ViewBag.message = "Save Successfully";
                        }
                        else
                        {
                            ViewBag.message = "failed to save";
                        }
                    }
                }
                catch (Exception ex)
                {

                    ViewBag.message = ex.Message;
                }
            }
            
            
            return View();
        }

        public ActionResult Details(int id)
        {
            Employee employee=new Employee();
            if (id!=null)
            {
                employee = aManager.GetEmployee(id);
                if (employee == null)
                {
                    return HttpNotFound();
                }
            }
            
            return View(employee);
        }
	}
}