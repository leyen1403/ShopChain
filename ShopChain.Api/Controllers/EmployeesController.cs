using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopChain.Application.Commands;
using ShopChain.Application.Queries;
using ShopChain.Core.Entities;

namespace ShopChain.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController(ISender sender) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var result = await sender.Send(new GetAllEmployeesQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var result = await sender.Send(new GetEmployeeByID(id));
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            var result = await sender.Send(new AddEmployeeCommand(employee));
            return CreatedAtAction(nameof(GetEmployeeById), new { id = result!.EmployeeID }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee([FromBody] Employee employee)
        {
            var result = await sender.Send(new UpdateEmployeeCommand(employee));
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var result = await sender.Send(new DeleteEmployeeCommand(id));
            return result ? NoContent() : NotFound();
        }
    }
}
