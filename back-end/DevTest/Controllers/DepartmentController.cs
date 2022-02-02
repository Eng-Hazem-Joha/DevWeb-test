using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DevTest.Repositories;

namespace DevTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {

        private readonly IDepartmentRepository _departmentRepository;
        public DepartmentController( IDepartmentRepository departmentRepository)
        {
            this._departmentRepository = departmentRepository;
        }


        //Index end point
        [HttpGet]
        public IActionResult  Index()
        {
            try
            {
                return Ok( _departmentRepository.GetDepartments());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Error Retreving Data From Database");
            }
        }




    }
}