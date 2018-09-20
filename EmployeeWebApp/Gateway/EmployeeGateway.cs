using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using EmployeeWebApp.Models;

namespace EmployeeWebApp.Gateway
{
    public class EmployeeGateway
    {
        private SqlConnection con = new SqlConnection(WebConfigurationManager.ConnectionStrings["EIDB"].ConnectionString);

        public int Save(Employee employee)
        {
            try
            {
                string query = @"INSERT INTO [dbo].[Employee]
           ([EmpId]
           ,[Name]
           ,[Email]
           ,[Salary])
            VALUES('" + employee.EmpId + "','" + employee.Name + "','" + employee.Email + "','" + employee.Salary + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                int rowAffected = cmd.ExecuteNonQuery();
                con.Close();
                return rowAffected;
            }
            catch (Exception exception)
            {
                throw new Exception("Unable to connect Server", exception);
            }
            finally
            {
                con.Close();
            }
        }

        public bool IsEmployeeIdExist(string id)
        {
            string query = @"select * from [dbo].[Employee] where(EmpId=@EmpId)";
            SqlCommand cmd=new SqlCommand(query,con);
            con.Open();
            bool isExist = false;
            cmd.Parameters.AddWithValue("@EmpId", id);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            isExist = reader.HasRows;
            reader.Close();
            con.Close();
            return isExist;
        }
        public bool IsEmailExist(string email)
        {
            string query = @"select * from [dbo].[Employee] where(Email=@Email)";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            bool isExist = false;
            cmd.Parameters.AddWithValue("@Email", email);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Read();
            isExist = reader.HasRows;
            reader.Close();
            con.Close();
            return isExist;
        }

        public List<Employee> GetAllEmployee()
        {
            string query = @"select * from [dbo].[Employee]";
            SqlCommand cmd=new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<Employee> aList=new List<Employee>();
            while (reader.Read())
            {
                Employee employee=new Employee();
                employee.Id = (int) reader["Id"];
                employee.EmpId = reader["EmpId"].ToString();
                employee.Name = reader["Name"].ToString();
                employee.Email = reader["Email"].ToString();
                employee.Salary = Convert.ToDouble(reader["Salary"]);
                aList.Add(employee);

            }
            reader.Close();
            con.Close();
            return aList;
        }
        //public Employee GetEmployee(int id)
        //{
        //    string query = @"select * from [dbo].[Employee] where Id='"+id+"'";
        //    SqlCommand cmd = new SqlCommand(query, con);
        //    con.Open();
        //    SqlDataReader reader = cmd.ExecuteReader();
        //    Employee employee = new Employee();
        //    while (reader.Read())
        //    {
                
        //        employee.Id = (int)reader["Id"];
        //        employee.EmpId = reader["EmpId"].ToString();
        //        employee.Name = reader["Name"].ToString();
        //        employee.Email = reader["Email"].ToString();
        //        employee.Salary = Convert.ToDouble(reader["Salary"]);

        //    }
        //    reader.Close();
        //    con.Close();
        //    return employee;
        //}

        public string GetTotalAmount()
        {
            string query = @"select sum(Salary) as Amount from [dbo].[Employee] ";
            SqlCommand cmd=new SqlCommand(query, con);
            con.Open();
            string amount="";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                amount = reader["Amount"].ToString();
            }
            reader.Close();
            con.Close();
            return amount;

        }
    }
}