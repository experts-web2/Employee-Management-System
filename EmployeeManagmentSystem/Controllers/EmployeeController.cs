using Domain.BL.Services.Interfaces;
using Domian.Entities.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmployee(EmployeeDto employeeDto)
        {
            var response = await _employeeService.CreateAsync(employeeDto);
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            var response =  _employeeService.GetAll();
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetEmployeeById(int Id)
        {
            var response =await _employeeService.GetByIdAsync(Id);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateEmployee(EmployeeDto employeeDto)
        {
            var response = _employeeService.Update(employeeDto);
            return Ok(response);
        }

        [HttpDelete("Delete/{Id}")]
        public IActionResult DeleteEmployee(int Id)
        {
            _employeeService.Delete(Id);
            return Ok();
        }
    }
}
