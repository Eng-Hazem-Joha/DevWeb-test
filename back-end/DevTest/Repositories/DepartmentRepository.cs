using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevTest.Models;

namespace DevTest.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {

        private readonly CompanyContext _CompanyContext ;

        public  DepartmentRepository (CompanyContext companyContext)
        {
            this._CompanyContext = companyContext;
        }


        // _____----_______-----______------__________----______

        public Department GetDepartment(int DepId)
        {
            return _CompanyContext.Departments.FirstOrDefault(o=> o.DepartmentId == DepId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _CompanyContext.Departments.ToList();
        }
    }
}
