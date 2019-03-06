using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Supervisor;
using Domain.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nest;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeSupervisor _employeeSupervisor;
        private readonly IElasticClient _elasticClient;

        public EmployeeController(IEmployeeSupervisor employeeSupervisor, IElasticClient elasticClient)
        {
            _employeeSupervisor = employeeSupervisor;
            _elasticClient = elasticClient;

        }

        // GET: api/Employee
        [HttpGet]
        public IActionResult  Get()
        {
            return new ObjectResult(_employeeSupervisor.GetEmployees());
           // return new string[] { "value1", "value2" };
        }

        // GET: api/Employee/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Employee
        [HttpPost]
        public IActionResult Post([FromBody] EmployeeViewModel value)
        {
            return new ObjectResult(_employeeSupervisor.AddEmployee(value));
             
        }

        // PUT: api/Employee/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] EmployeeViewModel value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
