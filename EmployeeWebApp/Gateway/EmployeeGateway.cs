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
            string query = @"INSERT INTO [dbo].[Employee]
           ([EmpId]
           ,[Name]
           ,[Email]
           ,[Salary])
            VALUES('"+employee.EmpId+"','"+employee.Name+"','"+employee.Email+"','"+employee.Salary+"')";
            SqlCommand cmd=new SqlCommand(query,con);
            con.Open();
            int rowAffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowAffected;
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
    }
}