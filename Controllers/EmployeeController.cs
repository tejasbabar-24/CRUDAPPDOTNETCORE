using CRUDAPPDOTNETCORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace CRUDAPPDOTNETCORE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        [Route("GetAllEmployees")]

        public Response GetAllEmployees()
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetAllEmployees(connection);
            return response;
        }

        [HttpGet]
        [Route("GetEmployeesByid/{id}")]

        public Response GetEmployeesByid(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.GetEmployeesByid(connection, id);
            return response;
        }

        [HttpPost]
        [Route("AddEmployees")]

        public Response AddEmployees(Employee employee)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.AddEmployees(connection, employee);
            return response;
        }

        [HttpPut]
        [Route("UpdateEmployee")]

        public Response UpdateEmployee(Employee employee)
        {
            SqlConnection connnection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.UpdateEmployee(connnection, employee);
            return response;

        }

        [HttpDelete]
        [Route("DeleteEmployee/{id}")]

        public Response DeleteEmployee(int id)
        {
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("CrudConnection").ToString());
            Response response = new Response();
            DAL dal = new DAL();
            response = dal.DeleteEmployee(connection, id);
            return response;
        }

    }
}
