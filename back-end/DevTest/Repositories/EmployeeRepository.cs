using DevTest.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTest.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly CompanyContext _companyContext;

        public EmployeeRepository(CompanyContext companyContext)
        {

            this._companyContext = companyContext;

        }

        // _____----_______-----______------__________----______

        public async Task<Employee> AddEmployee(Employee employee)
        {
           var Result = await _companyContext.Employees.AddAsync(employee);
           await  _companyContext.SaveChangesAsync();
           return Result.Entity;
        }

        // _____----_______-----______------__________----______

        public async void DeleteEmployee(int EmpId)
        {

            var Result = await _companyContext.Employees.FirstOrDefaultAsync(o => o.EmpId == EmpId);
            if(Result != null)
            {
                _companyContext.Employees.Remove(Result);
                await _companyContext.SaveChangesAsync();
            }

            
        }

        // _____----_______-----______------__________----______

        public async Task<Employee> GetEmployee(int EmpId)
        {
            return await _companyContext.Employees.FirstOrDefaultAsync(o => o.EmpId == EmpId);
        }


        // _____----_______-----______------__________----______

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await _companyContext.Employees.ToListAsync();
        }

        // _____----_______-----______------__________----______

        public async Task<Employee> UpdateEmployee(Employee employee)
        {
            var Result = await _companyContext.Employees.FirstOrDefaultAsync(o => o.EmpId == employee.EmpId);

            if(Result != null)
            {
                Result.EmpFirstName = employee.EmpFirstName;
                Result.EmpLastName = employee.EmpLastName;
                Result.EmpAddress = employee.EmpAddress;
                Result.EmpEmail = employee.EmpEmail;
                Result.EmpBirthDate = employee.EmpBirthDate;
                Result.EmpPhoneNumber = employee.EmpPhoneNumber;
                Result.Department.DepartmentId = employee.Department.DepartmentId;
                Result.Department.DepartmentName = employee.Department.DepartmentName;

                await _companyContext.SaveChangesAsync();
                return Result;
            }

            return null;
        }
    }
}
