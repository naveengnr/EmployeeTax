using System;
using Microsoft.AspNetCore.Mvc;
using EmployeeTax.Data;
using EmployeeTax.Service;
using EmployeeTax.Models;

using Microsoft.EntityFrameworkCore;

namespace EmployeeTax.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        public readonly EmployeeService service;


        public EmployeeController(EmployeeService _service)
        {
            service = _service;
        }



        [HttpGet("{id}")]
        public ActionResult<Employees> GetEmployeeById(int id)
        {
            var employee = service.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
           
            return Ok(employee);
        }

        [HttpGet]
        public ActionResult<Object> getmonths(int EmployeeId){

            return service.GetEmployeeTax(EmployeeId);
        }
    }
}