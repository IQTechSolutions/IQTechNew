using Employment.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employement.RestApi.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeServiceManager _service;

        public EmployeesController(IEmployeeServiceManager service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var companies = _service.EmployeeService.GetAllCompanies(false);
                return Ok(companies);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
