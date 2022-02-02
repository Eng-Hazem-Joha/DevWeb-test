using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DevTest.Models
{
    public class Department
    {

        [Key]
        public int DepartmentId { get; set; }

        public string DepartmentName { get; set; }

        public string DepartmentLocation { get; set; }


        //Relation

        public virtual ICollection <Employee> Employees { get; set; }




    }
}
