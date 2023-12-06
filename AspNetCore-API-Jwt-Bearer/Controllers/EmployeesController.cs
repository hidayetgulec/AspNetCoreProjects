using AspNetCore_API_Jwt_Bearer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCore_API_Jwt_Bearer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var list = _employeeService.GetAll();
            return Ok(list);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var employee = _employeeService.Get(id);
            return Ok(employee);
        }
    }
}
