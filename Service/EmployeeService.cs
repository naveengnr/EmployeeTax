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
                DateTime presentDate = DateTime.Now;
                TimeSpan employmentDuration = presentDate - Employee.DOJ;

                var days = employmentDuration.Days;

                var months = days/30;
                double Salaryperday = Employee.Salary / 30;

                var Yearlysalary = Employee.Salary * 12 ;
                double  tax = 0.0;
                var Totalsalary = days * Salaryperday;
                if(months > 12){

                 if(Yearlysalary >= 250000 && Yearlysalary <= 500000){
                     tax = Yearlysalary * 0.05 ;
                    
                }
                else if (Yearlysalary >= 500000 && Yearlysalary <= 750000){
                     tax = Yearlysalary * 0.10 ;
                   
                }
                else if (Yearlysalary >= 750000 && Yearlysalary <= 100000){
                     tax = Yearlysalary  * 0.20 ;
                 
                }
                }

                else{

                   if(Totalsalary >= 250000 && Totalsalary <= 500000){
                     tax = Totalsalary * 0.05 ;
                    
                }
                else if (Totalsalary >= 500000 && Totalsalary <= 750000){
                     tax = Totalsalary * 0.10 ;
                   
                }
                else if (Totalsalary >= 750000 && Totalsalary <= 100000){
                     tax = Totalsalary  * 0.20 ;
                 
                }
                }

                double cess = 0.02;

                if(Yearlysalary >= 250000){
                    cess = (Yearlysalary - 250000) * cess ;
                   
                }

               var result = new {

                EmployeeId = Employee.EmployeeId,
                Firstname = Employee.Firstname,
                Lastname = Employee.Lastname,
                Yearlysalary = Yearlysalary,
                Totalsalary = Totalsalary,
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
