using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevTest.Repositories;
using DevTest.Models;

namespace DevTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {


        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }


        // Index end point
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }

            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retreving Data From Database");
            }
        }




        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {

            try
            {
               var result =   await _employeeRepository.GetEmployee(id);

                if(result == null )
                {
                    return NotFound($"Employee with id {id} not found");
                }

                return result;
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Retreving Data From Database");
            }


        }





        // Update end point
        [HttpPut("{id:int}")]
        public async Task<ActionResult<Employee>> Update(int id, Employee employee)
        {

            try
            {
                //if (id != employee.EmpId)
                //{
                //    return BadRequest("Id Mismatch");
                //}

                var employeeToUpdate = await _employeeRepository.GetEmployee(id);

                if (employeeToUpdate == null)
                {
                    return NotFound($" employee with id = {id} not found");
                }

                return await _employeeRepository.UpdateEmployee(employee);
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error Updating Data ");
            }

        }


       



        [HttpPost]
        public async Task <ActionResult<Employee>> CreateEmployee(Employee employee)
        {
            try
            {
                if( employee == null)
                {
                    return BadRequest();
                }

               var CreatedEmployee =  await  _employeeRepository.AddEmployee(employee);
                return CreatedAtAction(nameof(GetEmployee) , new { id = CreatedEmployee.EmpId} , CreatedEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error Posting in Database");

            }
        }


    }
}