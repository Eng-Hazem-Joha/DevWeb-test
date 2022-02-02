using DevTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevTest.Repositories
{
    public interface IDepartmentRepository
    {

        IEnumerable<Department> GetDepartments();

        Department GetDepartment(int DepId);

    }
}
