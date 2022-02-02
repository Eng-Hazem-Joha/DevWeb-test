using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DevTest.Models
{
    public class Employee
    {

        [Key]
        public int EmpId { get; set; }

        public string EmpFirstName { get; set; }

        public string EmpLastName { get; set; }

        public string EmpAddress { get; set; }

        public string EmpEmail { get; set; }

        [DataType(DataType.Date)]
        public DateTime EmpBirthDate { get; set; }
        
        public double EmpPhoneNumber { get; set; }

        public int? DepartmentId { get; set; }

        //Relation

        public virtual Department Department { get; set; }



    }
}
