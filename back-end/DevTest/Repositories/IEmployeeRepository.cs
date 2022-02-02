using DevTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTest.Controllers;

namespace DevTest.Repositories
{
   public interface IEmployeeRepository
    {

        Task<IEnumerable<Employee>> GetEmployees();

        Task<Employee> GetEmployee( int EmpId);

        Task<Employee> AddEmployee(Employee employee);

        Task<Employee> UpdateEmployee(Employee employee);

        void DeleteEmployee(int EmpId);
    
    }
}
