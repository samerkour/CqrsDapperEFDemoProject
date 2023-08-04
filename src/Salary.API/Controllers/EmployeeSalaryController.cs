using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Salary.Application;
using Salary.Application.Commands;
using Salary.Application.Queries;
using Salary.Application.Response;
using Salary.Application.Shared;
using Salary.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Salary.API.Controllers
{
    [Route("")]
    [ApiController]
    public class EmployeeSalaryController : ControllerBase
    {
        private readonly IMediator _mediator;
        public EmployeeSalaryController(IMediator mediator)
        {
            _mediator = mediator;
        }


        /// <summary>
        /// Gets All Data
        /// </summary>
        /// <returns></returns>
        [HttpGet(template: "api/[controller]/GetAllAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<EmployeeSalary>> GetAllAsync()
        {
            return await _mediator.Send(new GetAllEmployeeSalaryQuery());
        }

        [HttpGet(template: "api/[controller]/GetByIdAsync/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<EmployeeSalary> GetByIdAsync(Int64 id)
        {
            return await _mediator.Send(new GetEmployeeSalaryByIdQuery(id));
        }

        [HttpGet(template: "api/[controller]/GetRangeAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<EmployeeSalary>> GetRangeAsync(DateTime DateFrom, DateTime DateTo)
        {
            return await _mediator.Send(new GetEmployeeSalaryByDateQuery(DateFrom, DateTo));
        }


         /// <summary>
         /// Imports data from json/xml/Cs/Custom object
         /// </summary>
         /// <param name="dataType"></param>
         /// <param name="command"></param>
         /// <returns></returns>
        [HttpPost( template: "api/{dataType}/[controller]/ImportEmployeeSalary")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeSalaryResponse>> ImportEmployeeSalary(ImportDataFormatEnum dataType, [FromBody] ImportEmployeeSalaryDto importEmployeeSalary)
        {
            var command = importEmployeeSalary.CreateEmployeeSalaryCommand(dataType);

            var result = await _mediator.Send(command);
            return Ok(result);
        }

    

        [HttpPost(template: "api/[controller]")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<EmployeeSalaryResponse>> CreateEmployeeSalary([FromBody] CreateEmployeeSalaryCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }


        [HttpPut(template: "api/[controller]/EditEmployeeSalary/{id}")]
        public async Task<ActionResult> EditEmployeeSalary(int id, [FromBody] EditEmployeeSalaryCommand command)
        {
            try
            {
                if (command.Id == id)
                {
                    var result = await _mediator.Send(command);
                    return Ok(result);
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }


        [HttpDelete(template: "api/[controller]/DeleteEmployeeSalary/{id}")]
        public async Task<ActionResult> DeleteEmployeeSalary(int id)
        {
            try
            {
                string result = string.Empty;
                result = await _mediator.Send(new DeleteEmployeeSalaryCommand(id));
                return Ok(result);
            }
            catch (Exception exp)
            {
                return BadRequest(exp.Message);
            }
        }

    }
}
