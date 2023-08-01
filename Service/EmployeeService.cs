using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using EmployeeTax.Data;
using EmployeeTax.Models;

namespace EmployeeTax.Service
{

    public class EmployeeService : ControllerBase
    {

        public readonly EmployeeContext? _context;

        public EmployeeService(EmployeeContext context)
        {

            _context = context;
        }

        public List<Employees> GetEmployeeById(int EmployeeId)
        {
            return _context.Employees.Include(e => e.details).Where(e => e.EmployeeId == EmployeeId).ToList();
        }


        public ActionResult<Object> GetEmployeeTax(int EmployeeId)
        {

            var Employee = _context.Employees.Find(EmployeeId);

            if (Employee == null)
            {
                return NotFound($"Employee with {EmployeeId} is Not Found");
            }

            else
            {
                

                var Yearlysalary = Employee.Salary * 12 ;
                double  tax = 0.0;

                 if(Yearlysalary >= 250000 && Yearlysalary <= 500000){
                     tax = Yearlysalary * 0.05 ;
                    
                }
                else if (Yearlysalary >= 500000 && Yearlysalary <= 750000){
                     tax = Yearlysalary * 0.10 ;
                   
                }
                else if (Yearlysalary >= 750000 && Yearlysalary <= 100000){
                     tax = Yearlysalary * 0.20 ;
                 
                }

                double cess = 0.02;

                if(Yearlysalary >= 250000){
                    cess = (Yearlysalary - 250000)* cess ;
                   
                }

                double Salaryperday = Employee.Salary / 30;

               var result = new {

                EmployeeId = Employee.EmployeeId,
                Firstname = Employee.Firstname,
                Lastname = Employee.Lastname,
                Yearlysalary = Yearlysalary,
                monthlysalary = Employee.Salary,
                Salaryperday = Salaryperday,
                taxamount = tax,
                cessamount = cess
               };
                   

                return Ok(result);
            }
        }

    }
}
