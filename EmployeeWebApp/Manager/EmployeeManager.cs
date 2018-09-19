using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EmployeeWebApp.Gateway;
using EmployeeWebApp.Models;

namespace EmployeeWebApp.Manager
{
    public class EmployeeManager
    {
        private EmployeeGateway aGateway=new EmployeeGateway();

        public int Save(Employee employee)
        {
            return aGateway.Save(employee);
        }

        public bool IsEmployeeIdExist(string id)
        {
            return aGateway.IsEmployeeIdExist(id);
        }
        public bool IsEmailExist(string email)
        {
            return aGateway.IsEmailExist(email);
        }

        public List<Employee> GetAllEmployee()
        {
            return aGateway.GetAllEmployee();
        }

        public Employee GetEmployee(int id)
        {
            return aGateway.GetEmployee(id);
        }
    }
}