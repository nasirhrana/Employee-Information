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
            ViewBag.TotalAmount = aManager.GetTotalAmount();
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
                        int message = aManager.Save(employee);
                        if (message > 0)
                        {
                            ViewBag.message = "Emloyee Save Successfully";
                        }
                        else
                        {
                            ViewBag.message = "failed to save";
                        }
                    
                }
                catch (Exception ex)
                {

                    ViewBag.message = ex.Message;
                }
            }
            
            
            return View();
        }

        //public ActionResult Details(int id)
        //{
        //    Employee employee=new Employee();
        //    if (id!=null)
        //    {
        //        employee = aManager.GetEmployee(id);
        //        if (employee == null)
        //        {
        //            return HttpNotFound();
        //        }
        //    }
            
        //    return View(employee);
        //}

        public JsonResult IsEmpIdExist(string empid)
        {
            bool result = aManager.IsEmployeeIdExist(empid);
            return Json(!result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult IsEmailExist(string email)
        {
            bool result = aManager.IsEmailExist(email);
            return Json(!result, JsonRequestBehavior.AllowGet);
        }
	}
}