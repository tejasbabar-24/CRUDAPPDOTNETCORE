using System.Data;
using System.Data.SqlClient;

namespace CRUDAPPDOTNETCORE.Models
{
    public class DAL
    {
        public Response GetAllEmployees(SqlConnection connection)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblCrudNetCore", connection);
            DataTable dt = new DataTable();
            List<Employee> lstEmployees = new List<Employee>();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for(int i = 0; i< dt.Rows.Count; i++)
                {
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[i]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[i]["IsActive"]);
                    lstEmployees.Add(employee);
                }
                
            }
            if (lstEmployees.Count > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Data Found";
                response.listEmployee = lstEmployees;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.listEmployee = null;
            }

            return response;
        }

        public Response GetEmployeesByid(SqlConnection connection,int id)
        {
            Response response = new Response();
            SqlDataAdapter da = new SqlDataAdapter("select * from tblCrudNetCore where ID='"+id+"' AND ISActive=1", connection);
            DataTable dt = new DataTable();
            Employee Employees = new Employee();
            da.Fill(dt);
            if (dt.Rows.Count > 0)
            {
               
                    Employee employee = new Employee();
                    employee.Id = Convert.ToInt32(dt.Rows[0]["Id"]);
                    employee.Name = Convert.ToString(dt.Rows[0]["Name"]);
                    employee.Email = Convert.ToString(dt.Rows[0]["Email"]);
                    employee.IsActive = Convert.ToInt32(dt.Rows[0]["IsActive"]);
                    response.StatusCode = 200;
                    response.StatusMessage = "Data Found";
                    response.Employee = employee;
            }
             else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data found";
                response.Employee = null;
            }

            return response;
        }

        public Response AddEmployees(SqlConnection connection,Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("INSERT INTO tblCrudNetCore([Name],[Email],[IsActive],[Createdon]) VALUES('"+employee.Name+"','"+employee.Email+"','"+employee.IsActive+"',GETDATE())", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i> 0)
            {                
                response.StatusCode = 200;
                response.StatusMessage = "Employee Added";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data inserted";
            }

            return response;
        }

        public Response UpdateEmployee(SqlConnection connection, Employee employee)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("UPDATE tblCrudNetCore SET Name='" + employee.Name + "',Email='" + employee.Email + "' WHERE Id='"+employee.Id+"'", connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Employee Updated";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "No data Updated";
            }

            return response;
        }

        public Response DeleteEmployee(SqlConnection connection,int id)
        {
            Response response = new Response();
            SqlCommand cmd = new SqlCommand("DELETE FROM tblCrudNetCore WHERE Id='"+id+"'",connection);
            connection.Open();
            int i = cmd.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "employee Deleted";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "NO Employee Deleted";
            }
            return response;
        }

    }
}
