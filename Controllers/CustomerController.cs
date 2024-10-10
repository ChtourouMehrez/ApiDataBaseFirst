
using ApiDataBaseFirst.DTO;
using ApiDataBaseFirst.Entities;
using ApiDataBaseFirst.Repository.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiDataBaseFirst.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepostory _repository;
        public CustomerController(ICustomerRepostory _repository)
        {
            this._repository = _repository;
        }
        //GET: CustomerController
        [HttpPost("add")]
        public async Task<ActionResult> add([FromBody] Customer c)
        {
            await _repository.add(c);
            return CreatedAtAction(nameof(GetCustomer), new { id = c.Id, Name = c.Name }, c);
        }
        [HttpGet("{id}")]

        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            return await _repository.GetCustomerAsync(id);
        }
        
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllAsync()
        {
            return Ok(await _repository.GetAllAsyncCustomer());
        }
        [HttpGet("all/dto")]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustromerDto()
        {
            return Ok(await _repository.GetAllAsyncCustomerDTO());
        }

        [HttpDelete("Remove/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var customer = await _repository.GetCustomerAsync(id);
            if (customer == null)
                return NotFound();
            await _repository.delete(id);
            return NoContent();
        }
        [HttpPut("Update/{id}")]
        public async Task<ActionResult> update(int id, [FromBody] Customer c)
        {
            if (id != c.Id)
                return BadRequest();
            await _repository.Update(c);
            return NoContent();
        }
    }
}
