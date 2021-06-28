using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;

namespace BasicWebApi
{
    [ApiController]
    [Route("api/person")]
    public class PersonController : Controller
    {
        private readonly PersonService _service;
        public PersonController(PersonService service)
        {
            _service = service;
        }

        
        [HttpGet("{name}")]
        public async Task<IActionResult> ReadSingle(string name)
        {
            var person = _service.GetByName(name);

            if(person == null)
            {
                return NotFound($"Person with name {name} was not found");
            }

            return Ok(person);         
        }

        [HttpGet]
        public async Task<IActionResult> Read()
        {
            var data = _service.GetAll();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Person payload)
        {
            // add an object to the data base here
            Console.WriteLine($"Saving {payload.Name} to the database..");
        
            var createdPerson = _service.CreateNewPerson(payload);

            if(createdPerson == null)
            {
                return BadRequest("Person can not be created, already exists in database");
            }

            return Ok(createdPerson);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Person payload)
        {
            // add an object to the data base here
            Console.WriteLine($"Updating {payload.Name} in the database..");

            var updatedPerson = _service.UpdatePerson(payload);

            if(updatedPerson == null)
            {
                return BadRequest("Person can not be updated, because it does not exist in the database");
            }
            return Ok(updatedPerson);
        }

        [HttpDelete("{name}")]
        public async Task<IActionResult> Delete(string name)
        {
            Console.WriteLine($"Delete {name} in the database..");

            var deletedPerson = _service.DeleteByName(name);
            
            if(deletedPerson == null)
            {
                return BadRequest("Person can not be deleted, because it does not exist in the database");
            }

            return Ok("Deleted");
        }
    }
}